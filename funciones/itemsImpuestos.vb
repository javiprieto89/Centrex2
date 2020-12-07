Imports System.Data.SqlClient

Module itemsImpuestos
    ' ************************************ FUNCIONES DE RELACION ITEMS E IMPUESTOS ********************
    Public Function info_itemImpuesto(ByVal id_item As String, ByVal id_impuesto As String) As itemImpuesto
        Dim tmp As New itemImpuesto
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT id_item, id_impuesto, activo FROM items_impuestos WHERE id_item = '" + id_item + "' AND id_impuesto = '" + id_impuesto + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_impuesto = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function additemImpuesto(ByVal ii As itemImpuesto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("INSERT INTO items_impuestos (id_item, id_impuesto, activo) VALUES ('" + ii.id_item.ToString + "', '" + ii.id_impuesto.ToString + _
            "', '" + ii.activo.ToString + "')", CN)

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

    Public Function updateitemImpuesto(ByVal iiViejo As itemImpuesto, Optional ByVal iiNuevo As itemImpuesto = Nothing, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE items_impuestos SET activo = '0' WHERE id_item = '" + iiViejo.id_item.ToString + "', id_impuesto = '" + iiViejo.id_impuesto.ToString + "'"

            Else
                sqlstr = "UPDATE items_impuestos SET id_item = '" + iiNuevo.id_item.ToString + "', id_impuesto = '" + iiNuevo.id_impuesto.ToString + "', activo = '" + iiNuevo.activo.ToString _
                            + "' WHERE id_item = '" + iiViejo.id_item.ToString + "' AND id_impuesto = '" + iiViejo.id_impuesto.ToString + "'"
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

    Public Function borraritemImpuesto(ByVal ii As itemImpuesto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM items_impuestos WHERE id_item = '" + ii.id_item.ToString + "' AND id_impuesto = '" + ii.id_impuesto.ToString + "'"

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
    ' ************************************ FUNCIONES DE RELACION ITEMS E IMPUESTOS ********************
End Module

