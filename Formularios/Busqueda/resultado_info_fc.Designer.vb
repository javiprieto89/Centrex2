<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class resultado_info_fc
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
        Me.lbl_cae = New System.Windows.Forms.Label()
        Me.txt_cae = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_subtotal = New System.Windows.Forms.TextBox()
        Me.lbl_subtotal = New System.Windows.Forms.Label()
        Me.txt_impuestos = New System.Windows.Forms.TextBox()
        Me.lbl_impuestos = New System.Windows.Forms.Label()
        Me.txt_CUIT = New System.Windows.Forms.TextBox()
        Me.lbl_CUIT = New System.Windows.Forms.Label()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_cae
        '
        Me.lbl_cae.AutoSize = True
        Me.lbl_cae.Location = New System.Drawing.Point(41, 133)
        Me.lbl_cae.Name = "lbl_cae"
        Me.lbl_cae.Size = New System.Drawing.Size(28, 13)
        Me.lbl_cae.TabIndex = 0
        Me.lbl_cae.Text = "CAE"
        '
        'txt_cae
        '
        Me.txt_cae.Location = New System.Drawing.Point(134, 128)
        Me.txt_cae.Name = "txt_cae"
        Me.txt_cae.ReadOnly = True
        Me.txt_cae.Size = New System.Drawing.Size(176, 20)
        Me.txt_cae.TabIndex = 1
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(134, 254)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(176, 20)
        Me.txt_total.TabIndex = 3
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Location = New System.Drawing.Point(41, 262)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(31, 13)
        Me.lbl_total.TabIndex = 2
        Me.lbl_total.Text = "Total"
        '
        'txt_subtotal
        '
        Me.txt_subtotal.Location = New System.Drawing.Point(134, 170)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.ReadOnly = True
        Me.txt_subtotal.Size = New System.Drawing.Size(176, 20)
        Me.txt_subtotal.TabIndex = 5
        '
        'lbl_subtotal
        '
        Me.lbl_subtotal.AutoSize = True
        Me.lbl_subtotal.Location = New System.Drawing.Point(41, 176)
        Me.lbl_subtotal.Name = "lbl_subtotal"
        Me.lbl_subtotal.Size = New System.Drawing.Size(46, 13)
        Me.lbl_subtotal.TabIndex = 4
        Me.lbl_subtotal.Text = "Subtotal"
        '
        'txt_impuestos
        '
        Me.txt_impuestos.Location = New System.Drawing.Point(134, 212)
        Me.txt_impuestos.Name = "txt_impuestos"
        Me.txt_impuestos.ReadOnly = True
        Me.txt_impuestos.Size = New System.Drawing.Size(176, 20)
        Me.txt_impuestos.TabIndex = 7
        '
        'lbl_impuestos
        '
        Me.lbl_impuestos.AutoSize = True
        Me.lbl_impuestos.Location = New System.Drawing.Point(41, 219)
        Me.lbl_impuestos.Name = "lbl_impuestos"
        Me.lbl_impuestos.Size = New System.Drawing.Size(55, 13)
        Me.lbl_impuestos.TabIndex = 6
        Me.lbl_impuestos.Text = "Impuestos"
        '
        'txt_CUIT
        '
        Me.txt_CUIT.Location = New System.Drawing.Point(134, 86)
        Me.txt_CUIT.Name = "txt_CUIT"
        Me.txt_CUIT.ReadOnly = True
        Me.txt_CUIT.Size = New System.Drawing.Size(176, 20)
        Me.txt_CUIT.TabIndex = 9
        '
        'lbl_CUIT
        '
        Me.lbl_CUIT.AutoSize = True
        Me.lbl_CUIT.Location = New System.Drawing.Point(41, 90)
        Me.lbl_CUIT.Name = "lbl_CUIT"
        Me.lbl_CUIT.Size = New System.Drawing.Size(32, 13)
        Me.lbl_CUIT.TabIndex = 8
        Me.lbl_CUIT.Text = "CUIT"
        '
        'txt_cliente
        '
        Me.txt_cliente.Location = New System.Drawing.Point(134, 44)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(176, 20)
        Me.txt_cliente.TabIndex = 11
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Location = New System.Drawing.Point(41, 47)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lbl_cliente.TabIndex = 10
        Me.lbl_cliente.Text = "Cliente"
        '
        'resultado_info_fc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 334)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.txt_CUIT)
        Me.Controls.Add(Me.lbl_CUIT)
        Me.Controls.Add(Me.txt_impuestos)
        Me.Controls.Add(Me.lbl_impuestos)
        Me.Controls.Add(Me.txt_subtotal)
        Me.Controls.Add(Me.lbl_subtotal)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.txt_cae)
        Me.Controls.Add(Me.lbl_cae)
        Me.Name = "resultado_info_fc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información del comprobante"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_cae As Label
    Friend WithEvents txt_cae As TextBox
    Friend WithEvents txt_total As TextBox
    Friend WithEvents lbl_total As Label
    Friend WithEvents txt_subtotal As TextBox
    Friend WithEvents lbl_subtotal As Label
    Friend WithEvents txt_impuestos As TextBox
    Friend WithEvents lbl_impuestos As Label
    Friend WithEvents txt_CUIT As TextBox
    Friend WithEvents lbl_CUIT As Label
    Friend WithEvents txt_cliente As TextBox
    Friend WithEvents lbl_cliente As Label
End Class
