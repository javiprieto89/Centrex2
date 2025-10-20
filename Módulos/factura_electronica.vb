Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text
Imports Centrex.Afip
Imports ZXing
Imports ZXing.QrCode
Imports Centrex.Pedidos

Module factura
    Private modo As String
    Private archivo_certificado As String
    Private archivo_licencia As String
    Private password_certificado As String
    Private cuit_emisor As String

    ''' <summary>
    ''' Función principal de facturación - MANTIENE LA FIRMA ORIGINAL
    ''' Devuelve 1 si está OK, 0 si hay error
    ''' </summary>
    Public Function facturar(ByVal p As pedido) As Integer
        'SI DEVUELVE 1 ESTÁ TODO OK
        'SI DEVUELVE 0 HUBO UN ERROR

        Try
            Dim cl As New cliente
            Dim c As New comprobante
            Dim pAnulado As pedido
            Dim cAnulado As comprobante
            Dim _fechaAFIP As String

            'Obtengo los datos del comprobante
            c = info_comprobante(p.id_comprobante)

            ' ============================================
            ' COMPROBANTES MANUALES Y PRESUPUESTOS
            ' ============================================
            If c.esPresupuesto Or c.esManual Then
                c.numeroComprobante += 1
                updatecomprobante(c)
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
                Return 1
            End If

            ' ============================================
            ' FACTURACIÓN ELECTRÓNICA
            ' ============================================

            'Obtengo los datos del cliente
            cl = info_cliente(p.id_cliente)
            _fechaAFIP = fechaAFIP() 'Fecha de hoy

            ' Inicializar configuración AFIP
            If Not inicialesFE(c.testing) Then
                MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
                Return 0
            End If

            ' Crear conexión con WSFE usando la nueva infraestructura
            Dim afipMode As AfipMode = If(c.testing, AfipMode.HOMO, AfipMode.PROD)
            Dim wsfe As WSFEv1 = Nothing

            Try
                wsfe = WSFEv1.CreateWithTa(afipMode)
            Catch ex As Exception
                MsgBox("Error al conectar con AFIP: " & ex.Message & vbCr & vbCr & "PROBLEMA DE AFIP", vbCritical + vbOKOnly, "Centrex")
                Return 0
            End Try

            ' Obtener último número de comprobante
            Dim ultimoNro As Integer
            Try
                ultimoNro = wsfe.FECompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante)
            Catch ex As Exception
                MsgBox("Error al consultar último comprobante: " & ex.Message, vbCritical + vbOKOnly, "Centrex")
                Return 0
            End Try

            Dim nuevoNro As Integer = ultimoNro + 1

            ' ============================================
            ' ARMAR REQUEST SEGÚN TIPO DE COMPROBANTE
            ' ============================================

            Dim req As New Centrex.Afip.Proxy.FECAERequest()

            ' Cabecera
            req.FeCabReq = New Centrex.Afip.Proxy.FECabReq() With {
                .CantReg = 1,
                .CbteTipo = c.id_tipoComprobante,
                .PtoVta = c.puntoVenta
            }

            ' Detalle básico
            Dim det = New Centrex.Afip.Proxy.FEDetReq() With {
                .Concepto = 1,
                .DocTipo = cl.id_tipoDocumento,
                .DocNro = CLng(If(String.IsNullOrEmpty(cl.taxNumber), 0, cl.taxNumber.Replace("-", ""))),
                .CbteDesde = nuevoNro,
                .CbteHasta = nuevoNro,
                .CbteFch = _fechaAFIP,
                .ImpTotal = Math.Round(p.total, 2),
                .ImpTotConc = 0,
                .ImpNeto = Math.Round(p.subTotal, 2),
                .ImpOpEx = 0,
                .ImpIVA = Math.Round(p.iva, 2),
                .ImpTrib = 0,
                .MonId = "PES",
                .MonCotiz = 1
            }

            ' IVA
            Dim ivaId As Integer = If(p.subTotal = p.total And p.iva = 0, 3, 5) ' 3=0%, 5=21%
            det.Iva = New Centrex.Afip.Proxy.FEIva() {
                New Centrex.Afip.Proxy.FEIva() With {
                    .Id = ivaId,
                    .BaseImp = Math.Round(p.subTotal, 2),
                    .Importe = Math.Round(p.iva, 2)
                }
            }

            ' ============================================
            ' COMPROBANTES MIPYME
            ' ============================================
            If c.esMiPyME Then
                det.FchVtoPago = _fechaAFIP

                Dim opcionales As New List(Of Centrex.Afip.Proxy.FEOpcional)()

                ' CBU (campo 2101)
                If Not String.IsNullOrEmpty(c.CBU_emisor) Then
                    opcionales.Add(New Centrex.Afip.Proxy.FEOpcional() With {
                        .Id = 2101,
                        .Valor = c.CBU_emisor
                    })
                End If

                ' Alias CBU (campo 2102)
                If Not String.IsNullOrEmpty(c.alias_CBU_emisor) Then
                    opcionales.Add(New Centrex.Afip.Proxy.FEOpcional() With {
                        .Id = 2102,
                        .Valor = c.alias_CBU_emisor
                    })
                End If

                ' Modo MiPyME (campo 27)
                If c.id_modoMiPyme > 0 Then
                    Dim modoMiPyme = info_modoMiPyme(c.id_modoMiPyme)
                    If modoMiPyme IsNot Nothing Then
                        opcionales.Add(New Centrex.Afip.Proxy.FEOpcional() With {
                            .Id = 27,
                            .Valor = modoMiPyme.abreviatura
                        })
                    End If
                End If

                ' Campo 22 - Anula MiPyME (solo para NC)
                If (UCase(c.anula_MiPyME) = "S" Or UCase(c.anula_MiPyME) = "N") Then
                    opcionales.Add(New Centrex.Afip.Proxy.FEOpcional() With {
                        .Id = 22,
                        .Valor = UCase(c.anula_MiPyME)
                    })
                End If

                det.Opcionales = opcionales.ToArray()

                ' Documentos asociados para NC/ND MiPyME
                If EsNotaCreditoODebito(c.id_tipoComprobante) AndAlso p.numeroPedido_anulado > 0 Then
                    pAnulado = InfoPedido(p.numeroPedido_anulado)
                    If pAnulado IsNot Nothing Then
                        cAnulado = info_comprobante(pAnulado.id_comprobante)
                        If cAnulado IsNot Nothing Then
                            det.CbtesAsoc = New Centrex.Afip.Proxy.FECbtesAsoc() {
                                New Centrex.Afip.Proxy.FECbtesAsoc() With {
                                    .Tipo = cAnulado.id_tipoComprobante,
                                    .PtoVta = pAnulado.puntoVenta,
                                    .Nro = p.numeroComprobante_anulado,
                                    .Cuit = cuit_emisor_default,
                                    .CbteFch = _fechaAFIP
                                }
                            }
                        End If
                    End If
                End If

            Else
                ' ============================================
                ' FACTURAS NORMALES - DOCUMENTOS ASOCIADOS PARA NC/ND
                ' ============================================
                If EsNotaCreditoODebito(c.id_tipoComprobante) AndAlso p.numeroPedido_anulado > 0 Then
                    pAnulado = InfoPedido(p.numeroPedido_anulado)
                    If pAnulado IsNot Nothing Then
                        cAnulado = info_comprobante(pAnulado.id_comprobante)
                        If cAnulado IsNot Nothing Then
                            det.CbtesAsoc = New Centrex.Afip.Proxy.FECbtesAsoc() {
                                New Centrex.Afip.Proxy.FECbtesAsoc() With {
                                    .Tipo = cAnulado.id_tipoComprobante,
                                    .PtoVta = pAnulado.puntoVenta,
                                    .Nro = p.numeroComprobante_anulado,
                                    .Cuit = cuit_emisor_default,
                                    .CbteFch = _fechaAFIP
                                }
                            }
                        End If
                    End If
                End If
            End If

            req.FeDetReq = New Centrex.Afip.Proxy.FEDetReq() {det}

            ' ============================================
            ' ENVIAR A AFIP
            ' ============================================
            Dim resp As Object
            Try
                resp = wsfe.FECAESolicitar(req)
            Catch ex As Exception
                MsgBox("Error al enviar a AFIP: " & ex.Message, vbCritical + vbOKOnly, "Centrex")
                Return 0
            End Try

            ' ============================================
            ' PROCESAR RESPUESTA
            ' ============================================
            If resp Is Nothing Then
                MsgBox("No se recibió respuesta de AFIP", vbCritical + vbOKOnly, "Centrex")
                Return 0
            End If

            ' Verificar errores generales
            If resp.Errors IsNot Nothing AndAlso resp.Errors.Length > 0 Then
                Dim errMsg As String = FormatearErroresAFIP(resp)
                MsgBox(errorFE_new(wsfe, c, ultimoNro) & vbCr & vbCr & errMsg, vbCritical + vbOKOnly, "Centrex")
                Return 0
            End If

            ' Verificar detalle
            If resp.FeDetResp Is Nothing OrElse resp.FeDetResp.Length = 0 Then
                MsgBox("La respuesta no contiene información del comprobante", vbCritical + vbOKOnly, "Centrex")
                Return 0
            End If

            Dim detResp = resp.FeDetResp(0)

            ' Verificar resultado
            If detResp.Resultado <> "A" Then
                Dim errMsg As String = FormatearErroresAFIP(resp)
                MsgBox(errorFE_new(wsfe, c, ultimoNro) & vbCr & vbCr & errMsg, vbExclamation + vbOKOnly, "Centrex")
                Return 0
            End If

            ' ============================================
            ' ÉXITO - ACTUALIZAR BASE DE DATOS
            ' ============================================

            ' Actualizar comprobante
            c.numeroComprobante = nuevoNro
            updatecomprobante(c)

            ' Actualizar pedido
            p.cae = detResp.CAE
            p.fechaVencimiento_cae = fechaAFIP_fecha(detResp.CAEFchVto)
            p.cerrado = True
            p.activo = False
            p.puntoVenta = c.puntoVenta
            p.numeroComprobante = nuevoNro

            ' Generar código de barras
            p.codigoDeBarras = generarCodigoDeBarras(cuit_emisor_default, p.numeroComprobante, p.puntoVenta, p.cae, detResp.CAEFchVto)

            ' Generar y guardar QR
            Try
                Dim nombreQR As String = Application.StartupPath & "\QR\" & cl.taxNumber & "_" & nuevoNro.ToString & "_" & p.id_pedido.ToString & "_" & _fechaAFIP & ".jpg"
                If GenerarYGuardarQR_AFIP(c, p, cl, nombreQR, afipMode) Then
                    Guardar_QR_DB(nombreQR, p.id_pedido)
                End If
            Catch ex As Exception
                ' QR no crítico - continuar
                Console.WriteLine("Error al generar QR: " & ex.Message)
            End Try

            ' Guardar pedido
            UpdatePedido(p)

            Return 1

        Catch ex As Exception
            MsgBox("Error crítico: " & ex.Message & vbCr & vbCr & ex.StackTrace, vbCritical + vbOKOnly, "Centrex")
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Inicializa configuración AFIP - MANTIENE LA FIRMA ORIGINAL
    ''' </summary>
    Private Function inicialesFE(ByVal esTest As Boolean) As Boolean
        Try
            If esTest Then
                modo = "HOMO"
                Select Case pc
                    Case Is = "JARVIS"
                        archivo_certificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                    Case Is = "SERVTEC-06"
                        archivo_certificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                    Case Is = "BRUNO"
                        archivo_certificado = Application.StartupPath + "\Certificados\bruno2023_prueba.pfx"
                    Case Is = "SILVIA"
                        archivo_certificado = Application.StartupPath + "\Certificados\SILVIA.pfx"
                    Case Else
                        MsgBox("PC no habilitada para emitir documentos de testing.", vbCritical + vbOKOnly, "Centrex")
                        Return False
                End Select
            Else
                modo = "PROD"
                Select Case pc
                    Case Is = "JARVIS"
                        archivo_certificado = Application.StartupPath + "\Certificados\BRUNO.pfx"
                    Case Is = "SERVTEC-06"
                        archivo_certificado = Application.StartupPath + "\Certificados\JARVIS.pfx"
                    Case Is = "BRUNO"
                        archivo_certificado = Application.StartupPath + "\Certificados\Bruno.pfx"
                    Case Is = "SILVIA"
                        archivo_certificado = Application.StartupPath + "\Certificados\SILVIA.pfx"
                    Case Else
                        MsgBox("PC no habilitada para emitir documentos fiscales.", vbCritical + vbOKOnly, "Centrex")
                        Return False
                End Select
            End If

            If Not File.Exists(archivo_certificado) Then
                MsgBox("No existe el archivo del certificado, no podrá continuar.", vbCritical + vbOKOnly, "Centrex")
                Return False
            End If

            cuit_emisor = cuit_emisor_default
            password_certificado = "Ladeda78"

            ' Configurar AfipConfig con las propiedades dinámicas
            Dim afipMode As AfipMode = If(esTest, AfipMode.HOMO, AfipMode.PROD)
            AfipConfig.DynamicCertPath = archivo_certificado
            AfipConfig.DynamicCertPassword = password_certificado
            AfipConfig.DynamicCuitEmisor = CLng(cuit_emisor)
            AfipConfig.Mode = afipMode

            ' Validar configuración
            Dim validation = AfipConfig.ValidateConfig(afipMode)
            If Not validation.isValid Then
                MsgBox("Error en la configuración: " & validation.errorMessage, vbCritical + vbOKOnly, "Centrex")
                Return False
            End If

            Return True

        Catch ex As Exception
            MsgBox("Error al inicializar: " & ex.Message, vbCritical + vbOKOnly, "Centrex")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Genera código de barras según especificaciones AFIP - MANTIENE LA FIRMA ORIGINAL
    ''' </summary>
    Private Function generarCodigoDeBarras(cuit As String, nroComprobante As Long, ptoVenta As Integer, cae As String, vtoCAE As String) As String
        Try
            Dim cuitStr As String = cuit.Replace("-", "").PadLeft(11, "0"c)
            Dim tipoComp As String = "006" ' Ajustar según tipo
            Dim ptoVtaStr As String = ptoVenta.ToString().PadLeft(5, "0"c)
            Dim caeStr As String = cae.PadLeft(14, "0"c)
            Dim vtoStr As String = vtoCAE.Replace("/", "").PadLeft(8, "0"c)

            Return cuitStr & tipoComp & ptoVtaStr & caeStr & vtoStr
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Genera y guarda el código QR según especificaciones AFIP
    ''' </summary>
    Private Function GenerarYGuardarQR_AFIP(c As comprobante, p As pedido, cl As cliente, rutaArchivo As String, modo As AfipMode) As Boolean
        Try
            ' Crear carpeta si no existe
            Dim carpetaQR As String = Path.GetDirectoryName(rutaArchivo)
            If Not Directory.Exists(carpetaQR) Then
                Directory.CreateDirectory(carpetaQR)
            End If

            ' Construir JSON para el QR según especificaciones AFIP
            Dim datosQR As New StringBuilder()
            datosQR.Append("{")
            datosQR.AppendFormat("""ver"":1,")
            datosQR.AppendFormat("""fecha"":""{0}"",", DateTime.Now.ToString("yyyy-MM-dd"))
            datosQR.AppendFormat("""cuit"":{0},", AfipConfig.GetCuitEmisor())
            datosQR.AppendFormat("""ptoVta"":{0},", p.puntoVenta)
            datosQR.AppendFormat("""tipoCmp"":{0},", c.id_tipoComprobante)
            datosQR.AppendFormat("""nroCmp"":{0},", p.numeroComprobante)
            datosQR.AppendFormat("""importe"":{0},", p.total.ToString("0.00").Replace(",", "."))
            datosQR.AppendFormat("""moneda"":""{0}"",", "PES")
            datosQR.AppendFormat("""ctz"":1,")
            datosQR.AppendFormat("""tipoDocRec"":{0},", cl.id_tipoDocumento)
            datosQR.AppendFormat("""nroDocRec"":{0},", CLng(If(String.IsNullOrEmpty(cl.taxNumber), 0, cl.taxNumber.Replace("-", ""))))
            datosQR.AppendFormat("""tipoCodAut"":""{0}"",", "E")
            datosQR.AppendFormat("""codAut"":{0}", CLng(p.cae))
            datosQR.Append("}")

            ' Codificar en Base64
            Dim datosQRBase64 As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(datosQR.ToString()))

            ' Construir URL
            Dim urlQR As String = "https://www.afip.gob.ar/fe/qr/?p=" & datosQRBase64

            ' Generar imagen QR usando ZXing
            Dim writer As New BarcodeWriter() With {
                .Format = BarcodeFormat.QR_CODE,
                .Options = New ZXing.QrCode.QrCodeEncodingOptions() With {
                    .Height = 300,
                    .Width = 300,
                    .Margin = 1,
                    .ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M
                }
            }

            Dim bitmapQR As Bitmap = writer.Write(urlQR)
            bitmapQR.Save(rutaArchivo, ImageFormat.Jpeg)

            Return True

        Catch ex As Exception
            Console.WriteLine("Error al generar QR: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Guarda imagen QR en la base de datos - MANTIENE LA FIRMA ORIGINAL
    ''' </summary>
    Public Function Guardar_QR_DB(ByVal archivo_imagen As String, ByVal id_pedido As Integer) As Integer
        Dim con As SqlClient.SqlConnection = Nothing
        Try
            If Not File.Exists(archivo_imagen) Then
                Return 0
            End If

            Dim img As Image = Image.FromFile(archivo_imagen)
            Dim ms As New MemoryStream()
            img.Save(ms, ImageFormat.Jpeg)
            Dim md As Byte() = ms.GetBuffer()

            con = New SqlClient.SqlConnection("Server=" + serversql + ";Database=" + basedb + ";Uid=" + usuariodb + ";Password=" + passdb)
            con.Open()

            Dim sqlstr As String = "UPDATE pedidos SET fc_qr = @qr WHERE id_pedido = '" + id_pedido.ToString + "'"
            Dim cmd As New SqlClient.SqlCommand(sqlstr, con)
            Dim param As New SqlClient.SqlParameter("@qr", SqlDbType.Image) With {.Value = md}

            cmd.Parameters.Add(param)
            cmd.ExecuteNonQuery()

            Return 0

        Catch ex As Exception
            Console.WriteLine("Error al guardar QR en DB: " & ex.Message)
            Return -1
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' Formatea errores de AFIP - NUEVA FUNCIÓN
    ''' </summary>
    Private Function FormatearErroresAFIP(resp As Object) As String
        Try
            Dim sb As New StringBuilder()

            If resp.Errors IsNot Nothing AndAlso resp.Errors.Length > 0 Then
                sb.AppendLine("Errores:")
                For Each Errx In resp.Errors
                    sb.AppendLine($"  [{Errx.Code}] {Errx.Msg}")
                Next
            End If

            If resp.FeDetResp IsNot Nothing AndAlso resp.FeDetResp.Length > 0 Then
                Dim detResp = resp.FeDetResp(0)
                If detResp.Observaciones IsNot Nothing AndAlso detResp.Observaciones.Length > 0 Then
                    If sb.Length > 0 Then sb.AppendLine()
                    sb.AppendLine("Observaciones:")
                    For Each obs In detResp.Observaciones
                        sb.AppendLine($"  [{obs.Code}] {obs.Msg}")
                    Next
                End If
            End If

            Return If(sb.Length = 0, "Error desconocido", sb.ToString())
        Catch
            Return "Error al procesar mensaje"
        End Try
    End Function

    ''' <summary>
    ''' Mensaje de error compatible con el formato original - NUEVA FUNCIÓN
    ''' </summary>
    Private Function errorFE_new(wsfe As WSFEv1, c As comprobante, ultimoNro As Integer) As String
        Dim errorStr As String = ""
        errorStr = "El número del último comprobante autorizado para: " + c.comprobante + " es: " + ultimoNro.ToString
        Return errorStr
    End Function

    ''' <summary>
    ''' Verifica si un tipo de comprobante es NC o ND - NUEVA FUNCIÓN
    ''' </summary>
    Private Function EsNotaCreditoODebito(tipoComprobante As Integer) As Boolean
        Dim notasCredito() As Integer = {2, 3, 7, 8, 12, 13, 52, 53, 202, 203, 207, 208, 212, 213}
        Dim notasDebito() As Integer = {4, 5, 9, 10, 14, 15, 54, 55, 204, 205, 209, 210, 214, 215}
        Return notasCredito.Contains(tipoComprobante) OrElse notasDebito.Contains(tipoComprobante)
    End Function

    ''' <summary>
    ''' Consulta un comprobante en AFIP - MANTIENE LA FIRMA ORIGINAL
    ''' </summary>
    Public Sub Consultar_Comprobante(ByVal pVenta As Integer, ByVal tipo_comprobante As Integer, ByVal nComprobante As String)
        Try
            If Not inicialesFE(False) Then
                MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
                Exit Sub
            End If

            Dim wsfe = WSFEv1.CreateWithTa(AfipMode.PROD)
            Dim resultado = wsfe.FECompConsultar(pVenta, tipo_comprobante, CLng(nComprobante))

            If resultado Is Nothing Then
                MsgBox("No se encontró el comprobante", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            End If

            ' Mostrar resultado (adaptar según tu formulario resultado_info_fc)
            Dim resultadofc As New resultado_info_fc(
                resultado.CAE,
                resultado.ImpNeto,
                resultado.ImpIVA,
                resultado.ImpTotal,
                resultado.DocNro
            )
            resultadofc.ShowDialog()

        Catch ex As Exception
            MsgBox("Error al consultar comprobante: " & ex.Message, vbCritical + vbOKOnly, "Centrex")
        End Try
    End Sub
    'Fallo iniciar


    Public Sub imprimirFactura(ByVal id_pedido As Integer, ByVal esPresupuesto As Boolean, ByVal imprimeRemito As Boolean)
        If showrpt Then
            id = id_pedido
            'If Not esPresupuesto Then
            'frm_rptFC.ShowDialog()
            'Else
            'frm_rptPresupuesto.ShowDialog()
            'End If
            'JAVI
            Dim frm As New frm_prnCmp(esPresupuesto, imprimeRemito)
            frm.ShowDialog()
            'frm_reportes.ShowDialog()
            id = 0
        End If
    End Sub

    Public Function consultaUltimoComprobante(ByVal puntoVenta As String, ByVal tipoComprobante As String, ByVal esTest As Boolean) As Integer
        'Dim ultimoCmp As Integer

        'If Not inicialesFE(esTest) Then
        '    Return -1
        'End If

        'If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
        '    If Not esTest Then fe.ArchivoCertificadoPassword = password_certificado
        '    If Not Resultado_Ticket_acceso(fe) Then
        '        MsgBox("Error al obtener el ticket de acceso, PROBLEMA DE AFIP", vbCritical + vbOKOnly, "Centrex")
        '        Return -1
        '        Exit Function
        '    End If

        '    ultimoCmp = fe.F1CompUltimoAutorizado(puntoVenta, tipoComprobante)
        '    Return ultimoCmp
        'Else
        '    'Fallo iniciar
        '    Return -1
        'End If
        Return 1
    End Function
End Module
