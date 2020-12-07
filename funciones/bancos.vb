
Imports System.Data
    Imports System.Data.SqlClient

Module bancos
    ' ************************************ FUNCIONES DE BANCOS ***************************
    Public Function info_banco(ByVal id_banco As String) As banco
        Dim tmp As New banco
        Dim sqlstr As String

        If id_banco = "" Then
            sqlstr = "SELECT id_banco, nombre, id_pais, n_banco, activo FROM bancos"
        Else
            sqlstr = "SELECT id_banco, nombre, id_pais, n_banco, activo FROM bancos WHERE id_banco = " + id_banco
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
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_banco = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_pais = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.n_banco = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addbanco(ByVal b As banco) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            With b
                sqlstr = "INSERT INTO bancos (nombre, id_pais, n_banco, activo) " &
                            "VALUES ('" + .nombre + "', '" + .id_pais.ToString + "', '" + .n_banco.ToString + "', '" + .activo.ToString + "')"
            End With

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

    Public Function updatebanco(ByVal b As banco, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE bancos SET activo = '0' WHERE id_banco = '" + b.id_banco.ToString + "'"
            Else
                With b
                    sqlstr = "UPDATE bancos SET nombre = '" + .nombre + "', id_pais = '" + .id_pais.ToString + "', n_banco = '" + .n_banco.ToString + "', " &
                        "activo = '" + .activo.ToString + "' " &
                        "WHERE id_banco = " + b.id_banco.ToString
                End With
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

    Public Function borrarbanco(ByVal b As banco) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM bancos WHERE id_banco = '" + b.id_banco.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE BANCOS ***************************
End Module

