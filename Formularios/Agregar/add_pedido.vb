Imports Centrex.Pedidos
Public Class add_pedido

    Private emitir As Boolean = False
    Private totalOriginal As Double
    Private subTotalOriginal As Double
    Public comprobanteSeleccionado As comprobante
    Private markupOriginal As Double = -1
    Private nPedido As Integer = -1
    Private historico As Boolean
    Private numeroPedido_anulado As Integer = -1
    Private idUsuario As Integer
    Private idUnico As String = ""

    'Dim desde As Integer = 0
    'Dim pagina As Integer = 0
    'Dim nRegs As Integer = 0
    'Dim tPaginas As Integer = 0
    Dim orderCol As ColumnClickEventArgs = Nothing

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _idUnico As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idUnico = _idUnico
    End Sub

    Private Sub cmd_add_item_Click(sender As Object, e As EventArgs) Handles cmd_add_item.Click
        If dg_viewPedido.Rows.Count = comprobanteSeleccionado.maxItems Then
            MsgBox("No se pueden agregar más de " + comprobanteSeleccionado.maxItems.ToString + " items por comprobante", vbExclamation)
            Exit Sub
        End If

        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo
        'If txt_markup.Text = 0 Then tabla = "items" Else tabla = "items_sinDescuento"
        tabla = "items_sinDescuento"
        activo = True

        agregaitem = True
        Me.Enabled = False

        'search.ShowDialog()
        Dim frm As New search(idUsuario, idUnico)
        frm.ShowDialog()
        tabla = tmpTabla
        activo = tmpActivo
        agregaitem = False

        updateAndCheck()
    End Sub

    Private Sub cmd_add_descuento_Click(sender As Object, e As EventArgs) Handles cmd_add_descuento.Click
        If dg_viewPedido.Rows.Count = comprobanteSeleccionado.maxItems Then
            MsgBox("No se pueden agregar más de " + comprobanteSeleccionado.maxItems.ToString + " items por comprobante", vbExclamation)
            Exit Sub
        End If

        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo
        'If txt_markup.Text = 0 Then tabla = "items" Else tabla = "items_sinDescuento"
        tabla = "itemsDescuentos"
        activo = True

        agregaitem = True
        Me.Enabled = False

        Dim s As New search(idUsuario, idUnico)
        s.ShowDialog()
        'search.ShowDialog()
        tabla = tmpTabla
        activo = tmpActivo
        agregaitem = False

        updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)
        '        resaltarColumna(dg_view, 4, Color.Red)
        subTotalOriginal = txt_subTotal.Text
        txt_markup_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub add_pedido_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        id = 0
        Dim pe As New pedido
        edita_pedido = pe
        'borro la tabla temporal
        'borrartbl("tmppedidos_items")
        generales_multiUsuario.borrar_tabla_pedidos_temporales(idUsuario, idUnico)
        'restauro los que se borraron porque no se guardaron los cambios
        activaitems("pedidos_items")
        edicion = False
        activo = historico
        closeandupdate(Me)
    End Sub

    Private Sub add_pedido_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 45 Then cmd_add_item_Click(Nothing, Nothing)
    End Sub
    Private Sub add_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String
        Dim cli As New cliente
        form = Me

        If idUnico = "" Then idUnico = Generar_ID_Unico()
        idUsuario = usuario_logueado.id_usuario

        historico = activo
        activo = True
        'Cargo el combo con todos los clientes
        sqlstr = "SELECT c.id_cliente AS 'id_cliente', c.razon_social AS 'razon_social' FROM clientes AS c WHERE c.activo = '1' ORDER BY c.razon_social ASC"
        cargar_combo(cmb_cliente, sqlstr, basedb, "razon_social", "id_cliente")

        'Cargo el combo con todos los comprobantes
        'cargar_combo(cmb_comprobante, "SELECT c.id_comprobante AS 'id_comprobante', c.comprobante AS 'comprobante' FROM comprobantes AS c WHERE c.activo = '1' ORDER BY c.comprobante ASC", basedb, "comprobante", "id_comprobante")
        'cmb_comprobante.SelectedValue = id_comprobante_default
        comprobanteSeleccionado = info_comprobante(id_comprobante_default)

        'Lo pongo acá para que traiga todos los clientes y en base a eso chequeo si en la lista está el cliente default
        cmb_cliente_SelectionChangeCommitted(Nothing, Nothing)

        If estaClienteDefault(id_cliente_pedido_default) Then
            cmb_cliente.SelectedValue = id_cliente_pedido_default
            cli = info_cliente(id_cliente_pedido_default)
        Else
            cmb_cliente.SelectedIndex = 0
            cli = info_cliente(cmb_cliente.SelectedValue)
        End If
        checkCustNoTaxNumber(cli)
        cmb_comprobante_SelectionChangeCommitted(Nothing, Nothing)

        'RemoveHandler Me.txt_subTotal.TextChanged, New EventHandler(AddressOf Me.txt_subTotal_TextChanged)
        RemoveHandler Me.txt_impuestos.TextChanged, New EventHandler(AddressOf Me.txt_impuestos_TextChanged)
        RemoveHandler Me.txt_total.TextChanged, New EventHandler(AddressOf Me.txt_total_TextChanged)
        RemoveHandler Me.chk_presupuesto.CheckedChanged, New EventHandler(AddressOf Me.chk_presupuesto_CheckedChanged)

        If edicion Or borrado Or terminarpedido Then
            'cargo fecha de pedido
            'cargo cliente del pedido 
            'cargo items
            'cargo total
            'inhabilito carga secuencial

            lbl_date.Text = DateTime.Parse(edita_pedido.fecha)

            Dim c As New comprobante
            c = info_comprobante(edita_pedido.id_comprobante)

            cmb_comprobante.SelectedValue = edita_pedido.id_comprobante
            comprobanteSeleccionado = info_comprobante(edita_pedido.id_comprobante)
            cmb_comprobante.Text = comprobanteSeleccionado.comprobante
            'cmb_comprobante_SelectionChangeCommitted(Nothing, Nothing) 'LINEA DUDOSA


            Dim cl As New cliente
            cl = info_cliente(edita_pedido.id_cliente)

            cmb_cliente.SelectedValue = edita_pedido.id_cliente

            cmb_cliente_SelectionChangeCommitted(Nothing, Nothing)

            sqlstr = "SELECT CONCAT(ti.id_tmpPedidoItem, '-', ti.id_item) AS 'ID', ti.id_pedidoItem AS 'id_pedidioItem', " &
                    "CASE WHEN i.id_item IS NULL THEN ti.descript ELSE i.descript END AS 'Producto', " &
                    "ti.cantidad AS 'Cant.', ti.precio AS 'Precio', " &
                   "CAST(ti.cantidad * ti.precio AS DECIMAL(18,3)) AS 'Subtotal' " &
                   "FROM tmppedidos_items AS ti " &
                   "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                   "LEFT JOIN tipos_items AS tim ON i.id_tipo = tim.id_tipo " &
                   "WHERE ti.activo = '1' AND (i.esMarkup = '0' OR ti.id_item IS NULL) " &
                   "ORDER BY id ASC"
            Dim nRegs As Integer = 0
            Dim tPaginas As Integer = 0
            Dim txtnPage As New TextBox()
            cargar_datagrid(dg_viewPedido, sqlstr, basedb, 0, nRegs, tPaginas, 1, txtnPage, "tmppedidos_items", "tmppedidos_items")
            'resaltarcolumna(dg_view, 4, Color.Red)

            txt_markup.Text = edita_pedido.markup
            txt_subTotal.Text = edita_pedido.subTotal
            txt_impuestos.Text = edita_pedido.iva
            txt_total.Text = edita_pedido.total
            txt_totalO.Text = txt_total.Text
            txt_nota1.Text = edita_pedido.nota1
            txt_nota2.Text = edita_pedido.nota2
            txt_comprobanteAsociado.Text = edita_pedido.numeroComprobante_anulado
            chk_presupuesto.Checked = edita_pedido.esPresupuesto
            chk_secuencia.Enabled = False
            subTotalOriginal = txt_subTotal.Text
            chk_esTest.Checked = edita_pedido.esTest

            markupOriginal = txt_markup.Text
            lbl_order.Text = edita_pedido.id_pedido
            lbl_pedido.Visible = True
            lbl_order.Visible = True

            If edita_pedido.numeroComprobante_anulado <> 0 Then
                lbl_avisoAFIP_NC_ND.Visible = True
                cmb_seleccionarComprobanteAnulación.Visible = True
                lbl_comprobante.Visible = True
                lbl_comprobanteAsociado.Visible = True
                txt_comprobanteAsociado.Visible = True
                cmb_cliente.Enabled = False
                cmb_cc.Enabled = False
                cmb_comprobante.Enabled = False
                txt_comprobanteAsociado.Text = edita_pedido.numeroComprobante_anulado
                numeroPedido_anulado = edita_pedido.numeroPedido_anulado
            End If
            'If edita_pedido.esDuplicado Then
            'cmb_comprobante.Enabled = False
            'pic_searchComprobante.Enabled = False
            'End If
        Else
            lbl_date.Text = Hoy()
            txt_total.Text = "0,00"
            txt_subTotal.Text = "0,00"
            txt_impuestos.Text = "0,00"
            txt_totalO.Text = txt_total.Text
            Me.ActiveControl = Me.cmb_cliente
        End If

        'AddHandler Me.txt_subTotal.TextChanged, New EventHandler(AddressOf Me.txt_subTotal_TextChanged)
        AddHandler Me.txt_impuestos.TextChanged, New EventHandler(AddressOf Me.txt_impuestos_TextChanged)
        AddHandler Me.txt_total.TextChanged, New EventHandler(AddressOf Me.txt_total_TextChanged)
        AddHandler Me.chk_presupuesto.CheckedChanged, New EventHandler(AddressOf Me.chk_presupuesto_CheckedChanged)

        If dg_viewPedido.Rows.Count > 0 Then
            cmd_emitir.Enabled = True
            cmd_ok.Enabled = True
        Else
            cmd_emitir.Enabled = False
            cmd_ok.Enabled = False
        End If

        If txt_markup.Text <> "0" Then
            cmd_add_descuento.Enabled = False
        Else
            cmd_add_descuento.Enabled = True
        End If

        If edita_pedido.activo = False Or borrado = True Then
            cmd_recargaprecios.Enabled = False
            cmd_emitir.Enabled = False
            cmb_comprobante.Enabled = False
            cmb_cliente.Enabled = False
            cmb_cc.Enabled = False
            pic_searchComprobante.Enabled = False
            pic_searchCliente.Enabled = False
            dg_viewPedido.Enabled = False
            txt_markup.Enabled = False
            txt_subTotal.Enabled = False
            txt_impuestos.Enabled = False
            txt_total.Enabled = False
            txt_nota1.Enabled = False
            txt_nota2.Enabled = False
            cmd_add_item.Enabled = False
            cmd_addItemManual.Enabled = False
            cmd_add_descuento.Enabled = False
            cmd_ok.Enabled = False
            chk_presupuesto.Enabled = False
            chk_esTest.Enabled = False
        End If

        If borrado = True Then
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este pedido?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If BorrarPedido(edita_pedido) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del pedido, ¿desea intetar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If UpdatePedido(edita_pedido) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el pedido no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el pedido, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el pedido.")
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
        Dim ultimoPedido As pedido = Nothing
        Dim p As New pedido
        Dim c As New comprobante
        'Dim cmpAsociado As New comprobante

        If cmb_cliente.Text = "Seleccione un cliente..." Or cmb_cliente.Text = "" Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_cc.Text = "Seleccione una cuenta corriente..." Or cmb_comprobante.Text = "" Then
            MsgBox("El campo 'Cuenta corriente' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_comprobante.Text = "Seleccione un comprobante..." Or cmb_comprobante.Text = "" Then
            MsgBox("El campo 'Comprobante' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf dg_viewPedido.Rows.Count = 0 Then
            MsgBox("No hay items cargados", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
            'cmpAsociado = info_nComprobante(txt_comprobanteAsociado.Text
        ElseIf txt_comprobanteAsociado.Text <> "" And numeroPedido_anulado <> -1 Then
            If Val(txt_total.Text) > InfoPedido(numeroPedido_anulado).total Then
                MsgBox("Está emitiendo un comprobante asociado a otro, el monto del comprobante que está queriendo emitir no puede ser superior al comprobante original.", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            End If
        End If

        p.id_comprobante = cmb_comprobante.SelectedValue
        c = info_comprobante(p.id_comprobante)
        p.id_cliente = cmb_cliente.SelectedValue
        p.fecha = lbl_date.Text
        p.markup = txt_markup.Text
        p.subTotal = txt_subTotal.Text
        p.iva = txt_impuestos.Text
        'p.total = txt_TotalO.Text
        p.total = txt_total.Text
        p.nota1 = txt_nota1.Text
        p.nota2 = txt_nota2.Text
        p.activo = True
        p.esPresupuesto = chk_presupuesto.Checked
        If c.esPresupuesto Then p.esPresupuesto = True
        p.idPresupuesto = 0
        p.esTest = chk_esTest.Checked
        p.id_Cc = cmb_cc.SelectedValue
        p.id_usuario = idUsuario

        If txt_comprobanteAsociado.Text <> "" Then
            p.numeroComprobante_anulado = txt_comprobanteAsociado.Text
            p.numeroPedido_anulado = numeroPedido_anulado
        End If

        'If txt_markup.Text <> 0 And edita_pedido.id_pedido = 0 Then
        If txt_markup.Text <> 0 Then
            'Agrego el descuento que corresponde al Markup
            'Calculo el descuento a partir del Markup
            Dim descuento As Double
            Dim costo As Double
            Dim total As Double
            total = calculoTotalPuro(dg_viewPedido)
            'If Not chk_presupuesto.Checked Then
            'If c.esPresupuesto And Not chk_presupuesto.Checked Then
            If c.esPresupuesto And Not chk_presupuesto.Checked Then
                descuento = Math.Round(100 - ((total / ("1." + txt_markup.Text) * 100) / total), 4)
            Else
                descuento = Math.Round(100 - (((total / ("1." + txt_markup.Text) / 1.21) * 100) / total), 4)
            End If
            'Else
            '   descuento = Math.Round(100 - ((total / ("1." + txt_markup.Text) * 100) / total), 4)
            'End If
            costo = ((total * descuento) / 100) * -1
            Dim i As New item
            i = info_itemDesc("Descuento: " + descuento.ToString + "%")
            If i.descript = "error" Then
                i.activo = True
                i.cantidad = 1
                i.costo = descuento
                i.precio_lista = descuento
                i.descript = "Descuento: " + descuento.ToString + "%"
                i.esDescuento = False
                i.esMarkup = True
                i.factor = 1
                i.id_proveedor = "2"
                i.id_tipo = "4"
                i.item = "MARKUP"
                i.precio_lista = "0"
                i.id_marca = "2"
                additem(i)
                i.id_item = infoItem_lastItem().id_item
            End If
            Dim id_tmpPedidoItem = ExisteDescuentoMarkupTmp(i.id_item)
            If id_tmpPedidoItem = -1 Then
                'addItemPedidotmp(i.id_item, "1", costo, True)
                addItemPedidotmp(i, "1", costo, idUsuario, idUnico, -1)
            Else
                addItemPedidotmp(i, "1", costo, idUsuario, idUnico, id_tmpPedidoItem)
            End If
        End If

        If edicion = True Then
            'actualizar cliente
            p.id_pedido = edita_pedido.id_pedido

            ultimoPedido = p
            p.fecha_edicion = Format(DateTime.Now, "dd/MM/yyyy")
            If UpdatePedido(p) = False Then
                MsgBox("Hubo un problema al actualizar el pedido.", vbExclamation)
                closeandupdate(Me)
            End If
            'actualizar pedido (items)            
            'actualizo, agrego y borro los items del pedido
            GuardarPedido(idUsuario, idUnico, edita_pedido.id_pedido)
            generales_multiUsuario.borrar_tabla_pedidos_temporales(idUsuario, idUnico)
            'borrartbl("tmppedidos_items")
        Else
            'Agrego el pedido
            If AddPedido(p) Then
                ultimoPedido = InfoPedido(Info_Ultimo_Pedido_Por_Usuario(idUsuario))
                'Agrego los items al pedido
                If Not GuardarPedido(idUsuario, idUnico, ultimoPedido.id_pedido) Then
                    MsgBox("Hubo un problema al agregar el pedido.", vbExclamation)
                    generales_multiUsuario.borrar_tabla_pedidos_temporales(idUsuario, idUnico)
                    closeandupdate(Me)
                    Exit Sub
                Else
                    generales_multiUsuario.borrar_tabla_pedidos_temporales(idUsuario, idUnico)
                End If
            Else
                MsgBox("Hubo un problema al agregar el pedido.", vbExclamation)
                generales_multiUsuario.borrar_tabla_pedidos_temporales(idUsuario, idUnico)
                closeandupdate(Me)
                Exit Sub
            End If
            edicion = True
            edita_pedido = ultimoPedido
        End If

        PedidoAPedidoTmp(edita_pedido.id_pedido, idUsuario, idUnico)

        'If emitir And Not chk_presupuesto.Checked Then
        If emitir Then 'Ahora los comprobantes se contabilizan si tienen el tilde 24/08/2021
            If facturar(ultimoPedido) Then 'And c.id_tipoComprobante <> 1011 And c.id_tipoComprobante <> 1012 Then '1011 y 1012 son proformas, no se contabilizan
                'Si se facturó, lo agrego a la cuenta corriente
                If c.contabilizar Then
                    Dim ccC As ccCliente
                    ccC = info_ccCliente(cmb_cc.SelectedValue)
                    If ccC.nombre = "error" Then
                        MsgBox("Ha ocurrido al impactar el saldo en la cuenta corriente del cliente.", vbCritical + vbOKOnly, "Centrex")
                    End If
                    Dim tc As New TipoComprobante(c.id_tipoComprobante)
                    If tc.signoCliente = "+" Then
                        ccC.saldo += edita_pedido.total
                    Else
                        ccC.saldo -= edita_pedido.total
                    End If
                    'ccC.saldo -= edita_pedido.total
                    updateCCCliente(ccC)
                    'cerrarpedido(InfoPedido(), chk_presupuesto.Checked)
                    'El pedido ya lo cierra la función facturar
                    Dim t As New transaccion
                    p = ultimoPedido
                    t.fecha = p.fecha
                    t.id_pedido = p.id_pedido
                    't.id_tipoComprobante = info_comprobante(p.id_comprobante).id_tipoComprobante
                    t.id_tipoComprobante = c.id_tipoComprobante
                    If Not p.esPresupuesto Then
                        t.numeroComprobante = p.numeroComprobante
                    Else
                        t.numeroComprobante = p.idPresupuesto
                    End If
                    t.puntoVenta = p.puntoVenta
                    t.total = p.total
                    t.id_cc = p.id_Cc
                    t.id_cliente = p.id_cliente
                    'Se agrega la operación a la tabla transacciones
                    If Not Agregar_Transaccion_Desde_Pedido(t) Then
                        MsgBox("Ha ocurrido un error al agregar la transaccion en el cliente, verifique el mismo o vuelva a intentarlo más tarde ya que puede haber problemas con los servidores de AFIP.", vbExclamation, "Centrex")
                        Exit Sub
                    End If
                End If
                If c.id_tipoComprobante <> 1000 And c.id_tipoComprobante <> 1001 Then
                    imprimirFactura(ultimoPedido.id_pedido, 0, chk_remitos.Checked)
                Else
                    MsgBox("Se generó un comprobante: """ + c.comprobante + """ por un valor de: $ " + p.total.ToString, vbInformation + vbOKOnly, "Centrex")
                End If
                emitir = False
            Else
                MsgBox("Ha ocurrido un error al facturar el pedido, verifique el mismo o vuelva a intentarlo más tarde ya que puede haber problemas con los servidores de AFIP.", vbExclamation, "Centrex")
                Exit Sub
            End If
        ElseIf emitir Then
            CerrarPedido(ultimoPedido, chk_presupuesto.Checked, chk_remitos.Checked)
            emitir = False
        End If

        If chk_secuencia.Checked = True Then
            cmb_comprobante.SelectedValue = id_comprobante_default
            cmb_cliente.SelectedValue = id_cliente_pedido_default
            lbl_date.Text = Format(DateTime.Now, "dd/MM/yyyy")
            txt_total.Text = ""
            dg_viewPedido.Columns.Clear()
            borrartbl("tmppedidos_items")
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub txt_total_TextChanged(sender As Object, e As EventArgs) Handles txt_total.TextChanged
        'If InStr(txt_total.Text, "$") = 0 Then txt_total.Text = "$ " + txt_total.Text
    End Sub

    'Private Sub updateform(Optional ByVal seleccionado As String = "", Optional ByVal cmb As ComboBox = Nothing)
    '    If cmb Is Nothing Then Exit Sub

    '    If seleccionado = "" Then
    '        seleccionado = cmb.SelectedValue
    '    Else
    '        cmb.SelectedValue = seleccionado
    '    End If
    'End Sub

    Private Sub dg_view_cliente_DoubleClick(sender As Object, e As EventArgs)
        updateform()
    End Sub

    Private Sub pic_searchCliente_Click(sender As Object, e As EventArgs) Handles pic_searchCliente.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_cliente)
        cmb_cliente_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub dg_view_DoubleClick(sender As Object, e As EventArgs) Handles dg_viewPedido.DoubleClick
        Dim seleccionado As String
        'Obtengo el ID del item
        seleccionado = dg_viewPedido.CurrentRow.Cells(0).Value.ToString()
        seleccionado = Microsoft.VisualBasic.Right(seleccionado, (seleccionado.Length - InStr(seleccionado, "-")))

        If seleccionado <> "" Then
            edita_item = info_item(seleccionado)
        Else
            'Es un item manual
            edita_item.item = "MANUAL"
            edita_item.activo = True
            edita_item.descript = dg_viewPedido.CurrentRow.Cells(2).Value.ToString()
            edita_item.cantidad = dg_viewPedido.CurrentRow.Cells(3).Value.ToString()
            edita_item.precio_lista = dg_viewPedido.CurrentRow.Cells(4).Value.ToString()
        End If
        If edita_item.esDescuento Or edita_item.esMarkup Then Exit Sub

        'Obtengo el ID interno de la tabla tmppedidos_items
        seleccionado = dg_viewPedido.CurrentRow.Cells(0).Value.ToString
        edita_item.id_item_temporal = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        If edita_item.item = "MANUAL" Then
            Dim addItemManual As New add_itemManual(edita_item, idUsuario, idUnico)
            addItemManual.ShowDialog()
        Else
            Dim infoItemAgregado As New infoagregaitem(idUsuario, idUnico)
            infoItemAgregado.ShowDialog()
        End If

        Dim i As New item
        edita_item = i

        updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)
        subTotalOriginal = txt_subTotal.Text
        txt_markup_LostFocus(Nothing, Nothing)
        'resaltarColumna(dg_view, 4, Color.Red)
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        dg_view_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        If dg_viewPedido.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String
        Dim id_tmpPedidoItem_seleccionado As String
        seleccionado = dg_viewPedido.CurrentRow.Cells(0).Value.ToString()

        'Obtengo el ID interno de la tabla tmppedidos_items
        id_tmpPedidoItem_seleccionado = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))


        borraritemCargado(id_tmpPedidoItem_seleccionado)

        'Si se borró algún descuento recalcula los descuentos 
        'updateDescuentos()

        updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)
        subTotalOriginal = txt_subTotal.Text
        txt_markup_LostFocus(Nothing, Nothing)
        'resaltarcolumna(dg_view, 4, Color.Red)
    End Sub

    Private Sub RecargarPrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargarPrecioToolStripMenuItem.Click
        If dg_viewPedido.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String = dg_viewPedido.CurrentRow.Cells(0).Value.ToString
        seleccionado = Microsoft.VisualBasic.Right(seleccionado, (seleccionado.Length - InStr(seleccionado, "-")))
        Dim i As item
        i = info_item(seleccionado)
        If i.esDescuento = False And i.esMarkup = False Then
            If edita_pedido.id_pedido Then
                recargaPrecios(edita_pedido.id_pedido, seleccionado, "pedidos_items")
            Else
                recargaPrecios(, seleccionado)
            End If

            updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)
            subTotalOriginal = txt_subTotal.Text
            txt_markup_LostFocus(Nothing, Nothing)
            'resaltarcolumna(dg_view, 4, Color.Red)
        End If
    End Sub

    Private Sub chk_presupuesto_CheckedChanged(sender As Object, e As EventArgs) Handles chk_presupuesto.CheckedChanged
        If Not chk_presupuesto.Checked Then
            txt_impuestos.Enabled = True

            updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)
            'resaltarcolumna(dg_view, 4, Color.Red)
            cmb_comprobante.SelectedValue = comprobanteSeleccionado.id_comprobante
        Else
            txt_impuestos.Text = "0"
            'txt_subTotal.Text = txt_totalO.Text
            'txt_total.Text = txt_totalO.Text
            updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)
            txt_impuestos.Enabled = False
            cmb_comprobante.SelectedValue = comprobantePresupuesto_default
        End If
        txt_markup_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub cmd_emitir_Click(sender As Object, e As EventArgs) Handles cmd_emitir.Click
        emitir = True
        cmd_ok_Click(Nothing, Nothing)
        emitir = False
    End Sub

    Private Sub txt_markup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_markup.KeyPress
        If esNumero(e) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_markup_LostFocus(sender As Object, e As EventArgs) Handles txt_markup.LostFocus
        'Validar que solo se puedan poner enteros entre 1 - 99
        'Recalcular precio
        'Dim markup As Long
        'markup = "1," 
        Dim id_itemMarkup As Integer
        Dim total As Double
        Dim descuento As Double

        If txt_markup.Text = "" Then txt_markup.Text = "0"

        If txt_markup.Text <> "0" Then
            cmd_add_descuento.Enabled = False
        Else
            cmd_add_descuento.Enabled = True
        End If

        'Aca calcula totales, subtotales e impuestos
        updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)

        subTotalOriginal = txt_subTotal.Text

        'Para que al cambiar el Markup borré el item anterior del Markup de la tabla de los items del pedido
        If markupOriginal <> -1 And markupOriginal <> txt_markup.Text And edicion = True Then
            markupOriginal = txt_markup.Text

            id_itemMarkup = IdItemMarkupPedido(edita_pedido.id_pedido)
            borraritemCargado(id_itemMarkup, True)

            'Si se borró algún descuento recalcula los descuentos 
            'updateDescuentos()

            updatePrecios(dg_viewPedido, chk_presupuesto, txt_subTotal, txt_impuestos, txt_total, txt_totalO, txt_markup, txt_totalDescuentos, comprobanteSeleccionado, idUsuario, idUnico)
            'subTotalOriginal = txt_subTotal.Text
            txt_markup_LostFocus(Nothing, Nothing)
            'resaltarcolumna(dg_view, 4, Color.Red)
        End If


        If Trim(txt_markup.Text) = "" Then txt_markup.Text = 0
        If txt_markup.Text <> "0" Then
            'If comprobanteSeleccionado.esPresupuesto And Not chk_presupuesto.Checked Then
            'If comprobanteSeleccionado.esPresupuesto And Not chk_presupuesto.Checked Then
            '    txt_subTotal.Text = Math.Round(subTotalOriginal / ("1." + txt_markup.Text), 2)
            'Else
            txt_subTotal.Text = Math.Round((subTotalOriginal / ("1." + txt_markup.Text) / 1.21), 2)
            'End If
        Else
            txt_subTotal.Text = Math.Round(subTotalOriginal, 2)
        End If

        markupOriginal = txt_markup.Text

        'total = txt_total.Text
        total = calculoTotalPuro(dg_viewPedido)

        If txt_markup.Text <> "" And txt_markup.Text <> "0" And dg_viewPedido.Rows.Count > 0 And txt_total.Text <> "" And txt_total.Text <> "0" Then
            If comprobanteSeleccionado.esPresupuesto And Not chk_presupuesto.Checked Then
                descuento = Math.Round(100 - ((total / ("1." + txt_markup.Text) * 100) / total), 4)
            Else
                descuento = Math.Round(100 - (((total / ("1." + txt_markup.Text) / 1.21) * 100) / total), 4)
            End If
            txt_totalDescuentos.Text = Math.Round((descuento * total) / 100, 2)
            'txt_totalDescuentos.t
            Dim toolTipText As String = "El descuento es del: " + descuento.ToString + "%"
            tt_descuento.SetToolTip(Me.txt_totalDescuentos, toolTipText)
            tt_descuento.Active = True
        Else
            txt_totalDescuentos.Text = "0"
            tt_descuento.Active = False
        End If

        If (comprobanteSeleccionado.id_tipoComprobante = 99 Or comprobanteSeleccionado.id_tipoComprobante = 0) And Not chk_presupuesto.Checked And (txt_markup.Text = "0" Or txt_markup.Text = "") Then
            lbl_noMarkupNoPresupuesto.Visible = True
        Else
            lbl_noMarkupNoPresupuesto.Visible = False
        End If
    End Sub

    'Private Sub txt_subTotal_TextChanged(sender As Object, e As EventArgs) Handles txt_subTotal.TextChanged
    '    If comprobanteSeleccionado.esPresupuesto And chk_presupuesto.Checked Then
    '        txt_impuestos.Text = 0
    '        txt_total.Text = txt_subTotal.Text
    '    Else
    '        Select Case comprobanteSeleccionado.id_tipoComprobante
    '            'Separo los comprobantes B de los A, a los B no se les hace distinción de los impuestos
    '            Case Is = 6, 7, 8, 9, 64, 40, 61, 49, 1012
    '                txt_impuestos_TextChanged(Nothing, Nothing)
    '            Case Else
    '                txt_impuestos.Text = 500 'Math.Round(txt_subTotal.Text * 0.21, 2)
    '        End Select
    '    End If
    'End Sub

    Private Sub txt_impuestos_TextChanged(sender As Object, e As EventArgs) Handles txt_impuestos.TextChanged
        Dim subtotal As Double
        Dim iva As Double

        Double.TryParse(txt_subTotal.Text, subtotal)
        Double.TryParse(txt_impuestos.Text, iva)
        If comprobanteSeleccionado.id_tipoComprobante <> 6 Then
            txt_total.Text = subtotal + iva
        End If

    End Sub

    Private Sub pic_searchComprobante_Click(sender As Object, e As EventArgs) Handles pic_searchComprobante.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "comprobantes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        updateform(id.ToString, cmb_comprobante)
    End Sub

    Private Sub dg_view_MouseDown(sender As Object, e As MouseEventArgs) Handles dg_viewPedido.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.dg_viewPedido
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
                Me.ContextMenuStrip1.Visible = True
            End With
        End If
    End Sub

    Private Sub cmb_comprobante_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_comprobante.SelectionChangeCommitted
        Dim c As New cliente

        comprobanteSeleccionado = info_comprobante(cmb_comprobante.SelectedValue)

        If comprobanteSeleccionado.esPresupuesto Then
            'Es un presupuesto

            chk_remitos.Checked = False
            chk_remitos.Enabled = False

            chk_presupuesto.Checked = True
            chk_presupuesto.Enabled = True
        Else
            'No es un presupuesto
            Select Case comprobanteSeleccionado.id_tipoComprobante
                Case Is = 2, 3, 4, 5, 7, 8, 9, 10, 12, 13, 15, 34, 39, 40, 49, 52, 53, 54, 60, 61, 63, 64, 199, 2002, 203, 207, 208, 212, 213 'Todo menos facturas
                    chk_remitos.Checked = False
                    chk_remitos.Enabled = False
                Case Else
                    chk_remitos.Checked = True
                    chk_remitos.Enabled = True
            End Select

            Select Case comprobanteSeleccionado.id_tipoComprobante
                Case Is = 2, 3, 7, 8, 12, 13, 52, 53, 202, 203, 207, 208, 212, 213 'Notas de débito y crédito según nueva disposición de AFIP
                    lbl_avisoAFIP_NC_ND.Visible = True
                    cmb_seleccionarComprobanteAnulación.Visible = True
                    lbl_comprobante.Visible = True
                    lbl_comprobanteAsociado.Visible = True
                    txt_comprobanteAsociado.Visible = True
                    dg_viewPedido.Enabled = False
                    ContextMenuStrip1.Enabled = False
                    cmd_add_item.Enabled = False
                    cmd_add_descuento.Enabled = False
                    cmd_addItemManual.Enabled = False
                    cmd_emitir.Enabled = False
                Case Else
                    lbl_avisoAFIP_NC_ND.Visible = False
                    cmb_seleccionarComprobanteAnulación.Visible = False
                    'lbl_comprobante.Visible = False
                    lbl_comprobanteAsociado.Visible = False
                    txt_comprobanteAsociado.Visible = False
                    dg_viewPedido.Enabled = True
                    ContextMenuStrip1.Enabled = True
                    cmd_add_item.Enabled = True
                    cmd_add_descuento.Enabled = True
                    cmd_addItemManual.Enabled = True
                    cmd_emitir.Enabled = True
            End Select

            chk_presupuesto.Checked = False
            chk_presupuesto.Enabled = False

            'MOD 21/04/2020
            c = info_cliente(cmb_cliente.SelectedValue)
            checkCustNoTaxNumber(c)
            'MOD 21/04/2020
        End If
        txt_markup_LostFocus(Nothing, Nothing)
        'cmb_cliente_SelectionChangeCommitted(Nothing, Nothing) 'MOD 21/04/2020
    End Sub

    Private Sub txt_markup_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_markup.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_markup_LostFocus(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmb_cliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cliente.SelectionChangeCommitted
        Dim c As New cliente
        Dim id_ultima_cc As Integer
        Dim sqlstr As String
        Dim condicion As String

        If cmb_cliente.SelectedValue <> Nothing Then
            c = info_cliente(cmb_cliente.SelectedValue)
        Else
            Exit Sub
        End If

        checkCustNoTaxNumber(c)

        If c.id_tipoDocumento = 80 And c.esInscripto Then
            condicion = "IN"
        Else
            condicion = "NOT IN"
        End If


        sqlstr = "SELECT c.id_comprobante AS 'id_comprobante', c.comprobante AS 'comprobante' " &
                    "FROM comprobantes AS c " &
                    "WHERE c.activo = '1' AND (c.id_tipoComprobante " + condicion + " (1, 2, 3, 4, 5, 63, 34, 39, 60, 201, 202, 203, 1011) OR c.id_tipoComprobante IN (0, 99, 199, 1000, 10001)) " &
                    "ORDER BY c.comprobante ASC"


        cargar_combo(cmb_comprobante, sqlstr, basedb, "comprobante", "id_comprobante")
        '7/7

        If estaComprobanteDefault(condicion, comprobanteSeleccionado.id_comprobante) Then
            cmb_comprobante.SelectedValue = comprobanteSeleccionado.id_comprobante
        ElseIf estaComprobanteDefault(condicion, id_comprobante_default) Then
            cmb_comprobante.SelectedValue = id_comprobante_default
        Else
            cmb_comprobante.SelectedIndex = 0
        End If
        cmb_comprobante_SelectionChangeCommitted(Nothing, Nothing)


        'Cargo el combo con todas las cuentas corrientes del cliente seleccionado
        sqlstr = "SELECT cc.id_cc AS 'id_cc', cc.nombre AS 'nombre' FROM cc_clientes AS cc WHERE cc.id_cliente = '" + cmb_cliente.SelectedValue.ToString + "' AND cc.activo = '1' ORDER BY cc.nombre ASC"
        cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")
        If cmb_cc.Items.Count = 0 Then
            MsgBox("Este cliente no tiene ninguna cuenta corriente creada, por lo cual no se podrá cargar el pedido a su nombre.", vbExclamation + vbOKOnly, "Centrex")
            cmd_emitir.Enabled = False
            cmd_ok.Enabled = False
        Else
            cmd_emitir.Enabled = True
            cmd_ok.Enabled = True
        End If
        'Selecciono la última cuenta corriente que se uso del cliente
        id_ultima_cc = Ultima_CC_Pedido_Cliente(c.id_cliente)
        If id_ultima_cc = -1 Then
            cmb_cc.Text = "Seleccione una cuenta corriente..."
        Else
            cmb_cc.SelectedValue = id_ultima_cc
        End If
        cmb_cc.Enabled = True
        SendKeys.Send("{TAB}")
        txt_markup_LostFocus(Nothing, Nothing)
        'comprobanteSeleccionado = info_comprobante(cmb_comprobante.SelectedValue)
    End Sub

    Public Sub checkCustNoTaxNumber(ByVal c As cliente)
        Select Case comprobanteSeleccionado.id_tipoComprobante
            Case Is = 1, 2, 3, 6, 7, 8, 4, 5, 9, 10, 63, 64, 34, 35, 39, 40, 60, 61, 11, 12, 13, 15, 49, 51, 52, 53, 54
                If c.taxNumber = "" Then
                    cmd_emitir.Enabled = False
                    lbl_noTaxNumber.Visible = True
                Else
                    cmd_emitir.Enabled = True
                    lbl_noTaxNumber.Visible = False
                End If
        End Select
    End Sub

    Private Sub cmd_addItemManual_Click(sender As Object, e As EventArgs) Handles cmd_addItemManual.Click
        agregaitem = True
        Dim addItemManual As New add_itemManual(idUsuario, idUnico)
        addItemManual.ShowDialog()
        agregaitem = False

        updateAndCheck()
    End Sub

    Private Sub updateAndCheck()
        txt_markup_LostFocus(Nothing, Nothing)
        subTotalOriginal = txt_subTotal.Text
        If dg_viewPedido.Rows.Count > 0 Then
            cmd_emitir.Enabled = True
            cmd_ok.Enabled = True
        Else
            cmd_emitir.Enabled = False
            cmd_ok.Enabled = False
        End If
    End Sub

    Private Sub cmb_comprobante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_comprobante.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cliente.KeyPress
        'e.KeyChar = ""
    End Sub


    Private Sub psearch_cc_Click(sender As Object, e As EventArgs) Handles psearch_cc.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "archivoCCClientes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        updateform(id.ToString, cmb_cc)
    End Sub

    Private Sub cmb_cc_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cc.SelectionChangeCommitted
        Me.ActiveControl = Me.cmb_comprobante
    End Sub

    Private Sub cmb_cliente_Leave(sender As Object, e As EventArgs) Handles cmb_cliente.Leave
        cmb_cliente_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub cmb_seleccionarComprobanteAnulación_Click(sender As Object, e As EventArgs) Handles cmb_seleccionarComprobanteAnulación.Click
        Dim tmp As String
        Dim c As cliente
        Dim cmp As comprobante

        If dg_viewPedido.Rows.Count > 0 Then
            If MsgBox("Ya tiene items cargados en el pedido, si continua, los perdera." & vbCrLf & "¿Desea continuar?", vbQuestion + vbYesNo, "Centrex") = vbNo Then
                Exit Sub
            End If
        End If

        generales_multiUsuario.borrar_tabla_pedidos_temporales(usuario_logueado.id_usuario)
        c = info_cliente(cmb_cliente.SelectedValue)
        cmp = info_comprobante(cmb_comprobante.SelectedValue)
        tmp = tabla
        tabla = "anulaComprobanteAFIP"
        'Me.Enabled = False
        Dim buscaComprobante As New search(c, cmp)
        buscaComprobante.ShowDialog()
        tabla = tmp
        If id = 0 Then
            Exit Sub
        End If
        numeroPedido_anulado = id

        PedidoAPedidoTmp(numeroPedido_anulado, usuario_logueado.id_usuario, idUnico)

        'Duplicar_Pedido_Para_Anularlo(numeroPedido_anulado)
        txt_comprobanteAsociado.Text = InfoPedido(numeroPedido_anulado).numeroComprobante

        edicion = True
        updateAndCheck()
        'txt_total.Text = edita_pedido.total
        'txt_subTotal.Text = edita_pedido.subTotal
        'txt_impuestos.Text = edita_pedido.iva
        'txt_markup.Text = edita_pedido.markup
        cmb_cliente.Enabled = False
        cmb_cc.Enabled = False
        cmb_comprobante.Enabled = False

        dg_viewPedido.Enabled = True
        ContextMenuStrip1.Enabled = True
        cmd_add_item.Enabled = True
        cmd_add_descuento.Enabled = True
        cmd_addItemManual.Enabled = True
        edicion = False
    End Sub

    Private Sub Duplicar_Pedido_Para_Anularlo(ByVal nPedidoAnulado As Integer)
        Dim p As New pedido
        p = InfoPedido(nPedidoAnulado)

        DuplicarPedido(nPedidoAnulado)
        edita_pedido = InfoPedido()
        PedidoAPedidoTmp(edita_pedido.id_pedido, idUsuario, idUnico)
        edita_pedido.numeroComprobante_anulado = p.numeroComprobante
        edita_pedido.id_Cc = p.id_Cc
        edita_pedido.numeroPedido_anulado = nPedidoAnulado
        edita_pedido.id_comprobante = cmb_comprobante.SelectedValue
        If UpdatePedido(edita_pedido) = False Then
            MsgBox("Hubo un problema al clonar el pedido.", vbExclamation, "Centrex")
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_recargaprecios_Click(sender As Object, e As EventArgs) Handles cmd_recargaprecios.Click

    End Sub

    'Private Sub cmd_next_Click(sender As Object, e As EventArgs) Handles cmd_next.Click
    '    If pagina = Math.Ceiling(nRegs / itXPage) Then Exit Sub
    '    desde += itXPage
    '    pagina += 1
    '    'actualizarDatagrid()
    'End Sub

    'Private Sub cmd_prev_Click(sender As Object, e As EventArgs) Handles cmd_prev.Click
    '    If pagina = 1 Then Exit Sub
    '    desde -= itXPage
    '    pagina -= 1
    '    ' actualizarDatagrid()
    'End Sub

    'Private Sub cmd_first_Click(sender As Object, e As EventArgs) Handles cmd_first.Click
    '    desde = 0
    '    pagina = 1
    '    ' actualizarDatagrid()
    'End Sub

    'Private Sub cmd_last_Click(sender As Object, e As EventArgs) Handles cmd_last.Click
    '    pagina = tPaginas
    '    desde = nRegs - itXPage
    '    ' actualizarDatagrid()
    'End Sub

    'Private Sub cmd_go_Click(sender As Object, e As EventArgs) Handles cmd_go.Click
    '    pagina = txt_nPage.Text
    '    If pagina > tPaginas Then pagina = tPaginas
    '    desde = (pagina - 1) * itXPage
    '    ' actualizarDatagrid()
    'End Sub

    'Private Sub txt_nPage_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nPage.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        cmd_go_Click(Nothing, Nothing)
    '    End If
    'End Sub

    'Private Sub txt_nPage_Click(sender As Object, e As EventArgs) Handles txt_nPage.Click
    '    txt_nPage.Text = ""
    'End Sub
End Class