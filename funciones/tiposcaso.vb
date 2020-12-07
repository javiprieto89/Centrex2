Imports System.Data.SqlClient

Module tipos_casos
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
    Public Function info_tipocaso(ByVal id_tipocaso As String) As tipo_caso
        Dim tmp As New tipo_caso
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM tipos_casos WHERE id_tipo = '" + id_tipocaso + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_tipocaso = dataset.Tables("tabla").Rows(0).Item(0).ToString
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

    Public Function addtipocaso(tc As tipo_caso) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("INSERT INTO tipos_casos (tipo, activo) VALUES ('" + tc.tipo + "', '" + tc.activo.ToString + "')", CN)

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

    Public Function updatetipocaso(tc As tipo_caso, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                Comando = New SqlClient.SqlCommand("UPDATE tipos_casos SET activo = '0' WHERE id_tipo = '" + tc.id_tipocaso.ToString + "'", CN)
            Else
                Comando = New SqlClient.SqlCommand("UPDATE tipos_casos SET tipo = '" + tc.tipo + "', activo = '" + tc.activo.ToString + _
                                               "' WHERE id_tipo = '" + tc.id_tipocaso.ToString + "'", CN)
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

    Public Function borrartipocaso(tc As tipo_caso) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM tipos_casos WHERE id_tipo = '" + tc.id_tipocaso.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE MARCAS DE AUTOS ********************
End Module
