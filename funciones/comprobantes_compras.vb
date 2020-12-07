Imports System.Data.SqlClient

Module comprobantes_compras
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
                    .AddWithValue("id_sysComprobanteCompra", cc.id_sysComprobanteCompra)
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
                    .AddWithValue("id_sysComprobanteCompra", cc.id_sysComprobanteCompra)
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
        'Los comprobantes de compra activos significa que quedaron a mitad de camino, sin guardarse, y por ende deben ser borrados
        'Si se pasa un número de comprobante en vez de borrarse los que están activos, borra los asociados al número de comprobante,
        'por ejemplo, cuando se está cerrando la ventana de carga de comprobantes de compra sin guardar
        If id_comprobante_compra = -1 Then
            'Lo grisado fué reemplazado por el trigger borrar_asociaciones_comprobantes_compras
            'ejecutarSQL("DELETE FROM comprobantes_compras_items WHERE activo = '1'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_impuestos WHERE activo = '1'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_conceptos WHERE activo = '1'")
            ejecutarSQL("DELETE FROM comprobantes_compras WHERE activo = '1'")
        Else
            'ejecutarSQL("DELETE FROM comprobantes_compras_items WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_impuestos WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'")
            'ejecutarSQL("DELETE FROM comprobantes_compras_conceptos WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'")
            'Lo grisado fué reemplazado por el trigger borrar_asociaciones_comprobantes_compras
            ejecutarSQL("DELETE FROM comprobantes_compras WHERE id_comprobanteCompra = '" + id_comprobante_compra.ToString + "'")
        End If
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
