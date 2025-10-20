Imports System.Data.SqlClient
Imports System.Data.Entity
Imports System.Linq

Module transacciones
    Public Function InfoTransaccion(Optional ByVal id_transaccion As String = "") As transaccion
        Dim tmp As New transaccion
        Dim sqlstr As String
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text

                sqlstr = "SET DATEFORMAT dmy; SELECT id_transaccion, CONVERT(NVARCHAR(20), fecha, 3), id_pedido, ISNULL(id_comprobanteCompra, -1), " &
                            "ISNULL(id_cobro, -1), ISNULL(id_pago, -1), id_tipoComprobante, numeroComprobante, puntoVenta, total, id_cc, " &
                            "ISNULL(id_cliente, -1), ISNULL(id_proveedor, -1) " &
                            "FROM transacciones " &
                            "WHERE id_transaccion = '" + id_transaccion + "'"
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")

            tmp.id_transaccion = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_pedido = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.id_comprobanteCompra = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.id_cobro = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.id_pago = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_tipoComprobante = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.numeroComprobante = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.puntoVenta = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.id_cc = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(12).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            'tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function Agregar_Transaccion_Desde_Pedido(ByVal t As transaccion) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO transacciones (fecha, id_pedido, id_tipoComprobante, numeroComprobante, puntoVenta, total, id_cc, id_cliente) " _
                                            + "VALUES ('" + t.fecha + "', '" + t.id_pedido.ToString + "', '" + t.id_tipoComprobante.ToString + "', '" + t.numeroComprobante.ToString + "', '" _
                                            + t.puntoVenta.ToString + "', '" + t.total.ToString + "', '" + t.id_cc.ToString + "', '" + t.id_cliente.ToString + "')"
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

    Public Function Agregar_Transaccion_Desde_Comprobante_Compra(ByVal t As transaccion) As Boolean
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO transacciones (fecha, id_comprobanteCompra, id_tipoComprobante, numeroComprobante, puntoVenta, total, id_cc, id_proveedor) " _
                                            + "VALUES ('" + t.fecha + "', '" + t.id_comprobanteCompra.ToString + "', '" + t.id_tipoComprobante.ToString + "', '" + t.numeroComprobante.ToString + "', '" _
                                            + t.puntoVenta.ToString + "', '" + t.total.ToString + "', '" + t.id_cc.ToString + "', '" + t.id_proveedor.ToString + "')"
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
End Module
