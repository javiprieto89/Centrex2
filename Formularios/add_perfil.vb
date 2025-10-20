Public Class add_perfil
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_perfil.Text = "" Then
            MsgBox("El campo 'Perfil' es obligatorio y está vacio")
        End If

        Dim tmp As New perfil

        tmp.nombre = txt_perfil.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_perfil = edita_perfil.id_perfil
            If updateperfil(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el perfil, consulte con su programdor", vbExclamation + vbOKOnly, "Dr. Oil")
                closeandupdate(Me)
            End If
        Else
            addperfil(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_perfil.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_perfil_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_perfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_perfil.Text = edita_perfil.nombre
            chk_activo.Checked = edita_perfil.activo
        End If

        If borrado = True Then
            txt_perfil.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este perfil?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarperfil(edita_perfil)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del perfil, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateperfil(edita_perfil, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el perfil no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el perfil, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar del perfil, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class