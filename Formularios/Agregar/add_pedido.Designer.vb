<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_pedido
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
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarPrecioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.cmd_recargaprecios = New System.Windows.Forms.Button()
        Me.lbl_nota1 = New System.Windows.Forms.Label()
        Me.txt_nota1 = New System.Windows.Forms.TextBox()
        Me.txt_nota2 = New System.Windows.Forms.TextBox()
        Me.lbl_nota2 = New System.Windows.Forms.Label()
        Me.txt_impuestos = New System.Windows.Forms.TextBox()
        Me.lbl_impuestos = New System.Windows.Forms.Label()
        Me.cmd_emitir = New System.Windows.Forms.Button()
        Me.txt_subTotal = New System.Windows.Forms.TextBox()
        Me.lbl_subTotal = New System.Windows.Forms.Label()
        Me.txt_totalO = New System.Windows.Forms.TextBox()
        Me.lbl_markup = New System.Windows.Forms.Label()
        Me.txt_markup = New System.Windows.Forms.TextBox()
        Me.cmb_cliente = New System.Windows.Forms.ComboBox()
        Me.chk_remitos = New System.Windows.Forms.CheckBox()
        Me.cmb_comprobante = New System.Windows.Forms.ComboBox()
        Me.lbl_comprobante = New System.Windows.Forms.Label()
        Me.chk_presupuesto = New System.Windows.Forms.CheckBox()
        Me.lbl_order = New System.Windows.Forms.Label()
        Me.lbl_pedido = New System.Windows.Forms.Label()
        Me.txt_totalDescuentos = New System.Windows.Forms.TextBox()
        Me.lbl_totalDescuentos = New System.Windows.Forms.Label()
        Me.lbl_noTaxNumber = New System.Windows.Forms.Label()
        Me.chk_esTest = New System.Windows.Forms.CheckBox()
        Me.tt_descuento = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbl_noMarkupNoPresupuesto = New System.Windows.Forms.Label()
        Me.cmb_cc = New System.Windows.Forms.ComboBox()
        Me.lbl_cc = New System.Windows.Forms.Label()
        Me.dg_viewPedido = New System.Windows.Forms.DataGridView()
        Me.lbl_items = New System.Windows.Forms.Label()
        Me.cmd_add_item = New System.Windows.Forms.Button()
        Me.cmd_add_descuento = New System.Windows.Forms.Button()
        Me.cmd_addItemManual = New System.Windows.Forms.Button()
        Me.cmd_first = New System.Windows.Forms.Button()
        Me.cmd_prev = New System.Windows.Forms.Button()
        Me.cmd_next = New System.Windows.Forms.Button()
        Me.cmd_last = New System.Windows.Forms.Button()
        Me.txt_nPage = New System.Windows.Forms.TextBox()
        Me.cmd_go = New System.Windows.Forms.Button()
        Me.psearch_cc = New System.Windows.Forms.PictureBox()
        Me.pic_searchComprobante = New System.Windows.Forms.PictureBox()
        Me.pic_searchCliente = New System.Windows.Forms.PictureBox()
        Me.lbl_avisoAFIP_NC_ND = New System.Windows.Forms.Label()
        Me.cmb_seleccionarComprobanteAnulación = New System.Windows.Forms.Button()
        Me.lbl_comprobanteAsociado = New System.Windows.Forms.Label()
        Me.txt_comprobanteAsociado = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dg_viewPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_cc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_date
        '
        Me.lbl_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Location = New System.Drawing.Point(58, 11)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(50, 13)
        Me.lbl_date.TabIndex = 49
        Me.lbl_date.Text = "%fecha%"
        '
        'cmd_exit
        '
        Me.cmd_exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(26, 669)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 11
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_ok.Location = New System.Drawing.Point(26, 580)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 10
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_cliente
        '
        Me.lbl_cliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(17, 47)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 41
        Me.lbl_cliente.Text = "Cliente"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(12, 11)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(40, 13)
        Me.lbl_fecha.TabIndex = 38
        Me.lbl_fecha.Text = "Fecha:"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem, Me.RecargarPrecioToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(157, 70)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'RecargarPrecioToolStripMenuItem
        '
        Me.RecargarPrecioToolStripMenuItem.Name = "RecargarPrecioToolStripMenuItem"
        Me.RecargarPrecioToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RecargarPrecioToolStripMenuItem.Text = "Recargar precio"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(26, 718)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 5
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'lbl_total
        '
        Me.lbl_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(338, 533)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(54, 20)
        Me.lbl_total.TabIndex = 53
        Me.lbl_total.Text = "Total:"
        '
        'txt_total
        '
        Me.txt_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_total.Location = New System.Drawing.Point(419, 533)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(174, 20)
        Me.txt_total.TabIndex = 4
        '
        'cmd_recargaprecios
        '
        Me.cmd_recargaprecios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_recargaprecios.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_recargaprecios.Location = New System.Drawing.Point(741, 531)
        Me.cmd_recargaprecios.Name = "cmd_recargaprecios"
        Me.cmd_recargaprecios.Size = New System.Drawing.Size(166, 22)
        Me.cmd_recargaprecios.TabIndex = 12
        Me.cmd_recargaprecios.Text = "Recargar precios"
        Me.cmd_recargaprecios.UseVisualStyleBackColor = True
        '
        'lbl_nota1
        '
        Me.lbl_nota1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_nota1.AutoSize = True
        Me.lbl_nota1.Location = New System.Drawing.Point(623, 159)
        Me.lbl_nota1.Name = "lbl_nota1"
        Me.lbl_nota1.Size = New System.Drawing.Size(102, 13)
        Me.lbl_nota1.TabIndex = 55
        Me.lbl_nota1.Text = "Condición de venta:"
        '
        'txt_nota1
        '
        Me.txt_nota1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nota1.Location = New System.Drawing.Point(626, 188)
        Me.txt_nota1.MaxLength = 85
        Me.txt_nota1.Multiline = True
        Me.txt_nota1.Name = "txt_nota1"
        Me.txt_nota1.Size = New System.Drawing.Size(266, 58)
        Me.txt_nota1.TabIndex = 6
        '
        'txt_nota2
        '
        Me.txt_nota2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nota2.Location = New System.Drawing.Point(626, 316)
        Me.txt_nota2.MaxLength = 91
        Me.txt_nota2.Multiline = True
        Me.txt_nota2.Name = "txt_nota2"
        Me.txt_nota2.Size = New System.Drawing.Size(266, 57)
        Me.txt_nota2.TabIndex = 7
        '
        'lbl_nota2
        '
        Me.lbl_nota2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_nota2.AutoSize = True
        Me.lbl_nota2.Location = New System.Drawing.Point(623, 289)
        Me.lbl_nota2.Name = "lbl_nota2"
        Me.lbl_nota2.Size = New System.Drawing.Size(81, 13)
        Me.lbl_nota2.TabIndex = 57
        Me.lbl_nota2.Text = "Observaciones:"
        '
        'txt_impuestos
        '
        Me.txt_impuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_impuestos.Location = New System.Drawing.Point(514, 477)
        Me.txt_impuestos.Name = "txt_impuestos"
        Me.txt_impuestos.ReadOnly = True
        Me.txt_impuestos.Size = New System.Drawing.Size(80, 20)
        Me.txt_impuestos.TabIndex = 60
        '
        'lbl_impuestos
        '
        Me.lbl_impuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_impuestos.AutoSize = True
        Me.lbl_impuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_impuestos.Location = New System.Drawing.Point(409, 477)
        Me.lbl_impuestos.Name = "lbl_impuestos"
        Me.lbl_impuestos.Size = New System.Drawing.Size(84, 20)
        Me.lbl_impuestos.TabIndex = 61
        Me.lbl_impuestos.Text = "Impuestos"
        '
        'cmd_emitir
        '
        Me.cmd_emitir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_emitir.Location = New System.Drawing.Point(26, 624)
        Me.cmd_emitir.Name = "cmd_emitir"
        Me.cmd_emitir.Size = New System.Drawing.Size(75, 23)
        Me.cmd_emitir.TabIndex = 9
        Me.cmd_emitir.Text = "Emitir"
        Me.cmd_emitir.UseVisualStyleBackColor = True
        '
        'txt_subTotal
        '
        Me.txt_subTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_subTotal.Location = New System.Drawing.Point(308, 477)
        Me.txt_subTotal.Name = "txt_subTotal"
        Me.txt_subTotal.ReadOnly = True
        Me.txt_subTotal.Size = New System.Drawing.Size(80, 20)
        Me.txt_subTotal.TabIndex = 633
        '
        'lbl_subTotal
        '
        Me.lbl_subTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_subTotal.AutoSize = True
        Me.lbl_subTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_subTotal.Location = New System.Drawing.Point(214, 477)
        Me.lbl_subTotal.Name = "lbl_subTotal"
        Me.lbl_subTotal.Size = New System.Drawing.Size(73, 20)
        Me.lbl_subTotal.TabIndex = 64
        Me.lbl_subTotal.Text = "Subtotal:"
        '
        'txt_totalO
        '
        Me.txt_totalO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_totalO.Location = New System.Drawing.Point(741, 559)
        Me.txt_totalO.Name = "txt_totalO"
        Me.txt_totalO.ReadOnly = True
        Me.txt_totalO.Size = New System.Drawing.Size(166, 20)
        Me.txt_totalO.TabIndex = 68
        Me.txt_totalO.Visible = False
        '
        'lbl_markup
        '
        Me.lbl_markup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_markup.AutoSize = True
        Me.lbl_markup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_markup.Location = New System.Drawing.Point(22, 477)
        Me.lbl_markup.Name = "lbl_markup"
        Me.lbl_markup.Size = New System.Drawing.Size(70, 20)
        Me.lbl_markup.TabIndex = 69
        Me.lbl_markup.Text = "Markup: "
        '
        'txt_markup
        '
        Me.txt_markup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_markup.Location = New System.Drawing.Point(113, 477)
        Me.txt_markup.Name = "txt_markup"
        Me.txt_markup.Size = New System.Drawing.Size(80, 20)
        Me.txt_markup.TabIndex = 8
        Me.txt_markup.Text = "0"
        '
        'cmb_cliente
        '
        Me.cmb_cliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cliente.FormattingEnabled = True
        Me.cmb_cliente.Location = New System.Drawing.Point(93, 42)
        Me.cmb_cliente.Name = "cmb_cliente"
        Me.cmb_cliente.Size = New System.Drawing.Size(343, 21)
        Me.cmb_cliente.TabIndex = 0
        '
        'chk_remitos
        '
        Me.chk_remitos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_remitos.AutoSize = True
        Me.chk_remitos.Checked = True
        Me.chk_remitos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_remitos.Location = New System.Drawing.Point(612, 86)
        Me.chk_remitos.Name = "chk_remitos"
        Me.chk_remitos.Size = New System.Drawing.Size(87, 17)
        Me.chk_remitos.TabIndex = 636
        Me.chk_remitos.Text = "Emitir remitos"
        Me.chk_remitos.UseVisualStyleBackColor = True
        '
        'cmb_comprobante
        '
        Me.cmb_comprobante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_comprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_comprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_comprobante.FormattingEnabled = True
        Me.cmb_comprobante.Location = New System.Drawing.Point(93, 82)
        Me.cmb_comprobante.Name = "cmb_comprobante"
        Me.cmb_comprobante.Size = New System.Drawing.Size(343, 21)
        Me.cmb_comprobante.TabIndex = 2
        '
        'lbl_comprobante
        '
        Me.lbl_comprobante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_comprobante.AutoSize = True
        Me.lbl_comprobante.Location = New System.Drawing.Point(17, 87)
        Me.lbl_comprobante.Name = "lbl_comprobante"
        Me.lbl_comprobante.Size = New System.Drawing.Size(70, 13)
        Me.lbl_comprobante.TabIndex = 637
        Me.lbl_comprobante.Text = "Comprobante"
        '
        'chk_presupuesto
        '
        Me.chk_presupuesto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_presupuesto.AutoSize = True
        Me.chk_presupuesto.Location = New System.Drawing.Point(492, 86)
        Me.chk_presupuesto.Name = "chk_presupuesto"
        Me.chk_presupuesto.Size = New System.Drawing.Size(114, 17)
        Me.chk_presupuesto.TabIndex = 8
        Me.chk_presupuesto.Text = "Es un presupuesto"
        Me.chk_presupuesto.UseVisualStyleBackColor = True
        Me.chk_presupuesto.Visible = False
        '
        'lbl_order
        '
        Me.lbl_order.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_order.AutoSize = True
        Me.lbl_order.Location = New System.Drawing.Point(194, 11)
        Me.lbl_order.Name = "lbl_order"
        Me.lbl_order.Size = New System.Drawing.Size(55, 13)
        Me.lbl_order.TabIndex = 643
        Me.lbl_order.Text = "%pedido%"
        Me.lbl_order.Visible = False
        '
        'lbl_pedido
        '
        Me.lbl_pedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Location = New System.Drawing.Point(148, 11)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(43, 13)
        Me.lbl_pedido.TabIndex = 642
        Me.lbl_pedido.Text = "Pedido:"
        Me.lbl_pedido.Visible = False
        '
        'txt_totalDescuentos
        '
        Me.txt_totalDescuentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_totalDescuentos.Location = New System.Drawing.Point(180, 531)
        Me.txt_totalDescuentos.Name = "txt_totalDescuentos"
        Me.txt_totalDescuentos.ReadOnly = True
        Me.txt_totalDescuentos.Size = New System.Drawing.Size(131, 20)
        Me.txt_totalDescuentos.TabIndex = 644
        '
        'lbl_totalDescuentos
        '
        Me.lbl_totalDescuentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_totalDescuentos.AutoSize = True
        Me.lbl_totalDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totalDescuentos.Location = New System.Drawing.Point(22, 533)
        Me.lbl_totalDescuentos.Name = "lbl_totalDescuentos"
        Me.lbl_totalDescuentos.Size = New System.Drawing.Size(131, 20)
        Me.lbl_totalDescuentos.TabIndex = 645
        Me.lbl_totalDescuentos.Text = "Total descuentos"
        '
        'lbl_noTaxNumber
        '
        Me.lbl_noTaxNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_noTaxNumber.AutoSize = True
        Me.lbl_noTaxNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_noTaxNumber.ForeColor = System.Drawing.Color.Red
        Me.lbl_noTaxNumber.Location = New System.Drawing.Point(230, 701)
        Me.lbl_noTaxNumber.Name = "lbl_noTaxNumber"
        Me.lbl_noTaxNumber.Size = New System.Drawing.Size(509, 13)
        Me.lbl_noTaxNumber.TabIndex = 646
        Me.lbl_noTaxNumber.Text = "El cliente no tiene cargado el CUIT por lo cual no se pueden emitir documentos of" &
    "iciales"
        Me.lbl_noTaxNumber.Visible = False
        '
        'chk_esTest
        '
        Me.chk_esTest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_esTest.AutoSize = True
        Me.chk_esTest.Location = New System.Drawing.Point(819, 86)
        Me.chk_esTest.Name = "chk_esTest"
        Me.chk_esTest.Size = New System.Drawing.Size(73, 17)
        Me.chk_esTest.TabIndex = 647
        Me.chk_esTest.Text = "Es un test"
        Me.chk_esTest.UseVisualStyleBackColor = True
        '
        'tt_descuento
        '
        Me.tt_descuento.Active = False
        '
        'lbl_noMarkupNoPresupuesto
        '
        Me.lbl_noMarkupNoPresupuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_noMarkupNoPresupuesto.AutoSize = True
        Me.lbl_noMarkupNoPresupuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_noMarkupNoPresupuesto.ForeColor = System.Drawing.Color.Red
        Me.lbl_noMarkupNoPresupuesto.Location = New System.Drawing.Point(269, 679)
        Me.lbl_noMarkupNoPresupuesto.Name = "lbl_noMarkupNoPresupuesto"
        Me.lbl_noMarkupNoPresupuesto.Size = New System.Drawing.Size(430, 13)
        Me.lbl_noMarkupNoPresupuesto.TabIndex = 648
        Me.lbl_noMarkupNoPresupuesto.Text = "Si no tilda 'Es un presupuesto' y no hay markup NO SE CALCULARÁ I.V.A."
        Me.lbl_noMarkupNoPresupuesto.Visible = False
        '
        'cmb_cc
        '
        Me.cmb_cc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_cc.Enabled = False
        Me.cmb_cc.FormattingEnabled = True
        Me.cmb_cc.Location = New System.Drawing.Point(597, 42)
        Me.cmb_cc.Name = "cmb_cc"
        Me.cmb_cc.Size = New System.Drawing.Size(267, 21)
        Me.cmb_cc.TabIndex = 1
        Me.cmb_cc.Text = "Seleccione una cuenta corriente..."
        '
        'lbl_cc
        '
        Me.lbl_cc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_cc.AutoSize = True
        Me.lbl_cc.Location = New System.Drawing.Point(494, 47)
        Me.lbl_cc.Name = "lbl_cc"
        Me.lbl_cc.Size = New System.Drawing.Size(85, 13)
        Me.lbl_cc.TabIndex = 650
        Me.lbl_cc.Text = "Cuenta corriente"
        '
        'dg_viewPedido
        '
        Me.dg_viewPedido.AllowUserToAddRows = False
        Me.dg_viewPedido.AllowUserToDeleteRows = False
        Me.dg_viewPedido.AllowUserToOrderColumns = True
        Me.dg_viewPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_viewPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dg_viewPedido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewPedido.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dg_viewPedido.Location = New System.Drawing.Point(15, 157)
        Me.dg_viewPedido.MultiSelect = False
        Me.dg_viewPedido.Name = "dg_viewPedido"
        Me.dg_viewPedido.ReadOnly = True
        Me.dg_viewPedido.RowHeadersVisible = False
        Me.dg_viewPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewPedido.Size = New System.Drawing.Size(592, 229)
        Me.dg_viewPedido.TabIndex = 640
        '
        'lbl_items
        '
        Me.lbl_items.AutoSize = True
        Me.lbl_items.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_items.Location = New System.Drawing.Point(252, 125)
        Me.lbl_items.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_items.Name = "lbl_items"
        Me.lbl_items.Size = New System.Drawing.Size(59, 24)
        Me.lbl_items.TabIndex = 51
        Me.lbl_items.Text = "Items"
        '
        'cmd_add_item
        '
        Me.cmd_add_item.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_add_item.Location = New System.Drawing.Point(104, 421)
        Me.cmd_add_item.Name = "cmd_add_item"
        Me.cmd_add_item.Size = New System.Drawing.Size(133, 22)
        Me.cmd_add_item.TabIndex = 3
        Me.cmd_add_item.Text = "Añadir producto"
        Me.cmd_add_item.UseVisualStyleBackColor = True
        '
        'cmd_add_descuento
        '
        Me.cmd_add_descuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_add_descuento.Location = New System.Drawing.Point(382, 421)
        Me.cmd_add_descuento.Name = "cmd_add_descuento"
        Me.cmd_add_descuento.Size = New System.Drawing.Size(133, 22)
        Me.cmd_add_descuento.TabIndex = 5
        Me.cmd_add_descuento.Text = "Agregar descuento"
        Me.cmd_add_descuento.UseVisualStyleBackColor = True
        '
        'cmd_addItemManual
        '
        Me.cmd_addItemManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_addItemManual.Location = New System.Drawing.Point(243, 421)
        Me.cmd_addItemManual.Name = "cmd_addItemManual"
        Me.cmd_addItemManual.Size = New System.Drawing.Size(133, 22)
        Me.cmd_addItemManual.TabIndex = 4
        Me.cmd_addItemManual.Text = "Añadir producto manual"
        Me.cmd_addItemManual.UseVisualStyleBackColor = True
        '
        'cmd_first
        '
        Me.cmd_first.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_first.Location = New System.Drawing.Point(12, 392)
        Me.cmd_first.Name = "cmd_first"
        Me.cmd_first.Size = New System.Drawing.Size(29, 20)
        Me.cmd_first.TabIndex = 652
        Me.cmd_first.Text = "|<<"
        Me.cmd_first.UseVisualStyleBackColor = True
        Me.cmd_first.Visible = False
        '
        'cmd_prev
        '
        Me.cmd_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_prev.Location = New System.Drawing.Point(47, 392)
        Me.cmd_prev.Name = "cmd_prev"
        Me.cmd_prev.Size = New System.Drawing.Size(40, 20)
        Me.cmd_prev.TabIndex = 653
        Me.cmd_prev.Text = "<<"
        Me.cmd_prev.UseVisualStyleBackColor = True
        Me.cmd_prev.Visible = False
        '
        'cmd_next
        '
        Me.cmd_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_next.Location = New System.Drawing.Point(93, 392)
        Me.cmd_next.Name = "cmd_next"
        Me.cmd_next.Size = New System.Drawing.Size(40, 20)
        Me.cmd_next.TabIndex = 654
        Me.cmd_next.Text = ">>"
        Me.cmd_next.UseVisualStyleBackColor = True
        Me.cmd_next.Visible = False
        '
        'cmd_last
        '
        Me.cmd_last.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_last.Location = New System.Drawing.Point(139, 392)
        Me.cmd_last.Name = "cmd_last"
        Me.cmd_last.Size = New System.Drawing.Size(29, 20)
        Me.cmd_last.TabIndex = 655
        Me.cmd_last.Text = ">>|"
        Me.cmd_last.UseVisualStyleBackColor = True
        Me.cmd_last.Visible = False
        '
        'txt_nPage
        '
        Me.txt_nPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_nPage.Location = New System.Drawing.Point(174, 392)
        Me.txt_nPage.Name = "txt_nPage"
        Me.txt_nPage.Size = New System.Drawing.Size(63, 20)
        Me.txt_nPage.TabIndex = 656
        Me.txt_nPage.Visible = False
        '
        'cmd_go
        '
        Me.cmd_go.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_go.Location = New System.Drawing.Point(243, 392)
        Me.cmd_go.Name = "cmd_go"
        Me.cmd_go.Size = New System.Drawing.Size(29, 20)
        Me.cmd_go.TabIndex = 657
        Me.cmd_go.Text = "Ir"
        Me.cmd_go.UseVisualStyleBackColor = True
        Me.cmd_go.Visible = False
        '
        'psearch_cc
        '
        Me.psearch_cc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.psearch_cc.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_cc.Location = New System.Drawing.Point(870, 41)
        Me.psearch_cc.Name = "psearch_cc"
        Me.psearch_cc.Size = New System.Drawing.Size(22, 22)
        Me.psearch_cc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_cc.TabIndex = 651
        Me.psearch_cc.TabStop = False
        '
        'pic_searchComprobante
        '
        Me.pic_searchComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_searchComprobante.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchComprobante.Location = New System.Drawing.Point(442, 81)
        Me.pic_searchComprobante.Name = "pic_searchComprobante"
        Me.pic_searchComprobante.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchComprobante.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchComprobante.TabIndex = 638
        Me.pic_searchComprobante.TabStop = False
        '
        'pic_searchCliente
        '
        Me.pic_searchCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_searchCliente.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCliente.Location = New System.Drawing.Point(442, 41)
        Me.pic_searchCliente.Name = "pic_searchCliente"
        Me.pic_searchCliente.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCliente.TabIndex = 48
        Me.pic_searchCliente.TabStop = False
        '
        'lbl_avisoAFIP_NC_ND
        '
        Me.lbl_avisoAFIP_NC_ND.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_avisoAFIP_NC_ND.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_avisoAFIP_NC_ND.ForeColor = System.Drawing.Color.Red
        Me.lbl_avisoAFIP_NC_ND.Location = New System.Drawing.Point(215, 582)
        Me.lbl_avisoAFIP_NC_ND.Name = "lbl_avisoAFIP_NC_ND"
        Me.lbl_avisoAFIP_NC_ND.Size = New System.Drawing.Size(550, 36)
        Me.lbl_avisoAFIP_NC_ND.TabIndex = 658
        Me.lbl_avisoAFIP_NC_ND.Text = "Por una nueva disposición de AFIP para emitir notas de crédito y débito deberá in" &
    "dicar a qué factura corresponde la contrapartida que está queriendo emitir. "
        Me.lbl_avisoAFIP_NC_ND.Visible = False
        '
        'cmb_seleccionarComprobanteAnulación
        '
        Me.cmb_seleccionarComprobanteAnulación.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_seleccionarComprobanteAnulación.Location = New System.Drawing.Point(268, 629)
        Me.cmb_seleccionarComprobanteAnulación.Name = "cmb_seleccionarComprobanteAnulación"
        Me.cmb_seleccionarComprobanteAnulación.Size = New System.Drawing.Size(166, 22)
        Me.cmb_seleccionarComprobanteAnulación.TabIndex = 659
        Me.cmb_seleccionarComprobanteAnulación.Text = "Seleccionar comprobante"
        Me.cmb_seleccionarComprobanteAnulación.UseVisualStyleBackColor = True
        Me.cmb_seleccionarComprobanteAnulación.Visible = False
        '
        'lbl_comprobanteAsociado
        '
        Me.lbl_comprobanteAsociado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_comprobanteAsociado.AutoSize = True
        Me.lbl_comprobanteAsociado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_comprobanteAsociado.ForeColor = System.Drawing.Color.Black
        Me.lbl_comprobanteAsociado.Location = New System.Drawing.Point(440, 634)
        Me.lbl_comprobanteAsociado.Name = "lbl_comprobanteAsociado"
        Me.lbl_comprobanteAsociado.Size = New System.Drawing.Size(136, 13)
        Me.lbl_comprobanteAsociado.TabIndex = 660
        Me.lbl_comprobanteAsociado.Text = "Comprobante asociado"
        Me.lbl_comprobanteAsociado.Visible = False
        '
        'txt_comprobanteAsociado
        '
        Me.txt_comprobanteAsociado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_comprobanteAsociado.Location = New System.Drawing.Point(587, 627)
        Me.txt_comprobanteAsociado.Name = "txt_comprobanteAsociado"
        Me.txt_comprobanteAsociado.ReadOnly = True
        Me.txt_comprobanteAsociado.Size = New System.Drawing.Size(80, 20)
        Me.txt_comprobanteAsociado.TabIndex = 661
        Me.txt_comprobanteAsociado.Visible = False
        '
        'add_pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmd_exit
        Me.ClientSize = New System.Drawing.Size(934, 737)
        Me.ControlBox = False
        Me.Controls.Add(Me.txt_comprobanteAsociado)
        Me.Controls.Add(Me.lbl_comprobanteAsociado)
        Me.Controls.Add(Me.cmb_seleccionarComprobanteAnulación)
        Me.Controls.Add(Me.lbl_avisoAFIP_NC_ND)
        Me.Controls.Add(Me.cmd_go)
        Me.Controls.Add(Me.txt_nPage)
        Me.Controls.Add(Me.cmd_last)
        Me.Controls.Add(Me.cmd_next)
        Me.Controls.Add(Me.cmd_prev)
        Me.Controls.Add(Me.cmd_first)
        Me.Controls.Add(Me.cmb_cc)
        Me.Controls.Add(Me.psearch_cc)
        Me.Controls.Add(Me.lbl_cc)
        Me.Controls.Add(Me.cmd_addItemManual)
        Me.Controls.Add(Me.lbl_noMarkupNoPresupuesto)
        Me.Controls.Add(Me.chk_esTest)
        Me.Controls.Add(Me.lbl_noTaxNumber)
        Me.Controls.Add(Me.txt_totalDescuentos)
        Me.Controls.Add(Me.lbl_totalDescuentos)
        Me.Controls.Add(Me.lbl_order)
        Me.Controls.Add(Me.lbl_pedido)
        Me.Controls.Add(Me.cmd_add_descuento)
        Me.Controls.Add(Me.cmb_comprobante)
        Me.Controls.Add(Me.pic_searchComprobante)
        Me.Controls.Add(Me.lbl_comprobante)
        Me.Controls.Add(Me.chk_remitos)
        Me.Controls.Add(Me.cmb_cliente)
        Me.Controls.Add(Me.txt_markup)
        Me.Controls.Add(Me.lbl_markup)
        Me.Controls.Add(Me.txt_totalO)
        Me.Controls.Add(Me.txt_subTotal)
        Me.Controls.Add(Me.lbl_subTotal)
        Me.Controls.Add(Me.cmd_emitir)
        Me.Controls.Add(Me.txt_impuestos)
        Me.Controls.Add(Me.lbl_impuestos)
        Me.Controls.Add(Me.chk_presupuesto)
        Me.Controls.Add(Me.txt_nota2)
        Me.Controls.Add(Me.lbl_nota2)
        Me.Controls.Add(Me.txt_nota1)
        Me.Controls.Add(Me.lbl_nota1)
        Me.Controls.Add(Me.cmd_recargaprecios)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_add_item)
        Me.Controls.Add(Me.lbl_date)
        Me.Controls.Add(Me.pic_searchCliente)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.lbl_items)
        Me.Controls.Add(Me.dg_viewPedido)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(950, 606)
        Me.Name = "add_pedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga de pedido"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dg_viewPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_cc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_cliente As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_recargaprecios As System.Windows.Forms.Button
    Friend WithEvents RecargarPrecioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_nota1 As System.Windows.Forms.Label
    Friend WithEvents txt_nota1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nota2 As System.Windows.Forms.Label
    Friend WithEvents txt_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents lbl_impuestos As System.Windows.Forms.Label
    Friend WithEvents cmd_emitir As System.Windows.Forms.Button
    Friend WithEvents txt_subTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_subTotal As System.Windows.Forms.Label
    Friend WithEvents txt_totalO As System.Windows.Forms.TextBox
    Friend WithEvents lbl_markup As System.Windows.Forms.Label
    Friend WithEvents txt_markup As System.Windows.Forms.TextBox
    Friend WithEvents cmb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents pic_searchCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chk_remitos As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_comprobante As System.Windows.Forms.ComboBox
    Friend WithEvents pic_searchComprobante As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_comprobante As System.Windows.Forms.Label
    Friend WithEvents chk_presupuesto As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_order As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents txt_totalDescuentos As System.Windows.Forms.TextBox
    Friend WithEvents lbl_totalDescuentos As System.Windows.Forms.Label
    Friend WithEvents lbl_noTaxNumber As System.Windows.Forms.Label
    Friend WithEvents chk_esTest As System.Windows.Forms.CheckBox
    Friend WithEvents tt_descuento As ToolTip
    Friend WithEvents lbl_noMarkupNoPresupuesto As Label
    Friend WithEvents cmb_cc As ComboBox
    Friend WithEvents psearch_cc As PictureBox
    Friend WithEvents lbl_cc As Label
    Friend WithEvents dg_viewPedido As DataGridView
    Friend WithEvents lbl_items As Label
    Friend WithEvents cmd_add_item As Button
    Friend WithEvents cmd_add_descuento As Button
    Friend WithEvents cmd_addItemManual As Button
    Friend WithEvents cmd_first As Button
    Friend WithEvents cmd_prev As Button
    Friend WithEvents cmd_next As Button
    Friend WithEvents cmd_last As Button
    Friend WithEvents txt_nPage As TextBox
    Friend WithEvents cmd_go As Button
    Friend WithEvents lbl_avisoAFIP_NC_ND As Label
    Friend WithEvents cmb_seleccionarComprobanteAnulación As Button
    Friend WithEvents lbl_comprobanteAsociado As Label
    Friend WithEvents txt_comprobanteAsociado As TextBox
End Class
