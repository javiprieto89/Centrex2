Imports System.Data.SqlClient

Module cobros_retenciones
    ' ************************************ ' ************************************ FUNCIONES DE RETENCIONES EN COBROS *************************** ***************************
    Public Function info_cobroRetencion(ByVal id_retencion As String) As cobroRetencion
        Dim tmp As New cobroRetencion
        Dim sqlstr As String


        sqlstr = "SELECT id_retencion, id_cobro, id_impuesto, total, notas " &
                    "FROM cobros_retenciones " &
                    "WHERE id_retencion = '" + id_retencion + "'"

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
            tmp.id_retencion = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_cobro = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_impuesto = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_retencion = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function info_tmpCobroRetencion(ByVal id_retencion As String) As cobroRetencion
        Dim tmp As New cobroRetencion
        Dim sqlstr As String

        sqlstr = "SELECT id_retencion, id_cobro, id_impuesto, total, notas " &
                    "FROM tmpcobros_retenciones " &
                    "WHERE id_tmpRetencion = '" + id_retencion + "'"

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
            tmp.id_retencion = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_cobro = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_impuesto = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_retencion = -1
            cerrardb()
            Return tmp
        End Try
    End Function
    Public Function addCobroRetencion(ByVal cb As cobroRetencion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO cobros_retenciones (id_cobro, id_impuesto, total, notas, " _
            + "VALUES ('" + cb.id_cobro.ToString + "', '" + cb.id_impuesto.ToString + "', '" + cb.total.ToString + "', '" + cb.notas + "')"

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

    Public Function addTmpCobroRetencion(ByVal cb As cobroRetencion) As Boolean
        Dim sqlComm As New SqlCommand 'Comando en el resto
        Dim resultado As Integer

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_insertTmpCobroRetencion"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("id_impuesto", cb.id_impuesto)
                    .AddWithValue("total", cb.total)
                    .AddWithValue("notas", cb.notas)
                    .Add(New SqlParameter("@resultado", SqlDbType.Int)).Direction = ParameterDirection.Output
                End With
                .Connection = CN
                .ExecuteNonQuery()
            End With

            resultado = CInt(sqlComm.Parameters("@resultado").Value)
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    Public Function guardarCobroRetencion(ByVal c As cobro) As Boolean
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "INSERT INTO cobros_retenciones (id_cobro, id_impuesto, total, notas) " &
                        "SELECT '" + c.id_cobro.ToString + "', id_impuesto, total, notas " &
                        "FROM tmpcobros_retenciones "
            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cerrardb()
            borrartbl("tmpcobros_retenciones")
        End Try
    End Function


    Public Function updateTmpCobroRetencion(ByVal cb As cobroRetencion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try

            sqlstr = "UPDATE tmpcobros_retenciones SET id_impuesto = '" + cb.id_impuesto.ToString +
                    "', total = '" + cb.total.ToString + "', notas = '" + cb.notas + "' " +
                    "WHERE id_tmpRetencion = '" + cb.id_retencion.ToString + "'"

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


    Public Function borrarTmpCobroRetencion(ByVal cb As cobroRetencion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM tmpcobros_retenciones WHERE id_tmpRetencion = '" + cb.id_retencion.ToString + "'", CN)
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

    Public Function borrarTmpCobroRetencion(ByVal id_retencion As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM tmpcobros_retenciones WHERE id_tmpRetencion = '" + id_retencion.ToString + "'", CN)
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

    Public Function borrarCobroRetencion(ByVal cb As cobroRetencion) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM cobros_retenciones WHERE id_retencion = '" + cb.id_retencion.ToString + "'"
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
    ' ************************************ FUNCIONES DE RETENCIONES EN COBROS ***************************
End Module
