Public Class info_fc
    Private Sub info_fc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cargar_combo(cmb_tipoComprobante, "SELECT id_tipoComprobante, comprobante_AFIP FROM tipos_comprobantes ORDER BY comprobante_AFIP ASC", basedb, "comprobante_AFIP", "id_tipoComprobante")
        cargar_combo(cmb_Comprobante, "SELECT id_comprobante, comprobante FROM comprobantes WHERE esElectronica = 1 AND activo = 1 ORDER BY comprobante ASC", basedb, "comprobante", "id_comprobante")
        cmb_Comprobante.Text = "Seleccione un comprobante..."
    End Sub

    Private Sub cmd_consultar_Click(sender As Object, e As EventArgs) Handles cmd_consultar.Click
        Dim c As comprobante

        If cmb_Comprobante.Text = "Seleccione un comprobante..." Then
            MsgBox("Debe seleccionar un comprobante sobre el cual desesa realizar la consulta.", vbInformation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_numeroComprobante.Text = "" Then
            MsgBox("Debe ingresar un número de comprobante sobre el cual desesa realizar la consulta.", vbInformation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        c = info_comprobante(cmb_Comprobante.SelectedValue)


        Consultar_Comprobante(txt_puntoVenta.Text, c.id_tipoComprobante, txt_numeroComprobante.Text)
    End Sub

    Private Sub cmb_Comprobante_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_Comprobante.SelectionChangeCommitted
        txt_puntoVenta.Text = info_comprobante(cmb_Comprobante.SelectedValue).puntoVenta
    End Sub
End Class