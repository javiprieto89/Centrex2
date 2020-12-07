Imports System.Data.SqlClient

Module asocitems
    ' ************************************ FUNCIONES DE ITEMS ASOCIADOS ***************************
    Public Function info_asocItem(ByVal id_item As String, ByVal id_asocItem As String) As asocItem
        Dim tmp As New asocItem
        Dim sqlstr As String = "SELECT * FROM asocItems WHERE id_item = '" + id_item + "' AND id_item_asoc = '" + id_asocItem + "'"
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
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_item_asoc = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_item = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addAsocItem(it As asocItem) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO asocItems (id_item, id_item_asoc, cantidad) VALUES " &
                                                   "('" + it.id_item.ToString + "', '" + it.id_item_asoc.ToString + "', '" + it.cantidad.ToString + "')"


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

    Public Function updateAsocItem(it As asocItem, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE asocItems SET id_item = '" + it.id_item.ToString + "', id_item_asoc = '" + it.id_item_asoc.ToString + "', cantidad = '" + it.cantidad.ToString + "' " &
                        "WHERE id_item = '" + it.id_item.ToString + "'"

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

    Public Function borrarAsocItem(it As asocItem) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM asocITems WHERE id_item = '" + it.id_item.ToString + "' AND id_item_asoc = '" + it.id_item_asoc.ToString + "'"
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

    Public Function Tiene_Items_Asociados(ByVal id_item As String) As Boolean
        Dim c As Integer
        Dim sqlstr As String = "SELECT COUNT(id_item) FROM asocItems WHERE id_item = '" + id_item + "'"
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
            c = dataset.Tables("tabla").Rows(0).Item(0)
            If c > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    Public Function Traer_Cantidades_Enviadas_Items_Asociados_Default_Produccion(ByVal id_item As String, Optional ByVal id_produccion As Integer = -1) As DataTable
        Dim sqlstr As String

        'sqlstr = "SELECT i.item AS 'Producto', tpi.cantidad AS 'Cantidad', ii.descript AS 'Producto asociado', ai.cantidad * tpi.cantidad  AS 'Cantidad enviada', " &
        '        "tpi.id_tmpProduccionItem AS 'id_tmpProduccionItem', ai.id_item AS 'id_item', ai.id_item_asoc AS 'id_item_asoc' " &
        '        "FROM asocItems AS ai " &
        '        "INNER JOIN tmpproduccion_items AS tpi ON ai.id_item = tpi.id_item " &
        '        "INNER JOIN items AS i ON ai.id_item = i.id_item " &
        '        "INNER JOIN items AS ii ON ai.id_item_asoc = ii.id_item " &
        '        "WHERE ai.id_item = '" + id_item + "'"


        If id_produccion = -1 Then
            sqlstr = "SELECT i.item AS 'Producto', tpi.cantidad AS 'Cantidad', ii.descript AS 'Producto asociado', ai.cantidad * tpi.cantidad  AS 'Cantidad enviada', " &
                    "tpi.id_tmpProduccionItem AS 'id_tmpProduccionItem', ai.id_item AS 'id_item', ai.id_item_asoc AS 'id_item_asoc' " &
                    "FROM asocItems AS ai " &
                    "INNER JOIN tmpproduccion_items AS tpi ON ai.id_item = tpi.id_item " &
                    "INNER JOIN items AS i ON ai.id_item = i.id_item " &
                    "INNER JOIN items AS ii ON ai.id_item_asoc = ii.id_item " &
                    "WHERE ai.id_item = '" + id_item + "'"
        Else
            sqlstr = "SELECT DISTINCT i.item AS 'Producto', pi.cantidad AS 'Cantidad', ii.descript AS 'Producto asociado', pai.cantidad_item_asoc_enviada  AS 'Cantidad enviada', " &
                    "pai.id_item AS 'id_item', pai.id_item_asoc AS 'id_item_asoc' " &
                    "FROM produccion_asocItems AS pai " &
                    "INNER JOIN produccion_items AS pi ON pai.id_item = pi.id_item " &
                    "INNER JOIN items AS i ON pai.id_item = i.id_item " &
                    "INNER JOIN items AS ii ON pai.id_item_asoc = ii.id_item " &
                    "WHERE pai.id_item = '" + id_item + "' AND pai.id_produccion = '" + id_produccion.ToString + "'"
        End If
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
            Dim dt As New DataTable 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return Nothing
        Finally
            cerrardb()
        End Try
    End Function
End Module
