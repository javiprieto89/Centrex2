<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_stock
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
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_cancel = New System.Windows.Forms.Button()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_factura = New System.Windows.Forms.TextBox()
        Me.lbl_factura = New System.Windows.Forms.Label()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.cmd_additem = New System.Windows.Forms.Button()
        Me.psearch_proveedor = New System.Windows.Forms.PictureBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_fechaingreso = New System.Windows.Forms.Label()
        Me.lbl_fecha_ingreso = New System.Windows.Forms.Label()
        Me.lbl_tooltip = New System.Windows.Forms.Label()
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1.SuspendLayout
        CType(Me.psearch_proveedor,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dg_view,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(288, 472)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(159, 42)
        Me.cmd_ok.TabIndex = 6
        Me.cmd_ok.Text = "Aceptar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_cancel
        '
        Me.cmd_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_cancel.Location = New System.Drawing.Point(470, 472)
        Me.cmd_cancel.Name = "cmd_cancel"
        Me.cmd_cancel.Size = New System.Drawing.Size(159, 42)
        Me.cmd_cancel.TabIndex = 7
        Me.cmd_cancel.Text = "Cancelar"
        Me.cmd_cancel.UseVisualStyleBackColor = True
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(27, 16)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(40, 13)
        Me.lbl_fecha.TabIndex = 8
        Me.lbl_fecha.Text = "Fecha:"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(107, 48)
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
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(95, 12)
        Me.txt_fecha.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.Size = New System.Drawing.Size(154, 20)
        Me.txt_fecha.TabIndex = 0
        '
        'txt_factura
        '
        Me.txt_factura.Location = New System.Drawing.Point(95, 40)
        Me.txt_factura.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.Size = New System.Drawing.Size(154, 20)
        Me.txt_factura.TabIndex = 1
        '
        'lbl_factura
        '
        Me.lbl_factura.AutoSize = True
        Me.lbl_factura.Location = New System.Drawing.Point(26, 41)
        Me.lbl_factura.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_factura.Name = "lbl_factura"
        Me.lbl_factura.Size = New System.Drawing.Size(43, 13)
        Me.lbl_factura.TabIndex = 9
        Me.lbl_factura.Text = "Factura"
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(26, 68)
        Me.lbl_proveedor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 10
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'cmd_additem
        '
        Me.cmd_additem.Location = New System.Drawing.Point(23, 112)
        Me.cmd_additem.Name = "cmd_additem"
        Me.cmd_additem.Size = New System.Drawing.Size(75, 23)
        Me.cmd_additem.TabIndex = 4
        Me.cmd_additem.Text = "Agregar item"
        Me.cmd_additem.UseVisualStyleBackColor = True
        '
        'psearch_proveedor
        '
        Me.psearch_proveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_proveedor.Location = New System.Drawing.Point(254, 66)
        Me.psearch_proveedor.Name = "psearch_proveedor"
        Me.psearch_proveedor.Size = New System.Drawing.Size(22, 22)
        Me.psearch_proveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_proveedor.TabIndex = 70
        Me.psearch_proveedor.TabStop = False
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(95, 66)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(154, 21)
        Me.cmb_proveedor.TabIndex = 2
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(312, 55)
        Me.lbl_notas.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 11
        Me.lbl_notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(412, 41)
        Me.txt_notas.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(482, 45)
        Me.txt_notas.TabIndex = 3
        Me.txt_notas.WordWrap = False
        '
        'lbl_fechaingreso
        '
        Me.lbl_fechaingreso.AutoSize = True
        Me.lbl_fechaingreso.Location = New System.Drawing.Point(312, 16)
        Me.lbl_fechaingreso.Name = "lbl_fechaingreso"
        Me.lbl_fechaingreso.Size = New System.Drawing.Size(92, 13)
        Me.lbl_fechaingreso.TabIndex = 71
        Me.lbl_fechaingreso.Text = "Fecha de ingreso:"
        '
        'lbl_fecha_ingreso
        '
        Me.lbl_fecha_ingreso.AutoSize = True
        Me.lbl_fecha_ingreso.Location = New System.Drawing.Point(410, 16)
        Me.lbl_fecha_ingreso.Name = "lbl_fecha_ingreso"
        Me.lbl_fecha_ingreso.Size = New System.Drawing.Size(40, 13)
        Me.lbl_fecha_ingreso.TabIndex = 72
        Me.lbl_fecha_ingreso.Text = "Fecha:"
        '
        'lbl_tooltip
        '
        Me.lbl_tooltip.AutoSize = True
        Me.lbl_tooltip.ForeColor = System.Drawing.Color.Red
        Me.lbl_tooltip.Location = New System.Drawing.Point(428, 30)
        Me.lbl_tooltip.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_tooltip.Name = "lbl_tooltip"
        Me.lbl_tooltip.Size = New System.Drawing.Size(224, 13)
        Me.lbl_tooltip.TabIndex = 73
        Me.lbl_tooltip.Text = "La fecha de ingreso NO puede ser modificada"
        Me.lbl_tooltip.Visible = False
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dg_view.Location = New System.Drawing.Point(23, 141)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(871, 312)
        Me.dg_view.TabIndex = 86
        '
        'add_stock
        '
        Me.AcceptButton = Me.cmd_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmd_cancel
        Me.ClientSize = New System.Drawing.Size(914, 525)
        Me.Controls.Add(Me.dg_view)
        Me.Controls.Add(Me.lbl_tooltip)
        Me.Controls.Add(Me.lbl_fecha_ingreso)
        Me.Controls.Add(Me.lbl_fechaingreso)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.psearch_proveedor)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.cmd_additem)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.txt_factura)
        Me.Controls.Add(Me.lbl_factura)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.cmd_cancel)
        Me.Controls.Add(Me.cmd_ok)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "add_stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso de mercaderia"
        Me.ContextMenuStrip1.ResumeLayout(false)
        CType(Me.psearch_proveedor,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dg_view,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents cmd_cancel As System.Windows.Forms.Button
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura As System.Windows.Forms.TextBox
    Friend WithEvents lbl_factura As System.Windows.Forms.Label
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents cmd_additem As System.Windows.Forms.Button
    Friend WithEvents psearch_proveedor As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_notas As System.Windows.Forms.Label
    Friend WithEvents txt_notas As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_fechaingreso As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha_ingreso As System.Windows.Forms.Label
    Friend WithEvents lbl_tooltip As System.Windows.Forms.Label
    Friend WithEvents dg_view As System.Windows.Forms.DataGridView
End Class
