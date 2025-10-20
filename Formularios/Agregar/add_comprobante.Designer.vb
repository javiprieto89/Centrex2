<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_comprobante
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
        Me.lbl_comprobante = New System.Windows.Forms.Label()
        Me.lbl_puntoVenta = New System.Windows.Forms.Label()
        Me.lbl_numero = New System.Windows.Forms.Label()
        Me.lbl_tipoComprobante = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.rb_fiscal = New System.Windows.Forms.RadioButton()
        Me.rb_electronico = New System.Windows.Forms.RadioButton()
        Me.rb_manual = New System.Windows.Forms.RadioButton()
        Me.txt_comprobante = New System.Windows.Forms.TextBox()
        Me.cmb_tipoComprobante = New System.Windows.Forms.ComboBox()
        Me.nup_puntoVenta = New System.Windows.Forms.NumericUpDown()
        Me.nup_numero = New System.Windows.Forms.NumericUpDown()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.gb_tipoComprobante = New System.Windows.Forms.GroupBox()
        Me.rb_presupuesto = New System.Windows.Forms.RadioButton()
        Me.chk_testing = New System.Windows.Forms.CheckBox()
        Me.nup_maxItems = New System.Windows.Forms.NumericUpDown()
        Me.lbl_maxItems = New System.Windows.Forms.Label()
        Me.chk_contabilizar = New System.Windows.Forms.CheckBox()
        Me.TC = New System.Windows.Forms.TabControl()
        Me.t_general = New System.Windows.Forms.TabPage()
        Me.chk_mueveStock = New System.Windows.Forms.CheckBox()
        Me.t_mipyme = New System.Windows.Forms.TabPage()
        Me.lbl_alias_CBU_emisor = New System.Windows.Forms.Label()
        Me.txt_alias_CBU_emisor = New System.Windows.Forms.TextBox()
        Me.lbl_CBU_emisor = New System.Windows.Forms.Label()
        Me.txt_CBU_emisor = New System.Windows.Forms.TextBox()
        Me.chk_esMipyme = New System.Windows.Forms.CheckBox()
        Me.lbl_comprobanteRelacionado = New System.Windows.Forms.Label()
        Me.cmb_comprobanteRelacionado = New System.Windows.Forms.ComboBox()
        Me.lbl_modoMiPyme = New System.Windows.Forms.Label()
        Me.cmb_modoMiPyme = New System.Windows.Forms.ComboBox()
        Me.lbl_comprobanteAnulación = New System.Windows.Forms.Label()
        Me.txt_comprobanteAnulacion = New System.Windows.Forms.TextBox()
        Me.tt_comprobanteAnulacion = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.nup_puntoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nup_numero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_tipoComprobante.SuspendLayout()
        CType(Me.nup_maxItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TC.SuspendLayout()
        Me.t_general.SuspendLayout()
        Me.t_mipyme.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_comprobante
        '
        Me.lbl_comprobante.AutoSize = True
        Me.lbl_comprobante.Location = New System.Drawing.Point(12, 19)
        Me.lbl_comprobante.Name = "lbl_comprobante"
        Me.lbl_comprobante.Size = New System.Drawing.Size(70, 13)
        Me.lbl_comprobante.TabIndex = 0
        Me.lbl_comprobante.Text = "Comprobante"
        '
        'lbl_puntoVenta
        '
        Me.lbl_puntoVenta.AutoSize = True
        Me.lbl_puntoVenta.Location = New System.Drawing.Point(378, 95)
        Me.lbl_puntoVenta.Name = "lbl_puntoVenta"
        Me.lbl_puntoVenta.Size = New System.Drawing.Size(80, 13)
        Me.lbl_puntoVenta.TabIndex = 2
        Me.lbl_puntoVenta.Text = "Punto de venta"
        '
        'lbl_numero
        '
        Me.lbl_numero.Location = New System.Drawing.Point(12, 90)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(141, 26)
        Me.lbl_numero.TabIndex = 3
        Me.lbl_numero.Text = "Último número de comprobante emitido"
        '
        'lbl_tipoComprobante
        '
        Me.lbl_tipoComprobante.AutoSize = True
        Me.lbl_tipoComprobante.Location = New System.Drawing.Point(12, 57)
        Me.lbl_tipoComprobante.Name = "lbl_tipoComprobante"
        Me.lbl_tipoComprobante.Size = New System.Drawing.Size(108, 13)
        Me.lbl_tipoComprobante.TabIndex = 4
        Me.lbl_tipoComprobante.Text = "Tipo de comprobante"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(106, 283)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(121, 17)
        Me.chk_activo.TabIndex = 38
        Me.chk_activo.Text = "Comprobante activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(312, 453)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 43
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(214, 453)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 42
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'rb_fiscal
        '
        Me.rb_fiscal.AutoSize = True
        Me.rb_fiscal.Location = New System.Drawing.Point(144, 19)
        Me.rb_fiscal.Name = "rb_fiscal"
        Me.rb_fiscal.Size = New System.Drawing.Size(52, 17)
        Me.rb_fiscal.TabIndex = 44
        Me.rb_fiscal.TabStop = True
        Me.rb_fiscal.Text = "Fiscal"
        Me.rb_fiscal.UseVisualStyleBackColor = True
        '
        'rb_electronico
        '
        Me.rb_electronico.AutoSize = True
        Me.rb_electronico.Location = New System.Drawing.Point(252, 19)
        Me.rb_electronico.Name = "rb_electronico"
        Me.rb_electronico.Size = New System.Drawing.Size(78, 17)
        Me.rb_electronico.TabIndex = 45
        Me.rb_electronico.TabStop = True
        Me.rb_electronico.Text = "Electrónico"
        Me.rb_electronico.UseVisualStyleBackColor = True
        '
        'rb_manual
        '
        Me.rb_manual.AutoSize = True
        Me.rb_manual.Location = New System.Drawing.Point(144, 56)
        Me.rb_manual.Name = "rb_manual"
        Me.rb_manual.Size = New System.Drawing.Size(60, 17)
        Me.rb_manual.TabIndex = 46
        Me.rb_manual.TabStop = True
        Me.rb_manual.Text = "Manual"
        Me.rb_manual.UseVisualStyleBackColor = True
        '
        'txt_comprobante
        '
        Me.txt_comprobante.Location = New System.Drawing.Point(159, 12)
        Me.txt_comprobante.MaxLength = 45
        Me.txt_comprobante.Name = "txt_comprobante"
        Me.txt_comprobante.Size = New System.Drawing.Size(388, 20)
        Me.txt_comprobante.TabIndex = 49
        '
        'cmb_tipoComprobante
        '
        Me.cmb_tipoComprobante.FormattingEnabled = True
        Me.cmb_tipoComprobante.Location = New System.Drawing.Point(159, 52)
        Me.cmb_tipoComprobante.Name = "cmb_tipoComprobante"
        Me.cmb_tipoComprobante.Size = New System.Drawing.Size(388, 21)
        Me.cmb_tipoComprobante.TabIndex = 52
        '
        'nup_puntoVenta
        '
        Me.nup_puntoVenta.Location = New System.Drawing.Point(464, 93)
        Me.nup_puntoVenta.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nup_puntoVenta.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nup_puntoVenta.Name = "nup_puntoVenta"
        Me.nup_puntoVenta.Size = New System.Drawing.Size(87, 20)
        Me.nup_puntoVenta.TabIndex = 53
        Me.nup_puntoVenta.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nup_numero
        '
        Me.nup_numero.Location = New System.Drawing.Point(159, 93)
        Me.nup_numero.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nup_numero.Name = "nup_numero"
        Me.nup_numero.Size = New System.Drawing.Size(202, 20)
        Me.nup_numero.TabIndex = 54
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(16, 397)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 55
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'gb_tipoComprobante
        '
        Me.gb_tipoComprobante.Controls.Add(Me.rb_presupuesto)
        Me.gb_tipoComprobante.Controls.Add(Me.rb_fiscal)
        Me.gb_tipoComprobante.Controls.Add(Me.rb_electronico)
        Me.gb_tipoComprobante.Controls.Add(Me.rb_manual)
        Me.gb_tipoComprobante.Location = New System.Drawing.Point(106, 170)
        Me.gb_tipoComprobante.Name = "gb_tipoComprobante"
        Me.gb_tipoComprobante.Size = New System.Drawing.Size(346, 95)
        Me.gb_tipoComprobante.TabIndex = 57
        Me.gb_tipoComprobante.TabStop = False
        Me.gb_tipoComprobante.Text = "El comprobante es"
        '
        'rb_presupuesto
        '
        Me.rb_presupuesto.AutoSize = True
        Me.rb_presupuesto.Location = New System.Drawing.Point(252, 56)
        Me.rb_presupuesto.Name = "rb_presupuesto"
        Me.rb_presupuesto.Size = New System.Drawing.Size(84, 17)
        Me.rb_presupuesto.TabIndex = 47
        Me.rb_presupuesto.TabStop = True
        Me.rb_presupuesto.Text = "Presupuesto"
        Me.rb_presupuesto.UseVisualStyleBackColor = True
        '
        'chk_testing
        '
        Me.chk_testing.AutoSize = True
        Me.chk_testing.Location = New System.Drawing.Point(250, 283)
        Me.chk_testing.Name = "chk_testing"
        Me.chk_testing.Size = New System.Drawing.Size(136, 17)
        Me.chk_testing.TabIndex = 56
        Me.chk_testing.Text = "Comprobante de testeo"
        Me.chk_testing.UseVisualStyleBackColor = True
        '
        'nup_maxItems
        '
        Me.nup_maxItems.Location = New System.Drawing.Point(159, 131)
        Me.nup_maxItems.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nup_maxItems.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nup_maxItems.Name = "nup_maxItems"
        Me.nup_maxItems.Size = New System.Drawing.Size(202, 20)
        Me.nup_maxItems.TabIndex = 59
        Me.nup_maxItems.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'lbl_maxItems
        '
        Me.lbl_maxItems.AutoSize = True
        Me.lbl_maxItems.Location = New System.Drawing.Point(12, 131)
        Me.lbl_maxItems.Name = "lbl_maxItems"
        Me.lbl_maxItems.Size = New System.Drawing.Size(129, 13)
        Me.lbl_maxItems.TabIndex = 58
        Me.lbl_maxItems.Text = "Cantidad máxima de items"
        '
        'chk_contabilizar
        '
        Me.chk_contabilizar.AutoSize = True
        Me.chk_contabilizar.Location = New System.Drawing.Point(106, 315)
        Me.chk_contabilizar.Name = "chk_contabilizar"
        Me.chk_contabilizar.Size = New System.Drawing.Size(80, 17)
        Me.chk_contabilizar.TabIndex = 60
        Me.chk_contabilizar.Text = "Contabilizar"
        Me.chk_contabilizar.UseVisualStyleBackColor = True
        '
        'TC
        '
        Me.TC.Controls.Add(Me.t_general)
        Me.TC.Controls.Add(Me.t_mipyme)
        Me.TC.Location = New System.Drawing.Point(16, 12)
        Me.TC.Name = "TC"
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(570, 371)
        Me.TC.TabIndex = 61
        '
        't_general
        '
        Me.t_general.BackColor = System.Drawing.SystemColors.Control
        Me.t_general.Controls.Add(Me.chk_mueveStock)
        Me.t_general.Controls.Add(Me.lbl_comprobante)
        Me.t_general.Controls.Add(Me.chk_contabilizar)
        Me.t_general.Controls.Add(Me.lbl_puntoVenta)
        Me.t_general.Controls.Add(Me.nup_maxItems)
        Me.t_general.Controls.Add(Me.lbl_numero)
        Me.t_general.Controls.Add(Me.lbl_maxItems)
        Me.t_general.Controls.Add(Me.lbl_tipoComprobante)
        Me.t_general.Controls.Add(Me.chk_testing)
        Me.t_general.Controls.Add(Me.chk_activo)
        Me.t_general.Controls.Add(Me.gb_tipoComprobante)
        Me.t_general.Controls.Add(Me.txt_comprobante)
        Me.t_general.Controls.Add(Me.cmb_tipoComprobante)
        Me.t_general.Controls.Add(Me.nup_numero)
        Me.t_general.Controls.Add(Me.nup_puntoVenta)
        Me.t_general.Location = New System.Drawing.Point(4, 22)
        Me.t_general.Name = "t_general"
        Me.t_general.Padding = New System.Windows.Forms.Padding(3)
        Me.t_general.Size = New System.Drawing.Size(562, 345)
        Me.t_general.TabIndex = 0
        Me.t_general.Text = "General"
        '
        'chk_mueveStock
        '
        Me.chk_mueveStock.AutoSize = True
        Me.chk_mueveStock.Location = New System.Drawing.Point(250, 315)
        Me.chk_mueveStock.Name = "chk_mueveStock"
        Me.chk_mueveStock.Size = New System.Drawing.Size(88, 17)
        Me.chk_mueveStock.TabIndex = 62
        Me.chk_mueveStock.Text = "Mueve stock"
        Me.chk_mueveStock.UseVisualStyleBackColor = True
        '
        't_mipyme
        '
        Me.t_mipyme.BackColor = System.Drawing.SystemColors.Control
        Me.t_mipyme.Controls.Add(Me.txt_comprobanteAnulacion)
        Me.t_mipyme.Controls.Add(Me.lbl_comprobanteAnulación)
        Me.t_mipyme.Controls.Add(Me.lbl_modoMiPyme)
        Me.t_mipyme.Controls.Add(Me.cmb_modoMiPyme)
        Me.t_mipyme.Controls.Add(Me.lbl_alias_CBU_emisor)
        Me.t_mipyme.Controls.Add(Me.txt_alias_CBU_emisor)
        Me.t_mipyme.Controls.Add(Me.lbl_CBU_emisor)
        Me.t_mipyme.Controls.Add(Me.txt_CBU_emisor)
        Me.t_mipyme.Controls.Add(Me.chk_esMipyme)
        Me.t_mipyme.Controls.Add(Me.lbl_comprobanteRelacionado)
        Me.t_mipyme.Controls.Add(Me.cmb_comprobanteRelacionado)
        Me.t_mipyme.Location = New System.Drawing.Point(4, 22)
        Me.t_mipyme.Name = "t_mipyme"
        Me.t_mipyme.Padding = New System.Windows.Forms.Padding(3)
        Me.t_mipyme.Size = New System.Drawing.Size(562, 345)
        Me.t_mipyme.TabIndex = 1
        Me.t_mipyme.Text = "MiPyme"
        '
        'lbl_alias_CBU_emisor
        '
        Me.lbl_alias_CBU_emisor.AutoSize = True
        Me.lbl_alias_CBU_emisor.Location = New System.Drawing.Point(16, 134)
        Me.lbl_alias_CBU_emisor.Name = "lbl_alias_CBU_emisor"
        Me.lbl_alias_CBU_emisor.Size = New System.Drawing.Size(87, 13)
        Me.lbl_alias_CBU_emisor.TabIndex = 58
        Me.lbl_alias_CBU_emisor.Text = "Alias CBU emisor"
        '
        'txt_alias_CBU_emisor
        '
        Me.txt_alias_CBU_emisor.Location = New System.Drawing.Point(163, 127)
        Me.txt_alias_CBU_emisor.MaxLength = 45
        Me.txt_alias_CBU_emisor.Name = "txt_alias_CBU_emisor"
        Me.txt_alias_CBU_emisor.Size = New System.Drawing.Size(388, 20)
        Me.txt_alias_CBU_emisor.TabIndex = 59
        '
        'lbl_CBU_emisor
        '
        Me.lbl_CBU_emisor.AutoSize = True
        Me.lbl_CBU_emisor.Location = New System.Drawing.Point(16, 74)
        Me.lbl_CBU_emisor.Name = "lbl_CBU_emisor"
        Me.lbl_CBU_emisor.Size = New System.Drawing.Size(63, 13)
        Me.lbl_CBU_emisor.TabIndex = 56
        Me.lbl_CBU_emisor.Text = "CBU Emisor"
        '
        'txt_CBU_emisor
        '
        Me.txt_CBU_emisor.Location = New System.Drawing.Point(163, 67)
        Me.txt_CBU_emisor.MaxLength = 45
        Me.txt_CBU_emisor.Name = "txt_CBU_emisor"
        Me.txt_CBU_emisor.Size = New System.Drawing.Size(388, 20)
        Me.txt_CBU_emisor.TabIndex = 57
        '
        'chk_esMipyme
        '
        Me.chk_esMipyme.AutoSize = True
        Me.chk_esMipyme.Location = New System.Drawing.Point(19, 23)
        Me.chk_esMipyme.Name = "chk_esMipyme"
        Me.chk_esMipyme.Size = New System.Drawing.Size(145, 17)
        Me.chk_esMipyme.TabIndex = 55
        Me.chk_esMipyme.Text = "Es comprobante MiPyME"
        Me.chk_esMipyme.UseVisualStyleBackColor = True
        '
        'lbl_comprobanteRelacionado
        '
        Me.lbl_comprobanteRelacionado.AutoSize = True
        Me.lbl_comprobanteRelacionado.Location = New System.Drawing.Point(16, 299)
        Me.lbl_comprobanteRelacionado.Name = "lbl_comprobanteRelacionado"
        Me.lbl_comprobanteRelacionado.Size = New System.Drawing.Size(128, 13)
        Me.lbl_comprobanteRelacionado.TabIndex = 53
        Me.lbl_comprobanteRelacionado.Text = "Comprobante relacionado"
        Me.lbl_comprobanteRelacionado.Visible = False
        '
        'cmb_comprobanteRelacionado
        '
        Me.cmb_comprobanteRelacionado.FormattingEnabled = True
        Me.cmb_comprobanteRelacionado.Location = New System.Drawing.Point(163, 294)
        Me.cmb_comprobanteRelacionado.Name = "cmb_comprobanteRelacionado"
        Me.cmb_comprobanteRelacionado.Size = New System.Drawing.Size(388, 21)
        Me.cmb_comprobanteRelacionado.TabIndex = 54
        Me.cmb_comprobanteRelacionado.Visible = False
        '
        'lbl_modoMiPyme
        '
        Me.lbl_modoMiPyme.AutoSize = True
        Me.lbl_modoMiPyme.Location = New System.Drawing.Point(16, 244)
        Me.lbl_modoMiPyme.Name = "lbl_modoMiPyme"
        Me.lbl_modoMiPyme.Size = New System.Drawing.Size(74, 13)
        Me.lbl_modoMiPyme.TabIndex = 61
        Me.lbl_modoMiPyme.Text = "Modo MiPyme"
        '
        'cmb_modoMiPyme
        '
        Me.cmb_modoMiPyme.FormattingEnabled = True
        Me.cmb_modoMiPyme.Location = New System.Drawing.Point(163, 239)
        Me.cmb_modoMiPyme.Name = "cmb_modoMiPyme"
        Me.cmb_modoMiPyme.Size = New System.Drawing.Size(388, 21)
        Me.cmb_modoMiPyme.TabIndex = 62
        '
        'lbl_comprobanteAnulación
        '
        Me.lbl_comprobanteAnulación.AutoSize = True
        Me.lbl_comprobanteAnulación.Location = New System.Drawing.Point(16, 187)
        Me.lbl_comprobanteAnulación.Name = "lbl_comprobanteAnulación"
        Me.lbl_comprobanteAnulación.Size = New System.Drawing.Size(160, 13)
        Me.lbl_comprobanteAnulación.TabIndex = 63
        Me.lbl_comprobanteAnulación.Text = "¿Es comprobante de anulación?"
        Me.tt_comprobanteAnulacion.SetToolTip(Me.lbl_comprobanteAnulación, "Si el cliente ya anuló el comprobante ponga una S, caso contrario ponga una N")
        '
        'txt_comprobanteAnulacion
        '
        Me.txt_comprobanteAnulacion.Location = New System.Drawing.Point(194, 180)
        Me.txt_comprobanteAnulacion.MaxLength = 1
        Me.txt_comprobanteAnulacion.Name = "txt_comprobanteAnulacion"
        Me.txt_comprobanteAnulacion.Size = New System.Drawing.Size(63, 20)
        Me.txt_comprobanteAnulacion.TabIndex = 62
        Me.tt_comprobanteAnulacion.SetToolTip(Me.txt_comprobanteAnulacion, "Si el cliente ya anuló el comprobante ponga una S, caso contrario ponga una N")
        '
        'add_comprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 507)
        Me.Controls.Add(Me.TC)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Name = "add_comprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar comprobante"
        CType(Me.nup_puntoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nup_numero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_tipoComprobante.ResumeLayout(False)
        Me.gb_tipoComprobante.PerformLayout()
        CType(Me.nup_maxItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TC.ResumeLayout(False)
        Me.t_general.ResumeLayout(False)
        Me.t_general.PerformLayout()
        Me.t_mipyme.ResumeLayout(False)
        Me.t_mipyme.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_comprobante As System.Windows.Forms.Label
    Friend WithEvents lbl_puntoVenta As System.Windows.Forms.Label
    Friend WithEvents lbl_numero As System.Windows.Forms.Label
    Friend WithEvents lbl_tipoComprobante As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents rb_fiscal As System.Windows.Forms.RadioButton
    Friend WithEvents rb_electronico As System.Windows.Forms.RadioButton
    Friend WithEvents rb_manual As System.Windows.Forms.RadioButton
    Friend WithEvents txt_comprobante As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents nup_puntoVenta As System.Windows.Forms.NumericUpDown
    Friend WithEvents nup_numero As System.Windows.Forms.NumericUpDown
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents gb_tipoComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents rb_presupuesto As System.Windows.Forms.RadioButton
    Friend WithEvents chk_testing As System.Windows.Forms.CheckBox
    Friend WithEvents nup_maxItems As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl_maxItems As System.Windows.Forms.Label
    Friend WithEvents chk_contabilizar As CheckBox
    Friend WithEvents TC As TabControl
    Friend WithEvents t_general As TabPage
    Friend WithEvents t_mipyme As TabPage
    Friend WithEvents lbl_alias_CBU_emisor As Label
    Friend WithEvents txt_alias_CBU_emisor As TextBox
    Friend WithEvents lbl_CBU_emisor As Label
    Friend WithEvents txt_CBU_emisor As TextBox
    Friend WithEvents chk_esMipyme As CheckBox
    Friend WithEvents lbl_comprobanteRelacionado As Label
    Friend WithEvents cmb_comprobanteRelacionado As ComboBox
    Friend WithEvents chk_mueveStock As CheckBox
    Friend WithEvents lbl_modoMiPyme As Label
    Friend WithEvents cmb_modoMiPyme As ComboBox
    Friend WithEvents txt_comprobanteAnulacion As TextBox
    Friend WithEvents tt_comprobanteAnulacion As ToolTip
    Friend WithEvents lbl_comprobanteAnulación As Label
End Class
