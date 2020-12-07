<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_comprobantes_compras_conceptos
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
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.lbl_concepto = New System.Windows.Forms.Label()
        Me.lbl_subtotal = New System.Windows.Forms.Label()
        Me.lbl_iva = New System.Windows.Forms.Label()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_subtotal = New System.Windows.Forms.TextBox()
        Me.txt_iva = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Location = New System.Drawing.Point(33, 19)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(53, 13)
        Me.lblConcepto.TabIndex = 0
        Me.lblConcepto.Text = "Concepto"
        '
        'lbl_concepto
        '
        Me.lbl_concepto.AutoSize = True
        Me.lbl_concepto.Location = New System.Drawing.Point(106, 19)
        Me.lbl_concepto.Name = "lbl_concepto"
        Me.lbl_concepto.Size = New System.Drawing.Size(68, 13)
        Me.lbl_concepto.TabIndex = 1
        Me.lbl_concepto.Text = "%concepto%"
        '
        'lbl_subtotal
        '
        Me.lbl_subtotal.AutoSize = True
        Me.lbl_subtotal.Location = New System.Drawing.Point(33, 66)
        Me.lbl_subtotal.Name = "lbl_subtotal"
        Me.lbl_subtotal.Size = New System.Drawing.Size(46, 13)
        Me.lbl_subtotal.TabIndex = 2
        Me.lbl_subtotal.Text = "Subtotal"
        '
        'lbl_iva
        '
        Me.lbl_iva.AutoSize = True
        Me.lbl_iva.Location = New System.Drawing.Point(33, 102)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.Size = New System.Drawing.Size(33, 13)
        Me.lbl_iva.TabIndex = 4
        Me.lbl_iva.Text = "I.V.A."
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Location = New System.Drawing.Point(33, 142)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(31, 13)
        Me.lbl_total.TabIndex = 6
        Me.lbl_total.Text = "Total"
        '
        'txt_subtotal
        '
        Me.txt_subtotal.Location = New System.Drawing.Point(106, 59)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.Size = New System.Drawing.Size(183, 20)
        Me.txt_subtotal.TabIndex = 3
        '
        'txt_iva
        '
        Me.txt_iva.Location = New System.Drawing.Point(106, 95)
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.Size = New System.Drawing.Size(183, 20)
        Me.txt_iva.TabIndex = 5
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(106, 135)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(183, 20)
        Me.txt_total.TabIndex = 7
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(169, 209)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 9
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(71, 209)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 8
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'add_comprobantes_compras_conceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 247)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.txt_iva)
        Me.Controls.Add(Me.txt_subtotal)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.lbl_iva)
        Me.Controls.Add(Me.lbl_subtotal)
        Me.Controls.Add(Me.lbl_concepto)
        Me.Controls.Add(Me.lblConcepto)
        Me.Name = "add_comprobantes_compras_conceptos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar concepto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblConcepto As Label
    Friend WithEvents lbl_concepto As Label
    Friend WithEvents lbl_subtotal As Label
    Friend WithEvents lbl_iva As Label
    Friend WithEvents lbl_total As Label
    Friend WithEvents txt_subtotal As TextBox
    Friend WithEvents txt_iva As TextBox
    Friend WithEvents txt_total As TextBox
    Friend WithEvents cmd_exit As Button
    Friend WithEvents cmd_ok As Button
End Class
