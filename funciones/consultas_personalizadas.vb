Imports System.Data.SqlClient

Module consultas
    ' ************************************ FUNCIONES DE CONSULTAS PERSONALIZADAS **********************
    Public Function info_consulta(ByVal id_consulta As Integer) As consultaP
        Dim tmp As New consultaP
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT c.id_consulta, c.nombre, c.consulta, c.activo FROM consultas_personalizadas AS c WHERE c.id_consulta = '" + id_consulta.ToString + "'"

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
            tmp.id_consulta = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.consulta = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addConsulta(ByVal c As consultaP) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO consultas_personalizadas " &
                    "(" &
                        "nombre, " &
                        "consulta, " &
                        "activo" &
                    ") " &
                    "VALUES " &
                    "(" &
                        "@nombre, " &
                        "@consulta, " &
                        "@activo" &
                    ")"

            Comando = New SqlClient.SqlCommand(sqlstr, CN)
            With Comando
                With .Parameters
                    .Clear()
                    .AddWithValue("@nombre", c.nombre)
                    .AddWithValue("@consulta", c.consulta)
                    .AddWithValue("@activo", c.activo.ToString)
                End With
                .Transaction = mytrans
                .ExecuteNonQuery()
            End With

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function updateConsulta(ByVal c As consultaP, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE consultas_personalizadas SET activo = '0' WHERE id_consulta = '" + c.id_consulta.ToString + "'"
            Else
                sqlstr = "UPDATE consultas_personalizadas SET nombre = @nombre, consulta = @consulta, activo = @activo  " &
                        " WHERE id_consulta = '" + c.id_consulta.ToString + "'"
            End If
            Comando = New SqlClient.SqlCommand(sqlstr, CN)
            With Comando
                With .Parameters
                    .Clear()
                    .AddWithValue("@nombre", c.nombre)
                    .AddWithValue("@consulta", c.consulta)
                    .AddWithValue("@activo", c.activo.ToString)
                End With
                .Transaction = mytrans
                .ExecuteNonQuery()
            End With

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function borrarConsulta(ByVal c As consultaP) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM consultas_personalizadas WHERE id_consulta = '" + c.id_consulta.ToString + "'"
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
    ' ************************************ FUNCIONES DE CONSULTAS PERSONALIZADAS **********************
End Module