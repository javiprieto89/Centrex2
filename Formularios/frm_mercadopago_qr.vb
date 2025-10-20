Imports System.Drawing
Imports System.Windows.Forms
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports MessagingToolkit.QRCode.Codec

Public Class frm_mercadopago_qr
    Private qrCodeImage As Image
    Private paymentLink As String
    Private preferenceId As String
    Private accessToken As String = "APP_USR-1861910115308653-101722-495e69898d2624ff1c403ff05258b364-2932397376"
    Private publicKey As String = "APP_USR-8bbcffb2-a950-4a17-9f87-8e196fab2255"
    Private checkTimer As Timer
    Private referencia As String

    Public Sub New()
        InitializeComponent()
        Me.Text = "Pago con MercadoPago"
        Me.Size = New Size(400, 500)
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

    Private Sub frm_mercadopago_qr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lbl_titulo.Text = "Escanear QR para Pagar"
            lbl_titulo.Font = New Font("Arial", 14, FontStyle.Bold)
            lbl_titulo.TextAlign = ContentAlignment.MiddleCenter

            lbl_instrucciones.Text = "1. Abre la app de MercadoPago" & vbCrLf &
                                   "2. Toca 'Escanear código'" & vbCrLf &
                                   "3. Apunta la cámara al QR" & vbCrLf &
                                   "4. Confirma el pago"
            lbl_instrucciones.TextAlign = ContentAlignment.MiddleLeft

            btn_generar_qr.Text = "Generar Nuevo QR"
            btn_copiar_link.Text = "Copiar Link de Pago"
            btn_cerrar.Text = "Cerrar"

            ' Generar QR inicial
            GenerarQR()

        Catch ex As Exception
            MessageBox.Show("Error inicializando formulario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerarQR()
        Try
            Dim monto As Decimal = ObtenerMontoPago()
            Dim descripcion As String = "Pago Centrex - " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            referencia = "CENTREX-" & DateTime.Now.ToString("yyyyMMddHHmmss")

            ' Crear preferencia real
            preferenceId = CrearPreferenciaPago(monto, descripcion, referencia)

            If String.IsNullOrEmpty(preferenceId) Then
                Throw New Exception("No se pudo crear la preferencia de pago.")
            End If

            paymentLink = "https://www.mercadopago.com.ar/checkout/v1/redirect?pref_id=" & preferenceId

            ' Generar QR real
            qrCodeImage = GenerarCodigoQR(paymentLink)

            ' Mostrar QR
            pic_qr.Image = qrCodeImage
            pic_qr.SizeMode = PictureBoxSizeMode.Zoom

            lbl_monto.Text = "Monto: $" & monto.ToString("N2")
            lbl_referencia.Text = "Referencia: " & referencia

            ' Iniciar verificación de pago cada 10 segundos
            If checkTimer IsNot Nothing Then
                checkTimer.Stop()
            End If
            checkTimer = New Timer()
            checkTimer.Interval = 10000
            AddHandler checkTimer.Tick, AddressOf VerificarEstadoPago
            checkTimer.Start()

        Catch ex As Exception
            MessageBox.Show("Error generando QR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ObtenerMontoPago() As Decimal
        Return 10D ' Monto de ejemplo; podés reemplazarlo por el valor real de la licencia
    End Function

    Private Function CrearPreferenciaPago(monto As Decimal, descripcion As String, referencia As String) As String
        Try
            ' JSON de preferencia
            Dim json As String =
                "{" &
                """items"":[{""title"":""" & descripcion & """,""quantity"":1,""unit_price"":" & monto & "}]," &
                """external_reference"":""" & referencia & """,""back_urls"":{""success"":""https://www.mercadopago.com"",""failure"":""https://www.mercadopago.com""},""auto_return"":""approved""" &
                "}"

            Dim request As WebRequest = WebRequest.Create("https://api.mercadopago.com/checkout/preferences")
            request.Method = "POST"
            request.ContentType = "application/json"
            request.Headers.Add("Authorization", "Bearer " & accessToken)

            Using streamWriter As New StreamWriter(request.GetRequestStream())
                streamWriter.Write(json)
            End Using

            Dim response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                Dim result = reader.ReadToEnd()
                Dim j As JObject = JObject.Parse(result)
                Return j("id").ToString() ' preference_id real
            End Using

        Catch ex As Exception
            MessageBox.Show("Error creando preferencia: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Private Function GenerarCodigoQR(texto As String) As Image
        Try
            Dim qrEncoder As New QRCodeEncoder()
            qrEncoder.QRCodeScale = 6
            Dim qrImage As Bitmap = qrEncoder.Encode(texto)
            Return qrImage
        Catch ex As Exception
            MessageBox.Show("Error generando QR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    'Private Sub VerificarEstadoPago(sender As Object, e As EventArgs)
    '    Try
    '        If String.IsNullOrEmpty(preferenceId) Then Exit Sub

    '        ' Buscar pagos asociados a esta preferencia
    '        Dim url As String = "https://api.mercadopago.com/v1/payments/search?sort=date_created&criteria=desc&q=" & preferenceId
    '        Dim client As New WebClient()
    '        client.Headers.Add("Authorization", "Bearer " & accessToken)
    '        Dim response As String = client.DownloadString(url)
    '        Dim j As JObject = JObject.Parse(response)
    '        Dim results = j("results")

    '        If results.HasValues Then
    '            Dim status As String = results(0)("status").ToString()
    '            Dim paymentId As String = results(0)("id").ToString()

    '            Select Case status
    '                Case "approved"
    '                    checkTimer.Stop()
    '                    MessageBox.Show($"✅ Pago aprobado (ID: {paymentId})", "Licencia renovada", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Case "pending"
    '                    lbl_instrucciones.Text = "⏳ Pago pendiente, esperando acreditación..."
    '                Case "rejected"
    '                    checkTimer.Stop()
    '                    MessageBox.Show("❌ Pago rechazado", "Error en pago", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            End Select
    '        End If

    '    Catch ex As Exception
    '        ' Ignorar errores de conexión para no interrumpir el timer
    '    End Try
    'End Sub

    Private Sub VerificarEstadoPago(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(preferenceId) Then Exit Sub

            Dim url As String = "https://api.mercadopago.com/v1/payments/search?external_reference=" & referencia
            Dim client As New WebClient()
            client.Headers.Add("Authorization", "Bearer " & accessToken)
            Dim response As String = client.DownloadString(url)
            Dim j As JObject = JObject.Parse(response)
            Dim results = j("results")

            If results.HasValues Then
                Dim status As String = results(0)("status").ToString()
                Dim statusDetail As String = results(0)("status_detail").ToString()
                Dim paymentId As String = results(0)("id").ToString()
                Dim paymentDate As String = results(0)("date_created").ToString()

                ' === LOG LOCAL ===
                Dim logLine As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {status.ToUpper()} | ID={paymentId} | Pref={preferenceId} | {statusDetail}"
                File.AppendAllText("MP_Transactions.log", logLine & Environment.NewLine)

                ' === REACCIONES ===
                Select Case status
                    Case "approved"
                        checkTimer.Stop()
                        MessageBox.Show($"✅ Pago aprobado (ID: {paymentId})", "Licencia renovada", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' TODO: acá podés activar la licencia, por ejemplo:
                    ' ActualizarLicencia(True)

                    Case "pending"
                        lbl_instrucciones.Text = "⏳ Pago pendiente, esperando acreditación..."
                    Case "rejected"
                        checkTimer.Stop()
                        MessageBox.Show("❌ Pago rechazado", "Error en pago", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        ' TODO: desactivar licencia o marcar error si querés
                        ' ActualizarLicencia(False)
                End Select
            Else
                ' No hay resultados aún (todavía no pagó)
            End If

        Catch ex As Exception
            File.AppendAllText("MP_Transactions.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ERROR | {ex.Message}" & Environment.NewLine)
        End Try
    End Sub


    Private Sub btn_generar_qr_Click(sender As Object, e As EventArgs) Handles btn_generar_qr.Click
        GenerarQR()
    End Sub

    Private Sub btn_copiar_link_Click(sender As Object, e As EventArgs) Handles btn_copiar_link.Click
        Try
            If Not String.IsNullOrEmpty(paymentLink) Then
                Clipboard.SetText(paymentLink)
                MessageBox.Show("Link de pago copiado al portapapeles", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No hay link de pago disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error copiando link: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        If checkTimer IsNot Nothing Then checkTimer.Stop()
        Me.Close()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        If qrCodeImage IsNot Nothing Then qrCodeImage.Dispose()
        MyBase.OnFormClosed(e)
    End Sub
End Class
