<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_itemImpuesto
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
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.cmb_items = New System.Windows.Forms.ComboBox()
        Me.lbl_impuesto = New System.Windows.Forms.Label()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.cmb_impuestos = New System.Windows.Forms.ComboBox()
        Me.pic_search_item = New System.Windows.Forms.PictureBox()
        Me.pic_search_impuestos = New System.Windows.Forms.PictureBox()
        CType(Me.pic_search_item, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_search_impuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(25, 100)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(100, 17)
        Me.chk_activo.TabIndex = 28
        Me.chk_activo.Text = "Relación activa"
        Me.chk_activo.UseVisualStyleBackColor = True
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
        'lbl_impuesto
        '
        Me.lbl_impuesto.AutoSize = True
        Me.lbl_impuesto.Location = New System.Drawing.Point(22, 69)
        Me.lbl_impuesto.Name = "lbl_impuesto"
        Me.lbl_impuesto.Size = New System.Drawing.Size(50, 13)
        Me.lbl_impuesto.TabIndex = 33
        Me.lbl_impuesto.Text = "Impuesto"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(25, 123)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 29
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(203, 163)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 31
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(105, 163)
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
        'cmb_impuestos
        '
        Me.cmb_impuestos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_impuestos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_impuestos.FormattingEnabled = True
        Me.cmb_impuestos.Location = New System.Drawing.Point(73, 61)
        Me.cmb_impuestos.Name = "cmb_impuestos"
        Me.cmb_impuestos.Size = New System.Drawing.Size(259, 21)
        Me.cmb_impuestos.TabIndex = 35
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
        'pic_search_impuestos
        '
        Me.pic_search_impuestos.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_search_impuestos.Location = New System.Drawing.Point(338, 61)
        Me.pic_search_impuestos.Name = "pic_search_impuestos"
        Me.pic_search_impuestos.Size = New System.Drawing.Size(22, 22)
        Me.pic_search_impuestos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search_impuestos.TabIndex = 51
        Me.pic_search_impuestos.TabStop = False
        '
        'add_itemImpuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 209)
        Me.Controls.Add(Me.pic_search_impuestos)
        Me.Controls.Add(Me.pic_search_item)
        Me.Controls.Add(Me.cmb_impuestos)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.cmb_items)
        Me.Controls.Add(Me.lbl_impuesto)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_item)
        Me.Name = "add_itemImpuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Relacionar Item - Impuestos"
        CType(Me.pic_search_item, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_search_impuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_items As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_impuesto As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents cmb_impuestos As System.Windows.Forms.ComboBox
    Friend WithEvents pic_search_item As System.Windows.Forms.PictureBox
    Friend WithEvents pic_search_impuestos As System.Windows.Forms.PictureBox
End Class
