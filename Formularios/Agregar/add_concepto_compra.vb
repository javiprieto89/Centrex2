Public Class add_concepto_compra
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_concepto.Text = "" Then
            MsgBox("El campo 'concepto' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New concepto_compra

        tmp.concepto = txt_concepto.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_concepto_compra = edita_concepto_compra.id_concepto_compra
            If updateconcepto_compra(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la concepto, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addconcepto_compra(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_concepto.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub Add_marcai_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub Add_concepto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_concepto.Text = edita_concepto_compra.concepto
            chk_activo.Checked = edita_concepto_compra.activo            
        End If

        If borrado = True Then
            txt_concepto.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False            
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta condición?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarconcepto_compra(edita_concepto_compra)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la condición, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateconcepto_compra(edita_concepto_compra, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la condición no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la condición, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la condición, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class