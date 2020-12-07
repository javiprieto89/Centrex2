<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_cobroRetencion
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
        Me.lbl_importe = New System.Windows.Forms.Label()
        Me.lbl_retencion = New System.Windows.Forms.Label()
        Me.psearch_retencion = New System.Windows.Forms.PictureBox()
        Me.cmb_retencion = New System.Windows.Forms.ComboBox()
        Me.txt_importe = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_agregarImpuesto = New System.Windows.Forms.Button()
        CType(Me.psearch_retencion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_importe
        '
        Me.lbl_importe.AutoSize = True
        Me.lbl_importe.Location = New System.Drawing.Point(23, 106)
        Me.lbl_importe.Name = "lbl_importe"
        Me.lbl_importe.Size = New System.Drawing.Size(42, 13)
        Me.lbl_importe.TabIndex = 1
        Me.lbl_importe.Text = "Importe"
        '
        'lbl_retencion
        '
        Me.lbl_retencion.AutoSize = True
        Me.lbl_retencion.Location = New System.Drawing.Point(23, 33)
        Me.lbl_retencion.Name = "lbl_retencion"
        Me.lbl_retencion.Size = New System.Drawing.Size(56, 13)
        Me.lbl_retencion.TabIndex = 3
        Me.lbl_retencion.Text = "Retención"
        '
        'psearch_retencion
        '
        Me.psearch_retencion.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_retencion.Location = New System.Drawing.Point(448, 25)
        Me.psearch_retencion.Name = "psearch_retencion"
        Me.psearch_retencion.Size = New System.Drawing.Size(22, 22)
        Me.psearch_retencion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_retencion.TabIndex = 29
        Me.psearch_retencion.TabStop = False
        '
        'cmb_retencion
        '
        Me.cmb_retencion.FormattingEnabled = True
        Me.cmb_retencion.Location = New System.Drawing.Point(90, 25)
        Me.cmb_retencion.Name = "cmb_retencion"
        Me.cmb_retencion.Size = New System.Drawing.Size(352, 21)
        Me.cmb_retencion.TabIndex = 0
        '
        'txt_importe
        '
        Me.txt_importe.Location = New System.Drawing.Point(90, 103)
        Me.txt_importe.Name = "txt_importe"
        Me.txt_importe.Size = New System.Drawing.Size(104, 20)
        Me.txt_importe.TabIndex = 1
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(23, 179)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 8
        Me.lbl_notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(90, 180)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(352, 97)
        Me.txt_notas.TabIndex = 2
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(256, 336)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 4
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(158, 336)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_agregarImpuesto
        '
        Me.cmd_agregarImpuesto.Location = New System.Drawing.Point(90, 52)
        Me.cmd_agregarImpuesto.Name = "cmd_agregarImpuesto"
        Me.cmd_agregarImpuesto.Size = New System.Drawing.Size(181, 23)
        Me.cmd_agregarImpuesto.TabIndex = 30
        Me.cmd_agregarImpuesto.Text = "Agregar retención en impuestos"
        Me.cmd_agregarImpuesto.UseVisualStyleBackColor = True
        '
        'add_cobroRetencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 384)
        Me.Controls.Add(Me.cmd_agregarImpuesto)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.txt_importe)
        Me.Controls.Add(Me.psearch_retencion)
        Me.Controls.Add(Me.cmb_retencion)
        Me.Controls.Add(Me.lbl_retencion)
        Me.Controls.Add(Me.lbl_importe)
        Me.Name = "add_cobroRetencion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingresar transferencia"
        CType(Me.psearch_retencion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_importe As Label
    Friend WithEvents lbl_retencion As Label
    Friend WithEvents psearch_retencion As PictureBox
    Friend WithEvents cmb_retencion As ComboBox
    Friend WithEvents txt_importe As TextBox
    Friend WithEvents lbl_notas As Label
    Friend WithEvents txt_notas As TextBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents cmd_agregarImpuesto As Button
End Class
