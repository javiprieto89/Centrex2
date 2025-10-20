<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_usuarios_perfiles
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
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.pic_searchPerfil = New System.Windows.Forms.PictureBox()
        Me.cmb_usuarios = New System.Windows.Forms.ComboBox()
        Me.lbl_usuarios = New System.Windows.Forms.Label()
        Me.pic_searchPermiso = New System.Windows.Forms.PictureBox()
        Me.cmb_perfiles = New System.Windows.Forms.ComboBox()
        Me.lbl_perfiles = New System.Windows.Forms.Label()
        CType(Me.pic_searchPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchPermiso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(21, 126)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 27
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(224, 180)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 29
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(126, 180)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 28
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'pic_searchPerfil
        '
        Me.pic_searchPerfil.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchPerfil.Location = New System.Drawing.Point(384, 23)
        Me.pic_searchPerfil.Name = "pic_searchPerfil"
        Me.pic_searchPerfil.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchPerfil.TabIndex = 35
        Me.pic_searchPerfil.TabStop = False
        '
        'cmb_usuarios
        '
        Me.cmb_usuarios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_usuarios.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_usuarios.FormattingEnabled = True
        Me.cmb_usuarios.Location = New System.Drawing.Point(119, 24)
        Me.cmb_usuarios.Name = "cmb_usuarios"
        Me.cmb_usuarios.Size = New System.Drawing.Size(259, 21)
        Me.cmb_usuarios.TabIndex = 33
        '
        'lbl_usuarios
        '
        Me.lbl_usuarios.AutoSize = True
        Me.lbl_usuarios.Location = New System.Drawing.Point(18, 24)
        Me.lbl_usuarios.Name = "lbl_usuarios"
        Me.lbl_usuarios.Size = New System.Drawing.Size(48, 13)
        Me.lbl_usuarios.TabIndex = 34
        Me.lbl_usuarios.Text = "Usuarios"
        '
        'pic_searchPermiso
        '
        Me.pic_searchPermiso.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchPermiso.Location = New System.Drawing.Point(384, 77)
        Me.pic_searchPermiso.Name = "pic_searchPermiso"
        Me.pic_searchPermiso.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchPermiso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchPermiso.TabIndex = 38
        Me.pic_searchPermiso.TabStop = False
        '
        'cmb_perfiles
        '
        Me.cmb_perfiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_perfiles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_perfiles.FormattingEnabled = True
        Me.cmb_perfiles.Location = New System.Drawing.Point(119, 78)
        Me.cmb_perfiles.Name = "cmb_perfiles"
        Me.cmb_perfiles.Size = New System.Drawing.Size(259, 21)
        Me.cmb_perfiles.TabIndex = 36
        '
        'lbl_perfiles
        '
        Me.lbl_perfiles.AutoSize = True
        Me.lbl_perfiles.Location = New System.Drawing.Point(18, 78)
        Me.lbl_perfiles.Name = "lbl_perfiles"
        Me.lbl_perfiles.Size = New System.Drawing.Size(41, 13)
        Me.lbl_perfiles.TabIndex = 37
        Me.lbl_perfiles.Text = "Perfiles"
        '
        'add_usuarios_perfiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 226)
        Me.Controls.Add(Me.pic_searchPermiso)
        Me.Controls.Add(Me.cmb_perfiles)
        Me.Controls.Add(Me.lbl_perfiles)
        Me.Controls.Add(Me.pic_searchPerfil)
        Me.Controls.Add(Me.cmb_usuarios)
        Me.Controls.Add(Me.lbl_usuarios)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Name = "add_usuarios_perfiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar relación perfil/permisos"
        CType(Me.pic_searchPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchPermiso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents pic_searchPerfil As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_usuarios As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_usuarios As System.Windows.Forms.Label
    Friend WithEvents pic_searchPermiso As PictureBox
    Friend WithEvents cmb_perfiles As ComboBox
    Friend WithEvents lbl_perfiles As Label
End Class
