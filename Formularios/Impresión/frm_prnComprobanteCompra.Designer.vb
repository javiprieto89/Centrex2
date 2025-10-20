<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_prnComprobanteCompra
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
        Me.rpt_view = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpt_view
        '
        Me.rpt_view.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_view.Location = New System.Drawing.Point(0, 0)
        Me.rpt_view.Name = "rpt_view"
        Me.rpt_view.Size = New System.Drawing.Size(930, 733)
        Me.rpt_view.TabIndex = 1
        '
        'frm_prnComprobanteCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 733)
        Me.Controls.Add(Me.rpt_view)
        Me.Name = "frm_prnComprobanteCompra"
        Me.Text = "Impresión"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpt_view As Microsoft.Reporting.WinForms.ReportViewer
End Class
