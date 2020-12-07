Module factura
    Public Function facturar(ByVal p As pedido) As Boolean
        'SI DEVUELVE 1 ESTÁ TODO OK
        'SI DEVUELVE 0 HUBO UN ERROR

        '************** FACTURA ELECTRONICA ************** 

        'Obtengo los datos del comprobante
        Dim c As New comprobante
        c = info_comprobante(p.id_comprobante)

        If c.esPresupuesto Then
            c.numeroComprobante = c.numeroComprobante + 1
            updatecomprobante(c)
            p.cerrado = True
            p.activo = False
            p.puntoVenta = c.puntoVenta
            p.numeroComprobante = c.numeroComprobante
            updatepedido(p)
            Return True
        End If

        If c.esManual Then
            c.numeroComprobante = c.numeroComprobante + 1
            updatecomprobante(c)
            p.cerrado = True
            p.activo = False
            p.puntoVenta = c.puntoVenta
            p.numeroComprobante = c.numeroComprobante
            updatepedido(p)
            Return True
        End If


        'Obtengo los datos del cliente
        Dim cl As New cliente
        cl = info_cliente(p.id_cliente)

        Dim modo As String
        Dim cuit_emisor As String
        Dim archivo_certificado As String
        Dim archivo_licencia As String
        Dim password_certificado As String
        Dim resultadoTicket As Boolean

        Dim lResultado As Boolean
        Dim fe As New WSAFIPFE.Factura

        If c.testing Then
            modo = WSAFIPFE.Factura.modoFiscal.Test
            archivo_certificado = "C:\Certificados\Bruno_prueba.pfx"
            'archivo_certificado = "C:\Certificados\JARVIS\JARVIS.pfx"
            archivo_licencia = ""
            cuit_emisor = cuit_emisor_default
            password_certificado = "Ladeda78"
        Else
            modo = WSAFIPFE.Factura.modoFiscal.Fiscal
            archivo_certificado = "C:\Certificados\Bruno_fe.p12"
            archivo_licencia = "C:\Certificados\WSAFIPFE.lic"
            cuit_emisor = cuit_emisor_default
            password_certificado = "Ladeda78"
        End If

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            fe.ArchivoCertificadoPassword = password_certificado
            'MsgBox(fe.f1TicketHoraVencimiento)
            'Return False
            'Exit Function
            If Not fe.f1TicketEsValido Then
                resultadoTicket = fe.f1ObtenerTicketAcceso()
                If Not resultadoTicket Then
                    Return False
                    Exit Function
                End If
            Else
                resultadoTicket = True
            End If

            'MsgBox("Último autorizado para " & c.comprobante & ", Punto venta: " & c.puntoVenta & ": " & fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString)

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
                fe.F1DetalleIvaId = 5 'IVA 21/ IVA 10.5
                fe.F1DetalleIvaBaseImp = p.subTotal
                fe.F1DetalleIvaImporte = p.iva

                fe.ArchivoXMLRecibido = "c:\recibido.xml"
                fe.ArchivoXMLEnviado = "c:\enviado.xml"

                lResultado = fe.F1CAESolicitar()

                If lResultado And fe.F1RespuestaDetalleCae <> "" Then
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
                    Return True
                Else
                    If Not c.testing Then
                        'MsgBox("El número del último comprobante autorizado para: " + c.comprobante + " es: " + fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString)
                        'MsgBox("resultado global AFIP: " + fe.F1RespuestaResultado)
                        'MsgBox("es reproceso? " + fe.F1RespuestaReProceso)
                        'MsgBox("registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg))
                        'MsgBox("error genérico global:" + fe.f1ErrorMsg1)
                        Return False 'Si no está en modo testing devuelve error
                    End If
                End If
                'Si es un test me devuelve la información de los errores
                'Consulta del último comprobante autorizado
                MsgBox("El número del último comprobante autorizado para: " + c.comprobante + " es: " + fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString)
                MsgBox("resultado global AFIP: " + fe.F1RespuestaResultado)
                MsgBox("es reproceso? " + fe.F1RespuestaReProceso)
                MsgBox("registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg))
                MsgBox("error genérico global:" + fe.f1ErrorMsg1)
                If fe.F1RespuestaCantidadReg > 0 Then
                    fe.f1Indice = 0
                    MsgBox("resultado detallado comprobante: " + fe.F1RespuestaDetalleResultado)
                    MsgBox("cae comprobante: " + fe.F1RespuestaDetalleCae)
                    MsgBox("número comprobante:" + fe.F1RespuestaDetalleCbteDesdeS)
                    MsgBox("error detallado comprobante: " + fe.F1RespuestaDetalleObservacionMsg1)

                    If fe.F1RespuestaDetalleCae <> "" Then
                        Return True
                    Else
                        Return False
                    End If
                End If
                Return False
            Else
                MsgBox(fe.UltimoMensajeError)
                Return False
            End If

        Else
            MsgBox(fe.UltimoMensajeError)
            Return False
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
            Dim frm As New frm_reportes(esPresupuesto, imprimeRemito)
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

    Public Sub check_ultimo_comrpobante_emitido(ByVal puntoVenta As String, ByVal tipoComprobante As String)
        Dim modo As String
        Dim cuit_emisor As String
        Dim archivo_certificado As String
        Dim archivo_licencia As String
        Dim password_certificado As String
        Dim fe As New WSAFIPFE.Factura

        modo = WSAFIPFE.Factura.modoFiscal.Test
        archivo_certificado = "C:\Certificados\JARVIS\JARVIS.pfx"
        archivo_licencia = ""
        cuit_emisor = cuit_emisor_default
        password_certificado = "Ladeda78"

        If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
            MsgBox("El número del último comprobante autorizado es: " + fe.F1CompUltimoAutorizado(puntoVenta, tipoComprobante).ToString)
        Else
            MsgBox(fe.UltimoMensajeError)
        End If
    End Sub
End Module
