Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Module generales
    Public CN As New SqlConnection

    '************************************* FUNCIONES GENERALES *****************************
    Public Function abrirdb(server As String, db As String, user As String, password As String) As Boolean
        Dim sqlstr As String
        sqlstr = "Server=" + server + ";Database=" + db + ";Uid=" + user + ";Password=" + password

        CN.ConnectionString = sqlstr
        CN.Open()
        If CN.State = ConnectionState.Open Then Return True Else Return False
    End Function

    Public Function cerrardb()
        CN.Close()
        If CN.State = ConnectionState.Closed Then Return True Else Return False
    End Function

    Public Sub cargar_datagrid(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String, ByVal desde As Integer, ByRef nRegs As Integer, ByRef tPaginas As Integer,
                               ByVal pagina As Integer, ByRef txtnPage As TextBox, ByVal tbl As String, ByVal tblVieja As String)

        'Guarda la columna por la cual está ordenado el control y la dirección en caso de existir
        'para luego volver a ordenar la lista de la misma forma
        Dim oldSortColumn As DataGridViewColumn = Nothing
        Dim oldSortDir As ListSortDirection

        If tbl = tblVieja Then
            oldSortColumn = dataGrid.SortedColumn
            If dataGrid.SortedColumn IsNot Nothing Then
                If dataGrid.SortOrder = SortOrder.Ascending Then
                    oldSortDir = ListSortDirection.Ascending
                Else
                    oldSortDir = ListSortDirection.Descending
                End If
            End If
        End If

        dataGrid.Columns.Clear()

        Try
            'Crea y abre una nueva conexión            
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset
            Dim datatable As New DataTable

            da.SelectCommand = comando

            'llenar el dataset
            'da.Fill(dataset)
            da.Fill(datatable) 'Obtengo todos los registros para poder saber cuantos tiene
            nRegs = datatable.Rows.Count
            tPaginas = Math.Ceiling(nRegs / itXPage)
            txtnPage.Text = pagina & " / " & tPaginas
            datatable.Clear()
            da.Fill(desde, itXPage, datatable) 'Cargo devuelta el datatable pero solo con los registros pedidos por página


            dataGrid.DataSource = datatable
            dataGrid.RowsDefaultCellStyle.BackColor = Color.White
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            cerrardb()

            'Inmovilizo las columnas
            Dim i As Integer = 0
            For Each columna As DataGridViewColumn In dataGrid.Columns
                dataGrid.Columns(columna.Name.ToString).DisplayIndex = i
                i = i + 1
            Next

            If Not dataGrid.Name = "dg_view_resultados" And Not depuracion Then
                dataGrid.Columns(0).Visible = False
            End If

            If dataGrid.Name = "dg_viewPedido" Then dataGrid.Columns(1).Visible = False

            dataGrid.Height = dataGrid.Height + 1
            dataGrid.Height = dataGrid.Height - 1

            If dataGrid.Rows.Count > 0 Then
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            'Si estaba ordenada en algún orden específico, vuelvo a ordenar la grilla por esa columna y dirección
            If tbl = tblVieja Then
                If oldSortColumn IsNot Nothing Then
                    dataGrid.Sort(dataGrid.Columns(oldSortColumn.Name), oldSortDir)
                End If
            End If

            dataGrid.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub cargar_datagrid(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String, ByVal desde As Integer, ByRef nRegs As Integer, ByRef tPaginas As Integer,
                               ByVal pagina As Integer, ByRef txtnPage As TextBox)
        'No guarda la tabla anterior, ni el orden, siempre resetea, se presupone que se usa esta rutina cuando siempre se van a recargar los datos 
        'de la misma tabla

        Dim oldSortColumn As DataGridViewColumn = Nothing
        Dim oldSortDir As ListSortDirection

        If dataGrid.SortedColumn IsNot Nothing Then
            If dataGrid.SortOrder = SortOrder.Ascending Then
                oldSortDir = ListSortDirection.Ascending
            Else
                oldSortDir = ListSortDirection.Descending
            End If
        End If

        dataGrid.Columns.Clear()

        Try
            'Crea y abre una nueva conexión            
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset
            Dim datatable As New DataTable

            da.SelectCommand = comando

            'llenar el dataset
            'da.Fill(dataset)
            da.Fill(datatable) 'Obtengo todos los registros para poder saber cuantos tiene
            nRegs = datatable.Rows.Count
            tPaginas = Math.Ceiling(nRegs / itXPage)
            txtnPage.Text = pagina & " / " & tPaginas
            datatable.Clear()
            da.Fill(desde, itXPage, datatable) 'Cargo devuelta el datatable pero solo con los registros pedidos por página


            dataGrid.DataSource = datatable
            dataGrid.RowsDefaultCellStyle.BackColor = Color.White
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            cerrardb()

            'Inmovilizo las columnas
            Dim i As Integer = 0
            For Each columna As DataGridViewColumn In dataGrid.Columns
                dataGrid.Columns(columna.Name.ToString).DisplayIndex = i
                i = i + 1
            Next

            If Not dataGrid.Name = "dg_view_resultados" And Not depuracion Then
                dataGrid.Columns(0).Visible = False
            End If

            If dataGrid.Name = "dg_viewPedido" Then dataGrid.Columns(1).Visible = False

            dataGrid.Height = dataGrid.Height + 1
            dataGrid.Height = dataGrid.Height - 1

            If dataGrid.Rows.Count > 0 Then
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            If oldSortColumn IsNot Nothing Then
                dataGrid.Sort(dataGrid.Columns(oldSortColumn.Name), oldSortDir)
            End If

            dataGrid.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub cargar_datagrid(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String, Optional ByVal colsHide As Integer() = Nothing, Optional ByVal check As Boolean = False,
                               Optional ByVal colCheckName As String = "Seleccionado", Optional ByVal colCheckPos As Integer = 0)


        dataGrid.Columns.Clear()

        Try
            'Crea y abre una nueva conexión            
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset)
            dataGrid.DataSource = dataset.Tables(0)
            dataGrid.RowsDefaultCellStyle.BackColor = Color.White
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            cerrardb()

            'Inmovilizo las columnas
            Dim i As Integer = 0
            For Each columna As DataGridViewColumn In dataGrid.Columns
                dataGrid.Columns(columna.Name.ToString).DisplayIndex = i
                i = i + 1
            Next

            If Not dataGrid.Name = "dg_view_resultados" And Not depuracion Then
                dataGrid.Columns(0).Visible = False
            End If

            If dataGrid.Name = "dg_viewPedido" Then dataGrid.Columns(1).Visible = False

            dataGrid.Height = dataGrid.Height + 1
            dataGrid.Height = dataGrid.Height - 1

            If dataGrid.Rows.Count > 0 Then
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            If check Then
                ' Este for es para que solo sea editable el checkbox de la grilla es decir poder hacerle click
                'dataGrid.ReadOnly = True
                '
                Dim column As New DataGridViewCheckBoxColumn
                column.Name = colCheckName
                column.ReadOnly = False
                dataGrid.ReadOnly = False
                dataGrid.Columns.Add(column)
                dataGrid.Columns(colCheckName).DisplayIndex = colCheckPos
                dataGrid.Columns(colCheckName).ReadOnly = False

                For Col As Integer = 0 To dataGrid.Columns.Count - 1
                    If Not dataGrid.Columns(Col).Name = colCheckName Then
                        dataGrid.Columns(Col).ReadOnly = True
                    End If
                Next
            End If

            If Not colsHide Is Nothing Then
                For Each col In colsHide
                    dataGrid.Columns(col).Visible = False
                Next
            End If

            dataGrid.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Sub cargar_checkListBox(ByRef checkListBox As CheckedListBox, ByVal cs As String, ByVal sqlstr As String, ByVal ValueMember As String, ByVal DisplayMember As String)
        Using cn As New SqlConnection(cs)
            Dim cmd As New SqlCommand(sqlstr, cn)

            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            checkListBox.ValueMember = ValueMember
            checkListBox.DisplayMember = DisplayMember
            checkListBox.DataSource = dt
        End Using
    End Sub

    'Public Sub cargar_datagridDeDataSet(ByRef dataGrid As DataGridView, ByVal dataset As DataSet)
    '    Try
    '        'Crea y abre una nueva conexión            
    '        abrirdb(serversql, db, usuariodb, passdb)

    '        'Propiedades del SqlCommand
    '        Dim comando As New SqlCommand

    '        With comando
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlstr
    '            .Connection = CN
    '        End With

    '        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
    '        'Dim dataset As New DataSet 'Crear nuevo dataset

    '        da.SelectCommand = comando

    '        'llenar el dataset
    '        da.Fill(ds)
    '        dataGrid.DataSource = ds.Tables(0)
    '        dataGrid.RowsDefaultCellStyle.BackColor = Color.White
    '        dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    '        cerrardb()

    '        'Inmovilizo las columnas
    '        Dim i As Integer = 0
    '        For Each columna As DataGridViewColumn In dataGrid.Columns
    '            dataGrid.Columns(columna.Name.ToString).DisplayIndex = i
    '            i = i + 1
    '        Next

    '        If Not dataGrid.Name = "dg_view_resultados" And Not depuracion Then
    '            dataGrid.Columns(0).Visible = False
    '        End If

    '        If dataGrid.Name = "dg_viewPedido" Then dataGrid.Columns(1).Visible = False
    '        dataGrid.Height = dataGrid.Height + 1
    '        dataGrid.Height = dataGrid.Height - 1
    '        dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

    '        dataGrid.Refresh()

    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '        cerrardb()
    '    End Try
    'End Sub

    Public Function updateDataGrid(ByVal historicoActivo As Boolean, Optional ByVal id_banco As Integer = -1) As String
        'activo acá al pasarse como parámetro, actua localmente y no toma de la variable global
        Dim sqlstr As String = ""
        Select Case tabla
            Case Is = "archivos"
                'dg_view.Clear()
            Case Is = "condiciones_venta"
                sqlstr = "SELECT id_condicion_venta AS 'ID', condicion AS 'Condición', vencimiento AS 'Vencimiento (días)', recargo AS 'Recargo', activo AS 'Activo' " &
                            "FROM condiciones_venta " &
                            "WHERE activo = '" + activo.ToString + "' ORDER BY condicion ASC"
            Case Is = "condiciones_compra"
                sqlstr = "SELECT id_condicion_compra AS 'ID', condicion AS 'Condición', vencimiento AS 'Vencimiento (días)', recargo AS 'Recargo', activo AS 'Activo' " &
                            "FROM condiciones_compra " &
                            "WHERE activo = '" + activo.ToString + "' ORDER BY condicion ASC"
            Case Is = "conceptos_compra"
                sqlstr = "SELECT id_concepto_compra AS 'ID', concepto AS 'Concepto', activo AS 'Activo' " &
                            "FROM conceptos_compra " &
                            "WHERE activo = '" + activo.ToString + "' ORDER BY concepto ASC"
            Case Is = "clientes"
                sqlstr = "SELECT c.id_cliente AS 'ID', c.razon_social AS 'Razon social', c.nombre_fantasia AS 'Nombre de fantasía', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                                "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                                "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                                "c.cp_entrega AS 'CP', " &
                                "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                                "FROM clientes AS c " &
                                "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                                "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                                "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                                "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                                "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                                 "WHERE c.activo = '" + historicoActivo.ToString + "' " &
                                "ORDER BY c.razon_social ASC"
            Case Is = "archivoCCClientes"
                sqlstr = "SELECT ccc.id_cc AS 'ID', c.razon_social AS 'Cliente', nombre AS 'Nombre', sm.moneda AS 'Moneda', ccc.saldo AS 'Saldo', CASE WHEN ccc.activo = 1 THEN 'Si' ELSE 'No' END AS '¿CC activa?' " &
                            "FROM cc_clientes AS ccc " &
                            "INNER JOIN clientes AS c ON ccc.id_cliente = c.id_cliente " &
                            "INNER JOIN sysMoneda AS sm ON ccc.id_moneda = sm.id_moneda " &
                            "ORDER BY c.razon_social, ccc.nombre ASC"
            Case Is = "proveedores"
                sqlstr = "SELECT c.id_proveedor AS 'ID', c.razon_social AS 'Razon social', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                                "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                                "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                                "c.cp_entrega AS 'CP', " &
                                "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                                "FROM proveedores AS c " &
                                "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                                "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                                "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                                "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                                "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                                 "WHERE c.activo = '" + historicoActivo.ToString + "' " &
                                "ORDER BY c.razon_social ASC"
            Case Is = "archivoCCProveedores"
                sqlstr = "SELECT ccp.id_cc AS 'ID', p.razon_social AS 'Proveedor', ccp.nombre AS 'Nombre', sm.moneda AS 'Moneda', ccp.saldo AS 'Saldo', CASE WHEN ccp.activo = 1 THEN 'Si' ELSE 'No' END AS '¿CC activa?' " &
                            "FROM cc_proveedores AS ccp " &
                            "INNER JOIN proveedores AS p ON ccp.id_proveedor = p.id_proveedor " &
                            "INNER JOIN sysMoneda AS sm ON ccp.id_moneda = sm.id_moneda " &
                            "ORDER BY p.razon_social, ccp.nombre ASC"
            Case Is = "marcas_items"
                sqlstr = "SELECT id_marca AS 'ID', marca as 'Marca', activo AS 'Activo' " &
                                "FROM marcas_items " &
                                "WHERE activo = '" + historicoActivo.ToString + "' ORDER BY marca ASC"
            Case Is = "tipos_items"
                sqlstr = "SELECT id_tipo AS 'ID', tipo as 'Categoría', activo AS 'Activo' " &
                                "FROM tipos_items " &
                                "WHERE activo = '" + historicoActivo.ToString + "' ORDER BY tipo ASC"
            Case Is = "items", "itemsImpuestosItems"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                "p.razon_social AS 'Proveedor', i.esDescuento AS 'Descuento', i.esMarkup AS 'Markup', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.activo = '" + historicoActivo.ToString + "' ORDER BY i.item ASC"
            Case Is = "asocItems"
                sqlstr = "SELECT CONCAT(ai.id_item, '-', ai.id_item_asoc) AS 'ID', CONCAT(i.item, '-', ii.item) AS 'Item', i.descript AS 'Producto', ii.descript AS 'Producto asociado', ai.cantidad AS 'Cantidad' " &
                        "FROM asocItems AS ai " &
                        "INNER JOIN items AS i ON ai.id_item = i.id_item " &
                        "INNER JOIN items AS ii ON ai.id_item_asoc = ii.id_item " &
                        "WHERE i.activo = '" + historicoActivo.ToString + "' ORDER BY i.item ASC"
            Case Is = "items_sinDescuento", "asocItem_Item"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                "p.razon_social AS 'Proveedor', i.esDescuento AS 'Descuento', i.esMarkup AS 'Markup', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.activo = '" + historicoActivo.ToString + "' AND i.esDescuento = '0' AND i.esMarkup = '0' ORDER BY i.item ASC"
            Case Is = "itemsDescuentos"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                "p.razon_social AS 'Proveedor', i.esDescuento AS 'Descuento', i.esMarkup AS 'Markup', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.activo = '" + historicoActivo.ToString + "' AND i.esDescuento = '1' AND i.esMarkup = '0' ORDER BY i.item ASC"
            Case Is = "items_registros_stock", "items_recibidos"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.cantidad AS 'Cantidad', i.precio_lista AS 'Precio de lista', " &
                                "i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                "p.razon_social AS 'Proveedor', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "ORDER BY i.item ASC"
            Case Is = "comprobantes"
                sqlstr = "SELECT c.id_comprobante AS 'ID', c.comprobante AS 'Comprobante', tc.comprobante_AFIP AS 'Tipo de Comprobante', c.numeroComprobante AS 'Número de comprobante', c.puntoVenta AS 'Punto de venta', " &
                                "CASE WHEN c.esFiscal = '1' THEN 'Fiscal' WHEN c.esElectronica = '1' THEN 'Eletrónico' ELSE 'Manual' END AS 'Formato de comprobante', c.testing AS 'Comprobante de testeo', c.activo AS 'Activo', c.maxItems AS 'Máximo de items' " &
                                "FROM comprobantes AS c " &
                                "INNER JOIN tipos_comprobantes AS tc ON c.id_tipoComprobante = tc.id_tipoComprobante " &
                                "WHERE c.activo = '" + historicoActivo.ToString + "' ORDER BY c.comprobante ASC"
            Case Is = "archivoconsultas"
                sqlstr = "SELECT c.id_consulta AS 'ID', c.nombre AS 'Nombre', c.consulta AS 'Consulta SQL', c.activo AS 'Activo' " &
                         "FROM consultas_personalizadas AS c " &
                         "WHERE c.activo = '" + historicoActivo.ToString + "' " &
                         "ORDER BY c.id_consulta ASC"
            Case Is = "caja"
                sqlstr = "SELECT c.id_caja AS 'ID', c.nombre AS 'Caja', c.esCC AS 'Es cuenta corriente', c.activo AS 'Activo' " &
                            "FROM cajas AS c " &
                            "WHERE c.activo = '" + activo.ToString + "' " &
                            "ORDER BY c.id_caja ASC"
            Case Is = "bancos"
                sqlstr = "SELECT b.id_banco AS 'ID', b.nombre AS 'Banco', p.pais AS 'País', b.n_banco AS 'Banco Nº', b.activo AS 'Activo' " &
                            "FROM bancos AS b " &
                            "INNER JOIN paises AS p ON b.id_pais = p.id_pais " &
                            "WHERE b.activo = '" + historicoActivo.ToString + "' " &
                            "ORDER BY b.nombre ASC"
            Case Is = "cuentas_bancarias"
                If id_banco = -1 Then
                    sqlstr = "SELECT cb.id_cuentaBancaria AS 'ID', b.nombre AS 'Banco', cb.nombre AS 'Cuenta bancaria', sm.moneda AS 'Moneda', cb.saldo AS 'Saldo', cb.activo AS 'Activo' " &
                            "FROM cuentas_bancarias AS cb " &
                            "INNER JOIN bancos AS b ON cb.id_banco = b.id_banco " &
                            "INNER JOIN sysMoneda AS sm ON cb.id_moneda = sm.id_moneda " &
                            "WHERE cb.activo = '" + historicoActivo.ToString + "' " &
                            "ORDER BY b.nombre, cb.nombre ASC"
                Else
                    sqlstr = "SELECT cb.id_cuentaBancaria AS 'ID', b.nombre AS 'Banco', cb.nombre AS 'Cuenta bancaria', sm.moneda AS 'Moneda', cb.saldo AS 'Saldo', cb.activo AS 'Activo' " &
                            "FROM cuentas_bancarias AS cb " &
                            "INNER JOIN bancos AS b ON cb.id_banco = b.id_banco " &
                            "INNER JOIN sysMoneda AS sm ON cb.id_moneda = sm.id_moneda " &
                            "WHERE cb.activo = '" + historicoActivo.ToString + "' AND cb.id_banco = '" & id_banco.ToString & "' " &
                            "ORDER BY b.nombre, cb.nombre ASC"
                End If
            Case Is = "chRecibidos"
                sqlstr = "SELECT ch.id_cheque AS 'ID', c.razon_social AS 'Cliente', b.nombre AS 'Banco', ch.nCheque AS 'Nº cheque', ch.importe AS 'Importe', sech.estado AS 'Estado', " &
                            "CASE WHEN ch.id_cuentaBancaria IS NULL THEN 'No' ELSE CONCAT('Si, en:', cbb.nombre, ' - ', cb.nombre) END AS '¿Depositado?', " &
                            "CASE WHEN ch.activo = 1 THEN 'Si' ELSE 'No' END AS '¿Activo?' " &
                            "FROM cheques AS ch " &
                            "INNER JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                            "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                            "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                            "LEFT JOIN bancos AS cbb ON cb.id_banco = cbb.id_banco " &
                            "INNER JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                            "WHERE ch.activo = 1 "
            Case Is = "chEmitidos"
                sqlstr = "SELECT ch.id_cheque AS 'ID', p.razon_social AS 'Proveedor', b.nombre AS 'Banco', ch.nCheque AS 'Nº cheque', ch.importe AS 'Importe', sech.estado AS 'Estado', " &
                            "CASE WHEN ch.id_cuentaBancaria IS NULL THEN 'No' ELSE CONCAT('Si, en:', cbb.nombre, ' - ', cb.nombre) END AS '¿Depositado?', " &
                            "CASE WHEN ch.activo = 1 THEN 'Si' ELSE 'No' END AS '¿Activo?' " &
                            "FROM cheques AS ch " &
                            "INNER JOIN proveedores AS p ON ch.id_proveedor = p.id_proveedor " &
                            "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                            "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                            "LEFT JOIN bancos AS cbb ON cb.id_banco = cbb.id_banco " &
                            "INNER JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                            "WHERE ch.activo = 1 "
            Case Is = "chCartera"
                sqlstr = "SELECT ch.id_cheque AS 'ID', CAST(ch.fecha_ingreso AS VARCHAR(50)) AS 'F. Ingreso', CAST(ch.fecha_emision AS VARCHAR(50)) AS 'F. Emisión', c.razon_social AS 'Recibido de', p.razon_social AS 'Entregado a', b.nombre AS 'Banco emisor', " &
                            "cb.nombre AS 'Depositado en', ch.nCheque AS 'Nº cheque', ch.nCheque2 AS '2do nºd/cheque', ch.importe AS 'Monto', sech.estado AS 'Estado', CAST(ch.fecha_cobro AS VARCHAR(50)) AS 'Fecha de cobro', " &
                            "CAST(ch.fecha_salida AS VARCHAR(50)) AS 'Fecha de salida', CAST(ch.fecha_deposito AS VARCHAR(50)) AS 'Fecha de deposito' " &
                            "FROM cheques AS ch " &
                            "LEFT JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                            "LEFT JOIN proveedores AS p ON ch.id_proveedor = p.id_proveedor " &
                            "LEFT JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                            "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                            "LEFT JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                            "WHERE ch.activo = '" + historicoActivo.ToString + "' " &
                            "ORDER BY ch.id_cheque ASC"
            Case Is = "impuestos", "itemsImpuestosImpuestos"
                sqlstr = "SELECT id_impuesto AS 'ID', nombre AS 'Impuesto', porcentaje AS 'Porcentaje (%)', " &
                       "CASE WHEN esRetencion = 1 THEN 'Si' ELSE 'No' END AS 'Retención', " &
                       "CASE WHEN esPercepcion = 1 THEN 'Si' ELSE 'No' END AS 'Percepción', " &
                       "activo AS 'Activo' " &
                       "FROM impuestos " &
                       "WHERE activo = '" + historicoActivo.ToString + "' " &
                       "ORDER BY nombre ASC"
            Case Is = "retenciones"
                sqlstr = "SELECT id_impuesto AS 'ID', nombre AS 'Impuesto', porcentaje AS 'Porcentaje (%)', " &
                       "CASE WHEN esRetencion = 1 THEN 'Si' ELSE 'No' END AS 'Retención', " &
                       "CASE WHEN esPercepcion = 1 THEN 'Si' ELSE 'No' END AS 'Percepción', " &
                       "activo AS 'Activo' " &
                       "FROM impuestos " &
                       "WHERE esRetencion = '1' AND activo = '" + historicoActivo.ToString + "' " &
                       "ORDER BY nombre ASC"
            Case Is = "itemIVA"
                sqlstr = "SELECT id_impuesto AS 'ID', nombre AS 'Impuesto', porcentaje AS 'Porcentaje (%)', activo AS 'Activo' " &
                       "FROM impuestos " &
                       "WHERE activo = '" + historicoActivo.ToString + "' AND nombre LIKE '%iva%' " &
                       "ORDER BY nombre ASC"
            Case Is = "itemsImpuestos"
                sqlstr = "SELECT CONCAT(ii.id_item, '-', ii.id_impuesto) AS 'ID', it.descript AS 'Item', im.nombre AS 'Impuesto', ii.activo AS 'Activo' " &
                         "FROM items_impuestos AS ii " &
                         "INNER JOIN items AS it ON ii.id_item = it.id_item " &
                         "INNER JOIN impuestos AS im ON ii.id_impuesto = im.id_impuesto " &
                         "WHERE ii.activo = '" + activo.ToString + "' " &
                         "ORDER BY im.nombre, it.descript ASC"
            Case Is = "ordenesCompras"
                sqlstr = "SELECT oc.id_ordenCompra AS 'ID', prov.razon_social AS 'Proveedor', CAST(oc.fecha_carga AS VARCHAR(50)) AS 'Fecha de carga', " &
                            "CAST(oc.fecha_recepcion AS VARCHAR(50)) AS 'Fecha de recepción', " &
                            "oc.total AS 'Importe', oc.activo AS 'Activo' " &
                            "FROM ordenes_compras AS oc " &
                            "INNER JOIN proveedores AS prov ON oc.id_proveedor = prov.id_proveedor  " &
                            "WHERE oc.activo = '" + historicoActivo.ToString + "' " &
                            "ORDER BY oc.id_ordenCompra ASC"
            Case Is = "comprobantes_compras"
                sqlstr = "SELECT cc.id_comprobanteCompra AS 'ID', CAST(cc.fecha_carga AS VARCHAR(50)) AS 'Fecha carga', CAST(cc.fecha_comprobante AS VARCHAR(50)) AS 'Fecha comprobante', p.razon_social AS 'Proveedor', " &
                            "CONCAT(scc.comprobante, ' Nº  ', REPLICATE('0', 4 - LEN(cc.puntoVenta)), cc.puntoVenta, '-', REPLICATE('0', 8 - LEN(cc.numeroComprobante)), cc.numeroComprobante) AS 'Comprobante', " &
                            "sm.moneda AS 'Moneda', cc.tasaCambio AS 'Tipo de cambio', cnc.condicion AS 'Condición de compra', " &
                            "cc.subtotal AS 'Subtotal', cc.impuestos AS 'Impuestos', cc.conceptos AS 'Conceptos', cc.total AS 'Total', cc.cae AS 'CAE' " &
                            "FROM comprobantes_compras AS cc " &
                            "INNER JOIN sysComprobantesCompras AS scc ON cc.id_sysComprobanteCompra = scc.id_sysComprobanteCompra " &
                            "INNER JOIN proveedores AS p ON cc.id_proveedor = p.id_proveedor " &
                            "INNER JOIN cc_proveedores AS ccp ON cc.id_cc = ccp.id_cc " &
                            "INNER JOIN sysMoneda AS sm ON cc.id_moneda = sm.id_moneda " &
                            "INNER JOIN condiciones_compra AS cnc ON cc.id_condicion_compra = cnc.id_condicion_compra " &
                            "WHERE cc.activo = '0' " &
                            "ORDER BY cc.fecha_comprobante ASC"
            Case Is = "pagos"
                sqlstr = "SELECT pg.id_pago AS 'ID', CAST(pg.fecha_carga AS VARCHAR(50)) AS 'Fecha carga', CAST(pg.fecha_pago AS VARCHAR(50)) AS 'Fecha pago', p.razon_social AS 'Proveedor', " &
                        "cc.nombre AS 'CC.', pg.efectivo AS 'Efectivo', pg.totalTransferencia AS 'Trans. B.', pg.totalCh AS 'Total cheques', pg.total AS 'Total pago' " &
                        "FROM pagos AS pg " &
                        "INNER JOIN proveedores AS p ON pg.id_proveedor = p.id_proveedor " &
                        "INNER JOIN cc_proveedores AS cc ON pg.id_cc = cc.id_cc " &
                        "LEFT JOIN pagos_cheques AS pgch ON pg.id_pago = pgch.id_pago " &
                        "ORDER BY pg.fecha_pago ASC"
            Case Is = "registros_stock"
                If activo Then
                    sqlstr = "SELECT rs.id_registro AS 'ID', CAST(rs.fecha AS VARCHAR(50)) AS 'Fecha FC', CAST(rs.fecha_ingreso AS VARCHAR(50)) AS 'Fecha ingreso', i.item AS 'Código', i.descript AS 'Producto', rs.cantidad AS 'Cantidad', rs.cantidad_anterior AS 'Cantidad anterior', " &
                        "rs.precio_lista AS 'Precio', rs.precio_lista_anterior AS 'Precio anterior', rs.factor AS 'Factor', rs.factor_anterior AS 'Factor anterior', " &
                        "rs.costo AS 'Costo',  rs.costo_anterior AS 'Costo anterior', p.razon_social AS 'Proveedor', rs.factura AS 'Factura', rs.nota AS 'Notas', rs.activo AS 'Activo' " &
                                    "FROM registros_stock AS rs " &
                                    "INNER JOIN items AS i ON rs.id_item = i.id_item " &
                                    "INNER JOIN proveedores AS p ON rs.id_proveedor = p.id_proveedor " &
                                    "WHERE rs.activo = '1' AND rs.fecha_ingreso = CONVERT (date, SYSDATETIME()) " &
                                    "ORDER BY rs.fecha_ingreso, rs.id_registro ASC"
                Else
                    sqlstr = "SELECT rs.id_registro AS 'ID', CAST(rs.fecha AS VARCHAR(50)) AS 'Fecha FC', CAST(rs.fecha_ingreso AS VARCHAR(50)) AS 'Fecha ingreso', i.item AS 'Código', i.descript AS 'Producto', rs.cantidad AS 'Cantidad', rs.cantidad_anterior AS 'Cantidad anterior', " &
                        "rs.precio_lista AS 'Precio', rs.precio_lista_anterior AS 'Precio anterior', rs.factor AS 'Factor', rs.factor_anterior AS 'Factor anterior', " &
                        "rs.costo AS 'Costo',  rs.costo_anterior AS 'Costo anterior', p.razon_social AS 'Proveedor', rs.factura AS 'Factura', rs.nota AS 'Notas', rs.activo AS 'Activo' " &
                                    "FROM registros_stock AS rs " &
                                    "INNER JOIN items AS i ON rs.id_item = i.id_item " &
                                    "INNER JOIN proveedores AS p ON rs.id_proveedor = p.id_proveedor " &
                                    "WHERE rs.activo = '0' " &
                                    "ORDER BY rs.fecha_ingreso, rs.id_registro ASC"
                End If
            Case Is = "ajustes_stock"
                If activo Then
                    sqlstr = "SELECT _as.id_ajusteStock AS 'ID', CAST(_as.fecha AS VARCHAR(50)) AS 'Fecha', i.item AS 'Código', i.descript AS 'Producto', " &
                            "_as.cantidad AS 'Cantidad', _as.notas AS 'Notas' " &
                            "FROM ajustes_stock AS _as " &
                            "INNER JOIN items AS i ON _as.id_item = i.id_item " &
                            "WHERE _as.fecha = CONVERT (date, SYSDATETIME()) " &
                            "ORDER BY _as.id_ajusteStock ASC"
                Else
                    sqlstr = "SELECT _as.id_ajusteStock AS 'ID', CAST(_as.fecha AS VARCHAR(50)) AS 'Fecha', i.item AS 'Código', i.descript AS 'Producto', " &
                        "_as.cantidad AS 'Cantidad', _as.notas AS 'Notas' " &
                       "FROM ajustes_stock AS _as " &
                       "INNER JOIN items AS i ON _as.id_item = i.id_item " &
                       "ORDER BY _as.id_ajusteStock ASC"
                End If
            Case Is = "produccion"
                sqlstr = "SELECT prod.id_produccion AS 'ID', prov.razon_social AS 'Proveedor', CAST(prod.fecha_carga AS VARCHAR(50)) AS 'Fecha de carga', " &
                            "CAST(prod.fecha_envio AS VARCHAR(50)) AS 'Fecha de envio', " &
                            "CAST(prod.fecha_recepcion AS VARCHAR(50)) AS 'Fecha de recepción', " &
                            "CASE WHEN prod.enviado = 1 THEN 'SI' ELSE 'NO' END AS '¿Mercadería enviada al proveedor?', " &
                            "CASE WHEN prod.recibido = 1 THEN 'SI' ELSE 'NO' END AS '¿Mercadería recibida del proveedor?' " &
                            "FROM produccion AS prod " &
                            "INNER JOIN proveedores AS prov ON prod.id_proveedor = prov.id_proveedor " &
                            "WHERE prod.activo = '" + historicoActivo.ToString + "' " &
                            "ORDER BY prod.id_produccion ASC"
            Case Is = "nuevopedido"
                tabla = ""
                add_pedido.ShowDialog()
            Case Is = "pedidos"
                If activo Then
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.razon_social AS 'Razón social', cp.comprobante AS 'Comprobante', " &
                                        "p.total AS 'Total', p.activo AS 'Activo' " &
                                        "FROM pedidos AS p " &
                                        "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                        "INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante " &
                                        "WHERE p.cerrado = '0' AND p.activo = '1' " &
                                        "ORDER BY p.id_pedido DESC"
                Else
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(P.fecha_edicion AS VARCHAR(50)) AS 'Fecha', c.razon_social AS 'Razón social', " &
                                        "cp.comprobante AS 'Comprobante', CASE WHEN cp.id_tipoComprobante = 99 THEN p.idPresupuesto " &
                                        "ELSE p.numeroComprobante END AS 'Nº comprobante', p.total AS 'Total', p.activo AS 'Activo' " &
                                        "FROM pedidos AS p " &
                                        "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                        "INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante " &
                                        "WHERE p.cerrado = '1' AND p.activo = '0' " &
                                        "ORDER BY p.fecha_edicion DESC, p.id_pedido DESC"
                End If
            Case Is = "cobros"
                sqlstr = "SELECT c.id_cobro AS 'ID', CAST(c.fecha_carga AS VARCHAR(50)) AS 'Fecha de carga', CAST(c.fecha_cobro AS VARCHAR(50)) AS 'Fecha de cobro', " &
                        "cl.razon_social AS 'Cliente', cc.nombre AS 'CC.', c.efectivo AS 'Efectivo', c.totalTransferencia AS 'Trans. B.', " &
                        "c.totalCh AS 'Total cheques', c.totalRetencion AS 'Retenciones', c.total AS 'Total' " &
                        "FROM cobros AS c " &
                        "INNER JOIN clientes AS cl ON c.id_cliente = cl.id_cliente " &
                        "INNER JOIN cc_clientes AS cc ON c.id_cc = cc.id_cc " &
                        "ORDER BY c.fecha_cobro ASC"
            Case Is = "stock"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Producto', i.descript AS 'Descripción', i.cantidad AS 'Cantidad', i.precio_lista AS 'Precio', i.costo AS 'Costo' " &
                        "FROM items AS i " &
                        "WHERE i.esMarkup = 'FALSE' AND i.esDescuento = 'FALSE' AND i.activo = 'TRUE' " &
                        "ORDER BY i.item, i.descript ASC"
            Case Is = "cpersonalizadas"
                grilla_resultados.ShowDialog()
                Exit Select
            Case Is = "ccClientes"
                infoccClientes.ShowDialog()
                Exit Select
            Case Is = "configuracion"
                config.ShowDialog()
            Case Is = "acercade"
                frmacercade.ShowDialog()
            Case Else
                sqlstr = "error"
        End Select
        Return sqlstr
    End Function

    Public Sub cargar_listview(ByRef ListView As ListView, ByVal sql As String, ByVal db As String)
        Try
            'Crea y abre una nueva conexión            
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            With ListView
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                'Añadir los nombres de columnas
                For i As Integer = 0 To dataset.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dataset.Tables("tabla").Columns(i).Caption)
                Next
            End With

            'Añadir los registros de la tabla
            With dataset.Tables("tabla")
                For i = 0 To .Rows.Count - 1
                    'For i = .Rows.Count - 1 To 0 Step -1
                    Dim dato As New ListViewItem(.Rows(i).Item(0).ToString)
                    'Recorrer las columnas
                    For j As Integer = 1 To .Columns.Count - 1
                        dato.SubItems.Add(.Rows(i).Item(j).ToString())
                    Next
                    ListView.Items.Add(dato)
                Next
            End With
            cerrardb()
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            'Errores
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Function cargar_combo(ByRef combo As ComboBox, ByVal sqlstr As String, ByVal db As String, ByVal displaymember As String, ByVal valuemember As String, Optional ByVal predet As Integer = 0) As Integer
        cargar_combo = -1
        'Crea y abre una nueva conexión
        abrirdb(serversql, db, usuariodb, passdb)

        Dim Dt As DataTable

        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        Try
            With Cmd
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Da.SelectCommand = Cmd
            Dt = New DataTable
            Da.Fill(Dt)

            With combo
                .DataSource = Dt
                '.DisplayMember = "marca"
                '.ValueMember = "id_marca"
                .DisplayMember = displaymember
                .ValueMember = valuemember
                .SelectedIndex = predet
            End With
            cerrardb()
            cargar_combo = 99
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
           cerrardb()
        End Try
    End Function

    Public Function traer_info(ByVal db As String, ByVal sqlstr As String, ByVal pone_columnas As Integer) ' As String
        'Si pone_columnas = 1 Agrega los nombres de las columnas de la base al array
        'Si se pone un argumento distinto a 0 o 1, se presupone q se deben poner las columnas
        If pone_columnas <> 0 And pone_columnas <> 1 Then pone_columnas = 1

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, db, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            'Las filas guardan los nombres del campo
            'Las columnas guardan la info de cada campo


            Dim cont_columnas, cont_filas As Integer

            cont_columnas = dataset.Tables("tabla").Columns.Count - 1
            cont_filas = dataset.Tables("tabla").Rows.Count - 1 'Filas DE LA BASE DE DATOS que PUEDE SER DISTINTA a la del array que lo contiene

            Dim i, j As Integer
            Dim datos(cont_filas + pone_columnas, cont_columnas) As String 'Más uno SI QUISIERA poner una fila con el nombre de las columnas

            If pone_columnas = 1 Then
                For i = 0 To cont_columnas 'Agrega el nombre de las columnas
                    datos(0, i) = dataset.Tables("tabla").Columns(i).Caption
                Next
            End If

            For i = 0 To cont_filas
                For j = 0 To cont_columnas
                    datos(cont_filas + pone_columnas, j) = dataset.Tables("tabla").Rows(i).Item(j).ToString
                Next
            Next
            cerrardb()
            Return datos
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function

    Public Sub closeandupdate(formulario As Form)
        'main.cmb_cat_SelectedIndexChanged(Nothing, Nothing)
        formulario.Dispose()
    End Sub

    Public Function strtoInt(ByVal str As String) As Integer
        If str = "" Then
            Return 0
        Else
            Return CInt(str)
        End If
    End Function

    Public Sub activaitems(ByVal tabla As String)
        Dim sqlstr As String

        sqlstr = "UPDATE " + tabla + " SET activo = '1' WHERE activo = '0'"

        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand(sqlstr, CN)


            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
        End Try
    End Sub

    Public Function calculoTotalPuro(ByVal datagrid As DataGridView) As Double
        'Dim subtotal As Double
        'Dim iva As Double
        Dim total As Double
        Dim i As New item
        Dim item_id As String

        'Calculo los precios
        For c = 0 To datagrid.Rows.Count - 1
            item_id = datagrid.Rows(c).Cells(0).Value.ToString
            item_id = Microsoft.VisualBasic.Right(item_id, (item_id.Length - InStr(item_id, "-")))
            If item_id <> "" Then
                i = info_item(item_id)
            End If
            If i.esDescuento = False And i.esMarkup = False Then
                total = total + (datagrid.Rows(c).Cells(4).Value * datagrid.Rows(c).Cells(3).Value)
            End If
        Next


        'Calculo los descuentos
        For c = 0 To datagrid.Rows.Count - 1
            item_id = datagrid.Rows(c).Cells(0).Value.ToString
            item_id = Microsoft.VisualBasic.Right(item_id, (item_id.Length - InStr(item_id, "-")))
            If item_id <> "" Then
                i = info_item(item_id)
            End If
            If i.esDescuento Then
                total = total - -datagrid.Rows(c).Cells(4).Value
            End If
        Next

        Return total
    End Function

    Public Function valida(ByVal str As String, ByVal t As Integer) As Boolean
        'Está función funciona al revez, como está preparada para asignarse directamente al handled del caracter
        'e.handled = false permite la escritura del caracter, por lo cual si devuelve true, el caracter no se escribirá
        'Todo a EXCEPCIÓN de que se valide una patente, en cuyo caso verificará que se escriban 3 letras y 3 dígitos luego, en ese caso devolverá true
        Dim chr As Char
        If t <> 4 Then
            chr = str
        End If
        Select Case t
            Case Is = 1
                'Solo letras (Nombres, apellidos, etc)
                If Char.IsLetter(chr) Then Return False
            Case Is = 2
                'Validación de teléfonos (Solo números y -)
                If Char.IsDigit(chr) Or chr = "-" Then Return False
            Case Is = 3
                'Validación de DNI (Solo números)
                If Char.IsDigit(chr) Then Return False
            Case Is = 4
                'Validación de patente (aaa###)
                If Len(str) = 6 Then
                    If Char.IsLetter(Strings.Left(str, 3)) Then
                        If Char.IsNumber(Strings.Right(str, 3)) Then
                            Return True
                        End If
                        Return False
                    End If
                    Return False
                End If
                Return False
            Case Is = 5
                'Escritura de números con decimales
                If chr = sepDecimal Or chr = "-" Or Char.IsDigit(chr) Then Return False
        End Select
        If Char.IsControl(chr) Then Return False
        Return True
    End Function

    'Public Sub resaltarColumna(ByRef datagrid As DataGridView, ByVal col As Integer, ByVal clr As Color, Optional ByVal autos As Boolean = False)
    '    Dim i As Integer
    '    For i = 0 To datagrid.Rows.Count - 1
    '        datagrid.Rows(i).Cells(col).Style.BackColor = clr
    '    Next
    'End Sub

    Public Function sqlstrbuscar(ByVal txtsearch As String) As String
        Dim sqlstr As String = ""
        Select Case tabla
            Case Is = "condiciones_venta"
                sqlstr = "SELECT id_condicion_venta AS 'ID', condicion AS 'Condición', vencimiento AS 'Vencimiento (días)', recargo AS 'Recargo', activo AS 'Activo' " &
                            "FROM condiciones_venta " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_condicion_venta LIKE '%" + txtsearch + "%' " &
                            "OR condicion LIKE '%" + txtsearch + "%' " &
                            "OR vencimiento LIKE '%" + txtsearch + "%' " &
                            "OR recargo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY condicion ASC"
            Case Is = "condiciones_compra"
                sqlstr = "SELECT id_condicion_venta AS 'ID', condicion AS 'Condición', vencimiento AS 'Vencimiento (días)', recargo AS 'Recargo', activo AS 'Activo' " &
                            "FROM condiciones_compra " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_condicion_compra LIKE '%" + txtsearch + "%' " &
                            "OR condicion LIKE '%" + txtsearch + "%' " &
                            "OR vencimiento LIKE '%" + txtsearch + "%' " &
                            "OR recargo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY condicion ASC"
            Case Is = "conceptos_compra"
                sqlstr = "SELECT id_concepto_compra AS 'ID', concepto AS 'Concepto', activo AS 'Activo' " &
                            "FROM conceptos_compra " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_concepto_compra LIKE '%" + txtsearch + "%' " &
                            "OR concepto LIKE '%" + txtsearch + "%') " &
                            "ORDER BY concepto ASC"
            Case Is = "clientes"
                sqlstr = "SELECT c.id_cliente AS 'ID', c.razon_social AS 'Razon social', c.nombre_fantasia AS 'Nombre de fantasía', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                              "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                              "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                              "c.cp_entrega AS 'CP', " &
                              "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                   "FROM clientes AS c " &
                   "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                   "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                   "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                   "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                   "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                   "WHERE c.activo = '" + activo.ToString + "' " &
                   "AND (c.id_cliente LIKE '%" + txtsearch + "%' " &
                   "OR c.razon_social LIKE '%" + txtsearch + "%' " &
                   "OR c.nombre_fantasia LIKE '%" + txtsearch + "%' " &
                   "OR td.documento LIKE '%" + txtsearch + "%' " &
                   "OR c.taxNumber LIKE '%" + txtsearch + "%' " &
                   "OR c.contacto LIKE '%" + txtsearch + "%' " &
                   "OR c.telefono LIKE '%" + txtsearch + "%' " &
                   "OR c.celular LIKE '%" + txtsearch + "%' " &
                   "OR c.email LIKE '%" + txtsearch + "%' " &
                   "OR prof.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR proe.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_entrega LIKE '%" + txtsearch + "%') " &
                   "ORDER BY razon_social ASC"
            Case Is = "archivoCCClientes"
                sqlstr = "SELECT ccc.id_cc AS 'ID', c.razon_social AS 'Cliente', ccc.nombre AS 'Nombre', sm.moneda AS 'Moneda', ccc.saldo AS 'Saldo', CASE WHEN ccc.activo = 1 THEN 'Si' ELSE 'No' END AS '¿CC activa?' " &
                            "FROM cc_clientes AS ccc " &
                            "INNER JOIN clientes AS c ON ccc.id_cliente = c.id_cliente " &
                            "INNER JOIN sysMoneda AS sm ON ccc.id_moneda = sm.id_moneda " &
                            "WHERE ccc.activo = '" + activo.ToString + "' " &
                            "AND (ccc.nombre LIKE '%" + txtsearch + "%' " &
                            "OR sm.moneda LIKE '%" + txtsearch + "%' " &
                            "OR c.razon_social LIKE '%" + txtsearch + "%' " &
                            "OR ccc.saldo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY c.razon_social, ccc.nombre ASC"
            Case Is = "proveedores"
                sqlstr = "SELECT c.id_proveedor AS 'ID', c.razon_social AS 'Razon social', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                              "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                              "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                              "c.cp_entrega AS 'CP', " &
                              "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                   "FROM proveedores AS c " &
                   "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                   "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                   "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                   "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                   "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                   "WHERE c.activo = '" + activo.ToString + "' " &
                   "AND (c.id_proveedor LIKE '%" + txtsearch + "%' " &
                   "OR c.razon_social LIKE '%" + txtsearch + "%' " &
                   "OR td.documento LIKE '%" + txtsearch + "%' " &
                   "OR c.taxNumber LIKE '%" + txtsearch + "%' " &
                   "OR c.contacto LIKE '%" + txtsearch + "%' " &
                   "OR c.telefono LIKE '%" + txtsearch + "%' " &
                   "OR c.celular LIKE '%" + txtsearch + "%' " &
                   "OR c.email LIKE '%" + txtsearch + "%' " &
                   "OR prof.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR proe.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_entrega LIKE '%" + txtsearch + "%') " &
                   "ORDER BY razon_social ASC"
            Case Is = "archivoCCProveedores"
                sqlstr = "SELECT ccp.id_cc AS 'ID', p.razon_social AS 'Proveedor', ccp.nombre AS 'Nombre', sm.moneda AS 'Moneda', ccp.saldo AS 'Saldo', CASE WHEN ccp.activo = 1 THEN 'Si' ELSE 'No' END AS '¿CC activa?' " &
                            "FROM cc_proveedores AS ccp " &
                            "INNER JOIN proveedores AS p ON ccp.id_proveedor = p.id_proveedor " &
                            "INNER JOIN sysMoneda AS sm ON ccp.id_moneda = sm.id_moneda " &
                            "WHERE ccp.activo = '" + activo.ToString + "' " &
                            "AND (nombre LIKE '%" + txtsearch + "%' " &
                            "OR sm.moneda LIKE '%" + txtsearch + "%' " &
                            "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                            "OR saldo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY p.razon_social, ccp.nombre ASC"
            Case "tipos_items"
                sqlstr = "SELECT id_tipo AS 'ID', tipo as 'Categoría', activo AS 'Activo' " &
                                "FROM tipos_items " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_tipo LIKE '%" + txtsearch + "%' " &
                            "OR tipo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY tipo ASC"
            Case "marcas_items"
                sqlstr = "SELECT id_marca AS 'ID', marca as 'Marca', activo AS 'Activo' " &
                                "FROM marcas_items " &
                            "WHERE activo = '" + activo.ToString + "' " &
                            "AND (id_marca LIKE '%" + txtsearch + "%' " &
                            "OR marca LIKE '%" + txtsearch + "%') " &
                            "ORDER BY marca ASC"
            Case "items", "itemsImpuestosItems"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                    "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                    "p.razon_social AS 'Proveedor', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.activo = '" + activo.ToString + "' " &
                                "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                                "OR i.item LIKE '%" + txtsearch + "%' " &
                                "OR i.descript LIKE '%" + txtsearch + "%' " &
                                "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                                "OR i.costo LIKE '%" + txtsearch + "%' " &
                                "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                                "OR t.tipo LIKE '%" + txtsearch + "%' " &
                                "OR m.marca LIKE '%" + txtsearch + "%' " &
                                "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                                "OR i.factor LIKE '%" + txtsearch + "%') " &
                                "ORDER BY i.item ASC"
            Case "items_sinDescuento", "asocItem_Item"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                    "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                    "p.razon_social AS 'Proveedor', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.esDescuento = '0' AND i.activo = '" + activo.ToString + "' " &
                                "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                                "OR i.item LIKE '%" + txtsearch + "%' " &
                                "OR i.descript LIKE '%" + txtsearch + "%' " &
                                "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                                "OR i.costo LIKE '%" + txtsearch + "%' " &
                                "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                                "OR t.tipo LIKE '%" + txtsearch + "%' " &
                                "OR m.marca LIKE '%" + txtsearch + "%' " &
                                "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                                "OR i.factor LIKE '%" + txtsearch + "%') " &
                                "ORDER BY i.item ASC"
            Case Is = "itemsDescuentos"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                "p.razon_social AS 'Proveedor', i.esDescuento AS 'Descuento', i.esMarkup AS 'Markup', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.activo = '" + activo.ToString + "' AND i.esDescuento = '1' AND i.esMarkup = '0' " &
                                "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                                "OR i.item LIKE '%" + txtsearch + "%' " &
                                "OR i.descript LIKE '%" + txtsearch + "%' " &
                                "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                                "OR i.costo LIKE '%" + txtsearch + "%' " &
                                "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                                "OR t.tipo LIKE '%" + txtsearch + "%' " &
                                "OR m.marca LIKE '%" + txtsearch + "%' " &
                                "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                                "OR i.factor LIKE '%" + txtsearch + "%') " &
                                "ORDER BY i.item ASC"
            Case Is = "asocItems"
                sqlstr = "SELECT CONCAT(ai.id_item, '-', ai.id_item_asoc) AS 'ID', CONCAT(i.item, '-', ii.item) AS 'Item', i.descript AS 'Producto', ii.descript AS 'Producto asociado', ai.cantidad AS 'Cantidad' " &
                        "FROM asocItems AS ai " &
                        "INNER JOIN items AS i ON ai.id_item = i.id_item " &
                        "INNER JOIN items AS ii ON ai.id_item_asoc = ii.id_item " &
                        "WHERE i.activo = '" + activo.ToString + "' " &
                        "AND (ai.id_item LIKE '%" + txtsearch + "%' " &
                        "OR ai.id_item_asoc LIKE '%" + txtsearch + "%' " &
                        "OR ai.cantidad LIKE '%" + txtsearch + "%' " &
                        "OR i.item LIKE '%" + txtsearch + "%' " &
                        "OR ii.item LIKE '%" + txtsearch + "%' " &
                        "OR i.descript LIKE '%" + txtsearch + "%' " &
                        "OR ii.descript LIKE '%" + txtsearch + "%') " &
                        "ORDER BY i.item ASC"
            Case "comprobantes"
                sqlstr = "SELECT c.id_comprobante AS 'ID', c.comprobante AS 'Comprobante', tc.comprobante_AFIP AS 'Tipo de comprobante', c.numeroComprobante AS 'Numero de comprobante',  c.puntoVenta AS 'Punto de Venta', " &
                            "CASE WHEN c.esFiscal = '1' THEN 'Fiscal' WHEN c.esElectronica = '1' THEN 'Eletrónico' ELSE 'Manual' END AS 'Formato de comprobante', c.testing AS 'Comprobante de testeo', c.activo AS 'Activo', c.maxItems AS 'Máximo de items' " &
                            "FROM comprobantes AS c " &
                            "INNER JOIN tipos_comprobantes AS tc ON c.id_tipoComprobante = tc.id_tipoComprobante " &
                            "WHERE c.activo = '" + activo.ToString + "' " &
                            "AND (c.id_comprobante LIKE '%" + txtsearch + "%' " &
                            "OR c.comprobante LIKE '%" + txtsearch + "%' " &
                            "OR tc.comprobante_AFIP LIKE '%" + txtsearch + "%' " &
                            "OR c.numeroComprobante LIKE '%" + txtsearch + "%' " &
                            "OR c.puntoVenta LIKE '%" + txtsearch + "%' " &
                            "OR c.testing LIKE '%" + txtsearch + "%' " &
                            "OR c.maxItems LIKE '%" + txtsearch + "%' " &
                            "ORDER BY c.comprobante ASC"
            Case Is = "archivoconsultas"
                sqlstr = "SELECT c.id_consulta AS 'ID', c.nombre AS 'Nombre', c.consulta AS 'Consulta SQL', c.activo AS 'Activo' " &
                         "FROM consultas_personalizadas AS c " &
                         "WHERE c.activo = '" + activo.ToString + "' " &
                         "AND (c.id_consulta LIKE '%" + txtsearch + "%' " &
                         "OR c.nombre LIKE '%" + txtsearch + "%' " &
                         "OR c.consulta LIKE '%" + txtsearch + "%') " &
                         "ORDER BY c.id_consulta ASC"
            Case Is = "caja"
                sqlstr = "SELECT c.id_caja AS 'ID', c.nombre AS 'Caja', c.esCC AS 'Es cuenta corriente', c.activo AS 'Activo' " &
                        "FROM cajas AS c " &
                        "WHERE c.activo = '" + activo.ToString + "' " &
                        "AND (c.id_caja LIKE '%" + txtsearch + "%' " &
                        "OR c.nombre LIKE '%" + txtsearch + "%') " &
                        "ORDER BY c.id_caja ASC"
            Case Is = "bancos"
                sqlstr = "SELECT b.id_banco AS 'ID', b.nombre AS 'Banco', p.pais AS 'País', b.n_banco AS 'Banco Nº', b.activo AS 'Activo' " &
                            "FROM bancos AS b " &
                            "INNER JOIN paises AS p ON b.id_pais = p.id_pais " &
                            "WHERE b.activo = '" + activo.ToString + "' " &
                            "AND (b.id_banco LIKE '%" + txtsearch + "%' " &
                            "OR b.nombre LIKE '%" + txtsearch + "%' " &
                            "OR p.pais LIKE '%" + txtsearch + "%' " &
                            "OR b.n_banco LIKE '%" + txtsearch + "%') " &
                            "ORDER BY b.nombre ASC"
            Case Is = "cuentas_bancarias"
                sqlstr = "SELECT cb.id_cuentaBancaria AS 'ID', b.nombre AS 'Banco', cb.nombre AS 'Cuenta bancaria', sm.moneda AS 'Moneda', cb.saldo AS 'Saldo', cb.activo AS 'Activo' " &
                            "FROM cuentas_bancarias AS cb " &
                            "INNER JOIN bancos AS b ON cb.id_banco = b.id_banco " &
                            "INNER JOIN sysMoneda AS sm ON cb.id_moneda = sm.id_moneda " &
                            "WHERE cb.activo = '" + activo.ToString + "' " &
                            "AND (cb.id_cuentaBancaria LIKE '%" + txtsearch + "%' " &
                            "OR b.nombre LIKE '%" + txtsearch + "%' " &
                            "OR cb.nombre LIKE '%" + txtsearch + "%' " &
                            "OR sm.moneda LIKE '%" + txtsearch + "%' " &
                            "OR cb.saldo LIKE '%" + txtsearch + "%') " &
                            "ORDER BY b.nombre, cb.nombre ASC"
            Case Is = "chCartera"
                sqlstr = "SELECT ch.id_cheque AS 'ID', CAST(ch.fecha_ingreso AS VARCHAR(50)) AS 'F. Ingreso', CAST(ch.fecha_emision AS VARCHAR(50)) AS 'F. Emision', c.razon_social AS 'Recibido de', p.razon_social AS 'Entregado a', b.nombre AS 'Banco emisor', " &
                            "cb.nombre AS 'Depositado en', ch.nCheque AS 'Nº cheque', ch.nCheque2 AS '2do nºd/cheque', ch.importe AS 'Monto', sech.estado AS 'Estado', CAST(ch.fecha_cobro AS VARCHAR(50)) AS 'Fecha de cobro', " &
                            "CAST(ch.fecha_salida AS VARCHAR(50)) AS 'Fecha de salida', CAST(ch.fecha_deposito AS VARCHAR(50)) AS 'Fecha de deposito' " &
                            "FROM cheques AS ch " &
                            "LEFT JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                            "LEFT JOIN proveedores AS p ON ch.id_proveedor = p.id_proveedor " &
                            "LEFT JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                            "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                            "LEFT JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                            "WHERE ch.activo = '" + activo.ToString + "' " &
                            "AND (ch.id_cheque LIKE '%" + txtsearch + "&' " &
                            "OR ch.fecha_ingreso LIKE '%" + txtsearch + "&' " &
                            "OR ch.fecha_emision LIKE '%" + txtsearch + "&' " &
                            "OR c.razon_social LIKE '%" + txtsearch + "&' " &
                            "OR p.razon_social LIKE '%" + txtsearch + "&' " &
                            "OR b.nombre LIKE '%" + txtsearch + "&' " &
                            "OR cb.nombre LIKE '%" + txtsearch + "&' " &
                            "OR ch.nCheque LIKE '%" + txtsearch + "&' " &
                            "OR ch.nCheque2 LIKE '%" + txtsearch + "&' " &
                            "OR ch.importe LIKE '%" + txtsearch + "&' " &
                            "OR sech.estado LIKE '%" + txtsearch + "&' " &
                            "OR ch.fecha_cobro LIKE '%" + txtsearch + "&' " &
                            "OR ch.fecha_salida LIKE '%" + txtsearch + "&' " &
                            "OR ch.fecha_deposito LIKE '%" + txtsearch + "&') " &
                            "ORDER BY ch.id_cheque ASC"
            Case Is = "impuestos", "itemsImpuestosImpuestos"
                sqlstr = "SELECT id_impuesto AS 'ID', nombre AS 'Impuesto', porcentaje AS 'Porcentaje (%)', " &
                       "CASE WHEN esRetencion = 1 THEN 'Si' ELSE 'No' END AS 'Retención', " &
                       "CASE WHEN esPercepcion = 1 THEN 'Si' ELSE 'No' END AS 'Percepción', " &
                       "activo AS 'Activo' " &
                       "FROM impuestos " &
                       "WHERE activo = '" + activo.ToString + "' " &
                       "AND (id_impuesto LIKE '%" + txtsearch + "%' " &
                       "OR esRetencion LIKE '%" + txtsearch + "%' " &
                       "OR esPercepcion LIKE '%" + txtsearch + "%' " &
                        "OR nombre LIKE '%" + txtsearch + "%') " &
                       "ORDER BY nombre ASC"
            Case Is = "retencion"
                sqlstr = "SELECT id_impuesto AS 'ID', nombre AS 'Impuesto', porcentaje AS 'Porcentaje (%)', " &
                       "CASE WHEN esRetencion = 1 THEN 'Si' ELSE 'No' END AS 'Retención', " &
                       "CASE WHEN esPercepcion = 1 THEN 'Si' ELSE 'No' END AS 'Percepción', " &
                       "activo AS 'Activo' " &
                       "FROM impuestos " &
                       "WHERE esRetencion = 1 AND activo = '" + activo.ToString + "' " &
                       "AND (id_impuesto LIKE '%" + txtsearch + "%' " &
                        "OR nombre LIKE '%" + txtsearch + "%') " &
                       "ORDER BY nombre ASC"
            Case Is = "itemsImpuestos"
                sqlstr = "SELECT CONCAT(ii.id_item, '-', ii.id_impuesto) AS 'ID', it.descript AS 'Item', im.nombre AS 'Impuesto', ii.activo AS 'Activo' " &
                         "FROM items_impuestos AS ii " &
                         "INNER JOIN items AS it ON ii.id_item = it.id_item " &
                         "INNER JOIN impuestos AS im ON ii.id_impuesto = im.id_impuesto " &
                         "WHERE ii.activo = '" + activo.ToString + "' " &
                         "AND (ii.id_impuesto LIKE '%" + txtsearch + "%' " &
                         "OR ii.id_item LIKE '%" + txtsearch + "%' " &
                         "OR it.descript LIKE '%" + txtsearch + "%' " &
                         "OR im.nombre LIKE '%" + txtsearch + "%') " &
                         "ORDER BY im.nombre, it.descript ASC"
            Case "items_registros_stock"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.cantidad AS 'Cantidad', i.precio_lista AS 'Precio de lista', " &
                      "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                      "p.razon_social AS 'Proveedor', i.activo AS 'Activo' " &
                  "FROM items AS i " &
                  "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                  "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                  "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                  "WHERE i.activo = '" + activo.ToString + "' " &
                  "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                  "OR i.item LIKE '%" + txtsearch + "%' " &
                  "OR i.descript LIKE '%" + txtsearch + "%' " &
                  "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                  "OR i.costo LIKE '%" + txtsearch + "%' " &
                  "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                  "OR t.tipo LIKE '%" + txtsearch + "%' " &
                  "OR m.marca LIKE '%" + txtsearch + "%' " &
                  "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                  "OR i.factor LIKE '%" + txtsearch + "%') " &
                  "ORDER BY i.item ASC"
            Case Is = "ordenesCompras"
                sqlstr = "SELECT oc.id_ordenCompra AS 'ID', prov.razon_social AS 'Proveedor', CAST(oc.fecha_carga AS VARCHAR(50)) AS 'Fecha de carga', " &
                            "CCAST(oc.fecha_recepcion AS VARCHAR(50)) AS 'Fecha de recepción', " &
                            "oc.total AS 'Importe', oc.activo AS 'Activo' " &
                            "FROM ordenes_compras AS oc " &
                            "INNER JOIN proveedores AS prov ON oc.id_proveedor = prov.id_proveedor  " &
                            "WHERE oc.activo = '" + activo.ToString + "' " &
                            "AND (oc.id_ordenCompra LIKE '%" + txtsearch + "%' " &
                            "OR prov.razon_social LIKE '%" + txtsearch + "%' " &
                            "OR oc.fecha_carga LIKE '%" + txtsearch + "%' " &
                            "oc.fecha_recepcion LIKE '%" + txtsearch + "%' " &
                            "oc.total LIKE '%" + txtsearch + "%') " &
                            "ORDER BY oc.id_ordenCompra ASC"
            Case Is = "comprobantes_compras"
                sqlstr = "SELECT cc.id_comprobanteCompra AS 'ID', CAST(cc.fecha_carga AS VARCHAR(50)) AS 'Fecha carga', CAST(cc.fecha_comprobante AS VARCHAR(50)) AS 'Fecha comprobante', p.razon_social AS 'Proveedor', " &
                            "CONCAT(scc.comprobante, ' Nº  ', REPLICATE('0', 4 - LEN(cc.puntoVenta)), cc.puntoVenta, '-', REPLICATE('0', 8 - LEN(cc.numeroComprobante)), cc.numeroComprobante) AS 'Comprobante', " &
                            "sm.moneda AS 'Moneda', cc.tasaCambio AS 'Tipo de cambio', cnc.condicion AS 'Condición de compra', " &
                            "cc.subtotal AS 'Subtotal', cc.impuestos AS 'Impuestos', cc.conceptos AS 'Conceptos', cc.total AS 'Total', cc.cae AS 'CAE' " &
                            "FROM comprobantes_compras AS cc " &
                            "INNER JOIN sysComprobantesCompras AS scc ON cc.id_sysComprobanteCompra = scc.id_sysComprobanteCompra " &
                            "INNER JOIN proveedores AS p ON cc.id_proveedor = p.id_proveedor " &
                            "INNER JOIN cc_proveedores AS ccp ON cc.id_cc = ccp.id_cc " &
                            "INNER JOIN sysMoneda AS sm ON cc.id_moneda = sm.id_moneda " &
                            "INNER JOIN condiciones_compra AS cnc ON cc.id_condicion_compra = cnc.id_condicion_compra " &
                            "WHERE cc.activo = '0' " &
                            "AND (cc.id_comprobanteCompra LIKE '%" + txtsearch + "%' " &
                            "OR cc.fecha_carga LIKE '%" + txtsearch + "%' " &
                            "OR cc.fecha_comprobante LIKE '%" + txtsearch + "%' " &
                            "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                            "OR scc.comprobante LIKE '%" + txtsearch + "%' " &
                            "OR cc.puntoVenta LIKE '%" + txtsearch + "%' " &
                            "OR cc.numeroComprobante LIKE '%" + txtsearch + "%' " &
                            "OR sm.moneda LIKE '%" + txtsearch + "%' " &
                            "OR cc.tasaCambio LIKE '%" + txtsearch + "%' " &
                            "OR cnc.condicion LIKE '%" + txtsearch + "%' " &
                            "OR cc.subtotal LIKE '%" + txtsearch + "%' " &
                            "OR cc.impuestos LIKE '%" + txtsearch + "%' " &
                            "OR cc.conceptos LIKE '%" + txtsearch + "%' " &
                            "OR cc.total LIKE '%" + txtsearch + "%' " &
                            "OR cc.cae LIKE '%" + txtsearch + "%') " &
                            "ORDER BY cc.fecha_comprobante ASC"
            Case Is = "pagos"
                sqlstr = "SELECT pg.id_pago AS 'ID', CAST(pg.fecha_carga AS VARCHAR(50)) AS 'Fecha carga', CAST(pg.fecha_pago AS VARCHAR(50)) AS 'Fecha pago', p.razon_social AS 'Proveedor', " &
                        "cc.nombre AS 'CC.', pg.efectivo AS 'Efectivo', pg.totalTransferencia AS 'Trans. B.', pg.totalCh AS 'Total cheques', pg.total AS 'Total pago' " &
                        "FROM pagos AS pg " &
                        "INNER JOIN proveedores AS p ON pg.id_proveedor = p.id_proveedor " &
                        "INNER JOIN cc_proveedores AS cc ON pg.id_cc = cc.id_cc " &
                        "WHERE (pc.id_pago LIKE '%" + txtsearch + "%' " &
                        "OR pg.fecha LIKE '%" + txtsearch + "%' " &
                        "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                        "OR cc.nombre LIKE '%" + txtsearch + "%' " &
                        "OR pg.efectivo + LIKE '%" + txtsearch + "%') " &
                        "ORDER BY pg.fecha_pago ASC"
            Case "registros_stock"
                sqlstr = "SELECT rs.id_registro AS 'ID', CAST(rs.fecha AS VARCHAR(50)) AS 'Fecha FC', CAST(rs.fecha_ingreso AS VARCHAR(50)) AS 'Fecha ingreso', i.item AS 'Código', i.descript AS 'Producto', rs.cantidad AS 'Cantidad', rs.cantidad_anterior AS 'Cantidad anterior', " &
                "rs.precio_lista AS 'Precio', rs.precio_lista_anterior AS 'Precio anterior', rs.factor AS 'Factor', rs.factor_anterior AS 'Factor anterior', " &
                "rs.costo AS 'Costo',  rs.costo_anterior AS 'Costo anterior', p.razon_social AS 'Proveedor', rs.factura AS 'Factura', rs.nota AS 'Notas', rs.activo AS 'Activo' " &
                            "FROM registros_stock AS rs " &
                            "INNER JOIN items AS i ON rs.id_item = i.id_item " &
                            "INNER JOIN proveedores AS p ON rs.id_proveedor = p.id_proveedor " &
                            "WHERE rs.activo = '" & activo.ToString & "' " &
                            "AND (rs.id_registro LIKE '%" + txtsearch + "%' " &
                            "OR rs.fecha LIKE '%" + txtsearch + "%' " &
                            "OR rs.fecha_ingreso LIKE '%" + txtsearch + "%' " &
                            "OR i.item LIKE '%" + txtsearch + "%' " &
                            "OR i.descript LIKE '%" + txtsearch + "%' " &
                            "OR rs.cantidad LIKE '%" + txtsearch + "%' " &
                            "OR rs.cantidad_anterior LIKE '%" + txtsearch + "%' " &
                            "OR rs.precio_lista LIKE '%" + txtsearch + "%' " &
                            "OR rs.precio_lista_anterior LIKE '%" + txtsearch + "%' " &
                            "OR rs.factor LIKE '%" + txtsearch + "%' " &
                            "OR rs.factor_anterior LIKE '%" + txtsearch + "%' " &
                            "OR rs.costo LIKE '%" + txtsearch + "%' " &
                            "OR rs.costo_anterior LIKE '%" + txtsearch + "%' " &
                            "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                            "OR rs.factura LIKE '%" + txtsearch + "%' " &
                            "OR rs.nota LIKE '%" + txtsearch + "%') " &
                            "ORDER BY rs.fecha_ingreso, rs.id_registro ASC"
            Case Is = "ajustes_stock"
                If activo Then
                    sqlstr = "SELECT _as.id_ajusteStock AS 'ID', CAST(_as.fecha AS VARCHAR(50)) AS 'Fecha', i.item AS 'Código', i.descript AS 'Producto', _as.cantidad AS 'Cantidad' " &
                            "FROM ajustes_stock AS _as " &
                            "INNER JOIN items AS i ON _as.id_item = i.id_item " &
                            "WHERE _as.fecha = CONVERT (date, SYSDATETIME()) " &
                            "AND (_as.id_ajusteStock LIKE '%" + txtsearch + "%' " &
                            "OR _as.fecha LIKE '%" + txtsearch + "%' " &
                            "OR i.item LIKE '%" + txtsearch + "%' " &
                            "OR i.descript LIKE '%" + txtsearch + "%' " &
                            "OR _as.cantidad LIKE '%" + txtsearch + "%' " &
                            "OR _as.notas LIKE '%" + txtsearch + "%') " &
                            "ORDER BY _as.id_ajusteStock ASC"
                Else
                    sqlstr = "SELECT _as.id_ajusteStock AS 'ID', CAST(_as.fecha AS VARCHAR(50)) AS 'Fecha', i.item AS 'Código', i.descript AS 'Producto', _as.cantidad AS 'Cantidad' " &
                       "FROM ajustes_stock AS _as " &
                       "INNER JOIN items AS i ON _as.id_item = i.id_item " &
                       "WHERE _as.id_ajusteStock LIKE '%" + txtsearch + "%' " &
                       "AND (_as.fecha LIKE '%" + txtsearch + "%' " &
                       "OR i.item LIKE '%" + txtsearch + "%' " &
                       "OR _as.cantidad LIKE '%" + txtsearch + "%' " &
                       "OR _as.notas LIKE '%" + txtsearch + "%') " &
                       "ORDER BY _as.id_ajusteStock ASC"
                End If
            Case "produccion"
                sqlstr = "SELECT prod.id_produccion AS 'ID', prov.razon_social AS 'Proveedor', CAST(prod.fecha_carga AS VARCHAR(50)) AS 'Fecha de carga', " &
                            "CAST(prod.fecha_envio AS VARCHAR(50)) AS 'Fecha de envio', " &
                            "CAST(prod.fecha_recepcion AS VARCHAR(50)) AS 'Fecha de recepción', " &
                            "CASE WHEN prod.enviado = 1 THEN 'SI' ELSE 'NO' END AS '¿Mercadería enviada al proveedor?', " &
                            "CASE WHEN prod.recibido = 1 THEN 'SI' ELSE 'NO' END AS '¿Mercadería recibida del proveedor?' " &
                            "FROM produccion AS prod " &
                            "INNER JOIN proveedores AS prov ON prod.id_proveedor = prov.id_proveedor " &
                            "WHERE prod.activo = '" + activo.ToString + "' " &
                            "AND (prod.id_produccion LIKE '%" + txtsearch + "%' " &
                            "OR prov.razon_social LIKE '%" + txtsearch + "%' " &
                            "OR prod.fecha_carga LIKE '%" + txtsearch + "%' " &
                            "OR prod.fecha_envio LIKE '%" + txtsearch + "%' " &
                            "OR prod.fecha_recepcion LIKE '%" + txtsearch + "%') " &
                            "ORDER BY prod.id_produccion ASC"
            Case "pedidos"
                If activo Then
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.razon_social AS 'Cliente', cp.comprobante AS 'Comprobante', " &
                                "p.total AS 'Total', p.activo AS 'Activo' " &
                                "FROM pedidos AS p " &
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                "INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante " &
                                "WHERE p.cerrado = '0' AND p.activo = '1' " &
                                "AND (p.id_pedido LIKE '%" + txtsearch + "%'" &
                                "OR p.fecha LIKE '%" + txtsearch + "%'" &
                                "OR c.razon_social LIKE '%" + txtsearch + "%')" &
                                "ORDER BY p.id_pedido DESC"
                Else
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha_edicion AS VARCHAR(50)) AS 'Fecha', c.razon_social 'Cliente', cp.comprobante AS 'Comprobante', " &
                                "CASE WHEN cp.id_tipoComprobante = 99 THEN p.idPresupuesto ELSE p.numeroComprobante END AS 'Nº comprobante', p.total AS 'Total', " &
                                "p.activo AS 'Activo' " &
                                "FROM pedidos AS p " &
                                "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                "INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante " &
                                "WHERE p.cerrado = '1' AND p.activo = '0' " &
                                "AND (p.id_pedido LIKE '%" + txtsearch + "%'" &
                                "OR p.fecha LIKE '%" + txtsearch + "%' " &
                                "OR c.razon_social LIKE '%" + txtsearch + "%' " &
                                "OR p.idPresupuesto LIKE '%" + txtsearch + "%' " &
                                "OR p.numeroComprobante LIKE '%" + txtsearch + "%')" &
                                "ORDER BY p.fecha_edicion DESC"
                End If
            Case Is = "cobros"
                sqlstr = "SELECT c.id_cobro AS 'ID', CAST(c.fecha_carga AS VARCHAR(50)) AS 'Fecha de carga', CAST(c.fecha_cobro AS VARCHAR(50)) AS 'Fecha de cobro', " &
                        "cl.razon_social AS 'Cliente', cc.nombre AS 'CC.', c.efectivo AS 'Efectivo', c.totalTransferencia AS 'Trans. B.', " &
                        "c.totalCh AS 'Total cheques', c.totalRetencion AS 'Retenciones', c.total AS 'Total' " &
                        "FROM cobros AS c " &
                        "INNER JOIN clientes AS cl ON c.id_cliente = cl.id_cliente " &
                        "INNER JOIN cc_clientes AS cc ON c.id_cc = cc.id_cc " &
                        "WHERE (c.id_cobro LIKE '%" + txtsearch + "%' " &
                        "OR c.fecha_carga LIKE '%" + txtsearch + "%' " &
                        "OR c.fecha_cobro LIKE '%" + txtsearch + "%' " &
                        "OR cl.razon_social LIKE '%" + txtsearch + "%' " &
                        "OR cc.nombre LIKE '%" + txtsearch + "%' " &
                        "OR c.efectivo LIKE '%" + txtsearch + "%' " &
                        "OR c.transferencia LIKE '%" + txtsearch + "%') " &
                        "ORDER BY c.fecha_cobro ASC"
        End Select
        Return sqlstr
    End Function

    Public Function Truncar(ByVal Numero As Double, Optional ByVal Decimales As Byte = 0) As Double
        Dim lngPotencia As Long
        lngPotencia = 10 ^ Decimales
        Numero = Int(Numero * lngPotencia)
        Truncar = Numero / lngPotencia
    End Function

    Public Function milesArgentinos(ByVal numero As String) As String
        numero.Replace(".", "*")
        numero.Replace(",", ".")
        numero.Replace("*", ",")
        Return numero
    End Function

    Public Function formatNN(ByVal nn As Double) As Double
        nn = Format(nn, "#.##0,00")
        Return nn
    End Function

    'Public Function fechaAFIP(Optional ByVal fecha As String = "", Optional ByVal divChar As Char = "/") As String
    Public Function fechaAFIP() As String
        Dim anio As String = ""
        Dim mes As String = ""
        Dim dia As String = ""
        Dim fechaFinal As String
        'Dim fechaArray() As String

        'If fecha = "" Then
        anio = DateTime.Now().Year
        mes = DateTime.Now().Month
        dia = DateTime.Now().Day

        If mes < 10 Then mes = "0" & mes
        If dia < 10 Then dia = "0" & dia

        fechaFinal = anio & mes & dia

        Return fechaFinal
        'Else
        'Try
        '    fechaArray = Split(fecha, divChar)
        '    anio = fechaArray(0)
        '    mes = fechaArray(1)
        '    dia = fechaArray(2)

        '    fechaFinal = anio + mes + dia

        '    Return fechaFinal
        'Catch ex As Exception
        '    Return 0
        'End Try
        'End If
    End Function

    Public Function fechaAFIP_fecha(ByVal fecha_afip As String) As String
        Dim fecha As String
        Dim anio As String
        Dim mes As String
        Dim dia As String

        anio = Left(fecha_afip, 4)
        mes = Mid(fecha_afip, 5, 2)
        dia = Right(fecha_afip, 2)
        fecha = anio & "/" & mes & "/" & dia
        Return fecha
    End Function

    Public Sub guardarArchivoTexto(ByVal path As String, ByVal strr As String)
        Dim fs As FileStream = File.Create(path)
        Dim str As Byte()

        str = New UTF8Encoding(True).GetBytes(strr)

        fs.Write(str, 0, str.Length)
        fs.Close()
    End Sub

    Public Function leerArchivoTexto(ByVal path As String) As String
        Dim strDesc As New Encriptar
        Dim objReader As New StreamReader(path)
        Dim str As String = ""
        'Dim arrSTR As New ArrayList
        Dim strr As String = ""
        Dim c As Integer = 0

        Do
            c = c + 1
            str = objReader.ReadLine()
            strr += str
        Loop Until str Is Nothing
        objReader.Close()

        Return strr
    End Function

    Public Function dbBackup() As Boolean
        Try
            Dim Comando As New SqlCommand
            'sqlstr = "Server=" + server + ";Database=" + db + ";Uid=" + user + ";Password=" + password
            CN = New SqlConnection("Data Source=localhost;Database=Master;integrated security=SSPI") 'Abro en un modo especial para poder hacer bkacup
            CN.Open()
            Comando = New SqlCommand("BACKUP DATABASE dbCentrex TO DISK='" & rutaBackup & "\" & archivoBackup & "'", CN)
            Comando.ExecuteNonQuery()
            Return 1 'Ok
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return 0 'Error
        End Try
    End Function

    Public Sub ejecutarSQL(ByVal sqlstr As String)
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try

            Comando = New SqlClient.SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Function FnExecSQL(ByVal sqlstr As String) As Integer
        Dim r As Integer = -1

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            r = dataset.Tables("tabla").Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        cerrardb()
        Return r
    End Function

    Public Function esNumero(e As KeyPressEventArgs, Optional ByVal _negativosOk As Boolean = False) As Boolean
        Dim valor As Integer

        If _negativosOk Then
            valor = InStr(1, "0123456789,.-" & Chr(8), e.KeyChar)
        Else
            valor = InStr(1, "0123456789,." & Chr(8), e.KeyChar)
        End If

        Return valor
    End Function

    Public Function obtieneValorConfig(ByVal str As String) As String
        Return Trim(Right(str, (str.Length - (InStr(str, "=") + 1))))
    End Function

    Public Function isDecimalOk(e As KeyPressEventArgs) As String
        'Convierte el punto o la coma al formato decimal correspondiente
        Dim valor As String = e.KeyChar

        If InStr(1, ".," & Chr(8), e.KeyChar) Then
            If InStr(1, sepDecimal & Chr(8), e.KeyChar) Then
                If InStr(1, Chr(8), e.KeyChar) = 0 Then
                    valor = sepDecimal
                End If
            Else
                If sepDecimal = "." Then
                    valor = "."
                Else
                    valor = ","
                End If
            End If
        End If

        Return valor
    End Function

    Public Function Hoy() As String
        Return Format(DateTime.Now, "dd/MM/yyyy")
    End Function

    Public Function Fecha_Sistema() As String
        Dim fecha As String
        Dim sqlstr As String

        fecha = "1/1/1900"

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT CONVERT(VARCHAR, fecha, 3) FROM empresa"

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            fecha = dataset.Tables("tabla").Rows(0).Item(0).ToString
            Return fecha
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            Return fecha
        Finally
            cerrardb()
        End Try
    End Function
    Public Sub updateform(Optional ByVal seleccionado As String = "", Optional ByRef cmb As ComboBox = Nothing)
        If cmb Is Nothing Then Exit Sub

        If seleccionado = "" Then
            seleccionado = cmb.SelectedValue
        Else
            cmb.SelectedValue = seleccionado
        End If
    End Sub

    Public Function delValArray(ByRef array() As Integer, ByVal del As Integer) As Integer()
        Dim arrayB(0) As Integer
        Dim c As Integer
        Dim x As Integer = 0
        Dim borrados As Integer = 0
        Dim max As Integer = UBound(array)

        For c = 0 To max
            If array(c) <> del Then
                ReDim Preserve arrayB(UBound(arrayB) + 1)
                arrayB(x) = array(c)
                x += 1
            End If
        Next

        ReDim Preserve arrayB(UBound(arrayB) - 1)

        Return arrayB
    End Function

    Public Function addValArray(ByRef array() As Integer, ByVal add As Integer) As Integer()
        Dim max As Integer = 0
        Dim c As Integer = 0
        Dim found As Boolean = False

        Try
            max = UBound(array)

            For c = 0 To max
                If array(c) = add Then found = True
            Next
        Catch ex As Exception
            max = -1
        End Try

        If Not found Then
            max += 1
            ReDim Preserve array(max)
            array(max) = add
        End If

        Return array
    End Function

    Public Function searchArray(ByVal array() As Integer, ByVal val As Integer) As Boolean
        Dim c As Integer = 0
        Dim max As Integer = 0
        Dim found As Boolean = False

        Try
            max = UBound(array)

            For c = 0 To max
                If array(c) = val Then
                    found = True
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try

        Return found
    End Function

    Public Function borrartbl(ByVal tbl As String, Optional ByVal reseed As Boolean = False) As Byte
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If reseed Then
                'sqlstr = "DELETE FROM " + tbl + "; DBCC CHECKIDENT ('" + basedb + ".dbo." + tbl + "',RESEED, 0)"
                sqlstr = "DELETE FROM " + tbl + "; DBCC CHECKIDENT ('" + tbl + "',RESEED, 0)"
            Else
                sqlstr = "TRUNCATE TABLE " + tbl
            End If

            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function precio(ByVal str As String) As String
        Return "$ " + Convert.ToString(str)
    End Function
    '************************************* FUNCIONES GENERALES *****************************
End Module