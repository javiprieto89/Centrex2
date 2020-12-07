<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ultimo_comprobante
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
        Me.cmb_comprobante = New System.Windows.Forms.ComboBox()
        Me.lbl_comprobante = New System.Windows.Forms.Label()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmb_comprobante
        '
        Me.cmb_comprobante.FormattingEnabled = True
        Me.cmb_comprobante.Location = New System.Drawing.Point(31, 62)
        Me.cmb_comprobante.Name = "cmb_comprobante"
        Me.cmb_comprobante.Size = New System.Drawing.Size(328, 21)
        Me.cmb_comprobante.TabIndex = 0
        '
        'lbl_comprobante
        '
        Me.lbl_comprobante.AutoSize = True
        Me.lbl_comprobante.Location = New System.Drawing.Point(28, 33)
        Me.lbl_comprobante.Name = "lbl_comprobante"
        Me.lbl_comprobante.Size = New System.Drawing.Size(75, 13)
        Me.lbl_comprobante.TabIndex = 1
        Me.lbl_comprobante.Text = "Comprobantes"
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(109, 109)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(168, 23)
        Me.cmd_ok.TabIndex = 53
        Me.cmd_ok.Text = "Consultar último comprobante"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'frm_ultimo_comprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 165)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_comprobante)
        Me.Controls.Add(Me.cmb_comprobante)
        Me.Name = "frm_ultimo_comprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta comprobantes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmb_comprobante As ComboBox
    Friend WithEvents lbl_comprobante As Label
    Friend WithEvents cmd_ok As Button
End Class
