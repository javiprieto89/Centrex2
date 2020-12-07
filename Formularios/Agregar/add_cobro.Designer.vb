<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_cobro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lbl_fechaCarga1 = New System.Windows.Forms.Label()
        Me.lbl_fechaCarga = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_importePago = New System.Windows.Forms.Label()
        Me.lbl_pago = New System.Windows.Forms.Label()
        Me.txt_aplicaFc = New System.Windows.Forms.TextBox()
        Me.lbl_aplicaFc = New System.Windows.Forms.Label()
        Me.tbControl = New System.Windows.Forms.TabControl()
        Me.tb_cobro = New System.Windows.Forms.TabPage()
        Me.lblpeso1 = New System.Windows.Forms.Label()
        Me.cmb_cc = New System.Windows.Forms.ComboBox()
        Me.pic_searchCCCliente = New System.Windows.Forms.PictureBox()
        Me.lbl_ccc = New System.Windows.Forms.Label()
        Me.txt_efectivo = New System.Windows.Forms.TextBox()
        Me.lbl_dineroCuenta = New System.Windows.Forms.Label()
        Me.lbl_dineroCuenta1 = New System.Windows.Forms.Label()
        Me.lbl_comoPaga = New System.Windows.Forms.Label()
        Me.chk_efectivo = New System.Windows.Forms.CheckBox()
        Me.cmb_cliente = New System.Windows.Forms.ComboBox()
        Me.pic_searchCliente = New System.Windows.Forms.PictureBox()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.dtp_fechaCobro = New System.Windows.Forms.DateTimePicker()
        Me.lbl_fechaCobro = New System.Windows.Forms.Label()
        Me.tb_cheques = New System.Windows.Forms.TabPage()
        Me.lbl_totalCh = New System.Windows.Forms.Label()
        Me.lbl_totalCheques = New System.Windows.Forms.Label()
        Me.lbl_borrarbusquedaCH = New System.Windows.Forms.Label()
        Me.lbl_buscarCheque = New System.Windows.Forms.Label()
        Me.txt_searchCH = New System.Windows.Forms.TextBox()
        Me.lbl_chSel = New System.Windows.Forms.Label()
        Me.dg_viewCH = New System.Windows.Forms.DataGridView()
        Me.cms_general = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_verCheques = New System.Windows.Forms.Button()
        Me.cmd_addCheques = New System.Windows.Forms.Button()
        Me.chk_cheque = New System.Windows.Forms.CheckBox()
        Me.tb_transferencias = New System.Windows.Forms.TabPage()
        Me.lbl_totalTransferencia = New System.Windows.Forms.Label()
        Me.lbl_totalTransferencias = New System.Windows.Forms.Label()
        Me.lbl_borrarbusquedaTransferencia = New System.Windows.Forms.Label()
        Me.lbl_buscarTransferencia = New System.Windows.Forms.Label()
        Me.txt_searchTransferencia = New System.Windows.Forms.TextBox()
        Me.dg_viewTransferencia = New System.Windows.Forms.DataGridView()
        Me.cmd_addTransferencia = New System.Windows.Forms.Button()
        Me.chk_transferencia = New System.Windows.Forms.CheckBox()
        Me.tb_retenciones = New System.Windows.Forms.TabPage()
        Me.lbl_totalRetencion = New System.Windows.Forms.Label()
        Me.lbl_totalRetenciones = New System.Windows.Forms.Label()
        Me.lbl_borrarbusquedaRetencion = New System.Windows.Forms.Label()
        Me.lbl_buscarRetencion = New System.Windows.Forms.Label()
        Me.txt_searchRetencion = New System.Windows.Forms.TextBox()
        Me.dg_viewRetencion = New System.Windows.Forms.DataGridView()
        Me.cmd_addRetencion = New System.Windows.Forms.Button()
        Me.chk_retenciones = New System.Windows.Forms.CheckBox()
        Me.tb_otros = New System.Windows.Forms.TabPage()
        Me.tb_notas = New System.Windows.Forms.TabPage()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_firmante = New System.Windows.Forms.Label()
        Me.tbControl.SuspendLayout()
        Me.tb_cobro.SuspendLayout()
        CType(Me.pic_searchCCCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_cheques.SuspendLayout()
        CType(Me.dg_viewCH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_general.SuspendLayout()
        Me.tb_transferencias.SuspendLayout()
        CType(Me.dg_viewTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_retenciones.SuspendLayout()
        CType(Me.dg_viewRetencion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_otros.SuspendLayout()
        Me.tb_notas.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_fechaCarga1
        '
        Me.lbl_fechaCarga1.AutoSize = True
        Me.lbl_fechaCarga1.Location = New System.Drawing.Point(30, 23)
        Me.lbl_fechaCarga1.Name = "lbl_fechaCarga1"
        Me.lbl_fechaCarga1.Size = New System.Drawing.Size(85, 13)
        Me.lbl_fechaCarga1.TabIndex = 0
        Me.lbl_fechaCarga1.Text = "Fecha de carga:"
        '
        'lbl_fechaCarga
        '
        Me.lbl_fechaCarga.AutoSize = True
        Me.lbl_fechaCarga.Location = New System.Drawing.Point(147, 23)
        Me.lbl_fechaCarga.Name = "lbl_fechaCarga"
        Me.lbl_fechaCarga.Size = New System.Drawing.Size(50, 13)
        Me.lbl_fechaCarga.TabIndex = 2
        Me.lbl_fechaCarga.Text = "%carga%"
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(302, 593)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 11
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(204, 593)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 5
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_importePago
        '
        Me.lbl_importePago.AutoSize = True
        Me.lbl_importePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_importePago.ForeColor = System.Drawing.Color.Green
        Me.lbl_importePago.Location = New System.Drawing.Point(201, 511)
        Me.lbl_importePago.Name = "lbl_importePago"
        Me.lbl_importePago.Size = New System.Drawing.Size(24, 16)
        Me.lbl_importePago.TabIndex = 662
        Me.lbl_importePago.Text = "$$"
        '
        'lbl_pago
        '
        Me.lbl_pago.AutoSize = True
        Me.lbl_pago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pago.ForeColor = System.Drawing.Color.Black
        Me.lbl_pago.Location = New System.Drawing.Point(30, 511)
        Me.lbl_pago.Name = "lbl_pago"
        Me.lbl_pago.Size = New System.Drawing.Size(148, 15)
        Me.lbl_pago.TabIndex = 661
        Me.lbl_pago.Text = "Importe total del pago"
        '
        'txt_aplicaFc
        '
        Me.txt_aplicaFc.Enabled = False
        Me.txt_aplicaFc.Location = New System.Drawing.Point(20, 49)
        Me.txt_aplicaFc.Multiline = True
        Me.txt_aplicaFc.Name = "txt_aplicaFc"
        Me.txt_aplicaFc.Size = New System.Drawing.Size(533, 98)
        Me.txt_aplicaFc.TabIndex = 12
        '
        'lbl_aplicaFc
        '
        Me.lbl_aplicaFc.AutoSize = True
        Me.lbl_aplicaFc.Location = New System.Drawing.Point(20, 20)
        Me.lbl_aplicaFc.Name = "lbl_aplicaFc"
        Me.lbl_aplicaFc.Size = New System.Drawing.Size(125, 13)
        Me.lbl_aplicaFc.TabIndex = 674
        Me.lbl_aplicaFc.Text = "Facturas a las que aplica"
        '
        'tbControl
        '
        Me.tbControl.Controls.Add(Me.tb_cobro)
        Me.tbControl.Controls.Add(Me.tb_cheques)
        Me.tbControl.Controls.Add(Me.tb_transferencias)
        Me.tbControl.Controls.Add(Me.tb_retenciones)
        Me.tbControl.Controls.Add(Me.tb_otros)
        Me.tbControl.Controls.Add(Me.tb_notas)
        Me.tbControl.Location = New System.Drawing.Point(30, 50)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.SelectedIndex = 0
        Me.tbControl.Size = New System.Drawing.Size(584, 430)
        Me.tbControl.TabIndex = 0
        '
        'tb_cobro
        '
        Me.tb_cobro.BackColor = System.Drawing.SystemColors.Control
        Me.tb_cobro.Controls.Add(Me.lblpeso1)
        Me.tb_cobro.Controls.Add(Me.cmb_cc)
        Me.tb_cobro.Controls.Add(Me.pic_searchCCCliente)
        Me.tb_cobro.Controls.Add(Me.lbl_ccc)
        Me.tb_cobro.Controls.Add(Me.txt_efectivo)
        Me.tb_cobro.Controls.Add(Me.lbl_dineroCuenta)
        Me.tb_cobro.Controls.Add(Me.lbl_dineroCuenta1)
        Me.tb_cobro.Controls.Add(Me.lbl_comoPaga)
        Me.tb_cobro.Controls.Add(Me.chk_efectivo)
        Me.tb_cobro.Controls.Add(Me.cmb_cliente)
        Me.tb_cobro.Controls.Add(Me.pic_searchCliente)
        Me.tb_cobro.Controls.Add(Me.lbl_cliente)
        Me.tb_cobro.Controls.Add(Me.dtp_fechaCobro)
        Me.tb_cobro.Controls.Add(Me.lbl_fechaCobro)
        Me.tb_cobro.Location = New System.Drawing.Point(4, 22)
        Me.tb_cobro.Name = "tb_cobro"
        Me.tb_cobro.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_cobro.Size = New System.Drawing.Size(576, 404)
        Me.tb_cobro.TabIndex = 0
        Me.tb_cobro.Text = "Cobro"
        '
        'lblpeso1
        '
        Me.lblpeso1.AutoSize = True
        Me.lblpeso1.Location = New System.Drawing.Point(230, 221)
        Me.lblpeso1.Name = "lblpeso1"
        Me.lblpeso1.Size = New System.Drawing.Size(13, 13)
        Me.lblpeso1.TabIndex = 675
        Me.lblpeso1.Text = "$"
        '
        'cmb_cc
        '
        Me.cmb_cc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cc.FormattingEnabled = True
        Me.cmb_cc.Location = New System.Drawing.Point(163, 91)
        Me.cmb_cc.Name = "cmb_cc"
        Me.cmb_cc.Size = New System.Drawing.Size(343, 21)
        Me.cmb_cc.TabIndex = 2
        '
        'pic_searchCCCliente
        '
        Me.pic_searchCCCliente.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCCCliente.Location = New System.Drawing.Point(512, 91)
        Me.pic_searchCCCliente.Name = "pic_searchCCCliente"
        Me.pic_searchCCCliente.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCCCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCCCliente.TabIndex = 691
        Me.pic_searchCCCliente.TabStop = False
        '
        'lbl_ccc
        '
        Me.lbl_ccc.AutoSize = True
        Me.lbl_ccc.Location = New System.Drawing.Point(20, 91)
        Me.lbl_ccc.Name = "lbl_ccc"
        Me.lbl_ccc.Size = New System.Drawing.Size(136, 13)
        Me.lbl_ccc.TabIndex = 690
        Me.lbl_ccc.Text = "Cuenta corriente del cliente"
        '
        'txt_efectivo
        '
        Me.txt_efectivo.Enabled = False
        Me.txt_efectivo.Location = New System.Drawing.Point(249, 221)
        Me.txt_efectivo.Name = "txt_efectivo"
        Me.txt_efectivo.Size = New System.Drawing.Size(285, 20)
        Me.txt_efectivo.TabIndex = 4
        '
        'lbl_dineroCuenta
        '
        Me.lbl_dineroCuenta.AutoSize = True
        Me.lbl_dineroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dineroCuenta.ForeColor = System.Drawing.Color.Green
        Me.lbl_dineroCuenta.Location = New System.Drawing.Point(155, 173)
        Me.lbl_dineroCuenta.Name = "lbl_dineroCuenta"
        Me.lbl_dineroCuenta.Size = New System.Drawing.Size(24, 16)
        Me.lbl_dineroCuenta.TabIndex = 689
        Me.lbl_dineroCuenta.Text = "$$"
        '
        'lbl_dineroCuenta1
        '
        Me.lbl_dineroCuenta1.AutoSize = True
        Me.lbl_dineroCuenta1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dineroCuenta1.ForeColor = System.Drawing.Color.Black
        Me.lbl_dineroCuenta1.Location = New System.Drawing.Point(20, 173)
        Me.lbl_dineroCuenta1.Name = "lbl_dineroCuenta1"
        Me.lbl_dineroCuenta1.Size = New System.Drawing.Size(117, 15)
        Me.lbl_dineroCuenta1.TabIndex = 688
        Me.lbl_dineroCuenta1.Text = "Dinero en cuenta"
        '
        'lbl_comoPaga
        '
        Me.lbl_comoPaga.AutoSize = True
        Me.lbl_comoPaga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_comoPaga.Location = New System.Drawing.Point(20, 133)
        Me.lbl_comoPaga.Name = "lbl_comoPaga"
        Me.lbl_comoPaga.Size = New System.Drawing.Size(210, 16)
        Me.lbl_comoPaga.TabIndex = 687
        Me.lbl_comoPaga.Text = "¿Cómo va a pagar el cliente?"
        '
        'chk_efectivo
        '
        Me.chk_efectivo.AutoSize = True
        Me.chk_efectivo.Enabled = False
        Me.chk_efectivo.Location = New System.Drawing.Point(23, 224)
        Me.chk_efectivo.Name = "chk_efectivo"
        Me.chk_efectivo.Size = New System.Drawing.Size(65, 17)
        Me.chk_efectivo.TabIndex = 3
        Me.chk_efectivo.Text = "Efectivo"
        Me.chk_efectivo.UseVisualStyleBackColor = True
        '
        'cmb_cliente
        '
        Me.cmb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cliente.FormattingEnabled = True
        Me.cmb_cliente.Location = New System.Drawing.Point(163, 52)
        Me.cmb_cliente.Name = "cmb_cliente"
        Me.cmb_cliente.Size = New System.Drawing.Size(343, 21)
        Me.cmb_cliente.TabIndex = 1
        '
        'pic_searchCliente
        '
        Me.pic_searchCliente.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCliente.Location = New System.Drawing.Point(512, 52)
        Me.pic_searchCliente.Name = "pic_searchCliente"
        Me.pic_searchCliente.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCliente.TabIndex = 686
        Me.pic_searchCliente.TabStop = False
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(20, 52)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 685
        Me.lbl_cliente.Text = "Cliente"
        '
        'dtp_fechaCobro
        '
        Me.dtp_fechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fechaCobro.Location = New System.Drawing.Point(163, 20)
        Me.dtp_fechaCobro.Name = "dtp_fechaCobro"
        Me.dtp_fechaCobro.Size = New System.Drawing.Size(104, 20)
        Me.dtp_fechaCobro.TabIndex = 0
        '
        'lbl_fechaCobro
        '
        Me.lbl_fechaCobro.AutoSize = True
        Me.lbl_fechaCobro.Location = New System.Drawing.Point(20, 20)
        Me.lbl_fechaCobro.Name = "lbl_fechaCobro"
        Me.lbl_fechaCobro.Size = New System.Drawing.Size(85, 13)
        Me.lbl_fechaCobro.TabIndex = 671
        Me.lbl_fechaCobro.Text = "Fecha de cobro:"
        '
        'tb_cheques
        '
        Me.tb_cheques.BackColor = System.Drawing.SystemColors.Control
        Me.tb_cheques.Controls.Add(Me.lbl_totalCh)
        Me.tb_cheques.Controls.Add(Me.lbl_totalCheques)
        Me.tb_cheques.Controls.Add(Me.lbl_borrarbusquedaCH)
        Me.tb_cheques.Controls.Add(Me.lbl_buscarCheque)
        Me.tb_cheques.Controls.Add(Me.txt_searchCH)
        Me.tb_cheques.Controls.Add(Me.lbl_chSel)
        Me.tb_cheques.Controls.Add(Me.dg_viewCH)
        Me.tb_cheques.Controls.Add(Me.cmd_verCheques)
        Me.tb_cheques.Controls.Add(Me.cmd_addCheques)
        Me.tb_cheques.Controls.Add(Me.chk_cheque)
        Me.tb_cheques.Location = New System.Drawing.Point(4, 22)
        Me.tb_cheques.Name = "tb_cheques"
        Me.tb_cheques.Size = New System.Drawing.Size(576, 404)
        Me.tb_cheques.TabIndex = 2
        Me.tb_cheques.Text = "Cheques"
        '
        'lbl_totalCh
        '
        Me.lbl_totalCh.AutoSize = True
        Me.lbl_totalCh.Location = New System.Drawing.Point(190, 351)
        Me.lbl_totalCh.Name = "lbl_totalCh"
        Me.lbl_totalCh.Size = New System.Drawing.Size(19, 13)
        Me.lbl_totalCh.TabIndex = 706
        Me.lbl_totalCh.Text = "$$"
        '
        'lbl_totalCheques
        '
        Me.lbl_totalCheques.AutoSize = True
        Me.lbl_totalCheques.Location = New System.Drawing.Point(17, 351)
        Me.lbl_totalCheques.Name = "lbl_totalCheques"
        Me.lbl_totalCheques.Size = New System.Drawing.Size(146, 13)
        Me.lbl_totalCheques.TabIndex = 705
        Me.lbl_totalCheques.Text = "Total cheques seleccionados"
        '
        'lbl_borrarbusquedaCH
        '
        Me.lbl_borrarbusquedaCH.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_borrarbusquedaCH.AutoSize = True
        Me.lbl_borrarbusquedaCH.Enabled = False
        Me.lbl_borrarbusquedaCH.Location = New System.Drawing.Point(519, -11)
        Me.lbl_borrarbusquedaCH.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusquedaCH.Name = "lbl_borrarbusquedaCH"
        Me.lbl_borrarbusquedaCH.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusquedaCH.TabIndex = 699
        Me.lbl_borrarbusquedaCH.Text = "x"
        '
        'lbl_buscarCheque
        '
        Me.lbl_buscarCheque.AutoSize = True
        Me.lbl_buscarCheque.Location = New System.Drawing.Point(23, 88)
        Me.lbl_buscarCheque.Name = "lbl_buscarCheque"
        Me.lbl_buscarCheque.Size = New System.Drawing.Size(84, 13)
        Me.lbl_buscarCheque.TabIndex = 704
        Me.lbl_buscarCheque.Text = "Buscar cheques"
        '
        'txt_searchCH
        '
        Me.txt_searchCH.Enabled = False
        Me.txt_searchCH.Location = New System.Drawing.Point(246, 85)
        Me.txt_searchCH.Name = "txt_searchCH"
        Me.txt_searchCH.Size = New System.Drawing.Size(268, 20)
        Me.txt_searchCH.TabIndex = 698
        '
        'lbl_chSel
        '
        Me.lbl_chSel.AutoSize = True
        Me.lbl_chSel.Location = New System.Drawing.Point(22, 61)
        Me.lbl_chSel.Name = "lbl_chSel"
        Me.lbl_chSel.Size = New System.Drawing.Size(177, 13)
        Me.lbl_chSel.TabIndex = 703
        Me.lbl_chSel.Text = "Cheques disponibles/seleccionados"
        '
        'dg_viewCH
        '
        Me.dg_viewCH.AllowUserToAddRows = False
        Me.dg_viewCH.AllowUserToDeleteRows = False
        Me.dg_viewCH.AllowUserToOrderColumns = True
        Me.dg_viewCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewCH.ContextMenuStrip = Me.cms_general
        Me.dg_viewCH.Enabled = False
        Me.dg_viewCH.Location = New System.Drawing.Point(20, 111)
        Me.dg_viewCH.MultiSelect = False
        Me.dg_viewCH.Name = "dg_viewCH"
        Me.dg_viewCH.ReadOnly = True
        Me.dg_viewCH.RowHeadersVisible = False
        Me.dg_viewCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewCH.Size = New System.Drawing.Size(511, 224)
        Me.dg_viewCH.TabIndex = 700
        '
        'cms_general
        '
        Me.cms_general.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem})
        Me.cms_general.Name = "cms_general"
        Me.cms_general.Size = New System.Drawing.Size(107, 48)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'cmd_verCheques
        '
        Me.cmd_verCheques.Enabled = False
        Me.cmd_verCheques.Location = New System.Drawing.Point(404, 20)
        Me.cmd_verCheques.Name = "cmd_verCheques"
        Me.cmd_verCheques.Size = New System.Drawing.Size(127, 38)
        Me.cmd_verCheques.TabIndex = 697
        Me.cmd_verCheques.Text = "Seleccionar cheques"
        Me.cmd_verCheques.UseVisualStyleBackColor = True
        Me.cmd_verCheques.Visible = False
        '
        'cmd_addCheques
        '
        Me.cmd_addCheques.Enabled = False
        Me.cmd_addCheques.Location = New System.Drawing.Point(404, 346)
        Me.cmd_addCheques.Name = "cmd_addCheques"
        Me.cmd_addCheques.Size = New System.Drawing.Size(119, 23)
        Me.cmd_addCheques.TabIndex = 701
        Me.cmd_addCheques.Text = "Ingresar cheques"
        Me.cmd_addCheques.UseVisualStyleBackColor = True
        '
        'chk_cheque
        '
        Me.chk_cheque.AutoSize = True
        Me.chk_cheque.Enabled = False
        Me.chk_cheque.Location = New System.Drawing.Point(20, 20)
        Me.chk_cheque.Name = "chk_cheque"
        Me.chk_cheque.Size = New System.Drawing.Size(63, 17)
        Me.chk_cheque.TabIndex = 702
        Me.chk_cheque.Text = "Cheque"
        Me.chk_cheque.UseVisualStyleBackColor = True
        '
        'tb_transferencias
        '
        Me.tb_transferencias.BackColor = System.Drawing.SystemColors.Control
        Me.tb_transferencias.Controls.Add(Me.lbl_totalTransferencia)
        Me.tb_transferencias.Controls.Add(Me.lbl_totalTransferencias)
        Me.tb_transferencias.Controls.Add(Me.lbl_borrarbusquedaTransferencia)
        Me.tb_transferencias.Controls.Add(Me.lbl_buscarTransferencia)
        Me.tb_transferencias.Controls.Add(Me.txt_searchTransferencia)
        Me.tb_transferencias.Controls.Add(Me.dg_viewTransferencia)
        Me.tb_transferencias.Controls.Add(Me.cmd_addTransferencia)
        Me.tb_transferencias.Controls.Add(Me.chk_transferencia)
        Me.tb_transferencias.Location = New System.Drawing.Point(4, 22)
        Me.tb_transferencias.Name = "tb_transferencias"
        Me.tb_transferencias.Size = New System.Drawing.Size(576, 404)
        Me.tb_transferencias.TabIndex = 3
        Me.tb_transferencias.Text = "Transferencias"
        '
        'lbl_totalTransferencia
        '
        Me.lbl_totalTransferencia.AutoSize = True
        Me.lbl_totalTransferencia.Location = New System.Drawing.Point(131, 351)
        Me.lbl_totalTransferencia.Name = "lbl_totalTransferencia"
        Me.lbl_totalTransferencia.Size = New System.Drawing.Size(19, 13)
        Me.lbl_totalTransferencia.TabIndex = 713
        Me.lbl_totalTransferencia.Text = "$$"
        '
        'lbl_totalTransferencias
        '
        Me.lbl_totalTransferencias.AutoSize = True
        Me.lbl_totalTransferencias.Location = New System.Drawing.Point(17, 351)
        Me.lbl_totalTransferencias.Name = "lbl_totalTransferencias"
        Me.lbl_totalTransferencias.Size = New System.Drawing.Size(100, 13)
        Me.lbl_totalTransferencias.TabIndex = 712
        Me.lbl_totalTransferencias.Text = "Total transferencias"
        '
        'lbl_borrarbusquedaTransferencia
        '
        Me.lbl_borrarbusquedaTransferencia.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_borrarbusquedaTransferencia.AutoSize = True
        Me.lbl_borrarbusquedaTransferencia.Enabled = False
        Me.lbl_borrarbusquedaTransferencia.Location = New System.Drawing.Point(519, 60)
        Me.lbl_borrarbusquedaTransferencia.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusquedaTransferencia.Name = "lbl_borrarbusquedaTransferencia"
        Me.lbl_borrarbusquedaTransferencia.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusquedaTransferencia.TabIndex = 708
        Me.lbl_borrarbusquedaTransferencia.Text = "x"
        '
        'lbl_buscarTransferencia
        '
        Me.lbl_buscarTransferencia.AutoSize = True
        Me.lbl_buscarTransferencia.Location = New System.Drawing.Point(23, 60)
        Me.lbl_buscarTransferencia.Name = "lbl_buscarTransferencia"
        Me.lbl_buscarTransferencia.Size = New System.Drawing.Size(104, 13)
        Me.lbl_buscarTransferencia.TabIndex = 711
        Me.lbl_buscarTransferencia.Text = "Buscar transferencia"
        '
        'txt_searchTransferencia
        '
        Me.txt_searchTransferencia.Enabled = False
        Me.txt_searchTransferencia.Location = New System.Drawing.Point(246, 57)
        Me.txt_searchTransferencia.Name = "txt_searchTransferencia"
        Me.txt_searchTransferencia.Size = New System.Drawing.Size(268, 20)
        Me.txt_searchTransferencia.TabIndex = 707
        '
        'dg_viewTransferencia
        '
        Me.dg_viewTransferencia.AllowUserToAddRows = False
        Me.dg_viewTransferencia.AllowUserToDeleteRows = False
        Me.dg_viewTransferencia.AllowUserToOrderColumns = True
        Me.dg_viewTransferencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewTransferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewTransferencia.ContextMenuStrip = Me.cms_general
        Me.dg_viewTransferencia.Enabled = False
        Me.dg_viewTransferencia.Location = New System.Drawing.Point(20, 83)
        Me.dg_viewTransferencia.MultiSelect = False
        Me.dg_viewTransferencia.Name = "dg_viewTransferencia"
        Me.dg_viewTransferencia.ReadOnly = True
        Me.dg_viewTransferencia.RowHeadersVisible = False
        Me.dg_viewTransferencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewTransferencia.Size = New System.Drawing.Size(511, 224)
        Me.dg_viewTransferencia.TabIndex = 709
        '
        'cmd_addTransferencia
        '
        Me.cmd_addTransferencia.Enabled = False
        Me.cmd_addTransferencia.Location = New System.Drawing.Point(404, 346)
        Me.cmd_addTransferencia.Name = "cmd_addTransferencia"
        Me.cmd_addTransferencia.Size = New System.Drawing.Size(119, 23)
        Me.cmd_addTransferencia.TabIndex = 710
        Me.cmd_addTransferencia.Text = "Ingresar transferencia"
        Me.cmd_addTransferencia.UseVisualStyleBackColor = True
        '
        'chk_transferencia
        '
        Me.chk_transferencia.AutoSize = True
        Me.chk_transferencia.Enabled = False
        Me.chk_transferencia.Location = New System.Drawing.Point(20, 20)
        Me.chk_transferencia.Name = "chk_transferencia"
        Me.chk_transferencia.Size = New System.Drawing.Size(180, 17)
        Me.chk_transferencia.TabIndex = 678
        Me.chk_transferencia.Text = "Transferencia/depósito bancario"
        Me.chk_transferencia.UseVisualStyleBackColor = True
        '
        'tb_retenciones
        '
        Me.tb_retenciones.BackColor = System.Drawing.SystemColors.Control
        Me.tb_retenciones.Controls.Add(Me.lbl_totalRetencion)
        Me.tb_retenciones.Controls.Add(Me.lbl_totalRetenciones)
        Me.tb_retenciones.Controls.Add(Me.lbl_borrarbusquedaRetencion)
        Me.tb_retenciones.Controls.Add(Me.lbl_buscarRetencion)
        Me.tb_retenciones.Controls.Add(Me.txt_searchRetencion)
        Me.tb_retenciones.Controls.Add(Me.dg_viewRetencion)
        Me.tb_retenciones.Controls.Add(Me.cmd_addRetencion)
        Me.tb_retenciones.Controls.Add(Me.chk_retenciones)
        Me.tb_retenciones.Location = New System.Drawing.Point(4, 22)
        Me.tb_retenciones.Name = "tb_retenciones"
        Me.tb_retenciones.Size = New System.Drawing.Size(576, 404)
        Me.tb_retenciones.TabIndex = 5
        Me.tb_retenciones.Text = "Retenciones"
        '
        'lbl_totalRetencion
        '
        Me.lbl_totalRetencion.AutoSize = True
        Me.lbl_totalRetencion.Location = New System.Drawing.Point(131, 351)
        Me.lbl_totalRetencion.Name = "lbl_totalRetencion"
        Me.lbl_totalRetencion.Size = New System.Drawing.Size(19, 13)
        Me.lbl_totalRetencion.TabIndex = 721
        Me.lbl_totalRetencion.Text = "$$"
        '
        'lbl_totalRetenciones
        '
        Me.lbl_totalRetenciones.AutoSize = True
        Me.lbl_totalRetenciones.Location = New System.Drawing.Point(17, 351)
        Me.lbl_totalRetenciones.Name = "lbl_totalRetenciones"
        Me.lbl_totalRetenciones.Size = New System.Drawing.Size(89, 13)
        Me.lbl_totalRetenciones.TabIndex = 720
        Me.lbl_totalRetenciones.Text = "Total retenciones"
        '
        'lbl_borrarbusquedaRetencion
        '
        Me.lbl_borrarbusquedaRetencion.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_borrarbusquedaRetencion.AutoSize = True
        Me.lbl_borrarbusquedaRetencion.Enabled = False
        Me.lbl_borrarbusquedaRetencion.Location = New System.Drawing.Point(519, 60)
        Me.lbl_borrarbusquedaRetencion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusquedaRetencion.Name = "lbl_borrarbusquedaRetencion"
        Me.lbl_borrarbusquedaRetencion.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusquedaRetencion.TabIndex = 716
        Me.lbl_borrarbusquedaRetencion.Text = "x"
        '
        'lbl_buscarRetencion
        '
        Me.lbl_buscarRetencion.AutoSize = True
        Me.lbl_buscarRetencion.Location = New System.Drawing.Point(23, 60)
        Me.lbl_buscarRetencion.Name = "lbl_buscarRetencion"
        Me.lbl_buscarRetencion.Size = New System.Drawing.Size(87, 13)
        Me.lbl_buscarRetencion.TabIndex = 719
        Me.lbl_buscarRetencion.Text = "Buscar retencion"
        '
        'txt_searchRetencion
        '
        Me.txt_searchRetencion.Enabled = False
        Me.txt_searchRetencion.Location = New System.Drawing.Point(246, 57)
        Me.txt_searchRetencion.Name = "txt_searchRetencion"
        Me.txt_searchRetencion.Size = New System.Drawing.Size(268, 20)
        Me.txt_searchRetencion.TabIndex = 715
        '
        'dg_viewRetencion
        '
        Me.dg_viewRetencion.AllowUserToAddRows = False
        Me.dg_viewRetencion.AllowUserToDeleteRows = False
        Me.dg_viewRetencion.AllowUserToOrderColumns = True
        Me.dg_viewRetencion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewRetencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewRetencion.ContextMenuStrip = Me.cms_general
        Me.dg_viewRetencion.Enabled = False
        Me.dg_viewRetencion.Location = New System.Drawing.Point(20, 83)
        Me.dg_viewRetencion.MultiSelect = False
        Me.dg_viewRetencion.Name = "dg_viewRetencion"
        Me.dg_viewRetencion.ReadOnly = True
        Me.dg_viewRetencion.RowHeadersVisible = False
        Me.dg_viewRetencion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewRetencion.Size = New System.Drawing.Size(511, 224)
        Me.dg_viewRetencion.TabIndex = 717
        '
        'cmd_addRetencion
        '
        Me.cmd_addRetencion.Enabled = False
        Me.cmd_addRetencion.Location = New System.Drawing.Point(404, 346)
        Me.cmd_addRetencion.Name = "cmd_addRetencion"
        Me.cmd_addRetencion.Size = New System.Drawing.Size(119, 23)
        Me.cmd_addRetencion.TabIndex = 718
        Me.cmd_addRetencion.Text = "Ingresar retencion"
        Me.cmd_addRetencion.UseVisualStyleBackColor = True
        '
        'chk_retenciones
        '
        Me.chk_retenciones.AutoSize = True
        Me.chk_retenciones.Enabled = False
        Me.chk_retenciones.Location = New System.Drawing.Point(20, 20)
        Me.chk_retenciones.Name = "chk_retenciones"
        Me.chk_retenciones.Size = New System.Drawing.Size(86, 17)
        Me.chk_retenciones.TabIndex = 714
        Me.chk_retenciones.Text = "Retenciones"
        Me.chk_retenciones.UseVisualStyleBackColor = True
        '
        'tb_otros
        '
        Me.tb_otros.BackColor = System.Drawing.SystemColors.Control
        Me.tb_otros.Controls.Add(Me.txt_aplicaFc)
        Me.tb_otros.Controls.Add(Me.lbl_aplicaFc)
        Me.tb_otros.Location = New System.Drawing.Point(4, 22)
        Me.tb_otros.Name = "tb_otros"
        Me.tb_otros.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_otros.Size = New System.Drawing.Size(576, 404)
        Me.tb_otros.TabIndex = 1
        Me.tb_otros.Text = "Otros"
        '
        'tb_notas
        '
        Me.tb_notas.BackColor = System.Drawing.SystemColors.Control
        Me.tb_notas.Controls.Add(Me.txt_notas)
        Me.tb_notas.Controls.Add(Me.lbl_notas)
        Me.tb_notas.Location = New System.Drawing.Point(4, 22)
        Me.tb_notas.Name = "tb_notas"
        Me.tb_notas.Size = New System.Drawing.Size(576, 404)
        Me.tb_notas.TabIndex = 4
        Me.tb_notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Enabled = False
        Me.txt_notas.Location = New System.Drawing.Point(20, 49)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(533, 98)
        Me.txt_notas.TabIndex = 675
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(20, 20)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 676
        Me.lbl_notas.Text = "Notas"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(88, 554)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(137, 20)
        Me.TextBox1.TabIndex = 663
        '
        'lbl_firmante
        '
        Me.lbl_firmante.AutoSize = True
        Me.lbl_firmante.Location = New System.Drawing.Point(30, 557)
        Me.lbl_firmante.Name = "lbl_firmante"
        Me.lbl_firmante.Size = New System.Drawing.Size(47, 13)
        Me.lbl_firmante.TabIndex = 664
        Me.lbl_firmante.Text = "Firmante"
        '
        'add_cobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 646)
        Me.Controls.Add(Me.lbl_firmante)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.tbControl)
        Me.Controls.Add(Me.lbl_importePago)
        Me.Controls.Add(Me.lbl_pago)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_fechaCarga)
        Me.Controls.Add(Me.lbl_fechaCarga1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "add_cobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar cobros"
        Me.tbControl.ResumeLayout(False)
        Me.tb_cobro.ResumeLayout(False)
        Me.tb_cobro.PerformLayout()
        CType(Me.pic_searchCCCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_cheques.ResumeLayout(False)
        Me.tb_cheques.PerformLayout()
        CType(Me.dg_viewCH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_general.ResumeLayout(False)
        Me.tb_transferencias.ResumeLayout(False)
        Me.tb_transferencias.PerformLayout()
        CType(Me.dg_viewTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_retenciones.ResumeLayout(False)
        Me.tb_retenciones.PerformLayout()
        CType(Me.dg_viewRetencion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_otros.ResumeLayout(False)
        Me.tb_otros.PerformLayout()
        Me.tb_notas.ResumeLayout(False)
        Me.tb_notas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_fechaCarga1 As Label
    Friend WithEvents lbl_fechaCarga As Label
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents lbl_importePago As Label
    Friend WithEvents lbl_pago As Label
    Friend WithEvents txt_aplicaFc As TextBox
    Friend WithEvents lbl_aplicaFc As Label
    Friend WithEvents tbControl As TabControl
    Friend WithEvents tb_cobro As TabPage
    Friend WithEvents lblpeso1 As Label
    Friend WithEvents cmb_cc As ComboBox
    Friend WithEvents pic_searchCCCliente As PictureBox
    Friend WithEvents lbl_ccc As Label
    Friend WithEvents txt_efectivo As TextBox
    Friend WithEvents lbl_dineroCuenta As Label
    Friend WithEvents lbl_dineroCuenta1 As Label
    Friend WithEvents lbl_comoPaga As Label
    Friend WithEvents chk_efectivo As CheckBox
    Friend WithEvents cmb_cliente As ComboBox
    Friend WithEvents pic_searchCliente As PictureBox
    Friend WithEvents lbl_cliente As Label
    Friend WithEvents dtp_fechaCobro As DateTimePicker
    Friend WithEvents lbl_fechaCobro As Label
    Friend WithEvents tb_otros As TabPage
    Friend WithEvents tb_cheques As TabPage
    Friend WithEvents lbl_totalCh As Label
    Friend WithEvents lbl_totalCheques As Label
    Friend WithEvents lbl_borrarbusquedaCH As Label
    Friend WithEvents lbl_buscarCheque As Label
    Friend WithEvents txt_searchCH As TextBox
    Friend WithEvents lbl_chSel As Label
    Friend WithEvents dg_viewCH As DataGridView
    Friend WithEvents cmd_verCheques As Button
    Friend WithEvents cmd_addCheques As Button
    Friend WithEvents chk_cheque As CheckBox
    Friend WithEvents tb_transferencias As TabPage
    Friend WithEvents lbl_totalTransferencia As Label
    Friend WithEvents lbl_totalTransferencias As Label
    Friend WithEvents lbl_borrarbusquedaTransferencia As Label
    Friend WithEvents lbl_buscarTransferencia As Label
    Friend WithEvents txt_searchTransferencia As TextBox
    Friend WithEvents dg_viewTransferencia As DataGridView
    Friend WithEvents cmd_addTransferencia As Button
    Friend WithEvents chk_transferencia As CheckBox
    Friend WithEvents tb_notas As TabPage
    Friend WithEvents txt_notas As TextBox
    Friend WithEvents lbl_notas As Label
    Friend WithEvents cms_general As ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tb_retenciones As TabPage
    Friend WithEvents lbl_totalRetencion As Label
    Friend WithEvents lbl_totalRetenciones As Label
    Friend WithEvents lbl_borrarbusquedaRetencion As Label
    Friend WithEvents lbl_buscarRetencion As Label
    Friend WithEvents txt_searchRetencion As TextBox
    Friend WithEvents dg_viewRetencion As DataGridView
    Friend WithEvents cmd_addRetencion As Button
    Friend WithEvents chk_retenciones As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lbl_firmante As Label
End Class
