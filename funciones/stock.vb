Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Entity
Imports System.Linq

Module stock
    ' ************************************ FUNCIONES DE STOCK ***************************
    Public Function InfoRegistroStock(ByVal id_rs As Integer) As registro_stock
        Dim tmp As New registro_stock
        Dim sqlstr As String

        sqlstr = "SELECT * FROM registros_stock WHERE id_registro = '" + id_rs.ToString + "'"
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
            tmp.id_registro = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_ingreso = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha_ingreso = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.factura = dataset.Tables("tabla").Rows(0).Item(4).ToString
            'tmp.archivofc = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.costo = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.precio_lista = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.factor = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.cantidad_anterior = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.costo_anterior = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.precio_lista_anterior = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.factor_anterior = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.nota = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(17).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function InfoRegistroStockTmp(ByVal id_rs As Integer) As registro_stock
        Dim tmp As New registro_stock
        Dim sqlstr As String

        sqlstr = "SELECT * FROM tmpregistros_stock WHERE id_registrotmp = '" + id_rs.ToString + "'"
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
            tmp.id_registro = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_ingreso = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha_ingreso = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.factura = dataset.Tables("tabla").Rows(0).Item(4).ToString
            'tmp.archivofc = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.costo = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.precio_lista = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.factor = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.cantidad_anterior = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.costo_anterior = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.precio_lista_anterior = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.factor_anterior = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.nota = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(17).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function AddStockTmp(ByVal rs As registro_stock) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO tmpregistros_stock (fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, factor, cantidad_anterior, " & _
                "costo_anterior, precio_lista_anterior, factor_anterior, nota) " & _
                "VALUES ('" + rs.fecha.ToString + "', '" + rs.factura.ToString + "', '" + rs.id_proveedor.ToString + "', '" + rs.id_item.ToString + "', '" + rs.cantidad.ToString + "', '" + rs.costo.ToString + "', '" & _
                rs.precio_lista.ToString + "', '" + rs.factor.ToString + "', '" + rs.cantidad_anterior.ToString + "', '" + rs.costo_anterior.ToString + "', '" & _
                rs.precio_lista_anterior.ToString + "', '" + rs.factor_anterior.ToString + "', '" + rs.nota + "')"

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

    Public Function UpdateStockTmp(ByVal rs As registro_stock) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        sqlstr = "SET DATEFORMAT dmy; UPDATE tmpregistros_stock SET fecha = '" + rs.fecha.ToString + "', factura = '" + rs.factura.ToString + "', id_proveedor = '" + rs.id_proveedor.ToString + "', " & _
                "id_item = '" + rs.id_item.ToString + "', cantidad = '" + rs.cantidad.ToString + "', costo = '" + rs.costo.ToString + "', precio_lista = '" + rs.precio_lista.ToString + "', " & _
                "factor = '" + rs.factor.ToString + "', nota = '" + rs.nota + "' " & _
                "WHERE id_registrotmp = '" + rs.id_registro.ToString + "'"

        Try
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

    Public Function AddStock() As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO registros_stock (id_ingreso, fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, factor, " & _
                        "cantidad_anterior, costo_anterior, precio_lista_anterior, factor_anterior, nota) " & _
                        "SELECT id_ingreso, fecha, factura, id_proveedor, id_item, cantidad, costo, precio_lista, factor, cantidad_anterior, " & _
                        "costo_anterior, precio_lista_anterior, factor_anterior, nota " & _
                        "FROM tmpregistros_stock"

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

    Public Function BorrarItemRegistroStockTmp(rs As registro_stock) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM tmpregistros_stock WHERE id_registrotmp = '" + rs.id_registro.ToString + "'", CN) With {.Transaction = mytrans}
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

    Public Sub ArchivarIngresoStock()
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE registros_stock " & _
                        "SET activo = 0 " & _
                        "WHERE fecha_ingreso <> CONVERT (date, SYSDATETIME())"

            Comando = New SqlClient.SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
        End Try
    End Sub
    ' ************************************ FUNCIONES DE STOCK ***************************
End Module
