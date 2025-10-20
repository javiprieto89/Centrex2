
Imports System.Data.SqlClient
Module condiciones_venta

    ' ************************************ FUNCIONES DE CONDICIONES DE VENTA Y COMPRA **********************
    Public Function info_condicion_venta(ByVal id_condicion As String) As condicion_venta
        Dim tmp As New condicion_venta
        Dim sqlstr As String

        Try
            sqlstr = "SELECT id_condicion_venta, condicion, vencimiento, recargo, activo " +
                    "FROM condiciones_venta " +
                    "WHERE id_condicion_venta = '" + id_condicion.ToString + "'"

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
            tmp.id_condicion_venta = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.condicion = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.vencimiento = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.recargo = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.condicion = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addCondicion_venta(ByVal condicion As condicion_venta) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO condiciones_venta (condicion, vencimiento, recargo, activo) VALUES ('" +
                        condicion.condicion + "', '" + condicion.vencimiento.ToString + "', '" + condicion.recargo.ToString +
                        "', '" + condicion.activo.ToString + "')"
            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function updateCondicion_venta(ByVal condicion As condicion_venta, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE condiciones_venta SET activo = '0' WHERE id_condicion_venta = '" + condicion.id_condicion_venta.ToString + "'"
            Else
                sqlstr = "UPDATE condiciones_venta SET condicion = '" + condicion.condicion + "', vencimiento = '" + condicion.vencimiento.ToString +
                            "', recargo = '" + condicion.recargo.ToString + "', activo = '" + condicion.activo.ToString +
                            "' WHERE id_condicion_venta = '" + condicion.id_condicion_venta.ToString + "'"
            End If
            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function borrarCondicion_venta(ByVal condicion As condicion_venta) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM condiciones_venta WHERE id_condicion_venta = '" + condicion.id_condicion_venta.ToString + "'"
            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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
    ' ************************************ FUNCIONES DE CONDICIONES DE VENTA Y COMPRA **********************
End Module
