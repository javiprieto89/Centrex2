<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_consulta
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
        Me.txt_consulta = New System.Windows.Forms.TextBox()
        Me.lbl_consulta = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'txt_consulta
        '
        Me.txt_consulta.Location = New System.Drawing.Point(22, 86)
        Me.txt_consulta.Multiline = true
        Me.txt_consulta.Name = "txt_consulta"
        Me.txt_consulta.Size = New System.Drawing.Size(983, 493)
        Me.txt_consulta.TabIndex = 22
        '
        'lbl_consulta
        '
        Me.lbl_consulta.AutoSize = true
        Me.lbl_consulta.Location = New System.Drawing.Point(19, 57)
        Me.lbl_consulta.Name = "lbl_consulta"
        Me.lbl_consulta.Size = New System.Drawing.Size(72, 13)
        Me.lbl_consulta.TabIndex = 28
        Me.lbl_consulta.Text = "Consulta SQL"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = true
        Me.chk_activo.Location = New System.Drawing.Point(22, 596)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(99, 17)
        Me.chk_activo.TabIndex = 23
        Me.chk_activo.Text = "Consulta activa"
        Me.chk_activo.UseVisualStyleBackColor = true
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(149, 21)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(856, 20)
        Me.txt_nombre.TabIndex = 21
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = true
        Me.chk_secuencia.Location = New System.Drawing.Point(22, 628)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 24
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = true
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(531, 655)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 26
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = true
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(433, 655)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 25
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = true
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = true
        Me.lbl_nombre.Location = New System.Drawing.Point(19, 24)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(113, 13)
        Me.lbl_nombre.TabIndex = 27
        Me.lbl_nombre.Text = "Nombre de la consulta"
        '
        'add_consulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 698)
        Me.Controls.Add(Me.txt_consulta)
        Me.Controls.Add(Me.lbl_consulta)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Name = "add_consulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar consulta personalizada"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txt_consulta As System.Windows.Forms.TextBox
    Friend WithEvents lbl_consulta As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
End Class
