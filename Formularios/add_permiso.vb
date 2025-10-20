Public Class add_permiso
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_permiso.Text = "" Then
            MsgBox("El campo 'Permiso' es obligatorio y está vacio")
        End If

        Dim tmp As New permiso

        tmp.nombre = txt_permiso.Text

        If edicion = True Then
            tmp.id_permiso = edita_permiso.id_permiso
            If updatepermiso(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el permiso, consulte con su programdor", vbExclamation + vbOKOnly, "Dr. Oil")
                closeandupdate(Me)
            End If
        Else
            addpermiso(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_permiso.Text = ""
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_permiso_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_permiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_permiso.Text = edita_permiso.nombre
        End If

        If borrado = True Then
            txt_permiso.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este permiso?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarpermiso(edita_permiso)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del permiso, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatepermiso(edita_permiso, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el permiso no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el permiso, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar del permiso, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class