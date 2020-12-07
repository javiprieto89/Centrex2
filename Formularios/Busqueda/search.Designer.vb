<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class search
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
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.lblbusqueda = New System.Windows.Forms.Label()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.lbl_borrarbusqueda = New System.Windows.Forms.Label()
        Me.cmd_addItem = New System.Windows.Forms.Button()
        Me.dg_view = New System.Windows.Forms.DataGridView()
        Me.cmd_go = New System.Windows.Forms.Button()
        Me.txt_nPage = New System.Windows.Forms.TextBox()
        Me.cmd_last = New System.Windows.Forms.Button()
        Me.cmd_next = New System.Windows.Forms.Button()
        Me.cmd_prev = New System.Windows.Forms.Button()
        Me.cmd_first = New System.Windows.Forms.Button()
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_search
        '
        Me.txt_search.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_search.Location = New System.Drawing.Point(103, 37)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(516, 20)
        Me.txt_search.TabIndex = 0
        '
        'lblbusqueda
        '
        Me.lblbusqueda.AutoSize = True
        Me.lblbusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbusqueda.Location = New System.Drawing.Point(25, 40)
        Me.lblbusqueda.Name = "lblbusqueda"
        Me.lblbusqueda.Size = New System.Drawing.Size(63, 13)
        Me.lblbusqueda.TabIndex = 11
        Me.lblbusqueda.Text = "Búsqueda"
        '
        'cmd_ok
        '
        Me.cmd_ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_ok.Location = New System.Drawing.Point(656, 25)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(168, 42)
        Me.cmd_ok.TabIndex = 1
        Me.cmd_ok.Text = "Seleccionar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(27, 512)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 12
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        Me.chk_secuencia.Visible = False
        '
        'lbl_borrarbusqueda
        '
        Me.lbl_borrarbusqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_borrarbusqueda.AutoSize = True
        Me.lbl_borrarbusqueda.Location = New System.Drawing.Point(624, 44)
        Me.lbl_borrarbusqueda.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_borrarbusqueda.Name = "lbl_borrarbusqueda"
        Me.lbl_borrarbusqueda.Size = New System.Drawing.Size(12, 13)
        Me.lbl_borrarbusqueda.TabIndex = 22
        Me.lbl_borrarbusqueda.Text = "x"
        '
        'cmd_addItem
        '
        Me.cmd_addItem.Location = New System.Drawing.Point(27, 76)
        Me.cmd_addItem.Name = "cmd_addItem"
        Me.cmd_addItem.Size = New System.Drawing.Size(107, 23)
        Me.cmd_addItem.TabIndex = 23
        Me.cmd_addItem.Text = "Agregar producto"
        Me.cmd_addItem.UseVisualStyleBackColor = True
        Me.cmd_addItem.Visible = False
        '
        'dg_view
        '
        Me.dg_view.AllowUserToAddRows = False
        Me.dg_view.AllowUserToDeleteRows = False
        Me.dg_view.AllowUserToOrderColumns = True
        Me.dg_view.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dg_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_view.Location = New System.Drawing.Point(27, 112)
        Me.dg_view.MultiSelect = False
        Me.dg_view.Name = "dg_view"
        Me.dg_view.ReadOnly = True
        Me.dg_view.RowHeadersVisible = False
        Me.dg_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_view.Size = New System.Drawing.Size(796, 386)
        Me.dg_view.TabIndex = 54
        '
        'cmd_go
        '
        Me.cmd_go.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_go.Location = New System.Drawing.Point(794, 79)
        Me.cmd_go.Name = "cmd_go"
        Me.cmd_go.Size = New System.Drawing.Size(29, 20)
        Me.cmd_go.TabIndex = 72
        Me.cmd_go.Text = "Ir"
        Me.cmd_go.UseVisualStyleBackColor = True
        '
        'txt_nPage
        '
        Me.txt_nPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nPage.Location = New System.Drawing.Point(725, 79)
        Me.txt_nPage.Name = "txt_nPage"
        Me.txt_nPage.Size = New System.Drawing.Size(63, 20)
        Me.txt_nPage.TabIndex = 71
        '
        'cmd_last
        '
        Me.cmd_last.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_last.Location = New System.Drawing.Point(690, 79)
        Me.cmd_last.Name = "cmd_last"
        Me.cmd_last.Size = New System.Drawing.Size(29, 20)
        Me.cmd_last.TabIndex = 70
        Me.cmd_last.Text = ">>|"
        Me.cmd_last.UseVisualStyleBackColor = True
        '
        'cmd_next
        '
        Me.cmd_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_next.Location = New System.Drawing.Point(644, 79)
        Me.cmd_next.Name = "cmd_next"
        Me.cmd_next.Size = New System.Drawing.Size(40, 20)
        Me.cmd_next.TabIndex = 69
        Me.cmd_next.Text = ">>"
        Me.cmd_next.UseVisualStyleBackColor = True
        '
        'cmd_prev
        '
        Me.cmd_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_prev.Location = New System.Drawing.Point(598, 79)
        Me.cmd_prev.Name = "cmd_prev"
        Me.cmd_prev.Size = New System.Drawing.Size(40, 20)
        Me.cmd_prev.TabIndex = 68
        Me.cmd_prev.Text = "<<"
        Me.cmd_prev.UseVisualStyleBackColor = True
        '
        'cmd_first
        '
        Me.cmd_first.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_first.Location = New System.Drawing.Point(563, 79)
        Me.cmd_first.Name = "cmd_first"
        Me.cmd_first.Size = New System.Drawing.Size(29, 20)
        Me.cmd_first.TabIndex = 67
        Me.cmd_first.Text = "|<<"
        Me.cmd_first.UseVisualStyleBackColor = True
        '
        'search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 546)
        Me.Controls.Add(Me.cmd_go)
        Me.Controls.Add(Me.txt_nPage)
        Me.Controls.Add(Me.cmd_last)
        Me.Controls.Add(Me.cmd_next)
        Me.Controls.Add(Me.cmd_prev)
        Me.Controls.Add(Me.cmd_first)
        Me.Controls.Add(Me.dg_view)
        Me.Controls.Add(Me.cmd_addItem)
        Me.Controls.Add(Me.lbl_borrarbusqueda)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.lblbusqueda)
        Me.Name = "search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar"
        CType(Me.dg_view, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents lblbusqueda As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_borrarbusqueda As System.Windows.Forms.Label
    Friend WithEvents cmd_addItem As System.Windows.Forms.Button
    Friend WithEvents dg_view As System.Windows.Forms.DataGridView
    Friend WithEvents cmd_go As Button
    Friend WithEvents txt_nPage As TextBox
    Friend WithEvents cmd_last As Button
    Friend WithEvents cmd_next As Button
    Friend WithEvents cmd_prev As Button
    Friend WithEvents cmd_first As Button
End Class
