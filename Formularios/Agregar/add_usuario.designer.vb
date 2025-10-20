<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_usuario
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
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_usuario = New System.Windows.Forms.Label()
        Me.lbl_perfil = New System.Windows.Forms.Label()
        Me.cmb_perfil = New System.Windows.Forms.ComboBox()
        Me.pic_showPassword = New System.Windows.Forms.PictureBox()
        CType(Me.pic_showPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(133, 57)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(259, 20)
        Me.txt_password.TabIndex = 24
        Me.txt_password.UseSystemPasswordChar = True
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.Location = New System.Drawing.Point(18, 59)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(53, 13)
        Me.lbl_password.TabIndex = 32
        Me.lbl_password.Text = "Password"
        '
        'txt_nombre
        '
        Me.txt_nombre.Location = New System.Drawing.Point(133, 93)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(259, 20)
        Me.txt_nombre.TabIndex = 25
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Location = New System.Drawing.Point(18, 94)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_nombre.TabIndex = 31
        Me.lbl_nombre.Text = "Nombre"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(21, 169)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(94, 17)
        Me.chk_activo.TabIndex = 26
        Me.chk_activo.Text = "Usuario activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'txt_usuario
        '
        Me.txt_usuario.Location = New System.Drawing.Point(133, 21)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(259, 20)
        Me.txt_usuario.TabIndex = 23
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(21, 208)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 27
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(224, 242)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 29
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(126, 242)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 28
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.Location = New System.Drawing.Point(18, 24)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(43, 13)
        Me.lbl_usuario.TabIndex = 30
        Me.lbl_usuario.Text = "Usuario"
        '
        'lbl_perfil
        '
        Me.lbl_perfil.AutoSize = True
        Me.lbl_perfil.Location = New System.Drawing.Point(18, 129)
        Me.lbl_perfil.Name = "lbl_perfil"
        Me.lbl_perfil.Size = New System.Drawing.Size(106, 13)
        Me.lbl_perfil.TabIndex = 34
        Me.lbl_perfil.Text = "Perfil predeterminado"
        '
        'cmb_perfil
        '
        Me.cmb_perfil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_perfil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_perfil.FormattingEnabled = True
        Me.cmb_perfil.Location = New System.Drawing.Point(133, 129)
        Me.cmb_perfil.Name = "cmb_perfil"
        Me.cmb_perfil.Size = New System.Drawing.Size(259, 21)
        Me.cmb_perfil.TabIndex = 33
        '
        'pic_showPassword
        '
        Me.pic_showPassword.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_showPassword.Location = New System.Drawing.Point(398, 57)
        Me.pic_showPassword.Name = "pic_showPassword"
        Me.pic_showPassword.Size = New System.Drawing.Size(22, 22)
        Me.pic_showPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_showPassword.TabIndex = 36
        Me.pic_showPassword.TabStop = False
        '
        'add_usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 287)
        Me.Controls.Add(Me.pic_showPassword)
        Me.Controls.Add(Me.cmb_perfil)
        Me.Controls.Add(Me.lbl_perfil)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_usuario)
        Me.Name = "add_usuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar usuario"
        CType(Me.pic_showPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents lbl_password As System.Windows.Forms.Label
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_usuario As System.Windows.Forms.Label
    Friend WithEvents pic_showPassword As PictureBox
    Friend WithEvents lbl_perfil As Label
    Friend WithEvents cmb_perfil As ComboBox
End Class
