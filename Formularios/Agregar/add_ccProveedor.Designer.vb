<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_ccProveedor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_cc = New System.Windows.Forms.Label()
        Me.txt_saldo = New System.Windows.Forms.TextBox()
        Me.lbl_saldo = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.pic_searchProveedor = New System.Windows.Forms.PictureBox()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.cmb_moneda = New System.Windows.Forms.ComboBox()
        Me.lbl_moneda = New System.Windows.Forms.Label()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(23, 206)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(72, 17)
        Me.chk_activo.TabIndex = 3
        Me.chk_activo.Text = "CC activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(76, 112)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(259, 20)
        Me.txt_nombre.TabIndex = 1
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(23, 238)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 4
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(191, 274)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 6
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(93, 274)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 5
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_cc
        '
        Me.lbl_cc.AutoSize = True
        Me.lbl_cc.Location = New System.Drawing.Point(20, 117)
        Me.lbl_cc.Name = "lbl_cc"
        Me.lbl_cc.Size = New System.Drawing.Size(44, 13)
        Me.lbl_cc.TabIndex = 6
        Me.lbl_cc.Text = "Nombre"
        '
        'txt_saldo
        '
        Me.txt_saldo.Location = New System.Drawing.Point(76, 150)
        Me.txt_saldo.Name = "txt_saldo"
        Me.txt_saldo.Size = New System.Drawing.Size(259, 20)
        Me.txt_saldo.TabIndex = 2
        '
        'lbl_saldo
        '
        Me.lbl_saldo.AutoSize = True
        Me.lbl_saldo.Location = New System.Drawing.Point(20, 158)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.Size = New System.Drawing.Size(34, 13)
        Me.lbl_saldo.TabIndex = 12
        Me.lbl_saldo.Text = "Saldo"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(76, 22)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(259, 21)
        Me.cmb_proveedor.TabIndex = 0
        '
        'pic_searchProveedor
        '
        Me.pic_searchProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchProveedor.Location = New System.Drawing.Point(353, 22)
        Me.pic_searchProveedor.Name = "pic_searchProveedor"
        Me.pic_searchProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchProveedor.TabIndex = 637
        Me.pic_searchProveedor.TabStop = False
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(20, 25)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 636
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'cmb_moneda
        '
        Me.cmb_moneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_moneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_moneda.FormattingEnabled = True
        Me.cmb_moneda.Location = New System.Drawing.Point(76, 66)
        Me.cmb_moneda.Name = "cmb_moneda"
        Me.cmb_moneda.Size = New System.Drawing.Size(259, 21)
        Me.cmb_moneda.TabIndex = 638
        '
        'lbl_moneda
        '
        Me.lbl_moneda.AutoSize = True
        Me.lbl_moneda.Location = New System.Drawing.Point(20, 69)
        Me.lbl_moneda.Name = "lbl_moneda"
        Me.lbl_moneda.Size = New System.Drawing.Size(46, 13)
        Me.lbl_moneda.TabIndex = 639
        Me.lbl_moneda.Text = "Moneda"
        '
        'add_ccProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 320)
        Me.Controls.Add(Me.cmb_moneda)
        Me.Controls.Add(Me.lbl_moneda)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.pic_searchProveedor)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.txt_saldo)
        Me.Controls.Add(Me.lbl_saldo)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_cc)
        Me.Name = "add_ccProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar cuenta corriente a cliente"
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chk_activo As CheckBox
    Friend WithEvents txt_nombre As TextBox
    Friend WithEvents chk_secuencia As CheckBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents lbl_cc As Label
    Friend WithEvents txt_saldo As TextBox
    Friend WithEvents lbl_saldo As Label
    Friend WithEvents cmb_proveedor As ComboBox
    Friend WithEvents pic_searchProveedor As PictureBox
    Friend WithEvents lbl_proveedor As Label
    Friend WithEvents cmb_moneda As ComboBox
    Friend WithEvents lbl_moneda As Label
End Class
