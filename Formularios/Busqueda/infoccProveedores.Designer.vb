<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class infoccProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(infoccProveedores))
        Me.chk_desdeSiempre = New System.Windows.Forms.CheckBox()
        Me.chk_hastaSiempre = New System.Windows.Forms.CheckBox()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_hasta = New System.Windows.Forms.Label()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.lbl_desde = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.cmd_consultar = New System.Windows.Forms.Button()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.lbl_cc = New System.Windows.Forms.Label()
        Me.cmb_cc = New System.Windows.Forms.ComboBox()
        Me.pExportXLS = New System.Windows.Forms.PictureBox()
        Me.psearch_cc = New System.Windows.Forms.PictureBox()
        Me.psearch_proveedor = New System.Windows.Forms.PictureBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.cmd_go = New System.Windows.Forms.Button()
        Me.txt_nPage = New System.Windows.Forms.TextBox()
        Me.cmd_last = New System.Windows.Forms.Button()
        Me.cmd_next = New System.Windows.Forms.Button()
        Me.cmd_prev = New System.Windows.Forms.Button()
        Me.cmd_first = New System.Windows.Forms.Button()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lbl_saldo = New System.Windows.Forms.Label()
        Me.lbl_saldo2 = New System.Windows.Forms.Label()
        Me.dgView_paraExportar = New System.Windows.Forms.DataGridView()
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pExportXLS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_cc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgView_paraExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chk_desdeSiempre
        '
        Me.chk_desdeSiempre.AutoSize = True
        Me.chk_desdeSiempre.Checked = True
        Me.chk_desdeSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_desdeSiempre.Location = New System.Drawing.Point(431, 64)
        Me.chk_desdeSiempre.Name = "chk_desdeSiempre"
        Me.chk_desdeSiempre.Size = New System.Drawing.Size(116, 17)
        Me.chk_desdeSiempre.TabIndex = 122
        Me.chk_desdeSiempre.Text = "Desde el comienzo"
        Me.chk_desdeSiempre.UseVisualStyleBackColor = True
        '
        'chk_hastaSiempre
        '
        Me.chk_hastaSiempre.AutoSize = True
        Me.chk_hastaSiempre.Checked = True
        Me.chk_hastaSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_hastaSiempre.Location = New System.Drawing.Point(431, 103)
        Me.chk_hastaSiempre.Name = "chk_hastaSiempre"
        Me.chk_hastaSiempre.Size = New System.Drawing.Size(87, 17)
        Me.chk_hastaSiempre.TabIndex = 121
        Me.chk_hastaSiempre.Text = "Hasta el final"
        Me.chk_hastaSiempre.UseVisualStyleBackColor = True
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Enabled = False
        Me.dtp_hasta.Location = New System.Drawing.Point(177, 100)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(248, 20)
        Me.dtp_hasta.TabIndex = 3
        '
        'lbl_hasta
        '
        Me.lbl_hasta.AutoSize = True
        Me.lbl_hasta.Location = New System.Drawing.Point(102, 102)
        Me.lbl_hasta.Name = "lbl_hasta"
        Me.lbl_hasta.Size = New System.Drawing.Size(35, 13)
        Me.lbl_hasta.TabIndex = 115
        Me.lbl_hasta.Text = "Hasta"
        '
        'dtp_desde
        '
        Me.dtp_desde.Enabled = False
        Me.dtp_desde.Location = New System.Drawing.Point(177, 61)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(248, 20)
        Me.dtp_desde.TabIndex = 2
        '
        'lbl_desde
        '
        Me.lbl_desde.AutoSize = True
        Me.lbl_desde.Location = New System.Drawing.Point(102, 63)
        Me.lbl_desde.Name = "lbl_desde"
        Me.lbl_desde.Size = New System.Drawing.Size(38, 13)
        Me.lbl_desde.TabIndex = 113
        Me.lbl_desde.Text = "Desde"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(177, 20)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(248, 21)
        Me.cmb_proveedor.TabIndex = 0
        Me.cmb_proveedor.Text = "Seleccione un proveedor..."
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.Location = New System.Drawing.Point(22, 278)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(958, 367)
        Me.dg_view.TabIndex = 6
        '
        'cmd_consultar
        '
        Me.cmd_consultar.Location = New System.Drawing.Point(431, 163)
        Me.cmd_consultar.Name = "cmd_consultar"
        Me.cmd_consultar.Size = New System.Drawing.Size(142, 44)
        Me.cmd_consultar.TabIndex = 5
        Me.cmd_consultar.Text = "Ejecutar consulta"
        Me.cmd_consultar.UseVisualStyleBackColor = True
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(101, 24)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 108
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'lbl_cc
        '
        Me.lbl_cc.AutoSize = True
        Me.lbl_cc.Location = New System.Drawing.Point(481, 24)
        Me.lbl_cc.Name = "lbl_cc"
        Me.lbl_cc.Size = New System.Drawing.Size(85, 13)
        Me.lbl_cc.TabIndex = 130
        Me.lbl_cc.Text = "Cuenta corriente"
        '
        'cmb_cc
        '
        Me.cmb_cc.Enabled = False
        Me.cmb_cc.FormattingEnabled = True
        Me.cmb_cc.Location = New System.Drawing.Point(584, 20)
        Me.cmb_cc.Name = "cmb_cc"
        Me.cmb_cc.Size = New System.Drawing.Size(248, 21)
        Me.cmb_cc.TabIndex = 136
        Me.cmb_cc.Text = "Seleccione una cuenta corriente..."
        '
        'pExportXLS
        '
        Me.pExportXLS.Image = CType(resources.GetObject("pExportXLS.Image"), System.Drawing.Image)
        Me.pExportXLS.Location = New System.Drawing.Point(22, 221)
        Me.pExportXLS.Name = "pExportXLS"
        Me.pExportXLS.Size = New System.Drawing.Size(55, 42)
        Me.pExportXLS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pExportXLS.TabIndex = 137
        Me.pExportXLS.TabStop = False
        '
        'psearch_cc
        '
        Me.psearch_cc.Image = CType(resources.GetObject("psearch_cc.Image"), System.Drawing.Image)
        Me.psearch_cc.Location = New System.Drawing.Point(841, 19)
        Me.psearch_cc.Name = "psearch_cc"
        Me.psearch_cc.Size = New System.Drawing.Size(22, 22)
        Me.psearch_cc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_cc.TabIndex = 132
        Me.psearch_cc.TabStop = False
        '
        'psearch_proveedor
        '
        Me.psearch_proveedor.Image = CType(resources.GetObject("psearch_proveedor.Image"), System.Drawing.Image)
        Me.psearch_proveedor.Location = New System.Drawing.Point(431, 20)
        Me.psearch_proveedor.Name = "psearch_proveedor"
        Me.psearch_proveedor.Size = New System.Drawing.Size(22, 22)
        Me.psearch_proveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_proveedor.TabIndex = 125
        Me.psearch_proveedor.TabStop = False
        '
        'cmd_go
        '
        Me.cmd_go.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_go.Enabled = False
        Me.cmd_go.Location = New System.Drawing.Point(950, 250)
        Me.cmd_go.Name = "cmd_go"
        Me.cmd_go.Size = New System.Drawing.Size(29, 20)
        Me.cmd_go.TabIndex = 153
        Me.cmd_go.Text = "Ir"
        Me.cmd_go.UseVisualStyleBackColor = True
        '
        'txt_nPage
        '
        Me.txt_nPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nPage.Enabled = False
        Me.txt_nPage.Location = New System.Drawing.Point(881, 250)
        Me.txt_nPage.Name = "txt_nPage"
        Me.txt_nPage.Size = New System.Drawing.Size(63, 20)
        Me.txt_nPage.TabIndex = 152
        '
        'cmd_last
        '
        Me.cmd_last.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_last.Enabled = False
        Me.cmd_last.Location = New System.Drawing.Point(846, 250)
        Me.cmd_last.Name = "cmd_last"
        Me.cmd_last.Size = New System.Drawing.Size(29, 20)
        Me.cmd_last.TabIndex = 151
        Me.cmd_last.Text = ">>|"
        Me.cmd_last.UseVisualStyleBackColor = True
        '
        'cmd_next
        '
        Me.cmd_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_next.Enabled = False
        Me.cmd_next.Location = New System.Drawing.Point(800, 250)
        Me.cmd_next.Name = "cmd_next"
        Me.cmd_next.Size = New System.Drawing.Size(40, 20)
        Me.cmd_next.TabIndex = 150
        Me.cmd_next.Text = ">>"
        Me.cmd_next.UseVisualStyleBackColor = True
        '
        'cmd_prev
        '
        Me.cmd_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_prev.Enabled = False
        Me.cmd_prev.Location = New System.Drawing.Point(754, 250)
        Me.cmd_prev.Name = "cmd_prev"
        Me.cmd_prev.Size = New System.Drawing.Size(40, 20)
        Me.cmd_prev.TabIndex = 149
        Me.cmd_prev.Text = "<<"
        Me.cmd_prev.UseVisualStyleBackColor = True
        '
        'cmd_first
        '
        Me.cmd_first.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_first.Enabled = False
        Me.cmd_first.Location = New System.Drawing.Point(719, 250)
        Me.cmd_first.Name = "cmd_first"
        Me.cmd_first.Size = New System.Drawing.Size(29, 20)
        Me.cmd_first.TabIndex = 148
        Me.cmd_first.Text = "|<<"
        Me.cmd_first.UseVisualStyleBackColor = True
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.ForeColor = System.Drawing.Color.Blue
        Me.lbl_total.Location = New System.Drawing.Point(495, 250)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(71, 13)
        Me.lbl_total.TabIndex = 147
        Me.lbl_total.Text = "%$$_total%"
        Me.lbl_total.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(395, 250)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(98, 13)
        Me.lblTotal.TabIndex = 146
        Me.lblTotal.Text = "Total facturado:"
        '
        'lbl_saldo
        '
        Me.lbl_saldo.AutoSize = True
        Me.lbl_saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo.ForeColor = System.Drawing.Color.Green
        Me.lbl_saldo.Location = New System.Drawing.Point(153, 250)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.Size = New System.Drawing.Size(85, 13)
        Me.lbl_saldo.TabIndex = 145
        Me.lbl_saldo.Text = "%$$_saldo%%"
        Me.lbl_saldo.Visible = False
        '
        'lbl_saldo2
        '
        Me.lbl_saldo2.AutoSize = True
        Me.lbl_saldo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_saldo2.Location = New System.Drawing.Point(102, 250)
        Me.lbl_saldo2.Name = "lbl_saldo2"
        Me.lbl_saldo2.Size = New System.Drawing.Size(43, 13)
        Me.lbl_saldo2.TabIndex = 144
        Me.lbl_saldo2.Text = "Saldo:"
        '
        'dgView_paraExportar
        '
        Me.dgView_paraExportar.AllowUserToAddRows = False
        Me.dgView_paraExportar.AllowUserToDeleteRows = False
        Me.dgView_paraExportar.AllowUserToOrderColumns = True
        Me.dgView_paraExportar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgView_paraExportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView_paraExportar.Location = New System.Drawing.Point(902, 12)
        Me.dgView_paraExportar.MultiSelect = False
        Me.dgView_paraExportar.Name = "dgView_paraExportar"
        Me.dgView_paraExportar.ReadOnly = True
        Me.dgView_paraExportar.RowHeadersVisible = False
        Me.dgView_paraExportar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView_paraExportar.Size = New System.Drawing.Size(89, 64)
        Me.dgView_paraExportar.TabIndex = 154
        Me.dgView_paraExportar.Visible = False
        '
        'infoccProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 672)
        Me.Controls.Add(Me.dgView_paraExportar)
        Me.Controls.Add(Me.cmd_go)
        Me.Controls.Add(Me.txt_nPage)
        Me.Controls.Add(Me.cmd_last)
        Me.Controls.Add(Me.cmd_next)
        Me.Controls.Add(Me.cmd_prev)
        Me.Controls.Add(Me.cmd_first)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lbl_saldo)
        Me.Controls.Add(Me.lbl_saldo2)
        Me.Controls.Add(Me.pExportXLS)
        Me.Controls.Add(Me.cmb_cc)
        Me.Controls.Add(Me.psearch_cc)
        Me.Controls.Add(Me.lbl_cc)
        Me.Controls.Add(Me.psearch_proveedor)
        Me.Controls.Add(Me.chk_desdeSiempre)
        Me.Controls.Add(Me.chk_hastaSiempre)
        Me.Controls.Add(Me.dtp_hasta)
        Me.Controls.Add(Me.lbl_hasta)
        Me.Controls.Add(Me.dtp_desde)
        Me.Controls.Add(Me.lbl_desde)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.dg_view)
        Me.Controls.Add(Me.cmd_consultar)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Name = "infoccProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cuenta corriente de proveedores"
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pExportXLS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_cc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgView_paraExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chk_desdeSiempre As CheckBox
    Friend WithEvents chk_hastaSiempre As CheckBox
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents lbl_hasta As Label
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents lbl_desde As Label
    Friend WithEvents cmb_proveedor As ComboBox
    Friend WithEvents dg_view As DataGridView
    Friend WithEvents cmd_consultar As Button
    Friend WithEvents lbl_proveedor As Label
    Friend WithEvents psearch_proveedor As PictureBox
    Friend WithEvents lbl_cc As Label
    Friend WithEvents psearch_cc As PictureBox
    Friend WithEvents cmb_cc As ComboBox
    Friend WithEvents pExportXLS As PictureBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents cmd_go As Button
    Friend WithEvents txt_nPage As TextBox
    Friend WithEvents cmd_last As Button
    Friend WithEvents cmd_next As Button
    Friend WithEvents cmd_prev As Button
    Friend WithEvents cmd_first As Button
    Friend WithEvents lbl_total As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lbl_saldo As Label
    Friend WithEvents lbl_saldo2 As Label
    Friend WithEvents dgView_paraExportar As DataGridView
End Class
