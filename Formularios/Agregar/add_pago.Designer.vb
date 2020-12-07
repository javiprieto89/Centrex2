<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_pago
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
        Me.lbl_fechaCarga1 = New System.Windows.Forms.Label()
        Me.lbl_fechaCobro = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.dtp_fechaPago = New System.Windows.Forms.DateTimePicker()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.chk_efectivo = New System.Windows.Forms.CheckBox()
        Me.lbl_comoPaga = New System.Windows.Forms.Label()
        Me.chk_transferencia = New System.Windows.Forms.CheckBox()
        Me.chk_cheque = New System.Windows.Forms.CheckBox()
        Me.lbl_dineroCuenta1 = New System.Windows.Forms.Label()
        Me.lbl_dineroCuenta = New System.Windows.Forms.Label()
        Me.txt_efectivo = New System.Windows.Forms.TextBox()
        Me.txt_transferenciaBancaria = New System.Windows.Forms.TextBox()
        Me.lbl_facturasPagar = New System.Windows.Forms.Label()
        Me.chklb_facturasPendientes = New System.Windows.Forms.CheckedListBox()
        Me.cmd_addCheques = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmb_cc = New System.Windows.Forms.ComboBox()
        Me.lbl_ccp = New System.Windows.Forms.Label()
        Me.cmd_verCheques = New System.Windows.Forms.Button()
        Me.pic_searchCCProveedor = New System.Windows.Forms.PictureBox()
        Me.pic_searchProveedor = New System.Windows.Forms.PictureBox()
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.lbl_chSel = New System.Windows.Forms.Label()
        Me.lbl_importePago = New System.Windows.Forms.Label()
        Me.lbl_pago = New System.Windows.Forms.Label()
        Me.lblpeso1 = New System.Windows.Forms.Label()
        Me.lblpeso2 = New System.Windows.Forms.Label()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.lbl_buscarCheque = New System.Windows.Forms.Label()
        Me.lbl_borrarbusqueda = New System.Windows.Forms.Label()
        Me.lbl_totalCheques = New System.Windows.Forms.Label()
        Me.lbl_totalCh = New System.Windows.Forms.Label()
        CType(Me.pic_searchCCProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_fechaCarga1
        '
        Me.lbl_fechaCarga1.AutoSize = True
        Me.lbl_fechaCarga1.Location = New System.Drawing.Point(16, 23)
        Me.lbl_fechaCarga1.Name = "lbl_fechaCarga1"
        Me.lbl_fechaCarga1.Size = New System.Drawing.Size(85, 13)
        Me.lbl_fechaCarga1.TabIndex = 0
        Me.lbl_fechaCarga1.Text = "Fecha de carga:"
        '
        'lbl_fechaCobro
        '
        Me.lbl_fechaCobro.AutoSize = True
        Me.lbl_fechaCobro.Location = New System.Drawing.Point(16, 51)
        Me.lbl_fechaCobro.Name = "lbl_fechaCobro"
        Me.lbl_fechaCobro.Size = New System.Drawing.Size(82, 13)
        Me.lbl_fechaCobro.TabIndex = 1
        Me.lbl_fechaCobro.Text = "Fecha de pago:"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(147, 23)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(50, 13)
        Me.lbl_fecha.TabIndex = 2
        Me.lbl_fecha.Text = "%carga%"
        '
        'dtp_fechaPago
        '
        Me.dtp_fechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fechaPago.Location = New System.Drawing.Point(171, 51)
        Me.dtp_fechaPago.Name = "dtp_fechaPago"
        Me.dtp_fechaPago.Size = New System.Drawing.Size(104, 20)
        Me.dtp_fechaPago.TabIndex = 0
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(171, 83)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(343, 21)
        Me.cmb_proveedor.TabIndex = 1
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(16, 83)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 636
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'chk_efectivo
        '
        Me.chk_efectivo.AutoSize = True
        Me.chk_efectivo.Enabled = False
        Me.chk_efectivo.Location = New System.Drawing.Point(19, 255)
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
        Me.lbl_comoPaga.Location = New System.Drawing.Point(16, 211)
        Me.lbl_comoPaga.Name = "lbl_comoPaga"
        Me.lbl_comoPaga.Size = New System.Drawing.Size(242, 16)
        Me.lbl_comoPaga.TabIndex = 640
        Me.lbl_comoPaga.Text = "¿Cómo se va a constituir el pago?"
        '
        'chk_transferencia
        '
        Me.chk_transferencia.AutoSize = True
        Me.chk_transferencia.Enabled = False
        Me.chk_transferencia.Location = New System.Drawing.Point(19, 294)
        Me.chk_transferencia.Name = "chk_transferencia"
        Me.chk_transferencia.Size = New System.Drawing.Size(180, 17)
        Me.chk_transferencia.TabIndex = 5
        Me.chk_transferencia.Text = "Transferencia/depósito bancario"
        Me.chk_transferencia.UseVisualStyleBackColor = True
        '
        'chk_cheque
        '
        Me.chk_cheque.AutoSize = True
        Me.chk_cheque.Enabled = False
        Me.chk_cheque.Location = New System.Drawing.Point(19, 335)
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
        Me.lbl_dineroCuenta1.Location = New System.Drawing.Point(16, 169)
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
        Me.lbl_dineroCuenta.Location = New System.Drawing.Point(163, 169)
        Me.lbl_dineroCuenta.Name = "lbl_dineroCuenta"
        Me.lbl_dineroCuenta.Size = New System.Drawing.Size(24, 16)
        Me.lbl_dineroCuenta.TabIndex = 644
        Me.lbl_dineroCuenta.Text = "$$"
        '
        'txt_efectivo
        '
        Me.txt_efectivo.Enabled = False
        Me.txt_efectivo.Location = New System.Drawing.Point(257, 252)
        Me.txt_efectivo.Name = "txt_efectivo"
        Me.txt_efectivo.Size = New System.Drawing.Size(285, 20)
        Me.txt_efectivo.TabIndex = 4
        '
        'txt_transferenciaBancaria
        '
        Me.txt_transferenciaBancaria.Enabled = False
        Me.txt_transferenciaBancaria.Location = New System.Drawing.Point(257, 294)
        Me.txt_transferenciaBancaria.Name = "txt_transferenciaBancaria"
        Me.txt_transferenciaBancaria.Size = New System.Drawing.Size(285, 20)
        Me.txt_transferenciaBancaria.TabIndex = 6
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
        'cmd_addCheques
        '
        Me.cmd_addCheques.Enabled = False
        Me.cmd_addCheques.Location = New System.Drawing.Point(423, 590)
        Me.cmd_addCheques.Name = "cmd_addCheques"
        Me.cmd_addCheques.Size = New System.Drawing.Size(119, 23)
        Me.cmd_addCheques.TabIndex = 9
        Me.cmd_addCheques.Text = "Ingresar cheques"
        Me.cmd_addCheques.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(302, 684)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 11
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(204, 684)
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
        Me.cmb_cc.Location = New System.Drawing.Point(171, 122)
        Me.cmb_cc.Name = "cmb_cc"
        Me.cmb_cc.Size = New System.Drawing.Size(343, 21)
        Me.cmb_cc.TabIndex = 2
        '
        'lbl_ccp
        '
        Me.lbl_ccp.AutoSize = True
        Me.lbl_ccp.Location = New System.Drawing.Point(16, 122)
        Me.lbl_ccp.Name = "lbl_ccp"
        Me.lbl_ccp.Size = New System.Drawing.Size(153, 13)
        Me.lbl_ccp.TabIndex = 653
        Me.lbl_ccp.Text = "Cuenta corriente del proveedor"
        '
        'cmd_verCheques
        '
        Me.cmd_verCheques.Enabled = False
        Me.cmd_verCheques.Location = New System.Drawing.Point(415, 335)
        Me.cmd_verCheques.Name = "cmd_verCheques"
        Me.cmd_verCheques.Size = New System.Drawing.Size(127, 38)
        Me.cmd_verCheques.TabIndex = 7
        Me.cmd_verCheques.Text = "Seleccionar cheques"
        Me.cmd_verCheques.UseVisualStyleBackColor = True
        Me.cmd_verCheques.Visible = False
        '
        'pic_searchCCProveedor
        '
        Me.pic_searchCCProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCCProveedor.Location = New System.Drawing.Point(520, 122)
        Me.pic_searchCCProveedor.Name = "pic_searchCCProveedor"
        Me.pic_searchCCProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCCProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCCProveedor.TabIndex = 654
        Me.pic_searchCCProveedor.TabStop = False
        '
        'pic_searchProveedor
        '
        Me.pic_searchProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchProveedor.Location = New System.Drawing.Point(520, 83)
        Me.pic_searchProveedor.Name = "pic_searchProveedor"
        Me.pic_searchProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchProveedor.TabIndex = 637
        Me.pic_searchProveedor.TabStop = False
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.Enabled = False
        Me.dg_view.Location = New System.Drawing.Point(19, 426)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(511, 158)
        Me.dg_view.TabIndex = 8
        '
        'lbl_chSel
        '
        Me.lbl_chSel.AutoSize = True
        Me.lbl_chSel.Location = New System.Drawing.Point(21, 376)
        Me.lbl_chSel.Name = "lbl_chSel"
        Me.lbl_chSel.Size = New System.Drawing.Size(177, 13)
        Me.lbl_chSel.TabIndex = 658
        Me.lbl_chSel.Text = "Cheques disponibles/seleccionados"
        '
        'lbl_importePago
        '
        Me.lbl_importePago.AutoSize = True
        Me.lbl_importePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_importePago.ForeColor = System.Drawing.Color.Green
        Me.lbl_importePago.Location = New System.Drawing.Point(201, 646)
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
        Me.lbl_pago.Location = New System.Drawing.Point(16, 646)
        Me.lbl_pago.Name = "lbl_pago"
        Me.lbl_pago.Size = New System.Drawing.Size(148, 15)
        Me.lbl_pago.TabIndex = 661
        Me.lbl_pago.Text = "Importe total del pago"
        '
        'lblpeso1
        '
        Me.lblpeso1.AutoSize = True
        Me.lblpeso1.Location = New System.Drawing.Point(238, 252)
        Me.lblpeso1.Name = "lblpeso1"
        Me.lblpeso1.Size = New System.Drawing.Size(13, 13)
        Me.lblpeso1.TabIndex = 663
        Me.lblpeso1.Text = "$"
        '
        'lblpeso2
        '
        Me.lblpeso2.AutoSize = True
        Me.lblpeso2.Location = New System.Drawing.Point(238, 297)
        Me.lblpeso2.Name = "lblpeso2"
        Me.lblpeso2.Size = New System.Drawing.Size(13, 13)
        Me.lblpeso2.TabIndex = 664
        Me.lblpeso2.Text = "$"
        '
        'txt_search
        '
        Me.txt_search.Enabled = False
        Me.txt_search.Location = New System.Drawing.Point(257, 400)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(268, 20)
        Me.txt_search.TabIndex = 665
        '
        'lbl_buscarCheque
        '
        Me.lbl_buscarCheque.AutoSize = True
        Me.lbl_buscarCheque.Location = New System.Drawing.Point(22, 403)
        Me.lbl_buscarCheque.Name = "lbl_buscarCheque"
        Me.lbl_buscarCheque.Size = New System.Drawing.Size(84, 13)
        Me.lbl_buscarCheque.TabIndex = 666
        Me.lbl_buscarCheque.Text = "Buscar cheques"
        '
        'lbl_borrarbusqueda
        '
        Me.lbl_borrarbusqueda.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_borrarbusqueda.AutoSize = True
        Me.lbl_borrarbusqueda.Enabled = False
        Me.lbl_borrarbusqueda.Location = New System.Drawing.Point(530, 403)
        Me.lbl_borrarbusqueda.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusqueda.Name = "lbl_borrarbusqueda"
        Me.lbl_borrarbusqueda.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusqueda.TabIndex = 667
        Me.lbl_borrarbusqueda.Text = "x"
        '
        'lbl_totalCheques
        '
        Me.lbl_totalCheques.AutoSize = True
        Me.lbl_totalCheques.Location = New System.Drawing.Point(16, 600)
        Me.lbl_totalCheques.Name = "lbl_totalCheques"
        Me.lbl_totalCheques.Size = New System.Drawing.Size(146, 13)
        Me.lbl_totalCheques.TabIndex = 668
        Me.lbl_totalCheques.Text = "Total cheques seleccionados"
        '
        'lbl_totalCh
        '
        Me.lbl_totalCh.AutoSize = True
        Me.lbl_totalCh.Location = New System.Drawing.Point(201, 600)
        Me.lbl_totalCh.Name = "lbl_totalCh"
        Me.lbl_totalCh.Size = New System.Drawing.Size(19, 13)
        Me.lbl_totalCh.TabIndex = 669
        Me.lbl_totalCh.Text = "$$"
        '
        'add_pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 731)
        Me.Controls.Add(Me.lbl_totalCh)
        Me.Controls.Add(Me.lbl_totalCheques)
        Me.Controls.Add(Me.lbl_borrarbusqueda)
        Me.Controls.Add(Me.lbl_buscarCheque)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.lblpeso2)
        Me.Controls.Add(Me.lblpeso1)
        Me.Controls.Add(Me.lbl_importePago)
        Me.Controls.Add(Me.lbl_pago)
        Me.Controls.Add(Me.lbl_chSel)
        Me.Controls.Add(Me.dg_view)
        Me.Controls.Add(Me.cmd_verCheques)
        Me.Controls.Add(Me.cmb_cc)
        Me.Controls.Add(Me.pic_searchCCProveedor)
        Me.Controls.Add(Me.lbl_ccp)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.cmd_addCheques)
        Me.Controls.Add(Me.chklb_facturasPendientes)
        Me.Controls.Add(Me.lbl_facturasPagar)
        Me.Controls.Add(Me.txt_transferenciaBancaria)
        Me.Controls.Add(Me.txt_efectivo)
        Me.Controls.Add(Me.lbl_dineroCuenta)
        Me.Controls.Add(Me.lbl_dineroCuenta1)
        Me.Controls.Add(Me.chk_cheque)
        Me.Controls.Add(Me.chk_transferencia)
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
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents chk_transferencia As CheckBox
    Friend WithEvents chk_cheque As CheckBox
    Friend WithEvents lbl_dineroCuenta1 As Label
    Friend WithEvents lbl_dineroCuenta As Label
    Friend WithEvents txt_efectivo As TextBox
    Friend WithEvents txt_transferenciaBancaria As TextBox
    Friend WithEvents lbl_facturasPagar As Label
    Friend WithEvents chklb_facturasPendientes As CheckedListBox
    Friend WithEvents cmd_addCheques As Button
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents cmb_cc As ComboBox
    Friend WithEvents pic_searchCCProveedor As PictureBox
    Friend WithEvents lbl_ccp As Label
    Friend WithEvents cmd_verCheques As Button
    Friend WithEvents dg_view As DataGridView
    Friend WithEvents lbl_chSel As Label
    Friend WithEvents lbl_importePago As Label
    Friend WithEvents lbl_pago As Label
    Friend WithEvents lblpeso1 As Label
    Friend WithEvents lblpeso2 As Label
    Friend WithEvents txt_search As TextBox
    Friend WithEvents lbl_buscarCheque As Label
    Friend WithEvents lbl_borrarbusqueda As Label
    Friend WithEvents lbl_totalCheques As Label
    Friend WithEvents lbl_totalCh As Label
End Class
