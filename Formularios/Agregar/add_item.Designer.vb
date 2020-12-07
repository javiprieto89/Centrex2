<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_item
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
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.txt_item = New System.Windows.Forms.TextBox()
        Me.txt_desc = New System.Windows.Forms.TextBox()
        Me.lbl_desc = New System.Windows.Forms.Label()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.lbl_costo = New System.Windows.Forms.Label()
        Me.txt_prclista = New System.Windows.Forms.TextBox()
        Me.lbl_preciolista = New System.Windows.Forms.Label()
        Me.lbl_categoria = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmb_cat = New System.Windows.Forms.ComboBox()
        Me.cmb_marca = New System.Windows.Forms.ComboBox()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_factor = New System.Windows.Forms.TextBox()
        Me.lbl_factor = New System.Windows.Forms.Label()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.chk_descuento = New System.Windows.Forms.CheckBox()
        Me.psearch_proveedor = New System.Windows.Forms.PictureBox()
        Me.psearch_marca = New System.Windows.Forms.PictureBox()
        Me.psearch_tipo = New System.Windows.Forms.PictureBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.pic_search_iva = New System.Windows.Forms.PictureBox()
        Me.cmb_iva = New System.Windows.Forms.ComboBox()
        Me.lbl_iva = New System.Windows.Forms.Label()
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_marca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_tipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_search_iva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(29, 65)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(40, 13)
        Me.lbl_item.TabIndex = 0
        Me.lbl_item.Text = "Código"
        '
        'txt_item
        '
        Me.txt_item.Location = New System.Drawing.Point(128, 61)
        Me.txt_item.Name = "txt_item"
        Me.txt_item.Size = New System.Drawing.Size(259, 20)
        Me.txt_item.TabIndex = 0
        '
        'txt_desc
        '
        Me.txt_desc.Location = New System.Drawing.Point(128, 101)
        Me.txt_desc.MaxLength = 54
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.Size = New System.Drawing.Size(259, 20)
        Me.txt_desc.TabIndex = 1
        '
        'lbl_desc
        '
        Me.lbl_desc.AutoSize = True
        Me.lbl_desc.Location = New System.Drawing.Point(29, 105)
        Me.lbl_desc.Name = "lbl_desc"
        Me.lbl_desc.Size = New System.Drawing.Size(50, 13)
        Me.lbl_desc.TabIndex = 2
        Me.lbl_desc.Text = "Producto"
        '
        'txt_costo
        '
        Me.txt_costo.Location = New System.Drawing.Point(128, 141)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(259, 20)
        Me.txt_costo.TabIndex = 2
        '
        'lbl_costo
        '
        Me.lbl_costo.AutoSize = True
        Me.lbl_costo.Location = New System.Drawing.Point(29, 145)
        Me.lbl_costo.Name = "lbl_costo"
        Me.lbl_costo.Size = New System.Drawing.Size(34, 13)
        Me.lbl_costo.TabIndex = 4
        Me.lbl_costo.Text = "Costo"
        '
        'txt_prclista
        '
        Me.txt_prclista.Location = New System.Drawing.Point(128, 221)
        Me.txt_prclista.Name = "txt_prclista"
        Me.txt_prclista.Size = New System.Drawing.Size(259, 20)
        Me.txt_prclista.TabIndex = 4
        '
        'lbl_preciolista
        '
        Me.lbl_preciolista.AutoSize = True
        Me.lbl_preciolista.Location = New System.Drawing.Point(26, 225)
        Me.lbl_preciolista.Name = "lbl_preciolista"
        Me.lbl_preciolista.Size = New System.Drawing.Size(73, 13)
        Me.lbl_preciolista.TabIndex = 6
        Me.lbl_preciolista.Text = "Precio de lista"
        '
        'lbl_categoria
        '
        Me.lbl_categoria.AutoSize = True
        Me.lbl_categoria.Location = New System.Drawing.Point(26, 265)
        Me.lbl_categoria.Name = "lbl_categoria"
        Me.lbl_categoria.Size = New System.Drawing.Size(54, 13)
        Me.lbl_categoria.TabIndex = 8
        Me.lbl_categoria.Text = "Categoría"
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(227, 569)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 14
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(28, 525)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 12
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmb_cat
        '
        Me.cmb_cat.FormattingEnabled = True
        Me.cmb_cat.Location = New System.Drawing.Point(128, 261)
        Me.cmb_cat.Name = "cmb_cat"
        Me.cmb_cat.Size = New System.Drawing.Size(259, 21)
        Me.cmb_cat.TabIndex = 5
        '
        'cmb_marca
        '
        Me.cmb_marca.FormattingEnabled = True
        Me.cmb_marca.Location = New System.Drawing.Point(128, 302)
        Me.cmb_marca.Name = "cmb_marca"
        Me.cmb_marca.Size = New System.Drawing.Size(259, 21)
        Me.cmb_marca.TabIndex = 6
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Location = New System.Drawing.Point(26, 305)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(37, 13)
        Me.lbl_marca.TabIndex = 14
        Me.lbl_marca.Text = "Marca"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(128, 343)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(259, 21)
        Me.cmb_proveedor.TabIndex = 7
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(27, 345)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 16
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(28, 478)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(78, 17)
        Me.chk_activo.TabIndex = 11
        Me.chk_activo.Text = "Item activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_factor
        '
        Me.txt_factor.Location = New System.Drawing.Point(128, 181)
        Me.txt_factor.Name = "txt_factor"
        Me.txt_factor.Size = New System.Drawing.Size(259, 20)
        Me.txt_factor.TabIndex = 3
        '
        'lbl_factor
        '
        Me.lbl_factor.AutoSize = True
        Me.lbl_factor.Location = New System.Drawing.Point(26, 185)
        Me.lbl_factor.Name = "lbl_factor"
        Me.lbl_factor.Size = New System.Drawing.Size(37, 13)
        Me.lbl_factor.TabIndex = 41
        Me.lbl_factor.Text = "Factor"
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(25, 385)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 50
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(127, 384)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(259, 20)
        Me.txt_cantidad.TabIndex = 8
        Me.txt_cantidad.Text = "1000000"
        '
        'chk_descuento
        '
        Me.chk_descuento.AutoSize = True
        Me.chk_descuento.Location = New System.Drawing.Point(32, 21)
        Me.chk_descuento.Name = "chk_descuento"
        Me.chk_descuento.Size = New System.Drawing.Size(106, 17)
        Me.chk_descuento.TabIndex = 9
        Me.chk_descuento.Text = "Es un descuento"
        Me.chk_descuento.UseVisualStyleBackColor = True
        '
        'psearch_proveedor
        '
        Me.psearch_proveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_proveedor.Location = New System.Drawing.Point(393, 342)
        Me.psearch_proveedor.Name = "psearch_proveedor"
        Me.psearch_proveedor.Size = New System.Drawing.Size(22, 22)
        Me.psearch_proveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_proveedor.TabIndex = 28
        Me.psearch_proveedor.TabStop = False
        '
        'psearch_marca
        '
        Me.psearch_marca.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_marca.Location = New System.Drawing.Point(393, 298)
        Me.psearch_marca.Name = "psearch_marca"
        Me.psearch_marca.Size = New System.Drawing.Size(22, 22)
        Me.psearch_marca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_marca.TabIndex = 27
        Me.psearch_marca.TabStop = False
        '
        'psearch_tipo
        '
        Me.psearch_tipo.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_tipo.Location = New System.Drawing.Point(393, 256)
        Me.psearch_tipo.Name = "psearch_tipo"
        Me.psearch_tipo.Size = New System.Drawing.Size(22, 22)
        Me.psearch_tipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_tipo.TabIndex = 26
        Me.psearch_tipo.TabStop = False
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(127, 569)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 51
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'pic_search_iva
        '
        Me.pic_search_iva.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_search_iva.Location = New System.Drawing.Point(393, 423)
        Me.pic_search_iva.Name = "pic_search_iva"
        Me.pic_search_iva.Size = New System.Drawing.Size(22, 22)
        Me.pic_search_iva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_search_iva.TabIndex = 54
        Me.pic_search_iva.TabStop = False
        '
        'cmb_iva
        '
        Me.cmb_iva.FormattingEnabled = True
        Me.cmb_iva.Location = New System.Drawing.Point(127, 424)
        Me.cmb_iva.Name = "cmb_iva"
        Me.cmb_iva.Size = New System.Drawing.Size(259, 21)
        Me.cmb_iva.TabIndex = 52
        '
        'lbl_iva
        '
        Me.lbl_iva.AutoSize = True
        Me.lbl_iva.Location = New System.Drawing.Point(26, 425)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.Size = New System.Drawing.Size(33, 13)
        Me.lbl_iva.TabIndex = 53
        Me.lbl_iva.Text = "I.V.A."
        '
        'add_item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 619)
        Me.Controls.Add(Me.pic_search_iva)
        Me.Controls.Add(Me.cmb_iva)
        Me.Controls.Add(Me.lbl_iva)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.chk_descuento)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Controls.Add(Me.txt_factor)
        Me.Controls.Add(Me.lbl_factor)
        Me.Controls.Add(Me.psearch_proveedor)
        Me.Controls.Add(Me.psearch_marca)
        Me.Controls.Add(Me.psearch_tipo)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.cmb_marca)
        Me.Controls.Add(Me.lbl_marca)
        Me.Controls.Add(Me.cmb_cat)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.lbl_categoria)
        Me.Controls.Add(Me.txt_prclista)
        Me.Controls.Add(Me.lbl_preciolista)
        Me.Controls.Add(Me.txt_costo)
        Me.Controls.Add(Me.lbl_costo)
        Me.Controls.Add(Me.txt_desc)
        Me.Controls.Add(Me.lbl_desc)
        Me.Controls.Add(Me.txt_item)
        Me.Controls.Add(Me.lbl_item)
        Me.Name = "add_item"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar producto"
        CType(Me.psearch_proveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_marca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_tipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_search_iva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents txt_item As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_desc As System.Windows.Forms.Label
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_costo As System.Windows.Forms.Label
    Friend WithEvents txt_prclista As System.Windows.Forms.TextBox
    Friend WithEvents lbl_preciolista As System.Windows.Forms.Label
    Friend WithEvents lbl_categoria As System.Windows.Forms.Label
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_cat As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_marca As System.Windows.Forms.Label
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents psearch_tipo As System.Windows.Forms.PictureBox
    Friend WithEvents psearch_marca As System.Windows.Forms.PictureBox
    Friend WithEvents psearch_proveedor As System.Windows.Forms.PictureBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_factor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_factor As System.Windows.Forms.Label
    Friend WithEvents lbl_cantidad As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents chk_descuento As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_ok As Button
    Friend WithEvents pic_search_iva As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_iva As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_iva As System.Windows.Forms.Label
End Class
