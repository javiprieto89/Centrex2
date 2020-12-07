Imports System.Data.SqlClient

Module mitem
    ' ************************************ FUNCIONES DE ITEMS ***************************
    Public Function info_item(ByVal id_item As String) As item
        Dim tmp As New item
        Dim sqlstr As String = "SELECT * FROM items WHERE id_item = '" + id_item + "'"
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
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.item = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.descript = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.costo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.precio_lista = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_tipo = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_marca = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.factor = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.esDescuento = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.esMarkup = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(12).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.descript = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function info_itemDesc(ByVal descript As String) As item
        Dim tmp As New item
        Dim sqlstr As String = "SELECT * FROM items WHERE descript = '" + descript + "'"
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
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.item = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.descript = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.costo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.precio_lista = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_tipo = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_marca = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.factor = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.esDescuento = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.esMarkup = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(12).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.descript = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function info_itemtmp(ByVal id_item As String) As Boolean
        Dim tmp As New item
        Dim sqlstr As String = "SELECT * FROM tmppedidos_items WHERE id_item = '" + id_item + "'"
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
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            'tmp.descript = "error"
            cerrardb()
            Return False
        End Try
    End Function

    Public Function additem(it As item) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO items (item, descript, cantidad, costo,  precio_lista, id_tipo, id_marca, id_proveedor, factor ,esDescuento, esMarkup, activo) VALUES " &
                        "('" + it.item.ToString + "', '" + it.descript.ToString + "', '" + it.cantidad.ToString + "', '" + it.costo.ToString + "', '" + it.precio_lista.ToString + "', '" + it.id_tipo.ToString + "', '" _
                        + it.id_marca.ToString + "', '" + it.id_proveedor.ToString + "', '" + it.factor.ToString + "', '" + it.esDescuento.ToString + "', '" + it.esMarkup.ToString +
                        "', '" + it.activo.ToString + "')"


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

    Public Function addItemIVA(ByVal ii As itemImpuesto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim sqlstr As String

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO items_impuestos (id_item, id_impuesto) VALUES (" & ii.id_item.ToString & ", " & ii.id_impuesto.ToString & ")"


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

    Public Function infoItem_lastItem() As item
        Dim tmp As New item
        Dim sqlstr As String = "SELECT TOP 1 * FROM items ORDER BY id_item DESC"
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
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.item = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.descript = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.cantidad = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.costo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.precio_lista = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.id_tipo = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_marca = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.factor = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.esDescuento = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.esMarkup = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(12).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.descript = "error"
            cerrardb()
            Return tmp
        End Try
    End Function


    Public Function updateitem(it As item, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String
        Dim cont As Integer

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE items SET activo = '0' WHERE id_item = '" + it.id_item.ToString + "'"
            Else
                cont = InStr(it.descript, "'")
                If cont > 0 Then it.descript = Left(it.descript, cont) + "'" + Right(it.descript, (it.descript.Length - cont)) 'Agrego un apostrofe extra si tiene alguno para que no de error en el SQL
                sqlstr = "UPDATE items SET item = '" + it.item + "', descript = '" + it.descript + "', cantidad = '" + it.cantidad.ToString + "', costo = '" + it.costo.ToString + "', precio_lista = '" _
                                         + it.precio_lista.ToString + "', id_tipo = '" + it.id_tipo.ToString + "', id_marca = '" + it.id_marca.ToString + "', id_proveedor =  '" _
                                        + it.id_proveedor.ToString + "', factor = '" + it.factor.ToString + "', esDescuento = '" + it.esDescuento.ToString + "', esMarkup = '" + it.esMarkup.ToString + _
                                        "', activo = '" + it.activo.ToString + "' " & _
              "WHERE id_item = '" + it.id_item.ToString + "'"
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

    Public Function borraritem(it As item) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM items WHERE id_item = '" + it.id_item.ToString + "'"
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

    Public Function existeitem(ByVal i As String) As Integer
        Dim tmp As New item

        Dim sqlstr As String
        sqlstr = "SELECT id_item FROM items WHERE item LIKE '%" + i.ToString + "%'"

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
            tmp.id_item = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If tmp.id_item = 0 Then Return -1
            cerrardb()
            Return tmp.id_item
        Catch ex As Exception
            tmp.item = "error"
            cerrardb()
            Return -1
        End Try
    End Function
    ' ************************************ FUNCIONES DE ITEMS ***************************
End Module
