<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Buscar_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CertificadoTX = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ClaveTX = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LoginBtn = New System.Windows.Forms.Button()
        Me.VerTokenBtn = New System.Windows.Forms.Button()
        Me.VerSignBtn = New System.Windows.Forms.Button()
        Me.VerFullRequestBtn = New System.Windows.Forms.Button()
        Me.VerFullResponseBtn = New System.Windows.Forms.Button()
        Me.WSFE_BTN = New System.Windows.Forms.Button()
        Me.testing_rb = New System.Windows.Forms.RadioButton()
        Me.produccion_rb = New System.Windows.Forms.RadioButton()
        Me.TestServerBTN = New System.Windows.Forms.Button()
        Me.EmitirWorkflowBtn = New System.Windows.Forms.Button()
        Me.FactObjTest = New System.Windows.Forms.Button()
        Me.ServicioTX = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CuitEmisorTX = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Buscar_btn
        '
        Me.Buscar_btn.Location = New System.Drawing.Point(619, 73)
        Me.Buscar_btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Buscar_btn.Name = "Buscar_btn"
        Me.Buscar_btn.Size = New System.Drawing.Size(100, 28)
        Me.Buscar_btn.TabIndex = 0
        Me.Buscar_btn.Text = "Buscar"
        Me.Buscar_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Certificado"
        '
        'CertificadoTX
        '
        Me.CertificadoTX.Location = New System.Drawing.Point(117, 75)
        Me.CertificadoTX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CertificadoTX.Name = "CertificadoTX"
        Me.CertificadoTX.Size = New System.Drawing.Size(492, 22)
        Me.CertificadoTX.TabIndex = 2
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 111)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Clave"
        '
        'ClaveTX
        '
        Me.ClaveTX.Location = New System.Drawing.Point(117, 107)
        Me.ClaveTX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ClaveTX.Name = "ClaveTX"
        Me.ClaveTX.Size = New System.Drawing.Size(492, 22)
        Me.ClaveTX.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 143)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Servicio"
        '
        'LoginBtn
        '
        Me.LoginBtn.Location = New System.Drawing.Point(119, 249)
        Me.LoginBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(111, 50)
        Me.LoginBtn.TabIndex = 3
        Me.LoginBtn.Text = "Login"
        Me.LoginBtn.UseVisualStyleBackColor = True
        '
        'VerTokenBtn
        '
        Me.VerTokenBtn.Location = New System.Drawing.Point(276, 249)
        Me.VerTokenBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VerTokenBtn.Name = "VerTokenBtn"
        Me.VerTokenBtn.Size = New System.Drawing.Size(111, 50)
        Me.VerTokenBtn.TabIndex = 3
        Me.VerTokenBtn.Text = "Ver Token"
        Me.VerTokenBtn.UseVisualStyleBackColor = True
        '
        'VerSignBtn
        '
        Me.VerSignBtn.Location = New System.Drawing.Point(395, 249)
        Me.VerSignBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VerSignBtn.Name = "VerSignBtn"
        Me.VerSignBtn.Size = New System.Drawing.Size(111, 50)
        Me.VerSignBtn.TabIndex = 3
        Me.VerSignBtn.Text = "Ver Sign"
        Me.VerSignBtn.UseVisualStyleBackColor = True
        '
        'VerFullRequestBtn
        '
        Me.VerFullRequestBtn.Location = New System.Drawing.Point(549, 249)
        Me.VerFullRequestBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VerFullRequestBtn.Name = "VerFullRequestBtn"
        Me.VerFullRequestBtn.Size = New System.Drawing.Size(111, 50)
        Me.VerFullRequestBtn.TabIndex = 3
        Me.VerFullRequestBtn.Text = "Ver Login Request"
        Me.VerFullRequestBtn.UseVisualStyleBackColor = True
        '
        'VerFullResponseBtn
        '
        Me.VerFullResponseBtn.Location = New System.Drawing.Point(697, 249)
        Me.VerFullResponseBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VerFullResponseBtn.Name = "VerFullResponseBtn"
        Me.VerFullResponseBtn.Size = New System.Drawing.Size(111, 50)
        Me.VerFullResponseBtn.TabIndex = 3
        Me.VerFullResponseBtn.Text = "Ver Login Response"
        Me.VerFullResponseBtn.UseVisualStyleBackColor = True
        '
        'WSFE_BTN
        '
        Me.WSFE_BTN.Location = New System.Drawing.Point(119, 332)
        Me.WSFE_BTN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WSFE_BTN.Name = "WSFE_BTN"
        Me.WSFE_BTN.Size = New System.Drawing.Size(392, 71)
        Me.WSFE_BTN.TabIndex = 3
        Me.WSFE_BTN.Text = "Facturacion Electronica WSFE"
        Me.WSFE_BTN.UseVisualStyleBackColor = True
        '
        'testing_rb
        '
        Me.testing_rb.AutoSize = True
        Me.testing_rb.Checked = True
        Me.testing_rb.Location = New System.Drawing.Point(119, 203)
        Me.testing_rb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.testing_rb.Name = "testing_rb"
        Me.testing_rb.Size = New System.Drawing.Size(76, 21)
        Me.testing_rb.TabIndex = 11
        Me.testing_rb.TabStop = True
        Me.testing_rb.Text = "Testing"
        Me.testing_rb.UseVisualStyleBackColor = True
        '
        'produccion_rb
        '
        Me.produccion_rb.AutoSize = True
        Me.produccion_rb.Location = New System.Drawing.Point(117, 231)
        Me.produccion_rb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.produccion_rb.Name = "produccion_rb"
        Me.produccion_rb.Size = New System.Drawing.Size(100, 21)
        Me.produccion_rb.TabIndex = 12
        Me.produccion_rb.TabStop = True
        Me.produccion_rb.Text = "Produccion"
        Me.produccion_rb.UseVisualStyleBackColor = True
        '
        'TestServerBTN
        '
        Me.TestServerBTN.Location = New System.Drawing.Point(697, 213)
        Me.TestServerBTN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TestServerBTN.Name = "TestServerBTN"
        Me.TestServerBTN.Size = New System.Drawing.Size(100, 28)
        Me.TestServerBTN.TabIndex = 5
        Me.TestServerBTN.Text = "Probar Servidor"
        Me.TestServerBTN.UseVisualStyleBackColor = True
        '
        'EmitirWorkflowBtn
        '
        Me.EmitirWorkflowBtn.Location = New System.Drawing.Point(697, 327)
        Me.EmitirWorkflowBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmitirWorkflowBtn.Name = "EmitirWorkflowBtn"
        Me.EmitirWorkflowBtn.Size = New System.Drawing.Size(100, 76)
        Me.EmitirWorkflowBtn.TabIndex = 6
        Me.EmitirWorkflowBtn.Text = "Emitir con nuevo flujo"
        Me.EmitirWorkflowBtn.UseVisualStyleBackColor = True
        '
        'FactObjTest
        '
        Me.FactObjTest.Location = New System.Drawing.Point(697, 416)
        Me.FactObjTest.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FactObjTest.Name = "FactObjTest"
        Me.FactObjTest.Size = New System.Drawing.Size(100, 71)
        Me.FactObjTest.TabIndex = 7
        Me.FactObjTest.Text = "Factura Obj Prueba"
        Me.FactObjTest.UseVisualStyleBackColor = True
        '
        'ServicioTX
        '
        Me.ServicioTX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServicioTX.FormattingEnabled = True
        Me.ServicioTX.Items.AddRange(New Object() {"wsfe"})
        Me.ServicioTX.Location = New System.Drawing.Point(117, 138)
        Me.ServicioTX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ServicioTX.Name = "ServicioTX"
        Me.ServicioTX.Size = New System.Drawing.Size(387, 24)
        Me.ServicioTX.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 175)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CUIT emisor"
        '
        'CuitEmisorTX
        '
        Me.CuitEmisorTX.Location = New System.Drawing.Point(117, 171)
        Me.CuitEmisorTX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CuitEmisorTX.Name = "CuitEmisorTX"
        Me.CuitEmisorTX.Size = New System.Drawing.Size(387, 22)
        Me.CuitEmisorTX.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 570)
        Me.Controls.Add(Me.CuitEmisorTX)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ServicioTX)
        Me.Controls.Add(Me.FactObjTest)
        Me.Controls.Add(Me.EmitirWorkflowBtn)
        Me.Controls.Add(Me.TestServerBTN)
        Me.Controls.Add(Me.produccion_rb)
        Me.Controls.Add(Me.testing_rb)
        Me.Controls.Add(Me.VerFullResponseBtn)
        Me.Controls.Add(Me.VerFullRequestBtn)
        Me.Controls.Add(Me.VerSignBtn)
        Me.Controls.Add(Me.VerTokenBtn)
        Me.Controls.Add(Me.WSFE_BTN)
        Me.Controls.Add(Me.LoginBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ClaveTX)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CertificadoTX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Buscar_btn)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Login WSAA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Buscar_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CertificadoTX As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents ClaveTX As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LoginBtn As Button
    Friend WithEvents VerTokenBtn As Button
    Friend WithEvents VerSignBtn As Button
    Friend WithEvents VerFullRequestBtn As Button
    Friend WithEvents VerFullResponseBtn As Button
    Friend WithEvents WSFE_BTN As Button
    Friend WithEvents testing_rb As RadioButton
    Friend WithEvents produccion_rb As RadioButton
    Friend WithEvents TestServerBTN As Button
    Friend WithEvents EmitirWorkflowBtn As Button
    Friend WithEvents FactObjTest As Button
    Friend WithEvents ServicioTX As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CuitEmisorTX As TextBox
End Class
