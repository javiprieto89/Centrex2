Imports System.Data
Imports System.Data.SqlClient

Module pagos
    ' ************************************ FUNCIONES DE PAGOS ***************************
    Public Function info_pago(ByVal id_pago As String) As pago
        Dim tmp As New pago
        Dim sqlstr As String

        sqlstr = "SET DATEFORMAT dmy; SELECT id_pago, fecha_carga, fecha_pago, id_proveedor, id_cc, dineroEnCc, efectivo, totalTransferencia, " &
                    "totalCh, total, hayCheque, hayTransferencia, activo, ISNULL(id_anulaPago, -1), notas " &
                    "FROM pagos " &
                    "WHERE id_pago = '" + id_pago + "'"

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
            tmp.id_pago = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.fecha_carga = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.fecha_pago = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.id_cc = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.dineroEnCc = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.efectivo = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.totalTransferencia = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.totalch = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.total = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.hayCheque = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.hayTransferencia = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.id_anulaPago = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(14).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.efectivo = -1
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addpago(ByVal p As pago) As Integer
        Dim sqlComm As New SqlCommand 'Comando en el resto
        Dim resultado As Integer

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_insertPago"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("fecha_pago", p.fecha_pago.ToString)
                    .AddWithValue("id_proveedor", p.id_proveedor)
                    .AddWithValue("id_cc", p.id_cc)
                    .AddWithValue("dineroEnCc", p.dineroEnCc)
                    .AddWithValue("efectivo", p.efectivo)
                    .AddWithValue("totalTransferencia", p.totalTransferencia)
                    .AddWithValue("totalCh", p.totalch)
                    .AddWithValue("total", p.total)
                    .AddWithValue("hayCheque", p.hayCheque)
                    .AddWithValue("hayTransferencia", p.hayTransferencia)
                    .AddWithValue("id_anulaPago", p.id_anulaPago)
                    If p.notas Is Nothing Then p.notas = ""
                    .AddWithValue("notas", p.notas)
                    'If p.aplicaFc Is Nothing Then p.aplicaFc = ""
                    '.AddWithValue("aplicaFC", p.aplicaFc)
                    .Add(New SqlParameter("@resultado", SqlDbType.Int)).Direction = ParameterDirection.Output
                End With
                .Connection = CN
                .ExecuteNonQuery()
            End With

            resultado = CInt(sqlComm.Parameters("@resultado").Value)
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            resultado = -1
            Return resultado
        Finally
            cerrardb()
        End Try
    End Function

    Public Function Anula_Pago(ByVal p As pago) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim ap As New pago
        Dim cc As New ccProveedor

        ap = p
        With ap
            .dineroEnCc = .dineroEnCc * -1
            .efectivo = .efectivo * -1
            .totalTransferencia = .totalTransferencia * -1
            .totalch = .totalch * -1
            .total = .total * -1
            .id_anulaPago = p.id_pago
            .notas += vbCr + "ANULA PAGO: " + .id_pago.ToString
            '.aplicaFc = p.aplicaFc
        End With

        'Agrego un pago exactamente al revez, referenciando al cobro original
        ap.id_pago = addpago(ap)

        If ap.id_pago Then
            'Borro los cheques asignados al pago para liberarlos y actualizo el saldo
            borrar_chequePagado(ap.id_pago)
            cc = info_ccProveedor(p.id_cc)
            cc.saldo -= p.total
            updateCCProveedor(cc)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function add_chequePagado(ByVal id_pago As Integer, ByVal id_cheque() As Integer) As Integer
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String = ""

        mytrans = CN.BeginTransaction()

        Try

            For Each cheque As Integer In id_cheque
                sqlstr += "INSERT INTO pagos_cheques (id_pago, id_cheque) VALUES (" + id_pago.ToString + ", " + cheque.ToString + "); "
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

    Public Function borrar_chequePagado(ByVal id_pago As Integer) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM pagos_cheques WHERE id_pago = '" + id_pago.ToString + "'"
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

    Public Function guardar_pagos_facturas_importes(ByVal id_pago As Integer, ByVal dg As DataGridView) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String = "SET NOCOUNT ON; SET DATEFORMAT dmy; "

        mytrans = CN.BeginTransaction()

        Try
            If dg.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dg.Rows
                    If Not row Is Nothing And Not row.IsNewRow Then
                        sqlstr += "INSERT INTO pagos_nFacturas_importes (id_pago, fecha, nfactura, importe) " &
                                "VALUES ('" + id_pago.ToString + "', '" + row.Cells("Fecha").Value.ToString _
                                + "', '" + row.Cells("Factura").Value.ToString _
                                + "', '" + row.Cells("Importe").Value.ToString + "'); "
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

    Public Function Pago_Ya_Anulado(ByVal id_pago As String) As Boolean
        Dim tmp As Integer = -1
        Dim sqlstr As String

        sqlstr = "SELECT ISNULL(id_anulaPago, -1) " &
                    "FROM pagos " &
                    "WHERE id_anulaPago = '" + id_pago + "'"

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
    ' ************************************ FUNCIONES DE PAGOS ***************************
End Module
