Public Class add_marcai
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_marca.Text = "" Then
            MsgBox("El campo 'Marca' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim tmp As New marca_item

        tmp.marca = txt_marca.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_marca = edita_marcai.id_marca
            If updatemarcai(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la marca, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addmarcai(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_marca.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_marcai_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_marcai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_marca.Text = edita_marcai.marca
            chk_activo.Checked = edita_marcai.activo
        End If

        If borrado = True Then
            txt_marca.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta marca de auto?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarmarcai(edita_marcai)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la marca, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatemarcai(edita_marcai, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la marca no se borró definitivamente." + Chr(13) + _
                                "Esto posiblemente se deba a que el cliente, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el cliente, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class