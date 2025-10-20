Public Class add_ordenCompra

    Private totalOriginal As Double
    Private subTotalOriginal As Double
    Public comprobanteSeleccionado As comprobante
    Private nOC As Integer = -1
    Private idUsuario As Integer
    Private idUnico As String

    Private Sub cmd_add_item_Click(sender As Object, e As EventArgs) Handles cmd_add_item.Click
        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo
        tabla = "items_sinDescuento"
        activo = True

        agregaitem = True
        Me.Enabled = False

        Dim srch As New search(False, True, True)
        srch.ShowDialog()
        tabla = tmpTabla
        activo = tmpActivo
        agregaitem = False
        actualizarDataGrid()
    End Sub

    Private Sub add_ordenCompra_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        id = 0
        Dim oc As New ordenCompra
        edita_ordenCompra = oc
        'borro la tabla temporal
        generales_multiUsuario.Borrar_tabla_segun_usuario("tmpOC_items", usuario_logueado.id_usuario)
        'restauro los que se borraron porque no se guardaron los cambios
        activaitems("ordenesCompras_items")
        edicion = False
        closeandupdate(Me)
    End Sub

    Private Sub add_ordenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 45 Then cmd_add_item_Click(Nothing, Nothing)
    End Sub
    Private Sub add_ordenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String
        Dim cli As New cliente
        form = Me

        'Cargo el combo con todos los proveedores
        sqlstr = "SELECT p.id_proveedor AS 'id_proveedor', p.razon_social AS 'razon_social' FROM proveedores AS p WHERE p.activo = '1' ORDER BY p.razon_social ASC"
        cargar_combo(cmb_proveedor, sqlstr, basedb, "razon_social", "id_proveedor")

        RemoveHandler Me.txt_subTotal.TextChanged, New EventHandler(AddressOf Me.txt_subTotal_TextChanged)
        RemoveHandler Me.txt_impuestos.TextChanged, New EventHandler(AddressOf Me.txt_impuestos_TextChanged)

        If edicion Or borrado Then
            'cargo fecha de la orden de compra
            'cargo cliente de la orden de compra
            'cargo items
            'cargo total
            'inhabilito carga secuencial

            lbl_fechaCarga.Text = DateTime.Parse(edita_ordenCompra.fecha_carga)
            dtp_fechaComprobante.Value = DateTime.Parse(edita_ordenCompra.fecha_comprobante)

            Dim p As New proveedor
            p = info_proveedor(edita_ordenCompra.id_proveedor)

            cmb_proveedor.SelectedValue = edita_ordenCompra.id_proveedor

            actualizarDataGrid()

            txt_subTotal.Text = edita_ordenCompra.subtotal
            txt_impuestos.Text = edita_ordenCompra.iva
            txt_total.Text = edita_ordenCompra.total
            txt_totalO.Text = txt_total.Text
            txt_nota.Text = edita_ordenCompra.notas
            chk_secuencia.Enabled = False
            subTotalOriginal = txt_subTotal.Text

            lbl_nOrdenCompra.Text = edita_ordenCompra.id_ordenCompra
            lbl_ordenCompra.Visible = True
            lbl_nOrdenCompra.Visible = True
            dg_viewOC.ContextMenuStrip = cms_enviado
        Else
            lbl_fechaCarga.Text = Hoy()
            dtp_fechaComprobante.Value = Hoy_DateFormat()
            txt_total.Text = "0,00"
            txt_subTotal.Text = "0,00"
            txt_impuestos.Text = "0,00"
            txt_totalO.Text = txt_total.Text
        End If

        AddHandler Me.txt_subTotal.TextChanged, New EventHandler(AddressOf Me.txt_subTotal_TextChanged)
        AddHandler Me.txt_impuestos.TextChanged, New EventHandler(AddressOf Me.txt_impuestos_TextChanged)

        If dg_viewOC.Rows.Count > 0 Then
            cmd_ok.Enabled = True
        Else
            cmd_ok.Enabled = False
        End If

        If edita_ordenCompra.id_ordenCompra <> 0 Or borrado = True Then
            pic_searchProveedor.Enabled = False
            dg_viewOC.Enabled = False
            txt_subTotal.Enabled = False
            txt_impuestos.Enabled = False
            txt_total.Enabled = False
            txt_nota.Enabled = False
            cmd_add_item.Enabled = False
            cmd_ok.Enabled = False
        End If

        If borrado = True Then
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta orden de compra?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If borrarOrdenCompra(edita_ordenCompra) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la orden de compra, ¿desea intetar desactivarla para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateOrdenCompra(edita_ordenCompra, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la orden de compra no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la orden de compra, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la orden de compra.")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
        'AddHandler Me.txt_markup.TextChanged, New EventHandler(AddressOf Me.txt_markup_TextChanged)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim ultimaOC As ordenCompra = Nothing

        If cmb_proveedor.Text = "Seleccione un cliente" Or cmb_proveedor.Text = "" Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio")
            Exit Sub
        ElseIf dg_viewOC.Rows.Count = 0 Then
            MsgBox("No hay items cargados")
            Exit Sub
        End If

        Dim oc As New ordenCompra

        With oc
            .id_proveedor = cmb_proveedor.SelectedValue
            .fecha_carga = lbl_fechaCarga.Text
            .fecha_comprobante = dtp_fechaComprobante.Value.Date
            If lbl_fechaRecepcion.Text <> "%fecha_recepcion%" Then .fecha_recepcion = lbl_fechaRecepcion.Text
            .subtotal = txt_subTotal.Text
            .iva = txt_impuestos.Text
            .total = txt_total.Text
            .notas = txt_nota.Text
            .activo = True
        End With

        If edicion = True Then
            'actualizar proveedor
            oc.id_ordenCompra = edita_ordenCompra.id_ordenCompra
            ultimaOC = oc
            If updateOrdenCompra(oc) = False Then
                MsgBox("Hubo un problema al actualizar la orden de compra.", vbExclamation)
                closeandupdate(Me)
            End If
            'actualizar orde de compra (items)            
            'actualizo, agrego y borro los items de la orden de compra
            guardarOrdenCompra(edita_ordenCompra.id_ordenCompra)
            generales_multiUsuario.Borrar_tabla_segun_usuario("tmpOC_items", usuario_logueado.id_usuario)
        Else
            'Agrego la orden de compra
            If addOrdenCompra(oc) Then
                ultimaOC = info_ordenCompra()
                'Agrego los items a la orden de compra
                If Not guardarOrdenCompra() Then
                    MsgBox("Hubo un problema al agregar la orden de compra.", vbExclamation)
                    generales_multiUsuario.Borrar_tabla_segun_usuario("tmpOC_items", usuario_logueado.id_usuario)
                    closeandupdate(Me)
                Else
                    generales_multiUsuario.Borrar_tabla_segun_usuario("tmpOC_items", usuario_logueado.id_usuario)
                End If
            Else
                MsgBox("Hubo un problema al agregar la orden de compra.", vbExclamation)
                generales_multiUsuario.Borrar_tabla_segun_usuario("tmpOC_items", usuario_logueado.id_usuario)
                closeandupdate(Me)
            End If
            edicion = True
            edita_ordenCompra = ultimaOC
        End If

        'oc_a_ocTmp(edita_ordenCompra.id_ordenCompra)

        If chk_secuencia.Checked = True Then
            edicion = False
            actualizarDataGrid()
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub dg_view_proveedor_DoubleClick(sender As Object, e As EventArgs) Handles dg_viewOC.DoubleClick
        updateform()
    End Sub

    Private Sub pic_searchProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchProveedor.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_proveedor_default
        updateform(id.ToString, cmb_proveedor)
    End Sub

    Private Sub dg_view_DoubleClick(sender As Object, e As EventArgs) Handles dg_viewOC.DoubleClick
        Dim seleccionado As String
        'Obtengo el ID del item
        seleccionado = dg_viewOC.CurrentRow.Cells(0).Value.ToString()
        seleccionado = Microsoft.VisualBasic.Right(seleccionado, (seleccionado.Length - InStr(seleccionado, "-")))

        edita_item = info_item(seleccionado)

        'Obtengo el ID interno de la tabla tmpOC_items
        seleccionado = dg_viewOC.CurrentRow.Cells(0).Value.ToString
        edita_item.id_item_temporal = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        Dim frm_infoAgregaItem As New infoagregaitem(False, True, True, idUsuario, idUnico)
        frm_infoAgregaItem.ShowDialog()

        Dim i As New item
        edita_item = i

        updatePreciosOC(dg_viewOC, txt_subTotal, txt_impuestos, txt_total, txt_totalO)
        subTotalOriginal = txt_subTotal.Text
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        dg_view_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        If dg_viewOC.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String
        Dim id_tmpOCItem_seleccionado As String
        seleccionado = dg_viewOC.CurrentRow.Cells(0).Value.ToString()

        'Obtengo el ID interno de la tabla tmpOC_items
        id_tmpOCItem_seleccionado = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        borraritemCargadoOC(id_tmpOCItem_seleccionado)

        'Si se borró algún descuento recalcula los descuentos 
        'updateDescuentos()

        updatePreciosOC(dg_viewOC, txt_subTotal, txt_impuestos, txt_total, txt_totalO)
        subTotalOriginal = txt_subTotal.Text
        'resaltarcolumna(dg_view, 4, Color.Red)
    End Sub

    Private Sub txt_subTotal_TextChanged(sender As Object, e As EventArgs) Handles txt_subTotal.TextChanged
        txt_impuestos.Text = Math.Round(txt_subTotal.Text * 0.21, 2)
    End Sub

    Private Sub txt_impuestos_TextChanged(sender As Object, e As EventArgs) Handles txt_impuestos.TextChanged
        Dim subtotal As Double
        Dim iva As Double

        Double.TryParse(txt_subTotal.Text, subtotal)
        Double.TryParse(txt_impuestos.Text, iva)
        txt_total.Text = subtotal + iva
    End Sub

    Private Sub dg_view_MouseDown(sender As Object, e As MouseEventArgs) Handles dg_viewOC.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.dg_viewOC
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
                Me.cms_general.Visible = True
            End With
        End If
    End Sub
    Private Sub updateAndCheck()
        subTotalOriginal = txt_subTotal.Text
        If dg_viewOC.Rows.Count > 0 Then
            cmd_ok.Enabled = True
        Else
            cmd_ok.Enabled = False
        End If
    End Sub

    Private Sub cmb_comprobante_KeyPress(sender As Object, e As KeyPressEventArgs)
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_proveedor.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub actualizarDataGrid()
        Dim sqlstr As String

        sqlstr = "SELECT CONCAT(ti.id_tmpOCItem, '-', ti.id_item) AS 'ID', ti.id_OCItem AS 'id_OCItem', " &
                    "CASE WHEN i.id_item IS NULL THEN ti.descript ELSE i.descript END AS 'Producto', " &
                    "ti.cantidad AS 'Cant.', ti.precio AS 'Precio', " &
                    "ti.cantidad_recibida AS 'Cantidad Recibida' " &
                   "FROM tmpOC_items AS ti " &
                   "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                   "WHERE ti.activo = '1' AND (i.esMarkup = '0' OR ti.id_item IS NULL) " &
                   "ORDER BY id ASC"
        cargar_datagrid(dg_viewOC, sqlstr, basedb)
        updatePreciosOC(dg_viewOC, txt_subTotal, txt_impuestos, txt_total, txt_totalO)
        updateAndCheck()
    End Sub

    Private Sub ModificarArtículoRecibidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarArtículoRecibidoToolStripMenuItem.Click
        Dim seleccionado As String
        Dim sqlstr As String
        Dim tmpTabla As String
        Dim tmpActivo As Boolean
        Dim id_item As Integer
        Dim id_item_tmp As Integer

        'Obtengo el ID interno de la tabla tmpOC_items
        seleccionado = dg_viewOC.CurrentRow.Cells(0).Value.ToString
        id_item_tmp = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        tmpTabla = tabla
        tmpActivo = activo
        tabla = "items_sinDescuento"
        activo = True

        Me.Enabled = False
        Dim srch As New search(False, True, False)
        srch.ShowDialog()
        id_item = id

        sqlstr = "UPDATE tmpOC_items SET id_item_recibido = '" + id_item.ToString + "' WHERE id_tmpOCItem = '" + id_item_tmp.ToString + "'"
        ejecutarSQL(sqlstr)

        actualizarDataGrid()
    End Sub

    Private Sub ModificarCantidadRecibidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarCantidadRecibidaToolStripMenuItem.Click
        Dim seleccionado As String
        Dim sqlstr As String
        Dim cantidad_recibida As Integer

        'Obtengo el ID del item
        seleccionado = dg_viewOC.CurrentRow.Cells(0).Value.ToString()
        seleccionado = Microsoft.VisualBasic.Right(seleccionado, (seleccionado.Length - InStr(seleccionado, "-")))

        edita_item = info_item(seleccionado)

        'Obtengo el ID interno de la tabla tmpOC_items
        seleccionado = dg_viewOC.CurrentRow.Cells(0).Value.ToString
        edita_item.id_item_temporal = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        Dim agregaItem As New infoagregaitem(False, True, False, idUsuario, idUnico)
        agregaItem.ShowDialog()
        cantidad_recibida = agregaItem.cant

        sqlstr = "UPDATE tmpproduccion_items SET cantidad_recibida = '" + cantidad_recibida.ToString + "' WHERE id_tmpProduccionItem = '" + edita_item.id_item_temporal.ToString + "'"
        ejecutarSQL(sqlstr)

        actualizarDataGrid()
    End Sub
End Class