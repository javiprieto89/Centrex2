
Imports System.Data
Imports System.Data.SqlClient

Module cuentas_bancarias
    ' ************************************ FUNCIONES DE CUENTAS BANCARIAS ***************************
    Public Function info_cuentaBancaria(ByVal id_cuentaBancaria As String) As cuenta_bancaria
        Dim tmp As New cuenta_bancaria
        Dim sqlstr As String

        sqlstr = "SELECT id_cuentaBancaria, id_banco, nombre, id_moneda, saldo, activo FROM cuentas_bancarias WHERE id_cuentaBancaria = '" + id_cuentaBancaria + "'"

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
            tmp.id_cuentaBancaria = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_banco = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.id_moneda = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.saldo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(5).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addcuentaBancaria(ByVal cb As cuenta_bancaria) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            With cb
                sqlstr = "INSERT INTO cuentas_bancarias (id_banco, nombre, id_moneda, saldo, activo) " +
                            "VALUES ('" + .id_banco.ToString + "', '" + .nombre + "', '" + .id_moneda.ToString + "', '" + .saldo.ToString + "', '" + .activo.ToString + "')"
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

    Public Function updatecuentaBancaria(ByVal cb As cuenta_bancaria, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE cuentas_bancarias SET activo = '0' WHERE id_cuentaBancaria = '" + cb.id_cuentaBancaria.ToString + "'"
            Else
                With cb
                    sqlstr = "UPDATE cuentas_bancarias SET id_banco = '" + .id_banco.ToString + "', nombre = '" + .nombre + "', id_moneda = '" +
                        .id_moneda.ToString + "', saldo = '" + .saldo.ToString + "', activo = '" + .activo.ToString + "' " +
                        "WHERE id_cuentaBancaria = '" + cb.id_cuentaBancaria.ToString + "'"
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

    Public Function borrarcuenta_Bancaria(ByVal cb As cuenta_bancaria) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM cuentas_bancarias WHERE id_cuentaBancaria = '" + cb.id_cuentaBancaria.ToString + "'", CN)
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
    ' ************************************ FUNCIONES DE CUENTAS BANCARIAS ***************************
End Module