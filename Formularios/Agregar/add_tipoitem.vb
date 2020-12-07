Public Class add_tipoitem
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_tipoitem.Text = "" Then
            MsgBox("El campo 'Categoría' es obligatorio y está vacio")
        End If

        Dim tmp As New tipoitem

        tmp.tipo = txt_tipoitem.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_tipo = edita_tipoitem.id_tipo
            If updatetipoitem(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la categoría, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addtipoitem(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_tipoitem.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_tipoitem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_tipoitem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_tipoitem.Text = edita_tipoitem.tipo
            chk_activo.Checked = edita_tipoitem.activo
        End If

        If borrado = True Then
            txt_tipoitem.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta categoría?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrartipoitem(edita_tipoitem)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la categoría, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatetipoitem(edita_tipoitem, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la categoría no se borró definitivamente." + Chr(13) + _
                                "Esto posiblemente se deba a que la categoría, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la categoría, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class