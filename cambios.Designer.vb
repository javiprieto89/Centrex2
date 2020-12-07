<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambios
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
        Me.cmdcontinuar = New System.Windows.Forms.Button()
        Me.lsv_cambios = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'cmdcontinuar
        '
        Me.cmdcontinuar.Location = New System.Drawing.Point(343, 366)
        Me.cmdcontinuar.Name = "cmdcontinuar"
        Me.cmdcontinuar.Size = New System.Drawing.Size(191, 42)
        Me.cmdcontinuar.TabIndex = 7
        Me.cmdcontinuar.Text = "Continuar"
        Me.cmdcontinuar.UseVisualStyleBackColor = True
        '
        'lsv_cambios
        '
        Me.lsv_cambios.Location = New System.Drawing.Point(9, 15)
        Me.lsv_cambios.Name = "lsv_cambios"
        Me.lsv_cambios.Size = New System.Drawing.Size(860, 336)
        Me.lsv_cambios.TabIndex = 6
        Me.lsv_cambios.UseCompatibleStateImageBehavior = False
        '
        'frmCambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 422)
        Me.Controls.Add(Me.cmdcontinuar)
        Me.Controls.Add(Me.lsv_cambios)
        Me.Name = "frmCambios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Últimos cambios - CTS"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdcontinuar As Button
    Friend WithEvents lsv_cambios As ListView
End Class
