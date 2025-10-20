<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class muestra_texto
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
        Me.txt_msg = New System.Windows.Forms.TextBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_msg
        '
        Me.txt_msg.Location = New System.Drawing.Point(42, 46)
        Me.txt_msg.Multiline = True
        Me.txt_msg.Name = "txt_msg"
        Me.txt_msg.ReadOnly = True
        Me.txt_msg.Size = New System.Drawing.Size(582, 261)
        Me.txt_msg.TabIndex = 0
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(272, 370)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(123, 34)
        Me.cmd_ok.TabIndex = 1
        Me.cmd_ok.Text = "Cerrar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'muestra_texto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 450)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_msg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "muestra_texto"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_msg As TextBox
    Friend WithEvents cmd_ok As Button
End Class
