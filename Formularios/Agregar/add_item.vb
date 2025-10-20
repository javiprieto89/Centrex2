Public Class add_item
    Private Sub add_item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        chk_activo.Checked = True
        txt_factor.Text = 1

        cargar_combo(cmb_cat, "SELECT id_tipo, tipo FROM tipos_items WHERE activo = '1' ORDER BY tipo ASC", basedb, "tipo", "id_tipo")
        cargar_combo(cmb_marca, "SELECT id_marca, marca FROM marcas_items WHERE activo = '1' ORDER BY marca ASC", basedb, "marca", "id_marca")
        cargar_combo(cmb_proveedor, "SELECT id_proveedor, razon_social FROM proveedores WHERE activo = '1' ORDER BY razon_social ASC", basedb, "razon_social", "id_proveedor")
        If Not edicion And Not borrado Then
            cargar_combo(cmb_iva, "SELECT id_impuesto, nombre FROM impuestos WHERE activo = '1' AND nombre LIKE '%iva%' ORDER BY nombre DESC", basedb, "nombre", "id_impuesto")
        Else
            cmb_iva.Text = "Archivos\Impuestos\Items-Impuestos para modificar"
        End If


        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_item.Text = edita_item.item
            txt_desc.Text = edita_item.descript
            txt_cantidad.Text = edita_item.cantidad
            txt_costo.Text = edita_item.costo
            txt_prclista.Text = edita_item.precio_lista
            txt_factor.Text = edita_item.factor

            cmb_cat.SelectedValue = CByte(edita_item.id_tipo)
            cmb_marca.SelectedValue = CByte(edita_item.id_marca)
            cmb_proveedor.SelectedValue = CByte(edita_item.id_proveedor)
            cmb_iva.Enabled = False

            chk_activo.Checked = edita_item.activo
            chk_descuento.Checked = edita_item.esDescuento
        End If

        If borrado = True Then
            txt_item.Enabled = False
            txt_desc.Enabled = False
            txt_costo.Enabled = False
            txt_prclista.Enabled = False
            txt_factor.Enabled = False
            txt_cantidad.Enabled = False
            cmb_cat.Enabled = False
            cmb_marca.Enabled = False
            cmb_proveedor.Enabled = False
            chk_activo.Enabled = False
            chk_descuento.Enabled = False
            psearch_marca.Enabled = False
            psearch_proveedor.Enabled = False
            psearch_tipo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este item?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borraritem(edita_item)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del item, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateitem(edita_item) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el item no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el item, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el item, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        ElseIf edicion = False Then
            cmb_cat.Text = "Seleccione una categoría"
            'cmb_marca.Text = "Seleccione una marca"
            'cmb_proveedor.Text = "Seleccione un proveedor"
            cmb_marca.SelectedValue = 1
            cmb_proveedor.SelectedValue = 1
        End If
    End Sub

    Private Sub psearch_marca_Click(sender As Object, e As EventArgs) Handles psearch_marca.Click
        Dim tmp As String
        tmp = tabla
        tabla = "marcas_items"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_marca.SelectedIndex = cmb_marca.FindString(info_marcai(id).marca)
        'cmb_marca.SelectedIndex = id
        id = 0
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
        'cmb_proveedor.SelectedIndex = id
        id = 0
    End Sub

    Private Sub psearch_tipo_Click(sender As Object, e As EventArgs) Handles psearch_tipo.Click
        Dim tmp As String
        tmp = tabla
        tabla = "tipos_items"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_cat.SelectedIndex = cmb_cat.FindString(InfoTipoItem(id).tipo)
        'cmb_cat.SelectedIndex = id
        id = 0
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_item.Text = "" Then
            MsgBox("El campo 'Código' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_desc.Text = "" Then
            MsgBox("El campo 'Producto' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_costo.Text = "" And chk_descuento.Checked = False Then
            MsgBox("El campo 'Costo' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_prclista.Text = "" And chk_descuento.Checked = False Then
            MsgBox("El campo 'Precio de lista' es obligatorio y está vacio")
            Exit Sub
        ElseIf lbl_factor.Text = "" Then
            MsgBox("El campo 'Factor' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_cat.Text = "Seleccione una categoría" And chk_descuento.Checked = False Then
            MsgBox("Debe seleccionar una categoría")
            Exit Sub
        ElseIf cmb_marca.Text = "Seleccione una marca" And chk_descuento.Checked = False Then
            MsgBox("Debe seleccionar una marca")
            Exit Sub
        ElseIf cmb_proveedor.Text = "Seleccione un proveedor" And chk_descuento.Enabled = False Then
            MsgBox("Debe seleccionar un proveedor")
            Exit Sub
        End If

        Dim tmp As New ItemEntity

        With tmp
            If chk_descuento.Checked Then
                .costo = 0
                .precio_lista = 0
                .id_tipo = 2 '2 = Descuentos
                .IdMarca = 2 '2 = Centrex
                .id_proveedor = 2 '2 = Centrex            
            Else
                .costo = txt_costo.Text
                .precio_lista = txt_prclista.Text
                .id_tipo = CInt(cmb_cat.SelectedItem(0).ToString)
                .IdMarca = CInt(cmb_marca.SelectedItem(0).ToString)
                .id_proveedor = CInt(cmb_proveedor.SelectedItem(0).ToString)
            End If
            .item = txt_item.Text
            .descript = txt_desc.Text
            .cantidad = txt_cantidad.Text
            .factor = txt_factor.Text
            .activo = chk_activo.Checked
            .esDescuento = chk_descuento.Checked
        End With

        If edicion = True Then
            tmp.id_item = edita_item.id_item
            If updateitem(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el item, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            additem(tmp)
            Dim i As New item
            Dim ii As New itemImpuesto
            i = infoItem_lastItem()
            With ii
                .id_item = i.id_item
                .id_impuesto = cmb_iva.SelectedValue
                .activo = True
            End With
            addItemIVA(ii)
        End If

        If chk_secuencia.Checked = True Then
            txt_item.Text = ""
            txt_desc.Text = ""
            txt_cantidad.Text = "1000000"
            txt_costo.Text = ""
            txt_prclista.Text = ""
            txt_factor.Text = 1
            cargar_combo(cmb_cat, "SELECT id_tipo, tipo FROM tipos_items ORDER BY tipo ASC", basedb, "tipo", "id_tipo")
            cmb_cat.Text = "Seleccione una categoría"
            cargar_combo(cmb_marca, "SELECT id_marca, marca FROM marcas_items ORDER BY marca ASC", basedb, "marca", "id_marca")
            cmb_marca.SelectedValue = id_marca_default
            cargar_combo(cmb_proveedor, "SELECT id_proveedor, razon_social FROM proveedores ORDER BY razon_social ASC", basedb, "razon_social", "id_proveedor")
            cmb_proveedor.SelectedValue = id_proveedor_default
            chk_activo.Checked = True
            chk_descuento.Checked = False
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
        'add_item_FormClosed(Nothing, Nothing)
    End Sub

    Private Sub cmb_cat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_cat.SelectedIndexChanged
        'If LCase(cmb_cat.SelectedItem(1).ToString) = "rosca" Then
        '    cmb_rosca.Enabled = True
        'psearch_rosca.Enabled = True
        'cargar_combo(cmb_rosca, "SELECT i.id_item AS 'ID', i.item AS 'Código' FROM items AS i " & _
        '           "LEFT JOIN tipos_items AS ti ON i.id_tipo = ti.id_tipo " & _
        '            "WHERE ti.tipo = 'rosca' ", basedb, "Item", "ID")
        'Else
        'cmb_rosca.Enabled = False
        'psearch_rosca.Enabled = False
        'cmb_rosca.Items.Clear()
        'End If
    End Sub

    Private Sub txt_costo_LostFocus(sender As Object, e As EventArgs) Handles txt_costo.LostFocus
        If Not txt_costo.Text = vbNullString And chk_descuento.Checked = False Then
            txt_prclista.Text = CDbl(txt_costo.Text) * CDbl(txt_factor.Text)
        End If
    End Sub

    Private Sub txt_factor_LostFocus(sender As Object, e As EventArgs) Handles txt_factor.LostFocus
        If Not txt_costo.Text = vbNullString And chk_descuento.Checked = False Then
            txt_prclista.Text = CDbl(txt_costo.Text) * CDbl(txt_factor.Text)
        End If
    End Sub

    Private Sub chk_descuento_CheckedChanged(sender As Object, e As EventArgs) Handles chk_descuento.CheckedChanged
        If chk_descuento.Checked = True Then
            cmb_cat.SelectedValue = 2 '2 = Descuentos
            cmb_marca.SelectedValue = 2 '2 = Centrex
            cmb_proveedor.SelectedValue = 2 '2 = Centrex
            'txt_cantidad.Text = 1000000

            txt_costo.Enabled = False
            txt_prclista.Enabled = False
            cmb_cat.Enabled = False
            cmb_marca.Enabled = False
            cmb_proveedor.Enabled = False
            'txt_cantidad.Enabled = True
        Else
            txt_costo.Enabled = True
            txt_prclista.Enabled = True
            cmb_cat.Enabled = True
            cmb_marca.Enabled = True
            cmb_proveedor.Enabled = True
            'txt_cantidad.Enabled = False
        End If
    End Sub

    Private Sub pic_search_iva_Click(sender As Object, e As EventArgs) Handles pic_search_iva.DoubleClick
        Dim tmp As String
        tmp = tabla
        tabla = "itemIVA"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        'cmb_impuestos.SelectedIndex = cmb_impuestos.FindString(info_impuesto(id).nombre)
        cmb_iva.SelectedValue = id
        id = 0
    End Sub

    Private Sub cmb_cat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cat.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_marca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_marca.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_proveedor.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_iva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_iva.KeyPress
        'e.KeyChar = ""
    End Sub
End Class