Public Class frm_ultimo_comprobante
    Private Sub frm_ultimo_comprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_combo(cmb_comprobante, "SELECT id_comprobante, comprobante FROM comprobantes WHERE activo = '1' AND esElectronica = '1' ORDER BY comprobante ASC", basedb, "comprobante", "id_comprobante")
        cmb_comprobante.Text = "Seleccione un comprobante..."
    End Sub

    Private Sub cmb_comprobante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_comprobante.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_comprobante.Text = "Seleccione un comprobante..." Then
            MsgBox("Debe seleccionar un comprobante para ejecutar la consulta", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim c As New comprobante
        Dim ultimoComprobante As Integer
        c = info_comprobante(cmb_comprobante.SelectedValue)

        ultimoComprobante = consultaUltimoComprobante(c.puntoVenta, c.id_tipoComprobante, c.testing)

        If ultimoComprobante = -1 Then
            MsgBox("Hubo un error al consultar el último número del comprobante.", vbExclamation + vbOKOnly, "Centrex")
        Else
            MsgBox("El último número de comprobante para el documento: " + c.comprobante + " con el punto de venta: " + c.puntoVenta +
                " es: " + ultimoComprobante.ToString, vbInformation + vbOKOnly, "Centrex")
        End If
    End Sub

    Private Sub frm_ultimo_comprobante_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub
End Class