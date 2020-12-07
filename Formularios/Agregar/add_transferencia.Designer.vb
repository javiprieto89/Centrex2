<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_transferencia
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
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.lbl_importe = New System.Windows.Forms.Label()
        Me.lbl_cuentaBancaria = New System.Windows.Forms.Label()
        Me.lbl_banco = New System.Windows.Forms.Label()
        Me.cmb_cuentaBancaria = New System.Windows.Forms.ComboBox()
        Me.psearch_banco = New System.Windows.Forms.PictureBox()
        Me.cmb_banco = New System.Windows.Forms.ComboBox()
        Me.psearch_cuentaBancaria = New System.Windows.Forms.PictureBox()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.txt_importe = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_nComprobante = New System.Windows.Forms.TextBox()
        Me.lbl_nComprobante = New System.Windows.Forms.Label()
        CType(Me.psearch_banco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.psearch_cuentaBancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(42, 29)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(37, 13)
        Me.lbl_fecha.TabIndex = 7
        Me.lbl_fecha.Text = "Fecha"
        '
        'lbl_importe
        '
        Me.lbl_importe.AutoSize = True
        Me.lbl_importe.Location = New System.Drawing.Point(42, 186)
        Me.lbl_importe.Name = "lbl_importe"
        Me.lbl_importe.Size = New System.Drawing.Size(42, 13)
        Me.lbl_importe.TabIndex = 1
        Me.lbl_importe.Text = "Importe"
        '
        'lbl_cuentaBancaria
        '
        Me.lbl_cuentaBancaria.Location = New System.Drawing.Point(42, 132)
        Me.lbl_cuentaBancaria.Name = "lbl_cuentaBancaria"
        Me.lbl_cuentaBancaria.Size = New System.Drawing.Size(51, 33)
        Me.lbl_cuentaBancaria.TabIndex = 2
        Me.lbl_cuentaBancaria.Text = "Cuenta bancaria"
        '
        'lbl_banco
        '
        Me.lbl_banco.AutoSize = True
        Me.lbl_banco.Location = New System.Drawing.Point(42, 89)
        Me.lbl_banco.Name = "lbl_banco"
        Me.lbl_banco.Size = New System.Drawing.Size(38, 13)
        Me.lbl_banco.TabIndex = 3
        Me.lbl_banco.Text = "Banco"
        '
        'cmb_cuentaBancaria
        '
        Me.cmb_cuentaBancaria.FormattingEnabled = True
        Me.cmb_cuentaBancaria.Location = New System.Drawing.Point(126, 132)
        Me.cmb_cuentaBancaria.Name = "cmb_cuentaBancaria"
        Me.cmb_cuentaBancaria.Size = New System.Drawing.Size(352, 21)
        Me.cmb_cuentaBancaria.TabIndex = 2
        '
        'psearch_banco
        '
        Me.psearch_banco.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_banco.Location = New System.Drawing.Point(493, 80)
        Me.psearch_banco.Name = "psearch_banco"
        Me.psearch_banco.Size = New System.Drawing.Size(22, 22)
        Me.psearch_banco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_banco.TabIndex = 29
        Me.psearch_banco.TabStop = False
        '
        'cmb_banco
        '
        Me.cmb_banco.FormattingEnabled = True
        Me.cmb_banco.Location = New System.Drawing.Point(126, 81)
        Me.cmb_banco.Name = "cmb_banco"
        Me.cmb_banco.Size = New System.Drawing.Size(352, 21)
        Me.cmb_banco.TabIndex = 1
        '
        'psearch_cuentaBancaria
        '
        Me.psearch_cuentaBancaria.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.psearch_cuentaBancaria.Location = New System.Drawing.Point(493, 132)
        Me.psearch_cuentaBancaria.Name = "psearch_cuentaBancaria"
        Me.psearch_cuentaBancaria.Size = New System.Drawing.Size(22, 22)
        Me.psearch_cuentaBancaria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.psearch_cuentaBancaria.TabIndex = 30
        Me.psearch_cuentaBancaria.TabStop = False
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(126, 29)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(104, 20)
        Me.dtp_fecha.TabIndex = 0
        '
        'txt_importe
        '
        Me.txt_importe.Location = New System.Drawing.Point(126, 183)
        Me.txt_importe.Name = "txt_importe"
        Me.txt_importe.Size = New System.Drawing.Size(104, 20)
        Me.txt_importe.TabIndex = 3
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(42, 281)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 8
        Me.lbl_notas.Text = "Notas"
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(126, 283)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(352, 97)
        Me.txt_notas.TabIndex = 1
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(282, 427)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 3
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(184, 427)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 2
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_nComprobante
        '
        Me.txt_nComprobante.Location = New System.Drawing.Point(126, 233)
        Me.txt_nComprobante.Name = "txt_nComprobante"
        Me.txt_nComprobante.Size = New System.Drawing.Size(104, 20)
        Me.txt_nComprobante.TabIndex = 0
        '
        'lbl_nComprobante
        '
        Me.lbl_nComprobante.Location = New System.Drawing.Point(42, 233)
        Me.lbl_nComprobante.Name = "lbl_nComprobante"
        Me.lbl_nComprobante.Size = New System.Drawing.Size(78, 30)
        Me.lbl_nComprobante.TabIndex = 31
        Me.lbl_nComprobante.Text = "Número de comprobante"
        '
        'add_transferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 482)
        Me.Controls.Add(Me.txt_nComprobante)
        Me.Controls.Add(Me.lbl_nComprobante)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.txt_importe)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.psearch_cuentaBancaria)
        Me.Controls.Add(Me.psearch_banco)
        Me.Controls.Add(Me.cmb_banco)
        Me.Controls.Add(Me.cmb_cuentaBancaria)
        Me.Controls.Add(Me.lbl_banco)
        Me.Controls.Add(Me.lbl_cuentaBancaria)
        Me.Controls.Add(Me.lbl_importe)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Name = "add_transferencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingresar transferencia"
        CType(Me.psearch_banco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.psearch_cuentaBancaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_fecha As Label
    Friend WithEvents lbl_importe As Label
    Friend WithEvents lbl_cuentaBancaria As Label
    Friend WithEvents lbl_banco As Label
    Friend WithEvents cmb_cuentaBancaria As ComboBox
    Friend WithEvents psearch_banco As PictureBox
    Friend WithEvents cmb_banco As ComboBox
    Friend WithEvents psearch_cuentaBancaria As PictureBox
    Friend WithEvents dtp_fecha As DateTimePicker
    Friend WithEvents txt_importe As TextBox
    Friend WithEvents lbl_notas As Label
    Friend WithEvents txt_notas As TextBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
    Friend WithEvents txt_nComprobante As TextBox
    Friend WithEvents lbl_nComprobante As Label
End Class
