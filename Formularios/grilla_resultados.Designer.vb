<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grilla_resultados
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
        Me.cmb_consultas = New System.Windows.Forms.ComboBox()
        Me.dg_view_resultados = New System.Windows.Forms.DataGridView()
        Me.cmd_ejecutar = New System.Windows.Forms.Button()
        Me.lbl_consultas = New System.Windows.Forms.Label()
        CType(Me.dg_view_resultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_consultas
        '
        Me.cmb_consultas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_consultas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_consultas.FormattingEnabled = True
        Me.cmb_consultas.Location = New System.Drawing.Point(98, 21)
        Me.cmb_consultas.Name = "cmb_consultas"
        Me.cmb_consultas.Size = New System.Drawing.Size(736, 21)
        Me.cmb_consultas.TabIndex = 59
        '
        'dg_view_resultados
        '
        Me.dg_view_resultados.AllowUserToAddRows = False
        Me.dg_view_resultados.AllowUserToDeleteRows = False
        Me.dg_view_resultados.AllowUserToOrderColumns = True
        Me.dg_view_resultados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view_resultados.Location = New System.Drawing.Point(24, 54)
        Me.dg_view_resultados.MultiSelect = False
        Me.dg_view_resultados.Name = "dg_view_resultados"
        Me.dg_view_resultados.ReadOnly = True
        Me.dg_view_resultados.RowHeadersVisible = False
        Me.dg_view_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view_resultados.Size = New System.Drawing.Size(958, 598)
        Me.dg_view_resultados.TabIndex = 58
        '
        'cmd_ejecutar
        '
        Me.cmd_ejecutar.Location = New System.Drawing.Point(840, 21)
        Me.cmd_ejecutar.Name = "cmd_ejecutar"
        Me.cmd_ejecutar.Size = New System.Drawing.Size(142, 21)
        Me.cmd_ejecutar.TabIndex = 57
        Me.cmd_ejecutar.Text = "Ejecutar consulta"
        Me.cmd_ejecutar.UseVisualStyleBackColor = True
        '
        'lbl_consultas
        '
        Me.lbl_consultas.AutoSize = True
        Me.lbl_consultas.Location = New System.Drawing.Point(21, 24)
        Me.lbl_consultas.Name = "lbl_consultas"
        Me.lbl_consultas.Size = New System.Drawing.Size(53, 13)
        Me.lbl_consultas.TabIndex = 56
        Me.lbl_consultas.Text = "Consultas"
        '
        'grilla_resultados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 672)
        Me.Controls.Add(Me.cmb_consultas)
        Me.Controls.Add(Me.dg_view_resultados)
        Me.Controls.Add(Me.cmd_ejecutar)
        Me.Controls.Add(Me.lbl_consultas)
        Me.Name = "grilla_resultados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultas personalizadas"
        CType(Me.dg_view_resultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_consultas As System.Windows.Forms.ComboBox
    Friend WithEvents dg_view_resultados As System.Windows.Forms.DataGridView
    Friend WithEvents cmd_ejecutar As System.Windows.Forms.Button
    Friend WithEvents lbl_consultas As System.Windows.Forms.Label
End Class
