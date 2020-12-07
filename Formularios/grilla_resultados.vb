Public Class grilla_resultados

    Private Sub grilla_resultados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_combo(cmb_consultas, "SELECT id_consulta, nombre FROM consultas_personalizadas ORDER BY nombre ASC", basedb, "nombre", "id_consulta")
        cmb_consultas.SelectedValue = 0
        cmb_consultas.Text = "Elija una consulta..."
    End Sub

    Private Sub cmd_ejecutar_Click(sender As Object, e As EventArgs) Handles cmd_ejecutar.Click
        Dim c As New consultaP
        If cmb_consultas.SelectedValue = 0 Then
            MsgBox("Debe elegir una consulta para ejecutar", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        c = info_consulta(cmb_consultas.SelectedValue)

        cargar_datagrid(dg_view_resultados, c.consulta, basedb)
    End Sub
End Class