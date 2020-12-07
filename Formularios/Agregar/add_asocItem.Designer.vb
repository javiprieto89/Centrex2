<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_asocItem
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
        Me.txt_descriptItem = New System.Windows.Forms.TextBox()
        Me.txt_descriptAsocItem = New System.Windows.Forms.TextBox()
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.lbl_asocItem = New System.Windows.Forms.Label()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.pic_searchItem = New System.Windows.Forms.PictureBox()
        Me.pic_searchAsocItem = New System.Windows.Forms.PictureBox()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.txt_asocItem = New System.Windows.Forms.TextBox()
        Me.txt_item = New System.Windows.Forms.TextBox()
        CType(Me.pic_searchItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchAsocItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_descriptItem
        '
        Me.txt_descriptItem.BackColor = System.Drawing.SystemColors.Window
        Me.txt_descriptItem.Location = New System.Drawing.Point(170, 54)
        Me.txt_descriptItem.Name = "txt_descriptItem"
        Me.txt_descriptItem.ReadOnly = True
        Me.txt_descriptItem.Size = New System.Drawing.Size(489, 20)
        Me.txt_descriptItem.TabIndex = 1
        '
        'txt_descriptAsocItem
        '
        Me.txt_descriptAsocItem.BackColor = System.Drawing.SystemColors.Window
        Me.txt_descriptAsocItem.Location = New System.Drawing.Point(170, 126)
        Me.txt_descriptAsocItem.Name = "txt_descriptAsocItem"
        Me.txt_descriptAsocItem.ReadOnly = True
        Me.txt_descriptAsocItem.Size = New System.Drawing.Size(489, 20)
        Me.txt_descriptAsocItem.TabIndex = 3
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(31, 27)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(50, 13)
        Me.lbl_item.TabIndex = 2
        Me.lbl_item.Text = "Producto"
        '
        'lbl_asocItem
        '
        Me.lbl_asocItem.AutoSize = True
        Me.lbl_asocItem.Location = New System.Drawing.Point(31, 99)
        Me.lbl_asocItem.Name = "lbl_asocItem"
        Me.lbl_asocItem.Size = New System.Drawing.Size(96, 13)
        Me.lbl_asocItem.TabIndex = 3
        Me.lbl_asocItem.Text = "Producto asociado"
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(248, 247)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(218, 47)
        Me.cmd_ok.TabIndex = 5
        Me.cmd_ok.Text = "Asociar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Checked = True
        Me.chk_secuencia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_secuencia.Location = New System.Drawing.Point(34, 327)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 6
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'pic_searchItem
        '
        Me.pic_searchItem.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchItem.Location = New System.Drawing.Point(677, 52)
        Me.pic_searchItem.Name = "pic_searchItem"
        Me.pic_searchItem.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchItem.TabIndex = 49
        Me.pic_searchItem.TabStop = False
        '
        'pic_searchAsocItem
        '
        Me.pic_searchAsocItem.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchAsocItem.Location = New System.Drawing.Point(677, 126)
        Me.pic_searchAsocItem.Name = "pic_searchAsocItem"
        Me.pic_searchAsocItem.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchAsocItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchAsocItem.TabIndex = 50
        Me.pic_searchAsocItem.TabStop = False
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(31, 175)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 52
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'txt_cantidad
        '
        Me.txt_cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.txt_cantidad.Location = New System.Drawing.Point(34, 205)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(61, 20)
        Me.txt_cantidad.TabIndex = 4
        '
        'txt_asocItem
        '
        Me.txt_asocItem.BackColor = System.Drawing.SystemColors.Window
        Me.txt_asocItem.Location = New System.Drawing.Point(26, 126)
        Me.txt_asocItem.Name = "txt_asocItem"
        Me.txt_asocItem.ReadOnly = True
        Me.txt_asocItem.Size = New System.Drawing.Size(116, 20)
        Me.txt_asocItem.TabIndex = 2
        '
        'txt_item
        '
        Me.txt_item.BackColor = System.Drawing.SystemColors.Window
        Me.txt_item.Location = New System.Drawing.Point(26, 54)
        Me.txt_item.Name = "txt_item"
        Me.txt_item.ReadOnly = True
        Me.txt_item.Size = New System.Drawing.Size(116, 20)
        Me.txt_item.TabIndex = 0
        '
        'add_asocItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 354)
        Me.Controls.Add(Me.txt_item)
        Me.Controls.Add(Me.txt_asocItem)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.pic_searchAsocItem)
        Me.Controls.Add(Me.pic_searchItem)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_asocItem)
        Me.Controls.Add(Me.lbl_item)
        Me.Controls.Add(Me.txt_descriptAsocItem)
        Me.Controls.Add(Me.txt_descriptItem)
        Me.Name = "add_asocItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asociar productos"
        CType(Me.pic_searchItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchAsocItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_descriptItem As TextBox
    Friend WithEvents txt_descriptAsocItem As TextBox
    Friend WithEvents lbl_item As Label
    Friend WithEvents lbl_asocItem As Label
    Friend WithEvents cmd_ok As Button
    Friend WithEvents chk_secuencia As CheckBox
    Friend WithEvents pic_searchItem As PictureBox
    Friend WithEvents pic_searchAsocItem As PictureBox
    Friend WithEvents lbl_cantidad As Label
    Friend WithEvents txt_cantidad As TextBox
    Friend WithEvents txt_asocItem As TextBox
    Friend WithEvents txt_item As TextBox
End Class
