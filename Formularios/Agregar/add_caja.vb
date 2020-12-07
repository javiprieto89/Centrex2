Public Class add_caja
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_caja.Text = "" Then
            MsgBox("El campo 'Caja' es obligatorio y está vacio")
        End If

        Dim tmp As New caja

        tmp.nombre = txt_caja.Text
        tmp.esCC = chk_cc.Checked
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_caja = edita_caja.id_caja
            If updateCaja(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la caja, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addCaja(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_caja.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_caja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_caja.Text = edita_caja.nombre
            chk_cc.Checked = edita_caja.esCC
            chk_activo.Checked = edita_caja.activo
        End If

        If borrado = True Then
            txt_caja.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta caja?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarCaja(edita_caja)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la caja, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateCaja(edita_caja, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la caja no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la caja, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la caja, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class