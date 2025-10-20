<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_proveedor
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_general = New System.Windows.Forms.TabPage()
        Me.cmb_claseFiscal = New System.Windows.Forms.ComboBox()
        Me.lbl_claseFiscal = New System.Windows.Forms.Label()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.lbl_vendedor = New System.Windows.Forms.Label()
        Me.cmb_tipoDocumento = New System.Windows.Forms.ComboBox()
        Me.lbl_tipoDocumento = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.lbl_email = New System.Windows.Forms.Label()
        Me.txt_contacto = New System.Windows.Forms.TextBox()
        Me.lbl_contacto = New System.Windows.Forms.Label()
        Me.txt_telefono = New System.Windows.Forms.TextBox()
        Me.lbl_tel = New System.Windows.Forms.Label()
        Me.txt_taxNumber = New System.Windows.Forms.TextBox()
        Me.lbl_taxNumber = New System.Windows.Forms.Label()
        Me.txt_celular = New System.Windows.Forms.TextBox()
        Me.lbl_celular = New System.Windows.Forms.Label()
        Me.txt_razonSocial = New System.Windows.Forms.TextBox()
        Me.lbl_razonSocial = New System.Windows.Forms.Label()
        Me.tab_fiscal = New System.Windows.Forms.TabPage()
        Me.lbl_cpFiscal = New System.Windows.Forms.Label()
        Me.txt_cpFiscal = New System.Windows.Forms.TextBox()
        Me.cmb_paisFiscal = New System.Windows.Forms.ComboBox()
        Me.lbl_paisFiscal = New System.Windows.Forms.Label()
        Me.cmb_provinciaFiscal = New System.Windows.Forms.ComboBox()
        Me.txt_direccionFiscal = New System.Windows.Forms.TextBox()
        Me.lbl_direccionFiscal = New System.Windows.Forms.Label()
        Me.lbl_provinciaFiscal = New System.Windows.Forms.Label()
        Me.lbl_localidadFiscal = New System.Windows.Forms.Label()
        Me.txt_localidadFiscal = New System.Windows.Forms.TextBox()
        Me.tab_entrega = New System.Windows.Forms.TabPage()
        Me.lbl_cpEntrega = New System.Windows.Forms.Label()
        Me.txt_cpEntrega = New System.Windows.Forms.TextBox()
        Me.cmb_paisEntrega = New System.Windows.Forms.ComboBox()
        Me.lbl_paisEntrega = New System.Windows.Forms.Label()
        Me.cmb_provinciaEntrega = New System.Windows.Forms.ComboBox()
        Me.txt_direccionEntrega = New System.Windows.Forms.TextBox()
        Me.lbl_direccionEntrega = New System.Windows.Forms.Label()
        Me.lbl_provinciaEntrega = New System.Windows.Forms.Label()
        Me.lbl_localidadEntrega = New System.Windows.Forms.Label()
        Me.txt_localidadEntrega = New System.Windows.Forms.TextBox()
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.chk_esInscripto = New System.Windows.Forms.CheckBox()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tab_general.SuspendLayout()
        Me.tab_fiscal.SuspendLayout()
        Me.tab_entrega.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_general)
        Me.TabControl1.Controls.Add(Me.tab_fiscal)
        Me.TabControl1.Controls.Add(Me.tab_entrega)
        Me.TabControl1.Location = New System.Drawing.Point(17, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(349, 376)
        Me.TabControl1.TabIndex = 0
        '
        'tab_general
        '
        Me.tab_general.BackColor = System.Drawing.SystemColors.Control
        Me.tab_general.Controls.Add(Me.cmb_claseFiscal)
        Me.tab_general.Controls.Add(Me.lbl_claseFiscal)
        Me.tab_general.Controls.Add(Me.txt_vendedor)
        Me.tab_general.Controls.Add(Me.lbl_vendedor)
        Me.tab_general.Controls.Add(Me.cmb_tipoDocumento)
        Me.tab_general.Controls.Add(Me.lbl_tipoDocumento)
        Me.tab_general.Controls.Add(Me.txt_email)
        Me.tab_general.Controls.Add(Me.lbl_email)
        Me.tab_general.Controls.Add(Me.txt_contacto)
        Me.tab_general.Controls.Add(Me.lbl_contacto)
        Me.tab_general.Controls.Add(Me.txt_telefono)
        Me.tab_general.Controls.Add(Me.lbl_tel)
        Me.tab_general.Controls.Add(Me.txt_taxNumber)
        Me.tab_general.Controls.Add(Me.lbl_taxNumber)
        Me.tab_general.Controls.Add(Me.txt_celular)
        Me.tab_general.Controls.Add(Me.lbl_celular)
        Me.tab_general.Controls.Add(Me.txt_razonSocial)
        Me.tab_general.Controls.Add(Me.lbl_razonSocial)
        Me.tab_general.Location = New System.Drawing.Point(4, 22)
        Me.tab_general.Name = "tab_general"
        Me.tab_general.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_general.Size = New System.Drawing.Size(341, 350)
        Me.tab_general.TabIndex = 0
        Me.tab_general.Text = "General"
        '
        'cmb_claseFiscal
        '
        Me.cmb_claseFiscal.FormattingEnabled = True
        Me.cmb_claseFiscal.Location = New System.Drawing.Point(149, 66)
        Me.cmb_claseFiscal.Name = "cmb_claseFiscal"
        Me.cmb_claseFiscal.Size = New System.Drawing.Size(163, 21)
        Me.cmb_claseFiscal.TabIndex = 1
        '
        'lbl_claseFiscal
        '
        Me.lbl_claseFiscal.AutoSize = True
        Me.lbl_claseFiscal.Location = New System.Drawing.Point(28, 69)
        Me.lbl_claseFiscal.Name = "lbl_claseFiscal"
        Me.lbl_claseFiscal.Size = New System.Drawing.Size(60, 13)
        Me.lbl_claseFiscal.TabIndex = 63
        Me.lbl_claseFiscal.Text = "Clase fiscal"
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Location = New System.Drawing.Point(149, 204)
        Me.txt_vendedor.MaxLength = 45
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(163, 20)
        Me.txt_vendedor.TabIndex = 5
        '
        'lbl_vendedor
        '
        Me.lbl_vendedor.AutoSize = True
        Me.lbl_vendedor.Location = New System.Drawing.Point(28, 205)
        Me.lbl_vendedor.Name = "lbl_vendedor"
        Me.lbl_vendedor.Size = New System.Drawing.Size(53, 13)
        Me.lbl_vendedor.TabIndex = 61
        Me.lbl_vendedor.Text = "Vendedor"
        '
        'cmb_tipoDocumento
        '
        Me.cmb_tipoDocumento.FormattingEnabled = True
        Me.cmb_tipoDocumento.Location = New System.Drawing.Point(149, 101)
        Me.cmb_tipoDocumento.Name = "cmb_tipoDocumento"
        Me.cmb_tipoDocumento.Size = New System.Drawing.Size(163, 21)
        Me.cmb_tipoDocumento.TabIndex = 2
        '
        'lbl_tipoDocumento
        '
        Me.lbl_tipoDocumento.AutoSize = True
        Me.lbl_tipoDocumento.Location = New System.Drawing.Point(28, 103)
        Me.lbl_tipoDocumento.Name = "lbl_tipoDocumento"
        Me.lbl_tipoDocumento.Size = New System.Drawing.Size(99, 13)
        Me.lbl_tipoDocumento.TabIndex = 59
        Me.lbl_tipoDocumento.Text = "Tipo de documento"
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(149, 306)
        Me.txt_email.MaxLength = 45
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(163, 20)
        Me.txt_email.TabIndex = 8
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Location = New System.Drawing.Point(28, 307)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(32, 13)
        Me.lbl_email.TabIndex = 58
        Me.lbl_email.Text = "Email"
        '
        'txt_contacto
        '
        Me.txt_contacto.Location = New System.Drawing.Point(149, 170)
        Me.txt_contacto.MaxLength = 45
        Me.txt_contacto.Name = "txt_contacto"
        Me.txt_contacto.Size = New System.Drawing.Size(163, 20)
        Me.txt_contacto.TabIndex = 4
        '
        'lbl_contacto
        '
        Me.lbl_contacto.AutoSize = True
        Me.lbl_contacto.Location = New System.Drawing.Point(28, 171)
        Me.lbl_contacto.Name = "lbl_contacto"
        Me.lbl_contacto.Size = New System.Drawing.Size(50, 13)
        Me.lbl_contacto.TabIndex = 56
        Me.lbl_contacto.Text = "Contacto"
        '
        'txt_telefono
        '
        Me.txt_telefono.Location = New System.Drawing.Point(149, 238)
        Me.txt_telefono.MaxLength = 45
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(163, 20)
        Me.txt_telefono.TabIndex = 6
        '
        'lbl_tel
        '
        Me.lbl_tel.AutoSize = True
        Me.lbl_tel.Location = New System.Drawing.Point(28, 239)
        Me.lbl_tel.Name = "lbl_tel"
        Me.lbl_tel.Size = New System.Drawing.Size(49, 13)
        Me.lbl_tel.TabIndex = 55
        Me.lbl_tel.Text = "Teléfono"
        '
        'txt_taxNumber
        '
        Me.txt_taxNumber.Location = New System.Drawing.Point(149, 136)
        Me.txt_taxNumber.MaxLength = 13
        Me.txt_taxNumber.Name = "txt_taxNumber"
        Me.txt_taxNumber.Size = New System.Drawing.Size(163, 20)
        Me.txt_taxNumber.TabIndex = 3
        '
        'lbl_taxNumber
        '
        Me.lbl_taxNumber.AutoSize = True
        Me.lbl_taxNumber.Location = New System.Drawing.Point(28, 137)
        Me.lbl_taxNumber.Name = "lbl_taxNumber"
        Me.lbl_taxNumber.Size = New System.Drawing.Size(85, 13)
        Me.lbl_taxNumber.TabIndex = 53
        Me.lbl_taxNumber.Text = "CUIT/CUIL/DNI"
        '
        'txt_celular
        '
        Me.txt_celular.Location = New System.Drawing.Point(149, 272)
        Me.txt_celular.MaxLength = 45
        Me.txt_celular.Name = "txt_celular"
        Me.txt_celular.Size = New System.Drawing.Size(163, 20)
        Me.txt_celular.TabIndex = 7
        '
        'lbl_celular
        '
        Me.lbl_celular.AutoSize = True
        Me.lbl_celular.Location = New System.Drawing.Point(28, 273)
        Me.lbl_celular.Name = "lbl_celular"
        Me.lbl_celular.Size = New System.Drawing.Size(39, 13)
        Me.lbl_celular.TabIndex = 50
        Me.lbl_celular.Text = "Celular"
        '
        'txt_razonSocial
        '
        Me.txt_razonSocial.Location = New System.Drawing.Point(149, 32)
        Me.txt_razonSocial.MaxLength = 45
        Me.txt_razonSocial.Name = "txt_razonSocial"
        Me.txt_razonSocial.Size = New System.Drawing.Size(163, 20)
        Me.txt_razonSocial.TabIndex = 0
        '
        'lbl_razonSocial
        '
        Me.lbl_razonSocial.AutoSize = True
        Me.lbl_razonSocial.Location = New System.Drawing.Point(28, 35)
        Me.lbl_razonSocial.Name = "lbl_razonSocial"
        Me.lbl_razonSocial.Size = New System.Drawing.Size(68, 13)
        Me.lbl_razonSocial.TabIndex = 47
        Me.lbl_razonSocial.Text = "Razón social"
        '
        'tab_fiscal
        '
        Me.tab_fiscal.BackColor = System.Drawing.SystemColors.Control
        Me.tab_fiscal.Controls.Add(Me.lbl_cpFiscal)
        Me.tab_fiscal.Controls.Add(Me.txt_cpFiscal)
        Me.tab_fiscal.Controls.Add(Me.cmb_paisFiscal)
        Me.tab_fiscal.Controls.Add(Me.lbl_paisFiscal)
        Me.tab_fiscal.Controls.Add(Me.cmb_provinciaFiscal)
        Me.tab_fiscal.Controls.Add(Me.txt_direccionFiscal)
        Me.tab_fiscal.Controls.Add(Me.lbl_direccionFiscal)
        Me.tab_fiscal.Controls.Add(Me.lbl_provinciaFiscal)
        Me.tab_fiscal.Controls.Add(Me.lbl_localidadFiscal)
        Me.tab_fiscal.Controls.Add(Me.txt_localidadFiscal)
        Me.tab_fiscal.Location = New System.Drawing.Point(4, 22)
        Me.tab_fiscal.Name = "tab_fiscal"
        Me.tab_fiscal.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_fiscal.Size = New System.Drawing.Size(341, 350)
        Me.tab_fiscal.TabIndex = 1
        Me.tab_fiscal.Text = "Información fiscal"
        '
        'lbl_cpFiscal
        '
        Me.lbl_cpFiscal.AutoSize = True
        Me.lbl_cpFiscal.Location = New System.Drawing.Point(28, 307)
        Me.lbl_cpFiscal.Name = "lbl_cpFiscal"
        Me.lbl_cpFiscal.Size = New System.Drawing.Size(21, 13)
        Me.lbl_cpFiscal.TabIndex = 43
        Me.lbl_cpFiscal.Text = "CP"
        '
        'txt_cpFiscal
        '
        Me.txt_cpFiscal.Location = New System.Drawing.Point(149, 300)
        Me.txt_cpFiscal.MaxLength = 200
        Me.txt_cpFiscal.Name = "txt_cpFiscal"
        Me.txt_cpFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_cpFiscal.TabIndex = 13
        '
        'cmb_paisFiscal
        '
        Me.cmb_paisFiscal.FormattingEnabled = True
        Me.cmb_paisFiscal.Location = New System.Drawing.Point(149, 27)
        Me.cmb_paisFiscal.Name = "cmb_paisFiscal"
        Me.cmb_paisFiscal.Size = New System.Drawing.Size(163, 21)
        Me.cmb_paisFiscal.TabIndex = 9
        '
        'lbl_paisFiscal
        '
        Me.lbl_paisFiscal.AutoSize = True
        Me.lbl_paisFiscal.Location = New System.Drawing.Point(28, 35)
        Me.lbl_paisFiscal.Name = "lbl_paisFiscal"
        Me.lbl_paisFiscal.Size = New System.Drawing.Size(29, 13)
        Me.lbl_paisFiscal.TabIndex = 40
        Me.lbl_paisFiscal.Text = "País"
        '
        'cmb_provinciaFiscal
        '
        Me.cmb_provinciaFiscal.FormattingEnabled = True
        Me.cmb_provinciaFiscal.Location = New System.Drawing.Point(149, 95)
        Me.cmb_provinciaFiscal.Name = "cmb_provinciaFiscal"
        Me.cmb_provinciaFiscal.Size = New System.Drawing.Size(163, 21)
        Me.cmb_provinciaFiscal.TabIndex = 10
        '
        'txt_direccionFiscal
        '
        Me.txt_direccionFiscal.Location = New System.Drawing.Point(149, 164)
        Me.txt_direccionFiscal.MaxLength = 200
        Me.txt_direccionFiscal.Name = "txt_direccionFiscal"
        Me.txt_direccionFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_direccionFiscal.TabIndex = 11
        '
        'lbl_direccionFiscal
        '
        Me.lbl_direccionFiscal.AutoSize = True
        Me.lbl_direccionFiscal.Location = New System.Drawing.Point(28, 171)
        Me.lbl_direccionFiscal.Name = "lbl_direccionFiscal"
        Me.lbl_direccionFiscal.Size = New System.Drawing.Size(79, 13)
        Me.lbl_direccionFiscal.TabIndex = 6
        Me.lbl_direccionFiscal.Text = "Dirección fiscal"
        '
        'lbl_provinciaFiscal
        '
        Me.lbl_provinciaFiscal.AutoSize = True
        Me.lbl_provinciaFiscal.Location = New System.Drawing.Point(28, 103)
        Me.lbl_provinciaFiscal.Name = "lbl_provinciaFiscal"
        Me.lbl_provinciaFiscal.Size = New System.Drawing.Size(51, 13)
        Me.lbl_provinciaFiscal.TabIndex = 35
        Me.lbl_provinciaFiscal.Text = "Provincia"
        '
        'lbl_localidadFiscal
        '
        Me.lbl_localidadFiscal.AutoSize = True
        Me.lbl_localidadFiscal.Location = New System.Drawing.Point(28, 239)
        Me.lbl_localidadFiscal.Name = "lbl_localidadFiscal"
        Me.lbl_localidadFiscal.Size = New System.Drawing.Size(53, 13)
        Me.lbl_localidadFiscal.TabIndex = 38
        Me.lbl_localidadFiscal.Text = "Localidad"
        '
        'txt_localidadFiscal
        '
        Me.txt_localidadFiscal.Location = New System.Drawing.Point(149, 232)
        Me.txt_localidadFiscal.MaxLength = 200
        Me.txt_localidadFiscal.Name = "txt_localidadFiscal"
        Me.txt_localidadFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_localidadFiscal.TabIndex = 12
        '
        'tab_entrega
        '
        Me.tab_entrega.BackColor = System.Drawing.SystemColors.Control
        Me.tab_entrega.Controls.Add(Me.lbl_cpEntrega)
        Me.tab_entrega.Controls.Add(Me.txt_cpEntrega)
        Me.tab_entrega.Controls.Add(Me.cmb_paisEntrega)
        Me.tab_entrega.Controls.Add(Me.lbl_paisEntrega)
        Me.tab_entrega.Controls.Add(Me.cmb_provinciaEntrega)
        Me.tab_entrega.Controls.Add(Me.txt_direccionEntrega)
        Me.tab_entrega.Controls.Add(Me.lbl_direccionEntrega)
        Me.tab_entrega.Controls.Add(Me.lbl_provinciaEntrega)
        Me.tab_entrega.Controls.Add(Me.lbl_localidadEntrega)
        Me.tab_entrega.Controls.Add(Me.txt_localidadEntrega)
        Me.tab_entrega.Location = New System.Drawing.Point(4, 22)
        Me.tab_entrega.Name = "tab_entrega"
        Me.tab_entrega.Size = New System.Drawing.Size(341, 350)
        Me.tab_entrega.TabIndex = 2
        Me.tab_entrega.Text = "Información de entrega"
        '
        'lbl_cpEntrega
        '
        Me.lbl_cpEntrega.AutoSize = True
        Me.lbl_cpEntrega.Location = New System.Drawing.Point(28, 307)
        Me.lbl_cpEntrega.Name = "lbl_cpEntrega"
        Me.lbl_cpEntrega.Size = New System.Drawing.Size(21, 13)
        Me.lbl_cpEntrega.TabIndex = 6
        Me.lbl_cpEntrega.Text = "CP"
        '
        'txt_cpEntrega
        '
        Me.txt_cpEntrega.Location = New System.Drawing.Point(149, 300)
        Me.txt_cpEntrega.MaxLength = 200
        Me.txt_cpEntrega.Name = "txt_cpEntrega"
        Me.txt_cpEntrega.Size = New System.Drawing.Size(163, 20)
        Me.txt_cpEntrega.TabIndex = 18
        '
        'cmb_paisEntrega
        '
        Me.cmb_paisEntrega.FormattingEnabled = True
        Me.cmb_paisEntrega.Location = New System.Drawing.Point(149, 27)
        Me.cmb_paisEntrega.Name = "cmb_paisEntrega"
        Me.cmb_paisEntrega.Size = New System.Drawing.Size(163, 21)
        Me.cmb_paisEntrega.TabIndex = 14
        '
        'lbl_paisEntrega
        '
        Me.lbl_paisEntrega.AutoSize = True
        Me.lbl_paisEntrega.Location = New System.Drawing.Point(28, 35)
        Me.lbl_paisEntrega.Name = "lbl_paisEntrega"
        Me.lbl_paisEntrega.Size = New System.Drawing.Size(29, 13)
        Me.lbl_paisEntrega.TabIndex = 1
        Me.lbl_paisEntrega.Text = "País"
        '
        'cmb_provinciaEntrega
        '
        Me.cmb_provinciaEntrega.FormattingEnabled = True
        Me.cmb_provinciaEntrega.Location = New System.Drawing.Point(149, 95)
        Me.cmb_provinciaEntrega.Name = "cmb_provinciaEntrega"
        Me.cmb_provinciaEntrega.Size = New System.Drawing.Size(163, 21)
        Me.cmb_provinciaEntrega.TabIndex = 15
        '
        'txt_direccionEntrega
        '
        Me.txt_direccionEntrega.Location = New System.Drawing.Point(149, 164)
        Me.txt_direccionEntrega.MaxLength = 200
        Me.txt_direccionEntrega.Name = "txt_direccionEntrega"
        Me.txt_direccionEntrega.Size = New System.Drawing.Size(163, 20)
        Me.txt_direccionEntrega.TabIndex = 16
        '
        'lbl_direccionEntrega
        '
        Me.lbl_direccionEntrega.AutoSize = True
        Me.lbl_direccionEntrega.Location = New System.Drawing.Point(28, 171)
        Me.lbl_direccionEntrega.Name = "lbl_direccionEntrega"
        Me.lbl_direccionEntrega.Size = New System.Drawing.Size(79, 13)
        Me.lbl_direccionEntrega.TabIndex = 7
        Me.lbl_direccionEntrega.Text = "Dirección fiscal"
        '
        'lbl_provinciaEntrega
        '
        Me.lbl_provinciaEntrega.AutoSize = True
        Me.lbl_provinciaEntrega.Location = New System.Drawing.Point(28, 103)
        Me.lbl_provinciaEntrega.Name = "lbl_provinciaEntrega"
        Me.lbl_provinciaEntrega.Size = New System.Drawing.Size(51, 13)
        Me.lbl_provinciaEntrega.TabIndex = 7
        Me.lbl_provinciaEntrega.Text = "Provincia"
        '
        'lbl_localidadEntrega
        '
        Me.lbl_localidadEntrega.AutoSize = True
        Me.lbl_localidadEntrega.Location = New System.Drawing.Point(28, 239)
        Me.lbl_localidadEntrega.Name = "lbl_localidadEntrega"
        Me.lbl_localidadEntrega.Size = New System.Drawing.Size(53, 13)
        Me.lbl_localidadEntrega.TabIndex = 8
        Me.lbl_localidadEntrega.Text = "Localidad"
        '
        'txt_localidadEntrega
        '
        Me.txt_localidadEntrega.Location = New System.Drawing.Point(149, 232)
        Me.txt_localidadEntrega.MaxLength = 200
        Me.txt_localidadEntrega.Name = "txt_localidadEntrega"
        Me.txt_localidadEntrega.Size = New System.Drawing.Size(163, 20)
        Me.txt_localidadEntrega.TabIndex = 17
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(396, 39)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.Size = New System.Drawing.Size(349, 354)
        Me.txt_notas.TabIndex = 19
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(393, 17)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 52
        Me.lbl_notas.Text = "Notas"
        '
        'chk_esInscripto
        '
        Me.chk_esInscripto.AutoSize = True
        Me.chk_esInscripto.Location = New System.Drawing.Point(17, 422)
        Me.chk_esInscripto.Name = "chk_esInscripto"
        Me.chk_esInscripto.Size = New System.Drawing.Size(130, 17)
        Me.chk_esInscripto.TabIndex = 20
        Me.chk_esInscripto.Text = "Responsable inscripto"
        Me.chk_esInscripto.UseVisualStyleBackColor = True
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(208, 422)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(107, 17)
        Me.chk_activo.TabIndex = 21
        Me.chk_activo.Text = "Proveedor activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(21, 486)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 22
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(435, 530)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 31
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(337, 530)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 30
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'add_proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 596)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.chk_esInscripto)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_notas)
        Me.Name = "add_proveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar Proveedor"
        Me.TabControl1.ResumeLayout(False)
        Me.tab_general.ResumeLayout(False)
        Me.tab_general.PerformLayout()
        Me.tab_fiscal.ResumeLayout(False)
        Me.tab_fiscal.PerformLayout()
        Me.tab_entrega.ResumeLayout(False)
        Me.tab_entrega.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_general As System.Windows.Forms.TabPage
    Friend WithEvents cmb_tipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipoDocumento As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents lbl_email As System.Windows.Forms.Label
    Friend WithEvents txt_contacto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_contacto As System.Windows.Forms.Label
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tel As System.Windows.Forms.Label
    Friend WithEvents txt_taxNumber As System.Windows.Forms.TextBox
    Friend WithEvents lbl_taxNumber As System.Windows.Forms.Label
    Friend WithEvents txt_celular As System.Windows.Forms.TextBox
    Friend WithEvents lbl_celular As System.Windows.Forms.Label
    Friend WithEvents txt_razonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lbl_razonSocial As System.Windows.Forms.Label
    Friend WithEvents tab_fiscal As System.Windows.Forms.TabPage
    Friend WithEvents lbl_cpFiscal As System.Windows.Forms.Label
    Friend WithEvents txt_cpFiscal As System.Windows.Forms.TextBox
    Friend WithEvents cmb_paisFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_paisFiscal As System.Windows.Forms.Label
    Friend WithEvents cmb_provinciaFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents txt_direccionFiscal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccionFiscal As System.Windows.Forms.Label
    Friend WithEvents lbl_provinciaFiscal As System.Windows.Forms.Label
    Friend WithEvents lbl_localidadFiscal As System.Windows.Forms.Label
    Friend WithEvents txt_localidadFiscal As System.Windows.Forms.TextBox
    Friend WithEvents tab_entrega As System.Windows.Forms.TabPage
    Friend WithEvents lbl_cpEntrega As System.Windows.Forms.Label
    Friend WithEvents txt_cpEntrega As System.Windows.Forms.TextBox
    Friend WithEvents cmb_paisEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_paisEntrega As System.Windows.Forms.Label
    Friend WithEvents cmb_provinciaEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents txt_direccionEntrega As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccionEntrega As System.Windows.Forms.Label
    Friend WithEvents lbl_provinciaEntrega As System.Windows.Forms.Label
    Friend WithEvents lbl_localidadEntrega As System.Windows.Forms.Label
    Friend WithEvents txt_localidadEntrega As System.Windows.Forms.TextBox
    Friend WithEvents txt_notas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_notas As System.Windows.Forms.Label
    Friend WithEvents chk_esInscripto As System.Windows.Forms.CheckBox
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_vendedor As System.Windows.Forms.Label
    Friend WithEvents cmb_claseFiscal As ComboBox
    Friend WithEvents lbl_claseFiscal As Label
End Class
