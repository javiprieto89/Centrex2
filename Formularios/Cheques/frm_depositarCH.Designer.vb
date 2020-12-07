<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_depositarCH
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
        Me.cmb_banco = New System.Windows.Forms.ComboBox()
        Me.lbl_Banco = New System.Windows.Forms.Label()
        Me.lbl_nCH = New System.Windows.Forms.Label()
        Me.txt_nCH_cartera = New System.Windows.Forms.TextBox()
        Me.lbl_importeCH_cartera = New System.Windows.Forms.Label()
        Me.txt_importeCH_cartera = New System.Windows.Forms.TextBox()
        Me.dg_view_chCartera = New System.Windows.Forms.DataGridView()
        Me.cmd_depositar = New System.Windows.Forms.Button()
        Me.dg_view_chDepositados = New System.Windows.Forms.DataGridView()
        Me.cmd_filtrarCH_cartera = New System.Windows.Forms.Button()
        Me.group_chCartera = New System.Windows.Forms.GroupBox()
        Me.cmd_go_cartera = New System.Windows.Forms.Button()
        Me.txt_nPage_cartera = New System.Windows.Forms.TextBox()
        Me.cmd_last_cartera = New System.Windows.Forms.Button()
        Me.cmd_next_cartera = New System.Windows.Forms.Button()
        Me.cmd_prev_cartera = New System.Windows.Forms.Button()
        Me.cmd_first_cartera = New System.Windows.Forms.Button()
        Me.group_chDepositados = New System.Windows.Forms.GroupBox()
        Me.cmb_cuentaBancaria = New System.Windows.Forms.ComboBox()
        Me.lbl_CuentaBancaria = New System.Windows.Forms.Label()
        Me.cmd_go_depositado = New System.Windows.Forms.Button()
        Me.txt_nPage_depositado = New System.Windows.Forms.TextBox()
        Me.cmd_last_depositado = New System.Windows.Forms.Button()
        Me.cmd_next_depositado = New System.Windows.Forms.Button()
        Me.cmd_prev_depositado = New System.Windows.Forms.Button()
        Me.cmd_first_depositado = New System.Windows.Forms.Button()
        Me.dtp_desde_depositado = New System.Windows.Forms.DateTimePicker()
        Me.cmd_filtrarCH_depositado = New System.Windows.Forms.Button()
        Me.txt_nCH_depositado = New System.Windows.Forms.TextBox()
        Me.lbl_desde_depositado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_importeCH_depositado = New System.Windows.Forms.Label()
        Me.lbl_hasta_depositado = New System.Windows.Forms.Label()
        Me.chk_desdeSiempre_depositado = New System.Windows.Forms.CheckBox()
        Me.dtp_hasta_depositado = New System.Windows.Forms.DateTimePicker()
        Me.txt_importeCH_depositado = New System.Windows.Forms.TextBox()
        Me.chk_hastaSiempre_depositado = New System.Windows.Forms.CheckBox()
        Me.cmd_acreditar = New System.Windows.Forms.Button()
        Me.cmd_anularDeposito = New System.Windows.Forms.Button()
        Me.gp_cartera = New System.Windows.Forms.GroupBox()
        Me.lbl_desde_cartera = New System.Windows.Forms.Label()
        Me.dtp_desde_cartera = New System.Windows.Forms.DateTimePicker()
        Me.lbl_hasta_cartera = New System.Windows.Forms.Label()
        Me.dtp_hasta_cartera = New System.Windows.Forms.DateTimePicker()
        Me.chk_hastaSiempre_cartera = New System.Windows.Forms.CheckBox()
        Me.chk_desdeSiempre_cartera = New System.Windows.Forms.CheckBox()
        Me.gp_depositado = New System.Windows.Forms.GroupBox()
        CType(Me.dg_view_chCartera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_view_chDepositados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_chCartera.SuspendLayout()
        Me.group_chDepositados.SuspendLayout()
        Me.gp_cartera.SuspendLayout()
        Me.gp_depositado.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_banco
        '
        Me.cmb_banco.FormattingEnabled = True
        Me.cmb_banco.Location = New System.Drawing.Point(141, 26)
        Me.cmb_banco.Name = "cmb_banco"
        Me.cmb_banco.Size = New System.Drawing.Size(263, 21)
        Me.cmb_banco.TabIndex = 0
        '
        'lbl_Banco
        '
        Me.lbl_Banco.AutoSize = True
        Me.lbl_Banco.Location = New System.Drawing.Point(12, 34)
        Me.lbl_Banco.Name = "lbl_Banco"
        Me.lbl_Banco.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Banco.TabIndex = 1
        Me.lbl_Banco.Text = "Banco"
        '
        'lbl_nCH
        '
        Me.lbl_nCH.AutoSize = True
        Me.lbl_nCH.Location = New System.Drawing.Point(18, 169)
        Me.lbl_nCH.Name = "lbl_nCH"
        Me.lbl_nCH.Size = New System.Drawing.Size(98, 13)
        Me.lbl_nCH.TabIndex = 129
        Me.lbl_nCH.Text = "Número de cheque"
        '
        'txt_nCH_cartera
        '
        Me.txt_nCH_cartera.Location = New System.Drawing.Point(127, 168)
        Me.txt_nCH_cartera.Name = "txt_nCH_cartera"
        Me.txt_nCH_cartera.Size = New System.Drawing.Size(263, 20)
        Me.txt_nCH_cartera.TabIndex = 130
        '
        'lbl_importeCH_cartera
        '
        Me.lbl_importeCH_cartera.AutoSize = True
        Me.lbl_importeCH_cartera.Location = New System.Drawing.Point(18, 226)
        Me.lbl_importeCH_cartera.Name = "lbl_importeCH_cartera"
        Me.lbl_importeCH_cartera.Size = New System.Drawing.Size(98, 13)
        Me.lbl_importeCH_cartera.TabIndex = 131
        Me.lbl_importeCH_cartera.Text = "Importe del cheque"
        '
        'txt_importeCH_cartera
        '
        Me.txt_importeCH_cartera.Location = New System.Drawing.Point(127, 225)
        Me.txt_importeCH_cartera.Name = "txt_importeCH_cartera"
        Me.txt_importeCH_cartera.Size = New System.Drawing.Size(263, 20)
        Me.txt_importeCH_cartera.TabIndex = 132
        '
        'dg_view_chCartera
        '
        Me.dg_view_chCartera.AllowUserToAddRows = False
        Me.dg_view_chCartera.AllowUserToDeleteRows = False
        Me.dg_view_chCartera.AllowUserToOrderColumns = True
        Me.dg_view_chCartera.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view_chCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view_chCartera.Location = New System.Drawing.Point(436, 19)
        Me.dg_view_chCartera.Name = "dg_view_chCartera"
        Me.dg_view_chCartera.ReadOnly = True
        Me.dg_view_chCartera.RowHeadersVisible = False
        Me.dg_view_chCartera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view_chCartera.Size = New System.Drawing.Size(624, 253)
        Me.dg_view_chCartera.TabIndex = 133
        '
        'cmd_depositar
        '
        Me.cmd_depositar.Location = New System.Drawing.Point(218, 346)
        Me.cmd_depositar.Name = "cmd_depositar"
        Me.cmd_depositar.Size = New System.Drawing.Size(140, 49)
        Me.cmd_depositar.TabIndex = 135
        Me.cmd_depositar.Text = "Depositar cheques seleccionados"
        Me.cmd_depositar.UseVisualStyleBackColor = True
        '
        'dg_view_chDepositados
        '
        Me.dg_view_chDepositados.AllowUserToAddRows = False
        Me.dg_view_chDepositados.AllowUserToDeleteRows = False
        Me.dg_view_chDepositados.AllowUserToOrderColumns = True
        Me.dg_view_chDepositados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view_chDepositados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view_chDepositados.Location = New System.Drawing.Point(425, 16)
        Me.dg_view_chDepositados.Name = "dg_view_chDepositados"
        Me.dg_view_chDepositados.ReadOnly = True
        Me.dg_view_chDepositados.RowHeadersVisible = False
        Me.dg_view_chDepositados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view_chDepositados.Size = New System.Drawing.Size(639, 277)
        Me.dg_view_chDepositados.TabIndex = 136
        '
        'cmd_filtrarCH_cartera
        '
        Me.cmd_filtrarCH_cartera.Location = New System.Drawing.Point(21, 275)
        Me.cmd_filtrarCH_cartera.Name = "cmd_filtrarCH_cartera"
        Me.cmd_filtrarCH_cartera.Size = New System.Drawing.Size(147, 23)
        Me.cmd_filtrarCH_cartera.TabIndex = 138
        Me.cmd_filtrarCH_cartera.Text = "Filtrar cheques"
        Me.cmd_filtrarCH_cartera.UseVisualStyleBackColor = True
        '
        'group_chCartera
        '
        Me.group_chCartera.Controls.Add(Me.gp_cartera)
        Me.group_chCartera.Controls.Add(Me.cmd_go_cartera)
        Me.group_chCartera.Controls.Add(Me.txt_nPage_cartera)
        Me.group_chCartera.Controls.Add(Me.cmd_last_cartera)
        Me.group_chCartera.Controls.Add(Me.cmd_next_cartera)
        Me.group_chCartera.Controls.Add(Me.cmd_prev_cartera)
        Me.group_chCartera.Controls.Add(Me.cmd_first_cartera)
        Me.group_chCartera.Controls.Add(Me.dg_view_chCartera)
        Me.group_chCartera.Controls.Add(Me.cmd_filtrarCH_cartera)
        Me.group_chCartera.Controls.Add(Me.txt_importeCH_cartera)
        Me.group_chCartera.Controls.Add(Me.lbl_importeCH_cartera)
        Me.group_chCartera.Controls.Add(Me.lbl_nCH)
        Me.group_chCartera.Controls.Add(Me.txt_nCH_cartera)
        Me.group_chCartera.Location = New System.Drawing.Point(16, 12)
        Me.group_chCartera.Name = "group_chCartera"
        Me.group_chCartera.Size = New System.Drawing.Size(1083, 322)
        Me.group_chCartera.TabIndex = 139
        Me.group_chCartera.TabStop = False
        Me.group_chCartera.Text = "Cheques en cartera"
        '
        'cmd_go_cartera
        '
        Me.cmd_go_cartera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_go_cartera.Location = New System.Drawing.Point(667, 278)
        Me.cmd_go_cartera.Name = "cmd_go_cartera"
        Me.cmd_go_cartera.Size = New System.Drawing.Size(29, 20)
        Me.cmd_go_cartera.TabIndex = 144
        Me.cmd_go_cartera.Text = "Ir"
        Me.cmd_go_cartera.UseVisualStyleBackColor = True
        '
        'txt_nPage_cartera
        '
        Me.txt_nPage_cartera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nPage_cartera.Location = New System.Drawing.Point(598, 278)
        Me.txt_nPage_cartera.Name = "txt_nPage_cartera"
        Me.txt_nPage_cartera.Size = New System.Drawing.Size(63, 20)
        Me.txt_nPage_cartera.TabIndex = 143
        '
        'cmd_last_cartera
        '
        Me.cmd_last_cartera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_last_cartera.Location = New System.Drawing.Point(563, 278)
        Me.cmd_last_cartera.Name = "cmd_last_cartera"
        Me.cmd_last_cartera.Size = New System.Drawing.Size(29, 20)
        Me.cmd_last_cartera.TabIndex = 142
        Me.cmd_last_cartera.Text = ">>|"
        Me.cmd_last_cartera.UseVisualStyleBackColor = True
        '
        'cmd_next_cartera
        '
        Me.cmd_next_cartera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_next_cartera.Location = New System.Drawing.Point(517, 278)
        Me.cmd_next_cartera.Name = "cmd_next_cartera"
        Me.cmd_next_cartera.Size = New System.Drawing.Size(40, 20)
        Me.cmd_next_cartera.TabIndex = 141
        Me.cmd_next_cartera.Text = ">>"
        Me.cmd_next_cartera.UseVisualStyleBackColor = True
        '
        'cmd_prev_cartera
        '
        Me.cmd_prev_cartera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_prev_cartera.Location = New System.Drawing.Point(471, 278)
        Me.cmd_prev_cartera.Name = "cmd_prev_cartera"
        Me.cmd_prev_cartera.Size = New System.Drawing.Size(40, 20)
        Me.cmd_prev_cartera.TabIndex = 140
        Me.cmd_prev_cartera.Text = "<<"
        Me.cmd_prev_cartera.UseVisualStyleBackColor = True
        '
        'cmd_first_cartera
        '
        Me.cmd_first_cartera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_first_cartera.Location = New System.Drawing.Point(436, 278)
        Me.cmd_first_cartera.Name = "cmd_first_cartera"
        Me.cmd_first_cartera.Size = New System.Drawing.Size(29, 20)
        Me.cmd_first_cartera.TabIndex = 139
        Me.cmd_first_cartera.Text = "|<<"
        Me.cmd_first_cartera.UseVisualStyleBackColor = True
        '
        'group_chDepositados
        '
        Me.group_chDepositados.Controls.Add(Me.gp_depositado)
        Me.group_chDepositados.Controls.Add(Me.cmb_cuentaBancaria)
        Me.group_chDepositados.Controls.Add(Me.lbl_CuentaBancaria)
        Me.group_chDepositados.Controls.Add(Me.cmd_go_depositado)
        Me.group_chDepositados.Controls.Add(Me.txt_nPage_depositado)
        Me.group_chDepositados.Controls.Add(Me.dg_view_chDepositados)
        Me.group_chDepositados.Controls.Add(Me.cmd_last_depositado)
        Me.group_chDepositados.Controls.Add(Me.cmd_next_depositado)
        Me.group_chDepositados.Controls.Add(Me.cmd_prev_depositado)
        Me.group_chDepositados.Controls.Add(Me.cmd_first_depositado)
        Me.group_chDepositados.Controls.Add(Me.cmb_banco)
        Me.group_chDepositados.Controls.Add(Me.lbl_Banco)
        Me.group_chDepositados.Controls.Add(Me.cmd_filtrarCH_depositado)
        Me.group_chDepositados.Controls.Add(Me.txt_nCH_depositado)
        Me.group_chDepositados.Controls.Add(Me.Label4)
        Me.group_chDepositados.Controls.Add(Me.lbl_importeCH_depositado)
        Me.group_chDepositados.Controls.Add(Me.txt_importeCH_depositado)
        Me.group_chDepositados.Location = New System.Drawing.Point(12, 404)
        Me.group_chDepositados.Name = "group_chDepositados"
        Me.group_chDepositados.Size = New System.Drawing.Size(1087, 354)
        Me.group_chDepositados.TabIndex = 140
        Me.group_chDepositados.TabStop = False
        Me.group_chDepositados.Text = "Cheques depositados"
        '
        'cmb_cuentaBancaria
        '
        Me.cmb_cuentaBancaria.FormattingEnabled = True
        Me.cmb_cuentaBancaria.Location = New System.Drawing.Point(141, 74)
        Me.cmb_cuentaBancaria.Name = "cmb_cuentaBancaria"
        Me.cmb_cuentaBancaria.Size = New System.Drawing.Size(263, 21)
        Me.cmb_cuentaBancaria.TabIndex = 162
        '
        'lbl_CuentaBancaria
        '
        Me.lbl_CuentaBancaria.AutoSize = True
        Me.lbl_CuentaBancaria.Location = New System.Drawing.Point(12, 74)
        Me.lbl_CuentaBancaria.Name = "lbl_CuentaBancaria"
        Me.lbl_CuentaBancaria.Size = New System.Drawing.Size(85, 13)
        Me.lbl_CuentaBancaria.TabIndex = 163
        Me.lbl_CuentaBancaria.Text = "Cuenta bancaria"
        '
        'cmd_go_depositado
        '
        Me.cmd_go_depositado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_go_depositado.Location = New System.Drawing.Point(656, 303)
        Me.cmd_go_depositado.Name = "cmd_go_depositado"
        Me.cmd_go_depositado.Size = New System.Drawing.Size(29, 20)
        Me.cmd_go_depositado.TabIndex = 161
        Me.cmd_go_depositado.Text = "Ir"
        Me.cmd_go_depositado.UseVisualStyleBackColor = True
        '
        'txt_nPage_depositado
        '
        Me.txt_nPage_depositado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nPage_depositado.Location = New System.Drawing.Point(587, 303)
        Me.txt_nPage_depositado.Name = "txt_nPage_depositado"
        Me.txt_nPage_depositado.Size = New System.Drawing.Size(63, 20)
        Me.txt_nPage_depositado.TabIndex = 160
        '
        'cmd_last_depositado
        '
        Me.cmd_last_depositado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_last_depositado.Location = New System.Drawing.Point(552, 303)
        Me.cmd_last_depositado.Name = "cmd_last_depositado"
        Me.cmd_last_depositado.Size = New System.Drawing.Size(29, 20)
        Me.cmd_last_depositado.TabIndex = 159
        Me.cmd_last_depositado.Text = ">>|"
        Me.cmd_last_depositado.UseVisualStyleBackColor = True
        '
        'cmd_next_depositado
        '
        Me.cmd_next_depositado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_next_depositado.Location = New System.Drawing.Point(506, 303)
        Me.cmd_next_depositado.Name = "cmd_next_depositado"
        Me.cmd_next_depositado.Size = New System.Drawing.Size(40, 20)
        Me.cmd_next_depositado.TabIndex = 158
        Me.cmd_next_depositado.Text = ">>"
        Me.cmd_next_depositado.UseVisualStyleBackColor = True
        '
        'cmd_prev_depositado
        '
        Me.cmd_prev_depositado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_prev_depositado.Location = New System.Drawing.Point(460, 303)
        Me.cmd_prev_depositado.Name = "cmd_prev_depositado"
        Me.cmd_prev_depositado.Size = New System.Drawing.Size(40, 20)
        Me.cmd_prev_depositado.TabIndex = 157
        Me.cmd_prev_depositado.Text = "<<"
        Me.cmd_prev_depositado.UseVisualStyleBackColor = True
        '
        'cmd_first_depositado
        '
        Me.cmd_first_depositado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_first_depositado.Location = New System.Drawing.Point(425, 303)
        Me.cmd_first_depositado.Name = "cmd_first_depositado"
        Me.cmd_first_depositado.Size = New System.Drawing.Size(29, 20)
        Me.cmd_first_depositado.TabIndex = 156
        Me.cmd_first_depositado.Text = "|<<"
        Me.cmd_first_depositado.UseVisualStyleBackColor = True
        '
        'dtp_desde_depositado
        '
        Me.dtp_desde_depositado.Enabled = False
        Me.dtp_desde_depositado.Location = New System.Drawing.Point(137, 29)
        Me.dtp_desde_depositado.Name = "dtp_desde_depositado"
        Me.dtp_desde_depositado.Size = New System.Drawing.Size(263, 20)
        Me.dtp_desde_depositado.TabIndex = 145
        '
        'cmd_filtrarCH_depositado
        '
        Me.cmd_filtrarCH_depositado.Location = New System.Drawing.Point(15, 312)
        Me.cmd_filtrarCH_depositado.Name = "cmd_filtrarCH_depositado"
        Me.cmd_filtrarCH_depositado.Size = New System.Drawing.Size(147, 23)
        Me.cmd_filtrarCH_depositado.TabIndex = 155
        Me.cmd_filtrarCH_depositado.Text = "Filtrar cheques"
        Me.cmd_filtrarCH_depositado.UseVisualStyleBackColor = True
        '
        'txt_nCH_depositado
        '
        Me.txt_nCH_depositado.Location = New System.Drawing.Point(141, 232)
        Me.txt_nCH_depositado.Name = "txt_nCH_depositado"
        Me.txt_nCH_depositado.Size = New System.Drawing.Size(263, 20)
        Me.txt_nCH_depositado.TabIndex = 152
        '
        'lbl_desde_depositado
        '
        Me.lbl_desde_depositado.AutoSize = True
        Me.lbl_desde_depositado.Location = New System.Drawing.Point(56, 30)
        Me.lbl_desde_depositado.Name = "lbl_desde_depositado"
        Me.lbl_desde_depositado.Size = New System.Drawing.Size(38, 13)
        Me.lbl_desde_depositado.TabIndex = 146
        Me.lbl_desde_depositado.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Número de cheque"
        '
        'lbl_importeCH_depositado
        '
        Me.lbl_importeCH_depositado.AutoSize = True
        Me.lbl_importeCH_depositado.Location = New System.Drawing.Point(6, 273)
        Me.lbl_importeCH_depositado.Name = "lbl_importeCH_depositado"
        Me.lbl_importeCH_depositado.Size = New System.Drawing.Size(98, 13)
        Me.lbl_importeCH_depositado.TabIndex = 153
        Me.lbl_importeCH_depositado.Text = "Importe del cheque"
        '
        'lbl_hasta_depositado
        '
        Me.lbl_hasta_depositado.AutoSize = True
        Me.lbl_hasta_depositado.Location = New System.Drawing.Point(62, 70)
        Me.lbl_hasta_depositado.Name = "lbl_hasta_depositado"
        Me.lbl_hasta_depositado.Size = New System.Drawing.Size(35, 13)
        Me.lbl_hasta_depositado.TabIndex = 148
        Me.lbl_hasta_depositado.Text = "Hasta"
        '
        'chk_desdeSiempre_depositado
        '
        Me.chk_desdeSiempre_depositado.AutoSize = True
        Me.chk_desdeSiempre_depositado.Location = New System.Drawing.Point(28, 29)
        Me.chk_desdeSiempre_depositado.Name = "chk_desdeSiempre_depositado"
        Me.chk_desdeSiempre_depositado.Size = New System.Drawing.Size(15, 14)
        Me.chk_desdeSiempre_depositado.TabIndex = 150
        Me.chk_desdeSiempre_depositado.UseVisualStyleBackColor = True
        '
        'dtp_hasta_depositado
        '
        Me.dtp_hasta_depositado.Enabled = False
        Me.dtp_hasta_depositado.Location = New System.Drawing.Point(137, 70)
        Me.dtp_hasta_depositado.Name = "dtp_hasta_depositado"
        Me.dtp_hasta_depositado.Size = New System.Drawing.Size(263, 20)
        Me.dtp_hasta_depositado.TabIndex = 147
        '
        'txt_importeCH_depositado
        '
        Me.txt_importeCH_depositado.Location = New System.Drawing.Point(141, 273)
        Me.txt_importeCH_depositado.Name = "txt_importeCH_depositado"
        Me.txt_importeCH_depositado.Size = New System.Drawing.Size(263, 20)
        Me.txt_importeCH_depositado.TabIndex = 154
        '
        'chk_hastaSiempre_depositado
        '
        Me.chk_hastaSiempre_depositado.AutoSize = True
        Me.chk_hastaSiempre_depositado.Location = New System.Drawing.Point(28, 67)
        Me.chk_hastaSiempre_depositado.Name = "chk_hastaSiempre_depositado"
        Me.chk_hastaSiempre_depositado.Size = New System.Drawing.Size(15, 14)
        Me.chk_hastaSiempre_depositado.TabIndex = 149
        Me.chk_hastaSiempre_depositado.UseVisualStyleBackColor = True
        '
        'cmd_acreditar
        '
        Me.cmd_acreditar.Location = New System.Drawing.Point(508, 346)
        Me.cmd_acreditar.Name = "cmd_acreditar"
        Me.cmd_acreditar.Size = New System.Drawing.Size(140, 49)
        Me.cmd_acreditar.TabIndex = 141
        Me.cmd_acreditar.Text = "Acreditar cheques seleccionados"
        Me.cmd_acreditar.UseVisualStyleBackColor = True
        '
        'cmd_anularDeposito
        '
        Me.cmd_anularDeposito.Location = New System.Drawing.Point(764, 346)
        Me.cmd_anularDeposito.Name = "cmd_anularDeposito"
        Me.cmd_anularDeposito.Size = New System.Drawing.Size(140, 49)
        Me.cmd_anularDeposito.TabIndex = 142
        Me.cmd_anularDeposito.Text = "Anular depósito"
        Me.cmd_anularDeposito.UseVisualStyleBackColor = True
        '
        'gp_cartera
        '
        Me.gp_cartera.Controls.Add(Me.lbl_desde_cartera)
        Me.gp_cartera.Controls.Add(Me.dtp_desde_cartera)
        Me.gp_cartera.Controls.Add(Me.lbl_hasta_cartera)
        Me.gp_cartera.Controls.Add(Me.dtp_hasta_cartera)
        Me.gp_cartera.Controls.Add(Me.chk_hastaSiempre_cartera)
        Me.gp_cartera.Controls.Add(Me.chk_desdeSiempre_cartera)
        Me.gp_cartera.Location = New System.Drawing.Point(6, 30)
        Me.gp_cartera.Name = "gp_cartera"
        Me.gp_cartera.Size = New System.Drawing.Size(406, 117)
        Me.gp_cartera.TabIndex = 145
        Me.gp_cartera.TabStop = False
        Me.gp_cartera.Text = "Fecha de cobro"
        '
        'lbl_desde_cartera
        '
        Me.lbl_desde_cartera.AutoSize = True
        Me.lbl_desde_cartera.Location = New System.Drawing.Point(55, 27)
        Me.lbl_desde_cartera.Name = "lbl_desde_cartera"
        Me.lbl_desde_cartera.Size = New System.Drawing.Size(38, 13)
        Me.lbl_desde_cartera.TabIndex = 130
        Me.lbl_desde_cartera.Text = "Desde"
        '
        'dtp_desde_cartera
        '
        Me.dtp_desde_cartera.Enabled = False
        Me.dtp_desde_cartera.Location = New System.Drawing.Point(122, 26)
        Me.dtp_desde_cartera.Name = "dtp_desde_cartera"
        Me.dtp_desde_cartera.Size = New System.Drawing.Size(263, 20)
        Me.dtp_desde_cartera.TabIndex = 129
        '
        'lbl_hasta_cartera
        '
        Me.lbl_hasta_cartera.AutoSize = True
        Me.lbl_hasta_cartera.Location = New System.Drawing.Point(55, 79)
        Me.lbl_hasta_cartera.Name = "lbl_hasta_cartera"
        Me.lbl_hasta_cartera.Size = New System.Drawing.Size(35, 13)
        Me.lbl_hasta_cartera.TabIndex = 132
        Me.lbl_hasta_cartera.Text = "Hasta"
        '
        'dtp_hasta_cartera
        '
        Me.dtp_hasta_cartera.Enabled = False
        Me.dtp_hasta_cartera.Location = New System.Drawing.Point(122, 78)
        Me.dtp_hasta_cartera.Name = "dtp_hasta_cartera"
        Me.dtp_hasta_cartera.Size = New System.Drawing.Size(263, 20)
        Me.dtp_hasta_cartera.TabIndex = 131
        '
        'chk_hastaSiempre_cartera
        '
        Me.chk_hastaSiempre_cartera.AutoSize = True
        Me.chk_hastaSiempre_cartera.Location = New System.Drawing.Point(13, 76)
        Me.chk_hastaSiempre_cartera.Name = "chk_hastaSiempre_cartera"
        Me.chk_hastaSiempre_cartera.Size = New System.Drawing.Size(15, 14)
        Me.chk_hastaSiempre_cartera.TabIndex = 133
        Me.chk_hastaSiempre_cartera.UseVisualStyleBackColor = True
        '
        'chk_desdeSiempre_cartera
        '
        Me.chk_desdeSiempre_cartera.AutoSize = True
        Me.chk_desdeSiempre_cartera.Location = New System.Drawing.Point(13, 26)
        Me.chk_desdeSiempre_cartera.Name = "chk_desdeSiempre_cartera"
        Me.chk_desdeSiempre_cartera.Size = New System.Drawing.Size(15, 14)
        Me.chk_desdeSiempre_cartera.TabIndex = 134
        Me.chk_desdeSiempre_cartera.UseVisualStyleBackColor = True
        '
        'gp_depositado
        '
        Me.gp_depositado.Controls.Add(Me.lbl_desde_depositado)
        Me.gp_depositado.Controls.Add(Me.chk_hastaSiempre_depositado)
        Me.gp_depositado.Controls.Add(Me.dtp_hasta_depositado)
        Me.gp_depositado.Controls.Add(Me.chk_desdeSiempre_depositado)
        Me.gp_depositado.Controls.Add(Me.lbl_hasta_depositado)
        Me.gp_depositado.Controls.Add(Me.dtp_desde_depositado)
        Me.gp_depositado.Location = New System.Drawing.Point(4, 108)
        Me.gp_depositado.Name = "gp_depositado"
        Me.gp_depositado.Size = New System.Drawing.Size(412, 109)
        Me.gp_depositado.TabIndex = 143
        Me.gp_depositado.TabStop = False
        Me.gp_depositado.Text = "Fecha de depósito"
        '
        'frm_depositarCH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 806)
        Me.Controls.Add(Me.cmd_anularDeposito)
        Me.Controls.Add(Me.cmd_acreditar)
        Me.Controls.Add(Me.group_chDepositados)
        Me.Controls.Add(Me.group_chCartera)
        Me.Controls.Add(Me.cmd_depositar)
        Me.Name = "frm_depositarCH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Depositar cheque"
        CType(Me.dg_view_chCartera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_view_chDepositados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_chCartera.ResumeLayout(False)
        Me.group_chCartera.PerformLayout()
        Me.group_chDepositados.ResumeLayout(False)
        Me.group_chDepositados.PerformLayout()
        Me.gp_cartera.ResumeLayout(False)
        Me.gp_cartera.PerformLayout()
        Me.gp_depositado.ResumeLayout(False)
        Me.gp_depositado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmb_banco As ComboBox
    Friend WithEvents lbl_Banco As Label
    Friend WithEvents lbl_nCH As Label
    Friend WithEvents txt_nCH_cartera As TextBox
    Friend WithEvents lbl_importeCH_cartera As Label
    Friend WithEvents txt_importeCH_cartera As TextBox
    Friend WithEvents dg_view_chCartera As DataGridView
    Friend WithEvents cmd_depositar As Button
    Friend WithEvents dg_view_chDepositados As DataGridView
    Friend WithEvents cmd_filtrarCH_cartera As Button
    Friend WithEvents group_chCartera As GroupBox
    Friend WithEvents group_chDepositados As GroupBox
    Friend WithEvents cmd_acreditar As Button
    Friend WithEvents cmd_anularDeposito As Button
    Friend WithEvents cmd_go_cartera As Button
    Friend WithEvents txt_nPage_cartera As TextBox
    Friend WithEvents cmd_last_cartera As Button
    Friend WithEvents cmd_next_cartera As Button
    Friend WithEvents cmd_prev_cartera As Button
    Friend WithEvents cmd_first_cartera As Button
    Friend WithEvents dtp_desde_depositado As DateTimePicker
    Friend WithEvents cmd_filtrarCH_depositado As Button
    Friend WithEvents txt_nCH_depositado As TextBox
    Friend WithEvents lbl_desde_depositado As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_importeCH_depositado As Label
    Friend WithEvents lbl_hasta_depositado As Label
    Friend WithEvents chk_desdeSiempre_depositado As CheckBox
    Friend WithEvents dtp_hasta_depositado As DateTimePicker
    Friend WithEvents txt_importeCH_depositado As TextBox
    Friend WithEvents chk_hastaSiempre_depositado As CheckBox
    Friend WithEvents cmd_go_depositado As Button
    Friend WithEvents txt_nPage_depositado As TextBox
    Friend WithEvents cmd_last_depositado As Button
    Friend WithEvents cmd_next_depositado As Button
    Friend WithEvents cmd_prev_depositado As Button
    Friend WithEvents cmd_first_depositado As Button
    Friend WithEvents cmb_cuentaBancaria As ComboBox
    Friend WithEvents lbl_CuentaBancaria As Label
    Friend WithEvents gp_cartera As GroupBox
    Friend WithEvents lbl_desde_cartera As Label
    Friend WithEvents dtp_desde_cartera As DateTimePicker
    Friend WithEvents lbl_hasta_cartera As Label
    Friend WithEvents dtp_hasta_cartera As DateTimePicker
    Friend WithEvents chk_hastaSiempre_cartera As CheckBox
    Friend WithEvents chk_desdeSiempre_cartera As CheckBox
    Friend WithEvents gp_depositado As GroupBox
End Class
