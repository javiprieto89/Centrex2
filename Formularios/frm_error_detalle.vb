Public Class frm_error_detalle
    Private Sub frm_error_detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Centrar el formulario
        Me.CenterToParent()
    End Sub

    Public Sub MostrarError(titulo As String, mensaje As String, detalles As String)
        Me.Text = titulo
        txt_mensaje.Text = mensaje
        txt_detalles.Text = detalles
        
        ' Seleccionar todo el texto para facilitar la copia
        txt_detalles.SelectAll()
        txt_detalles.Focus()
    End Sub

    Private Sub btn_copiar_Click(sender As Object, e As EventArgs) Handles btn_copiar.Click
        Try
            Dim textoCompleto As String = "TÍTULO: " & Me.Text & vbCrLf & vbCrLf &
                                        "MENSAJE: " & txt_mensaje.Text & vbCrLf & vbCrLf &
                                        "DETALLES: " & txt_detalles.Text
            
            Clipboard.SetText(textoCompleto)
            MessageBox.Show("Error copiado al portapapeles", "Centrex", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al copiar: " & ex.Message, "Centrex", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Me.Close()
    End Sub

    Private Sub txt_detalles_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_detalles.KeyDown
        ' Ctrl+A para seleccionar todo
        If e.Control AndAlso e.KeyCode = Keys.A Then
            txt_detalles.SelectAll()
            e.Handled = True
        End If
    End Sub
End Class
