<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_banco
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
        Me.lbl_banco = New System.Windows.Forms.Label()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.cmb_pais = New System.Windows.Forms.ComboBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_pais = New System.Windows.Forms.Label()
        Me.txt_bancoN = New System.Windows.Forms.TextBox()
        Me.lbl_bancoN = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_banco
        '
        Me.lbl_banco.AutoSize = True
        Me.lbl_banco.Location = New System.Drawing.Point(23, 30)
        Me.lbl_banco.Name = "lbl_banco"
        Me.lbl_banco.Size = New System.Drawing.Size(44, 13)
        Me.lbl_banco.TabIndex = 0
        Me.lbl_banco.Text = "Nombre"
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(101, 23)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(261, 20)
        Me.txt_nombre.TabIndex = 0
        '
        'cmb_pais
        '
        Me.cmb_pais.FormattingEnabled = True
        Me.cmb_pais.Location = New System.Drawing.Point(101, 73)
        Me.cmb_pais.Name = "cmb_pais"
        Me.cmb_pais.Size = New System.Drawing.Size(261, 21)
        Me.cmb_pais.TabIndex = 1
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Checked = True
        Me.chk_activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_activo.Location = New System.Drawing.Point(26, 186)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(89, 17)
        Me.chk_activo.TabIndex = 3
        Me.chk_activo.Text = "Banco activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(26, 244)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 4
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(104, 284)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 5
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_pais
        '
        Me.lbl_pais.AutoSize = True
        Me.lbl_pais.Location = New System.Drawing.Point(23, 81)
        Me.lbl_pais.Name = "lbl_pais"
        Me.lbl_pais.Size = New System.Drawing.Size(29, 13)
        Me.lbl_pais.TabIndex = 25
        Me.lbl_pais.Text = "País"
        '
        'txt_bancoN
        '
        Me.txt_bancoN.Location = New System.Drawing.Point(101, 126)
        Me.txt_bancoN.Name = "txt_bancoN"
        Me.txt_bancoN.Size = New System.Drawing.Size(261, 20)
        Me.txt_bancoN.TabIndex = 2
        '
        'lbl_bancoN
        '
        Me.lbl_bancoN.AutoSize = True
        Me.lbl_bancoN.Location = New System.Drawing.Point(23, 133)
        Me.lbl_bancoN.Name = "lbl_bancoN"
        Me.lbl_bancoN.Size = New System.Drawing.Size(53, 13)
        Me.lbl_bancoN.TabIndex = 26
        Me.lbl_bancoN.Text = "Banco Nº"
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(206, 284)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 27
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'add_banco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 331)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.txt_bancoN)
        Me.Controls.Add(Me.lbl_bancoN)
        Me.Controls.Add(Me.lbl_pais)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.cmb_pais)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.lbl_banco)
        Me.Name = "add_banco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar banco"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_banco As Label
    Friend WithEvents txt_nombre As TextBox
    Friend WithEvents cmb_pais As ComboBox
    Friend WithEvents chk_activo As CheckBox
    Friend WithEvents chk_secuencia As CheckBox
    Friend WithEvents cmd_ok As Button
    Friend WithEvents lbl_pais As Label
    Friend WithEvents txt_bancoN As TextBox
    Friend WithEvents lbl_bancoN As Label
    Friend WithEvents cmd_exit As Button
End Class
