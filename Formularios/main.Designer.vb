<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Condiciones de venta")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Condiciones de compra")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Conceptos de compra")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CC. Clientes")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CC. Proveedores")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Marcas")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Categorías")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos asociados")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12, TreeNode13, TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comprobantes")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultas personalizadas")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Caja")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bancos")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cuentas bancarias")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bancos", New System.Windows.Forms.TreeNode() {TreeNode19, TreeNode20})
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cheques recibidos")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cheques emitidos")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cartera de cheques")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Depositar ch. recibidos")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rechazar ch. recibidos")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cheques", New System.Windows.Forms.TreeNode() {TreeNode22, TreeNode23, TreeNode24, TreeNode25, TreeNode26})
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Impuestos")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Items - Impuestos")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Impuestos", New System.Windows.Forms.TreeNode() {TreeNode28, TreeNode29})
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Archivos", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode4, TreeNode7, TreeNode10, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode21, TreeNode27, TreeNode30})
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ordenes de compra")
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comprobantes de compras")
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pagos")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras", New System.Windows.Forms.TreeNode() {TreeNode32, TreeNode33, TreeNode34})
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ajustes de stock")
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ingreso de mercadería")
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock", New System.Windows.Forms.TreeNode() {TreeNode36, TreeNode37})
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Producción")
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nuevo pedido")
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pedidos")
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cobros")
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas", New System.Windows.Forms.TreeNode() {TreeNode40, TreeNode41, TreeNode42})
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock")
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Movimientos de stock")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos", New System.Windows.Forms.TreeNode() {TreeNode44, TreeNode45})
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CC. Proveedores")
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores", New System.Windows.Forms.TreeNode() {TreeNode47})
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CC. Clientes")
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes", New System.Windows.Forms.TreeNode() {TreeNode49})
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Último comprobante")
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Factura electrónica", New System.Windows.Forms.TreeNode() {TreeNode51})
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personalizadas")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultas", New System.Windows.Forms.TreeNode() {TreeNode46, TreeNode48, TreeNode50, TreeNode52, TreeNode53})
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración")
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acerca de...")
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Centrex", New System.Windows.Forms.TreeNode() {TreeNode31, TreeNode35, TreeNode38, TreeNode39, TreeNode43, TreeNode54, TreeNode55, TreeNode56})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.cmd_add = New System.Windows.Forms.Button()
        Me.lblbusqueda = New System.Windows.Forms.Label()
        Me.chk_historicos = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbl_borrarbusqueda = New System.Windows.Forms.Label()
        Me.Treev = New System.Windows.Forms.TreeView()
        Me.cmsPreciosMasivo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizaciónMasivaDePreciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_pedido = New System.Windows.Forms.Button()
        Me.cmd_addcliente = New System.Windows.Forms.Button()
        Me.chk_rpt = New System.Windows.Forms.CheckBox()
        Me.tooltip_advanceseach = New System.Windows.Forms.ToolTip(Me.components)
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.cmsGeneral = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminarPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshabilitarItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicarPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarInformaciónDeAFIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_version = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_dbInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_hora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chk_test = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.cmd_go = New System.Windows.Forms.Button()
        Me.txt_nPage = New System.Windows.Forms.TextBox()
        Me.cmd_last = New System.Windows.Forms.Button()
        Me.cmd_next = New System.Windows.Forms.Button()
        Me.cmd_prev = New System.Windows.Forms.Button()
        Me.cmd_first = New System.Windows.Forms.Button()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.pic_search = New System.Windows.Forms.PictureBox()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmsPreciosMasivo.SuspendLayout()
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsGeneral.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_add
        '
        Me.cmd_add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_add.Location = New System.Drawing.Point(20, 705)
        Me.cmd_add.Name = "cmd_add"
        Me.cmd_add.Size = New System.Drawing.Size(213, 42)
        Me.cmd_add.TabIndex = 3
        Me.cmd_add.Text = "Agregar"
        Me.cmd_add.UseVisualStyleBackColor = True
        '
        'lblbusqueda
        '
        Me.lblbusqueda.AutoSize = True
        Me.lblbusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbusqueda.Location = New System.Drawing.Point(13, 29)
        Me.lblbusqueda.Name = "lblbusqueda"
        Me.lblbusqueda.Size = New System.Drawing.Size(63, 13)
        Me.lblbusqueda.TabIndex = 18
        Me.lblbusqueda.Text = "Búsqueda"
        '
        'chk_historicos
        '
        Me.chk_historicos.AutoSize = True
        Me.chk_historicos.Location = New System.Drawing.Point(11, 67)
        Me.chk_historicos.Margin = New System.Windows.Forms.Padding(2)
        Me.chk_historicos.Name = "chk_historicos"
        Me.chk_historicos.Size = New System.Drawing.Size(136, 17)
        Me.chk_historicos.TabIndex = 20
        Me.chk_historicos.Text = "Ver históricos/inactivos"
        Me.chk_historicos.UseVisualStyleBackColor = True
        '
        'lbl_borrarbusqueda
        '
        Me.lbl_borrarbusqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_borrarbusqueda.AutoSize = True
        Me.lbl_borrarbusqueda.Location = New System.Drawing.Point(1073, 29)
        Me.lbl_borrarbusqueda.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusqueda.Name = "lbl_borrarbusqueda"
        Me.lbl_borrarbusqueda.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusqueda.TabIndex = 68
        Me.lbl_borrarbusqueda.Text = "x"
        Me.ToolTip1.SetToolTip(Me.lbl_borrarbusqueda, "Borrar búsqueda")
        '
        'Treev
        '
        Me.Treev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Treev.ContextMenuStrip = Me.cmsPreciosMasivo
        Me.Treev.Location = New System.Drawing.Point(11, 88)
        Me.Treev.Margin = New System.Windows.Forms.Padding(2)
        Me.Treev.Name = "Treev"
        TreeNode1.Name = "condiciones_venta"
        TreeNode1.Text = "Condiciones de venta"
        TreeNode2.Name = "condiciones_compra"
        TreeNode2.Text = "Condiciones de compra"
        TreeNode3.Name = "conceptos_compra"
        TreeNode3.Text = "Conceptos de compra"
        TreeNode4.Name = "archivo_compras"
        TreeNode4.Text = "Compras"
        TreeNode5.Name = "clientes"
        TreeNode5.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode5.Text = "Clientes"
        TreeNode6.Name = "archivoCCClientes"
        TreeNode6.Text = "CC. Clientes"
        TreeNode7.Name = "archivoClientes"
        TreeNode7.Text = "Clientes"
        TreeNode8.Name = "proveedores"
        TreeNode8.Text = "Proveedores"
        TreeNode9.Name = "archivoCCProveedores"
        TreeNode9.Text = "CC. Proveedores"
        TreeNode10.Name = "archivoProveedores"
        TreeNode10.Text = "Proveedores"
        TreeNode11.Name = "marcas_items"
        TreeNode11.Text = "Marcas"
        TreeNode12.Name = "tipos_items"
        TreeNode12.Text = "Categorías"
        TreeNode13.Name = "items"
        TreeNode13.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode13.Text = "Productos"
        TreeNode14.Name = "asocItems"
        TreeNode14.Text = "Productos asociados"
        TreeNode15.Name = "archivoitems"
        TreeNode15.Text = "Productos"
        TreeNode16.Name = "comprobantes"
        TreeNode16.Text = "Comprobantes"
        TreeNode17.Name = "archivoconsultas"
        TreeNode17.Text = "Consultas personalizadas"
        TreeNode18.Name = "caja"
        TreeNode18.Text = "Caja"
        TreeNode19.Name = "bancos"
        TreeNode19.Text = "Bancos"
        TreeNode20.Name = "cuentas_bancarias"
        TreeNode20.Text = "Cuentas bancarias"
        TreeNode21.Name = "archivoBancos"
        TreeNode21.Text = "Bancos"
        TreeNode22.Name = "chRecibidos"
        TreeNode22.Text = "Cheques recibidos"
        TreeNode23.Name = "chEmitidos"
        TreeNode23.Text = "Cheques emitidos"
        TreeNode24.Name = "chCartera"
        TreeNode24.Text = "Cartera de cheques"
        TreeNode25.Name = "depositarCH"
        TreeNode25.Text = "Depositar ch. recibidos"
        TreeNode26.Name = "rechazarCH"
        TreeNode26.Text = "Rechazar ch. recibidos"
        TreeNode27.Name = "cheques"
        TreeNode27.Text = "Cheques"
        TreeNode28.Name = "impuestos"
        TreeNode28.Text = "Impuestos"
        TreeNode29.Name = "itemsImpuestos"
        TreeNode29.Text = "Items - Impuestos"
        TreeNode30.Name = "archivoImpuestos"
        TreeNode30.Text = "Impuestos"
        TreeNode31.Name = "archivos"
        TreeNode31.Text = "Archivos"
        TreeNode32.Name = "ordenesCompras"
        TreeNode32.Text = "Ordenes de compra"
        TreeNode33.Name = "comprobantes_compras"
        TreeNode33.Text = "Comprobantes de compras"
        TreeNode34.Name = "pagos"
        TreeNode34.Text = "Pagos"
        TreeNode35.Name = "archivocompras"
        TreeNode35.Text = "Compras"
        TreeNode36.Name = "ajustes_stock"
        TreeNode36.Text = "Ajustes de stock"
        TreeNode37.Name = "registros_stock"
        TreeNode37.Text = "Ingreso de mercadería"
        TreeNode38.Name = "stock_menu"
        TreeNode38.Text = "Stock"
        TreeNode39.Name = "produccion"
        TreeNode39.Text = "Producción"
        TreeNode40.Name = "nuevopedido"
        TreeNode40.Text = "Nuevo pedido"
        TreeNode41.Name = "pedidos"
        TreeNode41.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode41.Text = "Pedidos"
        TreeNode42.Name = "cobros"
        TreeNode42.Text = "Cobros"
        TreeNode43.Name = "ventas"
        TreeNode43.Text = "Ventas"
        TreeNode44.Name = "stock"
        TreeNode44.Text = "Stock"
        TreeNode45.Name = "movStock"
        TreeNode45.Text = "Movimientos de stock"
        TreeNode46.Name = "consultasProductos"
        TreeNode46.Text = "Productos"
        TreeNode47.Name = "ccProveedores"
        TreeNode47.Text = "CC. Proveedores"
        TreeNode48.Name = "consultasProveedores"
        TreeNode48.Text = "Proveedores"
        TreeNode49.Name = "ccClientes"
        TreeNode49.Text = "CC. Clientes"
        TreeNode50.Name = "consultasClientes"
        TreeNode50.Text = "Clientes"
        TreeNode51.Name = "ultimoComprobante"
        TreeNode51.Text = "Último comprobante"
        TreeNode52.Name = "consultasFE"
        TreeNode52.Text = "Factura electrónica"
        TreeNode53.Name = "cpersonalizadas"
        TreeNode53.Text = "Personalizadas"
        TreeNode54.Name = "consultas"
        TreeNode54.Text = "Consultas"
        TreeNode55.Name = "configuracion"
        TreeNode55.Text = "Configuración"
        TreeNode56.Name = "acercade"
        TreeNode56.Text = "Acerca de..."
        TreeNode57.Name = "root"
        TreeNode57.Text = "Centrex"
        Me.Treev.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode57})
        Me.Treev.Size = New System.Drawing.Size(222, 600)
        Me.Treev.TabIndex = 23
        '
        'cmsPreciosMasivo
        '
        Me.cmsPreciosMasivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizaciónMasivaDePreciosToolStripMenuItem})
        Me.cmsPreciosMasivo.Name = "ContextMenuStrip1"
        Me.cmsPreciosMasivo.Size = New System.Drawing.Size(243, 26)
        '
        'ActualizaciónMasivaDePreciosToolStripMenuItem
        '
        Me.ActualizaciónMasivaDePreciosToolStripMenuItem.Name = "ActualizaciónMasivaDePreciosToolStripMenuItem"
        Me.ActualizaciónMasivaDePreciosToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.ActualizaciónMasivaDePreciosToolStripMenuItem.Text = "Actualización masiva de precios"
        '
        'cmd_pedido
        '
        Me.cmd_pedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_pedido.Location = New System.Drawing.Point(238, 705)
        Me.cmd_pedido.Name = "cmd_pedido"
        Me.cmd_pedido.Size = New System.Drawing.Size(213, 42)
        Me.cmd_pedido.TabIndex = 25
        Me.cmd_pedido.Text = "Nuevo pedido"
        Me.cmd_pedido.UseVisualStyleBackColor = True
        '
        'cmd_addcliente
        '
        Me.cmd_addcliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_addcliente.Location = New System.Drawing.Point(456, 705)
        Me.cmd_addcliente.Name = "cmd_addcliente"
        Me.cmd_addcliente.Size = New System.Drawing.Size(213, 42)
        Me.cmd_addcliente.TabIndex = 28
        Me.cmd_addcliente.Text = "Nuevo cliente"
        Me.cmd_addcliente.UseVisualStyleBackColor = True
        '
        'chk_rpt
        '
        Me.chk_rpt.AutoSize = True
        Me.chk_rpt.Checked = True
        Me.chk_rpt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_rpt.Location = New System.Drawing.Point(152, 67)
        Me.chk_rpt.Name = "chk_rpt"
        Me.chk_rpt.Size = New System.Drawing.Size(108, 17)
        Me.chk_rpt.TabIndex = 50
        Me.chk_rpt.Text = "Mostrar impresión"
        Me.chk_rpt.UseVisualStyleBackColor = True
        '
        'tooltip_advanceseach
        '
        Me.tooltip_advanceseach.ForeColor = System.Drawing.Color.Red
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.ContextMenuStrip = Me.cmsGeneral
        Me.dg_view.Location = New System.Drawing.Point(238, 90)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(891, 598)
        Me.dg_view.TabIndex = 53
        '
        'cmsGeneral
        '
        Me.cmsGeneral.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.cmsGeneral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem, Me.TerminarPedidoToolStripMenuItem, Me.DeshabilitarItemToolStripMenuItem, Me.MostrarFacturaToolStripMenuItem, Me.DuplicarPedidoToolStripMenuItem, Me.MostrarInformaciónDeAFIPToolStripMenuItem})
        Me.cmsGeneral.Name = "ContextMenuStrip"
        Me.cmsGeneral.Size = New System.Drawing.Size(227, 158)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        Me.EditarToolStripMenuItem.Visible = False
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'TerminarPedidoToolStripMenuItem
        '
        Me.TerminarPedidoToolStripMenuItem.Name = "TerminarPedidoToolStripMenuItem"
        Me.TerminarPedidoToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.TerminarPedidoToolStripMenuItem.Text = "Cerrar pedido"
        '
        'DeshabilitarItemToolStripMenuItem
        '
        Me.DeshabilitarItemToolStripMenuItem.Name = "DeshabilitarItemToolStripMenuItem"
        Me.DeshabilitarItemToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.DeshabilitarItemToolStripMenuItem.Text = "Desactivar item"
        '
        'MostrarFacturaToolStripMenuItem
        '
        Me.MostrarFacturaToolStripMenuItem.Name = "MostrarFacturaToolStripMenuItem"
        Me.MostrarFacturaToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.MostrarFacturaToolStripMenuItem.Text = "Ver pedido"
        '
        'DuplicarPedidoToolStripMenuItem
        '
        Me.DuplicarPedidoToolStripMenuItem.Name = "DuplicarPedidoToolStripMenuItem"
        Me.DuplicarPedidoToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.DuplicarPedidoToolStripMenuItem.Text = "Duplicar pedido"
        '
        'MostrarInformaciónDeAFIPToolStripMenuItem
        '
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Name = "MostrarInformaciónDeAFIPToolStripMenuItem"
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Text = "Mostrar información de AFIP"
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_version, Me.ToolStripStatusLabel2, Me.tss_dbInfo, Me.ToolStripStatusLabel1, Me.tss_hora})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 768)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1136, 22)
        Me.StatusStrip1.TabIndex = 54
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tss_version
        '
        Me.tss_version.Name = "tss_version"
        Me.tss_version.Size = New System.Drawing.Size(65, 17)
        Me.tss_version.Text = "%versión%"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(4, 17)
        '
        'tss_dbInfo
        '
        Me.tss_dbInfo.Name = "tss_dbInfo"
        Me.tss_dbInfo.Size = New System.Drawing.Size(62, 17)
        Me.tss_dbInfo.Text = "%dbInfo%"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(4, 17)
        '
        'tss_hora
        '
        Me.tss_hora.Name = "tss_hora"
        Me.tss_hora.Size = New System.Drawing.Size(51, 17)
        Me.tss_hora.Text = "%hora%"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'chk_test
        '
        Me.chk_test.AutoSize = True
        Me.chk_test.Location = New System.Drawing.Point(266, 67)
        Me.chk_test.Name = "chk_test"
        Me.chk_test.Size = New System.Drawing.Size(73, 17)
        Me.chk_test.TabIndex = 55
        Me.chk_test.Text = "Modo test"
        Me.chk_test.UseVisualStyleBackColor = True
        Me.chk_test.Visible = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'cmd_go
        '
        Me.cmd_go.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_go.Enabled = False
        Me.cmd_go.Location = New System.Drawing.Point(1100, 64)
        Me.cmd_go.Name = "cmd_go"
        Me.cmd_go.Size = New System.Drawing.Size(29, 20)
        Me.cmd_go.TabIndex = 66
        Me.cmd_go.Text = "Ir"
        Me.cmd_go.UseVisualStyleBackColor = True
        '
        'txt_nPage
        '
        Me.txt_nPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nPage.Enabled = False
        Me.txt_nPage.Location = New System.Drawing.Point(1031, 64)
        Me.txt_nPage.Name = "txt_nPage"
        Me.txt_nPage.Size = New System.Drawing.Size(63, 20)
        Me.txt_nPage.TabIndex = 65
        '
        'cmd_last
        '
        Me.cmd_last.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_last.Enabled = False
        Me.cmd_last.Location = New System.Drawing.Point(996, 64)
        Me.cmd_last.Name = "cmd_last"
        Me.cmd_last.Size = New System.Drawing.Size(29, 20)
        Me.cmd_last.TabIndex = 64
        Me.cmd_last.Text = ">>|"
        Me.cmd_last.UseVisualStyleBackColor = True
        '
        'cmd_next
        '
        Me.cmd_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_next.Enabled = False
        Me.cmd_next.Location = New System.Drawing.Point(950, 64)
        Me.cmd_next.Name = "cmd_next"
        Me.cmd_next.Size = New System.Drawing.Size(40, 20)
        Me.cmd_next.TabIndex = 63
        Me.cmd_next.Text = ">>"
        Me.cmd_next.UseVisualStyleBackColor = True
        '
        'cmd_prev
        '
        Me.cmd_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_prev.Enabled = False
        Me.cmd_prev.Location = New System.Drawing.Point(904, 64)
        Me.cmd_prev.Name = "cmd_prev"
        Me.cmd_prev.Size = New System.Drawing.Size(40, 20)
        Me.cmd_prev.TabIndex = 62
        Me.cmd_prev.Text = "<<"
        Me.cmd_prev.UseVisualStyleBackColor = True
        '
        'cmd_first
        '
        Me.cmd_first.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_first.Enabled = False
        Me.cmd_first.Location = New System.Drawing.Point(869, 64)
        Me.cmd_first.Name = "cmd_first"
        Me.cmd_first.Size = New System.Drawing.Size(29, 20)
        Me.cmd_first.TabIndex = 61
        Me.cmd_first.Text = "|<<"
        Me.cmd_first.UseVisualStyleBackColor = True
        '
        'txt_search
        '
        Me.txt_search.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_search.Location = New System.Drawing.Point(82, 22)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(986, 20)
        Me.txt_search.TabIndex = 67
        '
        'pic_search
        '
        Me.pic_search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_search.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_search.Location = New System.Drawing.Point(1091, 22)
        Me.pic_search.Name = "pic_search"
        Me.pic_search.Size = New System.Drawing.Size(22, 22)
        Me.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search.TabIndex = 69
        Me.pic_search.TabStop = False
        '
        'pic
        '
        Me.pic.Image = Global.Centrex.My.Resources.Resources.centrexlogo
        Me.pic.Location = New System.Drawing.Point(289, 222)
        Me.pic.Margin = New System.Windows.Forms.Padding(2)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(747, 341)
        Me.pic.TabIndex = 24
        Me.pic.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(404, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 24)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 790)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.pic_search)
        Me.Controls.Add(Me.lbl_borrarbusqueda)
        Me.Controls.Add(Me.cmd_go)
        Me.Controls.Add(Me.txt_nPage)
        Me.Controls.Add(Me.cmd_last)
        Me.Controls.Add(Me.cmd_next)
        Me.Controls.Add(Me.cmd_prev)
        Me.Controls.Add(Me.cmd_first)
        Me.Controls.Add(Me.chk_test)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.chk_rpt)
        Me.Controls.Add(Me.cmd_addcliente)
        Me.Controls.Add(Me.cmd_pedido)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.Treev)
        Me.Controls.Add(Me.chk_historicos)
        Me.Controls.Add(Me.lblbusqueda)
        Me.Controls.Add(Me.cmd_add)
        Me.Controls.Add(Me.dg_view)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Centrex"
        Me.cmsPreciosMasivo.ResumeLayout(False)
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsGeneral.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.pic_search, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents Centrex As WindowsApplication1.Centrex
    Friend WithEvents cmd_add As System.Windows.Forms.Button
    'Friend WithEvents ClienteTableAdapter1 As WindowsApplication1.Database1DataSetTableAdapters.clienteTableAdapter
    'Friend WithEvents Database1DataSet As WindowsApplication1.Database1DataSet
    Friend WithEvents lblbusqueda As System.Windows.Forms.Label
    Friend WithEvents chk_historicos As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Treev As System.Windows.Forms.TreeView
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_pedido As System.Windows.Forms.Button
    Friend WithEvents cmd_addcliente As System.Windows.Forms.Button
    Friend WithEvents chk_rpt As System.Windows.Forms.CheckBox
    Friend WithEvents tooltip_advanceseach As System.Windows.Forms.ToolTip
    Friend WithEvents dg_view As System.Windows.Forms.DataGridView
    Friend WithEvents cmsPreciosMasivo As ContextMenuStrip
    Friend WithEvents ActualizaciónMasivaDePreciosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tss_version As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tss_hora As ToolStripStatusLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents chk_test As System.Windows.Forms.CheckBox
    Friend WithEvents cmsGeneral As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminarPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeshabilitarItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MostrarFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DuplicarPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents MostrarInformaciónDeAFIPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmd_go As Button
    Friend WithEvents txt_nPage As TextBox
    Friend WithEvents cmd_last As Button
    Friend WithEvents cmd_next As Button
    Friend WithEvents cmd_prev As Button
    Friend WithEvents cmd_first As Button
    Friend WithEvents txt_search As TextBox
    Friend WithEvents pic_search As PictureBox
    Friend WithEvents lbl_borrarbusqueda As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tss_dbInfo As ToolStripStatusLabel
End Class
