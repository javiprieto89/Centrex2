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
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Exportaciones S.I.A.p")
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Movimientos de stock")
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos", New System.Windows.Forms.TreeNode() {TreeNode45, TreeNode46})
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CC. Proveedores")
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores", New System.Windows.Forms.TreeNode() {TreeNode48})
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CC. Clientes")
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes", New System.Windows.Forms.TreeNode() {TreeNode50})
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Último comprobante")
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Información factura")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pruebas AFIP")
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MercadoPago QR")
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Factura electrónica", New System.Windows.Forms.TreeNode() {TreeNode52, TreeNode53, TreeNode54, TreeNode55})
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Personalizadas")
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Exportaciones S.I.A.p")
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultas", New System.Windows.Forms.TreeNode() {TreeNode47, TreeNode49, TreeNode51, TreeNode56, TreeNode57, TreeNode58})
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración")
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Permisos")
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Perfiles")
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Usuarios")
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Asignar permisos a perfiles")
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Asignar perfiles a usuarios")
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguridad", New System.Windows.Forms.TreeNode() {TreeNode60, TreeNode61, TreeNode62, TreeNode63, TreeNode64, TreeNode65})
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración", New System.Windows.Forms.TreeNode() {TreeNode66})
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acerca de...")
        Dim TreeNode69 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Centrex", New System.Windows.Forms.TreeNode() {TreeNode31, TreeNode35, TreeNode38, TreeNode39, TreeNode43, TreeNode44, TreeNode59, TreeNode67, TreeNode68})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.cmd_add = New System.Windows.Forms.Button()
        Me.lbl_clientes = New System.Windows.Forms.Label()
        Me.lbl_proveedores = New System.Windows.Forms.Label()
        Me.lbl_items = New System.Windows.Forms.Label()
        Me.lbl_pedidos = New System.Windows.Forms.Label()
        Me.lbl_usuarios = New System.Windows.Forms.Label()
        Me.cmd_search = New System.Windows.Forms.Button()
        Me.cmd_refresh = New System.Windows.Forms.Button()
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
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_version = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_separador1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_dbInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_separador2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_usuario_logueado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_separador3 = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.tick_closeProgram = New System.Windows.Forms.Timer(Me.components)
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
        Me.cmd_add.Location = New System.Drawing.Point(27, 868)
        Me.cmd_add.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_add.Name = "cmd_add"
        Me.cmd_add.Size = New System.Drawing.Size(284, 52)
        Me.cmd_add.TabIndex = 3
        Me.cmd_add.Text = "Agregar"
        Me.cmd_add.UseVisualStyleBackColor = True
        '
        'lbl_clientes
        '
        Me.lbl_clientes.Location = New System.Drawing.Point(0, 0)
        Me.lbl_clientes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_clientes.Name = "lbl_clientes"
        Me.lbl_clientes.Size = New System.Drawing.Size(133, 28)
        Me.lbl_clientes.TabIndex = 71
        '
        'lbl_proveedores
        '
        Me.lbl_proveedores.Location = New System.Drawing.Point(0, 0)
        Me.lbl_proveedores.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_proveedores.Name = "lbl_proveedores"
        Me.lbl_proveedores.Size = New System.Drawing.Size(133, 28)
        Me.lbl_proveedores.TabIndex = 72
        '
        'lbl_items
        '
        Me.lbl_items.Location = New System.Drawing.Point(0, 0)
        Me.lbl_items.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_items.Name = "lbl_items"
        Me.lbl_items.Size = New System.Drawing.Size(133, 28)
        Me.lbl_items.TabIndex = 73
        '
        'lbl_pedidos
        '
        Me.lbl_pedidos.Location = New System.Drawing.Point(0, 0)
        Me.lbl_pedidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_pedidos.Name = "lbl_pedidos"
        Me.lbl_pedidos.Size = New System.Drawing.Size(133, 28)
        Me.lbl_pedidos.TabIndex = 74
        '
        'lbl_usuarios
        '
        Me.lbl_usuarios.Location = New System.Drawing.Point(0, 0)
        Me.lbl_usuarios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_usuarios.Name = "lbl_usuarios"
        Me.lbl_usuarios.Size = New System.Drawing.Size(133, 28)
        Me.lbl_usuarios.TabIndex = 75
        '
        'cmd_search
        '
        Me.cmd_search.Location = New System.Drawing.Point(0, 0)
        Me.cmd_search.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_search.Name = "cmd_search"
        Me.cmd_search.Size = New System.Drawing.Size(100, 28)
        Me.cmd_search.TabIndex = 76
        '
        'cmd_refresh
        '
        Me.cmd_refresh.Location = New System.Drawing.Point(0, 0)
        Me.cmd_refresh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_refresh.Name = "cmd_refresh"
        Me.cmd_refresh.Size = New System.Drawing.Size(100, 28)
        Me.cmd_refresh.TabIndex = 77
        '
        'lblbusqueda
        '
        Me.lblbusqueda.AutoSize = True
        Me.lblbusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbusqueda.Location = New System.Drawing.Point(17, 36)
        Me.lblbusqueda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblbusqueda.Name = "lblbusqueda"
        Me.lblbusqueda.Size = New System.Drawing.Size(80, 17)
        Me.lblbusqueda.TabIndex = 18
        Me.lblbusqueda.Text = "Búsqueda"
        '
        'chk_historicos
        '
        Me.chk_historicos.AutoSize = True
        Me.chk_historicos.Location = New System.Drawing.Point(15, 82)
        Me.chk_historicos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_historicos.Name = "chk_historicos"
        Me.chk_historicos.Size = New System.Drawing.Size(175, 21)
        Me.chk_historicos.TabIndex = 20
        Me.chk_historicos.Text = "Ver históricos/inactivos"
        Me.chk_historicos.UseVisualStyleBackColor = True
        '
        'lbl_borrarbusqueda
        '
        Me.lbl_borrarbusqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_borrarbusqueda.AutoSize = True
        Me.lbl_borrarbusqueda.Location = New System.Drawing.Point(1431, 36)
        Me.lbl_borrarbusqueda.Name = "lbl_borrarbusqueda"
        Me.lbl_borrarbusqueda.Size = New System.Drawing.Size(14, 17)
        Me.lbl_borrarbusqueda.TabIndex = 68
        Me.lbl_borrarbusqueda.Text = "x"
        Me.ToolTip1.SetToolTip(Me.lbl_borrarbusqueda, "Borrar búsqueda")
        '
        'Treev
        '
        Me.Treev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Treev.ContextMenuStrip = Me.cmsPreciosMasivo
        Me.Treev.Location = New System.Drawing.Point(15, 108)
        Me.Treev.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
        TreeNode44.Name = "exportSiap"
        TreeNode44.Text = "Exportaciones S.I.A.p"
        TreeNode45.Name = "stock"
        TreeNode45.Text = "Stock"
        TreeNode46.Name = "movStock"
        TreeNode46.Text = "Movimientos de stock"
        TreeNode47.Name = "consultasProductos"
        TreeNode47.Text = "Productos"
        TreeNode48.Name = "ccProveedores"
        TreeNode48.Text = "CC. Proveedores"
        TreeNode49.Name = "consultasProveedores"
        TreeNode49.Text = "Proveedores"
        TreeNode50.Name = "ccClientes"
        TreeNode50.Text = "CC. Clientes"
        TreeNode51.Name = "consultasClientes"
        TreeNode51.Text = "Clientes"
        TreeNode52.Name = "ultimoComprobante"
        TreeNode52.Text = "Último comprobante"
        TreeNode53.Name = "info_fc"
        TreeNode53.Text = "Información factura"
        TreeNode54.Name = "pruebasAFIP"
        TreeNode54.Text = "Pruebas AFIP"
        TreeNode55.Name = "mercadopagoQR"
        TreeNode55.Text = "MercadoPago QR"
        TreeNode56.Name = "consultasFE"
        TreeNode56.Text = "Factura electrónica"
        TreeNode57.Name = "cpersonalizadas"
        TreeNode57.Text = "Personalizadas"
        TreeNode58.Name = "exportSiap"
        TreeNode58.Text = "Exportaciones S.I.A.p"
        TreeNode59.Name = "consultas"
        TreeNode59.Text = "Consultas"
        TreeNode60.Name = "configuracion"
        TreeNode60.Text = "Configuración"
        TreeNode61.Name = "permisos"
        TreeNode61.Text = "Permisos"
        TreeNode62.Name = "perfiles"
        TreeNode62.Text = "Perfiles"
        TreeNode63.Name = "usuarios"
        TreeNode63.Text = "Usuarios"
        TreeNode64.Name = "permisos_a_perfiles"
        TreeNode64.Text = "Asignar permisos a perfiles"
        TreeNode65.Name = "perfiles_a_usuarios"
        TreeNode65.Text = "Asignar perfiles a usuarios"
        TreeNode66.Name = "seguridad"
        TreeNode66.Text = "Seguridad"
        TreeNode67.Name = "cfg_menu"
        TreeNode67.Text = "Configuración"
        TreeNode68.Name = "acercade"
        TreeNode68.Text = "Acerca de..."
        TreeNode69.Name = "root"
        TreeNode69.Text = "Centrex"
        Me.Treev.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode69})
        Me.Treev.Size = New System.Drawing.Size(295, 738)
        Me.Treev.TabIndex = 23
        '
        'cmsPreciosMasivo
        '
        Me.cmsPreciosMasivo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsPreciosMasivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizaciónMasivaDePreciosToolStripMenuItem})
        Me.cmsPreciosMasivo.Name = "ContextMenuStrip1"
        Me.cmsPreciosMasivo.Size = New System.Drawing.Size(291, 28)
        '
        'ActualizaciónMasivaDePreciosToolStripMenuItem
        '
        Me.ActualizaciónMasivaDePreciosToolStripMenuItem.Name = "ActualizaciónMasivaDePreciosToolStripMenuItem"
        Me.ActualizaciónMasivaDePreciosToolStripMenuItem.Size = New System.Drawing.Size(290, 24)
        Me.ActualizaciónMasivaDePreciosToolStripMenuItem.Text = "Actualización masiva de precios"
        '
        'cmd_pedido
        '
        Me.cmd_pedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_pedido.Location = New System.Drawing.Point(317, 868)
        Me.cmd_pedido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_pedido.Name = "cmd_pedido"
        Me.cmd_pedido.Size = New System.Drawing.Size(284, 52)
        Me.cmd_pedido.TabIndex = 25
        Me.cmd_pedido.Text = "Nuevo pedido"
        Me.cmd_pedido.UseVisualStyleBackColor = True
        '
        'cmd_addcliente
        '
        Me.cmd_addcliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_addcliente.Location = New System.Drawing.Point(608, 868)
        Me.cmd_addcliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_addcliente.Name = "cmd_addcliente"
        Me.cmd_addcliente.Size = New System.Drawing.Size(284, 52)
        Me.cmd_addcliente.TabIndex = 28
        Me.cmd_addcliente.Text = "Nuevo cliente"
        Me.cmd_addcliente.UseVisualStyleBackColor = True
        '
        'chk_rpt
        '
        Me.chk_rpt.AutoSize = True
        Me.chk_rpt.Checked = True
        Me.chk_rpt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_rpt.Location = New System.Drawing.Point(203, 82)
        Me.chk_rpt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_rpt.Name = "chk_rpt"
        Me.chk_rpt.Size = New System.Drawing.Size(143, 21)
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
        Me.dg_view.Location = New System.Drawing.Point(317, 111)
        Me.dg_view.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(1188, 736)
        Me.dg_view.TabIndex = 53
        '
        'cmsGeneral
        '
        Me.cmsGeneral.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.cmsGeneral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem, Me.TerminarPedidoToolStripMenuItem, Me.DeshabilitarItemToolStripMenuItem, Me.MostrarFacturaToolStripMenuItem, Me.DuplicarPedidoToolStripMenuItem, Me.MostrarInformaciónDeAFIPToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.cmsGeneral.Name = "ContextMenuStrip"
        Me.cmsGeneral.Size = New System.Drawing.Size(268, 196)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.EditarToolStripMenuItem.Text = "Editar"
        Me.EditarToolStripMenuItem.Visible = False
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'TerminarPedidoToolStripMenuItem
        '
        Me.TerminarPedidoToolStripMenuItem.Name = "TerminarPedidoToolStripMenuItem"
        Me.TerminarPedidoToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.TerminarPedidoToolStripMenuItem.Text = "Cerrar pedido"
        '
        'DeshabilitarItemToolStripMenuItem
        '
        Me.DeshabilitarItemToolStripMenuItem.Name = "DeshabilitarItemToolStripMenuItem"
        Me.DeshabilitarItemToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.DeshabilitarItemToolStripMenuItem.Text = "Desactivar item"
        '
        'MostrarFacturaToolStripMenuItem
        '
        Me.MostrarFacturaToolStripMenuItem.Name = "MostrarFacturaToolStripMenuItem"
        Me.MostrarFacturaToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.MostrarFacturaToolStripMenuItem.Text = "Ver pedido"
        '
        'DuplicarPedidoToolStripMenuItem
        '
        Me.DuplicarPedidoToolStripMenuItem.Name = "DuplicarPedidoToolStripMenuItem"
        Me.DuplicarPedidoToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.DuplicarPedidoToolStripMenuItem.Text = "Duplicar pedido"
        '
        'MostrarInformaciónDeAFIPToolStripMenuItem
        '
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Name = "MostrarInformaciónDeAFIPToolStripMenuItem"
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Text = "Mostrar información de AFIP"
        Me.MostrarInformaciónDeAFIPToolStripMenuItem.Visible = False
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(267, 24)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_version, Me.tss_separador1, Me.tss_dbInfo, Me.tss_separador2, Me.tss_usuario_logueado, Me.tss_separador3, Me.tss_hora})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 947)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1515, 25)
        Me.StatusStrip1.TabIndex = 54
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tss_version
        '
        Me.tss_version.Name = "tss_version"
        Me.tss_version.Size = New System.Drawing.Size(80, 20)
        Me.tss_version.Text = "%versión%"
        '
        'tss_separador1
        '
        Me.tss_separador1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.tss_separador1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tss_separador1.Name = "tss_separador1"
        Me.tss_separador1.Size = New System.Drawing.Size(4, 20)
        '
        'tss_dbInfo
        '
        Me.tss_dbInfo.Name = "tss_dbInfo"
        Me.tss_dbInfo.Size = New System.Drawing.Size(77, 20)
        Me.tss_dbInfo.Text = "%dbInfo%"
        '
        'tss_separador2
        '
        Me.tss_separador2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.tss_separador2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tss_separador2.Name = "tss_separador2"
        Me.tss_separador2.Size = New System.Drawing.Size(4, 20)
        '
        'tss_usuario_logueado
        '
        Me.tss_usuario_logueado.Name = "tss_usuario_logueado"
        Me.tss_usuario_logueado.Size = New System.Drawing.Size(151, 20)
        Me.tss_usuario_logueado.Text = "%usuario_logueado%"
        '
        'tss_separador3
        '
        Me.tss_separador3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.tss_separador3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tss_separador3.Name = "tss_separador3"
        Me.tss_separador3.Size = New System.Drawing.Size(4, 20)
        '
        'tss_hora
        '
        Me.tss_hora.Name = "tss_hora"
        Me.tss_hora.Size = New System.Drawing.Size(63, 20)
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
        Me.chk_test.Location = New System.Drawing.Point(355, 82)
        Me.chk_test.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chk_test.Name = "chk_test"
        Me.chk_test.Size = New System.Drawing.Size(92, 21)
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
        Me.cmd_go.Location = New System.Drawing.Point(1467, 79)
        Me.cmd_go.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_go.Name = "cmd_go"
        Me.cmd_go.Size = New System.Drawing.Size(39, 25)
        Me.cmd_go.TabIndex = 66
        Me.cmd_go.Text = "Ir"
        Me.cmd_go.UseVisualStyleBackColor = True
        '
        'txt_nPage
        '
        Me.txt_nPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nPage.Enabled = False
        Me.txt_nPage.Location = New System.Drawing.Point(1375, 79)
        Me.txt_nPage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_nPage.Name = "txt_nPage"
        Me.txt_nPage.Size = New System.Drawing.Size(83, 22)
        Me.txt_nPage.TabIndex = 65
        '
        'cmd_last
        '
        Me.cmd_last.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_last.Enabled = False
        Me.cmd_last.Location = New System.Drawing.Point(1328, 79)
        Me.cmd_last.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_last.Name = "cmd_last"
        Me.cmd_last.Size = New System.Drawing.Size(39, 25)
        Me.cmd_last.TabIndex = 64
        Me.cmd_last.Text = ">>|"
        Me.cmd_last.UseVisualStyleBackColor = True
        '
        'cmd_next
        '
        Me.cmd_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_next.Enabled = False
        Me.cmd_next.Location = New System.Drawing.Point(1267, 79)
        Me.cmd_next.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_next.Name = "cmd_next"
        Me.cmd_next.Size = New System.Drawing.Size(53, 25)
        Me.cmd_next.TabIndex = 63
        Me.cmd_next.Text = ">>"
        Me.cmd_next.UseVisualStyleBackColor = True
        '
        'cmd_prev
        '
        Me.cmd_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_prev.Enabled = False
        Me.cmd_prev.Location = New System.Drawing.Point(1205, 79)
        Me.cmd_prev.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_prev.Name = "cmd_prev"
        Me.cmd_prev.Size = New System.Drawing.Size(53, 25)
        Me.cmd_prev.TabIndex = 62
        Me.cmd_prev.Text = "<<"
        Me.cmd_prev.UseVisualStyleBackColor = True
        '
        'cmd_first
        '
        Me.cmd_first.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_first.Enabled = False
        Me.cmd_first.Location = New System.Drawing.Point(1159, 79)
        Me.cmd_first.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmd_first.Name = "cmd_first"
        Me.cmd_first.Size = New System.Drawing.Size(39, 25)
        Me.cmd_first.TabIndex = 61
        Me.cmd_first.Text = "|<<"
        Me.cmd_first.UseVisualStyleBackColor = True
        '
        'txt_search
        '
        Me.txt_search.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_search.Location = New System.Drawing.Point(109, 27)
        Me.txt_search.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(1313, 22)
        Me.txt_search.TabIndex = 67
        '
        'pic_search
        '
        Me.pic_search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_search.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_search.Location = New System.Drawing.Point(1455, 27)
        Me.pic_search.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pic_search.Name = "pic_search"
        Me.pic_search.Size = New System.Drawing.Size(22, 22)
        Me.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search.TabIndex = 69
        Me.pic_search.TabStop = False
        '
        'pic
        '
        Me.pic.Image = Global.Centrex.My.Resources.Resources.centrexlogo
        Me.pic.Location = New System.Drawing.Point(385, 273)
        Me.pic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(996, 420)
        Me.pic.TabIndex = 24
        Me.pic.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(561, 74)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 30)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'tick_closeProgram
        '
        Me.tick_closeProgram.Interval = 600000
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1515, 972)
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
        Me.Controls.Add(Me.lbl_clientes)
        Me.Controls.Add(Me.lbl_proveedores)
        Me.Controls.Add(Me.lbl_items)
        Me.Controls.Add(Me.lbl_pedidos)
        Me.Controls.Add(Me.lbl_usuarios)
        Me.Controls.Add(Me.cmd_search)
        Me.Controls.Add(Me.cmd_refresh)
        Me.Controls.Add(Me.dg_view)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Centrex"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
    Friend WithEvents lbl_clientes As System.Windows.Forms.Label
    Friend WithEvents lbl_proveedores As System.Windows.Forms.Label
    Friend WithEvents lbl_items As System.Windows.Forms.Label
    Friend WithEvents lbl_pedidos As System.Windows.Forms.Label
    Friend WithEvents lbl_usuarios As System.Windows.Forms.Label
    Friend WithEvents cmd_search As System.Windows.Forms.Button
    Friend WithEvents cmd_refresh As System.Windows.Forms.Button
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
    Friend WithEvents tss_separador3 As ToolStripStatusLabel
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
    Friend WithEvents tss_separador1 As ToolStripStatusLabel
    Friend WithEvents tss_dbInfo As ToolStripStatusLabel
    Friend WithEvents tick_closeProgram As Timer
    Friend WithEvents AnularToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tss_separador2 As ToolStripStatusLabel
    Friend WithEvents tss_usuario_logueado As ToolStripStatusLabel
End Class
