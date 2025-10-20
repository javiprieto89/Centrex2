<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_pruebas_afip
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_certificados = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_mode = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_cuit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_tipo_comprobante = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_punto_venta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_probar_parametros = New System.Windows.Forms.Button()
        Me.btn_probar_ultimo_comprobante = New System.Windows.Forms.Button()
        Me.btn_probar_conexion = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_resultado = New System.Windows.Forms.TextBox()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.btn_obtener_puntos_de_venta = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_password)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmb_certificados)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_mode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cuit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(533, 185)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuración AFIP"
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(160, 135)
        Me.txt_password.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(265, 22)
        Me.txt_password.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 139)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Contraseña Cert.:"
        '
        'cmb_certificados
        '
        Me.cmb_certificados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_certificados.FormattingEnabled = True
        Me.cmb_certificados.Location = New System.Drawing.Point(160, 98)
        Me.cmb_certificados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmb_certificados.Name = "cmb_certificados"
        Me.cmb_certificados.Size = New System.Drawing.Size(265, 24)
        Me.cmb_certificados.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 102)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Certificado:"
        '
        'cmb_mode
        '
        Me.cmb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_mode.FormattingEnabled = True
        Me.cmb_mode.Location = New System.Drawing.Point(160, 62)
        Me.cmb_mode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmb_mode.Name = "cmb_mode"
        Me.cmb_mode.Size = New System.Drawing.Size(132, 24)
        Me.cmb_mode.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modo:"
        '
        'txt_cuit
        '
        Me.txt_cuit.Location = New System.Drawing.Point(160, 25)
        Me.txt_cuit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_cuit.Name = "txt_cuit"
        Me.txt_cuit.Size = New System.Drawing.Size(199, 22)
        Me.txt_cuit.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CUIT Emisor:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_tipo_comprobante)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_punto_venta)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 222)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(533, 98)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parámetros de Consulta"
        '
        'txt_tipo_comprobante
        '
        Me.txt_tipo_comprobante.Location = New System.Drawing.Point(160, 55)
        Me.txt_tipo_comprobante.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_tipo_comprobante.Name = "txt_tipo_comprobante"
        Me.txt_tipo_comprobante.Size = New System.Drawing.Size(132, 22)
        Me.txt_tipo_comprobante.TabIndex = 3
        Me.txt_tipo_comprobante.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Tipo Comprobante:"
        '
        'txt_punto_venta
        '
        Me.txt_punto_venta.Location = New System.Drawing.Point(160, 18)
        Me.txt_punto_venta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_punto_venta.Name = "txt_punto_venta"
        Me.txt_punto_venta.Size = New System.Drawing.Size(132, 22)
        Me.txt_punto_venta.TabIndex = 1
        Me.txt_punto_venta.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Punto de Venta:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_probar_parametros)
        Me.GroupBox3.Controls.Add(Me.btn_probar_ultimo_comprobante)
        Me.GroupBox3.Controls.Add(Me.btn_probar_conexion)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 345)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(765, 98)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pruebas"
        '
        'btn_probar_parametros
        '
        Me.btn_probar_parametros.Location = New System.Drawing.Point(360, 31)
        Me.btn_probar_parametros.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_probar_parametros.Name = "btn_probar_parametros"
        Me.btn_probar_parametros.Size = New System.Drawing.Size(160, 43)
        Me.btn_probar_parametros.TabIndex = 2
        Me.btn_probar_parametros.Text = "Probar Parámetros"
        Me.btn_probar_parametros.UseVisualStyleBackColor = True
        '
        'btn_probar_ultimo_comprobante
        '
        Me.btn_probar_ultimo_comprobante.Location = New System.Drawing.Point(187, 31)
        Me.btn_probar_ultimo_comprobante.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_probar_ultimo_comprobante.Name = "btn_probar_ultimo_comprobante"
        Me.btn_probar_ultimo_comprobante.Size = New System.Drawing.Size(160, 43)
        Me.btn_probar_ultimo_comprobante.TabIndex = 1
        Me.btn_probar_ultimo_comprobante.Text = "Último Comprobante"
        Me.btn_probar_ultimo_comprobante.UseVisualStyleBackColor = True
        '
        'btn_probar_conexion
        '
        Me.btn_probar_conexion.Location = New System.Drawing.Point(13, 31)
        Me.btn_probar_conexion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_probar_conexion.Name = "btn_probar_conexion"
        Me.btn_probar_conexion.Size = New System.Drawing.Size(160, 43)
        Me.btn_probar_conexion.TabIndex = 0
        Me.btn_probar_conexion.Text = "Probar Conexión"
        Me.btn_probar_conexion.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_resultado)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 468)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(800, 246)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resultados"
        '
        'txt_resultado
        '
        Me.txt_resultado.Location = New System.Drawing.Point(13, 25)
        Me.txt_resultado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_resultado.Multiline = True
        Me.txt_resultado.Name = "txt_resultado"
        Me.txt_resultado.ReadOnly = True
        Me.txt_resultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_resultado.Size = New System.Drawing.Size(772, 208)
        Me.txt_resultado.TabIndex = 0
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Location = New System.Drawing.Point(600, 726)
        Me.btn_limpiar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(100, 37)
        Me.btn_limpiar.TabIndex = 4
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Location = New System.Drawing.Point(713, 726)
        Me.btn_cerrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(100, 37)
        Me.btn_cerrar.TabIndex = 5
        Me.btn_cerrar.Text = "Cerrar"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'btn_obtener_puntos_de_venta
        '
        Me.btn_obtener_puntos_de_venta.Location = New System.Drawing.Point(557, 376)
        Me.btn_obtener_puntos_de_venta.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_obtener_puntos_de_venta.Name = "btn_obtener_puntos_de_venta"
        Me.btn_obtener_puntos_de_venta.Size = New System.Drawing.Size(160, 43)
        Me.btn_obtener_puntos_de_venta.TabIndex = 3
        Me.btn_obtener_puntos_de_venta.Text = "Obtener puntos de venta"
        Me.btn_obtener_puntos_de_venta.UseVisualStyleBackColor = True
        '
        'frm_pruebas_afip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 777)
        Me.Controls.Add(Me.btn_obtener_puntos_de_venta)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_pruebas_afip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pruebas AFIP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txt_password As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmb_certificados As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmb_mode As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_cuit As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txt_tipo_comprobante As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_punto_venta As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn_probar_parametros As Button
    Friend WithEvents btn_probar_ultimo_comprobante As Button
    Friend WithEvents btn_probar_conexion As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txt_resultado As TextBox
    Friend WithEvents btn_limpiar As Button
    Friend WithEvents btn_cerrar As Button
    Friend WithEvents btn_obtener_puntos_de_venta As Button
End Class
