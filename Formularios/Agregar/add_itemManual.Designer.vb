<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_itemManual
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
        Me.lbl_item = New System.Windows.Forms.Label()
        Me.txt_item = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_precio = New System.Windows.Forms.TextBox()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.lbl_precio = New System.Windows.Forms.Label()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.tt_noGuarda = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Location = New System.Drawing.Point(22, 31)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(64, 13)
        Me.lbl_item.TabIndex = 0
        Me.lbl_item.Text = "Item manual"
        '
        'txt_item
        '
        Me.txt_item.Location = New System.Drawing.Point(108, 24)
        Me.txt_item.MaxLength = 54
        Me.txt_item.Name = "txt_item"
        Me.txt_item.Size = New System.Drawing.Size(307, 20)
        Me.txt_item.TabIndex = 1
        Me.tt_noGuarda.SetToolTip(Me.txt_item, "RECUERDE: Este item estará solamente asociado a este pedido y no se guardará como" &
        " un item más por lo cual no podrá volver a encontrarlo")
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(231, 179)
        Me.cmd_exit.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(70, 21)
        Me.cmd_exit.TabIndex = 9
        Me.cmd_exit.Text = "Cancelar"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(135, 179)
        Me.cmd_ok.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(70, 21)
        Me.cmd_ok.TabIndex = 7
        Me.cmd_ok.Text = "Aceptar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_precio
        '
        Me.txt_precio.Location = New System.Drawing.Point(236, 126)
        Me.txt_precio.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.Size = New System.Drawing.Size(88, 20)
        Me.txt_precio.TabIndex = 5
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Location = New System.Drawing.Point(115, 126)
        Me.txt_cantidad.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(88, 20)
        Me.txt_cantidad.TabIndex = 4
        '
        'lbl_precio
        '
        Me.lbl_precio.AutoSize = True
        Me.lbl_precio.Location = New System.Drawing.Point(234, 94)
        Me.lbl_precio.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_precio.Name = "lbl_precio"
        Me.lbl_precio.Size = New System.Drawing.Size(37, 13)
        Me.lbl_precio.TabIndex = 8
        Me.lbl_precio.Text = "Precio"
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(113, 94)
        Me.lbl_cantidad.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(49, 13)
        Me.lbl_cantidad.TabIndex = 6
        Me.lbl_cantidad.Text = "Cantidad"
        '
        'tt_noGuarda
        '
        Me.tt_noGuarda.Tag = ""
        '
        'add_itemManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 224)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_precio)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.lbl_precio)
        Me.Controls.Add(Me.lbl_cantidad)
        Me.Controls.Add(Me.txt_item)
        Me.Controls.Add(Me.lbl_item)
        Me.Name = "add_itemManual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar item manual"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_item As Label
    Friend WithEvents txt_item As TextBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents txt_precio As TextBox
    Friend WithEvents txt_cantidad As TextBox
    Friend WithEvents lbl_precio As Label
    Friend WithEvents lbl_cantidad As Label
    Friend WithEvents tt_noGuarda As ToolTip
End Class
