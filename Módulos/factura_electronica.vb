Imports System.IO

Module factura
    Private pc As String
    Private modo As String
    Private archivo_certificado As String
    Private archivo_licencia As String
    Private password_certificado As String
    Private cuit_emisor As String

    Public Function facturar(ByVal p As pedido) As Integer
        'SI DEVUELVE 1 ESTÁ TODO OK
        'SI DEVUELVE 0 HUBO UN ERROR

        '************** FACTURA ELECTRONICA ************** 
        Dim resultadoTicket As Boolean
        Dim lResultado As Boolean
        Dim cl As New cliente
        Dim c As New comprobante
        Dim fe As New WSAFIPFE.Factura


        'Obtengo los datos del comprobante
        c = info_comprobante(p.id_comprobante)

        If c.esPresupuesto Or c.esManual Then
            c.numeroComprobante += 1
            updatecomprobante(c)
            p.cerrado = True
            p.activo = False
            p.puntoVenta = c.puntoVenta
            p.numeroComprobante = c.numeroComprobante
            updatepedido(p)
            Return 1
        End If

        'Obtengo los datos del cliente
        cl = info_cliente(p.id_cliente)

        If Not inicialesFE(c.testing) Then
            MsgBox("Hubo un problema al inicializar el webservice, puede ser un problema de certificados", vbCritical + vbOKOnly, "Centrex")
            Return 0
            Exit Function
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            fe.tls = 12
            fe.ArchivoCertificadoPassword = password_certificado
            'MsgBox(fe.f1TicketHoraVencimiento)
            'Return 0            
            If fe.f1TicketEsValido Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath + "\ticketAccesoFE.jav") Then
                    fe.f1RestaurarTicketAcceso(leerArchivoTexto(Application.StartupPath + "\ticketAccesoFE.jav"))
                End If
            Else
                resultadoTicket = fe.f1ObtenerTicketAcceso()
                guardarArchivoTexto(Application.StartupPath + "\ticketAccesoFE.jav", fe.f1GuardarTicketAcceso)
                If Not resultadoTicket Then
                    MsgBox(errorFE(fe, c) & vbCr & vbCr &
                                   "Error al obtener el ticket de acceso, PROBLEMA DE AFIP")
                    Return 0
                    Exit Function
                End If
            End If

            'If Not fe.f1TicketEsValido Then
            '    resultadoTicket = fe.f1ObtenerTicketAcceso()
            '    guardarArchivoTexto(Application.StartupPath + "\ticketAccesoFE.jav", fe.f1GuardarTicketAcceso)
            '    If Not resultadoTicket Then
            '        MsgBox(errorFE(fe, c) & vbCr & vbCr &
            '                       "Error al obtener el ticket de acceso, PROBLEMA DE AFIP")
            '        Return 0
            '        Exit Function
            '    End If
            'Else
            '    resultadoTicket = True
            'End If

            If resultadoTicket Then
                fe.F1CabeceraCantReg = 1
                fe.F1CabeceraPtoVta = c.puntoVenta
                fe.F1CabeceraCbteTipo = c.id_tipoComprobante  'FACTURA A/B/NC

                fe.f1Indice = 0
                fe.F1DetalleConcepto = 1
                fe.F1DetalleDocTipo = cl.id_tipoDocumento     'CUIT/CUIL/DNI
                fe.F1DetalleDocNro = cl.taxNumber    'CUIT
                fe.F1DetalleCbteDesde = c.numeroComprobante + 1
                fe.F1DetalleCbteHasta = c.numeroComprobante + 1
                fe.F1DetalleCbteFch = fechaAFIP()
                fe.F1DetalleImpTotal = p.total
                fe.F1DetalleImpTotalConc = 0
                fe.F1DetalleImpNeto = p.subTotal
                fe.F1DetalleImpOpEx = 0
                fe.F1DetalleImpIva = p.iva
                fe.F1DetalleMonId = "PES"
                fe.F1DetalleMonCotiz = 1

                fe.F1DetalleIvaItemCantidad = 1
                fe.f1IndiceItem = 0
                Select Case c.id_tipoComprobante
                    Case Is = 1, 2, 3, 4, 5, 63, 34, 39, 60, 51, 52, 53, 54
                        fe.F1DetalleIvaId = 5 'IVA 21/ IVA 10.5
                    Case Else
                        fe.F1DetalleIvaId = 3 'IVA 0
                End Select

                'Ajusta el tipo de IVA del documento si no tiene IVA
                If p.subTotal = p.total And p.iva = 0 Then fe.F1DetalleIvaId = 3

                fe.F1DetalleIvaBaseImp = p.subTotal
                fe.F1DetalleIvaImporte = p.iva

                fe.ArchivoXMLRecibido = "c:\recibido.xml"
                fe.ArchivoXMLEnviado = "c:\enviado.xml"

                lResultado = fe.F1CAESolicitar()

                'If lResultado And fe.F1RespuestaDetalleCae <> "" Then
                If lResultado Then
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
                    updatepedido(p)
                    Return 1
                Else
                    If Not c.testing Then
                        'MsgBox(fe.F1RespuestaDetalleObservacionCode1)
                        'MsgBox(fe.F1RespuestaDetalleObservacionMsg1)
                        MsgBox(errorFE(fe, c))
                        Return 0 'Si no está en modo testing devuelve error
                    End If
                End If

                MsgBox(errorFE(fe, c))
                If fe.F1RespuestaCantidadReg > 0 Then
                    fe.f1Indice = 0
                    MsgBox(errorFE(fe, c))
                    If fe.F1RespuestaDetalleCae = "" Then Return 0 Else Return 1
                End If
                Return 0
            Else
                MsgBox(fe.UltimoMensajeError)
                Return 0
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
        Dim fe As New WSAFIPFE.Factura
        Dim resultadoTicket As Boolean

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
                Return fe.F1CompUltimoAutorizado(puntoVenta, tipoComprobante)
            Else
                Return -1
            End If
        Else
            Return -1
        End If
    End Function

    Private Function inicialesFE(ByVal esTest As Boolean) As Boolean
        pc = SystemInformation.ComputerName

        If esTest Then
            modo = WSAFIPFE.Factura.modoFiscal.Test

            Select Case pc
                Case Is = "JARVIS"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                Case Is = "SERVTEC-06"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS20171211.pfx"
                Case Is = "BRUNO"
                    archivo_certificado = Application.StartupPath + "\Certificados\BRUNO2020_Testing.pfx"
                Case Else

            End Select
            archivo_licencia = ""
            archivo_licencia = Application.StartupPath + "\Certificados\WSAFIPFE.lic"
        Else
            modo = WSAFIPFE.Factura.modoFiscal.Fiscal
            Select Case pc
                Case Is = "JARVIS"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS.pfx"
                Case Is = "SERVTEC-06"
                    archivo_certificado = Application.StartupPath + "\Certificados\JARVIS.pfx"
                Case Is = "BRUNO"
                    archivo_certificado = Application.StartupPath + "\Certificados\Bruno.pfx"
                Case Else
                    MsgBox("PC no habilitada para emitir documentos de testing.", vbCritical + vbOKOnly, "Centrex")
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


    Private Function errorFE(ByVal fe As WSAFIPFE.Factura, ByVal c As comprobante) As String
        Dim errorStr As String
        errorStr = "El número del último comprobante autorizado para: " + c.comprobante + " es: " + fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString
        If fe.F1RespuestaResultado IsNot Nothing Then errorStr += vbCr + "Resultado global AFIP: " + fe.F1RespuestaResultado.ToString
        If fe.F1RespuestaReProceso IsNot Nothing Then errorStr += vbCr + "Es reproceso? " + fe.F1RespuestaReProceso.ToString
        errorStr += vbCr + "Registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg).ToString
        errorStr += vbCr + "Eror genérico global A: " + fe.f1ErrorCode1.ToString
        errorStr += vbCr + "Error genérico global B:" + fe.f1ErrorMsg1.ToString + vbCr + vbCr
        If fe.f1ErrorItemCantidad > 0 Then
            fe.f1IndiceItem = 0
            errorStr += "*** ERROR DEVUELTOS POR AFIP ***" + vbCr
            Do While fe.f1ErrorItemCantidad <> -1
                errorStr += vbCr + "Código de error: " + fe.f1ErrorCode.ToString + " Mensaje: " + fe.f1ErrorMsg.ToString
                fe.f1IndiceItem += 1
                If fe.f1IndiceItem > 12 Then Exit Do
            Loop
        End If
        Return errorStr
    End Function
End Module
