<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_comprobantes_compras
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
        Me.lbl_tipoComprobante = New System.Windows.Forms.Label()
        Me.cmb_tipoComprobante = New System.Windows.Forms.ComboBox()
        Me.cmb_cc = New System.Windows.Forms.ComboBox()
        Me.lbl_ccp = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fechaComprobanteCompra = New System.Windows.Forms.DateTimePicker()
        Me.lbl_fechaCarga = New System.Windows.Forms.Label()
        Me.lbl_fechaComprobante = New System.Windows.Forms.Label()
        Me.lblFechaCarga = New System.Windows.Forms.Label()
        Me.tbl_comprobantesCompras = New System.Windows.Forms.TabControl()
        Me.productos = New System.Windows.Forms.TabPage()
        Me.dg_viewItems = New System.Windows.Forms.DataGridView()
        Me.cms_general = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.editar = New System.Windows.Forms.ToolStripMenuItem()
        Me.eliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.impuestos = New System.Windows.Forms.TabPage()
        Me.dg_viewImpuestos = New System.Windows.Forms.DataGridView()
        Me.conceptos = New System.Windows.Forms.TabPage()
        Me.dg_viewConceptos = New System.Windows.Forms.DataGridView()
        Me.notas = New System.Windows.Forms.TabPage()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_agregar = New System.Windows.Forms.Button()
        Me.lbl_totalItems = New System.Windows.Forms.Label()
        Me.txt_totalItems = New System.Windows.Forms.TextBox()
        Me.txt_totalConceptos = New System.Windows.Forms.TextBox()
        Me.lbl_totalConceptos = New System.Windows.Forms.Label()
        Me.txt_totalImpuestos = New System.Windows.Forms.TextBox()
        Me.lbl_totalImpuestos = New System.Windows.Forms.Label()
        Me.txt_totalFactura = New System.Windows.Forms.TextBox()
        Me.lbl_totalFactura = New System.Windows.Forms.Label()
        Me.lbl_moneda = New System.Windows.Forms.Label()
        Me.cmb_moneda = New System.Windows.Forms.ComboBox()
        Me.lbl_tasaCambio = New System.Windows.Forms.Label()
        Me.txt_tasaCambio = New System.Windows.Forms.TextBox()
        Me.cmb_condicionCompra = New System.Windows.Forms.ComboBox()
        Me.lbl_condicionCompra = New System.Windows.Forms.Label()
        Me.lbl_puntoVenta = New System.Windows.Forms.Label()
        Me.txt_puntoVenta = New System.Windows.Forms.TextBox()
        Me.lbl_numeroComprobante = New System.Windows.Forms.Label()
        Me.txt_numeroComprobante = New System.Windows.Forms.TextBox()
        Me.cmd_confirmar = New System.Windows.Forms.Button()
        Me.txt_CAE = New System.Windows.Forms.TextBox()
        Me.lbl_CAE = New System.Windows.Forms.Label()
        Me.cmd_editar = New System.Windows.Forms.Button()
        Me.pic_searchCondicionCompra = New System.Windows.Forms.PictureBox()
        Me.pic_searchCCProveedor = New System.Windows.Forms.PictureBox()
        Me.pic_searchProveedor = New System.Windows.Forms.PictureBox()
        Me.txt_totalOriginal = New System.Windows.Forms.TextBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.pic_searchTipoComprobante = New System.Windows.Forms.PictureBox()
        Me.tbl_comprobantesCompras.SuspendLayout()
        Me.productos.SuspendLayout()
        CType(Me.dg_viewItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_general.SuspendLayout()
        Me.impuestos.SuspendLayout()
        CType(Me.dg_viewImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.conceptos.SuspendLayout()
        CType(Me.dg_viewConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.notas.SuspendLayout()
        CType(Me.pic_searchCondicionCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchCCProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchTipoComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_tipoComprobante
        '
        Me.lbl_tipoComprobante.AutoSize = True
        Me.lbl_tipoComprobante.Location = New System.Drawing.Point(12, 125)
        Me.lbl_tipoComprobante.Name = "lbl_tipoComprobante"
        Me.lbl_tipoComprobante.Size = New System.Drawing.Size(108, 13)
        Me.lbl_tipoComprobante.TabIndex = 0
        Me.lbl_tipoComprobante.Text = "Tipo de comprobante"
        '
        'cmb_tipoComprobante
        '
        Me.cmb_tipoComprobante.FormattingEnabled = True
        Me.cmb_tipoComprobante.Location = New System.Drawing.Point(165, 123)
        Me.cmb_tipoComprobante.Name = "cmb_tipoComprobante"
        Me.cmb_tipoComprobante.Size = New System.Drawing.Size(215, 21)
        Me.cmb_tipoComprobante.TabIndex = 1
        '
        'cmb_cc
        '
        Me.cmb_cc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cc.FormattingEnabled = True
        Me.cmb_cc.Location = New System.Drawing.Point(530, 45)
        Me.cmb_cc.Name = "cmb_cc"
        Me.cmb_cc.Size = New System.Drawing.Size(281, 21)
        Me.cmb_cc.TabIndex = 659
        '
        'lbl_ccp
        '
        Me.lbl_ccp.Location = New System.Drawing.Point(428, 45)
        Me.lbl_ccp.Name = "lbl_ccp"
        Me.lbl_ccp.Size = New System.Drawing.Size(98, 29)
        Me.lbl_ccp.TabIndex = 663
        Me.lbl_ccp.Text = "Cuenta corriente del proveedor"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(165, 45)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(215, 21)
        Me.cmb_proveedor.TabIndex = 657
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 661
        Me.Label1.Text = "Proveedor"
        '
        'dtp_fechaComprobanteCompra
        '
        Me.dtp_fechaComprobanteCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fechaComprobanteCompra.Location = New System.Drawing.Point(576, 7)
        Me.dtp_fechaComprobanteCompra.Name = "dtp_fechaComprobanteCompra"
        Me.dtp_fechaComprobanteCompra.Size = New System.Drawing.Size(104, 20)
        Me.dtp_fechaComprobanteCompra.TabIndex = 655
        '
        'lbl_fechaCarga
        '
        Me.lbl_fechaCarga.AutoSize = True
        Me.lbl_fechaCarga.Location = New System.Drawing.Point(165, 13)
        Me.lbl_fechaCarga.Name = "lbl_fechaCarga"
        Me.lbl_fechaCarga.Size = New System.Drawing.Size(50, 13)
        Me.lbl_fechaCarga.TabIndex = 660
        Me.lbl_fechaCarga.Text = "%carga%"
        '
        'lbl_fechaComprobante
        '
        Me.lbl_fechaComprobante.AutoSize = True
        Me.lbl_fechaComprobante.Location = New System.Drawing.Point(430, 12)
        Me.lbl_fechaComprobante.Name = "lbl_fechaComprobante"
        Me.lbl_fechaComprobante.Size = New System.Drawing.Size(120, 13)
        Me.lbl_fechaComprobante.TabIndex = 658
        Me.lbl_fechaComprobante.Text = "Fecha de comprobante:"
        '
        'lblFechaCarga
        '
        Me.lblFechaCarga.AutoSize = True
        Me.lblFechaCarga.Location = New System.Drawing.Point(12, 13)
        Me.lblFechaCarga.Name = "lblFechaCarga"
        Me.lblFechaCarga.Size = New System.Drawing.Size(85, 13)
        Me.lblFechaCarga.TabIndex = 656
        Me.lblFechaCarga.Text = "Fecha de carga:"
        '
        'tbl_comprobantesCompras
        '
        Me.tbl_comprobantesCompras.Controls.Add(Me.productos)
        Me.tbl_comprobantesCompras.Controls.Add(Me.impuestos)
        Me.tbl_comprobantesCompras.Controls.Add(Me.conceptos)
        Me.tbl_comprobantesCompras.Controls.Add(Me.notas)
        Me.tbl_comprobantesCompras.Enabled = False
        Me.tbl_comprobantesCompras.Location = New System.Drawing.Point(10, 233)
        Me.tbl_comprobantesCompras.Name = "tbl_comprobantesCompras"
        Me.tbl_comprobantesCompras.SelectedIndex = 0
        Me.tbl_comprobantesCompras.Size = New System.Drawing.Size(812, 291)
        Me.tbl_comprobantesCompras.TabIndex = 665
        '
        'productos
        '
        Me.productos.BackColor = System.Drawing.SystemColors.Control
        Me.productos.Controls.Add(Me.dg_viewItems)
        Me.productos.Location = New System.Drawing.Point(4, 22)
        Me.productos.Name = "productos"
        Me.productos.Padding = New System.Windows.Forms.Padding(3)
        Me.productos.Size = New System.Drawing.Size(804, 265)
        Me.productos.TabIndex = 0
        Me.productos.Text = "Productos"
        '
        'dg_viewItems
        '
        Me.dg_viewItems.AllowUserToAddRows = False
        Me.dg_viewItems.AllowUserToDeleteRows = False
        Me.dg_viewItems.AllowUserToOrderColumns = True
        Me.dg_viewItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_viewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewItems.ContextMenuStrip = Me.cms_general
        Me.dg_viewItems.Location = New System.Drawing.Point(6, 6)
        Me.dg_viewItems.MultiSelect = False
        Me.dg_viewItems.Name = "dg_viewItems"
        Me.dg_viewItems.ReadOnly = True
        Me.dg_viewItems.RowHeadersVisible = False
        Me.dg_viewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewItems.Size = New System.Drawing.Size(791, 253)
        Me.dg_viewItems.TabIndex = 694
        '
        'cms_general
        '
        Me.cms_general.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.editar, Me.eliminar})
        Me.cms_general.Name = "cms_general"
        Me.cms_general.Size = New System.Drawing.Size(118, 48)
        '
        'editar
        '
        Me.editar.Name = "editar"
        Me.editar.Size = New System.Drawing.Size(117, 22)
        Me.editar.Text = "Editar"
        '
        'eliminar
        '
        Me.eliminar.Name = "eliminar"
        Me.eliminar.Size = New System.Drawing.Size(117, 22)
        Me.eliminar.Text = "Eliminar"
        '
        'impuestos
        '
        Me.impuestos.BackColor = System.Drawing.SystemColors.Control
        Me.impuestos.Controls.Add(Me.dg_viewImpuestos)
        Me.impuestos.Location = New System.Drawing.Point(4, 22)
        Me.impuestos.Name = "impuestos"
        Me.impuestos.Padding = New System.Windows.Forms.Padding(3)
        Me.impuestos.Size = New System.Drawing.Size(804, 265)
        Me.impuestos.TabIndex = 1
        Me.impuestos.Text = "Impuestos"
        '
        'dg_viewImpuestos
        '
        Me.dg_viewImpuestos.AllowUserToAddRows = False
        Me.dg_viewImpuestos.AllowUserToDeleteRows = False
        Me.dg_viewImpuestos.AllowUserToOrderColumns = True
        Me.dg_viewImpuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_viewImpuestos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewImpuestos.Location = New System.Drawing.Point(6, 6)
        Me.dg_viewImpuestos.MultiSelect = False
        Me.dg_viewImpuestos.Name = "dg_viewImpuestos"
        Me.dg_viewImpuestos.ReadOnly = True
        Me.dg_viewImpuestos.RowHeadersVisible = False
        Me.dg_viewImpuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewImpuestos.Size = New System.Drawing.Size(791, 253)
        Me.dg_viewImpuestos.TabIndex = 694
        '
        'conceptos
        '
        Me.conceptos.BackColor = System.Drawing.SystemColors.Control
        Me.conceptos.Controls.Add(Me.dg_viewConceptos)
        Me.conceptos.Location = New System.Drawing.Point(4, 22)
        Me.conceptos.Name = "conceptos"
        Me.conceptos.Size = New System.Drawing.Size(804, 265)
        Me.conceptos.TabIndex = 2
        Me.conceptos.Text = "Conceptos"
        '
        'dg_viewConceptos
        '
        Me.dg_viewConceptos.AllowUserToAddRows = False
        Me.dg_viewConceptos.AllowUserToDeleteRows = False
        Me.dg_viewConceptos.AllowUserToOrderColumns = True
        Me.dg_viewConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_viewConceptos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewConceptos.Location = New System.Drawing.Point(6, 6)
        Me.dg_viewConceptos.MultiSelect = False
        Me.dg_viewConceptos.Name = "dg_viewConceptos"
        Me.dg_viewConceptos.ReadOnly = True
        Me.dg_viewConceptos.RowHeadersVisible = False
        Me.dg_viewConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewConceptos.Size = New System.Drawing.Size(791, 253)
        Me.dg_viewConceptos.TabIndex = 694
        '
        'notas
        '
        Me.notas.BackColor = System.Drawing.SystemColors.Control
        Me.notas.Controls.Add(Me.txt_notas)
        Me.notas.Location = New System.Drawing.Point(4, 22)
        Me.notas.Name = "notas"
        Me.notas.Size = New System.Drawing.Size(804, 265)
        Me.notas.TabIndex = 3
        Me.notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(6, 6)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(812, 254)
        Me.txt_notas.TabIndex = 0
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(437, 686)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 667
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Enabled = False
        Me.cmd_ok.Location = New System.Drawing.Point(339, 686)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 666
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_agregar
        '
        Me.cmd_agregar.Enabled = False
        Me.cmd_agregar.Location = New System.Drawing.Point(10, 540)
        Me.cmd_agregar.Name = "cmd_agregar"
        Me.cmd_agregar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_agregar.TabIndex = 668
        Me.cmd_agregar.Text = "Agregar"
        Me.cmd_agregar.UseVisualStyleBackColor = True
        '
        'lbl_totalItems
        '
        Me.lbl_totalItems.AutoSize = True
        Me.lbl_totalItems.Location = New System.Drawing.Point(10, 584)
        Me.lbl_totalItems.Name = "lbl_totalItems"
        Me.lbl_totalItems.Size = New System.Drawing.Size(81, 13)
        Me.lbl_totalItems.TabIndex = 669
        Me.lbl_totalItems.Text = "Total productos"
        '
        'txt_totalItems
        '
        Me.txt_totalItems.Location = New System.Drawing.Point(111, 581)
        Me.txt_totalItems.Name = "txt_totalItems"
        Me.txt_totalItems.ReadOnly = True
        Me.txt_totalItems.Size = New System.Drawing.Size(128, 20)
        Me.txt_totalItems.TabIndex = 670
        '
        'txt_totalConceptos
        '
        Me.txt_totalConceptos.Location = New System.Drawing.Point(588, 577)
        Me.txt_totalConceptos.Name = "txt_totalConceptos"
        Me.txt_totalConceptos.ReadOnly = True
        Me.txt_totalConceptos.Size = New System.Drawing.Size(128, 20)
        Me.txt_totalConceptos.TabIndex = 672
        '
        'lbl_totalConceptos
        '
        Me.lbl_totalConceptos.AutoSize = True
        Me.lbl_totalConceptos.Location = New System.Drawing.Point(490, 580)
        Me.lbl_totalConceptos.Name = "lbl_totalConceptos"
        Me.lbl_totalConceptos.Size = New System.Drawing.Size(84, 13)
        Me.lbl_totalConceptos.TabIndex = 671
        Me.lbl_totalConceptos.Text = "Total conceptos"
        '
        'txt_totalImpuestos
        '
        Me.txt_totalImpuestos.Location = New System.Drawing.Point(348, 581)
        Me.txt_totalImpuestos.Name = "txt_totalImpuestos"
        Me.txt_totalImpuestos.ReadOnly = True
        Me.txt_totalImpuestos.Size = New System.Drawing.Size(128, 20)
        Me.txt_totalImpuestos.TabIndex = 674
        '
        'lbl_totalImpuestos
        '
        Me.lbl_totalImpuestos.AutoSize = True
        Me.lbl_totalImpuestos.Location = New System.Drawing.Point(253, 584)
        Me.lbl_totalImpuestos.Name = "lbl_totalImpuestos"
        Me.lbl_totalImpuestos.Size = New System.Drawing.Size(81, 13)
        Me.lbl_totalImpuestos.TabIndex = 673
        Me.lbl_totalImpuestos.Text = "Total impuestos"
        '
        'txt_totalFactura
        '
        Me.txt_totalFactura.Location = New System.Drawing.Point(111, 625)
        Me.txt_totalFactura.Name = "txt_totalFactura"
        Me.txt_totalFactura.ReadOnly = True
        Me.txt_totalFactura.Size = New System.Drawing.Size(128, 20)
        Me.txt_totalFactura.TabIndex = 676
        '
        'lbl_totalFactura
        '
        Me.lbl_totalFactura.AutoSize = True
        Me.lbl_totalFactura.Location = New System.Drawing.Point(10, 625)
        Me.lbl_totalFactura.Name = "lbl_totalFactura"
        Me.lbl_totalFactura.Size = New System.Drawing.Size(67, 13)
        Me.lbl_totalFactura.TabIndex = 675
        Me.lbl_totalFactura.Text = "Total factura"
        '
        'lbl_moneda
        '
        Me.lbl_moneda.AutoSize = True
        Me.lbl_moneda.Location = New System.Drawing.Point(428, 92)
        Me.lbl_moneda.Name = "lbl_moneda"
        Me.lbl_moneda.Size = New System.Drawing.Size(46, 13)
        Me.lbl_moneda.TabIndex = 678
        Me.lbl_moneda.Text = "Moneda"
        '
        'cmb_moneda
        '
        Me.cmb_moneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_moneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_moneda.Enabled = False
        Me.cmb_moneda.FormattingEnabled = True
        Me.cmb_moneda.Location = New System.Drawing.Point(530, 90)
        Me.cmb_moneda.Name = "cmb_moneda"
        Me.cmb_moneda.Size = New System.Drawing.Size(54, 21)
        Me.cmb_moneda.TabIndex = 679
        '
        'lbl_tasaCambio
        '
        Me.lbl_tasaCambio.Location = New System.Drawing.Point(611, 90)
        Me.lbl_tasaCambio.Name = "lbl_tasaCambio"
        Me.lbl_tasaCambio.Size = New System.Drawing.Size(57, 31)
        Me.lbl_tasaCambio.TabIndex = 680
        Me.lbl_tasaCambio.Text = "Tasa de cambio"
        '
        'txt_tasaCambio
        '
        Me.txt_tasaCambio.Location = New System.Drawing.Point(683, 87)
        Me.txt_tasaCambio.Name = "txt_tasaCambio"
        Me.txt_tasaCambio.Size = New System.Drawing.Size(128, 20)
        Me.txt_tasaCambio.TabIndex = 681
        '
        'cmb_condicionCompra
        '
        Me.cmb_condicionCompra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_condicionCompra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_condicionCompra.FormattingEnabled = True
        Me.cmb_condicionCompra.Location = New System.Drawing.Point(165, 84)
        Me.cmb_condicionCompra.Name = "cmb_condicionCompra"
        Me.cmb_condicionCompra.Size = New System.Drawing.Size(215, 21)
        Me.cmb_condicionCompra.TabIndex = 682
        '
        'lbl_condicionCompra
        '
        Me.lbl_condicionCompra.AutoSize = True
        Me.lbl_condicionCompra.Location = New System.Drawing.Point(12, 88)
        Me.lbl_condicionCompra.Name = "lbl_condicionCompra"
        Me.lbl_condicionCompra.Size = New System.Drawing.Size(107, 13)
        Me.lbl_condicionCompra.TabIndex = 683
        Me.lbl_condicionCompra.Text = "Condición de compra"
        '
        'lbl_puntoVenta
        '
        Me.lbl_puntoVenta.AutoSize = True
        Me.lbl_puntoVenta.Location = New System.Drawing.Point(428, 139)
        Me.lbl_puntoVenta.Name = "lbl_puntoVenta"
        Me.lbl_puntoVenta.Size = New System.Drawing.Size(80, 13)
        Me.lbl_puntoVenta.TabIndex = 685
        Me.lbl_puntoVenta.Text = "Punto de venta"
        '
        'txt_puntoVenta
        '
        Me.txt_puntoVenta.Location = New System.Drawing.Point(530, 136)
        Me.txt_puntoVenta.Name = "txt_puntoVenta"
        Me.txt_puntoVenta.Size = New System.Drawing.Size(54, 20)
        Me.txt_puntoVenta.TabIndex = 686
        '
        'lbl_numeroComprobante
        '
        Me.lbl_numeroComprobante.Location = New System.Drawing.Point(611, 131)
        Me.lbl_numeroComprobante.Name = "lbl_numeroComprobante"
        Me.lbl_numeroComprobante.Size = New System.Drawing.Size(69, 29)
        Me.lbl_numeroComprobante.TabIndex = 687
        Me.lbl_numeroComprobante.Text = "Número de comprobante"
        '
        'txt_numeroComprobante
        '
        Me.txt_numeroComprobante.Location = New System.Drawing.Point(683, 135)
        Me.txt_numeroComprobante.Name = "txt_numeroComprobante"
        Me.txt_numeroComprobante.Size = New System.Drawing.Size(128, 20)
        Me.txt_numeroComprobante.TabIndex = 688
        '
        'cmd_confirmar
        '
        Me.cmd_confirmar.Location = New System.Drawing.Point(10, 195)
        Me.cmd_confirmar.Name = "cmd_confirmar"
        Me.cmd_confirmar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_confirmar.TabIndex = 689
        Me.cmd_confirmar.Text = "Confirmar"
        Me.cmd_confirmar.UseVisualStyleBackColor = True
        '
        'txt_CAE
        '
        Me.txt_CAE.Location = New System.Drawing.Point(165, 162)
        Me.txt_CAE.Name = "txt_CAE"
        Me.txt_CAE.Size = New System.Drawing.Size(215, 20)
        Me.txt_CAE.TabIndex = 691
        '
        'lbl_CAE
        '
        Me.lbl_CAE.AutoSize = True
        Me.lbl_CAE.Location = New System.Drawing.Point(12, 162)
        Me.lbl_CAE.Name = "lbl_CAE"
        Me.lbl_CAE.Size = New System.Drawing.Size(50, 13)
        Me.lbl_CAE.TabIndex = 690
        Me.lbl_CAE.Text = "CAE/CAI"
        '
        'cmd_editar
        '
        Me.cmd_editar.Enabled = False
        Me.cmd_editar.Location = New System.Drawing.Point(111, 195)
        Me.cmd_editar.Name = "cmd_editar"
        Me.cmd_editar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_editar.TabIndex = 692
        Me.cmd_editar.Text = "Editar"
        Me.cmd_editar.UseVisualStyleBackColor = True
        '
        'pic_searchCondicionCompra
        '
        Me.pic_searchCondicionCompra.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCondicionCompra.Location = New System.Drawing.Point(386, 86)
        Me.pic_searchCondicionCompra.Name = "pic_searchCondicionCompra"
        Me.pic_searchCondicionCompra.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCondicionCompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCondicionCompra.TabIndex = 684
        Me.pic_searchCondicionCompra.TabStop = False
        '
        'pic_searchCCProveedor
        '
        Me.pic_searchCCProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCCProveedor.Location = New System.Drawing.Point(817, 45)
        Me.pic_searchCCProveedor.Name = "pic_searchCCProveedor"
        Me.pic_searchCCProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCCProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCCProveedor.TabIndex = 664
        Me.pic_searchCCProveedor.TabStop = False
        '
        'pic_searchProveedor
        '
        Me.pic_searchProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchProveedor.Location = New System.Drawing.Point(386, 44)
        Me.pic_searchProveedor.Name = "pic_searchProveedor"
        Me.pic_searchProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchProveedor.TabIndex = 662
        Me.pic_searchProveedor.TabStop = False
        '
        'txt_totalOriginal
        '
        Me.txt_totalOriginal.Location = New System.Drawing.Point(530, 175)
        Me.txt_totalOriginal.Name = "txt_totalOriginal"
        Me.txt_totalOriginal.Size = New System.Drawing.Size(215, 20)
        Me.txt_totalOriginal.TabIndex = 694
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Location = New System.Drawing.Point(430, 175)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(31, 13)
        Me.lbl_total.TabIndex = 693
        Me.lbl_total.Text = "Total"
        '
        'pic_searchTipoComprobante
        '
        Me.pic_searchTipoComprobante.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchTipoComprobante.Location = New System.Drawing.Point(386, 122)
        Me.pic_searchTipoComprobante.Name = "pic_searchTipoComprobante"
        Me.pic_searchTipoComprobante.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchTipoComprobante.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchTipoComprobante.TabIndex = 695
        Me.pic_searchTipoComprobante.TabStop = False
        '
        'add_comprobantes_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 741)
        Me.Controls.Add(Me.pic_searchTipoComprobante)
        Me.Controls.Add(Me.txt_totalOriginal)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.cmd_editar)
        Me.Controls.Add(Me.txt_CAE)
        Me.Controls.Add(Me.lbl_CAE)
        Me.Controls.Add(Me.cmd_confirmar)
        Me.Controls.Add(Me.txt_numeroComprobante)
        Me.Controls.Add(Me.lbl_numeroComprobante)
        Me.Controls.Add(Me.txt_puntoVenta)
        Me.Controls.Add(Me.lbl_puntoVenta)
        Me.Controls.Add(Me.cmb_condicionCompra)
        Me.Controls.Add(Me.pic_searchCondicionCompra)
        Me.Controls.Add(Me.lbl_condicionCompra)
        Me.Controls.Add(Me.txt_tasaCambio)
        Me.Controls.Add(Me.lbl_tasaCambio)
        Me.Controls.Add(Me.cmb_moneda)
        Me.Controls.Add(Me.lbl_moneda)
        Me.Controls.Add(Me.txt_totalFactura)
        Me.Controls.Add(Me.lbl_totalFactura)
        Me.Controls.Add(Me.txt_totalImpuestos)
        Me.Controls.Add(Me.lbl_totalImpuestos)
        Me.Controls.Add(Me.txt_totalConceptos)
        Me.Controls.Add(Me.lbl_totalConceptos)
        Me.Controls.Add(Me.txt_totalItems)
        Me.Controls.Add(Me.lbl_totalItems)
        Me.Controls.Add(Me.cmd_agregar)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.tbl_comprobantesCompras)
        Me.Controls.Add(Me.cmb_cc)
        Me.Controls.Add(Me.pic_searchCCProveedor)
        Me.Controls.Add(Me.lbl_ccp)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.pic_searchProveedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_fechaComprobanteCompra)
        Me.Controls.Add(Me.lbl_fechaCarga)
        Me.Controls.Add(Me.lbl_fechaComprobante)
        Me.Controls.Add(Me.lblFechaCarga)
        Me.Controls.Add(Me.cmb_tipoComprobante)
        Me.Controls.Add(Me.lbl_tipoComprobante)
        Me.Name = "add_comprobantes_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        Me.tbl_comprobantesCompras.ResumeLayout(False)
        Me.productos.ResumeLayout(False)
        CType(Me.dg_viewItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_general.ResumeLayout(False)
        Me.impuestos.ResumeLayout(False)
        CType(Me.dg_viewImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.conceptos.ResumeLayout(False)
        CType(Me.dg_viewConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.notas.ResumeLayout(False)
        Me.notas.PerformLayout()
        CType(Me.pic_searchCondicionCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchCCProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchTipoComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_tipoComprobante As Label
    Friend WithEvents cmb_tipoComprobante As ComboBox
    Friend WithEvents cmb_cc As ComboBox
    Friend WithEvents pic_searchCCProveedor As PictureBox
    Friend WithEvents lbl_ccp As Label
    Friend WithEvents cmb_proveedor As ComboBox
    Friend WithEvents pic_searchProveedor As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp_fechaComprobanteCompra As DateTimePicker
    Friend WithEvents lbl_fechaCarga As Label
    Friend WithEvents lbl_fechaComprobante As Label
    Friend WithEvents lblFechaCarga As Label
    Friend WithEvents tbl_comprobantesCompras As TabControl
    Friend WithEvents productos As TabPage
    Friend WithEvents impuestos As TabPage
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents conceptos As TabPage
    Friend WithEvents cmd_agregar As Button
    Friend WithEvents lbl_totalItems As Label
    Friend WithEvents txt_totalItems As TextBox
    Friend WithEvents txt_totalConceptos As TextBox
    Friend WithEvents lbl_totalConceptos As Label
    Friend WithEvents txt_totalImpuestos As TextBox
    Friend WithEvents lbl_totalImpuestos As Label
    Friend WithEvents txt_totalFactura As TextBox
    Friend WithEvents lbl_totalFactura As Label
    Friend WithEvents lbl_moneda As Label
    Friend WithEvents cmb_moneda As ComboBox
    Friend WithEvents lbl_tasaCambio As Label
    Friend WithEvents txt_tasaCambio As TextBox
    Friend WithEvents cmb_condicionCompra As ComboBox
    Friend WithEvents pic_searchCondicionCompra As PictureBox
    Friend WithEvents lbl_condicionCompra As Label
    Friend WithEvents lbl_puntoVenta As Label
    Friend WithEvents txt_puntoVenta As TextBox
    Friend WithEvents lbl_numeroComprobante As Label
    Friend WithEvents txt_numeroComprobante As TextBox
    Friend WithEvents cmd_confirmar As Button
    Friend WithEvents notas As TabPage
    Friend WithEvents txt_notas As TextBox
    Friend WithEvents txt_CAE As TextBox
    Friend WithEvents lbl_CAE As Label
    Friend WithEvents cmd_editar As Button
    Friend WithEvents dg_viewItems As DataGridView
    Friend WithEvents dg_viewImpuestos As DataGridView
    Friend WithEvents dg_viewConceptos As DataGridView
    Friend WithEvents cms_general As ContextMenuStrip
    Friend WithEvents editar As ToolStripMenuItem
    Friend WithEvents eliminar As ToolStripMenuItem
    Friend WithEvents txt_totalOriginal As TextBox
    Friend WithEvents lbl_total As Label
    Friend WithEvents pic_searchTipoComprobante As PictureBox
End Class
