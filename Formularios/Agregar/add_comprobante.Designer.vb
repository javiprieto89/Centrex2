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
        CType(Me.nup_puntoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nup_numero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_tipoComprobante.SuspendLayout()
        CType(Me.nup_maxItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_comprobante
        '
        Me.lbl_comprobante.AutoSize = True
        Me.lbl_comprobante.Location = New System.Drawing.Point(40, 29)
        Me.lbl_comprobante.Name = "lbl_comprobante"
        Me.lbl_comprobante.Size = New System.Drawing.Size(70, 13)
        Me.lbl_comprobante.TabIndex = 0
        Me.lbl_comprobante.Text = "Comprobante"
        '
        'lbl_puntoVenta
        '
        Me.lbl_puntoVenta.AutoSize = True
        Me.lbl_puntoVenta.Location = New System.Drawing.Point(406, 105)
        Me.lbl_puntoVenta.Name = "lbl_puntoVenta"
        Me.lbl_puntoVenta.Size = New System.Drawing.Size(80, 13)
        Me.lbl_puntoVenta.TabIndex = 2
        Me.lbl_puntoVenta.Text = "Punto de venta"
        '
        'lbl_numero
        '
        Me.lbl_numero.AutoSize = True
        Me.lbl_numero.Location = New System.Drawing.Point(40, 105)
        Me.lbl_numero.Name = "lbl_numero"
        Me.lbl_numero.Size = New System.Drawing.Size(44, 13)
        Me.lbl_numero.TabIndex = 3
        Me.lbl_numero.Text = "Número"
        '
        'lbl_tipoComprobante
        '
        Me.lbl_tipoComprobante.AutoSize = True
        Me.lbl_tipoComprobante.Location = New System.Drawing.Point(40, 67)
        Me.lbl_tipoComprobante.Name = "lbl_tipoComprobante"
        Me.lbl_tipoComprobante.Size = New System.Drawing.Size(108, 13)
        Me.lbl_tipoComprobante.TabIndex = 4
        Me.lbl_tipoComprobante.Text = "Tipo de comprobante"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(134, 293)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(121, 17)
        Me.chk_activo.TabIndex = 38
        Me.chk_activo.Text = "Comprobante activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(319, 453)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 43
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(221, 453)
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
        Me.txt_comprobante.Location = New System.Drawing.Point(187, 22)
        Me.txt_comprobante.MaxLength = 45
        Me.txt_comprobante.Name = "txt_comprobante"
        Me.txt_comprobante.Size = New System.Drawing.Size(388, 20)
        Me.txt_comprobante.TabIndex = 49
        '
        'cmb_tipoComprobante
        '
        Me.cmb_tipoComprobante.FormattingEnabled = True
        Me.cmb_tipoComprobante.Location = New System.Drawing.Point(187, 62)
        Me.cmb_tipoComprobante.Name = "cmb_tipoComprobante"
        Me.cmb_tipoComprobante.Size = New System.Drawing.Size(388, 21)
        Me.cmb_tipoComprobante.TabIndex = 52
        '
        'nup_puntoVenta
        '
        Me.nup_puntoVenta.Location = New System.Drawing.Point(492, 103)
        Me.nup_puntoVenta.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nup_puntoVenta.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nup_puntoVenta.Name = "nup_puntoVenta"
        Me.nup_puntoVenta.Size = New System.Drawing.Size(87, 20)
        Me.nup_puntoVenta.TabIndex = 53
        Me.nup_puntoVenta.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nup_numero
        '
        Me.nup_numero.Location = New System.Drawing.Point(187, 103)
        Me.nup_numero.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nup_numero.Name = "nup_numero"
        Me.nup_numero.Size = New System.Drawing.Size(202, 20)
        Me.nup_numero.TabIndex = 54
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(43, 383)
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
        Me.gb_tipoComprobante.Location = New System.Drawing.Point(134, 180)
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
        Me.chk_testing.Location = New System.Drawing.Point(278, 293)
        Me.chk_testing.Name = "chk_testing"
        Me.chk_testing.Size = New System.Drawing.Size(136, 17)
        Me.chk_testing.TabIndex = 56
        Me.chk_testing.Text = "Comprobante de testeo"
        Me.chk_testing.UseVisualStyleBackColor = True
        '
        'nup_maxItems
        '
        Me.nup_maxItems.Location = New System.Drawing.Point(187, 141)
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
        Me.lbl_maxItems.Location = New System.Drawing.Point(40, 141)
        Me.lbl_maxItems.Name = "lbl_maxItems"
        Me.lbl_maxItems.Size = New System.Drawing.Size(129, 13)
        Me.lbl_maxItems.TabIndex = 58
        Me.lbl_maxItems.Text = "Cantidad máxima de items"
        '
        'add_comprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 507)
        Me.Controls.Add(Me.nup_maxItems)
        Me.Controls.Add(Me.lbl_maxItems)
        Me.Controls.Add(Me.chk_testing)
        Me.Controls.Add(Me.gb_tipoComprobante)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.nup_numero)
        Me.Controls.Add(Me.nup_puntoVenta)
        Me.Controls.Add(Me.cmb_tipoComprobante)
        Me.Controls.Add(Me.txt_comprobante)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.lbl_tipoComprobante)
        Me.Controls.Add(Me.lbl_numero)
        Me.Controls.Add(Me.lbl_puntoVenta)
        Me.Controls.Add(Me.lbl_comprobante)
        Me.Name = "add_comprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar comprobante"
        CType(Me.nup_puntoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nup_numero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_tipoComprobante.ResumeLayout(False)
        Me.gb_tipoComprobante.PerformLayout()
        CType(Me.nup_maxItems, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
