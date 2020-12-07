<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_condicion_compra
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
        Me.txt_recargo = New System.Windows.Forms.TextBox()
        Me.lbl_recargo = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_condicion = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_condicion = New System.Windows.Forms.Label()
        Me.txt_vencimiento = New System.Windows.Forms.TextBox()
        Me.lbl_vencimiento = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_recargo
        '
        Me.txt_recargo.Location = New System.Drawing.Point(174, 100)
        Me.txt_recargo.Name = "txt_recargo"
        Me.txt_recargo.Size = New System.Drawing.Size(259, 20)
        Me.txt_recargo.TabIndex = 2
        '
        'lbl_recargo
        '
        Me.lbl_recargo.AutoSize = True
        Me.lbl_recargo.Location = New System.Drawing.Point(20, 104)
        Me.lbl_recargo.Name = "lbl_recargo"
        Me.lbl_recargo.Size = New System.Drawing.Size(65, 13)
        Me.lbl_recargo.TabIndex = 20
        Me.lbl_recargo.Text = "Recargo (%)"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(23, 145)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(105, 17)
        Me.chk_activo.TabIndex = 3
        Me.chk_activo.Text = "Condición activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_condicion
        '
        Me.txt_condicion.Location = New System.Drawing.Point(174, 36)
        Me.txt_condicion.Name = "txt_condicion"
        Me.txt_condicion.Size = New System.Drawing.Size(259, 20)
        Me.txt_condicion.TabIndex = 0
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(23, 177)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 4
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(247, 220)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 6
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(149, 220)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 5
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_condicion
        '
        Me.lbl_condicion.AutoSize = True
        Me.lbl_condicion.Location = New System.Drawing.Point(20, 36)
        Me.lbl_condicion.Name = "lbl_condicion"
        Me.lbl_condicion.Size = New System.Drawing.Size(54, 13)
        Me.lbl_condicion.TabIndex = 14
        Me.lbl_condicion.Text = "Condición"
        '
        'txt_vencimiento
        '
        Me.txt_vencimiento.Location = New System.Drawing.Point(174, 68)
        Me.txt_vencimiento.Name = "txt_vencimiento"
        Me.txt_vencimiento.Size = New System.Drawing.Size(259, 20)
        Me.txt_vencimiento.TabIndex = 1
        '
        'lbl_vencimiento
        '
        Me.lbl_vencimiento.AutoSize = True
        Me.lbl_vencimiento.Location = New System.Drawing.Point(20, 70)
        Me.lbl_vencimiento.Name = "lbl_vencimiento"
        Me.lbl_vencimiento.Size = New System.Drawing.Size(95, 13)
        Me.lbl_vencimiento.TabIndex = 22
        Me.lbl_vencimiento.Text = "Vencimiento (días)"
        '
        'add_condicion_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 264)
        Me.Controls.Add(Me.txt_vencimiento)
        Me.Controls.Add(Me.lbl_vencimiento)
        Me.Controls.Add(Me.txt_recargo)
        Me.Controls.Add(Me.lbl_recargo)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_condicion)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_condicion)
        Me.Name = "add_condicion_compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar condición de compra"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_recargo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_recargo As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_condicion As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_condicion As System.Windows.Forms.Label
    Friend WithEvents txt_vencimiento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_vencimiento As System.Windows.Forms.Label
End Class
