Imports System.Data.SqlClient

Module ajustes_stock
    ' ************************************ FUNCIONES DE RELACION ITEMS E IMPUESTOS ********************
    Public Function info_ajuste_stock(ByVal id_ajusteStock As String) As ajusteStock
        Dim tmp As New ajusteStock
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            sqlstr = "SELECT id_ajusteStock, fecha, id_item, cantidad, notas FROM ajustes_stock WHERE id_ajusteStock = '" + id_ajusteStock + "' "

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
            tmp.id_ajusteStock = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function add_ajusteStock(ByVal _as As ajusteStock) As Boolean
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        abrirdb(serversql, basedb, usuariodb, passdb)

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; INSERT INTO ajustes_stock (fecha, id_item, cantidad, notas) VALUES ('" + _as.fecha + "', '" + _as.id_item.ToString + "', '" + _as.cantidad.ToString +
                        "', '" + _as.notas + "')"

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

    'Public Function update_ajuste_stock(ByVal iiViejo As itemImpuesto, Optional ByVal iiNuevo As itemImpuesto = Nothing, Optional borra As Boolean = False) As Boolean
    '    abrirdb(serversql, basedb, usuariodb, passdb)

    '    Dim mytrans As SqlTransaction
    '    Dim Comando As New SqlClient.SqlCommand
    '    Dim sqlstr As String

    '    mytrans = CN.BeginTransaction()

    '    Try
    '        If borra = True Then
    '            sqlstr = "UPDATE items_impuestos SET activo = '0' WHERE id_item = '" + iiViejo.id_item.ToString + "', id_impuesto = '" + iiViejo.id_impuesto.ToString + "'"

    '        Else
    '            sqlstr = "UPDATE items_impuestos SET id_item = '" + iiNuevo.id_item.ToString + "', id_impuesto = '" + iiNuevo.id_impuesto.ToString + "', activo = '" + iiNuevo.activo.ToString _
    '                        + "' WHERE id_item = '" + iiViejo.id_item.ToString + "' AND id_impuesto = '" + iiViejo.id_impuesto.ToString + "'"
    '        End If
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

    'Public Function borrar_ajuste_stock(ByVal ii As itemImpuesto) As Boolean
    '    abrirdb(serversql, basedb, usuariodb, passdb)

    '    Dim mytrans As SqlTransaction
    '    Dim Comando As New SqlClient.SqlCommand
    '    Dim sqlstr As String

    '    mytrans = CN.BeginTransaction()

    '    Try
    '        sqlstr = "DELETE FROM items_impuestos WHERE id_item = '" + ii.id_item.ToString + "' AND id_impuesto = '" + ii.id_impuesto.ToString + "'"

    '        Comando = New SqlClient.SqlCommand(sqlstr, CN)
    '        Comando.Transaction = mytrans
    '        Comando.ExecuteNonQuery()

    '        mytrans.Commit()
    '        cerrardb()
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '        cerrardb()
    '        Return False
    '    End Try
    'End Function
    ' ************************************ FUNCIONES DE RELACION ITEMS E IMPUESTOS ********************
End Module


