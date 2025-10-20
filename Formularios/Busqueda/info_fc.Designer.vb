<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class info_fc
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
        Me.lbl_punto_venta = New System.Windows.Forms.Label()
        Me.lbl_comprobante = New System.Windows.Forms.Label()
        Me.lbl_numero_comprobante = New System.Windows.Forms.Label()
        Me.txt_puntoVenta = New System.Windows.Forms.TextBox()
        Me.txt_numeroComprobante = New System.Windows.Forms.TextBox()
        Me.cmb_Comprobante = New System.Windows.Forms.ComboBox()
        Me.cmd_consultar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_punto_venta
        '
        Me.lbl_punto_venta.AutoSize = True
        Me.lbl_punto_venta.Location = New System.Drawing.Point(34, 97)
        Me.lbl_punto_venta.Name = "lbl_punto_venta"
        Me.lbl_punto_venta.Size = New System.Drawing.Size(80, 13)
        Me.lbl_punto_venta.TabIndex = 0
        Me.lbl_punto_venta.Text = "Punto de venta"
        '
        'lbl_comprobante
        '
        Me.lbl_comprobante.AutoSize = True
        Me.lbl_comprobante.Location = New System.Drawing.Point(34, 42)
        Me.lbl_comprobante.Name = "lbl_comprobante"
        Me.lbl_comprobante.Size = New System.Drawing.Size(70, 13)
        Me.lbl_comprobante.TabIndex = 1
        Me.lbl_comprobante.Text = "Comprobante"
        '
        'lbl_numero_comprobante
        '
        Me.lbl_numero_comprobante.AutoSize = True
        Me.lbl_numero_comprobante.Location = New System.Drawing.Point(34, 152)
        Me.lbl_numero_comprobante.Name = "lbl_numero_comprobante"
        Me.lbl_numero_comprobante.Size = New System.Drawing.Size(124, 13)
        Me.lbl_numero_comprobante.TabIndex = 2
        Me.lbl_numero_comprobante.Text = "Número de comprobante"
        '
        'txt_puntoVenta
        '
        Me.txt_puntoVenta.Location = New System.Drawing.Point(177, 92)
        Me.txt_puntoVenta.Name = "txt_puntoVenta"
        Me.txt_puntoVenta.ReadOnly = True
        Me.txt_puntoVenta.Size = New System.Drawing.Size(177, 20)
        Me.txt_puntoVenta.TabIndex = 1
        '
        'txt_numeroComprobante
        '
        Me.txt_numeroComprobante.Location = New System.Drawing.Point(177, 149)
        Me.txt_numeroComprobante.Name = "txt_numeroComprobante"
        Me.txt_numeroComprobante.Size = New System.Drawing.Size(177, 20)
        Me.txt_numeroComprobante.TabIndex = 2
        '
        'cmb_Comprobante
        '
        Me.cmb_Comprobante.FormattingEnabled = True
        Me.cmb_Comprobante.Location = New System.Drawing.Point(177, 34)
        Me.cmb_Comprobante.Name = "cmb_Comprobante"
        Me.cmb_Comprobante.Size = New System.Drawing.Size(177, 21)
        Me.cmb_Comprobante.TabIndex = 0
        '
        'cmd_consultar
        '
        Me.cmd_consultar.Location = New System.Drawing.Point(105, 240)
        Me.cmd_consultar.Name = "cmd_consultar"
        Me.cmd_consultar.Size = New System.Drawing.Size(179, 56)
        Me.cmd_consultar.TabIndex = 3
        Me.cmd_consultar.Text = "Consultar"
        Me.cmd_consultar.UseVisualStyleBackColor = True
        '
        'info_fc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 333)
        Me.Controls.Add(Me.cmd_consultar)
        Me.Controls.Add(Me.cmb_Comprobante)
        Me.Controls.Add(Me.txt_numeroComprobante)
        Me.Controls.Add(Me.txt_puntoVenta)
        Me.Controls.Add(Me.lbl_numero_comprobante)
        Me.Controls.Add(Me.lbl_comprobante)
        Me.Controls.Add(Me.lbl_punto_venta)
        Me.Name = "info_fc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Información de factura ya emitida"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_punto_venta As Label
    Friend WithEvents lbl_comprobante As Label
    Friend WithEvents lbl_numero_comprobante As Label
    Friend WithEvents txt_puntoVenta As TextBox
    Friend WithEvents txt_numeroComprobante As TextBox
    Friend WithEvents cmb_Comprobante As ComboBox
    Friend WithEvents cmd_consultar As Button
End Class
