Public Class add_usuario
    Private Sub add_usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim encripta As New Encriptar
        Dim up As New usuario_perfil

        cargar_combo(cmb_perfil, "SELECT id_perfil, nombre FROM perfiles ORDER BY nombre ASC", basedb, "nombre", "id_perfil")
        cmb_perfil.Text = "Seleccione un perfil..."

        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            'up = info_perfi
            chk_secuencia.Enabled = False
            txt_usuario.Text = edita_usuario.usuario
            txt_password.Text = encripta.Desencriptar(edita_usuario.password)
            txt_nombre.Text = edita_usuario.nombre
            cmb_perfil.SelectedValue = 1 'Fijo por el momento
            'cmb_perfil.Enabled = False
            chk_activo.Checked = edita_usuario.activo
        End If

        If borrado = True Then
            txt_usuario.Enabled = False
            txt_password.Enabled = False
            txt_nombre.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este usuario?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarUsuario(edita_usuario)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del usuario, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateUsuario(edita_usuario, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el usuario no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el usuario, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar del usuario, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_usuario.Text = "" Then
            MsgBox("El campo 'Usuario' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_password.Text = "" Then
            MsgBox("El campo 'Password' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_nombre.Text = "" Then
            MsgBox("El campo 'Nombre' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_perfil.Text = "Seleccione un perfil..." Then
            MsgBox("Debe seleccionar un perfil inicial")
            Exit Sub
        End If

        Dim u As New usuario
        Dim perf_user As New usuario_perfil
        Dim encripta As New Encriptar

        u.usuario = txt_usuario.Text
        u.password = encripta.Encriptar(txt_password.Text)
        u.nombre = txt_nombre.Text
        u.activo = chk_activo.Checked

        If edicion = True Then
            u.id_usuario = edita_usuario.id_usuario
            If updateUsuario(u) = False Then
                MsgBox("Hubo un problema al actualizar el usuario, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addUsuario(u)
            u = info_usuario(txt_usuario.Text, False)
            If u.usuario = "error" Then
                MsgBox("Ha ocurrido un error al crear el usuario, consulte con su programador.", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            End If
            perf_user.id_perfil = cmb_perfil.SelectedValue
            perf_user.id_usuario = u.id_usuario

            If Not add_usuario_perfil(perf_user) Then
                MsgBox("Ha ocurrido un error al hacer la asignación del usuario con el perfil.", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            End If
        End If

        If chk_secuencia.Checked = True Then
            txt_usuario.Text = ""
            txt_password.Text = ""
            txt_nombre.Text = ""
            cmb_perfil.Text = "Selecione un perfil..."
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_usuario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub pic_showPassword_Click(sender As Object, e As EventArgs) Handles pic_showPassword.Click
        txt_password.UseSystemPasswordChar = False
    End Sub

    Private Sub pic_showPassword_MouseLeave(sender As Object, e As EventArgs) Handles pic_showPassword.MouseLeave
        txt_password.UseSystemPasswordChar = True
    End Sub

    Private Sub cmb_perfil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_perfil.KeyPress
        e.KeyChar = ""
    End Sub
End Class