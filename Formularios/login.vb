Public Class login
    Dim iniciar As Boolean = False

    Private Sub cmd_start_Click(sender As Object, e As EventArgs) Handles cmd_start.Click
        Dim u As usuario

        u = info_usuario(txt_usuario.Text, True)
        If u.usuario = "error" Then
            MsgBox("El nombre de usuario: " + txt_usuario.Text + " NO EXISTE", vbCritical + vbOKOnly, "Centrex")
            Exit Sub
        End If

        u = info_login(txt_usuario.Text, txt_password.Text)
        If u.usuario = "error" Then
            MsgBox("La contraseña ingresada para el usuario: " + txt_usuario.Text + " NO ES CORRECTA.", vbCritical + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf Not u.activo Then
            MsgBox("El usuario: " + txt_usuario.Text + " esta deshabilitado para el inicio de sesión", vbCritical + vbOKOnly, "Centrex")
            Exit Sub
        End If

        usuario_logueado = u
        iniciar = True
        closeandupdate(Me)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub
    Private Sub pic_showPassword_Click(sender As Object, e As EventArgs) Handles pic_showPassword.Click
        txt_password.UseSystemPasswordChar = False
    End Sub

    Private Sub pic_showPassword_MouseLeave(sender As Object, e As EventArgs) Handles pic_showPassword.MouseLeave
        txt_password.UseSystemPasswordChar = True
    End Sub

    Private Sub login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not iniciar Then
            End
        End If
    End Sub

End Class