<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_error_detalle
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txt_mensaje = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_detalles = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_copiar = New System.Windows.Forms.Button()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_mensaje
        '
        Me.txt_mensaje.Location = New System.Drawing.Point(12, 30)
        Me.txt_mensaje.Multiline = True
        Me.txt_mensaje.Name = "txt_mensaje"
        Me.txt_mensaje.ReadOnly = True
        Me.txt_mensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_mensaje.Size = New System.Drawing.Size(760, 60)
        Me.txt_mensaje.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mensaje:"
        '
        'txt_detalles
        '
        Me.txt_detalles.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_detalles.Location = New System.Drawing.Point(12, 120)
        Me.txt_detalles.Multiline = True
        Me.txt_detalles.Name = "txt_detalles"
        Me.txt_detalles.ReadOnly = True
        Me.txt_detalles.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_detalles.Size = New System.Drawing.Size(760, 400)
        Me.txt_detalles.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Detalles:"
        '
        'btn_copiar
        '
        Me.btn_copiar.Location = New System.Drawing.Point(616, 540)
        Me.btn_copiar.Name = "btn_copiar"
        Me.btn_copiar.Size = New System.Drawing.Size(75, 30)
        Me.btn_copiar.TabIndex = 4
        Me.btn_copiar.Text = "Copiar"
        Me.btn_copiar.UseVisualStyleBackColor = True
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Location = New System.Drawing.Point(697, 540)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(75, 30)
        Me.btn_cerrar.TabIndex = 5
        Me.btn_cerrar.Text = "Cerrar"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'frm_error_detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 581)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.btn_copiar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_detalles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_mensaje)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_error_detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle del Error"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_mensaje As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_detalles As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_copiar As Button
    Friend WithEvents btn_cerrar As Button
End Class
