<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_cliente
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
        Me.txt_notas = New System.Windows.Forms.TextBox()
        Me.lbl_notas = New System.Windows.Forms.Label()
        Me.chk_esInscripto = New System.Windows.Forms.CheckBox()
        Me.txt_localidadFiscal = New System.Windows.Forms.TextBox()
        Me.lbl_localidadFiscal = New System.Windows.Forms.Label()
        Me.lbl_provinciaFiscal = New System.Windows.Forms.Label()
        Me.chk_activo = New System.Windows.Forms.CheckBox()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.txt_direccionFiscal = New System.Windows.Forms.TextBox()
        Me.lbl_direccionFiscal = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_general = New System.Windows.Forms.TabPage()
        Me.txt_nombreFantasia = New System.Windows.Forms.TextBox()
        Me.lbl_nombreFantasia = New System.Windows.Forms.Label()
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
        Me.TabControl1.SuspendLayout()
        Me.tab_general.SuspendLayout()
        Me.tab_fiscal.SuspendLayout()
        Me.tab_entrega.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_notas
        '
        Me.txt_notas.Location = New System.Drawing.Point(393, 39)
        Me.txt_notas.Multiline = True
        Me.txt_notas.Name = "txt_notas"
        Me.txt_notas.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_notas.Size = New System.Drawing.Size(349, 311)
        Me.txt_notas.TabIndex = 0
        '
        'lbl_notas
        '
        Me.lbl_notas.AutoSize = True
        Me.lbl_notas.Location = New System.Drawing.Point(390, 17)
        Me.lbl_notas.Name = "lbl_notas"
        Me.lbl_notas.Size = New System.Drawing.Size(35, 13)
        Me.lbl_notas.TabIndex = 44
        Me.lbl_notas.Text = "Notas"
        '
        'chk_esInscripto
        '
        Me.chk_esInscripto.AutoSize = True
        Me.chk_esInscripto.Location = New System.Drawing.Point(14, 392)
        Me.chk_esInscripto.Name = "chk_esInscripto"
        Me.chk_esInscripto.Size = New System.Drawing.Size(130, 17)
        Me.chk_esInscripto.TabIndex = 1
        Me.chk_esInscripto.Text = "Responsable inscripto"
        Me.chk_esInscripto.UseVisualStyleBackColor = True
        '
        'txt_localidadFiscal
        '
        Me.txt_localidadFiscal.Location = New System.Drawing.Point(149, 185)
        Me.txt_localidadFiscal.MaxLength = 200
        Me.txt_localidadFiscal.Name = "txt_localidadFiscal"
        Me.txt_localidadFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_localidadFiscal.TabIndex = 11
        '
        'lbl_localidadFiscal
        '
        Me.lbl_localidadFiscal.AutoSize = True
        Me.lbl_localidadFiscal.Location = New System.Drawing.Point(28, 185)
        Me.lbl_localidadFiscal.Name = "lbl_localidadFiscal"
        Me.lbl_localidadFiscal.Size = New System.Drawing.Size(53, 13)
        Me.lbl_localidadFiscal.TabIndex = 38
        Me.lbl_localidadFiscal.Text = "Localidad"
        '
        'lbl_provinciaFiscal
        '
        Me.lbl_provinciaFiscal.AutoSize = True
        Me.lbl_provinciaFiscal.Location = New System.Drawing.Point(28, 85)
        Me.lbl_provinciaFiscal.Name = "lbl_provinciaFiscal"
        Me.lbl_provinciaFiscal.Size = New System.Drawing.Size(51, 13)
        Me.lbl_provinciaFiscal.TabIndex = 35
        Me.lbl_provinciaFiscal.Text = "Provincia"
        '
        'chk_activo
        '
        Me.chk_activo.AutoSize = True
        Me.chk_activo.Location = New System.Drawing.Point(205, 392)
        Me.chk_activo.Name = "chk_activo"
        Me.chk_activo.Size = New System.Drawing.Size(90, 17)
        Me.chk_activo.TabIndex = 2
        Me.chk_activo.Text = "Cliente activo"
        Me.chk_activo.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(18, 441)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 3
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(432, 485)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(334, 485)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'txt_direccionFiscal
        '
        Me.txt_direccionFiscal.Location = New System.Drawing.Point(149, 135)
        Me.txt_direccionFiscal.MaxLength = 200
        Me.txt_direccionFiscal.Name = "txt_direccionFiscal"
        Me.txt_direccionFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_direccionFiscal.TabIndex = 10
        '
        'lbl_direccionFiscal
        '
        Me.lbl_direccionFiscal.AutoSize = True
        Me.lbl_direccionFiscal.Location = New System.Drawing.Point(28, 135)
        Me.lbl_direccionFiscal.Name = "lbl_direccionFiscal"
        Me.lbl_direccionFiscal.Size = New System.Drawing.Size(79, 13)
        Me.lbl_direccionFiscal.TabIndex = 33
        Me.lbl_direccionFiscal.Text = "Dirección fiscal"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_general)
        Me.TabControl1.Controls.Add(Me.tab_fiscal)
        Me.TabControl1.Controls.Add(Me.tab_entrega)
        Me.TabControl1.Location = New System.Drawing.Point(14, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(349, 354)
        Me.TabControl1.TabIndex = 0
        '
        'tab_general
        '
        Me.tab_general.BackColor = System.Drawing.SystemColors.Control
        Me.tab_general.Controls.Add(Me.txt_nombreFantasia)
        Me.tab_general.Controls.Add(Me.lbl_nombreFantasia)
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
        Me.tab_general.Size = New System.Drawing.Size(341, 328)
        Me.tab_general.TabIndex = 0
        Me.tab_general.Text = "General"
        '
        'txt_nombreFantasia
        '
        Me.txt_nombreFantasia.Location = New System.Drawing.Point(149, 93)
        Me.txt_nombreFantasia.MaxLength = 45
        Me.txt_nombreFantasia.Name = "txt_nombreFantasia"
        Me.txt_nombreFantasia.Size = New System.Drawing.Size(163, 20)
        Me.txt_nombreFantasia.TabIndex = 2
        '
        'lbl_nombreFantasia
        '
        Me.lbl_nombreFantasia.AutoSize = True
        Me.lbl_nombreFantasia.Location = New System.Drawing.Point(28, 96)
        Me.lbl_nombreFantasia.Name = "lbl_nombreFantasia"
        Me.lbl_nombreFantasia.Size = New System.Drawing.Size(101, 13)
        Me.lbl_nombreFantasia.TabIndex = 61
        Me.lbl_nombreFantasia.Text = "Nombre de fantasía"
        '
        'cmb_tipoDocumento
        '
        Me.cmb_tipoDocumento.FormattingEnabled = True
        Me.cmb_tipoDocumento.Location = New System.Drawing.Point(149, 129)
        Me.cmb_tipoDocumento.Name = "cmb_tipoDocumento"
        Me.cmb_tipoDocumento.Size = New System.Drawing.Size(163, 21)
        Me.cmb_tipoDocumento.TabIndex = 3
        '
        'lbl_tipoDocumento
        '
        Me.lbl_tipoDocumento.AutoSize = True
        Me.lbl_tipoDocumento.Location = New System.Drawing.Point(28, 132)
        Me.lbl_tipoDocumento.Name = "lbl_tipoDocumento"
        Me.lbl_tipoDocumento.Size = New System.Drawing.Size(99, 13)
        Me.lbl_tipoDocumento.TabIndex = 59
        Me.lbl_tipoDocumento.Text = "Tipo de documento"
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(149, 285)
        Me.txt_email.MaxLength = 45
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(163, 20)
        Me.txt_email.TabIndex = 7
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Location = New System.Drawing.Point(28, 287)
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
        Me.lbl_contacto.Location = New System.Drawing.Point(28, 172)
        Me.lbl_contacto.Name = "lbl_contacto"
        Me.lbl_contacto.Size = New System.Drawing.Size(50, 13)
        Me.lbl_contacto.TabIndex = 56
        Me.lbl_contacto.Text = "Contacto"
        '
        'txt_telefono
        '
        Me.txt_telefono.Location = New System.Drawing.Point(149, 213)
        Me.txt_telefono.MaxLength = 45
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(163, 20)
        Me.txt_telefono.TabIndex = 5
        '
        'lbl_tel
        '
        Me.lbl_tel.AutoSize = True
        Me.lbl_tel.Location = New System.Drawing.Point(28, 215)
        Me.lbl_tel.Name = "lbl_tel"
        Me.lbl_tel.Size = New System.Drawing.Size(49, 13)
        Me.lbl_tel.TabIndex = 55
        Me.lbl_tel.Text = "Teléfono"
        '
        'txt_taxNumber
        '
        Me.txt_taxNumber.Location = New System.Drawing.Point(149, 21)
        Me.txt_taxNumber.MaxLength = 13
        Me.txt_taxNumber.Name = "txt_taxNumber"
        Me.txt_taxNumber.Size = New System.Drawing.Size(163, 20)
        Me.txt_taxNumber.TabIndex = 0
        '
        'lbl_taxNumber
        '
        Me.lbl_taxNumber.AutoSize = True
        Me.lbl_taxNumber.Location = New System.Drawing.Point(28, 23)
        Me.lbl_taxNumber.Name = "lbl_taxNumber"
        Me.lbl_taxNumber.Size = New System.Drawing.Size(85, 13)
        Me.lbl_taxNumber.TabIndex = 53
        Me.lbl_taxNumber.Text = "CUIT/CUIL/DNI"
        '
        'txt_celular
        '
        Me.txt_celular.Location = New System.Drawing.Point(149, 249)
        Me.txt_celular.MaxLength = 45
        Me.txt_celular.Name = "txt_celular"
        Me.txt_celular.Size = New System.Drawing.Size(163, 20)
        Me.txt_celular.TabIndex = 6
        '
        'lbl_celular
        '
        Me.lbl_celular.AutoSize = True
        Me.lbl_celular.Location = New System.Drawing.Point(28, 251)
        Me.lbl_celular.Name = "lbl_celular"
        Me.lbl_celular.Size = New System.Drawing.Size(39, 13)
        Me.lbl_celular.TabIndex = 50
        Me.lbl_celular.Text = "Celular"
        '
        'txt_razonSocial
        '
        Me.txt_razonSocial.Location = New System.Drawing.Point(149, 57)
        Me.txt_razonSocial.MaxLength = 45
        Me.txt_razonSocial.Name = "txt_razonSocial"
        Me.txt_razonSocial.Size = New System.Drawing.Size(163, 20)
        Me.txt_razonSocial.TabIndex = 1
        '
        'lbl_razonSocial
        '
        Me.lbl_razonSocial.AutoSize = True
        Me.lbl_razonSocial.Location = New System.Drawing.Point(28, 60)
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
        Me.tab_fiscal.Size = New System.Drawing.Size(341, 328)
        Me.tab_fiscal.TabIndex = 1
        Me.tab_fiscal.Text = "Información fiscal"
        '
        'lbl_cpFiscal
        '
        Me.lbl_cpFiscal.AutoSize = True
        Me.lbl_cpFiscal.Location = New System.Drawing.Point(28, 235)
        Me.lbl_cpFiscal.Name = "lbl_cpFiscal"
        Me.lbl_cpFiscal.Size = New System.Drawing.Size(21, 13)
        Me.lbl_cpFiscal.TabIndex = 43
        Me.lbl_cpFiscal.Text = "CP"
        '
        'txt_cpFiscal
        '
        Me.txt_cpFiscal.Location = New System.Drawing.Point(149, 235)
        Me.txt_cpFiscal.MaxLength = 200
        Me.txt_cpFiscal.Name = "txt_cpFiscal"
        Me.txt_cpFiscal.Size = New System.Drawing.Size(163, 20)
        Me.txt_cpFiscal.TabIndex = 12
        '
        'cmb_paisFiscal
        '
        Me.cmb_paisFiscal.FormattingEnabled = True
        Me.cmb_paisFiscal.Location = New System.Drawing.Point(149, 35)
        Me.cmb_paisFiscal.Name = "cmb_paisFiscal"
        Me.cmb_paisFiscal.Size = New System.Drawing.Size(163, 21)
        Me.cmb_paisFiscal.TabIndex = 8
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
        Me.cmb_provinciaFiscal.Location = New System.Drawing.Point(149, 85)
        Me.cmb_provinciaFiscal.Name = "cmb_provinciaFiscal"
        Me.cmb_provinciaFiscal.Size = New System.Drawing.Size(163, 21)
        Me.cmb_provinciaFiscal.TabIndex = 9
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
        Me.tab_entrega.Size = New System.Drawing.Size(341, 328)
        Me.tab_entrega.TabIndex = 2
        Me.tab_entrega.Text = "Información de entrega"
        '
        'lbl_cpEntrega
        '
        Me.lbl_cpEntrega.AutoSize = True
        Me.lbl_cpEntrega.Location = New System.Drawing.Point(28, 235)
        Me.lbl_cpEntrega.Name = "lbl_cpEntrega"
        Me.lbl_cpEntrega.Size = New System.Drawing.Size(21, 13)
        Me.lbl_cpEntrega.TabIndex = 51
        Me.lbl_cpEntrega.Text = "CP"
        '
        'txt_cpEntrega
        '
        Me.txt_cpEntrega.Location = New System.Drawing.Point(149, 235)
        Me.txt_cpEntrega.MaxLength = 200
        Me.txt_cpEntrega.Name = "txt_cpEntrega"
        Me.txt_cpEntrega.Size = New System.Drawing.Size(163, 20)
        Me.txt_cpEntrega.TabIndex = 17
        '
        'cmb_paisEntrega
        '
        Me.cmb_paisEntrega.FormattingEnabled = True
        Me.cmb_paisEntrega.Location = New System.Drawing.Point(149, 35)
        Me.cmb_paisEntrega.Name = "cmb_paisEntrega"
        Me.cmb_paisEntrega.Size = New System.Drawing.Size(163, 21)
        Me.cmb_paisEntrega.TabIndex = 13
        '
        'lbl_paisEntrega
        '
        Me.lbl_paisEntrega.AutoSize = True
        Me.lbl_paisEntrega.Location = New System.Drawing.Point(28, 35)
        Me.lbl_paisEntrega.Name = "lbl_paisEntrega"
        Me.lbl_paisEntrega.Size = New System.Drawing.Size(29, 13)
        Me.lbl_paisEntrega.TabIndex = 48
        Me.lbl_paisEntrega.Text = "País"
        '
        'cmb_provinciaEntrega
        '
        Me.cmb_provinciaEntrega.FormattingEnabled = True
        Me.cmb_provinciaEntrega.Location = New System.Drawing.Point(149, 85)
        Me.cmb_provinciaEntrega.Name = "cmb_provinciaEntrega"
        Me.cmb_provinciaEntrega.Size = New System.Drawing.Size(163, 21)
        Me.cmb_provinciaEntrega.TabIndex = 14
        '
        'txt_direccionEntrega
        '
        Me.txt_direccionEntrega.Location = New System.Drawing.Point(149, 135)
        Me.txt_direccionEntrega.MaxLength = 200
        Me.txt_direccionEntrega.Name = "txt_direccionEntrega"
        Me.txt_direccionEntrega.Size = New System.Drawing.Size(163, 20)
        Me.txt_direccionEntrega.TabIndex = 15
        '
        'lbl_direccionEntrega
        '
        Me.lbl_direccionEntrega.AutoSize = True
        Me.lbl_direccionEntrega.Location = New System.Drawing.Point(28, 135)
        Me.lbl_direccionEntrega.Name = "lbl_direccionEntrega"
        Me.lbl_direccionEntrega.Size = New System.Drawing.Size(91, 13)
        Me.lbl_direccionEntrega.TabIndex = 44
        Me.lbl_direccionEntrega.Text = "Dirección entrega"
        '
        'lbl_provinciaEntrega
        '
        Me.lbl_provinciaEntrega.AutoSize = True
        Me.lbl_provinciaEntrega.Location = New System.Drawing.Point(28, 85)
        Me.lbl_provinciaEntrega.Name = "lbl_provinciaEntrega"
        Me.lbl_provinciaEntrega.Size = New System.Drawing.Size(51, 13)
        Me.lbl_provinciaEntrega.TabIndex = 45
        Me.lbl_provinciaEntrega.Text = "Provincia"
        '
        'lbl_localidadEntrega
        '
        Me.lbl_localidadEntrega.AutoSize = True
        Me.lbl_localidadEntrega.Location = New System.Drawing.Point(28, 185)
        Me.lbl_localidadEntrega.Name = "lbl_localidadEntrega"
        Me.lbl_localidadEntrega.Size = New System.Drawing.Size(53, 13)
        Me.lbl_localidadEntrega.TabIndex = 46
        Me.lbl_localidadEntrega.Text = "Localidad"
        '
        'txt_localidadEntrega
        '
        Me.txt_localidadEntrega.Location = New System.Drawing.Point(149, 185)
        Me.txt_localidadEntrega.MaxLength = 200
        Me.txt_localidadEntrega.Name = "txt_localidadEntrega"
        Me.txt_localidadEntrega.Size = New System.Drawing.Size(163, 20)
        Me.txt_localidadEntrega.TabIndex = 16
        '
        'add_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 524)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txt_notas)
        Me.Controls.Add(Me.lbl_notas)
        Me.Controls.Add(Me.chk_esInscripto)
        Me.Controls.Add(Me.chk_activo)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Name = "add_cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Insertar cliente"
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
    Friend WithEvents txt_notas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_notas As System.Windows.Forms.Label
    Friend WithEvents chk_esInscripto As System.Windows.Forms.CheckBox
    Friend WithEvents txt_localidadFiscal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_localidadFiscal As System.Windows.Forms.Label
    Friend WithEvents lbl_provinciaFiscal As System.Windows.Forms.Label
    Friend WithEvents chk_activo As System.Windows.Forms.CheckBox
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_direccionFiscal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccionFiscal As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_general As System.Windows.Forms.TabPage
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
    Friend WithEvents tab_entrega As System.Windows.Forms.TabPage
    Friend WithEvents cmb_paisEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_paisEntrega As System.Windows.Forms.Label
    Friend WithEvents cmb_provinciaEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents txt_direccionEntrega As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccionEntrega As System.Windows.Forms.Label
    Friend WithEvents lbl_provinciaEntrega As System.Windows.Forms.Label
    Friend WithEvents lbl_localidadEntrega As System.Windows.Forms.Label
    Friend WithEvents txt_localidadEntrega As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cpEntrega As System.Windows.Forms.Label
    Friend WithEvents txt_cpEntrega As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipoDocumento As System.Windows.Forms.Label
    Friend WithEvents txt_nombreFantasia As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nombreFantasia As System.Windows.Forms.Label
End Class
