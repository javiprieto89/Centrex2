Module factura
    Private modo As String
    Private archivo_certificado As String
    Private archivo_licencia As String
    Private password_certificado As String
    Private cuit_emisor As String

    Public Function facturar(ByVal p As pedido) As Integer
        'SI DEVUELVE 1 ESTÁ TODO OK
        'SI DEVUELVE 0 HUBO UN ERROR

        '************** FACTURA ELECTRONICA ************** 
        Dim lResultado As Boolean = False
        Dim cl As New cliente
        Dim c As New comprobante
        Dim pAnulado As pedido
        Dim cAnulado As comprobante
        ' Eliminado uso de WSAFIPFE
        Dim _fechaAFIP As String


        'Obtengo los datos del comprobante
        c = info_comprobante(p.id_comprobante)
        'p.iva = 0
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
            updatepedido(p)
            Return 1
        End If

        'Obtengo los datos del cliente
        cl = info_cliente(p.id_cliente)
        _fechaAFIP = fechaAFIP() 'Fecha de hoy

        If Not inicialesFE(c.testing) Then
            MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
            Return 0
            Exit Function
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            If Not Resultado_Ticket_acceso(fe) Then
                MsgBox(errorFE(fe, c) & vbCr & vbCr & "Error al obtener el ticket de acceso, PROBLEMA DE AFIP")
                Return 0
                Exit Function
            Else
                fe.F1CabeceraCantReg = 1
                fe.F1CabeceraPtoVta = c.puntoVenta
                fe.F1CabeceraCbteTipo = c.id_tipoComprobante  'FACTURA A/B/NC/MiPyme

                fe.f1Indice = 0
                fe.F1DetalleConcepto = 1
                fe.F1DetalleDocTipo = cl.id_tipoDocumento     'CUIT/CUIL/DNI
                fe.F1DetalleDocNro = cl.taxNumber    'CUIT
                fe.F1DetalleCbteDesde = c.numeroComprobante + 1
                fe.F1DetalleCbteHasta = c.numeroComprobante + 1
                fe.F1DetalleCbteFch = _fechaAFIP
                fe.F1DetalleImpTotal = p.total
                fe.F1DetalleImpTotalConc = 0
                fe.F1DetalleImpNeto = p.subTotal
                fe.F1DetalleImpOpEx = 0
                fe.F1DetalleImpIva = p.iva
                fe.F1DetalleMonId = "PES"
                fe.F1DetalleMonCotiz = 1

                fe.f1IndiceItem = 0
                fe.F1DetalleIvaItemCantidad = 1
                fe.F1DetalleIvaId = 5
                fe.F1DetalleIvaBaseImp = p.total
                fe.F1DetalleIvaImporte = p.iva


                If c.esMiPyME Then
                    fe.F1DetalleFchVtoPago = _fechaAFIP
                    fe.F1DetalleOpcionalItemCantidad = 1

                    'Si se usa 2101 en F1DetalleOpcionalId se debe informar CBU del emisor donde al momento de pagar la factura se abonará el saldo en esa CBU
                    'Actualmente se usa ese método, se deja la otra opción grisada
                    'fe.f1IndiceItem = 0
                    'fe.F1DetalleOpcionalId = "2101"
                    'fe.F1DetalleOpcionalValor = c.CBU_emisor
                    'Si desea informar el alias en vez del CBU del emisor, debe grisar las lineas anteriores y usar estas
                    fe.f1IndiceItem = 0
                    fe.F1DetalleOpcionalId = "2102"
                    fe.F1DetalleOpcionalValor = c.alias_CBU_emisor

                    fe.f1IndiceItem = 1
                    fe.F1DetalleOpcionalId = 27
                    fe.F1DetalleOpcionalValor = info_modoMiPyme(c.id_modoMiPyme).abreviatura

                    'Si es una nota de crédito y es un comprobante que ya fue anulado por el cliente se debe mandar una S, si todavía no fue anulado por el cliente, una N
                    If UCase(c.anula_MiPyME) = "S" Or UCase(c.anula_MiPyME) = "N" Then
                        fe.F1DetalleOpcionalItemCantidad = 1
                        fe.f1IndiceItem = 0
                        fe.F1DetalleOpcionalId = 22
                        fe.F1DetalleOpcionalValor = UCase(c.anula_MiPyME)
                    End If



                    Select Case c.id_tipoComprobante
                        Case Is = 2, 3, 7, 8, 12, 13, 52, 53, 202, 203, 207, 208, 212, 213
                            pAnulado = info_pedido(p.numeroPedido_anulado)
                            cAnulado = info_comprobante(pAnulado.id_comprobante)
                            fe.F1DetalleCbtesAsocItemCantidad = 1
                            fe.f1IndiceItem = 0
                            fe.F1DetalleCbtesAsocFecha = fechaAFIP()
                            fe.F1DetalleCbtesAsocTipo = cAnulado.id_tipoComprobante
                            fe.F1DetalleCbtesAsocPtoVta = pAnulado.puntoVenta
                            'fe.F1DetalleCbtesAsocNro = p.numeroComprobante_anulado
                            fe.F1DetalleCbtesAsocNro = p.numeroComprobante_anulado
                            fe.F1DetalleCbtesAsocCUIT = cuit_emisor_default
                    End Select

                    'Select Case c.id_tipoComprobante
                    '    Case Is = 1, 2, 3, 4, 5, 63, 34, 39, 60, 51, 52, 53, 54
                    fe.F1DetalleIvaId = 5 'IVA 21/ IVA 10.5
                    '    Case Else
                    '        fe.F1DetalleIvaId = 3 'IVA 0
                    'End Select

                    'Ajusta el tipo de IVA del documento si no tiene IVA
                    If p.subTotal = p.total And p.iva = 0 Then fe.F1DetalleIvaId = 3

                    fe.F1DetalleIvaBaseImp = p.subTotal
                    fe.F1DetalleIvaImporte = p.iva

                    fe.ArchivoXMLRecibido = "c:\recibido.xml"
                    fe.ArchivoXMLEnviado = "c:\enviado.xml"

                    lResultado = fe.F1CAESolicitar()

                Else
                    fe.f1IndiceItem = 0
                    fe.F1DetalleIvaItemCantidad = 1

                    Select Case c.id_tipoComprobante
                        Case Is = 2, 3, 7, 8, 12, 13, 52, 53, 202, 203, 207, 208, 212, 213
                            pAnulado = info_pedido(p.numeroPedido_anulado)
                            cAnulado = info_comprobante(pAnulado.id_comprobante)
                            fe.F1DetalleCbtesAsocItemCantidad = 1
                            fe.f1IndiceItem = 0
                            fe.F1DetalleCbtesAsocFecha = fechaAFIP()
                            fe.F1DetalleCbtesAsocTipo = cAnulado.id_tipoComprobante
                            fe.F1DetalleCbtesAsocPtoVta = pAnulado.puntoVenta
                            'fe.F1DetalleCbtesAsocNro = p.numeroComprobante_anulado
                            fe.F1DetalleCbtesAsocNro = p.numeroComprobante_anulado
                            fe.F1DetalleCbtesAsocCUIT = cuit_emisor_default
                    End Select

                    'Select Case c.id_tipoComprobante
                    '    Case Is = 1, 2, 3, 4, 5, 63, 34, 39, 60, 51, 52, 53, 54
                    fe.F1DetalleIvaId = 5 'IVA 21/ IVA 10.5
                    '    Case Else
                    '        fe.F1DetalleIvaId = 3 'IVA 0
                    'End Select

                    'Ajusta el tipo de IVA del documento si no tiene IVA
                    If p.subTotal = p.total And p.iva = 0 Then fe.F1DetalleIvaId = 3

                    fe.F1DetalleIvaBaseImp = p.subTotal
                    fe.F1DetalleIvaImporte = p.iva

                    fe.ArchivoXMLRecibido = "c:\recibido.xml"
                    fe.ArchivoXMLEnviado = "c:\enviado.xml"

                    lResultado = fe.F1CAESolicitar()
                End If


                If lResultado And fe.F1RespuestaDetalleCae <> "" Then
                    'If fe.f1ErrorItemCantidad = 0 Then
                    'Si obtuvo el CAE
                    'Actualizo la DB y al pedido le pongo el CAE y la fecha de vencimiento 
                    'Dim ce As New comprobante
                    'ce = info_comprobante(p.id_comprobante)
                    c.numeroComprobante = c.numeroComprobante + 1
                    updatecomprobante(c)
                    p.cae = fe.F1RespuestaDetalleCae
                    p.fechaVencimiento_cae = fechaAFIP_fecha(fe.F1RespuestaDetalleCAEFchVto)
                    p.cerrado = True
                    p.activo = False
                    p.puntoVenta = c.puntoVenta
                    p.numeroComprobante = c.numeroComprobante
                    p.codigoDeBarras = generarCodigoDeBarras(cuit_emisor_default, p.numeroComprobante, p.puntoVenta, p.cae, fe.F1RespuestaDetalleCAEFchVto)
                    fe.F1DetalleQRArchivo = Application.StartupPath + "\QR\" + fe.F1RespuestaDetalleCae + ".jpg"
                    fe.f1detalleqrformato = 6
                    fe.f1detalleqrresolucion = 5
                    fe.f1detalleqrtolerancia = 1
                    fe.f1detalleqrformato = 6
                    If fe.f1qrGenerar(99) Then
                        Guardar_QR_DB(Application.StartupPath + "\QR\" + fe.F1RespuestaDetalleCae + ".jpg", p.id_pedido)
                    End If
                    updatepedido(p)
                    Return 1
                Else
                    'HUBO ERRORES
                    If fe.f1ErrorItemCantidad > 0 Then
                        Dim count As Integer
                        Dim errores As String = ""
                        For count = 0 To fe.f1ErrorItemCantidad - 1
                            fe.f1IndiceItem = count
                            errores = fe.f1ErrorCode & vbCrLf & fe.f1ErrorMsg
                            MsgBox(errores)
                        Next
                    End If

                    'If lResultado Then
                    '    MsgBox("resultado método: verdadero")
                    'Else
                    '    MsgBox("resultado método: falso")
                    'End If
                    'MsgBox("JAVIER - error local: " + fe.UltimoMensajeError)
                    'MsgBox("resultado global AFIP: " + fe.F1RespuestaResultado)
                    'MsgBox("es reproceso? " + fe.F1RespuestaReProceso)
                    'MsgBox("registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg))
                    'MsgBox("error genérico global:" + fe.f1ErrorMsg1)
                    'If Not c.testing Then
                    '    'MsgBox(fe.F1RespuestaDetalleObservacionCode1)
                    '    'MsgBox(fe.F1RespuestaDetalleObservacionMsg1)
                    '    MsgBox(errorFE(fe, c))
                    '    Return 0 'Si no está en modo testing devuelve error
                    'End If
                    MsgBox(errorFE(fe, c))
                    Return 0
                End If

                'MsgBox(errorFE(fe, c))
                'If fe.F1RespuestaCantidadReg > 0 Then
                '    fe.f1Indice = 0
                '    MsgBox(errorFE(fe, c))
                '    If fe.F1RespuestaDetalleCae = "" Then Return 0 Else Return 1
                'End If
                'Return 0
            End If
        Else
            MsgBox(fe.UltimoMensajeError)
            Return 0
        End If
        '************** FACTURA ELECTRONICA ************** 
    End Function

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

    Public Function generarCodigoDeBarras(ByVal cuit_emisor As String, ByVal numeroComprobante As String, ByVal puntoVenta As String, ByVal cae As String, ByVal _
                                            fechaVencimiento_cae As String) As String
        Dim I As Long
        Dim Cod As String
        Dim Impares As Long = 0
        Dim Pares As Long = 0
        Dim Impares3 As Long
        Dim Total As Long
        Dim digitoVerificador As Integer
        Dim codigoDeBarras As String


        Cod = cuit_emisor & numeroComprobante.ToString & puntoVenta.ToString & cae & fechaVencimiento_cae

        'Ahora analizo la cadena de caracteres:
        'Tengo que sumar todos los caracteres impares y los pares
        'Pares = 0 : Impares = 0

        For I = 1 To Cod.Length
            If I Mod 2 = 0 Then
                ' Si el valor de I es par entra por aca
                Pares = Pares + CLng(Mid(Cod, I, 1))
            Else
                'Si el valor de I es impar entra por aca
                Impares = Impares + CLng(Mid(Cod, I, 1))
            End If
        Next I

        'Me.TxtImpares.Text = Impares
        'Me.TxtPares.Text = Pares
        'Me.Txt3Impares.Text = 3 * CLng(Me.TxtImpares.Text)
        Impares3 = 3 * CLng(Impares)
        'Me.TxtTotal.Text = CLng(Me.TxtPares.Text) + CLng(Me.Txt3Impares.Text)
        Total = CLng(Pares) + CLng(Impares3)

        'Me.TxtDigito.Text = 10 - (CLng(Me.TxtTotal.Text) Mod 10)
        digitoVerificador = 10 - (CLng(Total) Mod 10)

        'Me.TxtCodBarraF.Text = Cod & Me.TxtDigito.Text
        codigoDeBarras = Cod & digitoVerificador
        Return codigoDeBarras
    End Function
    Public Function consultaUltimoComprobante(ByVal puntoVenta As String, ByVal tipoComprobante As String, ByVal esTest As Boolean) As Integer
        ' Eliminado uso de WSAFIPFE
        Dim resultadoTicket As Boolean
        Dim ultimoCmp As Integer

        If Not inicialesFE(esTest) Then
            Return -1
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            fe.ArchivoCertificadoPassword = password_certificado
            If Not fe.f1TicketEsValido Then
                resultadoTicket = fe.f1ObtenerTicketAcceso()
                If Not resultadoTicket Then
                    Return -1
                End If
            Else
                resultadoTicket = True
            End If

            If resultadoTicket Then
                ultimoCmp = fe.F1CompUltimoAutorizado(puntoVenta, tipoComprobante)
                Return ultimoCmp
            Else
                Return -1
            End If
        Else
            Return -1
        End If
    End Function

    Private Function inicialesFE(ByVal esTest As Boolean) As Boolean
        If esTest Then
            ' (Deprecado)

            Select Case pc
                Case Is = "JARVIS"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                Case Is = "SERVTEC-06"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                Case Is = "BRUNO"
                    archivo_certificado = Application.StartupPath + "\Certificados\BRUNO2020_Testing.pfx"
                Case Is = "SILVIA"
                    archivo_certificado = Application.StartupPath + "\Certificados\SILVIA.pfx"
                Case Else
                    MsgBox("PC no habilitada para emitir documentos de testing.", vbCritical + vbOKOnly, "Centrex")
                    Return False
            End Select
            archivo_licencia = ""
            archivo_licencia = Application.StartupPath + "\Certificados\WSAFIPFE.lic"
        Else
            ' (Deprecado)
            Select Case pc
                Case Is = "JARVIS"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS.pfx"
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
            archivo_licencia = Application.StartupPath + "\Certificados\WSAFIPFE.lic"
        End If

        If Not File.Exists(archivo_certificado) Then
            MsgBox("No existe el archivo del certificado, no podrá continuar.", vbCritical + vbOKOnly, "Centrex")
            Return False
        ElseIf Not File.Exists(archivo_licencia) And Not esTest Then
            MsgBox("No existe el archivo de la licencia, no podrá continuar.", vbCritical + vbOKOnly, "Centrex")
            Return False
        End If

        cuit_emisor = cuit_emisor_default
        password_certificado = "Ladeda78"
        Return True
    End Function

    Private Function errorFE(ByVal fe As Object, ByVal c As comprobante) As String
        Dim errorStr As String
        errorStr = "El número del último comprobante autorizado para: " + c.comprobante + " es: " + fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString
        If fe.F1RespuestaResultado IsNot Nothing Then errorStr += vbCr + "Resultado global AFIP: " + fe.F1RespuestaResultado.ToString
        If fe.F1RespuestaReProceso IsNot Nothing Then errorStr += vbCr + "Es reproceso? " + fe.F1RespuestaReProceso.ToString
        errorStr += vbCr + "Registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg).ToString
        errorStr += vbCr + "Eror genérico global A: " + fe.f1ErrorCode1.ToString
        errorStr += vbCr + "Error genérico global B:" + fe.f1ErrorMsg1.ToString
        errorStr += vbCr + "Error dertallado del comprobante: " + fe.F1RespuestaDetalleObservacionMsg1 + vbCr + vbCr
        If fe.f1ErrorItemCantidad > 0 Then
            fe.f1IndiceItem = 0
            errorStr += "*** ERROR DEVUELTOS POR AFIP ***" + vbCr
            Dim count As Integer
            For count = 0 To fe.f1ErrorItemCantidad - 1
                fe.f1IndiceItem = count
                errorStr += vbCr + "Error Nº: " & count.ToString & " >> Código de error: " + fe.f1ErrorCode.ToString + " Mensaje: " + fe.f1ErrorMsg.ToString
            Next
        End If
        Return errorStr
    End Function

    Public Function Guardar_QR_DB(ByVal archivo_imagen As String, ByVal id_pedido As Integer)
        Dim ds As New DataSet
        Dim con As New SqlClient.SqlConnection("Server=" + serversql + ";Database=" + basedb + ";Uid=" + usuariodb + ";Password=" + passdb)
        Dim img As Image
        Dim ms As New System.IO.MemoryStream
        Dim md As Byte()
        Dim sqlstr As String
        Dim param As New SqlClient.SqlParameter("@qr", SqlDbType.Image)
        con.Open()
        sqlstr = "UPDATE pedidos SET fc_qr = @qr WHERE id_pedido = '" + id_pedido.ToString + "'"
        Dim cmd As New SqlClient.SqlCommand(sqlstr, con)

        img = Image.FromFile(archivo_imagen)

        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        md = ms.GetBuffer

        param.Value = md
        cmd.Parameters.Add(param)
        cmd.ExecuteNonQuery()
        con.Close()
        Return 0
    End Function

    Private Function Resultado_Ticket_acceso(ByRef fe As WSAFIPFE.Factura) As Boolean
        Dim resultadoTicket As Boolean
        fe.tls = 12
        fe.ArchivoCertificadoPassword = password_certificado

        If fe.f1TicketEsValido Then
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "\ticketAccesoFE.jav") Then
                fe.f1RestaurarTicketAcceso(leerArchivoTexto(Application.StartupPath + "\ticketAccesoFE.jav"))
            End If
            Return 1
        Else
            resultadoTicket = fe.f1ObtenerTicketAcceso()
            guardarArchivoTexto(Application.StartupPath + "\ticketAccesoFE.jav", fe.f1GuardarTicketAcceso)
            If Not resultadoTicket Then
                Return 0
            Else
                Return 1
            End If
        End If
    End Function

    Public Sub Consultar_Comprobante(ByVal pVenta As Integer, ByVal tipo_comprobante As Integer, ByVal nComprobante As String)
        ' Eliminado uso de WSAFIPFE
        Dim resultado As Boolean
        'Dim respuestaCAE As String

        If Not inicialesFE(0) Then
            MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            If Not Resultado_Ticket_acceso(fe) Then
                MsgBox("Error al obtener el ticket de acceso, con el siguiente error: " + fe.UltimoMensajeError)
                Exit Sub
            Else
                fe.F1CabeceraCantReg = 1
                fe.f1Indice = 0
                fe.f1IndiceItem = 0
                fe.F1DetalleQRArchivo = Application.StartupPath + "\QR\" + nComprobante + ".jpg"
                fe.f1detalleqrformato = 6
                fe.f1detalleqrresolucion = 20
                fe.f1detalleqrtolerancia = 3
                fe.ArchivoXMLRecibido = "c:\recibido.xml"
                resultado = fe.F1CompConsultar(pVenta, tipo_comprobante, nComprobante)
                If fe.UltimoMensajeError = "" Then
                    'respuestaCAE = "CAE consultado: " + fe.F1RespuestaDetalleCae + vbCrLf
                    'respuestaCAE += "Total: " + Str(fe.F1DetalleImpTotal)
                    'MsgBox(respuestaCAE, vbInformation + vbOKOnly, "Centrex")
                    Dim resultadofc As New resultado_info_fc(fe.F1RespuestaDetalleCae, fe.F1DetalleIvaBaseImp, fe.F1DetalleIvaImporte, fe.F1DetalleImpTotal, fe.F1DetalleDocNro)
                    resultadofc.ShowDialog()
                Else
                    MsgBox("Fallo la consulta con el siguiente error:" + fe.UltimoMensajeError)

                End If
            End If
        Else
            MsgBox("Fallo al iniciar el webservice con el siguiente error: " + fe.UltimoMensajeError)
        End If
    End Sub
End Module
