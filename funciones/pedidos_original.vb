Imports System.Data.SqlClient

Module pedidos
    ' ************************************ FUNCIONES DE PEDIDOS ***************************
    Public Function InfoPedido(Optional ByVal id_pedido As String = "") As pedido
        Dim tmp As New pedido
        Dim sqlstr As String
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                If id_pedido = "" Then
                    sqlstr = "SET DATEFORMAT dmy; SELECT TOP 1 id_pedido, CONVERT(NVARCHAR(20), fecha, 3), CONVERT(NVARCHAR(20), fecha_edicion, 3), id_cliente, " &
                                "markup, subtotal, iva, total, nota1, nota2, esPresupuesto, activo, cerrado, ISNULL(idPresupuesto, 0), ISNULL(id_comprobante, 0), " &
                                "cae, CONVERT(NVARCHAR(20), fechaVencimiento_cae, 112), ISNULL(puntoVenta, 0), ISNULL(numeroComprobante, 0), " &
                                "ISNULL(codigoDeBarras, 0), ISNULL(esTest, 0), id_cc, ISNULL(numeroComprobante_anulado, 0), ISNULL(numeroPedido_anulado, 0), esDuplicado, id_usuario " &
                                "FROM pedidos " &
                                "ORDER by id_pedido DESC"
                Else
                    sqlstr = "SET DATEFORMAT dmy; SELECT id_pedido, CONVERT(NVARCHAR(20), fecha, 3), CONVERT(NVARCHAR(20), fecha_edicion, 3), id_cliente, " &
                                    "markup, subtotal, iva, total, nota1, nota2, esPresupuesto, activo, cerrado, ISNULL(idPresupuesto, 0), ISNULL(id_comprobante, 0), " &
                                    "cae, CONVERT(NVARCHAR(20), fechaVencimiento_cae, 112), ISNULL(puntoVenta, 0), ISNULL(numeroComprobante, 0), " +
                                    "ISNULL(codigoDeBarras, 0), ISNULL(esTest, 0), id_cc, ISNULL(numeroComprobante_anulado, 0), ISNULL(numeroPedido_anulado, 0), esDuplicado, id_usuario " &
                                    "FROM pedidos " &
                                    "WHERE id_pedido = '" + id_pedido + "'"
                End If
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha_edicion = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.markup = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.iva = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.nota1 = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.nota2 = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.esPresupuesto = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.cerrado = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.idPresupuesto = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.id_comprobante = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.cae = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.fechaVencimiento_cae = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.puntoVenta = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.numeroComprobante = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.codigoDeBarras = dataset.Tables("tabla").Rows(0).Item(19).ToString
            tmp.esTest = dataset.Tables("tabla").Rows(0).Item(20).ToString
            tmp.id_Cc = dataset.Tables("tabla").Rows(0).Item(21).ToString
            tmp.numeroComprobante_anulado = dataset.Tables("tabla").Rows(0).Item(22).ToString
            tmp.numeroPedido_anulado = dataset.Tables("tabla").Rows(0).Item(23).ToString
            tmp.esDuplicado = dataset.Tables("tabla").Rows(0).Item(24).ToString
            tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(25).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    'Public Function info_nComprobante(ByVal id_nComprobante As String, ByVal id_comprobante As String) As pedido
    '    Dim tmp As New pedido
    '    Dim sqlstr As String
    '    Try
    '        'Crea y abre una nueva conexión
    '        abrirdb(serversql, basedb, usuariodb, passdb)
    '
    ''
    '            'Propiedades del SqlCommand
    '           Dim comando As New SqlCommand

    'With comando
    '    .CommandType = CommandType.Text
    '    sqlstr = "SET DATEFORMAT dmy; SELECT id_pedido, CONVERT(NVARCHAR(20), fecha, 3), CONVERT(NVARCHAR(20), fecha_edicion, 3), id_cliente, " &
    '                "markup, subtotal, iva, total, nota1, nota2, esPresupuesto, activo, cerrado, ISNULL(idPresupuesto, 0), ISNULL(id_comprobante, 0), " &
    '                "cae, CONVERT(NVARCHAR(20), fechaVencimiento_cae, 112), ISNULL(puntoVenta, 0), ISNULL(numeroComprobante, 0), " +
    '                "ISNULL(codigoDeBarras, 0), ISNULL(esTest, 0), id_cc, ISNULL(numeroComprobante_anulado, 0) " &
    '                "FROM pedidos " &
    '                "WHERE numeroComprobante = '" + id_nComprobante + "' AND id_comprobante = '" + id_comprobante + "' "
    '    .CommandText = sqlstr
    '    .Connection = CN
    'End With

    'Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
    'Dim dataset As New DataSet 'Crear nuevo dataset

    '        da.SelectCommand = comando
    '
    'llenar el dataset
    '   da.Fill(dataset, "Tabla")

    '  tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
    ' tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
    'tmp.fecha_edicion = dataset.Tables("tabla").Rows(0).Item(2).ToString
    'tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(3).ToString
    'tmp.markup = dataset.Tables("tabla").Rows(0).Item(4).ToString
    '            tmp.subTotal = dataset.Tables("tabla").Rows(0).Item(5).ToString
    '            tmp.iva = dataset.Tables("tabla").Rows(0).Item(6).ToString
    '           tmp.total = dataset.Tables("tabla").Rows(0).Item(7).ToString
    '          tmp.nota1 = dataset.Tables("tabla").Rows(0).Item(8).ToString
    '         tmp.nota2 = dataset.Tables("tabla").Rows(0).Item(9).ToString
    '        tmp.esPresupuesto = dataset.Tables("tabla").Rows(0).Item(10).ToString
    '       tmp.activo = dataset.Tables("tabla").Rows(0).Item(11).ToString
    '      tmp.cerrado = dataset.Tables("tabla").Rows(0).Item(12).ToString
    '     tmp.idPresupuesto = dataset.Tables("tabla").Rows(0).Item(13).ToString
    '     tmp.id_comprobante = dataset.Tables("tabla").Rows(0).Item(14).ToString
    '     tmp.cae = dataset.Tables("tabla").Rows(0).Item(15).ToString
    '     tmp.fechaVencimiento_cae = dataset.Tables("tabla").Rows(0).Item(16).ToString
    '     tmp.puntoVenta = dataset.Tables("tabla").Rows(0).Item(17).ToString
    '     tmp.numeroComprobante = dataset.Tables("tabla").Rows(0).Item(18).ToString
    '     tmp.codigoDeBarras = dataset.Tables("tabla").Rows(0).Item(19).ToString
    '     tmp.esTest = dataset.Tables("tabla").Rows(0).Item(20).ToString
    '     tmp.id_Cc = dataset.Tables("tabla").Rows(0).Item(21).ToString
    '     tmp.numeroComprobante_anulado = dataset.Tables("tabla").Rows(0).Item(22).ToString
    '     cerrardb()
    '     Return tmp
    'Catch ex As Exception
    '    MsgBox(ex.Message.ToString)
    '    'tmp.nombre = "error"
    '    cerrardb()
    ' Return tmp
    'End Try
    '    End Function

    Public Function AddPedido(p As pedido) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO pedidos (fecha, id_cliente, markup, subTotal, iva, total, nota1, nota2, esPresupuesto, activo, idPresupuesto, id_comprobante, cae, " _
                                            + "fechaVencimiento_cae, puntoVenta, numeroComprobante, codigoDeBarras, esTest, id_Cc, numeroComprobante_anulado, numeroPedido_anulado, id_usuario) VALUES ('" + p.fecha.ToString + "', '" _
                                            + p.id_cliente.ToString + "', '" + p.markup.ToString + "', '" + p.subTotal.ToString + "', '" + p.iva.ToString + "', '" _
                                            + p.total.ToString + "', '" + p.nota1.ToString + "', '" + p.nota2 + "', '" + p.esPresupuesto.ToString + "', '" + p.activo.ToString +
                                            "', CASE WHEN " + p.idPresupuesto.ToString + " = 0 THEN NULL ELSE " + p.idPresupuesto.ToString + " END, '" _
                                            + p.id_comprobante.ToString + "', '" + p.cae + "', '" + p.fechaVencimiento_cae + "', '" + p.puntoVenta.ToString +
                                            "', CASE WHEN " + p.numeroComprobante.ToString + " = 0 THEN NULL ELSE " + p.numeroComprobante.ToString + " END ,'" _
                                              + p.codigoDeBarras + "', '" + p.esTest.ToString + "', '" + p.id_Cc.ToString + "', '" + p.numeroComprobante_anulado.ToString +
                                             "', '" + p.numeroPedido_anulado.ToString + "', '" + p.id_usuario.ToString + "') "
            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function UpdatePedido(ByVal p As pedido, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra Then
                sqlstr = "UPDATE pedidos SET activo = '0' WHERE id_pedido = '" + p.id_pedido.ToString + "'"
            Else
                sqlstr = "SET DATEFORMAT dmy; UPDATE pedidos SET fecha = '" + p.fecha + "', fecha_edicion = '" + p.fecha_edicion +
                        "', id_cliente = '" + p.id_cliente.ToString + "', markup = '" + p.markup.ToString +
                        "', subTotal = '" + p.subTotal.ToString + "', iva = '" + p.iva.ToString + "', total = '" + p.total.ToString + "', nota1 = '" + p.nota1 +
                        "', nota2 = '" + p.nota2 + "', esPresupuesto = '" + p.esPresupuesto.ToString + "', activo = '" + p.activo.ToString +
                        "', cerrado = '" + p.cerrado.ToString +
                        "', idPresupuesto = CASE WHEN " + p.idPresupuesto.ToString + " = 0 THEN NULL ELSE " + p.idPresupuesto.ToString + " END " +
                        ", id_comprobante = '" + p.id_comprobante.ToString + "', cae = '" + p.cae +
                        "', fechaVencimiento_cae = '" + p.fechaVencimiento_cae + "', puntoVenta = '" + p.puntoVenta.ToString +
                        "', numeroComprobante = '" + p.numeroComprobante.ToString + "', codigoDeBarras = '" + p.codigoDeBarras +
                        "', esTest = '" + p.esTest.ToString + "', id_Cc = '" + p.id_Cc.ToString + " " +
                        "', numeroComprobante_anulado = '" + p.numeroComprobante_anulado.ToString + " " +
                        "', numeroPedido_anulado = '" + p.numeroPedido_anulado.ToString + " " +
                        "', id_usuario = '" + p.id_usuario.ToString + "' " +
                        " WHERE id_pedido = '" + p.id_pedido.ToString + "'"
            End If

            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function BorrarPedido(p As pedido) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM tmppedidos_items WHERE id_pedido = '" + p.id_pedido.ToString + "'; DELETE FROM pedidos_items WHERE id_pedido = '" + p.id_pedido.ToString + "'; DELETE FROM pedidos WHERE id_pedido = '" + p.id_pedido.ToString + "'"
            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function Info_Ultimo_Pedido_Por_Usuario(ByVal _idUsuario As Integer) As Integer
        Dim id_ultimo_pedido As Integer = -1
        Dim sqlstr As String
        Dim n As Integer = 0

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                sqlstr = "SELECT TOP 1 id_pedido FROM pedidos WHERE id_usuario = '" + _idUsuario.ToString + "' ORDER BY id_pedido DESC"

                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            id_ultimo_pedido = dataset.Tables("tabla").Rows(0).Item(0)
            Return id_ultimo_pedido
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            Return id_ultimo_pedido
        Finally
            cerrardb()
        End Try
    End Function
    'Public Function addItemPedidotmp(ByVal id_item As Integer, ByVal cantidad As Double, ByVal precio As String, Optional ByVal id_tmpPedidoItem As Integer = -1) As Boolean
    Public Function AddItemPedidoTmp(ByVal i As item, ByVal cantidad As Double, ByVal precio As String, ByVal _idUsuario As Integer, ByVal _idUnico As String,
                                       Optional ByVal id_tmpPedidoItem As Integer = -1) As Boolean
        'Dim i As New item
        'If id_item Then i = info_item(id_item)

        'Dim mytrans As SqlTransaction
        Dim subtotal As Double
        Dim sqlComm As New SqlCommand 'Comando en el resto

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            'If id_item And i.esDescuento Then
            If i.esDescuento Then
                'Si es un descuento guardo el precio negativo
                'precio = (Math.Round(add_pedido.txt_subTotal.Text * precio, 2)) * -1
                Dim frm As add_pedido = DirectCast(Application.OpenForms.Item("add_pedido"), add_pedido)
                subtotal = CDbl(frm.txt_subTotal.Text)
                precio = (Math.Round(subtotal * precio, 2)) * -1
            End If

            With sqlComm
                If id_tmpPedidoItem = -1 Or id_tmpPedidoItem = 0 Then
                    .CommandText = "SP_insertItemsTMP"
                Else
                    .CommandText = "SP_updateItemsTMP"
                End If
                .CommandType = CommandType.StoredProcedure
                With .Parameters
                    .AddWithValue("id_tmpPedidoItem", id_tmpPedidoItem)
                    .AddWithValue("id_item", i.id_item)
                    .AddWithValue("cantidad", cantidad)
                    .AddWithValue("precio", precio)
                    .AddWithValue("descript", i.descript)
                    .AddWithValue("item", i.item)
                    .AddWithValue("id_usuario", _idUsuario)
                    .AddWithValue("id_unico", _idUnico)
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

    Public Function GuardarPedido(ByVal _idUsuario As Integer, ByVal _idUnico As String, ByVal _id_pedido As Integer) As Boolean
        'Obtengo el último pedido que se generó
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim p As New pedido

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "UPDATE pedidos_items " &
                            "SET cantidad = src.cantidad, " &
                            "descript = src.descript, " &
                            "precio = src.precio " &
                            "FROM pedidos_items dst " &
                            "JOIN tmppedidos_items src ON src.id_pedidoItem = dst.id_pedidoItem " &
                            "WHERE src.activo = '1' " &
                            "AND src.id_usuario = '" + _idUsuario.ToString &
                            "' AND src.id_unico = '" + _idUnico &
                            "' AND dst.id_pedido = '" + _id_pedido.ToString + "' " &
                        "INSERT pedidos_items " &
                            "(id_item, " &
                            "cantidad, " &
                            "precio, " &
                            "id_pedido, " &
                            "descript) " &
                            "SELECT id_item, " &
                               "cantidad, " &
                               "precio, '" &
                                _id_pedido.ToString + "', " &
                                "descript " &
                            "FROM tmppedidos_items src " &
                            "WHERE NOT EXISTS " &
                            "(" &
                                "SELECT id_item " &
                                "FROM pedidos_items dst " &
                                "WHERE src.id_pedidoItem = dst.id_pedidoItem " &
                                    "AND dst.id_pedido = '" + _id_pedido.ToString + "'" &
                            ") AND src.activo = '1' " &
                            "AND src.id_usuario = '" + _idUsuario.ToString &
                            "' AND src.id_unico = '" + _idUnico &
                            "' ORDER BY src.id_tmpPedidoItem ASC"
            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            'Borro de la tabla pedidos_items, todos los items que no estén en la tabla tmppedidos_items
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            'sqlstr = "DELETE FROM pedidos_items " &
            '            "WHERE id_pedidoItem IN " &
            '            "( " &
            '            "	SELECT tmpi.id_pedidoItem " &
            '            "	FROM pedidos_items AS pit " &
            '            "	LEFT JOIN tmppedidos_items AS tmpi ON tmpi.id_item = pit.id_item " &
            '            "	WHERE tmpi.activo = 0 " &
            '            "   AND pit.id_pedido = " + _id_pedido.ToString &
            '            "   AND pit.cantidad = tmpi.cantidad " &
            '            "   AND pit.precio = tmpi.precio " &
            '            "   AND tmpi.id_usuario = '" + _idUsuario.ToString + "' " &
            '            "   AND tmpi.id_unico = '" + _idUnico + "' " &
            '            ")"

            sqlstr = "DELETE FROM pedidos_items " &
                        "WHERE id_pedidoItem IN " &
                        "( " &
                        "	SELECT tmpi.id_pedidoItem " &
                        "	FROM pedidos_items AS pit " &
                        "	LEFT JOIN tmppedidos_items AS tmpi ON tmpi.id_item = pit.id_item " &
                        "	WHERE tmpi.activo = 0 " &
                        "   AND pit.id_pedido = " + _id_pedido.ToString &
                        "   AND tmpi.id_usuario = '" + _idUsuario.ToString + "' " &
                        "   AND tmpi.id_unico = '" + _idUnico + "' " &
                        ")"

            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function InfoItemPedido(ByVal id_item As String) As item_pedido
        Dim tmp As New item_pedido
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM pedidos_items WHERE id_item = '" + id_item + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.precio = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.id_item = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function CerrarPedido(ByVal p As pedido, ByVal esPresupuesto As Boolean, ByVal imprimeRemito As Boolean) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE pedidos SET cerrado = '1', activo = '0' WHERE id_pedido = '" + p.id_pedido.ToString + "'"
            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()

            '''''''imprimirFactura(p.id_pedido, esPresupuesto, imprimeRemito)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function RecargaPrecios(Optional ByVal id As Integer = 0, Optional ByVal id_item As Integer = 0, Optional ByVal tabla As String = "") As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        If id_item = 0 Then
            'Recargo todos los precios
            If tabla = "pedidos_items" Then
                sqlstr = "UPDATE pedidos_items " & _
                            "SET pedidos_items.precio = i.precio_lista " & _
                            "FROM pedidos_items AS [pi] " & _
                            "INNER JOIN items AS i ON [pi].id_item = i.id_item " & _
                            "WHERE [pi].id_pedido = '" + id.ToString + "' AND i.esDescuento = '0' AND i.esmarkup = '0'"
            Else
                sqlstr = "UPDATE tmppedidos_items " & _
                        "SET tmppedidos_items.precio = i.precio_lista " & _
                        "FROM tmppedidos_items AS tmpi " & _
                        "INNER JOIN items AS i ON tmpi.id_item = i.id_item " & _
                        "WHERE i.esDescuento = '0' AND i.esmarkup = '0'"

            End If
        Else
            'Recargo el precio solo del item indicado
            If tabla = "pedidos_items" Then
                sqlstr = "UPDATE pedidos_items " & _
                            "SET pedidos_items.precio = items.precio_lista " & _
                            "FROM pedidos_iitems AS [pi] " & _
                            "INNER JOIN items AS i ON [pi].id_item = i.id_item " & _
                            "WHERE [pi].id_pedido = '" + id.ToString + "' AND [pi].id_item = '" + id_item.ToString + "' AND i.esDescuento = '0' AND i.esmarkup = '0'"
            Else
                sqlstr = "UPDATE tmppedidos_items " & _
                            "SET tmppedidos_items.precio = i.precio_lista " & _
                            "FROM tmppedidos_items AS tmpi " & _
                            "INNER JOIN items AS i ON tmpi.id_item = i.id_item " & _
                            "WHERE tmpi.id_item = '" + id_item.ToString + "' AND i.esDescuento = '0' AND i.esmarkup = '0' "
            End If
        End If


        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
            Comando.ExecuteNonQuery()
            mytrans.Commit()
            cerrardb()
            If id <> 0 And tabla <> "" Then
                If recargaprecios(, id_item) = False Then Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function

    'Public Function askCantidadCargada(ByVal id_item As Integer, Optional ByVal id_pedido As Integer = -1, Optional ByVal id_tmpPedidoItem As Integer = -1) As Double
    Public Function AskCantidadCargada(ByVal id_item As Integer, ByVal id_pedido As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sqlstr As String
            If tabla = "pedidos_detalle" Then
                sqlstr = "SELECT cantidad FROM pedidos_detalle WHERE id_item = '" + id_item.ToString + "' AND id_pedido = '" + id_pedido.ToString + "'"
            Else
                sqlstr = "SELECT cantidad FROM tmppedidos_items WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString _
                    + "' AND id_unico = '" + _idUnico + "'"
            End If

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

    Public Function AskPrecioCargado(ByVal id_item As Integer, ByVal id_pedido As Integer, ByVal tabla As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Double
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            If tabla = "pedidos_detalle" Then
                sqlstr = "SELECT precio FROM pedidos_detalle WHERE id_item = '" + id_item.ToString + "' AND id_pedido = '" + id_pedido.ToString + "'"
            Else
                sqlstr = "SELECT precio FROM tmppedidos_items WHERE id_item = '" + id_item.ToString + "' AND id_usuario = '" + _idUsuario.ToString _
                    + "' AND id_unico = '" + _idUnico + "'"
            End If

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

    Public Function ExisteDescuentoMarkupTmp(ByVal id_item As Integer) As Integer
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim sqlstr As String

            sqlstr = "SELECT id_tmpPedidoItem FROM tmppedidos_items WHERE id_item = '" + id_item.ToString + "'"

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

            Dim id_tmpPedidoItem As Integer
            id_tmpPedidoItem = dataset.Tables("tabla").Rows(0).Item(0).ToString
            Return id_tmpPedidoItem
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            'si no hay stock devuelve -1
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function DuplicarPedido(ByVal id As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        Dim sqlstr As String = ""

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy;
                        INSERT INTO pedidos (
                                                fecha
                                                , id_cliente
                                                , markup
                                                , subTotal
                                                , iva
                                                , total
                                                , nota1
                                                , nota2
                                                , esPresupuesto
                                                , activo
                                                , cerrado
                                                , id_comprobante
                                                , esTest
                                                , id_Cc
                                                , esDuplicado
                                                , id_usuario
                                            ) 
                        SELECT '" & Format(DateTime.Now, "dd/MM/yyyy") & "'
                            , id_cliente
                            , markup
                            , subTotal
                            , iva
                            , total
                            , nota1
                            , nota2
                            , esPresupuesto
                            , 1
                            , 0
                            , id_comprobante
                            , esTest
                            , id_Cc 
                            , 1 
                            , " + usuario_logueado.id_usuario.ToString + "
                        FROM pedidos 
                        WHERE id_pedido = '" + id.ToString + "'; 
                        DECLARE @nuevo_id_pedido AS INTEGER; 
                        SET @nuevo_id_pedido = (SELECT TOP 1 id_pedido FROM pedidos WHERE id_usuario = " + usuario_logueado.id_usuario.ToString + "ORDER BY id_pedido DESC);
                        INSERT INTO pedidos_items (id_item, cantidad, precio, id_pedido)
                        SELECT id_item, cantidad, precio, @nuevo_id_pedido
                        FROM pedidos_items
                        WHERE id_pedido = '" + id.ToString + "'"

            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function DuplicarPedidoTemporal(ByVal id As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        Dim sqlstr As String = ""

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy;
                        INSERT INTO pedidos (
                                                fecha
                                                , id_cliente
                                                , markup
                                                , subTotal
                                                , iva
                                                , total
                                                , nota1
                                                , nota2
                                                , esPresupuesto
                                                , activo
                                                , cerrado
                                                , id_comprobante
                                                , esTest
                                                , id_Cc
                                                , esDuplicado
                                                , id_usuario
                                            ) 
                        SELECT '" & Format(DateTime.Now, "dd/MM/yyyy") & "'
                            , id_cliente
                            , markup
                            , subTotal
                            , iva
                            , total
                            , nota1
                            , nota2
                            , esPresupuesto
                            , 1
                            , 0
                            , id_comprobante
                            , esTest
                            , id_Cc 
                            , 1 
                            , " + usuario_logueado.id_usuario.ToString + "
                        FROM pedidos 
                        WHERE id_pedido = '" + id.ToString + "'; 
                        DECLARE @nuevo_id_pedido AS INTEGER; 
                        SET @nuevo_id_pedido = (SELECT TOP 1 id_pedido FROM pedidos WHERE id_usuario = " + usuario_logueado.id_usuario.ToString + "ORDER BY id_pedido DESC);
                        INSERT INTO pedidos_items (id_item, cantidad, precio, id_pedido)
                        SELECT id_item, cantidad, precio, @nuevo_id_pedido
                        FROM pedidos_items
                        WHERE id_pedido = '" + id.ToString + "'"

            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function UpdatePrecios(ByVal datagrid As DataGridView, ByVal chk_esPresupuesto As CheckBox, ByVal txt_subTotal As TextBox, ByVal txt_impuestos As TextBox,
                                     ByVal txt_total As TextBox, ByVal txt_totalOriginal As TextBox, ByVal txt_markup As TextBox, ByVal txt_totalDescuentos As TextBox,
                                     ByVal comprobanteSeleccionado As comprobante, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Dim sqlstr As String
        Dim total As Double
        Dim subtotal As Double
        Dim descuento As Double
        'Dim iva As Double
        Dim impuestosItem As Double
        Dim totalImpuestoItem As Double
        Dim totalImpuestos As Double
        Dim factor As Double
        Dim precio As Double
        Dim cantidad As Integer
        Dim id_item As Integer
        Dim mytrans As SqlTransaction
        Dim comando As New SqlCommand
        Dim id_tmpPedidoItem As Integer

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT ti.id_tmpPedidoItem, ISNULL(ti.id_item, 0) AS 'id_item' , ti.cantidad, ti.precio, ti.activo, " &
                        "ISNULL(i.esDescuento, 0) AS 'esDescuento', ISNULL(i.esMarkup, 0) AS 'esMarkup', ISNULL(i.factor, 1) AS 'factor', " &
                        "ISNULL(ti.descript, '') AS descript " &
                        "FROM tmppedidos_items AS ti " &
                        "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                        "WHERE id_usuario = '" + _idUsuario.ToString + "' AND id_unico = '" + _idUnico + "' " &
                        "ORDER BY id_tmpPedidoItem ASC"


            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando
            'llenar el dataset
            da.FillSchema(dataset, SchemaType.Source, "tmppedidos_items") 'Para que pueda manejarme con los nombres de las tablas y no haga falta por id
            da.Fill(dataset, "tmppedidos_items")

            Dim tbl_tmppedidos_items As DataTable
            tbl_tmppedidos_items = dataset.Tables("tmppedidos_items")
            cerrardb()

            'Calculo el subtotal
            For Each fila As DataRow In dataset.Tables(0).Rows
                cantidad = fila("cantidad")
                precio = fila("precio")
                If Not fila("esDescuento") And Not fila("esMarkup") And fila("activo") Then subtotal = subtotal + (cantidad * precio)
            Next

            txt_totalOriginal.Text = subtotal

            'Calculo los descuentos a partir del subtotal que se va actualizando con cada descuento
            For Each fila As DataRow In dataset.Tables(0).Rows
                If fila("esDescuento") And fila("activo") Then
                    fila.BeginEdit()

                    id_tmpPedidoItem = fila("id_tmpPedidoItem")
                    factor = fila("factor")
                    precio = (subtotal * factor) * -1 'Multiplico por -1 porque al ser un descuento necesito que sea negativo
                    cantidad = fila("cantidad")
                    id_item = fila("id_item")
                    fila("precio") = precio
                    fila.EndEdit()
                    'descuento += precio * -1
                    descuento += precio
                    subtotal = subtotal + precio 'Sumo porque fila("precio") tiene un valor negativo y + * - = - por lo cual queda restando

                    'Actualizo el precio en la base de datos
                    abrirdb(serversql, basedb, usuariodb, passdb)
                    sqlstr = "UPDATE tmppedidos_items SET cantidad = '" + cantidad.ToString + "', precio = '" + precio.ToString + "', activo = '1' WHERE id_item = '" + id_item.ToString &
                        "' AND id_tmpPedidoItem = '" + id_tmpPedidoItem.ToString + "' AND id_usuario = '" + _idUsuario.ToString + "' AND id_unico = '" + _idUnico + "' "

                    mytrans = CN.BeginTransaction()

                    comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
                    comando.ExecuteNonQuery()

                    mytrans.Commit()
                    cerrardb()
                End If
            Next

            'Calculo los impuestos
            'Calculo los impuestos
            'Dim tc As TipoComprobante
            Dim comprobantesB As New List(Of Integer) From {6, 7, 8, 9, 10, 18, 25, 26, 28, 43, 46, 61, 64, 82, 113, 116, 206}
            If comprobanteSeleccionado.esPresupuesto = 0 Then
                If Not comprobantesB.Contains(comprobanteSeleccionado.id_tipoComprobante) Then
                    totalImpuestos = 0

                    For Each fila As DataRow In dataset.Tables(0).Rows
                        If Not fila("esDescuento") And Not fila("esMarkup") And fila("activo") Then
                            precio = fila("precio")
                            cantidad = fila("cantidad")
                            impuestosItem = CalculaImpuestosItem(fila("id_tmpPedidoItem"), fila("id_item"), comprobanteSeleccionado)
                            '  If comprobanteSeleccionado.id_tipoComprobante = 6 Then
                            ' totalImpuestoItem = (precio * cantidad) - ((precio * cantidad) / Val("1." & impuestosItem))
                            ' Else
                            totalImpuestoItem = ((impuestosItem * (precio * cantidad)) / 100)
                            '   End If
                            totalImpuestos += totalImpuestoItem
                        End If
                    Next

                    totalImpuestos = totalImpuestos - ((impuestosItem * (descuento * -1)) / 100) 'TERRIBLE PARCHE SACALO YA!
                Else

                    totalImpuestos = subtotal - subtotal / 1.21
                End If
            End If

            'If comprobanteSeleccionado.id_tipoComprobante = 6 Then
            If comprobantesB.Contains(comprobanteSeleccionado.id_tipoComprobante) Then
                total = subtotal
                subtotal = subtotal - totalImpuestos
            Else
                total = subtotal + totalImpuestos
            End If
            impuestosItem = totalImpuestos



            'Si hay un descuento desactivo la posibilidad de poner markup y viceversa
            If txt_totalOriginal.Text <> subtotal Then
                txt_markup.Enabled = False
            Else
                txt_markup.Enabled = True
            End If


            'If add_pedido.chk_presupuesto.Checked Then
            '    'Si es un presupuesto no calcula IVA
            '    total = subtotal
            'Else
            '    impuestosItem = subtotal * 0.21
            '    total = subtotal + impuestosItem
            'End If

            txt_subTotal.Text = Math.Round(subtotal, 2)
            txt_impuestos.Text = Math.Round(totalImpuestos, 2)
            txt_totalDescuentos.Text = Math.Round(descuento, 2)
            txt_total.Text = Math.Round(total, 2)

            sqlstr = "SELECT CONCAT(ti.id_tmpPedidoItem, '-', ti.id_item) AS 'ID', ti.id_pedidoItem AS 'id_pedidioItem', 
                    CASE WHEN ti.id_item IS NULL THEN ti.descript ELSE i.descript END AS 'Producto', ti.cantidad AS 'Cant.', ti.precio AS 'Precio', " &
                   "CAST(ti.cantidad * ti.precio AS DECIMAL(18,2)) AS 'Subtotal' " &
                   "FROM tmppedidos_items AS ti " &
                   "LEFT JOIN items AS i ON ti.id_item = i.id_item " &
                   "LEFT JOIN tipos_items AS tim ON i.id_tipo = tim.id_tipo " &
                   "WHERE ti.activo = '1' AND (i.esMarkup = '0' OR i.esMarkup IS NULL)" &
                   "AND ti.id_usuario = '" + _idUsuario.ToString + "' AND ti.id_unico = '" + _idUnico + "' " &
                   "ORDER BY i.esdescuento ASC, id ASC"
            cargar_datagrid(datagrid, sqlstr, basedb)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function CalculaImpuestosItem(ByVal id_tmpPedidoItem As String, ByVal id_item As String, ByVal comprobanteSeleccionado As comprobante) As Double
        Dim sqlstr As String
        Dim totalImpuestos As Double
        Dim comando As New SqlCommand

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT ti.id_item, ti.cantidad, ti.precio, im.nombre, im.porcentaje " &
                        "FROM tmppedidos_items AS ti " &
                        "INNER JOIN items AS it ON ti.id_item = it.id_item " &
                        "INNER JOIN items_impuestos AS ii ON ti.id_item = ii.id_item " &
                        "INNER JOIN impuestos AS im ON ii.id_impuesto = im.id_impuesto " &
                        "WHERE ti.activo = '1' AND ii.activo = '1' AND ti.id_item = '" & id_item & "' AND ti.id_tmpPedidoITem = '" + id_tmpPedidoItem + "' " &
                        "AND it.esDescuento = '0' AND it.esMarkup = '0'"

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando
            'llenar el dataset
            da.FillSchema(dataset, SchemaType.Source, "tmppedidos_items") 'Para que pueda manejarme con los nombres de las tablas y no haga falta por id
            da.Fill(dataset, "tmppedidos_items")

            Dim tbl_tmppedidos_items As DataTable
            tbl_tmppedidos_items = dataset.Tables("tmppedidos_items")
            cerrardb()

            'Calculo cada uno de los impuestos, excepto el I.V.A. si es un presupuesto
            For Each fila As DataRow In dataset.Tables(0).Rows
                If add_pedido.chk_presupuesto.Checked Then
                    If InStr(LCase(Trim(fila("nombre"))), "iva") < 0 Then
                        totalImpuestos += fila("porcentaje")
                    End If
                Else
                    Select Case comprobanteSeleccionado.id_tipoComprobante
                        Case Is = 1, 2, 3, 6, 7, 8, 4, 5, 9, 10, 63, 64, 34, 35, 39, 40, 60, 61, 11, 12, 13, 15, 49, 51, 52, 53, 54, 99, 201, 202, 206, 207, 211, 212, 1011, 1012
                            If comprobanteSeleccionado.id_tipoComprobante = 99 Then
                                If add_pedido.chk_presupuesto.Checked Then
                                    If InStr(LCase(Trim(fila("nombre"))), "iva") < 0 Then
                                        totalImpuestos += fila("porcentaje")
                                    End If
                                Else
                                    totalImpuestos += fila("porcentaje")
                                End If
                            Else
                                'Select Case comprobanteSeleccionado.id_tipoComprobante
                                '    'A los comprobantes B no se les discriminan los impuestos
                                '    Case Is = 6, 7, 8, 9, 64, 40, 61, 49, 1012
                                '        If InStr(LCase(Trim(fila("nombre"))), "iva") < 0 Then
                                '            totalImpuestos += fila("porcentaje")
                                '        End If
                                '    Case Else
                                totalImpuestos += fila("porcentaje")
                                'End Select
                            End If
                            'totalImpuestos Then += fila("porcentaje")
                    End Select
                End If
            Next

            Return totalImpuestos
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Sub BorrarItemCargado(Optional ByVal id_tmpPedidoItem_seleccionado As Integer = -1, Optional ByVal esMarkup As Boolean = False)
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String = ""


        mytrans = CN.BeginTransaction()

        Try
            If id_tmpPedidoItem_seleccionado = -1 Then
                sqlstr = "DELETE FROM tmppedidos_items WHERE activo = '0'"
            Else
                'sqlstr = "DELETE tmppedidos_items WHERE id_tmpPedidoItem = '" + id_tmpPedidoItem_seleccionado.ToString + "'"
                If esMarkup Then
                    sqlstr = "UPDATE tmppedidos_items SET activo = 0 WHERE id_Item = '" + id_tmpPedidoItem_seleccionado.ToString + "'"
                Else
                    sqlstr = "UPDATE tmppedidos_items SET activo = 0 WHERE id_tmpPedidoItem = '" + id_tmpPedidoItem_seleccionado.ToString + "'"
                End If

            End If

            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    Public Function PedidoAPedidoTmp(ByVal id_pedido As Integer, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO tmppedidos_items (id_pedidoItem, id_pedido, id_item, cantidad, precio, activo, descript, id_usuario, id_unico) " _
                               + "SELECT id_pedidoItem, id_pedido, id_item, cantidad, precio, activo, descript, '" + _idUsuario.ToString + "', '" + _idUnico + "' " _
                               + "FROM pedidos_items " _
                               + "WHERE id_pedido = '" + id_pedido.ToString + "'"
            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function PrecioOriginalPedido(ByVal id_pedido As Integer) As Double
        Dim sqlstr As String
        Dim subtotal As Double
        Dim comando As New SqlCommand

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT ti.id_tmpPedidoItem, ti.id_item, ti.cantidad, ti.precio, ti.activo, i.esDescuento, i.esMarkup, i.factor " &
                        "FROM tmppedidos_items AS ti " &
                        "INNER JOIN items AS i ON ti.id_item = i.id_item"


            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando
            'llenar el dataset
            da.FillSchema(dataset, SchemaType.Source, "tmppedidos_items") 'Para que pueda manejarme con los nombres de las tablas y no haga falta por id
            da.Fill(dataset, "tmppedidos_items")

            Dim tbl_tmppedidos_items As DataTable
            tbl_tmppedidos_items = dataset.Tables("tmppedidos_items")
            cerrardb()

            'Calculo el subtotal
            For Each fila As DataRow In dataset.Tables(0).Rows
                If Not fila("esDescuento") And Not fila("esMarkup") And fila("activo") Then subtotal = subtotal + (fila("cantidad") * fila("precio"))
            Next
            Return subtotal
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function IdItemMarkupPedido(ByVal id_pedido As Integer) As Integer
        Dim id_item As Integer
        Dim sqlstr As String
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                sqlstr = "SELECT i.id_item " &
                            "FROM pedidos_items AS p " &
                            "INNER JOIN items AS i ON p.id_item = i.id_item " &
                            "WHERE i.esMarkup = '1' AND p.id_pedido = '" + id_pedido.ToString + "' "
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString

            Return id_item
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function Ultima_CC_Pedido_Cliente(ByVal id_cliente As Integer) As Integer
        Dim id_cc As Integer
        Dim sqlstr As String

        id_cc = -1

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                sqlstr = "SELECT TOP 1 id_cc FROM pedidos WHERE id_cliente = '" + id_cliente.ToString + "' ORDER BY id_pedido DESC"

                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            id_cc = dataset.Tables("tabla").Rows(0).Item(0).ToString

            Return id_cc
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            Return id_cc
        Finally
            cerrardb()
        End Try
    End Function

    Public Function Info_Ultimo_Presupuesto() As Integer
        Dim nMaxPresupuesto As Integer = -1
        Dim sqlstr As String
        Dim n As Integer = 0

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                sqlstr = "SELECT MAX(idPresupuesto) FROM pedidos"

                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            nMaxPresupuesto = dataset.Tables("tabla").Rows(0).Item(0)
            Return nMaxPresupuesto
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            Return nMaxPresupuesto
        Finally
            cerrardb()
        End Try
    End Function
    ' ************************************ FUNCIONES DE PEDIDOS ***************************
End Module
