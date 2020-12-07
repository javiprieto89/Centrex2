Imports System.Data.SqlClient

Module marcasitems

    ' ************************************ FUNCIONES DE MARCAS DE ITEMS **********************
    Public Function info_marcai(ByVal id_marca) As marca_item
        Dim tmp As New marca_item
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM marcas_items WHERE id_marca = '" + id_marca.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_marca = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.marca = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.marca = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addmarcai(marcai As marca_item) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("INSERT INTO marcas_items (marca, activo) VALUES ('" + marcai.marca + "', '" + marcai.activo.ToString + "')", CN)

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

    Public Function updatemarcai(marcai As marca_item, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                Comando = New SqlClient.SqlCommand("UPDATE marcas_items SET activo = '0' WHERE id_marca = '" + marcai.id_marca.ToString + "'", CN)
            Else
                Comando = New SqlClient.SqlCommand("UPDATE marcas_items SET marca = '" + marcai.marca + "', activo = '" + marcai.activo.ToString + _
                                               "' WHERE id_marca = '" + marcai.id_marca.ToString + "'", CN)
            End If

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

    Public Function borrarmarcai(marcai As marca_item) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM marcas_items WHERE id_marca = '" + marcai.id_marca.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE MARCAS DE ITEMS **********************
End Module
