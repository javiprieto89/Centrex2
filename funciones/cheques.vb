Imports System.Data
Imports System.Data.SqlClient

Module cheques
    ' ************************************ FUNCIONES DE CHEQUES ***************************
    Public Function info_cheque(ByVal id_cheque As String) As cheque
        Dim tmp As New cheque
        Dim sqlstr As String

        sqlstr = "SELECT ch.id_cheque, ch.fecha_ingreso, ch.fecha_emision, ch.id_cliente, ch.id_proveedor, ch.id_banco, ch.ncheque, ch.ncheque2, ch.importe, ch.id_estadoch, " &
                    "ch.fecha_cobro, ch.fecha_salida, ch.fecha_deposito, ch.recibido, ch.emitido, ch.id_cuentaBancaria, ch.eCheck, ch.activo " &
                    "FROM cheques AS ch " &
                    "WHERE ch.id_cheque = '" + id_cheque + "'"

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
            tmp.id_cheque = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha_ingreso = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha_emision = dataset.Tables("tabla").Rows(0).Item(2).ToString

            If Not IsDBNull(dataset.Tables("tabla").Rows(0).Item(3)) Then
                tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(3).ToString
            Else
                tmp.id_cliente = Nothing
            End If

            If Not IsDBNull(dataset.Tables("tabla").Rows(0).Item(4)) Then
                tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(4).ToString
            Else
                tmp.id_proveedor = Nothing
            End If

            tmp.id_banco = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.nCheque = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.nCheque2 = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.importe = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.id_estadoch = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.fecha_cobro = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.fecha_salida = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.fecha_deposito = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.recibido = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.emitido = dataset.Tables("tabla").Rows(0).Item(14).ToString

            If Not IsDBNull(dataset.Tables("tabla").Rows(0).Item(15)) Then
                tmp.id_cuentaBancaria = dataset.Tables("tabla").Rows(0).Item(15).ToString
            Else
                tmp.id_cuentaBancaria = Nothing
            End If

            tmp.eCheck = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(17).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.nCheque = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addch(ByVal ch As cheque) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            With ch
                sqlstr = ""
                sqlstr = "SET DATEFORMAT dmy; INSERT INTO cheques (fecha_emision, "
                If .id_cliente <> Nothing Then
                    sqlstr += "id_cliente, "
                ElseIf .id_proveedor <> Nothing Then
                    sqlstr += "id_proveedor, "
                End If
                sqlstr += "id_banco, nCheque, nCheque2, importe, id_estadoch, "
                If .fecha_cobro <> Nothing Then
                    sqlstr += "fecha_cobro, "
                End If
                If .fecha_salida <> Nothing Then
                    sqlstr += "fecha_salida, "
                End If
                If .fecha_deposito <> Nothing Then
                    sqlstr += "fecha_deposito, "
                End If
                sqlstr += "recibido, emitido, "
                If .id_cuentaBancaria <> Nothing Then
                    sqlstr += "id_cuentaBancaira, "
                End If
                sqlstr += "eCheck, activo) " &
                        "VALUES ('" + .fecha_emision + "', '"

                If .id_cliente <> Nothing Then
                    sqlstr += .id_cliente.ToString
                ElseIf .id_proveedor <> Nothing Then
                    sqlstr += .id_proveedor.ToString
                End If
                sqlstr += "', '" + .id_banco.ToString + "', '" + .nCheque + "', '" + .nCheque2 + "', '" + .importe.ToString + "', '" +
                        .id_estadoch.ToString + "', '"
                If .fecha_cobro <> Nothing Then
                    sqlstr += .fecha_cobro.ToString + "', '"
                End If
                If .fecha_salida <> Nothing Then
                    sqlstr += .fecha_salida.ToString + "', '"
                End If
                If .fecha_deposito <> Nothing Then
                    sqlstr += .fecha_deposito.ToString + "', '"
                End If
                sqlstr += .recibido.ToString + "', '" + .emitido.ToString + "', '"

                If .id_cuentaBancaria <> 0 Then
                    sqlstr += .id_cuentaBancaria.ToString + "', '"
                End If
                sqlstr += .eCheck.ToString + "', '1')"
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

    Public Function updatech(ByVal ch As cheque, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE cheques SET activo = '0' WHERE id_cheque = '" + ch.id_cheque.ToString + "'"
            Else
                With ch
                    sqlstr = "SET DATEFORMAT dmy; UPDATE cheques SET "
                    If Not .fecha_emision Is Nothing Then sqlstr += "fecha_emision = '" + .fecha_emision + "', "
                    sqlstr += "id_banco = '" + .id_banco.ToString + "', nCheque = '" + .nCheque + "', nCheque2 = '" + .nCheque2 + "', " _
                        + "importe = '" + .importe.ToString + "', id_estadoch = '" + .id_estadoch.ToString + "'"
                    If Not .fecha_cobro Is Nothing Then sqlstr += ", fecha_cobro = '" + .fecha_cobro.ToString + "'"
                    If Not .fecha_salida Is Nothing Then sqlstr += ", fecha_salida = '" + .fecha_salida.ToString + "'"
                    If Not .fecha_deposito Is Nothing Then sqlstr += ", fecha_deposito = '" + .fecha_deposito.ToString + "'"
                    sqlstr += ", recibido = '" + .recibido.ToString + "', emitido = '" + .emitido.ToString + "', eCheck = '" + .eCheck.ToString + "'"
                    If .id_cliente <> 0 Then
                        sqlstr += ", id_cliente = '" + .id_cliente.ToString + "'"
                    ElseIf .id_proveedor <> 0 Then
                        sqlstr += ", id_proveedor = '" + .id_proveedor.ToString + "'"
                    End If
                    sqlstr += " WHERE id_cheque = '" + .id_cheque.ToString + "'"
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

    Public Function borrarch(ByVal ch As cheque) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM cheques WHERE id_cheque = '" + ch.id_cheque.ToString + "'", CN)
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

    Public Function borrarch(ByVal id_cheque As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM cheques WHERE id_cheque = '" + id_cheque.ToString + "'", CN)
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

    Public Function Depositar_cheque(ByVal ch As cheque) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; UPDATE cheques SET id_estadoch = '" + ID_CH_DEPOSITADO.ToString + "', fecha_deposito = '" _
                        + ch.fecha_deposito.ToString + "', id_cuentaBancaria = '" & ch.id_cuentaBancaria.ToString & "' " &
                        "WHERE id_cheque = '" + ch.id_cheque.ToString + "'"

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

    Public Function Anular_Deposito_Cheque(ByVal id_cheque As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "SET DATEFORMAT dmy; UPDATE cheques SET id_estadoch = '" + ID_CH_CARTERA.ToString + "', fecha_deposito = NULL, " &
                        "id_cuentaBancaria = NULL " &
                        "WHERE id_cheque = '" + id_cheque.ToString + "'"

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

    Public Function Existe_N_Cheque(ByVal nCheque As String) As Boolean
        Dim c As New Integer
        Dim sqlstr As String

        sqlstr = "SELECT COUNT(id_cheque) FROM cheques WHERE nCheque = '" & Trim(nCheque) & "'"

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
            c = dataset.Tables("tabla").Rows(0).Item(0).ToString

            If c > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    Public Function Ultimo_N2_Cheque() As Integer
        Dim c As New Integer
        Dim sqlstr As String

        sqlstr = "SELECT ISNULL(MAX(nCheque2), 0) FROM cheques"

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
            c = dataset.Tables("tabla").Rows(0).Item(0).ToString

            Return c
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return 0
        Finally
            cerrardb()
        End Try
    End Function

    ' ************************************ FUNCIONES DE CHEQUES ***************************
End Module
