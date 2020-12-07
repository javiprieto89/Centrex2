Imports System.Data.SqlClient

Module ccClientes

    ' ************************************ FUNCIONES DE CUENTAS CORRIENTES DE CLIENTES **********************
    Public Function info_ccCliente(ByVal id_cc As Integer) As ccCliente
        Dim tmp As New ccCliente
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT * FROM cc_clientes WHERE id_cc = '" + id_cc.ToString + "'"

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
            tmp.id_cc = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_moneda = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.saldo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(5).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addCCCliente(ByVal cc As ccCliente) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO cc_clientes (id_cliente, id_moneda, nombre, saldo, activo) VALUES ('" + cc.id_cliente.ToString + "', '" + cc.id_moneda.ToString + "', '" + cc.nombre + "', '" + cc.saldo.ToString + "', '" + cc.activo.ToString + "')"
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

    Public Function updateCCCliente(ByVal cc As ccCliente, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE cc_clientes SET activo = '0' WHERE id_cc = '" + cc.id_cc.ToString + "'"
            Else
                sqlstr = "UPDATE cc_clientes SET id_cliente = '" + cc.id_cliente.ToString + "', id_moneda = '" + cc.id_moneda.ToString + "', nombre = '" + cc.nombre + "', saldo = '" + cc.saldo.ToString + "', activo = '" + cc.activo.ToString +
                                               "' WHERE id_cc = '" + cc.id_cc.ToString + "'"
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

    Public Function borrarccCliente(ByVal cc As ccCliente) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM cc_clientes WHERE id_cc = '" + cc.id_cc.ToString + "'"
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

    Public Function consultaCcCliente(ByVal id_cliente As Integer, ByVal id_Cc As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, ByVal tipoDoc As Integer) As DataTable
        Dim sqlstr As String
        Dim where As String = ""
        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
        Dim dt As New DataTable 'Crear nuevo dataset
        Dim comando As New SqlCommand

        Try
            'Select Case tipoDoc
            '    Case 0 'Documentos contables
            '        where += " AND c.id_tipoComprobante IN (1, 2, 3, 4, 6, 7, 8, 9, 11, 12, 13, 15, 51, 52, 53, 54, 200, 201) AND c.testing = 0"
            '    Case 1 'Presupuestos
            '        where += "AND c.esPresupuesto = 1"
            '    Case 2 'Documentos de prueba
            '        where += "AND c.testing = 1"
            '    Case 3 'Remitos
            '        where += "AND c.id_tipoComprobante = 199"
            '    Case 4 'Todos
            'End Select

            'sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.comprobante AS 'Comprobante', CONCAT('$ ', p.total) AS 'Total' " &
            '            "FROM pedidos As p " &
            '            "INNER JOIN comprobantes AS c ON p.id_comprobante = c.id_comprobante " &
            '            "WHERE p.fecha BETWEEN '" + fecha_desde.ToString("MM/dd/yyyy") + "' AND '" + fecha_hasta.ToString("MM/dd/yyyy") + "' " &
            '            "AND p.id_cliente = " + id_cliente.ToString + " AND c.activo = 1 " &
            '            "AND p.activo = '0' AND p.cerrado = '1' "

            'sqlstr = "" & vbc

            'sqlstr += where

            sqlstr = "DECLARE @id_cliente INTEGER; " & vbCr &
            "DECLARE @fecha_inicio DATE; " & vbCr &
            "DECLARE @fecha_fin DATE; " & vbCr &
            "DECLARE @id_cc AS INTEGER; " & vbCr &
            " " & vbCr &
            "SET @id_cliente = '" & id_cliente.ToString & "'; " & vbCr &
            "SET @fecha_inicio = '" & fecha_desde.ToString("MM/dd/yyyy") & "'; " & vbCr &
            "SET @fecha_fin =  '" & fecha_hasta.ToString("MM/dd/yyyy") & "'; " & vbCr &
            "SET @id_cc = '" & id_Cc.ToString & "'; " & vbCr &
            " " & vbCr &
            "WITH tbl " & vbCr &
            "AS (SELECT t.id_pedido, " & vbCr &
                    "t.id_cliente, " & vbCr &
                    "t.numeroComprobante, " & vbCr &
                    "t.puntoVenta, " & vbCr &
                    "cmp.id_tipoComprobante, " & vbCr &
                    "t.fecha, " & vbCr &
                    "(CASE WHEN cmp.id_tipoComprobante IN (1, 2, 6, 7, 11, 12, 51, 52, 200) THEN T.total ELSE 0 END) AS 'debito', " & vbCr &
                    "(CASE WHEN cmp.id_tipoComprobante IN (3, 4, 8, 9, 13, 15, 53, 54, 201) THEN T.total*-1 ELSE 0 END) AS 'credito', " & vbCr &
                    "(CASE WHEN cmp.id_tipoComprobante IN (1, 2, 6, 7, 11, 12, 51, 52, 200) THEN T.total " & vbCr &
                        "WHEN cmp.id_tipoComprobante IN (3, 4, 8, 9, 13, 15, 53, 54, 201) THEN T.TOTAL * -1 ELSE 0 END) AS 'total', " & vbCr &
                    "t.activo, " & vbCr &
                    "t.cerrado, " & vbCr &
                    "t.esTest, " & vbCr &
                    "t.esPresupuesto, " & vbCr &
                    "t.id_cc " & vbCr &
                    "FROM pedidos As t " & vbCr &
                    "INNER JOIN comprobantes AS cmp ON t.id_comprobante = cmp.id_comprobante " & vbCr &
                    "INNER JOIN tipos_comprobantes AS tc ON cmp.id_tipoComprobante = tc.id_tipoComprobante " & vbCr &
                    "WHERE t.id_cliente = @id_cliente AND t.id_cc = @id_cc AND t.fecha BETWEEN @fecha_inicio AND @fecha_fin AND t.activo = 0 AND t.cerrado = 1 AND t.esTest = 0 AND t.esPresupuesto = 0 " & vbCr &
                    "AND cmp.id_tipoComprobante IN (1, 2, 3, 4, 6, 7, 8, 9, 11 ,12, 13, 15, 51, 52, 53, 54, 200, 201)	" & vbCr &
                ") " & vbCr &
            "SELECT " & vbCr &
                "tbl.id_pedido AS 'ID', " & vbCr &
                "tbl.fecha AS 'Fecha', " & vbCr &
                "ccc.nombre AS 'Cuenta corriente', " & vbCr &
                "dbo.CalculoComprobante(tbl.id_tipoComprobante, tbl.puntoVenta, tbl.numeroComprobante) AS 'Comprobante', " & vbCr &
                "tbl.debito AS 'Débito', " & vbCr &
                "tbl.credito AS 'Crédito', " & vbCr &
                "SUM(tbl.TOTAL) OVER (PARTITION BY tbl.id_cc " & vbCr &
                "--ORDER BY tbl.fecha, tbl.numeroComprobante, tbl.id_pedido, tbl.id_cc ROWS UNBOUNDED PRECEDING ) AS 'Saldo' " & vbCr &
                "ORDER BY tbl.numeroComprobante ROWS UNBOUNDED PRECEDING ) AS 'Saldo' " & vbCr &
                "FROM tbl " & vbCr &
                "INNER JOIN cc_clientes AS ccc ON tbl.id_cc = ccc.id_cc " & vbCr &
                "WHERE tbl.id_cliente = @id_cliente AND tbl.id_cc = @id_cc AND tbl.fecha BETWEEN @fecha_inicio AND @fecha_fin AND tbl.activo = 0 AND tbl.cerrado = 1 AND tbl.esTest = 0 AND tbl.esPresupuesto = 0 " & vbCr &
                "AND tbl.id_tipoComprobante IN (1, 2, 3, 4, 6, 7, 8, 9, 11, 12, 13, 15, 51, 52, 53, 54, 200, 201) " & vbCr &
                "ORDER BY tbl.numeroComprobante ASC "

            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return dt
        Finally
            cerrardb()
        End Try
    End Function

    Public Function consultaTotalCcCliente(ByVal id_cliente As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, ByVal tipoDoc As Integer) As String
        Dim sqlstr As String
        Dim where As String = ""
        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
        Dim dt As New DataTable 'Crear nuevo dataset

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            Select Case tipoDoc
                Case 0 'Documentos contables
                    where += " AND c.id_tipoComprobante IN (1, 2, 3, 6, 7, 8, 4, 5, 9, 10, 63,64, 34, 35, 39, 40, 60, 61, 11, 12, 13, 15, 49, 51, 52, 53, 54) AND c.testing = 0"
                Case 1 'Presupuestos
                    where += "AND c.esPresupuesto = 1"
                Case 2 'Documentos de prueba
                    where += "AND c.testing = 1"
                Case 3 'Remitos
                    where += "AND c.id_tipoComprobante = 199"
                Case 4 'Todos
            End Select

            sqlstr = "SELECT SUM(p.total) AS 'Total' " &
                        "FROM pedidos As p " &
                        "INNER JOIN comprobantes AS c ON p.id_comprobante = c.id_comprobante " &
                        "WHERE p.fecha BETWEEN '" + fecha_desde.ToString("MM/dd/yyyy") + "' AND '" + fecha_hasta.ToString("MM/dd/yyyy") + "' " &
                        "AND p.id_cliente = " + id_cliente.ToString + " AND c.activo = 1 " &
                        "AND p.activo = '0' AND p.cerrado = '1' "

            sqlstr += where


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dt)
            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return ""
        Finally
            cerrardb()
        End Try
    End Function
    ' ************************************ FUNCIONES DE CUENTAS CORRIENTES DE CLIENTES **********************
End Module

