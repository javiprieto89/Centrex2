<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_pago
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
        Me.lbl_fechaCarga1 = New System.Windows.Forms.Label()
        Me.lbl_fechaCobro = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.dtp_fechaPago = New System.Windows.Forms.DateTimePicker()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.chk_efectivo = New System.Windows.Forms.CheckBox()
        Me.lbl_comoPaga = New System.Windows.Forms.Label()
        Me.chk_cheque = New System.Windows.Forms.CheckBox()
        Me.lbl_dineroCuenta1 = New System.Windows.Forms.Label()
        Me.lbl_dineroCuenta = New System.Windows.Forms.Label()
        Me.txt_efectivo = New System.Windows.Forms.TextBox()
        Me.lbl_facturasPagar = New System.Windows.Forms.Label()
        Me.chklb_facturasPendientes = New System.Windows.Forms.CheckedListBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmb_cc = New System.Windows.Forms.ComboBox()
        Me.lbl_ccp = New System.Windows.Forms.Label()
        Me.cmd_verCheques = New System.Windows.Forms.Button()
        Me.lbl_importePago = New System.Windows.Forms.Label()
        Me.lbl_pago = New System.Windows.Forms.Label()
        Me.lblpeso1 = New System.Windows.Forms.Label()
        Me.lbl_borrarbusqueda = New System.Windows.Forms.Label()
        Me.pic_searchCCProveedor = New System.Windows.Forms.PictureBox()
        Me.pic_searchProveedor = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.cheques = New System.Windows.Forms.TabPage()
        Me.lbl_totalCh = New System.Windows.Forms.Label()
        Me.lbl_totalCheques = New System.Windows.Forms.Label()
        Me.lbl_buscarCheque = New System.Windows.Forms.Label()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.lbl_chSel = New System.Windows.Forms.Label()
        Me.dg_viewCH = New System.Windows.Forms.DataGridView()
        Me.cmd_addCheques = New System.Windows.Forms.Button()
        Me.transferencias = New System.Windows.Forms.TabPage()
        Me.lbl_totalTransferencia = New System.Windows.Forms.Label()
        Me.lbl_totalTransferencias = New System.Windows.Forms.Label()
        Me.lbl_buscarTransferencia = New System.Windows.Forms.Label()
        Me.txt_searchTransferencia = New System.Windows.Forms.TextBox()
        Me.dg_viewTransferencia = New System.Windows.Forms.DataGridView()
        Me.cmd_addTransferencia = New System.Windows.Forms.Button()
        Me.chk_transferencia = New System.Windows.Forms.CheckBox()
        Me.tb_nFC_importe = New System.Windows.Forms.TabPage()
        Me.dg_view_nFC_importes = New System.Windows.Forms.DataGridView()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_aplicaFc = New System.Windows.Forms.Label()
        Me.notas = New System.Windows.Forms.TabPage()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        CType(Me.pic_searchCCProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.cheques.SuspendLayout()
        CType(Me.dg_viewCH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.transferencias.SuspendLayout()
        CType(Me.dg_viewTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_nFC_importe.SuspendLayout()
        CType(Me.dg_view_nFC_importes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.notas.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_fechaCarga1
        '
        Me.lbl_fechaCarga1.AutoSize = True
        Me.lbl_fechaCarga1.Location = New System.Drawing.Point(18, 23)
        Me.lbl_fechaCarga1.Name = "lbl_fechaCarga1"
        Me.lbl_fechaCarga1.Size = New System.Drawing.Size(85, 13)
        Me.lbl_fechaCarga1.TabIndex = 0
        Me.lbl_fechaCarga1.Text = "Fecha de carga:"
        '
        'lbl_fechaCobro
        '
        Me.lbl_fechaCobro.AutoSize = True
        Me.lbl_fechaCobro.Location = New System.Drawing.Point(18, 62)
        Me.lbl_fechaCobro.Name = "lbl_fechaCobro"
        Me.lbl_fechaCobro.Size = New System.Drawing.Size(82, 13)
        Me.lbl_fechaCobro.TabIndex = 1
        Me.lbl_fechaCobro.Text = "Fecha de pago:"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(173, 23)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(50, 13)
        Me.lbl_fecha.TabIndex = 2
        Me.lbl_fecha.Text = "%carga%"
        '
        'dtp_fechaPago
        '
        Me.dtp_fechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fechaPago.Location = New System.Drawing.Point(176, 55)
        Me.dtp_fechaPago.Name = "dtp_fechaPago"
        Me.dtp_fechaPago.Size = New System.Drawing.Size(104, 20)
        Me.dtp_fechaPago.TabIndex = 0
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(176, 93)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(343, 21)
        Me.cmb_proveedor.TabIndex = 1
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(18, 101)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 636
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'chk_efectivo
        '
        Me.chk_efectivo.AutoSize = True
        Me.chk_efectivo.Enabled = False
        Me.chk_efectivo.Location = New System.Drawing.Point(18, 272)
        Me.chk_efectivo.Name = "chk_efectivo"
        Me.chk_efectivo.Size = New System.Drawing.Size(65, 17)
        Me.chk_efectivo.TabIndex = 3
        Me.chk_efectivo.Text = "Efectivo"
        Me.chk_efectivo.UseVisualStyleBackColor = True
        '
        'lbl_comoPaga
        '
        Me.lbl_comoPaga.AutoSize = True
        Me.lbl_comoPaga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_comoPaga.Location = New System.Drawing.Point(18, 228)
        Me.lbl_comoPaga.Name = "lbl_comoPaga"
        Me.lbl_comoPaga.Size = New System.Drawing.Size(242, 16)
        Me.lbl_comoPaga.TabIndex = 640
        Me.lbl_comoPaga.Text = "¿Cómo se va a constituir el pago?"
        '
        'chk_cheque
        '
        Me.chk_cheque.AutoSize = True
        Me.chk_cheque.Enabled = False
        Me.chk_cheque.Location = New System.Drawing.Point(18, 18)
        Me.chk_cheque.Name = "chk_cheque"
        Me.chk_cheque.Size = New System.Drawing.Size(63, 17)
        Me.chk_cheque.TabIndex = 7
        Me.chk_cheque.Text = "Cheque"
        Me.chk_cheque.UseVisualStyleBackColor = True
        '
        'lbl_dineroCuenta1
        '
        Me.lbl_dineroCuenta1.AutoSize = True
        Me.lbl_dineroCuenta1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dineroCuenta1.ForeColor = System.Drawing.Color.Black
        Me.lbl_dineroCuenta1.Location = New System.Drawing.Point(18, 186)
        Me.lbl_dineroCuenta1.Name = "lbl_dineroCuenta1"
        Me.lbl_dineroCuenta1.Size = New System.Drawing.Size(90, 15)
        Me.lbl_dineroCuenta1.TabIndex = 643
        Me.lbl_dineroCuenta1.Text = "Saldo de CC."
        '
        'lbl_dineroCuenta
        '
        Me.lbl_dineroCuenta.AutoSize = True
        Me.lbl_dineroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dineroCuenta.ForeColor = System.Drawing.Color.Green
        Me.lbl_dineroCuenta.Location = New System.Drawing.Point(163, 186)
        Me.lbl_dineroCuenta.Name = "lbl_dineroCuenta"
        Me.lbl_dineroCuenta.Size = New System.Drawing.Size(24, 16)
        Me.lbl_dineroCuenta.TabIndex = 644
        Me.lbl_dineroCuenta.Text = "$$"
        '
        'txt_efectivo
        '
        Me.txt_efectivo.Enabled = False
        Me.txt_efectivo.Location = New System.Drawing.Point(257, 269)
        Me.txt_efectivo.Name = "txt_efectivo"
        Me.txt_efectivo.Size = New System.Drawing.Size(285, 20)
        Me.txt_efectivo.TabIndex = 4
        '
        'lbl_facturasPagar
        '
        Me.lbl_facturasPagar.AutoSize = True
        Me.lbl_facturasPagar.Location = New System.Drawing.Point(619, 18)
        Me.lbl_facturasPagar.Name = "lbl_facturasPagar"
        Me.lbl_facturasPagar.Size = New System.Drawing.Size(148, 13)
        Me.lbl_facturasPagar.TabIndex = 648
        Me.lbl_facturasPagar.Text = "Facturas pendientes de cobro"
        '
        'chklb_facturasPendientes
        '
        Me.chklb_facturasPendientes.Enabled = False
        Me.chklb_facturasPendientes.FormattingEnabled = True
        Me.chklb_facturasPendientes.Location = New System.Drawing.Point(622, 46)
        Me.chklb_facturasPendientes.Name = "chklb_facturasPendientes"
        Me.chklb_facturasPendientes.Size = New System.Drawing.Size(464, 259)
        Me.chklb_facturasPendientes.TabIndex = 649
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(307, 741)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 11
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(209, 741)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 10
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmb_cc
        '
        Me.cmb_cc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_cc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_cc.FormattingEnabled = True
        Me.cmb_cc.Location = New System.Drawing.Point(176, 132)
        Me.cmb_cc.Name = "cmb_cc"
        Me.cmb_cc.Size = New System.Drawing.Size(343, 21)
        Me.cmb_cc.TabIndex = 2
        '
        'lbl_ccp
        '
        Me.lbl_ccp.AutoSize = True
        Me.lbl_ccp.Location = New System.Drawing.Point(18, 140)
        Me.lbl_ccp.Name = "lbl_ccp"
        Me.lbl_ccp.Size = New System.Drawing.Size(153, 13)
        Me.lbl_ccp.TabIndex = 653
        Me.lbl_ccp.Text = "Cuenta corriente del proveedor"
        '
        'cmd_verCheques
        '
        Me.cmd_verCheques.Enabled = False
        Me.cmd_verCheques.Location = New System.Drawing.Point(391, 18)
        Me.cmd_verCheques.Name = "cmd_verCheques"
        Me.cmd_verCheques.Size = New System.Drawing.Size(127, 38)
        Me.cmd_verCheques.TabIndex = 7
        Me.cmd_verCheques.Text = "Seleccionar cheques"
        Me.cmd_verCheques.UseVisualStyleBackColor = True
        Me.cmd_verCheques.Visible = False
        '
        'lbl_importePago
        '
        Me.lbl_importePago.AutoSize = True
        Me.lbl_importePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_importePago.ForeColor = System.Drawing.Color.Green
        Me.lbl_importePago.Location = New System.Drawing.Point(206, 703)
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
        Me.lbl_pago.Location = New System.Drawing.Point(18, 703)
        Me.lbl_pago.Name = "lbl_pago"
        Me.lbl_pago.Size = New System.Drawing.Size(148, 15)
        Me.lbl_pago.TabIndex = 661
        Me.lbl_pago.Text = "Importe total del pago"
        '
        'lblpeso1
        '
        Me.lblpeso1.AutoSize = True
        Me.lblpeso1.Location = New System.Drawing.Point(238, 269)
        Me.lblpeso1.Name = "lblpeso1"
        Me.lblpeso1.Size = New System.Drawing.Size(13, 13)
        Me.lblpeso1.TabIndex = 663
        Me.lblpeso1.Text = "$"
        '
        'lbl_borrarbusqueda
        '
        Me.lbl_borrarbusqueda.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_borrarbusqueda.AutoSize = True
        Me.lbl_borrarbusqueda.Enabled = False
        Me.lbl_borrarbusqueda.Location = New System.Drawing.Point(-12, 427)
        Me.lbl_borrarbusqueda.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusqueda.Name = "lbl_borrarbusqueda"
        Me.lbl_borrarbusqueda.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusqueda.TabIndex = 667
        Me.lbl_borrarbusqueda.Text = "x"
        '
        'pic_searchCCProveedor
        '
        Me.pic_searchCCProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCCProveedor.Location = New System.Drawing.Point(525, 131)
        Me.pic_searchCCProveedor.Name = "pic_searchCCProveedor"
        Me.pic_searchCCProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCCProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCCProveedor.TabIndex = 654
        Me.pic_searchCCProveedor.TabStop = False
        '
        'pic_searchProveedor
        '
        Me.pic_searchProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchProveedor.Location = New System.Drawing.Point(524, 92)
        Me.pic_searchProveedor.Name = "pic_searchProveedor"
        Me.pic_searchProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchProveedor.TabIndex = 637
        Me.pic_searchProveedor.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.cheques)
        Me.TabControl1.Controls.Add(Me.transferencias)
        Me.TabControl1.Controls.Add(Me.tb_nFC_importe)
        Me.TabControl1.Controls.Add(Me.notas)
        Me.TabControl1.Location = New System.Drawing.Point(18, 307)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(560, 386)
        Me.TabControl1.TabIndex = 670
        '
        'cheques
        '
        Me.cheques.BackColor = System.Drawing.SystemColors.Control
        Me.cheques.Controls.Add(Me.lbl_totalCh)
        Me.cheques.Controls.Add(Me.lbl_totalCheques)
        Me.cheques.Controls.Add(Me.lbl_buscarCheque)
        Me.cheques.Controls.Add(Me.txt_search)
        Me.cheques.Controls.Add(Me.lbl_chSel)
        Me.cheques.Controls.Add(Me.cmd_verCheques)
        Me.cheques.Controls.Add(Me.dg_viewCH)
        Me.cheques.Controls.Add(Me.cmd_addCheques)
        Me.cheques.Controls.Add(Me.chk_cheque)
        Me.cheques.Location = New System.Drawing.Point(4, 22)
        Me.cheques.Name = "cheques"
        Me.cheques.Padding = New System.Windows.Forms.Padding(3)
        Me.cheques.Size = New System.Drawing.Size(552, 360)
        Me.cheques.TabIndex = 0
        Me.cheques.Text = "Cheques"
        '
        'lbl_totalCh
        '
        Me.lbl_totalCh.AutoSize = True
        Me.lbl_totalCh.Location = New System.Drawing.Point(194, 322)
        Me.lbl_totalCh.Name = "lbl_totalCh"
        Me.lbl_totalCh.Size = New System.Drawing.Size(19, 13)
        Me.lbl_totalCh.TabIndex = 676
        Me.lbl_totalCh.Text = "$$"
        '
        'lbl_totalCheques
        '
        Me.lbl_totalCheques.AutoSize = True
        Me.lbl_totalCheques.Location = New System.Drawing.Point(9, 322)
        Me.lbl_totalCheques.Name = "lbl_totalCheques"
        Me.lbl_totalCheques.Size = New System.Drawing.Size(146, 13)
        Me.lbl_totalCheques.TabIndex = 675
        Me.lbl_totalCheques.Text = "Total cheques seleccionados"
        '
        'lbl_buscarCheque
        '
        Me.lbl_buscarCheque.AutoSize = True
        Me.lbl_buscarCheque.Location = New System.Drawing.Point(15, 83)
        Me.lbl_buscarCheque.Name = "lbl_buscarCheque"
        Me.lbl_buscarCheque.Size = New System.Drawing.Size(84, 13)
        Me.lbl_buscarCheque.TabIndex = 674
        Me.lbl_buscarCheque.Text = "Buscar cheques"
        '
        'txt_search
        '
        Me.txt_search.Enabled = False
        Me.txt_search.Location = New System.Drawing.Point(250, 83)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(268, 20)
        Me.txt_search.TabIndex = 673
        '
        'lbl_chSel
        '
        Me.lbl_chSel.AutoSize = True
        Me.lbl_chSel.Location = New System.Drawing.Point(15, 57)
        Me.lbl_chSel.Name = "lbl_chSel"
        Me.lbl_chSel.Size = New System.Drawing.Size(177, 13)
        Me.lbl_chSel.TabIndex = 672
        Me.lbl_chSel.Text = "Cheques disponibles/seleccionados"
        '
        'dg_viewCH
        '
        Me.dg_viewCH.AllowUserToAddRows = False
        Me.dg_viewCH.AllowUserToDeleteRows = False
        Me.dg_viewCH.AllowUserToOrderColumns = True
        Me.dg_viewCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewCH.Enabled = False
        Me.dg_viewCH.Location = New System.Drawing.Point(12, 109)
        Me.dg_viewCH.MultiSelect = False
        Me.dg_viewCH.Name = "dg_viewCH"
        Me.dg_viewCH.ReadOnly = True
        Me.dg_viewCH.RowHeadersVisible = False
        Me.dg_viewCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewCH.Size = New System.Drawing.Size(511, 197)
        Me.dg_viewCH.TabIndex = 670
        '
        'cmd_addCheques
        '
        Me.cmd_addCheques.Enabled = False
        Me.cmd_addCheques.Location = New System.Drawing.Point(404, 312)
        Me.cmd_addCheques.Name = "cmd_addCheques"
        Me.cmd_addCheques.Size = New System.Drawing.Size(119, 23)
        Me.cmd_addCheques.TabIndex = 671
        Me.cmd_addCheques.Text = "Ingresar cheques"
        Me.cmd_addCheques.UseVisualStyleBackColor = True
        '
        'transferencias
        '
        Me.transferencias.BackColor = System.Drawing.SystemColors.Control
        Me.transferencias.Controls.Add(Me.lbl_totalTransferencia)
        Me.transferencias.Controls.Add(Me.lbl_totalTransferencias)
        Me.transferencias.Controls.Add(Me.lbl_buscarTransferencia)
        Me.transferencias.Controls.Add(Me.txt_searchTransferencia)
        Me.transferencias.Controls.Add(Me.dg_viewTransferencia)
        Me.transferencias.Controls.Add(Me.cmd_addTransferencia)
        Me.transferencias.Controls.Add(Me.chk_transferencia)
        Me.transferencias.Location = New System.Drawing.Point(4, 22)
        Me.transferencias.Name = "transferencias"
        Me.transferencias.Padding = New System.Windows.Forms.Padding(3)
        Me.transferencias.Size = New System.Drawing.Size(552, 360)
        Me.transferencias.TabIndex = 1
        Me.transferencias.Text = "Transferencias"
        '
        'lbl_totalTransferencia
        '
        Me.lbl_totalTransferencia.AutoSize = True
        Me.lbl_totalTransferencia.Location = New System.Drawing.Point(145, 337)
        Me.lbl_totalTransferencia.Name = "lbl_totalTransferencia"
        Me.lbl_totalTransferencia.Size = New System.Drawing.Size(19, 13)
        Me.lbl_totalTransferencia.TabIndex = 719
        Me.lbl_totalTransferencia.Text = "$$"
        '
        'lbl_totalTransferencias
        '
        Me.lbl_totalTransferencias.AutoSize = True
        Me.lbl_totalTransferencias.Location = New System.Drawing.Point(18, 337)
        Me.lbl_totalTransferencias.Name = "lbl_totalTransferencias"
        Me.lbl_totalTransferencias.Size = New System.Drawing.Size(100, 13)
        Me.lbl_totalTransferencias.TabIndex = 718
        Me.lbl_totalTransferencias.Text = "Total transferencias"
        '
        'lbl_buscarTransferencia
        '
        Me.lbl_buscarTransferencia.AutoSize = True
        Me.lbl_buscarTransferencia.Location = New System.Drawing.Point(18, 49)
        Me.lbl_buscarTransferencia.Name = "lbl_buscarTransferencia"
        Me.lbl_buscarTransferencia.Size = New System.Drawing.Size(104, 13)
        Me.lbl_buscarTransferencia.TabIndex = 717
        Me.lbl_buscarTransferencia.Text = "Buscar transferencia"
        '
        'txt_searchTransferencia
        '
        Me.txt_searchTransferencia.Enabled = False
        Me.txt_searchTransferencia.Location = New System.Drawing.Point(265, 46)
        Me.txt_searchTransferencia.Name = "txt_searchTransferencia"
        Me.txt_searchTransferencia.Size = New System.Drawing.Size(268, 20)
        Me.txt_searchTransferencia.TabIndex = 714
        '
        'dg_viewTransferencia
        '
        Me.dg_viewTransferencia.AllowUserToAddRows = False
        Me.dg_viewTransferencia.AllowUserToDeleteRows = False
        Me.dg_viewTransferencia.AllowUserToOrderColumns = True
        Me.dg_viewTransferencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewTransferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewTransferencia.Enabled = False
        Me.dg_viewTransferencia.Location = New System.Drawing.Point(18, 72)
        Me.dg_viewTransferencia.MultiSelect = False
        Me.dg_viewTransferencia.Name = "dg_viewTransferencia"
        Me.dg_viewTransferencia.ReadOnly = True
        Me.dg_viewTransferencia.RowHeadersVisible = False
        Me.dg_viewTransferencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewTransferencia.Size = New System.Drawing.Size(511, 242)
        Me.dg_viewTransferencia.TabIndex = 715
        '
        'cmd_addTransferencia
        '
        Me.cmd_addTransferencia.Enabled = False
        Me.cmd_addTransferencia.Location = New System.Drawing.Point(414, 327)
        Me.cmd_addTransferencia.Name = "cmd_addTransferencia"
        Me.cmd_addTransferencia.Size = New System.Drawing.Size(119, 23)
        Me.cmd_addTransferencia.TabIndex = 716
        Me.cmd_addTransferencia.Text = "Ingresar transferencia"
        Me.cmd_addTransferencia.UseVisualStyleBackColor = True
        '
        'chk_transferencia
        '
        Me.chk_transferencia.AutoSize = True
        Me.chk_transferencia.Enabled = False
        Me.chk_transferencia.Location = New System.Drawing.Point(18, 18)
        Me.chk_transferencia.Name = "chk_transferencia"
        Me.chk_transferencia.Size = New System.Drawing.Size(180, 17)
        Me.chk_transferencia.TabIndex = 713
        Me.chk_transferencia.Text = "Transferencia/depósito bancario"
        Me.chk_transferencia.UseVisualStyleBackColor = True
        '
        'tb_nFC_importe
        '
        Me.tb_nFC_importe.BackColor = System.Drawing.SystemColors.Control
        Me.tb_nFC_importe.Controls.Add(Me.dg_view_nFC_importes)
        Me.tb_nFC_importe.Controls.Add(Me.lbl_aplicaFc)
        Me.tb_nFC_importe.Location = New System.Drawing.Point(4, 22)
        Me.tb_nFC_importe.Name = "tb_nFC_importe"
        Me.tb_nFC_importe.Size = New System.Drawing.Size(552, 360)
        Me.tb_nFC_importe.TabIndex = 3
        Me.tb_nFC_importe.Text = "Nº FC / Importe"
        '
        'dg_view_nFC_importes
        '
        Me.dg_view_nFC_importes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view_nFC_importes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fecha, Me.factura, Me.importe})
        Me.dg_view_nFC_importes.Enabled = False
        Me.dg_view_nFC_importes.Location = New System.Drawing.Point(21, 48)
        Me.dg_view_nFC_importes.Name = "dg_view_nFC_importes"
        Me.dg_view_nFC_importes.Size = New System.Drawing.Size(514, 112)
        Me.dg_view_nFC_importes.TabIndex = 677
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        '
        'factura
        '
        Me.factura.HeaderText = "Factura"
        Me.factura.Name = "factura"
        '
        'importe
        '
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        '
        'lbl_aplicaFc
        '
        Me.lbl_aplicaFc.AutoSize = True
        Me.lbl_aplicaFc.Location = New System.Drawing.Point(18, 21)
        Me.lbl_aplicaFc.Name = "lbl_aplicaFc"
        Me.lbl_aplicaFc.Size = New System.Drawing.Size(194, 13)
        Me.lbl_aplicaFc.TabIndex = 676
        Me.lbl_aplicaFc.Text = "Facturas a las que aplica y sus importes"
        '
        'notas
        '
        Me.notas.BackColor = System.Drawing.SystemColors.Control
        Me.notas.Controls.Add(Me.txt_notas)
        Me.notas.Controls.Add(Me.lbl_notas)
        Me.notas.Location = New System.Drawing.Point(4, 22)
        Me.notas.Name = "notas"
        Me.notas.Size = New System.Drawing.Size(552, 360)
        Me.notas.TabIndex = 2
        Me.notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Enabled = False
        Me.txt_notas.Location = New System.Drawing.Point(18, 38)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(518, 181)
        Me.txt_notas.TabIndex = 677
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(18, 18)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 678
        Me.lbl_notas.Text = "Notas"
        '
        'add_pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 785)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lbl_borrarbusqueda)
        Me.Controls.Add(Me.lblpeso1)
        Me.Controls.Add(Me.lbl_importePago)
        Me.Controls.Add(Me.lbl_pago)
        Me.Controls.Add(Me.cmb_cc)
        Me.Controls.Add(Me.pic_searchCCProveedor)
        Me.Controls.Add(Me.lbl_ccp)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.chklb_facturasPendientes)
        Me.Controls.Add(Me.lbl_facturasPagar)
        Me.Controls.Add(Me.txt_efectivo)
        Me.Controls.Add(Me.lbl_dineroCuenta)
        Me.Controls.Add(Me.lbl_dineroCuenta1)
        Me.Controls.Add(Me.lbl_comoPaga)
        Me.Controls.Add(Me.chk_efectivo)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.pic_searchProveedor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.dtp_fechaPago)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.lbl_fechaCobro)
        Me.Controls.Add(Me.lbl_fechaCarga1)
        Me.Name = "add_pago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar pagos"
        CType(Me.pic_searchCCProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.cheques.ResumeLayout(False)
        Me.cheques.PerformLayout()
        CType(Me.dg_viewCH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.transferencias.ResumeLayout(False)
        Me.transferencias.PerformLayout()
        CType(Me.dg_viewTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_nFC_importe.ResumeLayout(False)
        Me.tb_nFC_importe.PerformLayout()
        CType(Me.dg_view_nFC_importes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.notas.ResumeLayout(False)
        Me.notas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_fechaCarga1 As Label
    Friend WithEvents lbl_fechaCobro As Label
    Friend WithEvents lbl_fecha As Label
    Friend WithEvents dtp_fechaPago As DateTimePicker
    Friend WithEvents cmb_proveedor As ComboBox
    Friend WithEvents pic_searchProveedor As PictureBox
    Friend WithEvents lbl_proveedor As Label
    Friend WithEvents chk_efectivo As CheckBox
    Friend WithEvents lbl_comoPaga As Label
    Friend WithEvents chk_cheque As CheckBox
    Friend WithEvents lbl_dineroCuenta1 As Label
    Friend WithEvents lbl_dineroCuenta As Label
    Friend WithEvents txt_efectivo As TextBox
    Friend WithEvents lbl_facturasPagar As Label
    Friend WithEvents chklb_facturasPendientes As CheckedListBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents cmb_cc As ComboBox
    Friend WithEvents pic_searchCCProveedor As PictureBox
    Friend WithEvents lbl_ccp As Label
    Friend WithEvents cmd_verCheques As Button
    Friend WithEvents lbl_importePago As Label
    Friend WithEvents lbl_pago As Label
    Friend WithEvents lblpeso1 As Label
    Friend WithEvents lbl_borrarbusqueda As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents cheques As TabPage
    Friend WithEvents lbl_totalCh As Label
    Friend WithEvents lbl_totalCheques As Label
    Friend WithEvents lbl_buscarCheque As Label
    Friend WithEvents txt_search As TextBox
    Friend WithEvents lbl_chSel As Label
    Friend WithEvents dg_viewCH As DataGridView
    Friend WithEvents cmd_addCheques As Button
    Friend WithEvents transferencias As TabPage
    Friend WithEvents notas As TabPage
    Friend WithEvents tb_nFC_importe As TabPage
    Friend WithEvents txt_notas As TextBox
    Friend WithEvents lbl_notas As Label
    Friend WithEvents lbl_totalTransferencias As Label
    Friend WithEvents lbl_buscarTransferencia As Label
    Friend WithEvents txt_searchTransferencia As TextBox
    Friend WithEvents dg_viewTransferencia As DataGridView
    Friend WithEvents cmd_addTransferencia As Button
    Friend WithEvents chk_transferencia As CheckBox
    Friend WithEvents lbl_totalTransferencia As Label
    Friend WithEvents dg_view_nFC_importes As DataGridView
    Friend WithEvents fecha As DataGridViewTextBoxColumn
    Friend WithEvents factura As DataGridViewTextBoxColumn
    Friend WithEvents importe As DataGridViewTextBoxColumn
    Friend WithEvents lbl_aplicaFc As Label
End Class
