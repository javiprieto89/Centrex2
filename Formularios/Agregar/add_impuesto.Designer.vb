<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_impuesto
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
        Me.txt_porcentaje = New System.Windows.Forms.TextBox()
        Me.lbl_porcentaje = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.chk_esRetencion = New System.Windows.Forms.CheckBox()
        Me.chk_esPercepcion = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txt_porcentaje
        '
        Me.txt_porcentaje.Location = New System.Drawing.Point(98, 67)
        Me.txt_porcentaje.Name = "txt_porcentaje"
        Me.txt_porcentaje.Size = New System.Drawing.Size(259, 20)
        Me.txt_porcentaje.TabIndex = 1
        '
        'lbl_porcentaje
        '
        Me.lbl_porcentaje.AutoSize = True
        Me.lbl_porcentaje.Location = New System.Drawing.Point(20, 74)
        Me.lbl_porcentaje.Name = "lbl_porcentaje"
        Me.lbl_porcentaje.Size = New System.Drawing.Size(75, 13)
        Me.lbl_porcentaje.TabIndex = 20
        Me.lbl_porcentaje.Text = "Porcentaje (%)"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(23, 166)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(101, 17)
        Me.chk_activo.TabIndex = 4
        Me.chk_activo.Text = "Impuesto activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(98, 29)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(259, 20)
        Me.txt_nombre.TabIndex = 0
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(23, 198)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 5
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(201, 246)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 7
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(103, 246)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 6
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Location = New System.Drawing.Point(20, 32)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(50, 13)
        Me.lbl_nombre.TabIndex = 19
        Me.lbl_nombre.Text = "Impuesto"
        '
        'chk_esRetencion
        '
        Me.chk_esRetencion.AutoSize = True
        Me.chk_esRetencion.Location = New System.Drawing.Point(62, 122)
        Me.chk_esRetencion.Name = "chk_esRetencion"
        Me.chk_esRetencion.Size = New System.Drawing.Size(85, 17)
        Me.chk_esRetencion.TabIndex = 2
        Me.chk_esRetencion.Text = "Es retención"
        Me.chk_esRetencion.UseVisualStyleBackColor = True
        '
        'chk_esPercepcion
        '
        Me.chk_esPercepcion.AutoSize = True
        Me.chk_esPercepcion.Location = New System.Drawing.Point(214, 122)
        Me.chk_esPercepcion.Name = "chk_esPercepcion"
        Me.chk_esPercepcion.Size = New System.Drawing.Size(94, 17)
        Me.chk_esPercepcion.TabIndex = 3
        Me.chk_esPercepcion.Text = "Es percepción"
        Me.chk_esPercepcion.UseVisualStyleBackColor = True
        '
        'add_impuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 292)
        Me.Controls.Add(Me.chk_esPercepcion)
        Me.Controls.Add(Me.chk_esRetencion)
        Me.Controls.Add(Me.txt_porcentaje)
        Me.Controls.Add(Me.lbl_porcentaje)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Name = "add_impuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar impuesto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lbl_porcentaje As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents chk_esRetencion As CheckBox
    Friend WithEvents chk_esPercepcion As CheckBox
End Class
