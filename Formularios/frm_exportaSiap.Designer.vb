<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_exportaSiap
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
        Me.lbl_exportar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chk_hasta = New System.Windows.Forms.CheckBox()
        Me.chk_desde = New System.Windows.Forms.CheckBox()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmd_cerrar = New System.Windows.Forms.Button()
        Me.cmb_consultas = New System.Windows.Forms.ComboBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.pExportTXT = New System.Windows.Forms.PictureBox()
        Me.pExportXLS = New System.Windows.Forms.PictureBox()
        CType(Me.pExportTXT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pExportXLS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_exportar
        '
        Me.lbl_exportar.AutoSize = True
        Me.lbl_exportar.Location = New System.Drawing.Point(11, 13)
        Me.lbl_exportar.Name = "lbl_exportar"
        Me.lbl_exportar.Size = New System.Drawing.Size(85, 13)
        Me.lbl_exportar.TabIndex = 0
        Me.lbl_exportar.Text = "Datos a exportar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Exportar resultados a Excel"
        Me.Label1.Visible = False
        '
        'chk_hasta
        '
        Me.chk_hasta.AutoSize = True
        Me.chk_hasta.Location = New System.Drawing.Point(14, 118)
        Me.chk_hasta.Name = "chk_hasta"
        Me.chk_hasta.Size = New System.Drawing.Size(54, 17)
        Me.chk_hasta.TabIndex = 139
        Me.chk_hasta.Text = "Hasta"
        Me.chk_hasta.UseVisualStyleBackColor = True
        '
        'chk_desde
        '
        Me.chk_desde.AutoSize = True
        Me.chk_desde.Location = New System.Drawing.Point(14, 80)
        Me.chk_desde.Name = "chk_desde"
        Me.chk_desde.Size = New System.Drawing.Size(57, 17)
        Me.chk_desde.TabIndex = 138
        Me.chk_desde.Text = "Desde"
        Me.chk_desde.UseVisualStyleBackColor = True
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Enabled = False
        Me.dtp_hasta.Location = New System.Drawing.Point(77, 118)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(291, 20)
        Me.dtp_hasta.TabIndex = 137
        '
        'dtp_desde
        '
        Me.dtp_desde.Enabled = False
        Me.dtp_desde.Location = New System.Drawing.Point(77, 80)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(293, 20)
        Me.dtp_desde.TabIndex = 136
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Exportar resultados a TXT"
        Me.Label2.Visible = False
        '
        'cmd_cerrar
        '
        Me.cmd_cerrar.Location = New System.Drawing.Point(119, 264)
        Me.cmd_cerrar.Name = "cmd_cerrar"
        Me.cmd_cerrar.Size = New System.Drawing.Size(142, 21)
        Me.cmd_cerrar.TabIndex = 143
        Me.cmd_cerrar.Text = "Cerrar"
        Me.cmd_cerrar.UseVisualStyleBackColor = True
        '
        'cmb_consultas
        '
        Me.cmb_consultas.FormattingEnabled = True
        Me.cmb_consultas.Location = New System.Drawing.Point(14, 38)
        Me.cmb_consultas.Name = "cmb_consultas"
        Me.cmb_consultas.Size = New System.Drawing.Size(356, 21)
        Me.cmb_consultas.TabIndex = 0
        '
        'pExportTXT
        '
        Me.pExportTXT.Image = Global.Centrex.My.Resources.Resources.iconotxtByN
        Me.pExportTXT.Location = New System.Drawing.Point(240, 164)
        Me.pExportTXT.Name = "pExportTXT"
        Me.pExportTXT.Size = New System.Drawing.Size(55, 42)
        Me.pExportTXT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pExportTXT.TabIndex = 142
        Me.pExportTXT.TabStop = False
        '
        'pExportXLS
        '
        Me.pExportXLS.Image = Global.Centrex.My.Resources.Resources.iconoExcelByN
        Me.pExportXLS.Location = New System.Drawing.Point(67, 164)
        Me.pExportXLS.Name = "pExportXLS"
        Me.pExportXLS.Size = New System.Drawing.Size(55, 42)
        Me.pExportXLS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pExportXLS.TabIndex = 131
        Me.pExportXLS.TabStop = False
        '
        'frm_exportaSiap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 297)
        Me.Controls.Add(Me.cmb_consultas)
        Me.Controls.Add(Me.cmd_cerrar)
        Me.Controls.Add(Me.pExportTXT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chk_hasta)
        Me.Controls.Add(Me.chk_desde)
        Me.Controls.Add(Me.dtp_hasta)
        Me.Controls.Add(Me.dtp_desde)
        Me.Controls.Add(Me.pExportXLS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_exportar)
        Me.Name = "frm_exportaSiap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Exportación de datos SIAp"
        CType(Me.pExportTXT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pExportXLS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_exportar As Label
    Friend WithEvents pExportXLS As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chk_hasta As CheckBox
    Friend WithEvents chk_desde As CheckBox
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents pExportTXT As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmd_cerrar As Button
    Friend WithEvents cmb_consultas As ComboBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
