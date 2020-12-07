Public Class add_ajuste_stock

    Private Sub add_ajuste_stock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub add_ajuste_stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        'Cargo todas los items
        cargar_combo(cmb_items, "SELECT id_item, descript FROM items ORDER BY item ASC", basedb, "descript", "id_item")
        cmb_items.Text = "Seleccione un item..."
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Dispose()
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim _as As New ajusteStock

        If cmb_items.Text = "Seleccione un item..." Then
            MsgBox("Debe seleccionar un item.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
            If txt_cantidad.Text = "" Then
                MsgBox("Debe escribir una cantidad a ajustar.", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            End If
        End If

        With _as
            .fecha = Hoy()
            .id_item = cmb_items.SelectedValue
            .cantidad = txt_cantidad.Text
            .notas = txt_notas.Text
        End With

        If Not add_ajusteStock(_as) Then
            MsgBox("Hubo un error al ingresar el ajuste de stock.", vbExclamation + vbOKOnly, "Centrex")
        End If
        closeandupdate(Me)
    End Sub

    Private Sub pic_search_item_Click(sender As Object, e As EventArgs) Handles pic_search_item.DoubleClick
        Dim tmp As String
        tmp = tabla
        'tabla = "items_sinDescuento"
        tabla = "items_registros_stock"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        'cmb_items.SelectedIndex = cmb_items.FindString(info_item(id).descript)
        cmb_items.SelectedValue = id
        id = 0
    End Sub

    Private Sub txt_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If esNumero(e, True) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class