Imports System.Data.SqlClient

Module transferencias
    ' ************************************ FUNCIONES DE TRANSFERENCIAS ***************************
    Public Function info_transferencia(ByVal id_transferencia As String, ByVal esCobro As Boolean) As transferencia
        Dim tmp As New transferencia
        Dim sqlstr As String

        If esCobro Then
            sqlstr = "SET DATEFORMAT dmy; SELECT id_transferencia, id_cobro, id_cuentaBancaria, CONVERT(NVARCHAR(20), fecha, 3) AS 'fecha', total, nComprobante, notas " &
                    "FROM transferencias " &
                    "WHERE id_transferencia = '" + id_transferencia + "'"
        Else
            sqlstr = "SET DATEFORMAT dmy; SELECT id_transferencia, id_pago, id_cuentaBancaria, CONVERT(NVARCHAR(20), fecha, 3) AS 'fecha', total, nComprobante, notas " &
                    "FROM transferencias " &
                    "WHERE id_transferencia = '" + id_transferencia + "'"
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
            tmp.id_transferencia = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If esCobro Then
                tmp.id_cobro = dataset.Tables("tabla").Rows(0).Item(1).ToString
            Else
                tmp.id_pago = dataset.Tables("tabla").Rows(0).Item(1).ToString
            End If
            tmp.id_cuentaBancaria = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.nComprobante = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(6).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_transferencia = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function info_tmpTransferencia(ByVal id_transferencia As String) As transferencia
        Dim tmp As New transferencia
        Dim sqlstr As String


        sqlstr = "SET DATEFORMAT dmy; SELECT id_tmpTransferencia, id_cuentaBancaria, CONVERT(NVARCHAR(20), fecha, 3) AS 'fecha', total, nComprobante, notas " &
                    "FROM tmptransferencias " &
                    "WHERE id_tmpTransferencia = '" + id_transferencia + "'"

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
            tmp.id_transferencia = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_cuentaBancaria = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.nComprobante = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(5).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_transferencia = -1
            cerrardb()
            Return tmp
        End Try
    End Function
    Public Function addtransferencia(ByVal t As transferencia, ByVal esCobro As Boolean) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If esCobro Then
                sqlstr = "SET DATEFORMAT dmy; INSERT INTO transferencias (id_cobro, id_cuentaBancaria, fecha, total, nComprobante, notas, " _
                            + "VALUES ('" + t.id_cobro.ToString + "', '" + t.id_cuentaBancaria.ToString + "', '" + t.fecha + "', '" + t.total.ToString + "', '" + t.nComprobante + "', '" + t.notas + "')"
            Else
                sqlstr = "SET DATEFORMAT dmy; INSERT INTO transferencias (id_pago, id_cuentaBancaria, fecha, total, nComprobante, notas, " _
                            + "VALUES ('" + t.id_pago.ToString + "', '" + t.id_cuentaBancaria.ToString + "', '" + t.fecha + "', '" + t.total.ToString + "', '" + t.nComprobante + "', '" + t.notas + "')"
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

    Public Function addTmpTransferencia(ByVal t As transferencia) As Boolean
        Dim sqlComm As New SqlCommand 'Comando en el resto
        Dim resultado As Integer

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_insertTmpTransferencia"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("id_cuentaBancaria", t.id_cuentaBancaria)
                    .AddWithValue("fecha", t.fecha)
                    .AddWithValue("total", t.total)
                    .AddWithValue("nComprobante", t.nComprobante)
                    .AddWithValue("notas", t.notas)
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

    Public Function guardarTransferencias(ByVal c As cobro) As Boolean
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "INSERT INTO transferencias (id_cobro, id_cuentaBancaria, fecha, total, nComprobante, notas) " &
                        "SELECT '" + c.id_cobro.ToString + "', id_cuentaBancaria, fecha, total, nComprobante, notas " &
                        "FROM tmptransferencias "
            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            borrartbl("tmptransferencias")
            cerrardb()
        End Try
    End Function

    Public Function guardarTransferencias(ByVal p As pago) As Boolean
        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            mytrans = CN.BeginTransaction()

            sqlstr = "INSERT INTO transferencias (id_pago, id_cuentaBancaria, fecha, total, nComprobante, notas) " &
                        "SELECT '" + p.id_pago.ToString + "', id_cuentaBancaria, fecha, total, nComprobante, notas " &
                        "FROM tmptransferencias "
            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            borrartbl("tmptransferencias")
            cerrardb()
        End Try
    End Function

    Public Function updateTmptransferencia(ByVal t As transferencia) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try

            sqlstr = "SET DATEFORMAT dmy; UPDATE tmptransferencias SET id_cuentaBancaria = '" + t.id_cuentaBancaria.ToString +
                    "', fecha = '" + t.fecha + "', total = '" + t.total.ToString + "', nComprobante = '" + t.nComprobante + ", notas = '" + t.notas + "' " +
                    "WHERE id_tmpTransferencia = '" + t.id_transferencia.ToString + "'"

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


    Public Function borrarTmptransferencia(ByVal t As transferencia) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM tmptransferencias WHERE id_tmptransferencia = '" + t.id_transferencia.ToString + "'", CN)
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

    Public Function borrarTmptransferencia(ByVal id_transferencia As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM tmptransferencias WHERE id_tmptransferencia = '" + id_transferencia.ToString + "'", CN)
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

    Public Function borrartransferencia(ByVal t As transferencia) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM transferencias WHERE id_transferencia = '" + t.id_transferencia.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE TRANSFERENCIAS ***************************
End Module
