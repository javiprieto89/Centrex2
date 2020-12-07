Public Class add_stock
    Public ingreso_guardado As Boolean

    Private Sub add_stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me
        cargar_combo(cmb_proveedor, "SELECT id_proveedor, razon_social FROM proveedores ORDER BY razon_social ASC", basedb, "razon_social", "id_proveedor")
        If edicion Then
            txt_fecha.Text = DateTime.Parse(edita_registro_stock.fecha)
            lbl_fecha_ingreso.Text = DateTime.Parse(edita_registro_stock.fecha_ingreso)
            txt_factura.Text = edita_registro_stock.factura
            cmb_proveedor.SelectedValue = CByte(edita_registro_stock.id_proveedor)
            If Not editaStock Then
                txt_fecha.Enabled = False
                txt_factura.Enabled = False
                txt_notas.Enabled = False
                cmb_proveedor.Enabled = False
                psearch_proveedor.Enabled = False
                cmd_additem.Enabled = False
            End If
        Else
            txt_fecha.Text = Format(DateTime.Now, "dd/MM/yyyy")
            lbl_fecha_ingreso.Text = Format(DateTime.Now, "dd/MM/yyyy")
            cmb_proveedor.SelectedValue = CByte(20)
            borrartbl("tmpregistros_stock")
        End If
        updateform()
    End Sub

    Private Sub add_stock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ingreso_guardado Then Exit Sub
        If edicion = False Then
            If MsgBox("Eliminará el ingreso, por lo cual no se contabilizará. ¿Deseá continuar?", vbYesNo + vbQuestion) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub updateform()
        Dim sqlstr As String
        If edicion And editaStock Then
            sqlstr = "SELECT rs.id_registro AS 'ID', i.item AS 'Código', i.descript AS 'Producto', rs.factura AS 'Factura', rs.fecha AS 'Fecha', rs.cantidad AS 'Cantidad', rs.costo AS 'Costo', " &
                        "rs.precio_lista AS 'Precio de lista', rs.factor AS 'Factor', rs.nota AS 'Notas' " &
                        "FROM registros_stock AS rs " &
                        "LEFT JOIN items AS i ON rs.id_item = i.id_item " &
                        "WHERE rs.id_ingreso = '" + edita_registro_stock.id_ingreso.ToString + "' " &
                        "ORDER BY rs.id_ingreso ASC"
        Else
            sqlstr = "SELECT rstmp.id_registrotmp AS 'ID', i.item AS 'Código', i.descript AS 'Producto', rstmp.factura AS 'Factura', rstmp.fecha AS 'Fecha', rstmp.cantidad AS 'Cantidad', rstmp.costo AS 'Costo', " &
                    "rstmp.precio_lista AS 'Precio de lista', rstmp.factor AS 'Factor', rstmp.nota AS 'Notas' " &
                    "FROM tmpregistros_stock AS rstmp " &
                    "LEFT JOIN items AS i ON rstmp.id_item = i.id_item " &
                    "WHERE rstmp.activo = '1' " &
                    "ORDER BY rstmp.id_ingreso ASC"
        End If


        cargar_datagrid(dg_view, sqlstr, basedb)
        'resaltarColumna(dg_view, 7, Color.Red)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If edicion = False Then
            If MsgBox("Se modificarán todos los items anteriormente cargados. ¿Está seguro de que desea continuar?", vbYesNo + vbQuestion, "Centrex") = vbYes Then
                addstock()
                borrartbl("tmpregistros_stock")
                MsgBox("Se actualizaron los items correctamente", vbOK, "Centrex")
                ingreso_guardado = True
            Else
                'MsgBox("Operación cancelada.", vbOKOnly + vbInformation, "Centrex")
                Exit Sub
            End If
        End If

        closeandupdate(Me)
    End Sub
    Private Sub cmd_additem_Click(sender As Object, e As EventArgs) Handles cmd_additem.Click
        Me.Enabled = False
        search.ShowDialog()

        If id = 0 Then Exit Sub
        Dim frm As New infoagregarstock(cmb_proveedor.SelectedValue)
        frm.ShowDialog()
        'infoagregarstock.ShowDialog()
        updateform()
        'If secuencia Then cmd_additem_Click(Nothing, Nothing)
    End Sub

    Private Sub cmd_cancel_Click(sender As Object, e As EventArgs) Handles cmd_cancel.Click
        If edicion = False Then
            If MsgBox("Eliminará el ingreso, por lo cual no se contabilizará. ¿Deseá continuar?", vbYesNo + vbQuestion) = vbYes Then
                ingreso_guardado = True
                closeandupdate(Me)
            End If
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub psearch_proveedor_Click(sender As Object, e As EventArgs) Handles psearch_proveedor.Click
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_proveedor.SelectedIndex = cmb_proveedor.FindString(info_proveedor(id).razon_social)
        id = 0
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        dg_view_CellMouseDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub lsv_items_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If edicion = True Then
                ContextMenuStrip1.Enabled = False
            End If
        End If
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        'borrar item de tmp
        If dg_view.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        If MsgBox("¿Está seguro de borrar el item: " + info_item(info_registro_stocktmp(seleccionado).id_item).item + "?", vbYesNo + vbQuestion) = vbYes Then
            borraritemregistrostocktmp(info_registro_stocktmp(seleccionado))
        End If
        updateform()
    End Sub

    Private Sub lbl_fecha_ingreso_MouseEnter(sender As Object, e As EventArgs) Handles lbl_fecha_ingreso.MouseEnter
        lbl_tooltip.Visible = True
    End Sub

    Private Sub lbl_fecha_ingreso_MouseLeave(sender As Object, e As EventArgs) Handles lbl_fecha_ingreso.MouseLeave
        lbl_tooltip.Visible = False
    End Sub

    Private Sub dg_view_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_view.CellMouseDoubleClick
        If edicion And Not editaStock Then Exit Sub
        If dg_view.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString

        edicion_item_registro_stock = True
        edita_item_registro_stock = info_registro_stock(seleccionado)
        infoagregarstock.ShowDialog()
        updateform()
        edicion_item_registro_stock = False
    End Sub

    Private Sub cmb_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_proveedor.KeyPress
        'e.KeyChar = ""
    End Sub
End Class