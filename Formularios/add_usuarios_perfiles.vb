Public Class add_usuarios_perfiles
    Private Sub add_usuarios_perfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todos los usuarios
        cargar_combo(cmb_usuarios, "SELECT id_usuario, CONCAT(usuario, ' - ', nombre) AS 'nombre' FROM usuarios ORDER BY usuario ASC", basedb, "nombre", "id_usuario")
        cmb_usuarios.Text = "Selecione un permiso..."
        'Cargo todos los perfiles
        cargar_combo(cmb_perfiles, "SELECT id_perfil, nombre FROM perfiles ORDER BY nombre ASC", basedb, "nombre", "id_perfil")
        cmb_usuarios.Text = "Selecione un perfil..."


        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            cmb_usuarios.SelectedValue = edita_permiso_perfil.id_perfil
            cmb_perfiles.SelectedValue = edita_permiso_perfil.id_permiso
            cmb_usuarios.Enabled = False
            cmb_perfiles.Enabled = False
        End If

        If borrado = True Then
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta relación entre el usuario y el perfil?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarTarjeta(edita_tarjeta)) = False Then
                    MsgBox("No se ha podido borrar la relación, consulte con el programador")
                End If
            End If
            closeandupdate(Me)
        ElseIf edicion = True Then
            MsgBox("La relación entre un usuario y un perfil no puede editarse", vbExclamation + vbOKOnly, "Dr. Oil")
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_usuarios.Text = "Seleccione un usuario..." Then
            MsgBox("Debe seleccionar un usuario")
            Exit Sub
        ElseIf cmb_perfiles.Text = "Seleccione un perfil..." Then
            MsgBox("Debe seleccionar un perfil")
            Exit Sub
        End If

        Dim tmp As New usuario_perfil

        tmp.id_usuario = cmb_usuarios.SelectedValue
        tmp.id_perfil = cmb_perfiles.SelectedValue

        add_usuario_perfil(tmp)

        If chk_secuencia.Checked = True Then
            cmb_perfiles.Text = "Selecione un perfil..."
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_usuarios_perfiles_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmb_permisos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_perfiles.KeyPress
        e.KeyChar = ""
    End Sub

    Private Sub cmb_perfiles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_usuarios.KeyPress
        e.KeyChar = ""
    End Sub
End Class