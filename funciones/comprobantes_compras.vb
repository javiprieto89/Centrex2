Imports System.Data.SqlClient

Module comprobantes_compras
    Public Function info_comprobante_compra(ByVal id_comprobante_compra As String) As comprobante_compra
        Dim tmp As New comprobante_compra
        Dim sqlstr As String
        'cerrardb() 'temporal

        If id_comprobante_compra Is Nothing Then
            tmp.numeroComprobante = -1
            Return tmp
        End If

        sqlstr = "SET DATEFORMAT dmy; SELECT id_comprobanteCompra, CONVERT(NVARCHAR(20), fecha_carga, 3), CONVERT(NVARCHAR(20), fecha_comprobante, 3), id_tipoComprobante, " &
                                    "id_proveedor, id_cc, id_moneda, ISNULL(puntoVenta, 0), ISNULL(numeroComprobante, 0), id_condicion_compra, ISNULL(subtotal, 0), ISNULL(impuestos, 0), " &
                                    "ISNULL(conceptos, 0), ISNULL(total, 0), ISNULL(tasaCambio, 0), ISNULL(nota, ''), ISNULL(cae, 0), activo " &
                                    "FROM comprobantes_compras " &
                                    "WHERE id_comprobanteCompra = '" + id_comprobante_compra + "'"

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
            tmp.id_comprobanteCompra = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha_carga = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha_comprobante = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.id_tipoComprobante = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.id_cc = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_moneda = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.puntoVenta = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.numeroComprobante = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.id_condicion_compra = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.subtotal = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.impuestos = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.conceptos = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.tasaCambio = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.nota = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.cae = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(17).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.numeroComprobante = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function add_comprobante_compra(ByVal cc As comprobante_compra) As Integer
        Dim sqlComm As New SqlCommand 'Comando en el resto
        Dim resultado As Integer

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_insertComprobanteCompra"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("fecha_comprobante", cc.fecha_comprobante)
                    .AddWithValue("id_proveedor", cc.id_proveedor)
                    .AddWithValue("id_cc", cc.id_cc)
                    .AddWithValue("id_condicion_compra", cc.id_condicion_compra)
                    .AddWithValue("id_tipoComprobante", cc.id_tipoComprobante)
                    .AddWithValue("id_moneda", cc.id_moneda)
                    .AddWithValue("tasaCambio", cc.tasaCambio)
                    .AddWithValue("puntoVenta", cc.puntoVenta)
                    .AddWithValue("numeroComprobante", cc.numeroComprobante)
                    .AddWithValue("cae", cc.cae)
                    .Add(New SqlParameter("@resultado", SqlDbType.Int)).Direction = ParameterDirection.Output
                End With
                .Connection = CN
                .ExecuteNonQuery()
            End With

            resultado = CInt(sqlComm.Parameters("@resultado").Value)
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function update_comprobante_compra(ByVal cc As comprobante_compra) As Boolean
        Dim sqlComm As New SqlCommand 'Comando en el resto

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_updateComprobanteCompra"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("id_comprobanteCompra", cc.id_comprobanteCompra)
                    .AddWithValue("fecha_comprobante", cc.fecha_comprobante)
                    .AddWithValue("id_proveedor", cc.id_proveedor)
                    .AddWithValue("id_cc", cc.id_cc)
                    .AddWithValue("id_condicion_compra", cc.id_condicion_compra)
                    .AddWithValue("id_tipoComprobante", cc.id_tipoComprobante)
                    .AddWithValue("id_moneda", cc.id_moneda)
                    .AddWithValue("tasaCambio", cc.tasaCambio)
                    .AddWithValue("puntoVenta", cc.puntoVenta)
                    .AddWithValue("numeroComprobante", cc.numeroComprobante)
                    .AddWithValue("cae", cc.cae)
                End With
                .Connection = CN
                .ExecuteNonQuery()
            End With

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function cerrar_comprobante_compra(ByVal cc As comprobante_compra) As Boolean
        Dim sqlComm As New SqlCommand 'Comando en el resto

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_cerrarComprobanteCompra"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("id_comprobanteCompra", cc.id_comprobanteCompra)
                    .AddWithValue("subtotal", cc.subtotal)
                    .AddWithValue("impuestos", cc.impuestos)
                    .AddWithValue("conceptos", cc.conceptos)
                    .AddWithValue("total", cc.total)
                    .AddWithValue("nota", cc.nota)
                End With
                .Connection = CN
                .ExecuteNonQuery()
            End With

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    Public Function add_item_comprobanteCompra(ByVal id_comprobanteCompra As Integer, ByVal id_item As Integer, ByVal cantidad As Integer, ByVal precio As Double) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO comprobantes_compras_items (id_comprobanteCompra, id_item, cantidad, precio) VALUES ('" + id_comprobanteCompra.ToString + "' " &
                        ", '" + id_item.ToString + "', '" + cantidad.ToString + "', '" + precio.ToString + "')"
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

    Public Function add_impuesto_comprobanteCompra(ByVal id_comprobanteCompra As Integer, ByVal id_impuesto As Integer, ByVal importe As Double) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO comprobantes_compras_impuestos (id_comprobanteCompra, id_impuesto, importe) VALUES ('" + id_comprobanteCompra.ToString + "' " &
                        ", '" + id_impuesto.ToString + "', '" + importe.ToString + "')"
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

    Public Function add_concepto_comprobanteCompra(ByVal id_comprobanteCompra As Integer, ByVal id_concepto_compra As Integer, ByVal subtotal As Double,
                                                   ByVal iva As Double, ByVal total As Double) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO comprobantes_compras_conceptos (id_comprobanteCompra, id_concepto_compra, subtotal, iva, total) VALUES ('" + id_comprobanteCompra.ToString + "' " &
                        ", '" + id_concepto_compra.ToString + "', '" + subtotal.ToString + "', '" + iva.ToString + "', '" + total.ToString + "')"
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

    Public Sub borrar_comprobantes_compras_activos(Optional ByVal id_comprobante_compra As Integer = -1)
        Dim sqlstr As String

        'Los comprobantes de compra activos significa que quedaron a mitad de camino, sin guardarse, y por ende deben ser borrados
        'Si se pasa un número de comprobante en vez de borrarse los que están activos, borra los asociados al número de comprobante,
        'por ejemplo, cuando se está cerrando la ventana de carga de comprobantes de compra sin guardar
        If id_comprobante_compra = -1 Then
            'Lo grisado fué reemplazado por el trigger borrar_asociaciones_comprobantes_compras
            'ejecutarSQL("DELETE FROM comprobantes_compras_items WHERE activo = '1'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_impuestos WHERE activo = '1'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_conceptos WHERE activo = '1'")
            'sqlstr = "DELETE FROM comprobantes_compras WHERE activo = '1'"
            Exit Sub
        Else
            'ejecutarSQL("DELETE FROM comprobantes_compras_items WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_impuestos WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_conceptos WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'")
            'Lo grisado fué reemplazado por el trigger borrar_asociaciones_comprobantes_compras
            sqlstr = "DELETE FROM comprobantes_compras_conceptos WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "' " &
                            "DELETE FROM comprobantes_compras_impuestos WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "' " &
                            "DELETE FROM comprobantes_compras_items WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "' " &
                            "DELETE FROM comprobantes_compras WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'"
        End If
        ejecutarSQL(sqlstr)
    End Sub

    Public Function Ultima_CC_comprobante_compra_proveedor(ByVal id_proveedor As Integer) As Integer
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
                sqlstr = "SELECT TOP 1 id_cc FROM comprobantes_compras WHERE id_proveedor = '" + id_proveedor.ToString + "' ORDER BY id_comprobanteCompra DESC"

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
End Module
