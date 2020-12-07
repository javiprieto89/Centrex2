
Imports System.Data.SqlClient
Module conceptos_compra

    ' ************************************ FUNCIONES DE CONCEPTOS DE COMPRA **********************
    Public Function info_concepto_compra(ByVal id_concepto As String) As concepto_compra
        Dim tmp As New concepto_compra
        Dim sqlstr As String

        Try
            sqlstr = "SELECT id_concepto_compra, concepto, activo " +
                    "FROM conceptos_compra " +
                    "WHERE id_concepto_compra = '" + id_concepto.ToString + "'"

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
            tmp.id_concepto_compra = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.concepto = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.concepto = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addConcepto_compra(ByVal concepto As concepto_compra) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO conceptos_compra (concepto, activo) VALUES ('" +
                        concepto.concepto + "', '" + concepto.activo.ToString + "')"
            Comando = New SqlCommand(sqlstr, CN)

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

    Public Function updateConcepto_compra(ByVal concepto As concepto_compra, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE conceptos_compra SET activo = '0' WHERE id_concepto_compra = '" + concepto.id_concepto_compra.ToString + "'"
            Else
                sqlstr = "UPDATE conceptos_compra SET concepto = '" + concepto.concepto + "', activo = '" + concepto.activo.ToString +
                            "' WHERE id_concepto_compra = '" + concepto.id_concepto_compra.ToString + "'"
            End If
            Comando = New SqlCommand(sqlstr, CN)

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

    Public Function borrarConcepto_compra(ByVal concepto As concepto_compra) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM conceptos_compra WHERE id_concepto_compra = '" + concepto.id_concepto_compra.ToString + "'"
            Comando = New SqlCommand(sqlstr, CN)
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
    ' ************************************ FUNCIONES DE CONCEPTOS COMPRA **********************
End Module
