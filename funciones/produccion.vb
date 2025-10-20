Imports System.Data.SqlClient

Module producciones
    ' ************************************ FUNCIONES DE PRODUCCION ***************************
    Public Function info_produccion(Optional ByVal id_produccion As String = "") As produccion
        Dim tmp As New produccion
        Dim sqlstr As String
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                If id_produccion = "" Then
                    sqlstr = "SET DATEFORMAT dmy; SELECT TOP 1 id_produccion, id_proveedor, CONVERT(NVARCHAR(20), fecha_carga, 3), CONVERT(NVARCHAR(20), fecha_envio, 3), CONVERT(NVARCHAR(20), fecha_recepcion, 3), " &
                        "enviado, recibido, notas, activo, id_usuario " &
                        "FROM produccion " &
                        "ORDER BY id_produccion DESC"
                Else
                    sqlstr = "SET DATEFORMAT dmy; SELECT id_produccion, id_proveedor, CONVERT(NVARCHAR(20), fecha_carga, 3), CONVERT(NVARCHAR(20), fecha_envio, 3), CONVERT(NVARCHAR(20), fecha_recepcion, 3), " &
                        "enviado, recibido, notas, activo, id_usuario " &
                        "FROM produccion WHERE id_produccion = '" + id_produccion + "'"
                End If
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_produccion = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha_carga = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha_envio = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.fecha_recepcion = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.enviado = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.recibido = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(9).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_produccion = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addProduccion(p As produccion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO produccion (id_proveedor, fecha_carga, "
            If Not p.fecha_envio Is Nothing Then sqlstr += "fecha_envio, "
            If Not p.fecha_recepcion Is Nothing Then sqlstr += "fecha_recepcion, "
            sqlstr += "enviado, recibido, notas, id_usuario) VALUES " &
            "('" + p.id_proveedor.ToString + "', '" + p.fecha_carga.ToString + "', '"
            If Not p.fecha_envio Is Nothing Then sqlstr += p.fecha_envio.ToString + "', '"
            If Not p.fecha_recepcion Is Nothing Then sqlstr += p.fecha_recepcion.ToString + "', "
            sqlstr += p.enviado.ToString + "', '" + p.recibido.ToString + "', '" + p.notas + "', '" + p.id_usuario.ToString + ")"


            ' ************* CON TRIGGER **********
            'sqlstr = "SET DATEFORMAT dmy; INSERT INTO produccion (id_proveedor, fecha_carga, "
            'If Not p.fecha_envio Is Nothing Then sqlstr += "fecha_envio, "
            'If Not p.fecha_recepcion Is Nothing Then sqlstr += "fecha_recepcion, "
            'sqlstr += "notas) VALUES " &
            '"('" + p.id_proveedor.ToString + "', '" + p.fecha_carga.ToString + "', '"
            'If Not p.fecha_envio Is Nothing Then sqlstr += p.fecha_envio.ToString + "', '"
            'If Not p.fecha_recepcion Is Nothing Then sqlstr += p.fecha_recepcion.ToString + "', '"
            'sqlstr += p.notas + "')"
            ' ************* CON TRIGGER **********

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

    Public Function updateProduccion(p As produccion, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra Then
                sqlstr = "UPDATE produccion SET activo = '0' WHERE id_produccion = '" + p.id_produccion.ToString + "'"
            Else
                sqlstr = "SET DATEFORMAT dmy; UPDATE produccion SET id_proveedor = '" + p.id_proveedor.ToString + "', fecha_carga = '" + p.fecha_carga.ToString + "', "
                If p.fecha_envio IsNot Nothing Then
                    sqlstr += "fecha_envio = '" + p.fecha_envio.ToString + "', enviado = '" + p.enviado.ToString + "', "
                End If

                If p.fecha_recepcion IsNot Nothing Then
                    sqlstr += "fecha_recepcion = '" + p.fecha_recepcion.ToString + "', recibido = '" + p.recibido.ToString + "', "
                End If

                sqlstr += "notas = '" + p.notas + "', activo = '" + p.activo.ToString + "' " &
                            "WHERE id_produccion = '" + p.id_produccion.ToString + "'"
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

    Public Function borrarProduccion(p As produccion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM produccion WHERE id_produccion = '" + p.id_produccion.ToString + "'"
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

    Public Function addItemProducciontmp(ByVal i As item, ByVal cantidad As Integer, Optional ByVal id_tmpProduccionItem As Integer = -1) As Boolean
        Dim sqlComm As New SqlCommand 'Comando en el resto

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                If id_tmpProduccionItem = -1 Or id_tmpProduccionItem = 0 Then
                    .CommandText = "SP_insertItemsProduccionTMP"
                Else
                    .CommandText = "SP_updateItemsProduccionTMP"
                End If
                .CommandType = CommandType.StoredProcedure
                With .Parameters
                    .AddWithValue("id_tmpProduccionItem", id_tmpProduccionItem)
                    .AddWithValue("id_item", i.id_item)
                    .AddWithValue("cantidad", cantidad)
                    .AddWithValue("descript", i.descript)
                    .AddWithValue("id_usuario", usuario_logueado.id_usuario)
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

    Public Function addItemAsocProducciontmp(ByVal id_tmpProduccionItem As Integer, ByVal id_item As Integer, ByVal id_item_asoc As Integer,
                                               ByVal cantidad_item_asoc_enviada As Integer, Optional ByVal id_tmpProduccion_asocItem As Integer = -1) As Boolean
        Dim sqlComm As New SqlCommand 'Comando en el resto

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                If id_tmpProduccion_asocItem = -1 Or id_tmpProduccion_asocItem = 0 Then
                    .CommandText = "SP_insertAsocItemsProduccionTMP"
                Else
                    .CommandText = "SP_updateAsocItemsProduccionTMP"
                End If
                .CommandType = CommandType.StoredProcedure
                With .Parameters
                    .AddWithValue("id_tmpProduccion_asocItem", id_tmpProduccion_asocItem)
                    .AddWithValue("id_tmpProduccionItem", id_tmpProduccionItem)
                    .AddWithValue("id_item", id_item)
                    .AddWithValue("id_item_asoc", id_item_asoc)
                    .AddWithValue("cantidad_item_asoc_enviada", cantidad_item_asoc_enviada)
                    If sqlComm.CommandText = "SP_insertAsocItemsProduccionTMP" Then .AddWithValue("id_usuario", usuario_logueado.id_usuario)
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

    Public Function guardarProduccion(Optional ByVal id_produccion As Integer = 0) As Boolean
        'Obtengo el último pedido que se generó
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim p As New produccion

        If id_produccion = 0 Then
            p = info_produccion()
            id_produccion = p.id_produccion
        End If

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "UPDATE produccion_items " &
                            "SET id_item = src.id_item, " &
                            "cantidad = src.cantidad, " &
                            "id_item_recibido = src.id_item_recibido, " &
                            "cantidad_recibida = src.cantidad_recibida, " &
                            "descript = src.descript " &
                            "FROM produccion_items dst " &
                            "JOIN tmpproduccion_items src ON src.id_produccionItem = dst.id_produccionItem " &
                            "WHERE dst.id_produccion = '" + id_produccion.ToString + "' " &
                                "AND src.activo = '1' " &
                        "INSERT produccion_items " &
                            "(id_produccion, " &
                            "id_item, " &
                            "cantidad, " &
                            "id_item_recibido, " &
                            "cantidad_recibida, " &
                            "descript) " &
                            "SELECT '" + id_produccion.ToString + "', " &
                               "id_item, " &
                               "cantidad, " &
                               "id_item_recibido, " &
                               "cantidad_recibida, " &
                               "descript " &
                            "FROM tmpproduccion_items src " &
                            "WHERE NOT EXISTS " &
                            "(" &
                                "SELECT id_item " &
                                "FROM produccion_items dst " &
                                "WHERE src.id_produccionItem = dst.id_produccionItem " &
                                    "AND dst.id_produccion = '" + id_produccion.ToString + "'" &
                            ") " &
                            "AND src.activo = '1' " &
                            "ORDER BY src.id_tmpProduccionItem ASC"
            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            'Actualizo la tabla con las cantidades enviadas de los productos que tienen productos asociados
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "UPDATE produccion_asocItems " &
                            "SET cantidad_item_asoc_enviada = src.cantidad_item_asoc_enviada " &
                            "FROM produccion_asocItems dst " &
                            "JOIN tmpproduccion_asocItems src ON src.id_produccion = dst.id_produccion " &
                            "WHERE dst.id_produccion = '" + id_produccion.ToString + "' " &
                                "AND dst.id_item = src.id_item " &
                                "AND dst.id_item_asoc = src.id_item_asoc " &
                        "INSERT produccion_asocItems " &
                            "(id_produccion, " &
                            "id_item, " &
                            "id_item_asoc, " &
                            "cantidad_item_asoc_enviada) " &
                            "SELECT '" + id_produccion.ToString + "', " &
                               "id_item, " &
                               "id_item_asoc, " &
                               "cantidad_item_asoc_enviada " &
                            "FROM tmpproduccion_asocItems src " &
                            "WHERE NOT EXISTS " &
                            "(" &
                                "SELECT id_item " &
                                "FROM produccion_asocItems dst " &
                                "WHERE src.id_item = dst.id_item  " &
                                    "AND src.id_item_asoc = dst.id_item_asoc " &
                                    "AND dst.id_produccion = '" + id_produccion.ToString + "'" &
                            ") " &
                            "ORDER BY src.id_tmpProduccion_asocItem ASC"
            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            'Borro de la tabla produccion_items, todos los items que no estén en la tabla tmpproduccion_items
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "DELETE FROM produccion_items " &
                        "WHERE id_produccionItem IN " &
                        "( " &
                        "	SELECT tmpi.id_produccionItem " &
                        "	FROM produccion_items AS pit " &
                        "	LEFT JOIN tmpproduccion_items AS tmpi ON tmpi.id_item = pit.id_item " &
                        "	WHERE tmpi.activo = 0 AND tmpi.id_produccion = " + id_produccion.ToString + " AND pit.cantidad = tmpi.cantidad " &
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

    Public Function produccion_a_produccionTmp(ByVal id_produccion As Integer) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO tmpproduccion_items (id_produccionItem, id_produccion, id_item, cantidad, activo, descript, id_item_recibido, cantidad_recibida, id_usuario) " _
                               + "SELECT id_produccionItem, id_produccion, id_item, cantidad, activo, descript, id_item_recibido, cantidad_recibida, '" + usuario_logueado.id_usuario.ToString + "' " _
                               + "FROM produccion_items " _
                               + "WHERE id_produccion = '" + id_produccion.ToString + "'"
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

    Public Function askCantidadCargadaProduccion(ByVal id_item As Integer, Optional ByVal id As Integer = -1, Optional ByVal id_tmpProduccionItem As Integer = -1) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sqlstr As String

            sqlstr = "SELECT cantidad FROM tmpproduccion_items WHERE id_item = '" + id_item.ToString + "'"
            If id <> -1 Then sqlstr = sqlstr + " AND id_produccion = '" + id.ToString + "'"
            If id_tmpProduccionItem <> -1 Then sqlstr = sqlstr + " AND id_tmpProduccionItem = '" + id_tmpProduccionItem.ToString + "'"

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

    Public Sub imprimirProduccion(ByVal id_produccion As Integer)
        If showrpt Then
            id = id_produccion
            'Dim frm As New frm_reportes(esPresupuesto, imprimeRemito)
            'frm.ShowDialog()
            'frm_reportes.ShowDialog()
            id = 0
        End If
    End Sub

    'Public Sub borrarTmpProduccion()
    'borrartbl("tmpproduccion_asocItems")
    'borrartbl("tmpproduccion_items", True)
    'End Sub

    'Public Function Items_Asociados_Produccion_A_TMP(ByVal id_produccion As Integer, ByVal id_item As Integer) As Boolean
    '    Dim sqlstr As String
    '    abrirdb(serversql, basedb, usuariodb, passdb)

    '    Dim mytrans As SqlTransaction
    '    Dim Comando As New SqlClient.SqlCommand

    '    mytrans = CN.BeginTransaction()

    '    Try
    '        sqlstr = "INSERT INTO tmppedidos_items (id_pedidoItem, id_pedido, id_item, cantidad, precio, activo, descript) " _
    '                           + "SELECT id_pedidoItem, id_pedido, id_item, cantidad, precio, activo, descript " _
    '                           + "FROM pedidos_items " _
    '                           + "WHERE id_pedido = '" + id_pedido.ToString + "'"
    '        Comando = New SqlClient.SqlCommand(sqlstr, CN)

    '        Comando.Transaction = mytrans
    '        Comando.ExecuteNonQuery()

    '        mytrans.Commit()
    '        cerrardb()
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        cerrardb()
    '        Return False
    '    End Try
    'End Function

    'Public Function info_itemProduccion(ByVal id_item As String) As item_produccion
    '    Dim tmp As New item_pedido
    '    Try
    '        'Crea y abre una nueva conexión
    '        abrirdb(serversql, basedb, usuariodb, passdb)

    '        'Propiedades del SqlCommand
    '        Dim comando As New SqlCommand
    '        With comando
    '            .CommandType = CommandType.Text
    '            .CommandText = "SELECT * FROM produccion_items WHERE id_item = '" + id_item + "'"
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
    ' ************************************ FUNCIONES DE PRODUCCION ***************************
End Module
