<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_cuentaBancaria
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
        Me.lbl_banco = New System.Windows.Forms.Label()
        Me.lbl_nombreCuenta = New System.Windows.Forms.Label()
        Me.lbl_moneda = New System.Windows.Forms.Label()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.tt_nCuenta = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmb_banco = New System.Windows.Forms.ComboBox()
        Me.cmb_moneda = New System.Windows.Forms.ComboBox()
        Me.txt_cuentaBancaria = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.psearch_banco = New System.Windows.Forms.PictureBox()
        CType(Me.psearch_banco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_banco
        '
        Me.lbl_banco.AutoSize = True
        Me.lbl_banco.Location = New System.Drawing.Point(22, 40)
        Me.lbl_banco.Name = "lbl_banco"
        Me.lbl_banco.Size = New System.Drawing.Size(38, 13)
        Me.lbl_banco.TabIndex = 0
        Me.lbl_banco.Text = "Banco"
        '
        'lbl_nombreCuenta
        '
        Me.lbl_nombreCuenta.AutoSize = True
        Me.lbl_nombreCuenta.Location = New System.Drawing.Point(22, 83)
        Me.lbl_nombreCuenta.Name = "lbl_nombreCuenta"
        Me.lbl_nombreCuenta.Size = New System.Drawing.Size(63, 13)
        Me.lbl_nombreCuenta.TabIndex = 1
        Me.lbl_nombreCuenta.Text = "Descripción"
        Me.tt_nCuenta.SetToolTip(Me.lbl_nombreCuenta, "Número de cuenta")
        '
        'lbl_moneda
        '
        Me.lbl_moneda.AutoSize = True
        Me.lbl_moneda.Location = New System.Drawing.Point(22, 134)
        Me.lbl_moneda.Name = "lbl_moneda"
        Me.lbl_moneda.Size = New System.Drawing.Size(46, 13)
        Me.lbl_moneda.TabIndex = 2
        Me.lbl_moneda.Text = "Moneda"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(25, 274)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 4
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(143, 337)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 5
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Checked = True
        Me.chk_activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_activo.Location = New System.Drawing.Point(25, 201)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(136, 17)
        Me.chk_activo.TabIndex = 3
        Me.chk_activo.Text = "Cuenta bancaria activa"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'cmb_banco
        '
        Me.cmb_banco.FormattingEnabled = True
        Me.cmb_banco.Location = New System.Drawing.Point(104, 32)
        Me.cmb_banco.Name = "cmb_banco"
        Me.cmb_banco.Size = New System.Drawing.Size(352, 21)
        Me.cmb_banco.TabIndex = 0
        '
        'cmb_moneda
        '
        Me.cmb_moneda.FormattingEnabled = True
        Me.cmb_moneda.Location = New System.Drawing.Point(104, 126)
        Me.cmb_moneda.Name = "cmb_moneda"
        Me.cmb_moneda.Size = New System.Drawing.Size(352, 21)
        Me.cmb_moneda.TabIndex = 2
        '
        'txt_cuentaBancaria
        '
        Me.txt_cuentaBancaria.Location = New System.Drawing.Point(104, 80)
        Me.txt_cuentaBancaria.Name = "txt_cuentaBancaria"
        Me.txt_cuentaBancaria.Size = New System.Drawing.Size(352, 20)
        Me.txt_cuentaBancaria.TabIndex = 1
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(261, 337)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 24
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'psearch_banco
        '
        Me.psearch_banco.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_banco.Location = New System.Drawing.Point(471, 31)
        Me.psearch_banco.Name = "psearch_banco"
        Me.psearch_banco.Size = New System.Drawing.Size(22, 22)
        Me.psearch_banco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_banco.TabIndex = 27
        Me.psearch_banco.TabStop = False
        '
        'add_cuentaBancaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 393)
        Me.Controls.Add(Me.psearch_banco)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.txt_cuentaBancaria)
        Me.Controls.Add(Me.cmb_moneda)
        Me.Controls.Add(Me.cmb_banco)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.lbl_moneda)
        Me.Controls.Add(Me.lbl_nombreCuenta)
        Me.Controls.Add(Me.lbl_banco)
        Me.Name = "add_cuentaBancaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar cuenta bancaria"
        CType(Me.psearch_banco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_banco As Label
    Friend WithEvents lbl_nombreCuenta As Label
    Friend WithEvents lbl_moneda As Label
    Friend WithEvents chk_secuencia As CheckBox
    Friend WithEvents cmd_ok As Button
    Friend WithEvents chk_activo As CheckBox
    Friend WithEvents tt_nCuenta As ToolTip
    Friend WithEvents cmb_banco As ComboBox
    Friend WithEvents cmb_moneda As ComboBox
    Friend WithEvents txt_cuentaBancaria As TextBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents psearch_banco As PictureBox
End Class
