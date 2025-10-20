<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_mercadopago_qr
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
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.pic_qr = New System.Windows.Forms.PictureBox()
        Me.lbl_instrucciones = New System.Windows.Forms.Label()
        Me.lbl_monto = New System.Windows.Forms.Label()
        Me.lbl_referencia = New System.Windows.Forms.Label()
        Me.btn_generar_qr = New System.Windows.Forms.Button()
        Me.btn_copiar_link = New System.Windows.Forms.Button()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        CType(Me.pic_qr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.Location = New System.Drawing.Point(12, 9)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(200, 24)
        Me.lbl_titulo.TabIndex = 0
        Me.lbl_titulo.Text = "Escanear QR para Pagar"
        '
        'pic_qr
        '
        Me.pic_qr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_qr.Location = New System.Drawing.Point(100, 50)
        Me.pic_qr.Name = "pic_qr"
        Me.pic_qr.Size = New System.Drawing.Size(200, 200)
        Me.pic_qr.TabIndex = 1
        Me.pic_qr.TabStop = False
        '
        'lbl_instrucciones
        '
        Me.lbl_instrucciones.AutoSize = True
        Me.lbl_instrucciones.Location = New System.Drawing.Point(12, 270)
        Me.lbl_instrucciones.Name = "lbl_instrucciones"
        Me.lbl_instrucciones.Size = New System.Drawing.Size(200, 65)
        Me.lbl_instrucciones.TabIndex = 2
        Me.lbl_instrucciones.Text = "1. Abre la app de MercadoPago" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Toca 'Escanear código'" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. Apunta la cámara al QR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4. Confirma el pago"
        '
        'lbl_monto
        '
        Me.lbl_monto.AutoSize = True
        Me.lbl_monto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_monto.Location = New System.Drawing.Point(12, 350)
        Me.lbl_monto.Name = "lbl_monto"
        Me.lbl_monto.Size = New System.Drawing.Size(100, 17)
        Me.lbl_monto.TabIndex = 3
        Me.lbl_monto.Text = "Monto: $0.00"
        '
        'lbl_referencia
        '
        Me.lbl_referencia.AutoSize = True
        Me.lbl_referencia.Location = New System.Drawing.Point(12, 375)
        Me.lbl_referencia.Name = "lbl_referencia"
        Me.lbl_referencia.Size = New System.Drawing.Size(100, 13)
        Me.lbl_referencia.TabIndex = 4
        Me.lbl_referencia.Text = "Referencia: "
        '
        'btn_generar_qr
        '
        Me.btn_generar_qr.Location = New System.Drawing.Point(12, 400)
        Me.btn_generar_qr.Name = "btn_generar_qr"
        Me.btn_generar_qr.Size = New System.Drawing.Size(100, 30)
        Me.btn_generar_qr.TabIndex = 5
        Me.btn_generar_qr.Text = "Generar Nuevo QR"
        Me.btn_generar_qr.UseVisualStyleBackColor = True
        '
        'btn_copiar_link
        '
        Me.btn_copiar_link.Location = New System.Drawing.Point(150, 400)
        Me.btn_copiar_link.Name = "btn_copiar_link"
        Me.btn_copiar_link.Size = New System.Drawing.Size(100, 30)
        Me.btn_copiar_link.TabIndex = 6
        Me.btn_copiar_link.Text = "Copiar Link"
        Me.btn_copiar_link.UseVisualStyleBackColor = True
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Location = New System.Drawing.Point(300, 400)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(75, 30)
        Me.btn_cerrar.TabIndex = 7
        Me.btn_cerrar.Text = "Cerrar"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'frm_mercadopago_qr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 450)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.btn_copiar_link)
        Me.Controls.Add(Me.btn_generar_qr)
        Me.Controls.Add(Me.lbl_referencia)
        Me.Controls.Add(Me.lbl_monto)
        Me.Controls.Add(Me.lbl_instrucciones)
        Me.Controls.Add(Me.pic_qr)
        Me.Controls.Add(Me.lbl_titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mercadopago_qr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pago con MercadoPago"
        CType(Me.pic_qr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_titulo As Label
    Friend WithEvents pic_qr As PictureBox
    Friend WithEvents lbl_instrucciones As Label
    Friend WithEvents lbl_monto As Label
    Friend WithEvents lbl_referencia As Label
    Friend WithEvents btn_generar_qr As Button
    Friend WithEvents btn_copiar_link As Button
    Friend WithEvents btn_cerrar As Button
End Class
