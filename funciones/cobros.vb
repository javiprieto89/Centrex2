Imports System.Data.SqlClient
'Imports System.Data.Entity
Imports System.Linq

Module cobros
    ' ************************************ FUNCIONES DE COBROS ***************************
    Public Function info_cobro(ByVal id_cobro As String) As cobro
        Dim tmp As New cobro
        Dim sqlstr As String

        sqlstr = "SET DATEFORMAT dmy; SELECT id_cobro, ISNULL(id_cobro_oficial, -1), ISNULL(id_cobro_no_oficial, -1), fecha_carga, fecha_cobro, id_cliente, id_cc, dineroEnCc, efectivo, totalTransferencia, totalCh, " &
                    "totalRetencion, total, hayCheque, hayTransferencia, hayRetencion, activo, ISNULL(id_anulaCobro, -1), notas, firmante " &
                    "FROM cobros " &
                    "WHERE id_cobro = '" + id_cobro + "'"

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
            tmp.id_cobro = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_cobro_oficial = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_cobro_no_oficial = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.fecha_carga = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.fecha_cobro = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_cc = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.dineroEnCc = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.efectivo = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.totalTransferencia = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.totalCh = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.totalRetencion = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.hayCheque = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.hayTransferencia = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.hayRetencion = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.id_anulaCobro = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.firmante = dataset.Tables("tabla").Rows(0).Item(19).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.efectivo = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addcobro(ByVal c As cobro) As Integer
        Dim sqlComm As New SqlCommand 'Comando en el resto
        Dim resultado As Integer

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_insertCobro"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("id_cobro_oficial", c.id_cobro_oficial)
                    .AddWithValue("id_cobro_no_oficial", c.id_cobro_no_oficial)
                    .AddWithValue("fecha_cobro", c.fecha_cobro)
                    .AddWithValue("id_cliente", c.id_cliente)
                    .AddWithValue("id_cc", c.id_cc)
                    .AddWithValue("dineroEnCc", c.dineroEnCc)
                    .AddWithValue("efectivo", c.efectivo)
                    .AddWithValue("totalTransferencia", c.totalTransferencia)
                    .AddWithValue("totalCh", c.totalCh)
                    .AddWithValue("totalRetencion", c.totalRetencion)
                    .AddWithValue("total", c.total)
                    .AddWithValue("hayCheque", c.hayCheque)
                    .AddWithValue("hayTransferencia", c.hayTransferencia)
                    .AddWithValue("hayRetencion", c.hayRetencion)
                    .AddWithValue("id_anulaCobro", c.id_anulaCobro)
                    .AddWithValue("notas", c.notas)
                    .AddWithValue("firmante", c.firmante)
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

    Public Function borrarcobro(ByVal c As cobro) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim ac As New cobro
        Dim cc As New ccCliente

        ac = c
        With ac
            .dineroEnCc = .dineroEnCc * -1
            .efectivo = .efectivo * -1
            .totalTransferencia = .totalTransferencia * -1
            .totalCh = .totalCh * -1
            .totalRetencion = .totalRetencion * -1
            .total = .total * -1
            .id_anulaCobro = c.id_cobro
            If .id_cobro_no_oficial = -1 Then
                .notas += vbCr + "Anula cobro: " + .id_cobro_oficial.ToString
            Else
                .notas += vbCr + "Anula cobro: " + .id_cobro_no_oficial.ToString
            End If
        End With

        'Agrego un cobro exactamente al revez, referenciando al cobro original
        ac.id_cobro = addcobro(ac)

        'Borro todas las transferencias que pertenecen a ese cobro
        borrar_transferencias(c.id_cobro)

        'Borro todas las retenciones que pertenecen a ese cobro
        borrar_retenciones(c.id_cobro)

        If ac.id_cobro Then
            'Borro los cheques asignados al cobro para liberarlos y actualizo el saldo
            borrar_chequeCobrado(ac.id_cobro)
            cc = info_ccCliente(c.id_cc)
            cc.saldo -= c.total
            updateCCCliente(cc)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function add_chequeCobrado(ByVal id_cobro As Integer, ByVal id_cheque() As Integer) As Integer
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String = ""

        mytrans = CN.BeginTransaction()

        Try

            For Each cheque As Integer In id_cheque
                sqlstr += "INSERT INTO cobros_cheques (id_cobro, id_cheque) VALUES (" + id_cobro.ToString + ", " + cheque.ToString + "); "
            Next

            sqlstr = Left(Trim(sqlstr), (Len(Trim(sqlstr)) - 1))

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

    Public Function borrar_chequeCobrado(ByVal id_cobro As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM cobros_cheques WHERE id_cobro = '" + id_cobro.ToString + "'"
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

    Public Function liberar_chequesCobrados(ByVal id_cobro As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "UPDATE ch " &
                    "SET ch.id_estadoch = '" + ID_CH_CARTERA + "' " &
                    "FROM cheques AS ch " &
                    "INNER JOIN cobros_cheques AS cch ON ch.id_cheque = cch.id_cheque " &
                    "WHERE cch.id_cobro = '" + id_cobro.ToString + "' "
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

    Public Function borrar_transferencias(ByVal id_cobro As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM transferencias WHERE id_cobro = '" + id_cobro.ToString + "'"
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

    Public Function borrar_retenciones(ByVal id_cobro As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM cobros_retenciones WHERE id_cobro = '" + id_cobro.ToString + "'"
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

    Public Function guardar_cobros_facturas_importes(ByVal id_cobro As Integer, ByVal dg As DataGridView) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String = "SET NOCOUNT ON; SET DATEFORMAT dmy; "

        mytrans = CN.BeginTransaction()

        Try
            If dg.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dg.Rows
                    If Not row Is Nothing And Not row.IsNewRow Then
                        sqlstr += "INSERT INTO cobros_Nfacturas_importes (id_cobro, fecha, nfactura, importe) VALUES ('" + id_cobro.ToString + "', '" + row.Cells("Fecha").Value.ToString + "', '" + row.Cells("Factura").Value.ToString + "', '" + row.Cells("Importe").Value.ToString + "'); "
                    End If
                Next

                sqlstr = Left(Trim(sqlstr), (Len(Trim(sqlstr)) - 1))

                Comando = New SqlClient.SqlCommand(sqlstr, CN)

                Comando.Transaction = mytrans
                Comando.ExecuteNonQuery()

                mytrans.Commit()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cerrardb()
        End Try

    End Function


    Public Function Cobro_Ya_Anulado(ByVal id_cobro As String) As Boolean
        Dim tmp As Integer = -1
        Dim sqlstr As String

        sqlstr = "SELECT ISNULL(id_anulaCobro, -1) " &
                    "FROM cobros " &
                    "WHERE id_anulaCobro = '" + id_cobro + "'"

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
            If dataset.Tables("Tabla").Rows.Count > 0 Then
                tmp = dataset.Tables("tabla").Rows(0).Item(0).ToString
            End If

            If tmp <> -1 Then
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

    Public Function Ultimo_cobro_oficial() As Integer
        Dim id_cobro_oficial As Integer
        Dim sqlstr As String

        sqlstr = "SELECT MAX(id_cobro_oficial) FROM cobros"

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
            id_cobro_oficial = dataset.Tables("tabla").Rows(0).Item(0)
            If id_cobro_oficial = -1 Then
                id_cobro_oficial = 1
            Else
                id_cobro_oficial += 1
            End If
            Return id_cobro_oficial
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return -1
        Finally
            cerrardb()
        End Try
    End Function

    Public Function Ultimo_cobro_no_oficial() As Integer
        Dim id_cobro_no_oficial As Integer
        Dim sqlstr As String

        sqlstr = "SELECT MAX(id_cobro_no_oficial) FROM cobros"

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
            id_cobro_no_oficial = dataset.Tables("tabla").Rows(0).Item(0)
            If id_cobro_no_oficial = -1 Then
                id_cobro_no_oficial = 1
            Else
                id_cobro_no_oficial += 1
            End If
            Return id_cobro_no_oficial
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return -1
        Finally
            cerrardb()
        End Try
    End Function
    ' ************************************ FUNCIONES DE COBROS ***************************
End Module