Imports System.Data.SqlClient

Module ordenesCompras
    ' ************************************ FUNCIONES DE ORDENES DE COMPRA ***************************
    Public Function info_ordenCompra(Optional ByVal id_ordenCompra As String = "") As ordenCompra
        Dim tmp As New ordenCompra
        Dim sqlstr As String
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                If id_ordenCompra = "" Then
                    sqlstr = "SET DATEFORMAT dmy; SELECT TOP 1 id_ordenCompra, id_proveedor, CONVERT(NVARCHAR(20), fecha_carga, 3), ISNULL(CONVERT(NVARCHAR(20), fecha_recepcion, 3), 0), " &
                        "subtotal, iva, total, recibido, notas, activo " &
                        "FROM ordenes_compras " &
                        "ORDER BY id_ordenCompra DESC"
                Else
                    sqlstr = "SET DATEFORMAT dmy; SELECT id_ordenCompra, id_proveedor, CONVERT(NVARCHAR(20), fecha_carga, 3), ISNULL(CONVERT(NVARCHAR(20), fecha_recepcion, 3), 0), " &
                        "subtotal, iva, total, recibido, notas, activo " &
                        "FROM ordenes_compras WHERE id_ordenCompra = '" + id_ordenCompra + "'"
                End If
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_ordenCompra = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha_carga = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha_recepcion = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.subtotal = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.iva = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.recibido = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(9).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_ordenCompra = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addOrdenCompra(ByVal oc As ordenCompra) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO ordenes_compras (id_proveedor, fecha_carga, "
            If Not oc.fecha_recepcion Is Nothing Then sqlstr += "fecha_recepcion, "
            sqlstr += "subtotal, iva, total, recibido, notas) VALUES " &
            "('" + oc.id_proveedor.ToString + "', '" + oc.fecha_carga.ToString + "', '"
            If Not oc.fecha_recepcion Is Nothing Then sqlstr += oc.fecha_recepcion.ToString + "', '"
            sqlstr += oc.subtotal.ToString + "', '" + oc.iva.ToString + "', '" + oc.total.ToString + "', '" + oc.recibido.ToString + "', '" + oc.notas + "')"

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

    Public Function updateOrdenCompra(ByVal oc As ordenCompra, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra Then
                sqlstr = "UPDATE ordenes_compras SET activo = '0' WHERE id_ordenCompra = '" + oc.id_ordenCompra.ToString + "'"
            Else
                sqlstr = "SET DATEFORMAT dmy; UPDATE ordenes_compras SET id_proveedor = '" + oc.id_proveedor.ToString + "', fecha_carga = '" + oc.fecha_carga.ToString + "', "

                If oc.fecha_recepcion IsNot Nothing Then
                    sqlstr += "fecha_recepcion = '" + oc.fecha_recepcion.ToString + "', recibido = '" + oc.recibido.ToString + "', "
                End If

                sqlstr += "subtotal = '" + oc.subtotal.ToString + "', iva = '" + oc.iva.ToString + "', total = '" + oc.total.ToString + "', " &
                            "notas = '" + oc.notas + "', activo = '" + oc.activo.ToString + "' " &
                            "WHERE id_ordenCompra = '" + oc.id_ordenCompra.ToString + "'"
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

    Public Function borrarOrdenCompra(ByVal oc As ordenCompra) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM ordenes_compras WHERE id_ordenCompra = '" + oc.id_ordenCompra.ToString + "'"
            Comando = New SqlClient.SqlCommand(sqlstr, CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function addItemOCtmp(ByVal i As item, ByVal cantidad As Integer, ByVal precio As Double, Optional ByVal id_tmpOCItem As Integer = -1) As Boolean
        Dim sqlComm As New SqlCommand 'Comando en el resto

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                If id_tmpOCItem = -1 Or id_tmpOCItem = 0 Then
                    .CommandText = "SP_insertItemsOCTMP"
                Else
                    .CommandText = "SP_updateItemsOCTMP"
                End If
                .CommandType = CommandType.StoredProcedure
                With .Parameters
                    .AddWithValue("id_tmpOCItem", id_tmpOCItem)
                    .AddWithValue("id_item", i.id_item)
                    .AddWithValue("cantidad", cantidad)
                    .AddWithValue("precio", precio)
                    .AddWithValue("descript", i.descript)
                    .Add(New SqlParameter("@resultado", SqlDbType.Int)).Direction = ParameterDirection.Output
                End With
                .Connection = CN
                .ExecuteNonQuery()
            End With

            'sqlComm.Transaction = mytrans
            'mytrans.Commit()
            If CInt(sqlComm.Parameters("@resultado").Value) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    Public Function guardarOrdenCompra(Optional ByVal id_ordenCompra As Integer = 0) As Boolean
        'Obtengo el último pedido que se generó
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim oc As New ordenCompra

        If id_ordenCompra = 0 Then
            oc = info_ordenCompra()
            id_ordenCompra = oc.id_ordenCompra
        End If

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "UPDATE ordenesCompras_items " &
                            "SET id_item = src.id_item, " &
                            "cantidad = src.cantidad, " &
                            "precio = src.precio, " &
                            "cantidad_recibida = src.cantidad_recibida, " &
                            "descript = src.descript " &
                            "FROM ordenesCompras_items dst " &
                            "JOIN tmpOC_items src ON src.id_ocItem = dst.id_ocItem " &
                            "WHERE dst.id_ordenCompra = '" + id_ordenCompra.ToString + "' " &
                                "AND src.activo = '1' " &
                        "INSERT ordenesCompras_items " &
                            "(id_ordenCompra, " &
                            "id_item, " &
                            "cantidad, " &
                            "precio, " &
                            "cantidad_recibida, " &
                            "descript,
                            activo) " &
                            "SELECT '" + id_ordenCompra.ToString + "', " &
                               "id_item, " &
                               "cantidad, " &
                               "precio, " &
                               "cantidad_recibida, " &
                               "descript,
                               1" &
                            "FROM tmpOC_items src " &
                            "WHERE NOT EXISTS " &
                            "(" &
                                "SELECT id_item " &
                                "FROM ordenesCompras_items dst " &
                                "WHERE src.id_ocItem = dst.id_ocItem " &
                                    "AND dst.id_ordenCompra = '" + id_ordenCompra.ToString + "'" &
                            ") " &
                            "AND src.activo = '1' " &
                            "ORDER BY src.id_tmpOCItem ASC"
            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            'Borro de la tabla ordenesCompras_items, todos los items que no estén en la tabla tmpOC_items
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "DELETE FROM ordenesCompras_items " &
                        "WHERE id_ocItem IN " &
                        "( " &
                        "	SELECT tmpi.id_ocItem " &
                        "	FROM ordenesCompras_items AS pit " &
                        "	LEFT JOIN tmpOC_items AS tmpi ON tmpi.id_item = pit.id_item " &
                        "	WHERE tmpi.activo = 0 AND tmpi.id_ordenCompra = " + id_ordenCompra.ToString + " AND pit.cantidad = tmpi.cantidad AND pit.precio = tmpi.precio " &
                        ")"

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

    Public Function oc_a_ocTmp(ByVal id_ordenCompra As Integer) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO tmpOC_items (id_ocItem, id_ordenCompra, id_item, cantidad, precio, activo, descript, cantidad_recibida) " _
                               + "SELECT id_ocItem, id_ordenCompra, id_item, cantidad, precio, activo, descript, cantidad_recibida " _
                               + "FROM ordenesCompras_items " _
                               + "WHERE id_ordenCompra = '" + id_ordenCompra.ToString + "'"
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

    Public Function askCantidadCargadaOC(ByVal id_item As Integer, Optional ByVal id As Integer = -1, Optional ByVal id_tmpOCItem As Integer = -1) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sqlstr As String

            sqlstr = "SELECT cantidad FROM tmpOC_items WHERE id_item = '" + id_item.ToString + "'"
            If id <> -1 Then sqlstr = sqlstr + " AND id_ordenCompra = '" + id.ToString + "'"
            If id_tmpOCItem <> -1 Then sqlstr = sqlstr + " AND id_tmpOCItem = '" + id_tmpOCItem.ToString + "'"

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

            Dim cantidad As Double
            cantidad = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()
            Return cantidad
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            'si no hay stock devuelve -1
            cerrardb()
            Return -1
        End Try
    End Function

    Public Function askPrecioCargadoOC(ByVal id_item As Integer, Optional ByVal id As Integer = -1, Optional ByVal id_tmpOCItem As Integer = -1) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sqlstr As String

            sqlstr = "SELECT precio FROM tmpOC_items WHERE id_item = '" + id_item.ToString + "'"
            If id <> -1 Then sqlstr = sqlstr + " AND id_ordenCompra = '" + id.ToString + "'"
            If id_tmpOCItem <> -1 Then sqlstr = sqlstr + " AND id_tmpOCItem = '" + id_tmpOCItem.ToString + "'"

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

            Dim precio As Double
            precio = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()
            Return precio
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            'si no hay stock devuelve -1
            cerrardb()
            Return -1
        End Try
    End Function

    Public Sub imprimirProduccion(ByVal id_produccion As Integer)
        If showrpt Then
            id = id_produccion
            'Dim frm As New frm_reportes(esPresupuesto, imprimeRemito)
            'frm.ShowDialog()
            'frm_reportes.ShowDialog()
            id = 0
        End If
    End Sub

    Public Function updatePreciosOC(ByVal datagrid As DataGridView, ByVal txt_subTotal As TextBox, ByVal txt_impuestos As TextBox,
                                    ByVal txt_total As TextBox, ByVal txt_totalOriginal As TextBox) As Boolean
        Dim sqlstr As String
        Dim total As Double
        Dim subtotal As Double
        Dim descuento As Double
        Dim impuestosItem As Double
        Dim totalImpuestoItem As Double
        Dim totalImpuestos As Double
        Dim precio As Double
        Dim cantidad As Integer
        Dim comando As New SqlCommand

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT ti.id_tmpOCItem, ISNULL(ti.id_item, 0) AS 'id_item' , ti.cantidad, ti.precio, ti.activo, " &
                        "ISNULL(ti.descript, '') AS descript " &
                        "FROM tmpOC_items AS ti " &
                        "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                        "ORDER BY id_tmpOCItem ASC"

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando
            'llenar el dataset
            da.FillSchema(dataset, SchemaType.Source, "tmpOC_items") 'Para que pueda manejarme con los nombres de las tablas y no haga falta por id
            da.Fill(dataset, "tmpOC_items")

            Dim tbl_tmppedidos_items As DataTable
            tbl_tmppedidos_items = dataset.Tables("tmpOC_items")
            cerrardb()

            'Calculo el subtotal
            For Each fila As DataRow In dataset.Tables(0).Rows
                cantidad = fila("cantidad")
                precio = fila("precio")
                subtotal = subtotal + (cantidad * precio)
            Next

            txt_totalOriginal.Text = subtotal

            'Calculo los impuestos
            totalImpuestos = 0
            For Each fila As DataRow In dataset.Tables(0).Rows
                precio = fila("precio")
                cantidad = fila("cantidad")
                impuestosItem = calculaImpuestosItem(fila("id_tmpOCItem"), fila("id_item"))
                totalImpuestoItem = ((impuestosItem * (precio * cantidad)) / 100)
                totalImpuestos += totalImpuestoItem
            Next

            totalImpuestos = totalImpuestos - ((impuestosItem * descuento) / 100) 'TERRIBLE PARCHE SACALO YA!

            total = subtotal + totalImpuestos
            impuestosItem = totalImpuestos


            txt_subTotal.Text = Math.Round(subtotal, 2)
            txt_impuestos.Text = Math.Round(totalImpuestos, 2)
            txt_total.Text = Math.Round(total, 2)

            sqlstr = "SELECT CONCAT(ti.id_tmpOCItem, '-', ti.id_item) AS 'ID', ti.id_OCItem AS 'id_OCItem', 
                    CASE WHEN ti.id_item IS NULL THEN ti.descript ELSE i.descript END AS 'Producto', ti.cantidad AS 'Cant.', ti.precio AS 'Precio', " &
                   "CAST(ti.cantidad * ti.precio AS DECIMAL(18,2)) AS 'Subtotal' " &
                   "FROM tmpOC_items AS ti " &
                   "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                   "LEFT JOIN tipos_items AS tim ON i.id_tipo = tim.id_tipo " &
                   "WHERE ti.activo = '1' " &
                   "ORDER BY id ASC"
            cargar_datagrid(datagrid, sqlstr, basedb)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function calculaImpuestosItem(ByVal id_tmpOCItem As String, ByVal id_item As String) As Double
        Dim sqlstr As String
        Dim totalImpuestos As Double
        Dim comando As New SqlCommand

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT ti.id_item, ti.cantidad, ti.precio, im.nombre, im.porcentaje " &
                        "FROM tmpOC_items AS ti " &
                        "INNER JOIN items AS it ON ti.id_item = it.id_item " &
                        "INNER JOIN items_impuestos AS ii ON ti.id_item = ii.id_item " &
                        "INNER JOIN impuestos AS im ON ii.id_impuesto = im.id_impuesto " &
                        "WHERE ti.activo = '1' AND ii.activo = '1' AND ti.id_item = '" & id_item & "' AND ti.id_tmpOCItem = '" + id_tmpOCItem + "'"

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando
            'llenar el dataset
            da.FillSchema(dataset, SchemaType.Source, "tmpOC_items") 'Para que pueda manejarme con los nombres de las tablas y no haga falta por id
            da.Fill(dataset, "tmpOC_items")

            Dim tbl_tmppedidos_items As DataTable
            tbl_tmppedidos_items = dataset.Tables("tmpOC_items")
            cerrardb()

            'Calculo cada uno de los impuestos, excepto el I.V.A. si es un presupuesto
            For Each fila As DataRow In dataset.Tables(0).Rows
                totalImpuestos += fila("porcentaje")
            Next

            Return totalImpuestos
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Sub borraritemCargadoOC(Optional ByVal id_tmpOCItem_seleccionado As Integer = -1)
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String = ""


        mytrans = CN.BeginTransaction()

        Try
            If id_tmpOCItem_seleccionado = -1 Then
                sqlstr = "DELETE FROM tmpOC_items WHERE activo = '0'"
            Else
                sqlstr = "UPDATE tmppedidos_items SET activo = 0 WHERE id_tmpPedidoItem = '" + id_tmpOCItem_seleccionado.ToString + "'"
            End If

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

    'Public Function info_itemOrdenCompra(ByVal id_item As String) As item_produccion
    '    Dim tmp As New item_pedido
    '    Try
    '        'Crea y abre una nueva conexión
    '        abrirdb(serversql, basedb, usuariodb, passdb)

    '        'Propiedades del SqlCommand
    '        Dim comando As New SqlCommand
    '        With comando
    '            .CommandType = CommandType.Text
    '            .CommandText = "SELECT * FROM ordenesCompras_items WHERE id_item = '" + id_item + "'"
    '            .Connection = CN
    '        End With

    '        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
    '        Dim dataset As New DataSet 'Crear nuevo dataset

    '        da.SelectCommand = comando

    '        'llenar el dataset
    '        da.Fill(dataset, "Tabla")
    '        tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
    '        tmp.id_item = dataset.Tables("tabla").Rows(0).Item(1).ToString
    '        tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(2).ToString
    '        tmp.precio = dataset.Tables("tabla").Rows(0).Item(3).ToString
    '        tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
    '        cerrardb()
    '        Return tmp
    '    Catch ex As Exception
    '        'MsgBox(ex.Message.ToString)
    '        tmp.id_item = -1
    '        cerrardb()
    '        Return tmp
    '    End Try
    'End Function
    ' ************************************ FUNCIONES DE ORDENES DE COMPRA ***************************
End Module

