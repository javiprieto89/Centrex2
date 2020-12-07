<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dbselect
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
        Me.cmb_selectdb = New System.Windows.Forms.ComboBox()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.lbl_elija = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmb_selectdb
        '
        Me.cmb_selectdb.FormattingEnabled = True
        Me.cmb_selectdb.Items.AddRange(New Object() {"Centrex", "CentrexTest"})
        Me.cmb_selectdb.Location = New System.Drawing.Point(42, 52)
        Me.cmb_selectdb.Name = "cmb_selectdb"
        Me.cmb_selectdb.Size = New System.Drawing.Size(255, 24)
        Me.cmb_selectdb.TabIndex = 0
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(42, 110)
        Me.cmd_ok.Margin = New System.Windows.Forms.Padding(4)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(255, 52)
        Me.cmd_ok.TabIndex = 1
        Me.cmd_ok.Text = "Iniciar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.Location = New System.Drawing.Point(42, 186)
        Me.cmd_exit.Margin = New System.Windows.Forms.Padding(4)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(255, 52)
        Me.cmd_exit.TabIndex = 2
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'lbl_elija
        '
        Me.lbl_elija.AutoSize = True
        Me.lbl_elija.Location = New System.Drawing.Point(46, 15)
        Me.lbl_elija.Name = "lbl_elija"
        Me.lbl_elija.Size = New System.Drawing.Size(156, 17)
        Me.lbl_elija.TabIndex = 4
        Me.lbl_elija.Text = "Elija una base de datos"
        '
        'dbselect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 253)
        Me.Controls.Add(Me.lbl_elija)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.cmb_selectdb)
        Me.Name = "dbselect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Centrex"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_selectdb As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents lbl_elija As System.Windows.Forms.Label
End Class
