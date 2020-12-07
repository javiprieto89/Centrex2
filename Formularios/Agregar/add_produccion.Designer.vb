<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_produccion
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
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_ok = New System.Windows.Forms.Button()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.cms_general = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chk_secuencia = New System.Windows.Forms.CheckBox()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.lbl_nota = New System.Windows.Forms.Label()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.dg_viewProduccion = New System.Windows.Forms.DataGridView()
        Me.lbl_fechaCarga = New System.Windows.Forms.Label()
        Me.lbl_fecha1 = New System.Windows.Forms.Label()
        Me.lbl_fechaRecepcion = New System.Windows.Forms.Label()
        Me.lbl_fecha3 = New System.Windows.Forms.Label()
        Me.lbl_fechaEnvio = New System.Windows.Forms.Label()
        Me.lbl_fecha2 = New System.Windows.Forms.Label()
        Me.lbl_produccion = New System.Windows.Forms.Label()
        Me.lbl_nProduccion = New System.Windows.Forms.Label()
        Me.cmd_enviar = New System.Windows.Forms.Button()
        Me.cms_enviado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarArtículoRecibidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarCantidadRecibidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chk_imprimir = New System.Windows.Forms.CheckBox()
        Me.pic_searchProveedor = New System.Windows.Forms.PictureBox()
        Me.cms_general.SuspendLayout()
        CType(Me.dg_viewProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_enviado.SuspendLayout()
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_add_item
        '
        Me.cmd_add_item.Location = New System.Drawing.Point(14, 386)
        Me.cmd_add_item.Name = "cmd_add_item"
        Me.cmd_add_item.Size = New System.Drawing.Size(133, 22)
        Me.cmd_add_item.TabIndex = 1
        Me.cmd_add_item.Text = "Añadir producto"
        Me.cmd_add_item.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(384, 586)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(75, 23)
        Me.cmd_exit.TabIndex = 5
        Me.cmd_exit.Text = "Salir"
        Me.cmd_exit.UseVisualStyleBackColor = True
        '
        'cmd_ok
        '
        Me.cmd_ok.Location = New System.Drawing.Point(160, 586)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "Guardar"
        Me.cmd_ok.UseVisualStyleBackColor = True
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(12, 126)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbl_proveedor.TabIndex = 41
        Me.lbl_proveedor.Text = "Proveedor"
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
        Me.chk_secuencia.Location = New System.Drawing.Point(20, 547)
        Me.chk_secuencia.Name = "chk_secuencia"
        Me.chk_secuencia.Size = New System.Drawing.Size(108, 17)
        Me.chk_secuencia.TabIndex = 5
        Me.chk_secuencia.Text = "Carga secuencial"
        Me.chk_secuencia.UseVisualStyleBackColor = True
        '
        'txt_nota
        '
        Me.txt_nota.Location = New System.Drawing.Point(61, 432)
        Me.txt_nota.MaxLength = 91
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(546, 57)
        Me.txt_nota.TabIndex = 8
        '
        'lbl_nota
        '
        Me.lbl_nota.AutoSize = True
        Me.lbl_nota.Location = New System.Drawing.Point(17, 452)
        Me.lbl_nota.Name = "lbl_nota"
        Me.lbl_nota.Size = New System.Drawing.Size(38, 13)
        Me.lbl_nota.TabIndex = 57
        Me.lbl_nota.Text = "Notas:"
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(78, 121)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(490, 21)
        Me.cmb_proveedor.TabIndex = 635
        '
        'dg_viewProduccion
        '
        Me.dg_viewProduccion.AllowUserToAddRows = False
        Me.dg_viewProduccion.AllowUserToDeleteRows = False
        Me.dg_viewProduccion.AllowUserToOrderColumns = True
        Me.dg_viewProduccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dg_viewProduccion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_viewProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_viewProduccion.ContextMenuStrip = Me.cms_general
        Me.dg_viewProduccion.Location = New System.Drawing.Point(14, 155)
        Me.dg_viewProduccion.MultiSelect = False
        Me.dg_viewProduccion.Name = "dg_viewProduccion"
        Me.dg_viewProduccion.ReadOnly = True
        Me.dg_viewProduccion.RowHeadersVisible = False
        Me.dg_viewProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_viewProduccion.Size = New System.Drawing.Size(592, 216)
        Me.dg_viewProduccion.TabIndex = 640
        '
        'lbl_fechaCarga
        '
        Me.lbl_fechaCarga.AutoSize = True
        Me.lbl_fechaCarga.Location = New System.Drawing.Point(134, 18)
        Me.lbl_fechaCarga.Name = "lbl_fechaCarga"
        Me.lbl_fechaCarga.Size = New System.Drawing.Size(83, 13)
        Me.lbl_fechaCarga.TabIndex = 662
        Me.lbl_fechaCarga.Text = "%fecha_carga%"
        '
        'lbl_fecha1
        '
        Me.lbl_fecha1.AutoSize = True
        Me.lbl_fecha1.Location = New System.Drawing.Point(12, 18)
        Me.lbl_fecha1.Name = "lbl_fecha1"
        Me.lbl_fecha1.Size = New System.Drawing.Size(85, 13)
        Me.lbl_fecha1.TabIndex = 661
        Me.lbl_fecha1.Text = "Fecha de carga:"
        '
        'lbl_fechaRecepcion
        '
        Me.lbl_fechaRecepcion.AutoSize = True
        Me.lbl_fechaRecepcion.Location = New System.Drawing.Point(134, 79)
        Me.lbl_fechaRecepcion.Name = "lbl_fechaRecepcion"
        Me.lbl_fechaRecepcion.Size = New System.Drawing.Size(103, 13)
        Me.lbl_fechaRecepcion.TabIndex = 660
        Me.lbl_fechaRecepcion.Text = "%fecha_recepcion%"
        Me.lbl_fechaRecepcion.Visible = False
        '
        'lbl_fecha3
        '
        Me.lbl_fecha3.AutoSize = True
        Me.lbl_fecha3.Location = New System.Drawing.Point(11, 79)
        Me.lbl_fecha3.Name = "lbl_fecha3"
        Me.lbl_fecha3.Size = New System.Drawing.Size(105, 13)
        Me.lbl_fecha3.TabIndex = 659
        Me.lbl_fecha3.Text = "Fecha de recepción:"
        '
        'lbl_fechaEnvio
        '
        Me.lbl_fechaEnvio.AutoSize = True
        Me.lbl_fechaEnvio.Location = New System.Drawing.Point(134, 48)
        Me.lbl_fechaEnvio.Name = "lbl_fechaEnvio"
        Me.lbl_fechaEnvio.Size = New System.Drawing.Size(82, 13)
        Me.lbl_fechaEnvio.TabIndex = 658
        Me.lbl_fechaEnvio.Text = "%fecha_envio%"
        '
        'lbl_fecha2
        '
        Me.lbl_fecha2.AutoSize = True
        Me.lbl_fecha2.Location = New System.Drawing.Point(12, 48)
        Me.lbl_fecha2.Name = "lbl_fecha2"
        Me.lbl_fecha2.Size = New System.Drawing.Size(86, 13)
        Me.lbl_fecha2.TabIndex = 657
        Me.lbl_fecha2.Text = "Fecha de envío:"
        '
        'lbl_produccion
        '
        Me.lbl_produccion.AutoSize = True
        Me.lbl_produccion.Location = New System.Drawing.Point(435, 18)
        Me.lbl_produccion.Name = "lbl_produccion"
        Me.lbl_produccion.Size = New System.Drawing.Size(114, 13)
        Me.lbl_produccion.TabIndex = 642
        Me.lbl_produccion.Text = "Pedido de producción:"
        Me.lbl_produccion.Visible = False
        '
        'lbl_nProduccion
        '
        Me.lbl_nProduccion.AutoSize = True
        Me.lbl_nProduccion.Location = New System.Drawing.Point(550, 18)
        Me.lbl_nProduccion.Name = "lbl_nProduccion"
        Me.lbl_nProduccion.Size = New System.Drawing.Size(55, 13)
        Me.lbl_nProduccion.TabIndex = 643
        Me.lbl_nProduccion.Text = "%pedido%"
        Me.lbl_nProduccion.Visible = False
        '
        'cmd_enviar
        '
        Me.cmd_enviar.Location = New System.Drawing.Point(257, 586)
        Me.cmd_enviar.Name = "cmd_enviar"
        Me.cmd_enviar.Size = New System.Drawing.Size(105, 23)
        Me.cmd_enviar.TabIndex = 663
        Me.cmd_enviar.Text = "Guardar y enviar"
        Me.cmd_enviar.UseVisualStyleBackColor = True
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
        'chk_imprimir
        '
        Me.chk_imprimir.AutoSize = True
        Me.chk_imprimir.Location = New System.Drawing.Point(20, 510)
        Me.chk_imprimir.Name = "chk_imprimir"
        Me.chk_imprimir.Size = New System.Drawing.Size(167, 17)
        Me.chk_imprimir.TabIndex = 664
        Me.chk_imprimir.Text = "Imprimir pedido de producción"
        Me.chk_imprimir.UseVisualStyleBackColor = True
        '
        'pic_searchProveedor
        '
        Me.pic_searchProveedor.Image = Global.Centrex.My.Resources.Resources.iconoLupa
        Me.pic_searchProveedor.Location = New System.Drawing.Point(584, 121)
        Me.pic_searchProveedor.Name = "pic_searchProveedor"
        Me.pic_searchProveedor.Size = New System.Drawing.Size(22, 22)
        Me.pic_searchProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pic_searchProveedor.TabIndex = 48
        Me.pic_searchProveedor.TabStop = False
        '
        'add_produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmd_exit
        Me.ClientSize = New System.Drawing.Size(618, 626)
        Me.ControlBox = False
        Me.Controls.Add(Me.chk_imprimir)
        Me.Controls.Add(Me.cmd_enviar)
        Me.Controls.Add(Me.lbl_fechaCarga)
        Me.Controls.Add(Me.lbl_fecha1)
        Me.Controls.Add(Me.lbl_fechaRecepcion)
        Me.Controls.Add(Me.lbl_fecha3)
        Me.Controls.Add(Me.lbl_fechaEnvio)
        Me.Controls.Add(Me.lbl_fecha2)
        Me.Controls.Add(Me.lbl_nProduccion)
        Me.Controls.Add(Me.lbl_produccion)
        Me.Controls.Add(Me.dg_viewProduccion)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.txt_nota)
        Me.Controls.Add(Me.lbl_nota)
        Me.Controls.Add(Me.chk_secuencia)
        Me.Controls.Add(Me.cmd_add_item)
        Me.Controls.Add(Me.pic_searchProveedor)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_ok)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "add_produccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga de pedido de producción"
        Me.cms_general.ResumeLayout(False)
        CType(Me.dg_viewProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_enviado.ResumeLayout(False)
        CType(Me.pic_searchProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_add_item As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents chk_secuencia As System.Windows.Forms.CheckBox
    Friend WithEvents cms_general As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_nota As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nota As System.Windows.Forms.Label
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents pic_searchProveedor As System.Windows.Forms.PictureBox
    Friend WithEvents dg_viewProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_fechaCarga As Label
    Friend WithEvents lbl_fecha1 As Label
    Friend WithEvents lbl_fechaRecepcion As Label
    Friend WithEvents lbl_fecha3 As Label
    Friend WithEvents lbl_fechaEnvio As Label
    Friend WithEvents lbl_fecha2 As Label
    Friend WithEvents lbl_produccion As Label
    Friend WithEvents lbl_nProduccion As Label
    Friend WithEvents cmd_enviar As Button
    Friend WithEvents cms_enviado As ContextMenuStrip
    Friend WithEvents ModificarArtículoRecibidoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarCantidadRecibidaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents chk_imprimir As CheckBox
End Class
