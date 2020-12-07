<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_caja
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
        Me.lbl_caja = New System.Windows.Forms.Label()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_caja = New System.Windows.Forms.TextBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.chk_cc = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'lbl_caja
        '
        Me.lbl_caja.AutoSize = True
        Me.lbl_caja.Location = New System.Drawing.Point(22, 28)
        Me.lbl_caja.Name = "lbl_caja"
        Me.lbl_caja.Size = New System.Drawing.Size(28, 13)
        Me.lbl_caja.TabIndex = 0
        Me.lbl_caja.Text = "Caja"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(27, 136)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 2
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(191, 190)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 4
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(93, 190)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_caja
        '
        Me.txt_caja.Location = New System.Drawing.Point(78, 21)
        Me.txt_caja.Name = "txt_caja"
        Me.txt_caja.Size = New System.Drawing.Size(259, 20)
        Me.txt_caja.TabIndex = 0
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(25, 103)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(79, 17)
        Me.chk_activo.TabIndex = 1
        Me.chk_activo.Text = "Caja activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'chk_cc
        '
        Me.chk_cc.AutoSize = True
        Me.chk_cc.Location = New System.Drawing.Point(25, 70)
        Me.chk_cc.Name = "chk_cc"
        Me.chk_cc.Size = New System.Drawing.Size(118, 17)
        Me.chk_cc.TabIndex = 5
        Me.chk_cc.Text = "Es cuenta corriente"
        Me.ToolTip1.SetToolTip(Me.chk_cc, "Si tilda esta casilla, al hacer el cierre de caja no se cerrarán los pedidos que " &
        "tengan esta caja seleccionada")
        Me.chk_cc.UseVisualStyleBackColor = True
        '
        'add_caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 236)
        Me.Controls.Add(Me.chk_cc)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_caja)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_caja)
        Me.Name = "add_caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar caja"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_caja As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_caja As System.Windows.Forms.TextBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents chk_cc As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
