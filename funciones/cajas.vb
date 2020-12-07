Imports System.Data.SqlClient

Module cajas
    ' ************************************ FUNCIONES DE CAJAS ********************
    Public Function info_caja(ByVal id_caja As String) As caja
        Dim tmp As New caja
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT * FROM cajas WHERE id_caja = '" + id_caja + "'"

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
            tmp.id_caja = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.esCC = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addCaja(ByVal c As caja) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO cajas (nombre, esCC, activo) VALUES ('" + c.nombre + "', '" + c.esCC.ToString + "', '" + c.activo.ToString + "')"

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

    Public Function updateCaja(ByVal c As caja, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE cajas SET activo = '0' WHERE id_caja = '" + c.id_caja.ToString + "'"
            Else
                sqlstr = "UPDATE cajas SET nombre = '" + c.nombre + "', esCC = '" + c.esCC.ToString + "', activo = '" + c.activo.ToString +
                                               "' WHERE id_caja = '" + c.id_caja.ToString + "'"
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

    Public Function borrarCaja(ByVal c As caja) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM cajas WHERE id_caja = '" + c.id_caja.ToString + "'"

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

    Public Function consultaSaldoCaja(ByVal id_caja As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, _
                                      ByVal consulta_pedidos As Boolean, ByVal consulta_casos As Boolean, _
                                      ByVal consulta_abiertos As Boolean, ByVal consulta_cerrados As Boolean) As saldoCaja
        Dim saldo As New saldoCaja
        Dim sqlstr As String
        Dim where As String = ""

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            If consulta_pedidos And Not consulta_casos Then
                where = " AND p.es_caso = '0'"
            ElseIf Not consulta_pedidos And consulta_casos Then
                where = " AND p.es_caso = '1'"
            End If

            If consulta_abiertos And Not consulta_cerrados Then
                where += " AND p.activo = '1' AND p.cerrado = '0'"
            ElseIf Not consulta_abiertos And consulta_cerrados Then
                where += " AND p.activo = '0' AND p.cerrado = '1'"
            End If

            sqlstr = "SELECT ISNULL((SUM(p.total) - SUM(p.montoTarjeta)),0) AS 'Contado', ISNULL(SUM(p.montoTarjeta),0) AS 'Tarjeta', " +
                        "ISNULL(SUM(p.total), 0) AS 'Total' " &
                        "FROM pedidos As p " &
                        "INNER JOIN cajas AS c ON p.id_caja = c.id_caja " &
                        "WHERE c.esCC = '0' AND p.fecha BETWEEN '" + fecha_desde.ToString("yyyy/MM/dd") + "' AND '" + fecha_hasta.ToString("yyyy/MM/dd") + "' " &
                        "AND p.id_caja = '" + id_caja.ToString + "'" ' AND p.activo = '0' AND p.cerrado = '1'"

            sqlstr += where

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
            saldo.contado = dataset.Tables("tabla").Rows(0).Item(0).ToString
            saldo.tarjeta = dataset.Tables("tabla").Rows(0).Item(1).ToString
            saldo.total = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return saldo
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            saldo.contado = -9999999
            cerrardb()
            Return saldo
        End Try
    End Function

    ' ************************************ FUNCIONES DE CAJAS ********************
End Module
