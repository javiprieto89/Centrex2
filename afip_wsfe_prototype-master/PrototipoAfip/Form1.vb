Imports System.Globalization
Imports System.IO
Imports System.Net
Public Class Form1
    Private Sub Buscar_btn_Click(sender As Object, e As EventArgs) Handles Buscar_btn.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            CertificadoTX.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private l As LoginClass
    Private url As String = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms"
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        l = New LoginClass(ServicioTX.Text, url, CertificadoTX.Text, ClaveTX.Text)
        l.hacerLogin()
        guardar_params()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fuerza TLS 1.2 para cumplir con los requisitos de AFIP.
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
        cargar_params()
    End Sub
    Private Sub guardar_params()
        My.Settings.def_cert = CertificadoTX.Text
        My.Settings.def_pass = ClaveTX.Text
        My.Settings.def_serv = ServicioTX.Text
        My.Settings.def_url = url
        My.Settings.def_cuit = CuitEmisorTX.Text
        My.Settings.Save()
    End Sub

    Private Sub cargar_params()
        My.Settings.Reload()
        CertificadoTX.Text = My.Settings.def_cert
        ClaveTX.Text = My.Settings.def_pass
        ServicioTX.Text = My.Settings.def_serv
        url = My.Settings.def_url
        CuitEmisorTX.Text = My.Settings.def_cuit
    End Sub

    Private Sub VerTokenBtn_Click(sender As Object, e As EventArgs) Handles VerTokenBtn.Click
        LargeText.mostrarMensaje(l.Token)
    End Sub

    Private Sub VerSignBtn_Click(sender As Object, e As EventArgs) Handles VerSignBtn.Click
        LargeText.mostrarMensaje(l.Sign)
    End Sub

    Private Sub VerFullRequestBtn_Click(sender As Object, e As EventArgs) Handles VerFullRequestBtn.Click
        If l.XDocRequest Is Nothing Then Return
        LargeText.mostrarMensaje(l.XDocRequest.ToString)
    End Sub

    Private Sub VerFullResponseBtn_Click(sender As Object, e As EventArgs) Handles VerFullResponseBtn.Click
        If l.XDocResponse Is Nothing Then Return
        LargeText.mostrarMensaje(l.XDocResponse.ToString)
    End Sub

    Private Sub WSFE_BTN_Click(sender As Object, e As EventArgs) Handles WSFE_BTN.Click
        FacturaForm.Login = l
        FacturaForm.Show()
    End Sub

    Private Sub testing_rb_CheckedChanged(sender As Object, e As EventArgs) Handles testing_rb.CheckedChanged
        url = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms"
    End Sub

    Private Sub produccion_rb_CheckedChanged(sender As Object, e As EventArgs) Handles produccion_rb.CheckedChanged
        url = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl"
    End Sub

    Private Sub TestServerBTN_Click(sender As Object, e As EventArgs) Handles TestServerBTN.Click
        Dim s As New WSFEHOMO.Service
        Dim f As WSFEHOMO.DummyResponse = s.FEDummy
        MsgBox(String.Format("{0} - {1} - {2}", f.AppServer, f.AuthServer, f.DbServer))
    End Sub

    Private Sub FactObjTest_Click(sender As Object, e As EventArgs) Handles FactObjTest.Click
        Dim f As New FacturaPrueba
        f.Show()
    End Sub


    Private Sub EmitirWorkflowBtn_Click(sender As Object, e As EventArgs) Handles EmitirWorkflowBtn.Click
        Try
            Dim ambiente = If(testing_rb.Checked, AfipWorkflow.AfipEnvironment.Homologacion, AfipWorkflow.AfipEnvironment.Produccion)
            Dim certPath = CertificadoTX.Text
            Dim certificadoDisponible = Not String.IsNullOrWhiteSpace(certPath) AndAlso File.Exists(certPath)
            Dim puedeReutilizarLogin = (ambiente = AfipWorkflow.AfipEnvironment.Homologacion) AndAlso Not certificadoDisponible AndAlso l IsNot Nothing AndAlso l.Logeado

            If Not certificadoDisponible AndAlso Not puedeReutilizarLogin Then
                Dim mensajeAdvertencia = If(ambiente = AfipWorkflow.AfipEnvironment.Homologacion,
                                            "En homologación podés reutilizar la sesión activa desde 'Login' o indicar el certificado de pruebas.",
                                            "Ingrese un certificado valido antes de continuar.")
                MsgBox(mensajeAdvertencia)
                Return
            End If

            Dim password = ClaveTX.Text
            Dim servicioSeleccionado = If(ServicioTX.SelectedItem Is Nothing, String.Empty, ServicioTX.SelectedItem.ToString())
            Dim servicio = If(String.IsNullOrWhiteSpace(servicioSeleccionado), "wsfe", servicioSeleccionado)

            Dim cuitEmisorTexto = CuitEmisorTX.Text.Trim()
            Dim cuitEmisor As Long
            If Not Long.TryParse(cuitEmisorTexto, cuitEmisor) Then
                MsgBox("CUIT del emisor invalido.")
                Return
            End If

            Dim puntoVentaTexto = InputBox("Punto de venta.", "Punto de venta", "1")
            Dim puntoVenta As Integer
            If Not Integer.TryParse(puntoVentaTexto, puntoVenta) Then
                MsgBox("Punto de venta invalido.")
                Return
            End If

            Dim tipoComprobanteTexto = InputBox("Tipo de comprobante AFIP (ej. 1 = Factura A, 6 = Factura B).", "Tipo comprobante", "1")
            Dim tipoComprobante As Integer
            If Not Integer.TryParse(tipoComprobanteTexto, tipoComprobante) Then
                MsgBox("Tipo de comprobante invalido.")
                Return
            End If

            Dim docTipoTexto = InputBox("Tipo de documento del receptor (ej. 80 = CUIT).", "Tipo documento", "80")
            Dim docTipo As Integer
            If Not Integer.TryParse(docTipoTexto, docTipo) Then
                MsgBox("Tipo de documento invalido.")
                Return
            End If

            Dim docNroTexto = InputBox("Documento del receptor.", "Documento receptor", "20111111112")
            Dim docNro As Long
            If Not Long.TryParse(docNroTexto, docNro) Then
                MsgBox("Documento del receptor invalido.")
                Return
            End If

            Dim descripcionItem = InputBox("Descripcion del item.", "Descripcion", "Producto demostracion")
            If String.IsNullOrWhiteSpace(descripcionItem) Then
                MsgBox("Ingrese una descripcion.")
                Return
            End If

            Dim netoTexto = InputBox("Importe neto gravado.", "Importe neto", "1000,00")
            Dim neto As Decimal
            If Not Decimal.TryParse(netoTexto, NumberStyles.Any, CultureInfo.CurrentCulture, neto) Then
                MsgBox("Importe neto invalido.")
                Return
            End If

            Dim alicuotaTexto = InputBox("Alicuota de IVA (porcentaje).", "IVA", "21")
            Dim alicuota As Decimal
            If Not Decimal.TryParse(alicuotaTexto, NumberStyles.Any, CultureInfo.CurrentCulture, alicuota) Then
                MsgBox("Alicuota invalida.")
                Return
            End If

            Dim factura As New Factura With {
                .PuntoVenta = puntoVenta,
                .TipoFacturaId = tipoComprobante,
                .Concepto = 1,
                .DocTipo = docTipo,
                .Documento = docNro,
                .Fecha = Date.Today,
                .FechaVencimiento = Date.Today.AddDays(10)
            }

            factura.addDetalle(codigo:=Nothing, cant:=1, precioNeto:=neto, descripcion:=descripcionItem, alicuota:=alicuota)

            Dim respuesta As WSFEHOMO.FECAEResponse
            If puedeReutilizarLogin Then
                respuesta = AfipWorkflow.EmitirFacturaAfip(factura,
                                                           certificadoPath:=String.Empty,
                                                           certificadoPassword:=password,
                                                           servicio:=servicio,
                                                           cuitEmisor:=cuitEmisor,
                                                           monedaCodigo:="PES",
                                                           ambiente:=ambiente,
                                                           loginExistente:=l)
            Else
                respuesta = AfipWorkflow.EmitirFacturaAfip(factura,
                                                           certificadoPath:=certPath,
                                                           certificadoPassword:=password,
                                                           servicio:=servicio,
                                                           cuitEmisor:=cuitEmisor,
                                                           monedaCodigo:="PES",
                                                           ambiente:=ambiente)
            End If

            Dim detalle As WSFEHOMO.FECAEDetResponse = Nothing
            If respuesta.FeDetResp IsNot Nothing AndAlso respuesta.FeDetResp.Length > 0 Then
                detalle = respuesta.FeDetResp(0)
            End If

            Dim mensaje As String
            If detalle IsNot Nothing Then
                mensaje = "Resultado: " & detalle.Resultado & Environment.NewLine
                mensaje &= "CAE: " & detalle.CAE & Environment.NewLine
                mensaje &= "Vencimiento CAE: " & detalle.CAEFchVto & Environment.NewLine
                mensaje &= "Desde-Hasta: " & detalle.CbteDesde & "-" & detalle.CbteHasta & Environment.NewLine
                mensaje &= "Importe total informado: " & factura.Total.ToString(CultureInfo.CurrentCulture)
            Else
                mensaje = "La respuesta no contiene detalle FECAEDetResp."
            End If

            If respuesta.Errors IsNot Nothing Then
                For Each er In respuesta.Errors
                    mensaje &= Environment.NewLine & "Error " & er.Code & ": " & er.Msg
                Next
            End If
            If detalle IsNot Nothing AndAlso detalle.Observaciones IsNot Nothing Then
                For Each obs In detalle.Observaciones
                    mensaje &= Environment.NewLine & "Obs " & obs.Code & ": " & obs.Msg
                Next
            End If

            LargeText.mostrarMensaje(mensaje)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class



