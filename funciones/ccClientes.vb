Imports System.Data.SqlClient
Imports System.ComponentModel

Module ccClientes

    ' ************************************ FUNCIONES DE CUENTAS CORRIENTES DE CLIENTES **********************
    Public Function info_ccCliente(ByVal id_cc As Integer) As ccCliente
        Dim tmp As New ccCliente
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT * FROM cc_clientes WHERE id_cc = '" + id_cc.ToString + "'"

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
            tmp.id_cc = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_moneda = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.saldo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(5).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addCCCliente(ByVal cc As ccCliente) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO cc_clientes (id_cliente, id_moneda, nombre, saldo, activo) VALUES ('" + cc.id_cliente.ToString + "', '" + cc.id_moneda.ToString + "', '" + cc.nombre + "', '" + cc.saldo.ToString + "', '" + cc.activo.ToString + "')"
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

    Public Function updateCCCliente(ByVal cc As ccCliente, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE cc_clientes SET activo = '0' WHERE id_cc = '" + cc.id_cc.ToString + "'"
            Else
                sqlstr = "UPDATE cc_clientes SET id_cliente = '" + cc.id_cliente.ToString + "', id_moneda = '" + cc.id_moneda.ToString + "', nombre = '" + cc.nombre + "', saldo = '" + cc.saldo.ToString + "', activo = '" + cc.activo.ToString +
                                               "' WHERE id_cc = '" + cc.id_cc.ToString + "'"
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

    Public Function borrarccCliente(ByVal cc As ccCliente) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM cc_clientes WHERE id_cc = '" + cc.id_cc.ToString + "'"
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

    Public Sub consultaCcCliente(ByRef dataGrid As DataGridView, ByVal id_cliente As Integer, ByVal id_Cc As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, ByVal desde As Integer,
                                      ByRef nRegs As Integer, ByRef tPaginas As Integer, ByVal pagina As Integer, ByRef txtnPage As TextBox, ByVal traerTodo As Boolean)

        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
        Dim datatable As New DataTable 'Crear nuevo dataset
        Dim dataset As New DataSet 'Crear nuevo dataset
        Dim comando As New SqlCommand
        'Guarda la columna por la cual está ordenado el control y la dirección en caso de existir
        'para luego volver a ordenar la lista de la misma forma
        Dim oldSortColumn As DataGridViewColumn = Nothing
        Dim oldSortDir As ListSortDirection

        oldSortColumn = dataGrid.SortedColumn
        If dataGrid.SortedColumn IsNot Nothing Then
            If dataGrid.SortOrder = SortOrder.Ascending Then
                oldSortDir = ListSortDirection.Ascending
            Else
                oldSortDir = ListSortDirection.Descending
            End If
        End If

        dataGrid.Columns.Clear()

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            With comando
                .CommandText = "SP_consulta_CC_Cliente"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("id_cliente", id_cliente)
                    .AddWithValue("id_cc", id_Cc)
                    .AddWithValue("fecha_desde", fecha_desde)
                    .AddWithValue("fecha_hasta", fecha_hasta)
                End With
                .Connection = CN
            End With

            da.SelectCommand = comando

            'llenar el dataset
            'da.Fill(datatable)
            'llenar el dataset
            'da.Fill(dataset)
            da.Fill(datatable) 'Obtengo todos los registros para poder saber cuantos tiene
            If Not traerTodo Then
                nRegs = datatable.Rows.Count
                tPaginas = Math.Ceiling(nRegs / itXPage)
                txtnPage.Text = pagina & " / " & tPaginas
                datatable.Clear()
                da.Fill(desde, itXPage, datatable) 'Cargo devuelta el datatable pero solo con los registros pedidos por página
            End If

            dataGrid.DataSource = datatable
            dataGrid.RowsDefaultCellStyle.BackColor = Color.White
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue

            'Inmovilizo las columnas
            Dim i As Integer = 0
            For Each columna As DataGridViewColumn In dataGrid.Columns
                dataGrid.Columns(columna.Name.ToString).DisplayIndex = i
                i = i + 1
            Next

            dataGrid.Height = dataGrid.Height + 1
            dataGrid.Height = dataGrid.Height - 1

            If dataGrid.Rows.Count > 0 Then
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            If oldSortColumn IsNot Nothing Then
                dataGrid.Sort(dataGrid.Columns(oldSortColumn.Name), oldSortDir)
            End If

            dataGrid.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            cerrardb()
        End Try
    End Sub

    Public Function consultaTotalCcCliente(ByVal id_cliente As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date) As String
        Dim sqlstr As String = ""
        Dim where As String = ""
        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
        Dim dt As New DataTable 'Crear nuevo dataset

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT DISTINCT SUM(t.total) AS 'Total' " &
                        "FROM transacciones As t " &
                        "INNER JOIN tipos_comprobantes AS tc ON t.id_tipoComprobante = tc.id_tipoComprobante " &
                        "INNER JOIN comprobantes AS c ON tc.id_tipoComprobante = c.id_tipoComprobante " &
                        "WHERE t.fecha BETWEEN '" + fecha_desde.ToString("MM/dd/yyyy") + "' AND '" + fecha_hasta.ToString("MM/dd/yyyy") + "' " &
                        "AND t.id_cliente = " + id_cliente.ToString + " " &
                        "AND c.contabilizar = 1"


            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dt)
            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return ""
        Finally
            cerrardb()
        End Try
    End Function
    ' ************************************ FUNCIONES DE CUENTAS CORRIENTES DE CLIENTES **********************
End Module

