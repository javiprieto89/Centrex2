<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_ajuste_stock
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
        Me.cmb_items = New System.Windows.Forms.ComboBox()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.pic_search_item = New System.Windows.Forms.PictureBox()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        CType(Me.pic_search_item, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_items
        '
        Me.cmb_items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_items.FormattingEnabled = True
        Me.cmb_items.Location = New System.Drawing.Point(73, 23)
        Me.cmb_items.Name = "cmb_items"
        Me.cmb_items.Size = New System.Drawing.Size(259, 21)
        Me.cmb_items.TabIndex = 26
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(22, 66)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 33
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(201, 279)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 31
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(103, 279)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 30
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(23, 31)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(27, 13)
        Me.lbl_item.TabIndex = 32
        Me.lbl_item.Text = "Item"
        '
        'pic_search_item
        '
        Me.pic_search_item.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_search_item.Location = New System.Drawing.Point(338, 23)
        Me.pic_search_item.Name = "pic_search_item"
        Me.pic_search_item.Size = New System.Drawing.Size(22, 22)
        Me.pic_search_item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search_item.TabIndex = 50
        Me.pic_search_item.TabStop = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(73, 63)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(259, 20)
        Me.txt_cantidad.TabIndex = 51
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(73, 103)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(259, 121)
        Me.txt_notas.TabIndex = 53
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(22, 106)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 52
        Me.lbl_notas.Text = "Notas"
        '
        'add_ajuste_stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 315)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.pic_search_item)
        Me.Controls.Add(Me.cmb_items)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_item)
        Me.Name = "add_ajuste_stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Relacionar Item - Impuestos"
        CType(Me.pic_search_item, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_items As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_cantidad As System.Windows.Forms.Label
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents pic_search_item As System.Windows.Forms.PictureBox
    Friend WithEvents txt_cantidad As TextBox
    Friend WithEvents txt_notas As TextBox
    Friend WithEvents lbl_notas As Label
End Class
