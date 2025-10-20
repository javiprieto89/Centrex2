Public Class add_produccion

    Private recibido As Boolean = False
    Private idUsuario As Integer
    Private idUnico As String


    Private Sub add_produccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        'Cargo todos los proveedores
        cargar_combo(cmb_proveedor, "SELECT id_proveedor, razon_social FROM proveedores WHERE activo = '1' ORDER BY razon_social ASC", basedb, "razon_social", "id_proveedor")
        cmb_proveedor.SelectedIndex = 0
        cmb_proveedor.Text = "Seleccione un proveedor..."


        If edicion Or borrado = True Then
            lbl_nProduccion.Text = edita_produccion.id_produccion
            lbl_produccion.Visible = True
            lbl_nProduccion.Visible = True
            lbl_fechaCarga.Text = DateTime.Parse(edita_produccion.fecha_carga)

            If edita_produccion.fecha_envio <> "" Then
                lbl_fechaEnvio.Text = DateTime.Parse(edita_produccion.fecha_envio)
                cmd_enviar.Text = "Cerrar pedido"
                dg_viewProduccion.ContextMenuStrip = cms_enviado
                recibido = True
            Else
                lbl_fechaEnvio.Text = ""
            End If

            If edita_produccion.fecha_recepcion <> "" Then
                lbl_fechaRecepcion.Text = DateTime.Parse(edita_produccion.fecha_recepcion)
            Else
                lbl_fechaRecepcion.Text = ""
            End If

            'Dim pv As New proveedor
            'PV = info_proveedor(edita_produccion.id_proveedor)
            cmb_proveedor.SelectedValue = edita_produccion.id_proveedor
            cmb_proveedor.Enabled = False

            actualizarDataGrid()
        Else
            generales_multiUsuario.borrarTmpProduccion(usuario_logueado.id_usuario)
            lbl_fechaCarga.Text = Hoy()
            lbl_fechaEnvio.Text = ""
            lbl_fechaRecepcion.Text = ""
        End If

        If borrado Or (edita_produccion.id_produccion <> 0 And edita_produccion.activo = False) Then
            cmb_proveedor.Enabled = False
            cmd_add_item.Enabled = False
            pic_searchProveedor.Enabled = False
            'dg_viewProduccion.Enabled = False
            chk_imprimir.Enabled = False
            chk_secuencia.Enabled = False
            cmd_ok.Enabled = False
            cmd_enviar.Enabled = False
        End If

        If borrado Then
            If Not edita_produccion.activo Then
                Me.Show()
                MsgBox("No se puede borrar un pedido de producción ya recibido", vbOKOnly + vbExclamation, "Centrex")
                closeandupdate(Me)
                Exit Sub
            End If

            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este pedido de producción?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                'borrartbl("tmpproduccion_items", True)
                generales_multiUsuario.borrarTmpProduccion(usuario_logueado.id_usuario)
                ejecutarSQL("DELETE FROM produccion_items WHERE id_produccion = '" + edita_produccion.id_produccion.ToString + "'")
                If borrarProduccion(edita_produccion) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del pedido de producción, ¿desea intetar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateProduccion(edita_produccion, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el pedido no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el pedido, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el pedido de producción.")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub add_produccion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        id = 0
        Dim prod As New produccion
        edita_produccion = prod
        'borro la tabla temporal
        'borrartbl("tmpproduccion_items", True)
        generales_multiUsuario.borrarTmpProduccion(usuario_logueado.id_usuario)
        'restauro los que se borraron porque no se guardaron los cambios
        activaitems("produccion_items")
        edicion = False
        closeandupdate(Me)
    End Sub

    Private Sub cmd_add_item_Click(sender As Object, e As EventArgs) Handles cmd_add_item.Click
        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo
        tabla = "items_sinDescuento"
        activo = True

        agregaitem = True
        Me.Enabled = False

        Dim srch As New search(True, False, True)
        srch.ShowDialog()
        tabla = tmpTabla
        activo = tmpActivo
        agregaitem = False
        actualizarDataGrid()
        If Tiene_Items_Asociados(id) Then
            Dim frm_detalle_prod As New frm_detalle_asoc_produccion(id)
            frm_detalle_prod.ShowDialog()
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim ultimaProd As produccion = Nothing
        Dim p As New produccion
        Dim sqlstr As String = ""

        If cmb_proveedor.Text = "Seleccione un proveedor..." Or cmb_proveedor.Text = "" Then
            MsgBox("El campo 'Proveedor' es obligatorio y está vacio")
            Exit Sub
        ElseIf dg_viewProduccion.Rows.Count = 0 Then
            MsgBox("No hay items cargados")
            Exit Sub
        End If

        p.id_proveedor = cmb_proveedor.SelectedValue
        p.fecha_carga = lbl_fechaCarga.Text
        If lbl_fechaEnvio.Text <> "" Then
            p.fecha_envio = lbl_fechaEnvio.Text
            p.enviado = True
        Else
            p.enviado = False
        End If

        If lbl_fechaRecepcion.Text <> "" Then
            p.fecha_recepcion = lbl_fechaRecepcion.Text
            p.recibido = True
            p.activo = False
        Else
            p.recibido = False
            p.activo = True
        End If

        If edicion Then
            p.id_produccion = edita_produccion.id_produccion
            ultimaProd = p
            If Not updateProduccion(p) Then
                MsgBox("Hubo un problema al actualizar el pedido de producción.", vbExclamation)
                closeandupdate(Me)
            End If
            guardarProduccion(edita_produccion.id_produccion)
            If p.recibido Then
                'Si se recibio la mercadería, igualo los productos recibidos si no es que se explicitó que son distintos
                'y hago lo mismo con las cantidades
                sqlstr = "UPDATE produccion_items " &
                        "SET id_item_recibido = id_item " &
                        "WHERE id_produccion = '" + edita_produccion.id_produccion.ToString + "' " &
                        "AND id_item_recibido IS NULL"
                ejecutarSQL(sqlstr)

                sqlstr = "UPDATE produccion_items " &
                        "SET cantidad_recibida = cantidad " &
                        "WHERE id_produccion = '" + edita_produccion.id_produccion.ToString + "' " &
                        "AND cantidad_recibida IS NULL"
                ejecutarSQL(sqlstr)

                'Cierro el pedido para que se actualice el stock
                sqlstr = "UPDATE produccion_items " &
                        "SET activo = '0' " &
                        "WHERE id_produccion = '" + edita_produccion.id_produccion.ToString + "'"
                ejecutarSQL(sqlstr)
            End If
            'borrartbl("tmpproduccion_items", True)
            generales_multiUsuario.borrarTmpProduccion(usuario_logueado.id_usuario)
        Else
            'Agrego el pedido de producción
            If addProduccion(p) Then
                ultimaProd = info_produccion()
                'Agrego los items al pedido
                If Not guardarProduccion(ultimaProd.id_produccion) Then
                    MsgBox("Hubo un problema al agregar el pedido de producción.", vbExclamation)
                    'borrartbl("tmpproduccion_asocItems")
                    'borrartbl("tmpproduccion_items", True)
                    generales_multiUsuario.borrarTmpProduccion(usuario_logueado.id_usuario)
                    closeandupdate(Me)
                Else
                    'borrartbl("tmpproduccion_asocItems")
                    'borrartbl("tmpproduccion_items", True)
                    generales_multiUsuario.borrarTmpProduccion(usuario_logueado.id_usuario)
                End If
            Else
                MsgBox("Hubo un problema al agregar el pedido de producción.", vbExclamation)
                'borrartbl("tmpproduccion_asocItems")
                'borrartbl("tmpproduccion_items", True)
                generales_multiUsuario.borrarTmpProduccion(usuario_logueado.id_usuario)
                closeandupdate(Me)
            End If
        End If

        If chk_imprimir.Checked Then
            Dim frm As New frm_prnReportes("rpt_produccion", "datos_empresa", "produccion_cabecera", "produccion_detalle", "DS_empresa",
                                            "Produccion_cabecera", "Produccion_detalle", ultimaProd.id_produccion)
            frm.ShowDialog()
        End If

        If chk_secuencia.Checked = True Then
            'borrartbl("tmpproduccion_items",true) 'Ya debería estar borrada la tabla
            'cmb_proveedor.SelectedValue = 0
            'cmb_proveedor.Text = "Seleccione un proveedor..."
            actualizarDataGrid()
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub pic_searchProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchProveedor.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_proveedor_default
        updateform(id.ToString, cmb_proveedor)
    End Sub

    Private Sub dg_view_DoubleClick(sender As Object, e As EventArgs) Handles dg_viewProduccion.DoubleClick
        Dim seleccionado As String
        Dim seleccionado_b As String

        If edita_produccion.id_produccion <> 0 And Not edita_produccion.activo Then
            Exit Sub
        ElseIf edicion And edita_produccion.enviado Then
            MsgBox("No puede editar un item ya enviado al proveedor", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        'Obtengo el ID del item
        seleccionado = dg_viewProduccion.CurrentRow.Cells(0).Value.ToString()
        seleccionado = Microsoft.VisualBasic.Right(seleccionado, (seleccionado.Length - InStr(seleccionado, "-")))

        edita_item = info_item(seleccionado)

        'Obtengo el ID interno de la tabla tmppedidos_items
        seleccionado_b = dg_viewProduccion.CurrentRow.Cells(0).Value.ToString
        edita_item.id_item_temporal = Microsoft.VisualBasic.Left(seleccionado_b, (InStr(seleccionado_b, "-") - 1))

        Dim agregaItemFrm As New infoagregaitem(True, False, True, idUsuario, idUnico)
        agregaItemFrm.ShowDialog()

        'Dim i As New item
        'edita_item = info_item(id)
        actualizarDataGrid()
        If Tiene_Items_Asociados(edita_item.id_item) Then
            If edita_produccion.id_produccion <> Nothing And edita_produccion.id_produccion <> 0 Then
                'Ya hay un pedido de producción guardado
                Dim frm_detalle_prod As New frm_detalle_asoc_produccion(edita_item.id_item, edita_produccion.id_produccion)
                frm_detalle_prod.ShowDialog()
            Else
                'Se está dando de alta el pedido de producción
                Dim frm_detalle_prod As New frm_detalle_asoc_produccion(edita_item.id_item)
                frm_detalle_prod.ShowDialog()
            End If
        End If
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        dg_view_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        Dim seleccionado As String
        Dim id_tmpPedidoItem_seleccionado As String

        If dg_viewProduccion.Rows.Count = 0 Then Exit Sub

        If edicion And edita_produccion.enviado Then
            MsgBox("No puede editar un item ya enviado al proveedor", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        seleccionado = dg_viewProduccion.CurrentRow.Cells(0).Value.ToString()

        'Obtengo el ID interno de la tabla tmppedidos_items
        id_tmpPedidoItem_seleccionado = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        borraritemCargado(id_tmpPedidoItem_seleccionado)
    End Sub

    Private Sub dg_view_MouseDown(sender As Object, e As MouseEventArgs) Handles dg_viewProduccion.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.dg_viewProduccion
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
                Me.cms_general.Visible = True
            End With
        End If
    End Sub

    Private Sub cmb_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_proveedor.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmd_enviar_Click(sender As Object, e As EventArgs) Handles cmd_enviar.Click
        If recibido Then
            If MsgBox("ATENCIÓN: Si finaliza la recepción, NO PODRÁ realizar más modificaciones en la orden de producción." & vbCrLf &
                "Se supondrá que los artículos y cantidades que regresaron fueron las mismas que se solicitaron para aquellos en los cuales no haya seleccionado expresamente lo contrario " & vbCrLf &
                "¿Está seguro?", vbYesNo + vbQuestion, "Centrex") = vbYes Then
                lbl_fechaRecepcion.Text = Hoy()
            Else
                Exit Sub
            End If
        Else
            lbl_fechaEnvio.Text = Hoy()
        End If
        cmd_ok_Click(Nothing, Nothing)
    End Sub

    Private Sub actualizarDataGrid()
        Dim sqlstr As String

        sqlstr = "SELECT CONCAT(ti.id_tmpProduccionItem, '-', ti.id_item) AS 'ID', ti.id_produccionItem AS 'id_produccionItem', " &
                    "CASE WHEN i.id_item IS NULL THEN ti.descript ELSE i.descript END AS 'Producto', " &
                    "ti.cantidad AS 'Cant.', " &
                    "CASE WHEN ti.id_item_recibido IS NULL THEN '' ELSE ii.descript END AS 'Producto Recibido', " &
                    "ti.cantidad_recibida AS 'Cantidad Recibida' " &
                   "FROM tmpproduccion_items AS ti " &
                   "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                   "LEFT JOIN items AS ii ON ti.id_item_recibido = ii.id_item " &
                   "WHERE ti.activo = '1' AND (i.esMarkup = '0' OR ti.id_item IS NULL) " &
                   "ORDER BY id ASC"
        cargar_datagrid(dg_viewProduccion, sqlstr, basedb)
    End Sub

    Private Sub ModificarArtículoRecibidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarArtículoRecibidoToolStripMenuItem.Click
        Dim seleccionado As String
        Dim sqlstr As String
        Dim tmpTabla As String
        Dim tmpActivo As Boolean
        Dim id_item As Integer
        Dim id_item_tmp As Integer

        'Obtengo el ID interno de la tabla tmpproduccion_items
        seleccionado = dg_viewProduccion.CurrentRow.Cells(0).Value.ToString
        id_item_tmp = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        tmpTabla = tabla
        tmpActivo = activo
        tabla = "items_sinDescuento"
        activo = True

        Me.Enabled = False
        Dim srch As New search(True, False, False)
        srch.ShowDialog()
        id_item = id

        sqlstr = "UPDATE tmpproduccion_items SET id_item_recibido = '" + id_item.ToString + "' WHERE id_tmpProduccionItem = '" + id_item_tmp.ToString + "'"
        ejecutarSQL(sqlstr)

        actualizarDataGrid()
    End Sub

    Private Sub ModificarCantidadRecibidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarCantidadRecibidaToolStripMenuItem.Click
        Dim seleccionado As String
        Dim sqlstr As String
        Dim cantidad_recibida As Integer

        'Obtengo el ID del item
        seleccionado = dg_viewProduccion.CurrentRow.Cells(0).Value.ToString()
        seleccionado = Microsoft.VisualBasic.Right(seleccionado, (seleccionado.Length - InStr(seleccionado, "-")))

        edita_item = info_item(seleccionado)

        'Obtengo el ID interno de la tabla tmpproduccion_items
        seleccionado = dg_viewProduccion.CurrentRow.Cells(0).Value.ToString
        edita_item.id_item_temporal = Microsoft.VisualBasic.Left(seleccionado, (InStr(seleccionado, "-") - 1))

        Dim agregaItem As New infoagregaitem(True, False, False, idUsuario, idUnico)
        agregaItem.ShowDialog()
        cantidad_recibida = agregaItem.cant

        sqlstr = "UPDATE tmpproduccion_items SET cantidad_recibida = '" + cantidad_recibida.ToString + "' WHERE id_tmpProduccionItem = '" + edita_item.id_item_temporal.ToString + "'"
        ejecutarSQL(sqlstr)

        actualizarDataGrid()
    End Sub

    'Private Sub dg_viewProduccion_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_viewProduccion.CellMouseDoubleClick
    '    Dim idItemSeleccionado As String

    '    If dg_viewProduccion.Rows.Count = 0 Then Exit Sub

    '    idItemSeleccionado = dg_viewProduccion.CurrentRow.Cells(0).Value.ToString

    '    idItemSeleccionado = Strings.Right(idItemSeleccionado, (InStr(idItemSeleccionado, "-") - 1))

    '    If Tiene_Items_Asociados(idItemSeleccionado) Then
    '        'Dim frm_detalle_prod As New frm_detalle_asoc_produccion(id)
    '        'frm_detalle_prod.ShowDialog()
    '        MsgBox("Tiene asociados")
    '    Else
    '        MsgBox("No tiene asociados")
    '    End If
    'End Sub
End Class