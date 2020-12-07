Imports System.Data.SqlClient

Module tipositems
    ' ************************************ FUNCIONES DE TIPOS DE ITEMS ***********************
    Public Function info_tipoitem(ByVal id_tipo) As tipoitem
        Dim tmp As New tipoitem
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM tipos_items WHERE id_tipo = '" + id_tipo.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_tipo = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.tipo = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.tipo = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addtipoitem(titem As tipoitem) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("INSERT INTO tipos_items (tipo, activo) VALUES ('" + titem.tipo + "', '" + titem.activo.ToString + "')", CN)

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

    Public Function updatetipoitem(titem As tipoitem, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                Comando = New SqlClient.SqlCommand("UPDATE tipos_items SET activo = '0' WHERE id_tipo = '" + titem.id_tipo.ToString + "'", CN)
            Else
                Comando = New SqlClient.SqlCommand("UPDATE tipos_items SET tipo = '" + titem.tipo + "', activo = '" + titem.activo.ToString + _
                                               "' WHERE id_tipo = '" + titem.id_tipo.ToString + "'", CN)
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

    Public Function borrartipoitem(titem As tipoitem) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM tipos_items WHERE id_tipo = '" + titem.id_tipo.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE TIPOS DE ITEMS ***********************
End Module
