Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports PrototipoAfip.WSFEHOMO

Public Module AfipWorkflow
    Public Enum AfipEnvironment
        Homologacion
        Produccion
    End Enum

    ''' <summary>
    ''' Ejecuta el flujo completo de login WSAA + solicitud FECAE para un único comprobante.
    ''' Crea el número siguiente en AFIP, autentica la sesión (o reutiliza una existente) y devuelve la respuesta cruda.
    ''' Ejemplo de uso:
    ''' Dim resp = AfipWorkflow.EmitirFacturaAfip(miFactura, "C:\cert.pfx", "1234", "wsfe", 20123456789, "PES", AfipEnvironment.Homologacion)
    ''' </summary>
    ''' <param name="factura">Instancia precargada con importes, detalles, punto de venta, cbte tipo, concepto, doc tipo y doc nro.</param>
    ''' <param name="certificadoPath">Ruta absoluta al archivo .pfx que contiene la clave privada. Se ignora si se pasa un login existente.</param>
    ''' <param name="certificadoPassword">Contraseña del certificado .pfx. Se ignora si se pasa un login existente.</param>
    ''' <param name="servicio">Nombre lógico del servicio (generalmente "wsfe").</param>
    ''' <param name="cuitEmisor">CUIT del emisor utilizado para autenticar la solicitud.</param>
    ''' <param name="monedaCodigo">Código AFIP de la moneda (ej. "PES" para pesos).</param>
    ''' <param name="ambiente">Ambiente AFIP al que se quiere apuntar (homologación o producción).</param>
    ''' <param name="monedaCotizacion">Cotización de la moneda frente al peso; 1 para ARS.</param>
    Public Function EmitirFacturaAfip(factura As Factura,
                                      certificadoPath As String,
                                      certificadoPassword As String,
                                      servicio As String,
                                      cuitEmisor As Long,
                                      monedaCodigo As String,
                                      ambiente As AfipEnvironment,
                                      Optional monedaCotizacion As Decimal = 1D,
                                      Optional loginExistente As LoginClass = Nothing) As FECAEResponse

        ' Validaciones básicas antes de llamar a servicios remotos.
        If factura Is Nothing Then Throw New ArgumentNullException(NameOf(factura))
        If factura.Detalles Is Nothing OrElse factura.Detalles.Count = 0 Then Throw New ArgumentException("La factura debe contener al menos un detalle.", NameOf(factura))
        If factura.Fecha = Date.MinValue Then Throw New ArgumentException("La factura debe indicar Fecha.", NameOf(factura))
        If Not factura.TipoFacturaId.HasValue Then Throw New ArgumentException("La factura debe indicar TipoFacturaId.", NameOf(factura))
        If Not factura.PuntoVenta.HasValue Then Throw New ArgumentException("La factura debe indicar PuntoVenta.", NameOf(factura))
        If Not factura.DocTipo.HasValue Then Throw New ArgumentException("La factura debe indicar DocTipo.", NameOf(factura))
        If Not factura.Documento.HasValue Then Throw New ArgumentException("La factura debe indicar Documento.", NameOf(factura))
        If String.IsNullOrWhiteSpace(monedaCodigo) Then Throw New ArgumentException("Debe indicar un código de moneda AFIP válido.", NameOf(monedaCodigo))
        If monedaCotizacion <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(monedaCotizacion), "La cotización debe ser mayor a cero.")

        ' Paso 1: autenticación contra WSAA para obtener token y sign válidos o reutilizar un login existente.
        Dim urls = ResolverUrls(ambiente)
        Dim login = loginExistente
        If login Is Nothing Then
            If String.IsNullOrWhiteSpace(certificadoPath) OrElse Not File.Exists(certificadoPath) Then
                Throw New ArgumentException("Debe indicar un certificado .pfx válido o proporcionar un login autenticado.", NameOf(certificadoPath))
            End If
            login = New LoginClass(servicio, urls.LoginUrl, certificadoPath, certificadoPassword)
            login.hacerLogin()
        ElseIf Not login.Logeado Then
            Throw New InvalidOperationException("El login proporcionado no posee token/sign vigentes. Realice el login nuevamente.")
        End If

        ' Paso 2: arma el request de autenticación que reutilizan todas las llamadas a WSFE.
        Dim auth = New FEAuthRequest With {
            .Cuit = cuitEmisor,
            .Sign = login.Sign,
            .Token = login.Token
        }

        ' Paso 3: inicializa el cliente SOAP de WSFE y adjunta el certificado para TLS.
        Dim service As New Service With {.Url = urls.WsfeUrl}
        If login.certificado IsNot Nothing Then
            service.ClientCertificates.Add(login.certificado)
        End If

        ' Paso 4: arma la cabecera del comprobante y calcula el próximo número autorizado.
        Dim cabecera As New FECAECabRequest With {
            .CantReg = 1,
            .PtoVta = factura.PuntoVenta.Value,
            .CbteTipo = factura.TipoFacturaId.Value
        }
        Dim ultimo = service.FECompUltimoAutorizado(auth, cabecera.PtoVta, cabecera.CbteTipo)
        Dim numero = ultimo.CbteNro + 1

        ' Paso 5: prepara las líneas de IVA usando el catálogo oficial que devuelve AFIP.
        Dim ivaCatalogo = service.FEParamGetTiposIva(auth).ResultGet
        Dim ivaLineas = ConstruirIvaArray(factura, ivaCatalogo)
        Dim ivaTotal = ivaLineas.Sum(Function(i) Convert.ToDecimal(i.Importe))

        ' Paso 6: completa el detalle del comprobante con importes y totales consolidados.
        Dim detalle As New FECAEDetRequest With {
            .Concepto = factura.Concepto.GetValueOrDefault(1),
            .DocTipo = factura.DocTipo.Value,
            .DocNro = factura.Documento.Value,
            .CbteDesde = numero,
            .CbteHasta = numero,
            .CbteFch = factura.Fecha.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
            .ImpNeto = Convert.ToDouble(factura.SubTotalNeto),
            .ImpIVA = Convert.ToDouble(ivaTotal),
            .ImpTrib = 0,
            .ImpTotConc = 0,
            .ImpOpEx = 0,
            .ImpTotal = Convert.ToDouble(factura.Total),
            .MonId = monedaCodigo,
            .MonCotiz = Convert.ToDouble(monedaCotizacion),
            .Iva = ivaLineas
        }

        If detalle.Concepto <> 1 Then
            ' Para servicios la AFIP exige informar período y vencimiento.
            detalle.FchServDesde = factura.Fecha.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
            If factura.FechaVencimiento <> Date.MinValue Then
                Dim vto = factura.FechaVencimiento.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
                detalle.FchServHasta = vto
                detalle.FchVtoPago = vto
            End If
        End If

        ' Paso 7: arma y envía la solicitud FECAE con un único registro.
        Dim solicitud As New FECAERequest With {
            .FeCabReq = cabecera,
            .FeDetReq = {detalle}
        }

        Return service.FECAESolicitar(auth, solicitud)
    End Function

    Private Function ResolverUrls(ambiente As AfipEnvironment) As AfipEndpoints
        Select Case ambiente
            Case AfipEnvironment.Homologacion
                Return New AfipEndpoints With {
                    .LoginUrl = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms",
                    .WsfeUrl = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx"
                }
            Case AfipEnvironment.Produccion
                Return New AfipEndpoints With {
                    .LoginUrl = "https://wsaa.afip.gov.ar/ws/services/LoginCms",
                    .WsfeUrl = "https://servicios1.afip.gov.ar/wsfev1/service.asmx"
                }
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(ambiente))
        End Select
    End Function

    Private Function ConstruirIvaArray(factura As Factura, catalogo As IvaTipo()) As AlicIva()
        If catalogo Is Nothing OrElse catalogo.Length = 0 Then
            Throw New InvalidOperationException("El catálogo de tipos de IVA no devolvió resultados.")
        End If

        Dim resultado As New List(Of AlicIva)

        For Each subtotal In factura.SubTotalesIva
            Dim ivaTipoId = BuscarIvaId(subtotal.Alicuota, catalogo)
            Dim baseImponible = factura.Detalles.Where(Function(d) d.Alicuota = subtotal.Alicuota).Sum(Function(d) d.Subtotal)
            Dim iva = New AlicIva With {
                .Id = ivaTipoId,
                .BaseImp = Convert.ToDouble(Decimal.Round(baseImponible, 2, MidpointRounding.AwayFromZero)),
                .Importe = Convert.ToDouble(Decimal.Round(subtotal.Valor, 2, MidpointRounding.AwayFromZero))
            }
            resultado.Add(iva)
        Next

        Return resultado.ToArray()
    End Function

    Private Function BuscarIvaId(alicuota As Decimal, catalogo As IvaTipo()) As Short
        For Each item In catalogo
            Dim texto = item.Desc.Replace("%", "").Trim()
            Dim valor As Decimal
            If Decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, valor) OrElse
               Decimal.TryParse(texto, NumberStyles.Any, CultureInfo.CurrentCulture, valor) Then
                If Math.Abs(valor - alicuota) < 0.0001D Then
                    Return item.Id
                End If
            End If
        Next

        Throw New InvalidOperationException($"No se encontró el código de IVA para la alícuota {alicuota}.")
    End Function
    Private Class AfipEndpoints
        Public Property LoginUrl As String
        Public Property WsfeUrl As String
    End Class
End Module
