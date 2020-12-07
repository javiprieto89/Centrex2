Public Class add_consulta
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_nombre.Text = "" Then
            MsgBox("El campo 'Nombre de la consulta' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_consulta.Text = "" Then
            MsgBox("El campo 'Consulta SQL' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New consultaP

        tmp.nombre = txt_nombre.Text
        tmp.consulta = txt_consulta.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_consulta = edita_consulta.id_consulta
            If updateConsulta(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la consulta, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addConsulta(tmp)
        End If

        If chk_secuencia.Checked = True Then
            txt_nombre.Text = ""
            txt_consulta.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_consulta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_nombre.Text = edita_consulta.nombre
            txt_consulta.Text = edita_consulta.consulta
            chk_activo.Checked = edita_consulta.activo
        End If

        If borrado = True Then
            txt_nombre.Enabled = False
            txt_consulta.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta consulta?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarConsulta(edita_consulta)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la consulta, ¿desea intectar desactivarla para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateConsulta(edita_consulta, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la consulta no se borró definitivamente." + Chr(13) + _
                                "Esto posiblemente se deba a que la consulta, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la consulta, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub
End Class