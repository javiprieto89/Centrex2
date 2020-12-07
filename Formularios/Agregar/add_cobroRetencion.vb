Public Class add_cobroRetencion
    Private formViejo As Form

    Private Sub add_cobroRetencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_combo(cmb_retencion, "SELECT id_impuesto, nombre FROM impuestos WHERE esRetencion = '1' ORDER BY nombre ASC", basedb, "nombre", "id_impuesto")

        If Not edicion And Not borrado Then
            cmb_retencion.SelectedItem = Nothing
            cmb_retencion.Text = "Seleccione una retención..."
        Else
            cmb_retencion.SelectedValue = edita_cobroRetencion.id_retencion

            txt_importe.Text = edita_cobroRetencion.total
            txt_notas.Text = edita_cobroRetencion.notas
        End If

        If borrado Then
            cmb_retencion.Enabled = False
            txt_importe.Enabled = False
            txt_notas.Enabled = False
            cmd_ok.Enabled = False
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta retención?", vbYesNo + vbQuestion, "Centrex") = MsgBoxResult.Yes Then
                If borrarTmptransferencia(edita_cobroRetencion.id_retencion) = False Then
                    MsgBox("No se ha podido borrar la retención.")
                End If
            End If
            closeandupdate(Me)
        End If

        formViejo = form
        form = Me
    End Sub

    Private Sub txt_importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_importe.KeyPress
        e.Handled = valida(e.KeyChar, 5)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim cb As New cobroRetencion

        If cmb_retencion.Text = "Seleccione una retencion..." Then
            MsgBox("Debe seleccionar una retención", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_importe.Text = "" Then
            MsgBox("Debe ingresar un importe", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        With cb
            .id_impuesto = cmb_retencion.SelectedValue
            .total = txt_importe.Text
            .notas = txt_notas.Text
        End With

        If edicion Then
            cb.id_retencion = edita_cobroRetencion.id_retencion
            If Not updateTmpCobroRetencion(cb) Then
                MsgBox("Ocurrió un error al actualizar la retención.", vbExclamation + vbOKOnly, "Centrex")
            End If
        Else
            cb.id_retencion = addTmpCobroRetencion(cb)
            If cb.id_retencion = False Then
                MsgBox("Ocurrió un error al agregar la retencion", vbExclamation + vbOKOnly, "Centrex")
            End If
        End If

        closeandupdate(Me)
    End Sub

    Private Sub psearch_retencion_Click(sender As Object, e As EventArgs) Handles psearch_retencion.Click
        Dim tmp As String
        tmp = tabla
        tabla = "retenciones"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_retencion.SelectedValue = id
    End Sub

    Private Sub add_cobroRetencion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        form = formViejo
        closeandupdate(Me)
    End Sub

    Private Sub cmb_retencion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_retencion.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmd_agregarImpuesto_Click(sender As Object, e As EventArgs) Handles cmd_agregarImpuesto.Click
        Dim frmImpuesto As New add_impuesto(True, False)
        Dim i As Integer
        frmImpuesto.ShowDialog()
        i = frmImpuesto.id_impuesto

        cargar_combo(cmb_retencion, "SELECT id_impuesto, nombre FROM impuestos WHERE esRetencion = '1' ORDER BY nombre ASC", basedb, "nombre", "id_impuesto")
        cmb_retencion.SelectedValue = i
    End Sub
End Class