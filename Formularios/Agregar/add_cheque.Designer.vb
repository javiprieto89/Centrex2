<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_cheque
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
        Me.lbl_fechaEmision = New System.Windows.Forms.Label()
        Me.lbl_fechaCobro = New System.Windows.Forms.Label()
        Me.lbl_estado = New System.Windows.Forms.Label()
        Me.lbl_importe = New System.Windows.Forms.Label()
        Me.lbl_ncheque2 = New System.Windows.Forms.Label()
        Me.lbl_ncheque = New System.Windows.Forms.Label()
        Me.lbl_banco = New System.Windows.Forms.Label()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.lbl_fechaSalida = New System.Windows.Forms.Label()
        Me.lbl_fechaDeposito = New System.Windows.Forms.Label()
        Me.rb_recibido = New System.Windows.Forms.RadioButton()
        Me.rb_emitido = New System.Windows.Forms.RadioButton()
        Me.chk_depositado = New System.Windows.Forms.CheckBox()
        Me.lbl_cuentaBancaria = New System.Windows.Forms.Label()
        Me.cmb_cuentaBancaria = New System.Windows.Forms.ComboBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.txt_nCheque = New System.Windows.Forms.TextBox()
        Me.txt_nCheque2 = New System.Windows.Forms.TextBox()
        Me.txt_importe = New System.Windows.Forms.TextBox()
        Me.cmb_cliente = New System.Windows.Forms.ComboBox()
        Me.cmb_banco = New System.Windows.Forms.ComboBox()
        Me.cmb_estadoch = New System.Windows.Forms.ComboBox()
        Me.dtp_fEmision = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fCobro = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fDeposito = New System.Windows.Forms.DateTimePicker()
        Me.chk_fCobro = New System.Windows.Forms.CheckBox()
        Me.chk_fSalida = New System.Windows.Forms.CheckBox()
        Me.chk_fDeposito = New System.Windows.Forms.CheckBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.pic_searchCliente = New System.Windows.Forms.PictureBox()
        Me.pic_searchProveedor = New System.Windows.Forms.PictureBox()
        Me.pic_searchBanco = New System.Windows.Forms.PictureBox()
        Me.dtp_fIngreso = New System.Windows.Forms.DateTimePicker()
        Me.lbl_fechaIngreso = New System.Windows.Forms.Label()
        Me.chk_eCheck = New System.Windows.Forms.CheckBox()
        CType(Me.pic_searchCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_fechaEmision
        '
        Me.lbl_fechaEmision.AutoSize = True
        Me.lbl_fechaEmision.Location = New System.Drawing.Point(23, 74)
        Me.lbl_fechaEmision.Name = "lbl_fechaEmision"
        Me.lbl_fechaEmision.Size = New System.Drawing.Size(90, 13)
        Me.lbl_fechaEmision.TabIndex = 0
        Me.lbl_fechaEmision.Text = "Fecha de emisión"
        '
        'lbl_fechaCobro
        '
        Me.lbl_fechaCobro.AutoSize = True
        Me.lbl_fechaCobro.Location = New System.Drawing.Point(23, 114)
        Me.lbl_fechaCobro.Name = "lbl_fechaCobro"
        Me.lbl_fechaCobro.Size = New System.Drawing.Size(82, 13)
        Me.lbl_fechaCobro.TabIndex = 1
        Me.lbl_fechaCobro.Text = "Fecha de cobro"
        '
        'lbl_estado
        '
        Me.lbl_estado.AutoSize = True
        Me.lbl_estado.Location = New System.Drawing.Point(451, 25)
        Me.lbl_estado.Name = "lbl_estado"
        Me.lbl_estado.Size = New System.Drawing.Size(96, 13)
        Me.lbl_estado.TabIndex = 2
        Me.lbl_estado.Text = "Estado del cheque"
        '
        'lbl_importe
        '
        Me.lbl_importe.AutoSize = True
        Me.lbl_importe.Location = New System.Drawing.Point(23, 438)
        Me.lbl_importe.Name = "lbl_importe"
        Me.lbl_importe.Size = New System.Drawing.Size(42, 13)
        Me.lbl_importe.TabIndex = 3
        Me.lbl_importe.Text = "Importe"
        '
        'lbl_ncheque2
        '
        Me.lbl_ncheque2.AutoSize = True
        Me.lbl_ncheque2.Location = New System.Drawing.Point(23, 393)
        Me.lbl_ncheque2.Name = "lbl_ncheque2"
        Me.lbl_ncheque2.Size = New System.Drawing.Size(94, 13)
        Me.lbl_ncheque2.TabIndex = 4
        Me.lbl_ncheque2.Text = "2do Nº de cheque"
        '
        'lbl_ncheque
        '
        Me.lbl_ncheque.AutoSize = True
        Me.lbl_ncheque.Location = New System.Drawing.Point(23, 348)
        Me.lbl_ncheque.Name = "lbl_ncheque"
        Me.lbl_ncheque.Size = New System.Drawing.Size(73, 13)
        Me.lbl_ncheque.TabIndex = 5
        Me.lbl_ncheque.Text = "Nº de cheque"
        '
        'lbl_banco
        '
        Me.lbl_banco.AutoSize = True
        Me.lbl_banco.Location = New System.Drawing.Point(23, 303)
        Me.lbl_banco.Name = "lbl_banco"
        Me.lbl_banco.Size = New System.Drawing.Size(71, 13)
        Me.lbl_banco.TabIndex = 6
        Me.lbl_banco.Text = "Banco emisor"
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(23, 190)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 7
        Me.lbl_cliente.Text = "Cliente"
        '
        'lbl_fechaSalida
        '
        Me.lbl_fechaSalida.AutoSize = True
        Me.lbl_fechaSalida.Location = New System.Drawing.Point(485, 111)
        Me.lbl_fechaSalida.Name = "lbl_fechaSalida"
        Me.lbl_fechaSalida.Size = New System.Drawing.Size(82, 13)
        Me.lbl_fechaSalida.TabIndex = 8
        Me.lbl_fechaSalida.Text = "Fecha de salida"
        '
        'lbl_fechaDeposito
        '
        Me.lbl_fechaDeposito.AutoSize = True
        Me.lbl_fechaDeposito.Location = New System.Drawing.Point(485, 158)
        Me.lbl_fechaDeposito.Name = "lbl_fechaDeposito"
        Me.lbl_fechaDeposito.Size = New System.Drawing.Size(95, 13)
        Me.lbl_fechaDeposito.TabIndex = 9
        Me.lbl_fechaDeposito.Text = "Fecha de depósito"
        '
        'rb_recibido
        '
        Me.rb_recibido.AutoSize = True
        Me.rb_recibido.Location = New System.Drawing.Point(23, 154)
        Me.rb_recibido.Name = "rb_recibido"
        Me.rb_recibido.Size = New System.Drawing.Size(102, 17)
        Me.rb_recibido.TabIndex = 10
        Me.rb_recibido.TabStop = True
        Me.rb_recibido.Text = "Cheque recibido"
        Me.rb_recibido.UseVisualStyleBackColor = True
        '
        'rb_emitido
        '
        Me.rb_emitido.AutoSize = True
        Me.rb_emitido.Location = New System.Drawing.Point(23, 221)
        Me.rb_emitido.Name = "rb_emitido"
        Me.rb_emitido.Size = New System.Drawing.Size(98, 17)
        Me.rb_emitido.TabIndex = 11
        Me.rb_emitido.TabStop = True
        Me.rb_emitido.Text = "Cheque emitido"
        Me.rb_emitido.UseVisualStyleBackColor = True
        '
        'chk_depositado
        '
        Me.chk_depositado.AutoSize = True
        Me.chk_depositado.Enabled = False
        Me.chk_depositado.Location = New System.Drawing.Point(457, 205)
        Me.chk_depositado.Name = "chk_depositado"
        Me.chk_depositado.Size = New System.Drawing.Size(180, 17)
        Me.chk_depositado.TabIndex = 12
        Me.chk_depositado.Text = "El cheque ya ha sido depositado"
        Me.chk_depositado.UseVisualStyleBackColor = True
        '
        'lbl_cuentaBancaria
        '
        Me.lbl_cuentaBancaria.AutoSize = True
        Me.lbl_cuentaBancaria.Location = New System.Drawing.Point(454, 251)
        Me.lbl_cuentaBancaria.Name = "lbl_cuentaBancaria"
        Me.lbl_cuentaBancaria.Size = New System.Drawing.Size(189, 13)
        Me.lbl_cuentaBancaria.TabIndex = 13
        Me.lbl_cuentaBancaria.Text = "Cuenta bancaria en la que se deposito"
        '
        'cmb_cuentaBancaria
        '
        Me.cmb_cuentaBancaria.Enabled = False
        Me.cmb_cuentaBancaria.FormattingEnabled = True
        Me.cmb_cuentaBancaria.Location = New System.Drawing.Point(454, 295)
        Me.cmb_cuentaBancaria.Name = "cmb_cuentaBancaria"
        Me.cmb_cuentaBancaria.Size = New System.Drawing.Size(355, 21)
        Me.cmb_cuentaBancaria.TabIndex = 14
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(134, 585)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 54
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(26, 543)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 52
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(234, 585)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 53
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'txt_nCheque
        '
        Me.txt_nCheque.Location = New System.Drawing.Point(163, 341)
        Me.txt_nCheque.MaxLength = 8
        Me.txt_nCheque.Name = "txt_nCheque"
        Me.txt_nCheque.Size = New System.Drawing.Size(224, 20)
        Me.txt_nCheque.TabIndex = 55
        '
        'txt_nCheque2
        '
        Me.txt_nCheque2.Location = New System.Drawing.Point(163, 386)
        Me.txt_nCheque2.Name = "txt_nCheque2"
        Me.txt_nCheque2.Size = New System.Drawing.Size(224, 20)
        Me.txt_nCheque2.TabIndex = 56
        '
        'txt_importe
        '
        Me.txt_importe.Location = New System.Drawing.Point(163, 431)
        Me.txt_importe.Name = "txt_importe"
        Me.txt_importe.Size = New System.Drawing.Size(224, 20)
        Me.txt_importe.TabIndex = 57
        '
        'cmb_cliente
        '
        Me.cmb_cliente.FormattingEnabled = True
        Me.cmb_cliente.Location = New System.Drawing.Point(163, 182)
        Me.cmb_cliente.Name = "cmb_cliente"
        Me.cmb_cliente.Size = New System.Drawing.Size(224, 21)
        Me.cmb_cliente.TabIndex = 58
        '
        'cmb_banco
        '
        Me.cmb_banco.FormattingEnabled = True
        Me.cmb_banco.Location = New System.Drawing.Point(163, 295)
        Me.cmb_banco.Name = "cmb_banco"
        Me.cmb_banco.Size = New System.Drawing.Size(224, 21)
        Me.cmb_banco.TabIndex = 59
        '
        'cmb_estadoch
        '
        Me.cmb_estadoch.Enabled = False
        Me.cmb_estadoch.FormattingEnabled = True
        Me.cmb_estadoch.Location = New System.Drawing.Point(585, 21)
        Me.cmb_estadoch.Name = "cmb_estadoch"
        Me.cmb_estadoch.Size = New System.Drawing.Size(224, 21)
        Me.cmb_estadoch.TabIndex = 60
        '
        'dtp_fEmision
        '
        Me.dtp_fEmision.Location = New System.Drawing.Point(163, 68)
        Me.dtp_fEmision.Name = "dtp_fEmision"
        Me.dtp_fEmision.Size = New System.Drawing.Size(224, 20)
        Me.dtp_fEmision.TabIndex = 113
        '
        'dtp_fCobro
        '
        Me.dtp_fCobro.Location = New System.Drawing.Point(163, 116)
        Me.dtp_fCobro.Name = "dtp_fCobro"
        Me.dtp_fCobro.Size = New System.Drawing.Size(224, 20)
        Me.dtp_fCobro.TabIndex = 114
        '
        'dtp_fSalida
        '
        Me.dtp_fSalida.Enabled = False
        Me.dtp_fSalida.Location = New System.Drawing.Point(585, 105)
        Me.dtp_fSalida.Name = "dtp_fSalida"
        Me.dtp_fSalida.Size = New System.Drawing.Size(224, 20)
        Me.dtp_fSalida.TabIndex = 115
        '
        'dtp_fDeposito
        '
        Me.dtp_fDeposito.Enabled = False
        Me.dtp_fDeposito.Location = New System.Drawing.Point(585, 152)
        Me.dtp_fDeposito.Name = "dtp_fDeposito"
        Me.dtp_fDeposito.Size = New System.Drawing.Size(224, 20)
        Me.dtp_fDeposito.TabIndex = 116
        '
        'chk_fCobro
        '
        Me.chk_fCobro.AutoSize = True
        Me.chk_fCobro.Enabled = False
        Me.chk_fCobro.Location = New System.Drawing.Point(-6, 111)
        Me.chk_fCobro.Name = "chk_fCobro"
        Me.chk_fCobro.Size = New System.Drawing.Size(15, 14)
        Me.chk_fCobro.TabIndex = 117
        Me.chk_fCobro.UseVisualStyleBackColor = True
        Me.chk_fCobro.Visible = False
        '
        'chk_fSalida
        '
        Me.chk_fSalida.AutoSize = True
        Me.chk_fSalida.Enabled = False
        Me.chk_fSalida.Location = New System.Drawing.Point(454, 113)
        Me.chk_fSalida.Name = "chk_fSalida"
        Me.chk_fSalida.Size = New System.Drawing.Size(15, 14)
        Me.chk_fSalida.TabIndex = 118
        Me.chk_fSalida.UseVisualStyleBackColor = True
        '
        'chk_fDeposito
        '
        Me.chk_fDeposito.AutoSize = True
        Me.chk_fDeposito.Enabled = False
        Me.chk_fDeposito.Location = New System.Drawing.Point(454, 158)
        Me.chk_fDeposito.Name = "chk_fDeposito"
        Me.chk_fDeposito.Size = New System.Drawing.Size(15, 14)
        Me.chk_fDeposito.TabIndex = 119
        Me.chk_fDeposito.UseVisualStyleBackColor = True
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(163, 248)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(224, 21)
        Me.cmb_proveedor.TabIndex = 121
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(23, 256)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 120
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'pic_searchCliente
        '
        Me.pic_searchCliente.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchCliente.Location = New System.Drawing.Point(403, 181)
        Me.pic_searchCliente.Name = "pic_searchCliente"
        Me.pic_searchCliente.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchCliente.TabIndex = 122
        Me.pic_searchCliente.TabStop = False
        '
        'pic_searchProveedor
        '
        Me.pic_searchProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchProveedor.Location = New System.Drawing.Point(403, 247)
        Me.pic_searchProveedor.Name = "pic_searchProveedor"
        Me.pic_searchProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchProveedor.TabIndex = 123
        Me.pic_searchProveedor.TabStop = False
        '
        'pic_searchBanco
        '
        Me.pic_searchBanco.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchBanco.Location = New System.Drawing.Point(403, 295)
        Me.pic_searchBanco.Name = "pic_searchBanco"
        Me.pic_searchBanco.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchBanco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchBanco.TabIndex = 124
        Me.pic_searchBanco.TabStop = False
        '
        'dtp_fIngreso
        '
        Me.dtp_fIngreso.Enabled = False
        Me.dtp_fIngreso.Location = New System.Drawing.Point(163, 25)
        Me.dtp_fIngreso.Name = "dtp_fIngreso"
        Me.dtp_fIngreso.Size = New System.Drawing.Size(224, 20)
        Me.dtp_fIngreso.TabIndex = 126
        '
        'lbl_fechaIngreso
        '
        Me.lbl_fechaIngreso.AutoSize = True
        Me.lbl_fechaIngreso.Location = New System.Drawing.Point(23, 31)
        Me.lbl_fechaIngreso.Name = "lbl_fechaIngreso"
        Me.lbl_fechaIngreso.Size = New System.Drawing.Size(89, 13)
        Me.lbl_fechaIngreso.TabIndex = 125
        Me.lbl_fechaIngreso.Text = "Fecha de ingreso"
        '
        'chk_eCheck
        '
        Me.chk_eCheck.AutoSize = True
        Me.chk_eCheck.Location = New System.Drawing.Point(26, 481)
        Me.chk_eCheck.Name = "chk_eCheck"
        Me.chk_eCheck.Size = New System.Drawing.Size(118, 17)
        Me.chk_eCheck.TabIndex = 127
        Me.chk_eCheck.Text = "Cheque electrónico"
        Me.chk_eCheck.UseVisualStyleBackColor = True
        '
        'add_cheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 626)
        Me.Controls.Add(Me.chk_eCheck)
        Me.Controls.Add(Me.dtp_fIngreso)
        Me.Controls.Add(Me.lbl_fechaIngreso)
        Me.Controls.Add(Me.pic_searchBanco)
        Me.Controls.Add(Me.pic_searchProveedor)
        Me.Controls.Add(Me.pic_searchCliente)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.chk_fDeposito)
        Me.Controls.Add(Me.chk_fSalida)
        Me.Controls.Add(Me.chk_fCobro)
        Me.Controls.Add(Me.dtp_fDeposito)
        Me.Controls.Add(Me.dtp_fSalida)
        Me.Controls.Add(Me.dtp_fCobro)
        Me.Controls.Add(Me.dtp_fEmision)
        Me.Controls.Add(Me.cmb_estadoch)
        Me.Controls.Add(Me.cmb_banco)
        Me.Controls.Add(Me.cmb_cliente)
        Me.Controls.Add(Me.txt_importe)
        Me.Controls.Add(Me.txt_nCheque2)
        Me.Controls.Add(Me.txt_nCheque)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmb_cuentaBancaria)
        Me.Controls.Add(Me.lbl_cuentaBancaria)
        Me.Controls.Add(Me.chk_depositado)
        Me.Controls.Add(Me.rb_emitido)
        Me.Controls.Add(Me.rb_recibido)
        Me.Controls.Add(Me.lbl_fechaDeposito)
        Me.Controls.Add(Me.lbl_fechaSalida)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.lbl_banco)
        Me.Controls.Add(Me.lbl_ncheque)
        Me.Controls.Add(Me.lbl_ncheque2)
        Me.Controls.Add(Me.lbl_importe)
        Me.Controls.Add(Me.lbl_estado)
        Me.Controls.Add(Me.lbl_fechaCobro)
        Me.Controls.Add(Me.lbl_fechaEmision)
        Me.Name = "add_cheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar cheques"
        CType(Me.pic_searchCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchBanco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_fechaEmision As Label
    Friend WithEvents lbl_fechaCobro As Label
    Friend WithEvents lbl_estado As Label
    Friend WithEvents lbl_importe As Label
    Friend WithEvents lbl_ncheque2 As Label
    Friend WithEvents lbl_ncheque As Label
    Friend WithEvents lbl_banco As Label
    Friend WithEvents lbl_cliente As Label
    Friend WithEvents lbl_fechaSalida As Label
    Friend WithEvents lbl_fechaDeposito As Label
    Friend WithEvents rb_recibido As RadioButton
    Friend WithEvents rb_emitido As RadioButton
    Friend WithEvents chk_depositado As CheckBox
    Friend WithEvents lbl_cuentaBancaria As Label
    Friend WithEvents cmb_cuentaBancaria As ComboBox
    Friend WithEvents cmd_ok As Button
    Friend WithEvents chk_secuencia As CheckBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents txt_nCheque As TextBox
    Friend WithEvents txt_nCheque2 As TextBox
    Friend WithEvents txt_importe As TextBox
    Friend WithEvents cmb_cliente As ComboBox
    Friend WithEvents cmb_banco As ComboBox
    Friend WithEvents cmb_estadoch As ComboBox
    Friend WithEvents dtp_fEmision As DateTimePicker
    Friend WithEvents dtp_fCobro As DateTimePicker
    Friend WithEvents dtp_fSalida As DateTimePicker
    Friend WithEvents dtp_fDeposito As DateTimePicker
    Friend WithEvents chk_fCobro As CheckBox
    Friend WithEvents chk_fSalida As CheckBox
    Friend WithEvents chk_fDeposito As CheckBox
    Friend WithEvents cmb_proveedor As ComboBox
    Friend WithEvents lbl_proveedor As Label
    Friend WithEvents pic_searchCliente As PictureBox
    Friend WithEvents pic_searchProveedor As PictureBox
    Friend WithEvents pic_searchBanco As PictureBox
    Friend WithEvents dtp_fIngreso As DateTimePicker
    Friend WithEvents lbl_fechaIngreso As Label
    Friend WithEvents chk_eCheck As CheckBox
End Class
