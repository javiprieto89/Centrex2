Imports System.Data.SqlClient
Module perfiles
    ' ************************************ FUNCIONES DE PERFILES ********************
    Public Function info_perfil(ByVal id_perfil As String) As perfil
        Dim tmp As New perfil
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT * FROM perfiles WHERE id_perfil = '" + id_perfil + "'"

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
            tmp.id_perfil = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addperfil(ByVal p As perfil) As Boolean
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        abrirdb(serversql, basedb, usuariodb, passdb)

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO perfiles (nombre, activo) VALUES ('" + p.nombre + "', '" + p.activo.ToString + "')"
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

    Public Function updateperfil(ByVal p As perfil, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE perfiles SET activo = '0' WHERE id_perfil = '" + p.id_perfil.ToString + "'"
            Else
                sqlstr = "UPDATE perfiles SET nombre = '" + p.nombre + "', activo = '" + p.activo.ToString + "' " +
                                               "WHERE id_perfil = '" + p.id_perfil.ToString + "'"
            End If

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

    Public Function borrarperfil(ByVal p As perfil) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM perfiles WHERE id_perfil = '" + p.id_perfil.ToString + "'"

            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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
    ' ************************************ FUNCIONES DE PERFILES ********************
End Module
