<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.lbl_usuario = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_start = New System.Windows.Forms.Button()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pic_showPassword = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_showPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_usuario.Location = New System.Drawing.Point(14, 119)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(43, 13)
        Me.lbl_usuario.TabIndex = 0
        Me.lbl_usuario.Text = "Usuario"
        '
        'txt_usuario
        '
        Me.txt_usuario.Location = New System.Drawing.Point(93, 116)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(236, 20)
        Me.txt_usuario.TabIndex = 0
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(110, 274)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(174, 42)
        Me.cmd_exit.TabIndex = 3
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_start
        '
        Me.cmd_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_start.Location = New System.Drawing.Point(110, 216)
        Me.cmd_start.Name = "cmd_start"
        Me.cmd_start.Size = New System.Drawing.Size(174, 42)
        Me.cmd_start.TabIndex = 2
        Me.cmd_start.Text = "Iniciar sesión"
        Me.cmd_start.UseVisualStyleBackColor = True
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(93, 173)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(236, 20)
        Me.txt_password.TabIndex = 1
        Me.txt_password.UseSystemPasswordChar = True
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.Location = New System.Drawing.Point(14, 176)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(53, 13)
        Me.lbl_password.TabIndex = 28
        Me.lbl_password.Text = "Password"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Centrex.My.Resources.Resources.logoCentrexFC
        Me.PictureBox1.Location = New System.Drawing.Point(32, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(331, 85)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'pic_showPassword
        '
        Me.pic_showPassword.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_showPassword.Location = New System.Drawing.Point(335, 173)
        Me.pic_showPassword.Name = "pic_showPassword"
        Me.pic_showPassword.Size = New System.Drawing.Size(22, 22)
        Me.pic_showPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_showPassword.TabIndex = 37
        Me.pic_showPassword.TabStop = False
        '
        'login
        '
        Me.AcceptButton = Me.cmd_start
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CancelButton = Me.cmd_exit
        Me.ClientSize = New System.Drawing.Size(395, 331)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pic_showPassword)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_start)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.lbl_usuario)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar sesión"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_showPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_usuario As Label
    Friend WithEvents txt_usuario As TextBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_start As Button
    Friend WithEvents txt_password As TextBox
    Friend WithEvents lbl_password As Label
    Friend WithEvents pic_showPassword As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
