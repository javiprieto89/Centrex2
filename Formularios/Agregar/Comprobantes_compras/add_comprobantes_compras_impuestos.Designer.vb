<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_comprobantes_compras_impuestos
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
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.lbl_importe = New System.Windows.Forms.Label()
        Me.txt_importe = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_impuesto = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblImpuesto
        '
        Me.lblImpuesto.AutoSize = True
        Me.lblImpuesto.Location = New System.Drawing.Point(47, 26)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(50, 13)
        Me.lblImpuesto.TabIndex = 0
        Me.lblImpuesto.Text = "Impuesto"
        '
        'lbl_importe
        '
        Me.lbl_importe.AutoSize = True
        Me.lbl_importe.Location = New System.Drawing.Point(47, 82)
        Me.lbl_importe.Name = "lbl_importe"
        Me.lbl_importe.Size = New System.Drawing.Size(42, 13)
        Me.lbl_importe.TabIndex = 2
        Me.lbl_importe.Text = "Importe"
        '
        'txt_importe
        '
        Me.txt_importe.Location = New System.Drawing.Point(113, 79)
        Me.txt_importe.Name = "txt_importe"
        Me.txt_importe.Size = New System.Drawing.Size(100, 20)
        Me.txt_importe.TabIndex = 3
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(152, 159)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(54, 159)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_impuesto
        '
        Me.lbl_impuesto.AutoSize = True
        Me.lbl_impuesto.Location = New System.Drawing.Point(113, 26)
        Me.lbl_impuesto.Name = "lbl_impuesto"
        Me.lbl_impuesto.Size = New System.Drawing.Size(65, 13)
        Me.lbl_impuesto.TabIndex = 1
        Me.lbl_impuesto.Text = "%impuesto%"
        '
        'add_comprobantes_compras_impuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(281, 207)
        Me.Controls.Add(Me.lbl_impuesto)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_importe)
        Me.Controls.Add(Me.lbl_importe)
        Me.Controls.Add(Me.lblImpuesto)
        Me.Name = "add_comprobantes_compras_impuestos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar impuesto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblImpuesto As Label
    Friend WithEvents lbl_importe As Label
    Friend WithEvents txt_importe As TextBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents lbl_impuesto As Label
End Class
