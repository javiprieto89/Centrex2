<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class infoagregarstock
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
        Me.lblitem = New System.Windows.Forms.Label()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.lbl_preciolista = New System.Windows.Forms.Label()
        Me.lbl_costo = New System.Windows.Forms.Label()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.lbl_factura = New System.Windows.Forms.Label()
        Me.lbl_factor = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.txt_factor = New System.Windows.Forms.TextBox()
        Me.txt_preciolista = New System.Windows.Forms.TextBox()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.txt_factura = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.psearch_proveedor = New System.Windows.Forms.PictureBox()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.psearch_item = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_item, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblitem
        '
        Me.lblitem.AutoSize = True
        Me.lblitem.Location = New System.Drawing.Point(26, 24)
        Me.lblitem.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblitem.Name = "lblitem"
        Me.lblitem.Size = New System.Drawing.Size(27, 13)
        Me.lblitem.TabIndex = 0
        Me.lblitem.Text = "Item"
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(112, 24)
        Me.lbl_item.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(42, 13)
        Me.lbl_item.TabIndex = 1
        Me.lbl_item.Text = "%item%"
        '
        'lbl_preciolista
        '
        Me.lbl_preciolista.AutoSize = True
        Me.lbl_preciolista.Location = New System.Drawing.Point(24, 270)
        Me.lbl_preciolista.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_preciolista.Name = "lbl_preciolista"
        Me.lbl_preciolista.Size = New System.Drawing.Size(58, 13)
        Me.lbl_preciolista.TabIndex = 2
        Me.lbl_preciolista.Text = "Precio lista"
        '
        'lbl_costo
        '
        Me.lbl_costo.AutoSize = True
        Me.lbl_costo.Location = New System.Drawing.Point(26, 202)
        Me.lbl_costo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_costo.Name = "lbl_costo"
        Me.lbl_costo.Size = New System.Drawing.Size(34, 13)
        Me.lbl_costo.TabIndex = 3
        Me.lbl_costo.Text = "Costo"
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(26, 167)
        Me.lbl_cantidad.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 4
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'lbl_factura
        '
        Me.lbl_factura.AutoSize = True
        Me.lbl_factura.Location = New System.Drawing.Point(26, 96)
        Me.lbl_factura.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_factura.Name = "lbl_factura"
        Me.lbl_factura.Size = New System.Drawing.Size(43, 13)
        Me.lbl_factura.TabIndex = 5
        Me.lbl_factura.Text = "Factura"
        '
        'lbl_factor
        '
        Me.lbl_factor.AutoSize = True
        Me.lbl_factor.Location = New System.Drawing.Point(26, 236)
        Me.lbl_factor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_factor.Name = "lbl_factor"
        Me.lbl_factor.Size = New System.Drawing.Size(37, 13)
        Me.lbl_factor.TabIndex = 6
        Me.lbl_factor.Text = "Factor"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(26, 61)
        Me.lbl_fecha.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(37, 13)
        Me.lbl_fecha.TabIndex = 7
        Me.lbl_fecha.Text = "Fecha"
        '
        'txt_fecha
        '
        Me.txt_fecha.Location = New System.Drawing.Point(114, 58)
        Me.txt_fecha.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.Size = New System.Drawing.Size(154, 20)
        Me.txt_fecha.TabIndex = 0
        '
        'txt_factor
        '
        Me.txt_factor.Location = New System.Drawing.Point(114, 232)
        Me.txt_factor.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_factor.Name = "txt_factor"
        Me.txt_factor.Size = New System.Drawing.Size(154, 20)
        Me.txt_factor.TabIndex = 5
        '
        'txt_preciolista
        '
        Me.txt_preciolista.Location = New System.Drawing.Point(114, 267)
        Me.txt_preciolista.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_preciolista.Name = "txt_preciolista"
        Me.txt_preciolista.Size = New System.Drawing.Size(154, 20)
        Me.txt_preciolista.TabIndex = 6
        '
        'txt_costo
        '
        Me.txt_costo.Location = New System.Drawing.Point(114, 197)
        Me.txt_costo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(154, 20)
        Me.txt_costo.TabIndex = 4
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(114, 162)
        Me.txt_cantidad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(154, 20)
        Me.txt_cantidad.TabIndex = 3
        '
        'txt_factura
        '
        Me.txt_factura.Location = New System.Drawing.Point(114, 93)
        Me.txt_factura.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.Size = New System.Drawing.Size(154, 20)
        Me.txt_factura.TabIndex = 1
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(169, 426)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 9
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(71, 426)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 8
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(26, 131)
        Me.lbl_proveedor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 16
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'psearch_proveedor
        '
        Me.psearch_proveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_proveedor.Location = New System.Drawing.Point(273, 128)
        Me.psearch_proveedor.Name = "psearch_proveedor"
        Me.psearch_proveedor.Size = New System.Drawing.Size(22, 22)
        Me.psearch_proveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_proveedor.TabIndex = 72
        Me.psearch_proveedor.TabStop = False
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(114, 128)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(154, 21)
        Me.cmb_proveedor.TabIndex = 2
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(26, 306)
        Me.lbl_notas.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 73
        Me.lbl_notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(114, 302)
        Me.txt_notas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(154, 88)
        Me.txt_notas.TabIndex = 7
        Me.txt_notas.WordWrap = False
        '
        'psearch_item
        '
        Me.psearch_item.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_item.Location = New System.Drawing.Point(273, 24)
        Me.psearch_item.Name = "psearch_item"
        Me.psearch_item.Size = New System.Drawing.Size(22, 22)
        Me.psearch_item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_item.TabIndex = 74
        Me.psearch_item.TabStop = False
        Me.ToolTip1.SetToolTip(Me.psearch_item, "Modificar item")
        Me.psearch_item.Visible = False
        '
        'infoagregarstock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 473)
        Me.Controls.Add(Me.psearch_item)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.psearch_proveedor)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_factura)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.txt_costo)
        Me.Controls.Add(Me.txt_preciolista)
        Me.Controls.Add(Me.txt_factor)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.lbl_factor)
        Me.Controls.Add(Me.lbl_factura)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Controls.Add(Me.lbl_costo)
        Me.Controls.Add(Me.lbl_preciolista)
        Me.Controls.Add(Me.lbl_item)
        Me.Controls.Add(Me.lblitem)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "infoagregarstock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Actualizar stock"
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_item, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblitem As System.Windows.Forms.Label
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents lbl_preciolista As System.Windows.Forms.Label
    Friend WithEvents lbl_costo As System.Windows.Forms.Label
    Friend WithEvents lbl_cantidad As System.Windows.Forms.Label
    Friend WithEvents lbl_factura As System.Windows.Forms.Label
    Friend WithEvents lbl_factor As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents txt_factor As System.Windows.Forms.TextBox
    Friend WithEvents txt_preciolista As System.Windows.Forms.TextBox
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura As System.Windows.Forms.TextBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents psearch_proveedor As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_notas As System.Windows.Forms.Label
    Friend WithEvents txt_notas As System.Windows.Forms.TextBox
    Friend WithEvents psearch_item As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
