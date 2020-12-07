Public Class edita_precios
    Private Sub edita_precios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String
        sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio' " _
                    + "FROM items AS i " _
                    + "WHERE i.esDescuento = '0' AND i.esMarkup = '0' AND i.activo = '1'"
        cargar_datagrid(dg_view, sqlstr, basedb)
        dg_view.Columns(0).ReadOnly = True
        dg_view.Columns(1).ReadOnly = True
        dg_view.Columns(2).ReadOnly = True
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If MsgBox("¿Está seguro de que desea aplicar la actualización de precios?", vbYesNo + vbQuestion, "Centrex") = MsgBoxResult.Yes Then
            Dim i As Integer

            For i = 0 To dg_view.Rows.Count - 1
                If Not updatePrecios_items(dg_view.Rows(i).Cells(0).Value.ToString, dg_view.Rows(i).Cells(3).Value.ToString) Then
                    MsgBox("Ha ocurrido un error al actualizar los precios", vbOKOnly + vbExclamation, "Centrex")
                    Exit Sub
                End If
            Next
            MsgBox("Todos los precios se han actualizado correctamente", vbOKOnly + vbInformation, "Centrex")
        Else
            MsgBox("Todos los cambios realizados se descartarán", vbOKOnly + vbInformation, "Centrex")
        End If
        closeandupdate(Me)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub
End Class