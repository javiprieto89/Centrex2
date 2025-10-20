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
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.chk_desdeSiempre = New System.Windows.Forms.CheckBox()
        Me.chk_hastaSiempre = New System.Windows.Forms.CheckBox()
        Me.chk_cerrados = New System.Windows.Forms.CheckBox()
        Me.chk_abiertos = New System.Windows.Forms.CheckBox()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_hasta = New System.Windows.Forms.Label()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.lbl_desde = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.cmd_consultar = New System.Windows.Forms.Button()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.psearch_tipo = New System.Windows.Forms.PictureBox()
        Me.lbl_tipoDocs = New System.Windows.Forms.Label()
        Me.cmb_tipoDocs = New System.Windows.Forms.ComboBox()
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_tipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_total.Location = New System.Drawing.Point(24, 248)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(94, 13)
        Me.lbl_total.TabIndex = 124
        Me.lbl_total.Text = "Total facturado"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Red
        Me.txt_total.Location = New System.Drawing.Point(124, 245)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(248, 20)
        Me.txt_total.TabIndex = 123
        '
        'chk_desdeSiempre
        '
        Me.chk_desdeSiempre.AutoSize = True
        Me.chk_desdeSiempre.Checked = True
        Me.chk_desdeSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_desdeSiempre.Location = New System.Drawing.Point(351, 64)
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
        Me.chk_hastaSiempre.Location = New System.Drawing.Point(351, 103)
        Me.chk_hastaSiempre.Name = "chk_hastaSiempre"
        Me.chk_hastaSiempre.Size = New System.Drawing.Size(87, 17)
        Me.chk_hastaSiempre.TabIndex = 121
        Me.chk_hastaSiempre.Text = "Hasta el final"
        Me.chk_hastaSiempre.UseVisualStyleBackColor = True
        '
        'chk_cerrados
        '
        Me.chk_cerrados.AutoSize = True
        Me.chk_cerrados.Checked = True
        Me.chk_cerrados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_cerrados.Location = New System.Drawing.Point(557, 61)
        Me.chk_cerrados.Name = "chk_cerrados"
        Me.chk_cerrados.Size = New System.Drawing.Size(154, 17)
        Me.chk_cerrados.TabIndex = 119
        Me.chk_cerrados.Text = "Consultar pedidos cerrados"
        Me.chk_cerrados.UseVisualStyleBackColor = True
        '
        'chk_abiertos
        '
        Me.chk_abiertos.AutoSize = True
        Me.chk_abiertos.Location = New System.Drawing.Point(557, 103)
        Me.chk_abiertos.Name = "chk_abiertos"
        Me.chk_abiertos.Size = New System.Drawing.Size(150, 17)
        Me.chk_abiertos.TabIndex = 118
        Me.chk_abiertos.Text = "Consultar pedidos abiertos"
        Me.chk_abiertos.UseVisualStyleBackColor = True
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Enabled = False
        Me.dtp_hasta.Location = New System.Drawing.Point(97, 100)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(248, 20)
        Me.dtp_hasta.TabIndex = 114
        '
        'lbl_hasta
        '
        Me.lbl_hasta.AutoSize = True
        Me.lbl_hasta.Location = New System.Drawing.Point(22, 102)
        Me.lbl_hasta.Name = "lbl_hasta"
        Me.lbl_hasta.Size = New System.Drawing.Size(35, 13)
        Me.lbl_hasta.TabIndex = 115
        Me.lbl_hasta.Text = "Hasta"
        '
        'dtp_desde
        '
        Me.dtp_desde.Enabled = False
        Me.dtp_desde.Location = New System.Drawing.Point(97, 61)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(248, 20)
        Me.dtp_desde.TabIndex = 112
        '
        'lbl_desde
        '
        Me.lbl_desde.AutoSize = True
        Me.lbl_desde.Location = New System.Drawing.Point(22, 63)
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
        Me.cmb_proveedor.Location = New System.Drawing.Point(97, 21)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(248, 21)
        Me.cmb_proveedor.TabIndex = 111
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.Location = New System.Drawing.Point(24, 285)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(958, 367)
        Me.dg_view.TabIndex = 110
        '
        'cmd_consultar
        '
        Me.cmd_consultar.Location = New System.Drawing.Point(25, 195)
        Me.cmd_consultar.Name = "cmd_consultar"
        Me.cmd_consultar.Size = New System.Drawing.Size(142, 21)
        Me.cmd_consultar.TabIndex = 109
        Me.cmd_consultar.Text = "Ejecutar consulta"
        Me.cmd_consultar.UseVisualStyleBackColor = True
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(21, 24)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 108
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'psearch_tipo
        '
        Me.psearch_tipo.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_tipo.Location = New System.Drawing.Point(351, 20)
        Me.psearch_tipo.Name = "psearch_tipo"
        Me.psearch_tipo.Size = New System.Drawing.Size(22, 22)
        Me.psearch_tipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_tipo.TabIndex = 125
        Me.psearch_tipo.TabStop = False
        '
        'lbl_tipoDocs
        '
        Me.lbl_tipoDocs.AutoSize = True
        Me.lbl_tipoDocs.Location = New System.Drawing.Point(22, 141)
        Me.lbl_tipoDocs.Name = "lbl_tipoDocs"
        Me.lbl_tipoDocs.Size = New System.Drawing.Size(67, 13)
        Me.lbl_tipoDocs.TabIndex = 127
        Me.lbl_tipoDocs.Text = "Documentos"
        '
        'cmb_tipoDocs
        '
        Me.cmb_tipoDocs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_tipoDocs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_tipoDocs.FormattingEnabled = True
        Me.cmb_tipoDocs.Items.AddRange(New Object() {"Documentos contables", "Presupuestos", "Documentos de prueba", "Remitos", "Todos los documentos"})
        Me.cmb_tipoDocs.Location = New System.Drawing.Point(97, 139)
        Me.cmb_tipoDocs.Name = "cmb_tipoDocs"
        Me.cmb_tipoDocs.Size = New System.Drawing.Size(248, 21)
        Me.cmb_tipoDocs.TabIndex = 129
        Me.cmb_tipoDocs.Text = "Seleccione un tipo de documento"
        '
        'infoccProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 672)
        Me.Controls.Add(Me.cmb_tipoDocs)
        Me.Controls.Add(Me.lbl_tipoDocs)
        Me.Controls.Add(Me.psearch_tipo)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.chk_desdeSiempre)
        Me.Controls.Add(Me.chk_hastaSiempre)
        Me.Controls.Add(Me.chk_cerrados)
        Me.Controls.Add(Me.chk_abiertos)
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
        CType(Me.psearch_tipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_total As Label
    Friend WithEvents txt_total As TextBox
    Friend WithEvents chk_desdeSiempre As CheckBox
    Friend WithEvents chk_hastaSiempre As CheckBox
    Friend WithEvents chk_cerrados As CheckBox
    Friend WithEvents chk_abiertos As CheckBox
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents lbl_hasta As Label
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents lbl_desde As Label
    Friend WithEvents cmb_proveedor As ComboBox
    Friend WithEvents dg_view As DataGridView
    Friend WithEvents cmd_consultar As Button
    Friend WithEvents lbl_proveedor As Label
    Friend WithEvents psearch_tipo As PictureBox
    Friend WithEvents lbl_tipoDocs As Label
    Friend WithEvents cmb_tipoDocs As ComboBox
End Class
