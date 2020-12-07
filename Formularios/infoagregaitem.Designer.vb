<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class infoagregaitem
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
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.lbl_precio = New System.Windows.Forms.Label()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.txt_precio = New System.Windows.Forms.TextBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_desc = New System.Windows.Forms.Label()
        Me.lbldesc = New System.Windows.Forms.Label()
        Me.lbl_stock = New System.Windows.Forms.Label()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.lblstock = New System.Windows.Forms.Label()
        Me.lblitem = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(168, 162)
        Me.lbl_cantidad.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 1
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'lbl_precio
        '
        Me.lbl_precio.AutoSize = True
        Me.lbl_precio.Location = New System.Drawing.Point(289, 162)
        Me.lbl_precio.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_precio.Name = "lbl_precio"
        Me.lbl_precio.Size = New System.Drawing.Size(37, 13)
        Me.lbl_precio.TabIndex = 2
        Me.lbl_precio.Text = "Precio"
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(170, 194)
        Me.txt_cantidad.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(88, 20)
        Me.txt_cantidad.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txt_cantidad, "Si la cantidad ingresada es igual a -1, se cancela la operación")
        '
        'txt_precio
        '
        Me.txt_precio.Location = New System.Drawing.Point(291, 194)
        Me.txt_precio.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.Size = New System.Drawing.Size(88, 20)
        Me.txt_precio.TabIndex = 1
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(190, 247)
        Me.cmd_ok.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(70, 21)
        Me.cmd_ok.TabIndex = 2
        Me.cmd_ok.Text = "Aceptar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(286, 247)
        Me.cmd_exit.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(70, 21)
        Me.cmd_exit.TabIndex = 3
        Me.cmd_exit.Text = "Cancelar"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_desc)
        Me.GroupBox1.Controls.Add(Me.lbldesc)
        Me.GroupBox1.Controls.Add(Me.lbl_stock)
        Me.GroupBox1.Controls.Add(Me.lbl_item)
        Me.GroupBox1.Controls.Add(Me.lblstock)
        Me.GroupBox1.Controls.Add(Me.lblitem)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(500, 115)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información item"
        '
        'lbl_desc
        '
        Me.lbl_desc.AutoSize = True
        Me.lbl_desc.Location = New System.Drawing.Point(105, 50)
        Me.lbl_desc.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_desc.Name = "lbl_desc"
        Me.lbl_desc.Size = New System.Drawing.Size(77, 13)
        Me.lbl_desc.TabIndex = 8
        Me.lbl_desc.Text = "%descripción%"
        '
        'lbldesc
        '
        Me.lbldesc.AutoSize = True
        Me.lbldesc.Location = New System.Drawing.Point(31, 50)
        Me.lbldesc.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbldesc.Name = "lbldesc"
        Me.lbldesc.Size = New System.Drawing.Size(66, 13)
        Me.lbldesc.TabIndex = 7
        Me.lbldesc.Text = "Descripción:"
        '
        'lbl_stock
        '
        Me.lbl_stock.AutoSize = True
        Me.lbl_stock.Location = New System.Drawing.Point(106, 76)
        Me.lbl_stock.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_stock.Name = "lbl_stock"
        Me.lbl_stock.Size = New System.Drawing.Size(49, 13)
        Me.lbl_stock.TabIndex = 10
        Me.lbl_stock.Text = "%stock%"
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(106, 26)
        Me.lbl_item.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(42, 13)
        Me.lbl_item.TabIndex = 6
        Me.lbl_item.Text = "%item%"
        '
        'lblstock
        '
        Me.lblstock.AutoSize = True
        Me.lblstock.Location = New System.Drawing.Point(32, 76)
        Me.lblstock.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblstock.Name = "lblstock"
        Me.lblstock.Size = New System.Drawing.Size(38, 13)
        Me.lblstock.TabIndex = 9
        Me.lblstock.Text = "Stock:"
        '
        'lblitem
        '
        Me.lblitem.AutoSize = True
        Me.lblitem.Location = New System.Drawing.Point(32, 26)
        Me.lblitem.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblitem.Name = "lblitem"
        Me.lblitem.Size = New System.Drawing.Size(33, 13)
        Me.lblitem.TabIndex = 5
        Me.lblitem.Text = "Item: "
        '
        'infoagregaitem
        '
        Me.AcceptButton = Me.cmd_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 284)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_precio)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.lbl_precio)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "infoagregaitem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Centrex"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_cantidad As System.Windows.Forms.Label
    Friend WithEvents lbl_precio As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_precio As System.Windows.Forms.TextBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_desc As System.Windows.Forms.Label
    Friend WithEvents lbldesc As System.Windows.Forms.Label
    Friend WithEvents lbl_stock As System.Windows.Forms.Label
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents lblstock As System.Windows.Forms.Label
    Friend WithEvents lblitem As System.Windows.Forms.Label
End Class
