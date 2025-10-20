Public Class add_permisos_perfiles
    Private Sub add_permisos_perfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todos los permisos
        cargar_combo(cmb_perfiles, "SELECT id_permiso, nombre FROM permisos ORDER BY nombre ASC", basedb, "nombre", "id_permiso")
        cmb_perfiles.Text = "Selecione un permiso..."
        'Cargo todos los perfiles
        cargar_combo(cmb_perfiles, "SELECT id_perfil, nombre FROM perfiles ORDER BY nombre ASC", basedb, "nombre", "id_perfil")
        cmb_perfiles.Text = "Selecione un perfil..."


        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            cmb_permisos.SelectedValue = edita_permiso_perfil.id_permiso
            cmb_perfiles.SelectedValue = edita_permiso_perfil.id_perfil
            cmb_permisos.Enabled = False
            cmb_perfiles.Enabled = False
        End If

        If borrado = True Then
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta relación entre el perfil y el permiso?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarTarjeta(edita_tarjeta)) = False Then
                    MsgBox("No se ha podido borrar la relación, consulte con el programador")
                End If
            End If
            closeandupdate(Me)
        ElseIf edicion = True Then
            MsgBox("La relación entre un permiso y un perfil no puede editarse", vbExclamation + vbOKOnly, "Dr. Oil")
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_permisos.Text = "Seleccione un permiso..." Then
            MsgBox("Debe seleccionar un permiso")
            Exit Sub
        ElseIf cmb_perfiles.Text = "Seleccione un perfil..." Then
            MsgBox("Debe seleccionar un perfil")
            Exit Sub
        End If

        Dim tmp As New perfil_permiso


        tmp.id_permiso = cmb_permisos.SelectedValue
        tmp.id_perfil = cmb_perfiles.SelectedValue

        add_permiso_perfil(tmp)

        If chk_secuencia.Checked = True Then
            cmb_perfiles.Text = "Selecione un permiso..."
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_permisos_perfiles_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmb_permisos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_permisos.KeyPress
        e.KeyChar = ""
    End Sub

    Private Sub cmb_perfiles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_perfiles.KeyPress
        e.KeyChar = ""
    End Sub
End Class