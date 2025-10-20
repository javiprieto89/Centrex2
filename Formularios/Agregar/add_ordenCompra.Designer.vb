<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_ordenCompra
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
        Me.components = New System.ComponentModel.Container()
        Me.cmd_add_item = New System.Windows.Forms.Button()
        Me.lbl_fechaCarga = New System.Windows.Forms.Label()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.lbl_fecha1 = New System.Windows.Forms.Label()
        Me.cms_general = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_impuestos = New System.Windows.Forms.TextBox()
        Me.lbl_impuestos = New System.Windows.Forms.Label()
        Me.txt_subTotal = New System.Windows.Forms.TextBox()
        Me.lbl_subTotal = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.dg_viewOC = New System.Windows.Forms.DataGridView()
        Me.lbl_nOrdenCompra = New System.Windows.Forms.Label()
        Me.lbl_ordenCompra = New System.Windows.Forms.Label()
        Me.pic_searchProveedor = New System.Windows.Forms.PictureBox()
        Me.lbl_fechaRecepcion = New System.Windows.Forms.Label()
        Me.lbl_fecha2 = New System.Windows.Forms.Label()
        Me.chk_imprimir = New System.Windows.Forms.CheckBox()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.lbl_nota = New System.Windows.Forms.Label()
        Me.txt_totalO = New System.Windows.Forms.TextBox()
        Me.cms_enviado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarArtículoRecibidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarCantidadRecibidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_fecha3 = New System.Windows.Forms.Label()
        Me.dtp_fechaComprobante = New System.Windows.Forms.DateTimePicker()
        Me.cms_general.SuspendLayout()
        CType(Me.dg_viewOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_enviado.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_add_item
        '
        Me.cmd_add_item.Location = New System.Drawing.Point(19, 406)
        Me.cmd_add_item.Name = "cmd_add_item"
        Me.cmd_add_item.Size = New System.Drawing.Size(133, 22)
        Me.cmd_add_item.TabIndex = 1
        Me.cmd_add_item.Text = "Añadir producto"
        Me.cmd_add_item.UseVisualStyleBackColor = True
        '
        'lbl_fechaCarga
        '
        Me.lbl_fechaCarga.AutoSize = True
        Me.lbl_fechaCarga.Location = New System.Drawing.Point(156, 25)
        Me.lbl_fechaCarga.Name = "lbl_fechaCarga"
        Me.lbl_fechaCarga.Size = New System.Drawing.Size(50, 13)
        Me.lbl_fechaCarga.TabIndex = 49
        Me.lbl_fechaCarga.Text = "%fecha%"
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(332, 683)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(232, 683)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(19, 148)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 41
        Me.lbl_proveedor.Text = "Proveedor"
        '
        'lbl_fecha1
        '
        Me.lbl_fecha1.AutoSize = True
        Me.lbl_fecha1.Location = New System.Drawing.Point(19, 25)
        Me.lbl_fecha1.Name = "lbl_fecha1"
        Me.lbl_fecha1.Size = New System.Drawing.Size(85, 13)
        Me.lbl_fecha1.TabIndex = 38
        Me.lbl_fecha1.Text = "Fecha de carga:"
        '
        'cms_general
        '
        Me.cms_general.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.cms_general.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.BorrarToolStripMenuItem})
        Me.cms_general.Name = "ContextMenuStrip1"
        Me.cms_general.Size = New System.Drawing.Size(107, 48)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'chk_secuencia
        '
        Me.chk_secuencia.AutoSize = True
        Me.chk_secuencia.Location = New System.Drawing.Point(19, 632)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 5
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(447, 453)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(54, 20)
        Me.lbl_total.TabIndex = 53
        Me.lbl_total.Text = "Total:"
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(528, 453)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(80, 20)
        Me.txt_total.TabIndex = 4
        '
        'txt_impuestos
        '
        Me.txt_impuestos.Location = New System.Drawing.Point(340, 453)
        Me.txt_impuestos.Name = "txt_impuestos"
        Me.txt_impuestos.ReadOnly = True
        Me.txt_impuestos.Size = New System.Drawing.Size(80, 20)
        Me.txt_impuestos.TabIndex = 60
        '
        'lbl_impuestos
        '
        Me.lbl_impuestos.AutoSize = True
        Me.lbl_impuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_impuestos.Location = New System.Drawing.Point(229, 453)
        Me.lbl_impuestos.Name = "lbl_impuestos"
        Me.lbl_impuestos.Size = New System.Drawing.Size(84, 20)
        Me.lbl_impuestos.TabIndex = 61
        Me.lbl_impuestos.Text = "Impuestos"
        '
        'txt_subTotal
        '
        Me.txt_subTotal.Location = New System.Drawing.Point(122, 453)
        Me.txt_subTotal.Name = "txt_subTotal"
        Me.txt_subTotal.ReadOnly = True
        Me.txt_subTotal.Size = New System.Drawing.Size(80, 20)
        Me.txt_subTotal.TabIndex = 633
        '
        'lbl_subTotal
        '
        Me.lbl_subTotal.AutoSize = True
        Me.lbl_subTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_subTotal.Location = New System.Drawing.Point(19, 453)
        Me.lbl_subTotal.Name = "lbl_subTotal"
        Me.lbl_subTotal.Size = New System.Drawing.Size(73, 20)
        Me.lbl_subTotal.TabIndex = 64
        Me.lbl_subTotal.Text = "Subtotal:"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(81, 143)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(493, 21)
        Me.cmb_proveedor.TabIndex = 635
        '
        'dg_viewOC
        '
        Me.dg_viewOC.AllowUserToAddRows = False
        Me.dg_viewOC.AllowUserToDeleteRows = False
        Me.dg_viewOC.AllowUserToOrderColumns = True
        Me.dg_viewOC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dg_viewOC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewOC.ContextMenuStrip = Me.cms_general
        Me.dg_viewOC.Location = New System.Drawing.Point(19, 174)
        Me.dg_viewOC.MultiSelect = False
        Me.dg_viewOC.Name = "dg_viewOC"
        Me.dg_viewOC.ReadOnly = True
        Me.dg_viewOC.RowHeadersVisible = False
        Me.dg_viewOC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewOC.Size = New System.Drawing.Size(592, 216)
        Me.dg_viewOC.TabIndex = 640
        '
        'lbl_nOrdenCompra
        '
        Me.lbl_nOrdenCompra.AutoSize = True
        Me.lbl_nOrdenCompra.Location = New System.Drawing.Point(541, 25)
        Me.lbl_nOrdenCompra.Name = "lbl_nOrdenCompra"
        Me.lbl_nOrdenCompra.Size = New System.Drawing.Size(65, 13)
        Me.lbl_nOrdenCompra.TabIndex = 643
        Me.lbl_nOrdenCompra.Text = "%oCompra%"
        Me.lbl_nOrdenCompra.Visible = False
        '
        'lbl_ordenCompra
        '
        Me.lbl_ordenCompra.AutoSize = True
        Me.lbl_ordenCompra.Location = New System.Drawing.Point(448, 25)
        Me.lbl_ordenCompra.Name = "lbl_ordenCompra"
        Me.lbl_ordenCompra.Size = New System.Drawing.Size(92, 13)
        Me.lbl_ordenCompra.TabIndex = 642
        Me.lbl_ordenCompra.Text = "Orden de compra:"
        Me.lbl_ordenCompra.Visible = False
        '
        'pic_searchProveedor
        '
        Me.pic_searchProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchProveedor.Location = New System.Drawing.Point(591, 143)
        Me.pic_searchProveedor.Name = "pic_searchProveedor"
        Me.pic_searchProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchProveedor.TabIndex = 48
        Me.pic_searchProveedor.TabStop = False
        '
        'lbl_fechaRecepcion
        '
        Me.lbl_fechaRecepcion.AutoSize = True
        Me.lbl_fechaRecepcion.Location = New System.Drawing.Point(156, 106)
        Me.lbl_fechaRecepcion.Name = "lbl_fechaRecepcion"
        Me.lbl_fechaRecepcion.Size = New System.Drawing.Size(103, 13)
        Me.lbl_fechaRecepcion.TabIndex = 662
        Me.lbl_fechaRecepcion.Text = "%fecha_recepcion%"
        Me.lbl_fechaRecepcion.Visible = False
        '
        'lbl_fecha2
        '
        Me.lbl_fecha2.AutoSize = True
        Me.lbl_fecha2.Location = New System.Drawing.Point(19, 106)
        Me.lbl_fecha2.Name = "lbl_fecha2"
        Me.lbl_fecha2.Size = New System.Drawing.Size(105, 13)
        Me.lbl_fecha2.TabIndex = 661
        Me.lbl_fecha2.Text = "Fecha de recepción:"
        '
        'chk_imprimir
        '
        Me.chk_imprimir.AutoSize = True
        Me.chk_imprimir.Location = New System.Drawing.Point(19, 590)
        Me.chk_imprimir.Name = "chk_imprimir"
        Me.chk_imprimir.Size = New System.Drawing.Size(144, 17)
        Me.chk_imprimir.TabIndex = 667
        Me.chk_imprimir.Text = "Imprimir orden de compra"
        Me.chk_imprimir.UseVisualStyleBackColor = True
        '
        'txt_nota
        '
        Me.txt_nota.Location = New System.Drawing.Point(62, 503)
        Me.txt_nota.MaxLength = 91
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(546, 57)
        Me.txt_nota.TabIndex = 665
        '
        'lbl_nota
        '
        Me.lbl_nota.AutoSize = True
        Me.lbl_nota.Location = New System.Drawing.Point(19, 523)
        Me.lbl_nota.Name = "lbl_nota"
        Me.lbl_nota.Size = New System.Drawing.Size(38, 13)
        Me.lbl_nota.TabIndex = 666
        Me.lbl_nota.Text = "Notas:"
        '
        'txt_totalO
        '
        Me.txt_totalO.Location = New System.Drawing.Point(283, 408)
        Me.txt_totalO.Name = "txt_totalO"
        Me.txt_totalO.ReadOnly = True
        Me.txt_totalO.Size = New System.Drawing.Size(166, 20)
        Me.txt_totalO.TabIndex = 668
        Me.txt_totalO.Visible = False
        '
        'cms_enviado
        '
        Me.cms_enviado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarArtículoRecibidoToolStripMenuItem, Me.ModificarCantidadRecibidaToolStripMenuItem})
        Me.cms_enviado.Name = "cms2"
        Me.cms_enviado.Size = New System.Drawing.Size(220, 48)
        '
        'ModificarArtículoRecibidoToolStripMenuItem
        '
        Me.ModificarArtículoRecibidoToolStripMenuItem.Name = "ModificarArtículoRecibidoToolStripMenuItem"
        Me.ModificarArtículoRecibidoToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ModificarArtículoRecibidoToolStripMenuItem.Text = "Modificar artículo recibido"
        '
        'ModificarCantidadRecibidaToolStripMenuItem
        '
        Me.ModificarCantidadRecibidaToolStripMenuItem.Name = "ModificarCantidadRecibidaToolStripMenuItem"
        Me.ModificarCantidadRecibidaToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ModificarCantidadRecibidaToolStripMenuItem.Text = "Modificar cantidad recibida"
        '
        'lbl_fecha3
        '
        Me.lbl_fecha3.AutoSize = True
        Me.lbl_fecha3.Location = New System.Drawing.Point(16, 64)
        Me.lbl_fecha3.Name = "lbl_fecha3"
        Me.lbl_fecha3.Size = New System.Drawing.Size(122, 13)
        Me.lbl_fecha3.TabIndex = 669
        Me.lbl_fecha3.Text = "Fecha del comprobante:"
        '
        'dtp_fechaComprobante
        '
        Me.dtp_fechaComprobante.Location = New System.Drawing.Point(159, 58)
        Me.dtp_fechaComprobante.Name = "dtp_fechaComprobante"
        Me.dtp_fechaComprobante.Size = New System.Drawing.Size(217, 20)
        Me.dtp_fechaComprobante.TabIndex = 670
        '
        'add_ordenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmd_exit
        Me.ClientSize = New System.Drawing.Size(628, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtp_fechaComprobante)
        Me.Controls.Add(Me.lbl_fecha3)
        Me.Controls.Add(Me.txt_totalO)
        Me.Controls.Add(Me.chk_imprimir)
        Me.Controls.Add(Me.txt_nota)
        Me.Controls.Add(Me.lbl_nota)
        Me.Controls.Add(Me.lbl_fechaRecepcion)
        Me.Controls.Add(Me.lbl_fecha2)
        Me.Controls.Add(Me.lbl_nOrdenCompra)
        Me.Controls.Add(Me.lbl_ordenCompra)
        Me.Controls.Add(Me.dg_viewOC)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.txt_subTotal)
        Me.Controls.Add(Me.lbl_subTotal)
        Me.Controls.Add(Me.txt_impuestos)
        Me.Controls.Add(Me.lbl_impuestos)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_add_item)
        Me.Controls.Add(Me.lbl_fechaCarga)
        Me.Controls.Add(Me.pic_searchProveedor)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.lbl_fecha1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "add_ordenCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga de orden de compra"
        Me.cms_general.ResumeLayout(False)
        CType(Me.dg_viewOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_enviado.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_add_item As System.Windows.Forms.Button
    Friend WithEvents lbl_fechaCarga As System.Windows.Forms.Label
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha1 As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents cms_general As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents lbl_impuestos As System.Windows.Forms.Label
    Friend WithEvents txt_subTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_subTotal As System.Windows.Forms.Label
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents pic_searchProveedor As System.Windows.Forms.PictureBox
    Friend WithEvents dg_viewOC As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_nOrdenCompra As System.Windows.Forms.Label
    Friend WithEvents lbl_ordenCompra As System.Windows.Forms.Label
    Friend WithEvents lbl_fechaRecepcion As Label
    Friend WithEvents lbl_fecha2 As Label
    Friend WithEvents chk_imprimir As CheckBox
    Friend WithEvents txt_nota As TextBox
    Friend WithEvents lbl_nota As Label
    Friend WithEvents txt_totalO As TextBox
    Friend WithEvents cms_enviado As ContextMenuStrip
    Friend WithEvents ModificarArtículoRecibidoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarCantidadRecibidaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lbl_fecha3 As Label
    Friend WithEvents dtp_fechaComprobante As DateTimePicker
End Class
