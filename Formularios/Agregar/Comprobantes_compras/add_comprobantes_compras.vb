Public Class add_comprobantes_compras
    Dim id_comprobante_compra As Integer = -1
    Dim cerrarOk As Boolean = False

    Private Sub add_comprobantes_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        lbl_fechaCarga.Text = Hoy()


        form = Me

        'Cargo el combo con todos los proveedores
        sqlstr = "SELECT p.id_proveedor AS 'id_proveedor', p.razon_social AS 'razon_social' FROM proveedores AS p WHERE p.activo = '1' ORDER BY p.razon_social ASC"
        cargar_combo(cmb_proveedor, sqlstr, basedb, "razon_social", "id_proveedor")
        cmb_proveedor.Text = "Seleccione un proveedor..."
        cmb_cc.Enabled = False

        'Cargo el combo con todos los comprobantes
        sqlstr = "SELECT id_sysComprobanteCompra, comprobante FROM sysComprobantesCompras ORDER BY comprobante ASC"
        cargar_combo(cmb_tipoComprobante, sqlstr, basedb, "comprobante", "id_sysComprobanteCompra")
        cmb_tipoComprobante.Text = "Seleccione un comprobante..."

        'Cargo el combo con todas las condiciones de compra
        sqlstr = "SELECT id_condicion_compra, condicion FROM condiciones_compra ORDER BY condicion ASC"
        cargar_combo(cmb_condicionCompra, sqlstr, basedb, "condicion", "id_condicion_compra")
        cmb_condicionCompra.SelectedValue = id_condicion_compra_default
        'cmb_condicionCompra.Text = "Seleccione una condición de compra..."

        txt_tasaCambio.Enabled = False

        Me.ActiveControl = dtp_fechaComprobanteCompra

        'cmb_proveedor.SelectedValue = 3
        'cmb_proveedor_SelectionChangeCommitted(Nothing, Nothing)
        'cmb_cc.SelectedValue = 1016
        'cmb_cc_SelectionChangeCommitted(Nothing, Nothing)
        'cmb_condicionCompra.SelectedValue = 1
        'cmb_moneda.SelectedValue = 1
        'txt_puntoVenta.Text = "1"
        'txt_numeroComprobante.Text = "22"
        'txt_CAE.Text = "5454654654"
    End Sub

    Private Sub cmb_proveedor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_proveedor.SelectionChangeCommitted
        Dim sqlstr As String
        Dim p As Integer
        Dim id_ultima_cc As Integer

        p = cmb_proveedor.SelectedValue

        'Cargo los combos con todas las cuentas corrientes del proveedor
        sqlstr = "SELECT id_cc, nombre FROM cc_proveedores WHERE activo = 1 AND id_proveedor = '" + p.ToString + "' ORDER BY nombre ASC"
        cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")

        'Selecciono la última cuenta corriente que se uso del cliente
        id_ultima_cc = Ultima_CC_comprobante_compra_proveedor(p)
        If id_ultima_cc = -1 Then
            cmb_cc.Text = "Seleccione una cuenta corriente..."
        Else
            cmb_cc.SelectedValue = id_ultima_cc
            cmb_cc_SelectionChangeCommitted(Nothing, Nothing)
        End If
        cmb_cc.Enabled = True
    End Sub

    Private Sub cmb_cc_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cc.SelectionChangeCommitted
        Dim sqlstr As String
        Dim ccp As ccProveedor


        ccp = info_ccProveedor(cmb_cc.SelectedValue)

        'Cargo el combo con todas las monedas disponibles y selecciono la moneda de la cuenta corriente del proveedor seleccionado
        sqlstr = "SELECT id_moneda, moneda FROM sysMoneda ORDER BY moneda ASC"
        cargar_combo(cmb_moneda, sqlstr, basedb, "moneda", "id_moneda")
        cmb_moneda.SelectedValue = ccp.id_moneda
        cmb_moneda.Enabled = False
        If ccp.id_moneda <> ID_PESO Then
            txt_tasaCambio.Enabled = True
        Else
            txt_tasaCambio.Text = "0"
        End If
    End Sub

    Private Sub pic_proveedorProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchProveedor.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_proveedor)
    End Sub

    Private Sub pic_searchCCProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchCCProveedor.Click
        'busqueda
        Dim tmp As String
        Dim tmpProveedor As proveedor

        If cmb_proveedor.Text = "Seleccione un proveedor..." Or cmb_proveedor.SelectedValue = 0 Then Exit Sub

        tmp = tabla
        tmpProveedor = edita_proveedor
        'edita_cliente = info_cliente(cmb_proveedor.SelectedValue)
        edita_proveedor = info_proveedor(cmb_proveedor.SelectedValue)
        tabla = "cc_proveedores"
        Me.Enabled = False

        search.ShowDialog()
        tabla = tmp
        edita_proveedor = tmpProveedor

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_cc)
    End Sub

    Private Sub cmd_agregar_Click(sender As Object, e As EventArgs) Handles cmd_agregar.Click
        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo

        Select Case tbl_comprobantesCompras.SelectedTab.Name
            Case "productos"
                tabla = "items_sinDescuento"
                activo = True
            Case "impuestos"
                tabla = "impuestos"
            Case "conceptos"
                tabla = "conceptos_compra"
        End Select

        'activo = True

        'agregaitem = True
        Me.Enabled = False

        Dim frmSearch As New search(True, id_comprobante_compra)
        frmSearch.ShowDialog()
        tabla = tmpTabla
        activo = tmpActivo

        'Select Case tbl_comprobantesCompras.SelectedTab.Name
        '    Case "productos"

        '    Case "impuestos"

        '    Case "conceptos"

        'End Select
        'agregaitem = False

        update_form()
    End Sub

    Private Sub cmd_confirmar_Click(sender As Object, e As EventArgs) Handles cmd_confirmar.Click
        Dim cc As New comprobante_compra
        Dim id_cc As Integer

        If cmb_proveedor.Text = "Seleccione un proveedor..." Then
            MsgBox("Debe seleccionar un proveedor.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_cc.Text = "Seleccione una cuenta corriente..." Then
            MsgBox("Debe seleccionar una cuenta corriente.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_condicionCompra.Text = "Seleccione una condición de compra..." Then
            MsgBox("Debe seleccionar una condición de compra.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_moneda.SelectedValue <> ID_PESO And txt_tasaCambio.Text = "" Then
            MsgBox("La moneda seleccionada es extranjera, por lo cual escribir la tasa de cambio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_tipoComprobante.Text = "Seleccione un tipo de comprobante..." Then
            MsgBox("Debe seleccionar un comprobante.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        With cc
            .fecha_comprobante = dtp_fechaComprobanteCompra.Value.Date.ToShortDateString
            .id_proveedor = cmb_proveedor.SelectedValue
            .id_cc = cmb_cc.SelectedValue
            .id_condicion_compra = cmb_condicionCompra.SelectedValue
            .id_sysComprobanteCompra = cmb_tipoComprobante.SelectedValue
            .id_moneda = cmb_moneda.SelectedValue
            .tasaCambio = txt_tasaCambio.Text
            .puntoVenta = txt_puntoVenta.Text
            .numeroComprobante = txt_numeroComprobante.Text
            .cae = txt_CAE.Text
        End With

        If id_comprobante_compra = -1 Then
            id_cc = add_comprobante_compra(cc)
            If id_cc = -1 Then
                MsgBox("Hubo un error al dar de alta el comprobante, consulte con el programador.", vbCritical + vbOKOnly, "Centrex")
                Exit Sub
            End If

            id_comprobante_compra = id_cc
        Else
            cc.id_comprobanteCompra = id_comprobante_compra
            If Not update_comprobante_compra(cc) Then
                MsgBox("Ocurrió un error al actualizar el comprobante de compra, consulte con el programador.", vbCritical + vbOKOnly, "Centrex")
                Exit Sub
            End If
        End If

        dtp_fechaComprobanteCompra.Enabled = False
        cmb_proveedor.Enabled = False
        cmb_cc.Enabled = False
        cmb_condicionCompra.Enabled = False
        cmb_moneda.Enabled = False
        txt_tasaCambio.Enabled = False
        cmb_tipoComprobante.Enabled = False
        txt_puntoVenta.Enabled = False
        txt_numeroComprobante.Enabled = False
        txt_CAE.Enabled = False
        pic_searchProveedor.Enabled = False
        pic_searchCondicionCompra.Enabled = False
        pic_searchCCProveedor.Enabled = False

        tbl_comprobantesCompras.Enabled = True
        cmd_confirmar.Enabled = False
        cmd_editar.Enabled = True
        cmd_agregar.Enabled = True
        cmd_ok.Enabled = True

        update_form()
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        If MsgBox("Si sale sin guardar los cambios perderá todo lo guardado." & vbCr & "¿Desea salir?", vbQuestion + vbYesNo, "Centrex") = vbYes Then
            If id_comprobante_compra = -1 Then
                closeandupdate(Me)
                Exit Sub
            End If
            'Borrar los comprobantes de compras que no esten activos y todos los productos, impuestos y conceptos asociados a esa orden
            borrar_comprobantes_compras_activos(id_comprobante_compra)
            closeandupdate(Me)
        End If
    End Sub

    Public Sub update_form()
        Dim sqlstr As String
        Dim totalItems As Double
        Dim totalImpuestos As Double
        Dim totalConceptos As Double
        Dim totalFactura As Double

        'Actualizo el datagrid con los productos
        sqlstr = "SELECT CONCAT(cci.id_comprobanteCompraItem, '-', cci.id_item) AS 'ID', i.item AS 'Código', i.descript AS 'Producto', cci.cantidad AS 'Cantidad' " &
                    ", cci.precio AS 'Subtotal', (cci.cantidad * cci.precio) AS 'Total' " &
                    "FROM comprobantes_compras_items AS cci " &
                    "INNER JOIN items AS i ON cci.id_item = i.id_item " &
                    "WHERE cci.id_comprobanteCompra = '" + id_comprobante_compra.ToString + "' " &
                    "ORDER BY cci.id_comprobanteCompraItem ASC"
        cargar_datagrid(dg_viewItems, sqlstr, basedb)

        'Sumo el precio de todos los productos del datagrid
        For Each row As DataGridViewRow In dg_viewItems.Rows
            totalItems += row.Cells("Total").Value.ToString
        Next
        txt_totalItems.Text = totalItems.ToString

        'Actualizo el datagrid con los impuestos
        sqlstr = "SELECT CONCAT(cci.id_comprobanteCompraImpuesto, '-', cci.id_impuesto) AS 'ID', i.nombre AS 'Impuesto', cci.importe AS 'Importe' " &
                    "FROM comprobantes_compras_impuestos AS cci " &
                    "INNER JOIN impuestos AS i ON cci.id_impuesto = i.id_impuesto " &
                    "WHERE cci.id_comprobanteCompra = '" + id_comprobante_compra.ToString + "' " &
                    "ORDER BY cci.id_comprobanteCompraImpuesto ASC"
        cargar_datagrid(dg_viewImpuestos, sqlstr, basedb)

        'Sumo el precio de todos los impuestos del datagrid
        For Each row As DataGridViewRow In dg_viewImpuestos.Rows
            totalImpuestos += row.Cells("Importe").Value.ToString
        Next
        txt_totalImpuestos.Text = totalImpuestos.ToString

        'Actualizo el datagrid con los conceptos de compra
        sqlstr = "SELECT CONCAT(ccc.id_comprobanteCompraConcepto, '-', ccc.id_concepto_compra) AS 'ID', cc.concepto AS 'Concepto', " &
                    "ccc.subtotal AS 'Subtotal', ccc.iva AS 'I.V.A.', ccc.total AS 'Total' " &
                    "FROM comprobantes_compras_conceptos AS ccc " &
                    "INNER JOIN conceptos_compra AS cc ON ccc.id_concepto_compra = cc.id_concepto_compra " &
                    "WHERE ccc.id_comprobanteCompra = '" + id_comprobante_compra.ToString + "' " &
                    "ORDER BY ccc.id_comprobanteCompraConcepto ASC"
        cargar_datagrid(dg_viewConceptos, sqlstr, basedb)

        'Sumo el precio de todos los conceptos de compra del datagrid
        For Each row As DataGridViewRow In dg_viewConceptos.Rows
            totalConceptos += row.Cells("Total").Value.ToString
        Next
        txt_totalConceptos.Text = totalConceptos.ToString


        totalFactura = totalItems + totalImpuestos + totalConceptos
        txt_totalFactura.Text = totalFactura
    End Sub

    Private Sub cmd_editar_Click(sender As Object, e As EventArgs) Handles cmd_editar.Click
        dtp_fechaComprobanteCompra.Enabled = True
        cmb_proveedor.Enabled = True
        cmb_cc.Enabled = True
        cmb_condicionCompra.Enabled = True
        cmb_moneda.Enabled = True
        txt_tasaCambio.Enabled = True
        cmb_tipoComprobante.Enabled = True
        txt_puntoVenta.Enabled = True
        txt_numeroComprobante.Enabled = True
        txt_CAE.Enabled = True
        pic_searchProveedor.Enabled = True
        pic_searchCondicionCompra.Enabled = True
        pic_searchCCProveedor.Enabled = True

        tbl_comprobantesCompras.Enabled = False
        cmd_confirmar.Enabled = True
        cmd_editar.Enabled = False
        cmd_agregar.Enabled = False
        cmd_ok.Enabled = False
    End Sub

    Private Sub add_comprobantes_compras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not cerrarOk Then
            cmd_exit_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_totalFactura.Text = "0" Or txt_totalFactura.Text = "" Then
            MsgBox("Carge algún producto, impuesto o concepto para poder guardar.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim cc As New comprobante_compra

        With cc
            .id_comprobanteCompra = id_comprobante_compra
            .subtotal = CDbl(txt_totalItems.Text)
            .impuestos = CDbl(txt_totalImpuestos.Text)
            .conceptos = CDbl(txt_totalConceptos.Text)
            .total = CDbl(txt_totalFactura.Text)
            .nota = txt_notas.Text
        End With

        If Not cerrar_comprobante_compra(cc) Then
            MsgBox("Hubo un problema al guardar el comprobante de compra, consulte con el programador.", vbCritical + vbOKOnly, "Centrex")
            closeandupdate(Me)
            Exit Sub
        End If

        cerrarOk = True
        closeandupdate(Me)
    End Sub

    Private Sub dg_viewItems_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_viewItems.CellMouseDoubleClick
        Dim seleccionado As String

        seleccionado = dg_viewItems.CurrentRow.Cells(0).Value.ToString
        seleccionado = Strings.right(seleccionado, (len(seleccionado)-InStr(seleccionado, "-")))


    End Sub
End Class