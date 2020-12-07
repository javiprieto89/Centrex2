<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rechazarCH
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
        Me.cmd_filtrarCH = New System.Windows.Forms.Button()
        Me.lbl_desde = New System.Windows.Forms.Label()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.lbl_hasta = New System.Windows.Forms.Label()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.chk_hastaSiempre = New System.Windows.Forms.CheckBox()
        Me.txt_importeCH = New System.Windows.Forms.TextBox()
        Me.chk_desdeSiempre = New System.Windows.Forms.CheckBox()
        Me.lbl_importeCH = New System.Windows.Forms.Label()
        Me.lbl_nCH = New System.Windows.Forms.Label()
        Me.txt_nCH = New System.Windows.Forms.TextBox()
        Me.dg_view_chCartera = New System.Windows.Forms.DataGridView()
        Me.cmb_rechazarCH = New System.Windows.Forms.Button()
        Me.cmb_anularCH = New System.Windows.Forms.Button()
        Me.cmb_cancelarRechazo = New System.Windows.Forms.Button()
        Me.cmb_cancelarAnul = New System.Windows.Forms.Button()
        Me.gp_depositados = New System.Windows.Forms.GroupBox()
        CType(Me.dg_view_chCartera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gp_depositados.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_filtrarCH
        '
        Me.cmd_filtrarCH.Location = New System.Drawing.Point(105, 231)
        Me.cmd_filtrarCH.Name = "cmd_filtrarCH"
        Me.cmd_filtrarCH.Size = New System.Drawing.Size(147, 23)
        Me.cmd_filtrarCH.TabIndex = 149
        Me.cmd_filtrarCH.Text = "Filtrar cheques"
        Me.cmd_filtrarCH.UseVisualStyleBackColor = True
        '
        'lbl_desde
        '
        Me.lbl_desde.AutoSize = True
        Me.lbl_desde.Location = New System.Drawing.Point(49, 31)
        Me.lbl_desde.Name = "lbl_desde"
        Me.lbl_desde.Size = New System.Drawing.Size(38, 13)
        Me.lbl_desde.TabIndex = 140
        Me.lbl_desde.Text = "Desde"
        '
        'dtp_desde
        '
        Me.dtp_desde.Enabled = False
        Me.dtp_desde.Location = New System.Drawing.Point(158, 24)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(263, 20)
        Me.dtp_desde.TabIndex = 139
        '
        'lbl_hasta
        '
        Me.lbl_hasta.AutoSize = True
        Me.lbl_hasta.Location = New System.Drawing.Point(49, 69)
        Me.lbl_hasta.Name = "lbl_hasta"
        Me.lbl_hasta.Size = New System.Drawing.Size(35, 13)
        Me.lbl_hasta.TabIndex = 142
        Me.lbl_hasta.Text = "Hasta"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Enabled = False
        Me.dtp_hasta.Location = New System.Drawing.Point(158, 69)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(263, 20)
        Me.dtp_hasta.TabIndex = 141
        '
        'chk_hastaSiempre
        '
        Me.chk_hastaSiempre.AutoSize = True
        Me.chk_hastaSiempre.Checked = True
        Me.chk_hastaSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_hastaSiempre.Location = New System.Drawing.Point(19, 68)
        Me.chk_hastaSiempre.Name = "chk_hastaSiempre"
        Me.chk_hastaSiempre.Size = New System.Drawing.Size(15, 14)
        Me.chk_hastaSiempre.TabIndex = 143
        Me.chk_hastaSiempre.UseVisualStyleBackColor = True
        '
        'txt_importeCH
        '
        Me.txt_importeCH.Location = New System.Drawing.Point(265, 190)
        Me.txt_importeCH.Name = "txt_importeCH"
        Me.txt_importeCH.Size = New System.Drawing.Size(263, 20)
        Me.txt_importeCH.TabIndex = 148
        '
        'chk_desdeSiempre
        '
        Me.chk_desdeSiempre.AutoSize = True
        Me.chk_desdeSiempre.Checked = True
        Me.chk_desdeSiempre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_desdeSiempre.Location = New System.Drawing.Point(19, 30)
        Me.chk_desdeSiempre.Name = "chk_desdeSiempre"
        Me.chk_desdeSiempre.Size = New System.Drawing.Size(15, 14)
        Me.chk_desdeSiempre.TabIndex = 144
        Me.chk_desdeSiempre.UseVisualStyleBackColor = True
        '
        'lbl_importeCH
        '
        Me.lbl_importeCH.AutoSize = True
        Me.lbl_importeCH.Location = New System.Drawing.Point(105, 190)
        Me.lbl_importeCH.Name = "lbl_importeCH"
        Me.lbl_importeCH.Size = New System.Drawing.Size(98, 13)
        Me.lbl_importeCH.TabIndex = 147
        Me.lbl_importeCH.Text = "Importe del cheque"
        '
        'lbl_nCH
        '
        Me.lbl_nCH.AutoSize = True
        Me.lbl_nCH.Location = New System.Drawing.Point(105, 149)
        Me.lbl_nCH.Name = "lbl_nCH"
        Me.lbl_nCH.Size = New System.Drawing.Size(98, 13)
        Me.lbl_nCH.TabIndex = 145
        Me.lbl_nCH.Text = "Número de cheque"
        '
        'txt_nCH
        '
        Me.txt_nCH.Location = New System.Drawing.Point(265, 149)
        Me.txt_nCH.Name = "txt_nCH"
        Me.txt_nCH.Size = New System.Drawing.Size(263, 20)
        Me.txt_nCH.TabIndex = 146
        '
        'dg_view_chCartera
        '
        Me.dg_view_chCartera.AllowUserToAddRows = False
        Me.dg_view_chCartera.AllowUserToDeleteRows = False
        Me.dg_view_chCartera.AllowUserToOrderColumns = True
        Me.dg_view_chCartera.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view_chCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view_chCartera.Enabled = False
        Me.dg_view_chCartera.Location = New System.Drawing.Point(20, 281)
        Me.dg_view_chCartera.MultiSelect = False
        Me.dg_view_chCartera.Name = "dg_view_chCartera"
        Me.dg_view_chCartera.ReadOnly = True
        Me.dg_view_chCartera.RowHeadersVisible = False
        Me.dg_view_chCartera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view_chCartera.Size = New System.Drawing.Size(607, 279)
        Me.dg_view_chCartera.TabIndex = 150
        '
        'cmb_rechazarCH
        '
        Me.cmb_rechazarCH.Location = New System.Drawing.Point(20, 586)
        Me.cmb_rechazarCH.Name = "cmb_rechazarCH"
        Me.cmb_rechazarCH.Size = New System.Drawing.Size(124, 23)
        Me.cmb_rechazarCH.TabIndex = 151
        Me.cmb_rechazarCH.Text = "Rechazar cheque"
        Me.cmb_rechazarCH.UseVisualStyleBackColor = True
        '
        'cmb_anularCH
        '
        Me.cmb_anularCH.Location = New System.Drawing.Point(184, 586)
        Me.cmb_anularCH.Name = "cmb_anularCH"
        Me.cmb_anularCH.Size = New System.Drawing.Size(121, 23)
        Me.cmb_anularCH.TabIndex = 152
        Me.cmb_anularCH.Text = "Anular cheque"
        Me.cmb_anularCH.UseVisualStyleBackColor = True
        '
        'cmb_cancelarRechazo
        '
        Me.cmb_cancelarRechazo.Location = New System.Drawing.Point(345, 586)
        Me.cmb_cancelarRechazo.Name = "cmb_cancelarRechazo"
        Me.cmb_cancelarRechazo.Size = New System.Drawing.Size(121, 23)
        Me.cmb_cancelarRechazo.TabIndex = 153
        Me.cmb_cancelarRechazo.Text = "Cancelar rechazo"
        Me.cmb_cancelarRechazo.UseVisualStyleBackColor = True
        '
        'cmb_cancelarAnul
        '
        Me.cmb_cancelarAnul.Location = New System.Drawing.Point(506, 586)
        Me.cmb_cancelarAnul.Name = "cmb_cancelarAnul"
        Me.cmb_cancelarAnul.Size = New System.Drawing.Size(121, 23)
        Me.cmb_cancelarAnul.TabIndex = 154
        Me.cmb_cancelarAnul.Text = "Cancelar anulación"
        Me.cmb_cancelarAnul.UseVisualStyleBackColor = True
        '
        'gp_depositados
        '
        Me.gp_depositados.Controls.Add(Me.chk_desdeSiempre)
        Me.gp_depositados.Controls.Add(Me.chk_hastaSiempre)
        Me.gp_depositados.Controls.Add(Me.dtp_hasta)
        Me.gp_depositados.Controls.Add(Me.lbl_hasta)
        Me.gp_depositados.Controls.Add(Me.dtp_desde)
        Me.gp_depositados.Controls.Add(Me.lbl_desde)
        Me.gp_depositados.Location = New System.Drawing.Point(105, 12)
        Me.gp_depositados.Name = "gp_depositados"
        Me.gp_depositados.Size = New System.Drawing.Size(433, 120)
        Me.gp_depositados.TabIndex = 155
        Me.gp_depositados.TabStop = False
        Me.gp_depositados.Text = "Fecha de cobro"
        '
        'frm_rechazarCH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 642)
        Me.Controls.Add(Me.gp_depositados)
        Me.Controls.Add(Me.cmb_cancelarAnul)
        Me.Controls.Add(Me.cmb_cancelarRechazo)
        Me.Controls.Add(Me.cmb_anularCH)
        Me.Controls.Add(Me.cmb_rechazarCH)
        Me.Controls.Add(Me.dg_view_chCartera)
        Me.Controls.Add(Me.cmd_filtrarCH)
        Me.Controls.Add(Me.txt_importeCH)
        Me.Controls.Add(Me.lbl_importeCH)
        Me.Controls.Add(Me.lbl_nCH)
        Me.Controls.Add(Me.txt_nCH)
        Me.Name = "frm_rechazarCH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechazar cheques"
        CType(Me.dg_view_chCartera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gp_depositados.ResumeLayout(False)
        Me.gp_depositados.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmd_filtrarCH As Button
    Friend WithEvents lbl_desde As Label
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents lbl_hasta As Label
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents chk_hastaSiempre As CheckBox
    Friend WithEvents txt_importeCH As TextBox
    Friend WithEvents chk_desdeSiempre As CheckBox
    Friend WithEvents lbl_importeCH As Label
    Friend WithEvents lbl_nCH As Label
    Friend WithEvents txt_nCH As TextBox
    Friend WithEvents dg_view_chCartera As DataGridView
    Friend WithEvents cmb_rechazarCH As Button
    Friend WithEvents cmb_anularCH As Button
    Friend WithEvents cmb_cancelarRechazo As Button
    Friend WithEvents cmb_cancelarAnul As Button
    Friend WithEvents gp_depositados As GroupBox
End Class
