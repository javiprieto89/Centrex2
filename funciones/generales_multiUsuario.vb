Imports System.Data.SqlClient

Module generales_multiUsuario

    Public Function borrar_tabla_pedidos_temporales(ByVal idUsuario As Integer, ByVal idUnico As String) As Byte
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE tmppedidos_items WHERE id_usuario = '" + idUsuario.ToString + "' AND id_unico = '" + idUnico + "'"
            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function borrar_tabla_pedidos_temporales(ByVal idUsuario As String) As Byte
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE tmppedidos_items WHERE id_usuario = '" + idUsuario + "'"
            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function Borrar_tabla_segun_usuario(ByVal tbl As String, ByVal id_usuario As Integer) As Byte
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            'sqlstr = "DELETE FROM " + tbl + "; DBCC CHECKIDENT ('" + basedb + ".dbo." + tbl + "',RESEED, 0)"
            sqlstr = "DELETE FROM " + tbl + " WHERE id_usuario = '" + id_usuario.ToString + "'; DBCC CHECKIDENT ('" + tbl + "',RESEED, 0)"

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

    Public Sub borrarTmpProduccion(ByVal id_usuario As Integer)
        Borrar_tabla_segun_usuario("tmpproduccion_asocItems", id_usuario)
        Borrar_tabla_segun_usuario("tmpproduccion_items", id_usuario)
    End Sub

    Public Function Generar_ID_Unico() As String
        Dim idUnico As String

        idUnico = ejecutarSQLconResultado("SELECT CONVERT(NVARCHAR(100), NEWID())")

        Return idUnico
    End Function
End Module
