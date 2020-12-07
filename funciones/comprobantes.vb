Imports System.Data
Imports System.Data.SqlClient

Module comprobantes
    ' ************************************ FUNCIONES DE COMPROBANTES ***************************
    Public Function info_comprobante(ByVal id_comprobante As String) As comprobante
        Dim tmp As New comprobante
        Dim sqlstr As String
        'cerrardb() 'temporal

        If id_comprobante Is Nothing Then
            tmp.comprobante = "error"
            Return tmp
        End If

        sqlstr = "SELECT id_comprobante, comprobante, id_tipoComprobante, numeroComprobante, puntoVenta, ISNULL(esFiscal, 0), ISNULL(esElectronica, 0), ISNULL(esManual, 0), ISNULL(esPresupuesto, 0), " &
                    "activo, testing, maxItems " &
                    "FROM comprobantes WHERE id_comprobante = '" + id_comprobante.ToString + "'"

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
            tmp.id_comprobante = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.comprobante = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_tipoComprobante = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.numeroComprobante = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.puntoVenta = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.esFiscal = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.esElectronica = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.esManual = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.esPresupuesto = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.testing = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.maxItems = dataset.Tables("tabla").Rows(0).Item(11).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.comprobante = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addcomprobante(ByVal c As comprobante) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO comprobantes (comprobante, id_tipoComprobante, numeroComprobante, puntoVenta, esFiscal, esElectronica, esManual, esPresupuesto, activo, testing, maxItems) " & _
                        "VALUES ('" + c.comprobante + "', '" + c.id_tipoComprobante.ToString + "', '" + c.numeroComprobante.ToString + "', '" + c.puntoVenta.ToString + "', '" + c.esFiscal.ToString + _
                        "', '" + c.esElectronica.ToString + "', '" + c.esManual.ToString + "', '" + c.esPresupuesto.ToString + "', '" + c.activo.ToString + "', '" + c.testing.ToString + "', '" + c.maxItems.ToString + "')"

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

    Public Function updatecomprobante(ByVal c As comprobante, Optional ByVal borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE comprobantes SET activo = '0' WHERE id_id_comprobante = '" + c.id_comprobante.ToString + "'"
            Else
                sqlstr = "UPDATE comprobantes SET comprobante = '" + c.comprobante + "', id_tipoComprobante = '" + c.id_tipoComprobante.ToString + "', numeroComprobante = '" + c.numeroComprobante.ToString + "', puntoVenta = '" _
                        + c.puntoVenta.ToString + "', esFiscal = '" + c.esFiscal.ToString + "', esElectronica = '" + c.esElectronica.ToString + "', esManual = '" _
                        + c.esManual.ToString + "', esPresupuesto = '" + c.esPresupuesto.ToString + "', activo = '" + c.activo.ToString + "', testing = '" + c.testing.ToString + "', maxItems = '" + c.maxItems.ToString + "' " _
                        + "WHERE id_comprobante = '" + c.id_comprobante.ToString + "'"
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

    Public Function borrarcomprobante(ByVal c As comprobante) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM comprobantes WHERE id_comprobante = '" + c.id_comprobante.ToString + "'", CN)
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

    Public Function estaComprobanteDefault(ByVal condicion As String, ByVal id_comprobanteDefault As Integer) As Boolean
        Dim tmp As New comprobante
        Dim sqlstr As String

        'Select Case id_comprobanteDefault
        '    Case Is = 1, 2, 3, 4, 5, 63, 34, 39, 60
        '        id_comprobanteDefault = -1
        'End Select

        sqlstr = "SELECT c.id_comprobante AS 'id_comprobante', c.comprobante AS 'comprobante' " &
                            "FROM comprobantes AS c " &
                            "WHERE c.activo = '1' AND (c.id_tipoComprobante " + condicion + " (1, 2, 3, 4, 5, 63, 34, 39, 60) " &
                            "OR c.id_tipoComprobante IN (0, 99, 199)) AND c.id_comprobante = " + id_comprobanteDefault.ToString + " " &
                            "ORDER BY c.comprobante ASC"

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
            tmp.id_comprobante = dataset.Tables("tabla").Rows(0).Item(0).ToString
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            Return False
        Finally
            cerrardb()
        End Try
    End Function
    ' ************************************ FUNCIONES DE COMPROBANTES ***************************
End Module