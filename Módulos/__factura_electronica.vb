Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports Centrex.Afip

Module factura_electronica
    ' ============================================
    ' CONFIGURACIÓN CENTRALIZADA
    ' ============================================
    Private _configuracionActual As ConfiguracionAFIP = Nothing

    ''' <summary>
    ''' Clase que contiene toda la configuración necesaria para AFIP
    ''' </summary>
    Public Class ConfiguracionAFIP
        Public Property Modo As String
        Public Property EsTest As Boolean
        Public Property ArchivoCertificado As String
        Public Property ArchivoLicencia As String
        Public Property PasswordCertificado As String
        Public Property CuitEmisor As String
        Public Property AfipMode As AfipMode

        Public Function EsValida() As Boolean
            Return Not String.IsNullOrWhiteSpace(ArchivoCertificado) AndAlso
                   File.Exists(ArchivoCertificado) AndAlso
                   Not String.IsNullOrWhiteSpace(CuitEmisor)
        End Function
    End Class

    ''' <summary>
    ''' Inicializa la configuración de AFIP - PUNTO DE PARTIDA ÚNICO
    ''' Debe ser llamada antes de cualquier operación con AFIP
    ''' </summary>
    Public Function InicialesFE(ByVal esTest As Boolean) As ConfiguracionAFIP
        Dim pc As String = Environment.MachineName
        Dim config As New ConfiguracionAFIP()

        config.EsTest = esTest

        If esTest Then
            config.Modo = "Test"  ' HOMOLOGACIÓN - certificados de prueba
            config.AfipMode = AfipMode.HOMO

            Select Case pc
                Case Is = "JARVIS"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                Case Is = "SERVTEC-06"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                Case Is = "BRUNO"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\bruno2023_prueba.pfx"
                Case Is = "SILVIA"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\SILVIA.pfx"
                Case Else
                    MsgBox("PC no habilitada para emitir documentos de testing.", vbCritical + vbOKOnly, "Centrex")
                    Return Nothing
            End Select
            config.ArchivoLicencia = ""
        Else
            config.Modo = "Fiscal"  ' PRODUCCIÓN - certificados fiscales
            config.AfipMode = AfipMode.PROD

            Select Case pc
                Case Is = "JARVIS"
                    'config.ArchivoCertificado = Application.StartupPath + "\Certificados\JARVIS.pfx"
                    'config.ArchivoCertificado = Application.StartupPath + "\Certificados\BRUNO.pfx"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\JARVISDR.pfx"
                Case Is = "SERVTEC-06"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\JARVIS.pfx"
                Case Is = "BRUNO"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\Bruno.pfx"
                Case Is = "SILVIA"
                    config.ArchivoCertificado = Application.StartupPath + "\Certificados\SILVIA.pfx"
                Case Else
                    MsgBox("PC no habilitada para emitir documentos fiscales.", vbCritical + vbOKOnly, "Centrex")
                    Return Nothing
            End Select
            config.ArchivoLicencia = ""
        End If

        If Not File.Exists(config.ArchivoCertificado) Then
            MsgBox("No existe el archivo del certificado, no podrá continuar.", vbCritical + vbOKOnly, "Centrex")
            Return Nothing
        End If

        config.CuitEmisor = cuit_emisor_default
        config.PasswordCertificado = "Ladeda78"

        ' Configurar valores dinámicos en AfipConfig
        AfipConfig.DynamicCertPath = config.ArchivoCertificado
        AfipConfig.DynamicCertPassword = config.PasswordCertificado
        AfipConfig.DynamicCuitEmisor = CLng(config.CuitEmisor)

        ' Guardar configuración actual para uso en el módulo
        _configuracionActual = config

        WriteLog("InicialesFE", $"Configuración inicializada: Modo={config.Modo}, PC={pc}, Cert={Path.GetFileName(config.ArchivoCertificado)}")

        Return config
    End Function

    ''' <summary>
    ''' Obtiene la configuración actual de AFIP
    ''' </summary>
    Public Function ObtenerConfiguracionActual() As ConfiguracionAFIP
        Return _configuracionActual
    End Function

    ''' <summary>
    ''' Verifica si hay una configuración válida cargada
    ''' </summary>
    Public Function TieneConfiguracionValida() As Boolean
        Return _configuracionActual IsNot Nothing AndAlso _configuracionActual.EsValida()
    End Function

    ' ============================================
    ' OPERACIONES AFIP
    ' ============================================

    ''' <summary>
    ''' Prueba de conexión con AFIP (WSAA + WSFE)
    ''' </summary>
    Public Function ProbarConexionAFIP(esTest As Boolean) As Boolean
        Try
            ' Inicializar configuración
            Dim config = InicialesFE(esTest)
            If config Is Nothing Then
                Return False
            End If

            ' Crear instancia WSFEv1 usando la configuración
            Dim wsfe = WSFEv1.CreateWithTa(config.AfipMode)
            Dim resultado = wsfe.FEDummy()
            WriteLog("ProbarConexionAFIP", "Conectado correctamente. " & resultado)
            MsgBox("Conexión correcta con AFIP: " & resultado, vbInformation)
            Return True
        Catch ex As Exception
            WriteLog("ProbarConexionAFIP", "Error: " & ex.Message)
            MsgBox("Error de conexión AFIP: " & ex.Message, vbCritical)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Consulta último comprobante autorizado
    ''' </summary>
    Public Function ConsultaUltimoComprobante(ByVal puntoVenta As String, ByVal tipoComprobante As String, ByVal esTest As Boolean) As Integer
        Try
            ' Inicializar configuración
            Dim config = InicialesFE(esTest)
            If config Is Nothing Then
                Return 0
            End If

            ' Crear instancia WSFEv1 usando la configuración
            Dim wsfe = WSFEv1.CreateWithTa(config.AfipMode)

            Return wsfe.FECompUltimoAutorizado(CInt(puntoVenta), CInt(tipoComprobante))

        Catch ex As ApplicationException
            ' Si el error es sobre punto de venta no habilitado, mostrar puntos de venta disponibles
            If ex.Message.Contains("punto de venta no se encuentra habilitado") Then
                Try
                    ' Reinicializar WSFEv1 para consulta adicional
                    Dim config = ObtenerConfiguracionActual()
                    Dim wsfe = WSFEv1.CreateWithTa(config.AfipMode)

                    Dim puntosVenta = wsfe.FEParamGetPtosVenta()
                    Dim mensajeDetallado = "Error: " & ex.Message & vbCrLf & vbCrLf &
                                         "Punto de venta solicitado: " & puntoVenta & vbCrLf & vbCrLf &
                                         "Puntos de venta habilitados en AFIP:" & vbCrLf

                    ' Agregar información de puntos de venta habilitados
                    If puntosVenta IsNot Nothing Then
                        mensajeDetallado &= "Consulta FEParamGetPtosVenta ejecutada correctamente." & vbCrLf &
                                          "Revisa la respuesta en los logs de consola para ver los puntos de venta habilitados."
                    End If

                    Throw New ApplicationException(mensajeDetallado, ex)
                Catch innerEx As Exception
                    ' Si falla la consulta de puntos de venta, mostrar el error original
                    Throw New ApplicationException("Error: " & ex.Message & vbCrLf & vbCrLf &
                                                  "Error adicional al consultar puntos de venta: " & innerEx.Message, ex)
                End Try
            Else
                ' Para otros errores, re-lanzar tal como están
                Throw
            End If
        End Try
    End Function

    ''' <summary>
    ''' Emite comprobante electrónico o manual según configuración
    ''' </summary>
    Public Function Facturar(ByVal p As pedido) As Boolean
        Try
            Dim cl As New cliente
            Dim c As New comprobante

            'Obtengo los datos del comprobante
            c = info_comprobante(p.id_comprobante)

            ' ============================================
            ' EVALUACIÓN: ¿Es comprobante manual?
            ' Se evalúa c.testing para determinar si es manual
            ' ============================================
            If c.esPresupuesto Or c.esManual Or c.testing Then
                WriteLog("Facturar", $"Comprobante MANUAL/PRESUPUESTO: esPresupuesto={c.esPresupuesto}, esManual={c.esManual}, testing={c.testing}")

                ' Incrementar número de comprobante manualmente
                c.numeroComprobante += 1
                updatecomprobante(c)

                ' Actualizar pedido
                p.cerrado = True
                p.activo = False
                p.puntoVenta = c.puntoVenta

                If c.esPresupuesto Then
                    p.idPresupuesto = c.numeroComprobante
                    p.numeroComprobante = 0
                Else
                    p.numeroComprobante = c.numeroComprobante
                    p.idPresupuesto = 0
                End If

                UpdatePedido(p)
                WriteLog("Facturar", $"Comprobante manual procesado correctamente. Número: {c.numeroComprobante}")
                Return True
            End If

            ' ============================================
            ' FACTURACIÓN ELECTRÓNICA AFIP
            ' ============================================

            ' Inicializar configuración basada en c.testing
            Dim config = InicialesFE(Not c.testing) ' Si c.testing es False, usar modo PROD
            If config Is Nothing Then
                WriteLog("Facturar", "Error: No se pudo inicializar configuración AFIP")
                Return False
            End If

            WriteLog("Facturar", $"Facturación ELECTRÓNICA: Modo={config.Modo}, testing={c.testing}")

            ' Crear instancia WSFEv1 con la configuración
            Dim wsfe = WSFEv1.CreateWithTa(config.AfipMode)

            Dim auth = New AfipAuth With {
                .Cuit = AfipConfig.GetCuitEmisor(),
                .Sign = "",
                .Token = ""
            }

            ' Arma la solicitud
            Dim req As New WSFEHomo.FECAERequest()
            Dim cab = New WSFEHomo.FECAECabRequest() With {
                .CantReg = 1,
                .CbteTipo = c.id_tipoComprobante,
                .PtoVta = c.puntoVenta
            }

            Dim det = New WSFEHomo.FECAEDetRequest() With {
                .Concepto = 1,
                .DocTipo = 80,
                .DocNro = 0,
                .CbteDesde = p.numeroComprobante,
                .CbteHasta = p.numeroComprobante,
                .CbteFch = DateTime.Now.ToString("yyyyMMdd"),
                .ImpTotal = p.total,
                .ImpNeto = p.subTotal,
                .ImpIVA = p.iva,
                .ImpOpEx = 0,
                .ImpTrib = 0,
                .MonId = "PES",
                .MonCotiz = 1
            }

            Dim iva(0) As WSFEHomo.AlicIva
            iva(0) = New WSFEHomo.AlicIva() With {.Id = 5, .BaseImp = p.subTotal, .Importe = p.iva}
            det.Iva = iva
            req.FeCabReq = cab
            req.FeDetReq = New WSFEHomo.FECAEDetRequest() {det}

            Dim resp = wsfe.FECAESolicitar(req)

            If resp Is Nothing OrElse resp.FeDetResp Is Nothing Then
                Throw New Exception("Sin respuesta de AFIP.")
            End If

            Dim detResp = resp.FeDetResp(0)
            If detResp.Resultado <> "A" Then
                WriteLog("Facturar", "Rechazado: " & ErrorFE(resp))
                MsgBox("Comprobante rechazado por AFIP." & vbCrLf & ErrorFE(resp), vbExclamation)
                Return False
            End If

            p.cae = detResp.CAE
            p.fechaVencimiento_cae = detResp.CAEFchVto

            WriteLog("Facturar", $"Autorizado. CAE: {p.cae} - Vto: {p.fechaVencimiento_cae}")
            Return True

        Catch ex As Exception
            WriteLog("Facturar", "Error: " & ex.Message)
            MsgBox("Error al facturar: " & ex.Message, vbCritical)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Devuelve mensaje de error detallado
    ''' </summary>
    Private Function ErrorFE(resp As Object) As String
        Try
            Dim sb As New System.Text.StringBuilder()
            If resp.Errors IsNot Nothing Then
                For Each e In resp.Errors
                    sb.AppendLine($"Código {e.Code}: {e.Msg}")
                Next
            End If
            If resp.FeDetResp IsNot Nothing Then
                For Each d In resp.FeDetResp
                    If d.Observaciones IsNot Nothing Then
                        For Each o In d.Observaciones
                            sb.AppendLine($"Obs {o.Code}: {o.Msg}")
                        Next
                    End If
                Next
            End If
            Return sb.ToString()
        Catch
            Return "Error desconocido en respuesta AFIP."
        End Try
    End Function

    ''' <summary>
    ''' Genera el QR oficial AFIP usando configuración actual
    ''' </summary>
    Public Function CrearQR(p As pedido) As String
        Try
            ' Obtener configuración actual
            Dim config = ObtenerConfiguracionActual()
            If config Is Nothing Then
                WriteLog("CrearQR", "Error: No hay configuración AFIP inicializada")
                Return ""
            End If

            Dim cuitEmisor = config.CuitEmisor

            Dim json = $"{{""ver"":1,""fecha"":""{DateTime.Now:yyyy-MM-dd}"",""cuit"":{cuitEmisor},""ptoVta"":{p.puntoVenta},""tipoCmp"":1,""nroCmp"":{p.numeroComprobante},""importe"":{p.total},""moneda"":""PES"",""ctz"":1,""tipoDocRec"":80,""nroDocRec"":0,""tipoCodAut"":""E"",""codAut"":""{p.cae}""}}"
            Dim bytes = System.Text.Encoding.UTF8.GetBytes(json)
            Dim b64 = Convert.ToBase64String(bytes)
            Dim url = $"https://www.afip.gob.ar/fe/qr/?p={b64}"

            Dim qr = New MessagingToolkit.QRCode.Codec.QRCodeEncoder()
            Dim img = qr.Encode(url)
            Dim nombreArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"QR_{p.id_pedido}.jpg")
            img.Save(nombreArchivo, ImageFormat.Jpeg)
            WriteLog("CrearQR", $"QR generado: {nombreArchivo}")
            Return nombreArchivo
        Catch ex As Exception
            WriteLog("CrearQR", "Error: " & ex.Message)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Guarda QR en la base de datos
    ''' </summary>
    Public Function Guardar_QR_DB(archivo_imagen As String, id_pedido As Integer) As Boolean
        Try
            Dim con As New SqlConnection("Server=" & serversql & ";Database=" & basedb & ";Uid=" & usuariodb & ";Password=" & passdb)
            Dim img = Image.FromFile(archivo_imagen)
            Dim ms As New MemoryStream()
            img.Save(ms, ImageFormat.Jpeg)
            Dim md = ms.ToArray()

            Dim sqlstr = "UPDATE Pedidos SET fc_qr=@qr WHERE id_pedido=@id"
            Dim cmd As New SqlCommand(sqlstr, con)
            cmd.Parameters.Add("@qr", SqlDbType.Image).Value = md
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id_pedido
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            WriteLog("Guardar_QR_DB", $"QR guardado en DB para pedido {id_pedido}")
            Return True
        Catch ex As Exception
            WriteLog("Guardar_QR_DB", "Error: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Genera log individual por operación
    ''' </summary>
    Private Sub WriteLog(operacion As String, mensaje As String)
        Try
            Dim dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")
            If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)
            Dim nombre = $"afip_{operacion}_{DateTime.Now:yyyyMMdd_HHmmss}.log"
            Dim ruta = Path.Combine(dir, nombre)
            Using sw As New StreamWriter(ruta, True)
                sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {mensaje}")
            End Using
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Placeholder de impresión
    ''' </summary>
    Public Sub imprimirFactura(ByVal id_pedido As Integer, ByVal esPresupuesto As Boolean, ByVal imprimeRemito As Boolean)
        If showrpt Then
            id = id_pedido
            Dim frm As New frm_prnCmp(esPresupuesto, imprimeRemito)
            frm.ShowDialog()
            id = 0
        End If
    End Sub


    ''' <summary>
    ''' Consulta un comprobante específico ya emitido
    ''' Determina automáticamente el modo (Test/Prod) basándose en el número de comprobante
    ''' </summary>
    Public Sub Consultar_Comprobante(ByVal pVenta As Integer, ByVal tipo_comprobante As Integer, ByVal nComprobante As String, ByVal esTest As Boolean)
        Try
            ' Inicializar configuración
            Dim config = InicialesFE(esTest)
            If config Is Nothing Then
                MsgBox("Hubo un problema al inicializar la configuración AFIP, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
                Exit Sub
            End If

            WriteLog("Consultar_Comprobante", $"Consultando comprobante: PV={pVenta}, Tipo={tipo_comprobante}, Nro={nComprobante}, Modo={config.Modo}")

            ' Crear instancia WSFEv1 usando la configuración
            Dim wsfe = WSFEv1.CreateWithTa(config.AfipMode)

            ' Consultar el comprobante
            Dim resultado = wsfe.FECompConsultar(pVenta, tipo_comprobante, CLng(nComprobante))

            If resultado Is Nothing Then
                WriteLog("Consultar_Comprobante", "No se obtuvo respuesta de AFIP")
                MsgBox("No se obtuvo respuesta de AFIP al consultar el comprobante", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            End If

            ' Extraer datos del resultado
            Dim cae As String = resultado.CodAutorizacion
            Dim baseImponible As Decimal = 0
            Dim importeIva As Decimal = 0
            Dim importeTotal As Decimal = resultado.ImpTotal
            Dim docNro As Long = resultado.DocNro

            ' Obtener datos de IVA si existen
            If resultado.Iva IsNot Nothing AndAlso resultado.Iva.Length > 0 Then
                baseImponible = resultado.Iva(0).BaseImp
                importeIva = resultado.Iva(0).Importe
            End If

            WriteLog("Consultar_Comprobante", $"Consulta exitosa. CAE: {cae}, Total: {importeTotal}")

            ' Mostrar resultado en formulario
            Dim resultadofc As New resultado_info_fc(cae, baseImponible, importeIva, importeTotal, docNro)
            resultadofc.ShowDialog()

        Catch ex As Exception
            WriteLog("Consultar_Comprobante", "Error: " & ex.Message)
            MsgBox("Error al consultar el comprobante: " & ex.Message, vbCritical + vbOKOnly, "Centrex")
        End Try
    End Sub
End Module
