Imports System.Data.SqlClient
Imports System.ComponentModel

Module proveedores
    ' ************************************ FUNCIONES DE PROVEEDORES ***************************
    Public Function info_proveedor(ByVal id_proveedor As String) As proveedor
        Dim tmp As New proveedor
        Dim sqlstr As String

        sqlstr = "SELECT p.id_proveedor, p.razon_social, p.taxNumber, p.contacto, p.telefono, p.celular, p.email, prof.id_pais AS 'id_pais_fiscal', p.id_provincia_fiscal, p.direccion_fiscal, p.localidad_fiscal, p.cp_fiscal, " &
                    "proe.id_pais AS 'id_pais_entrega', p.id_provincia_entrega, p.direccion_entrega, p.localidad_entrega, p.cp_entrega, p.notas, p.esInscripto, p.vendedor, p.activo, p.id_tipoDocumento, p.id_claseFiscal " &
                    "FROM proveedores AS p " &
                    "INNER JOIN provincias AS prof ON p.id_provincia_fiscal = prof.id_provincia " &
                    "INNER JOIN provincias AS proe ON p.id_provincia_entrega = proe.id_provincia " &
                    "WHERE p.id_proveedor = '" + id_proveedor + "'"

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
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.razon_social = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.taxNumber = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.contacto = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.telefono = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.celular = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.email = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_pais_fiscal = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.id_provincia_fiscal = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.direccion_fiscal = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.localidad_fiscal = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.cp_fiscal = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.id_pais_entrega = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.id_provincia_entrega = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.direccion_entrega = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.localidad_entrega = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.cp_entrega = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.esInscripto = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.vendedor = dataset.Tables("tabla").Rows(0).Item(19).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(20).ToString
            tmp.id_tipoDocumento = dataset.Tables("tabla").Rows(0).Item(21).ToString
            tmp.id_claseFiscal = dataset.Tables("tabla").Rows(0).Item(22).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.razon_social = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addproveedor(ByVal pr As proveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO proveedores (razon_social, taxNumber, contacto, telefono, celular, email, id_provincia_fiscal, direccion_fiscal, localidad_fiscal, cp_fiscal, " &
                        "id_provincia_entrega, direccion_entrega, localidad_entrega, cp_entrega, notas, esInscripto, vendedor, activo, id_tipoDocumento, id_claseFiscal) " &
                        "VALUES ('" + pr.razon_social + "', '" + pr.taxNumber + "', '" + pr.contacto + "', '" + pr.telefono + "', '" + pr.celular + "', '" + pr.email + "', '" + pr.id_provincia_fiscal.ToString +
                        "', '" + pr.direccion_fiscal + "', '" + pr.localidad_fiscal + "', '" + pr.cp_fiscal + "', '" + pr.id_provincia_entrega.ToString + "', '" + pr.direccion_entrega + "', '" + pr.localidad_entrega +
                        "', '" + pr.cp_entrega + "', '" + pr.notas + "', '" + pr.esInscripto.ToString + "', '" + pr.vendedor + "', '" + pr.activo.ToString + "', '" + pr.id_tipoDocumento.ToString +
                        "', '" + pr.id_claseFiscal.ToString + "')"

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

    Public Function updateProveedor(pr As proveedor, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE proveedores SET activo = '0' WHERE id_proveedor = '" + pr.id_proveedor.ToString + "'"
            Else
                sqlstr = "UPDATE proveedores SET razon_social = '" + pr.razon_social + "', taxNumber = '" + pr.taxNumber + "', contacto = '" + pr.contacto + "', telefono = '" _
                                                + pr.telefono + "', celular = '" + pr.celular + "', email = '" + pr.email + "', id_provincia_fiscal = '" _
                                                + pr.id_provincia_fiscal.ToString + "', direccion_fiscal = '" + pr.direccion_fiscal + "', localidad_fiscal = '" _
                                                + pr.localidad_fiscal + "', cp_fiscal = '" + pr.cp_fiscal + "', id_provincia_entrega = '" + pr.id_provincia_entrega.ToString + "', direccion_entrega = '" _
                                                + pr.direccion_entrega + "', localidad_entrega = '" + pr.localidad_entrega + "', cp_entrega = '" + pr.cp_entrega + "', notas = '" _
                                                + pr.notas + "', esInscripto = '" + pr.esInscripto.ToString + "', vendedor = '" + pr.vendedor + "', activo = '" _
                                                + pr.activo.ToString + "', id_tipoDocumento = '" + pr.id_tipoDocumento.ToString + "', id_claseFiscal = '" + pr.id_claseFiscal.ToString + "' " _
                                                + "WHERE id_proveedor = '" + pr.id_proveedor.ToString + "'"
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

    Public Function borrarproveedor(pr As proveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM proveedores WHERE id_proveedor = '" + pr.id_proveedor.ToString + "'", CN)
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

    Public Sub consultaCcProveedor(ByRef dataGrid As DataGridView, ByVal id_proveedor As Integer, ByVal id_Cc As Integer, ByVal fecha_desde As Date, ByVal fecha_hasta As Date, ByVal desde As Integer,
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
                .CommandText = "SP_consulta_CC_Proveedor"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("id_proveedor", id_proveedor)
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

    'Public Function info_proveedorVendedor(ByVal id_proveedor As String) As Integer
    '    Dim sqlstr As String
    '    Dim id_vendedor As Integer

    '    sqlstr = "SELECT p.id_vendedor " & _
    '                "FROM proveedores AS p " & _
    '                "WHERE p.id_vendedor = '" + id_proveedor + "'"

    '    Try
    '        'Crea y abre una nueva conexión
    '        abrirdb(serversql, basedb, usuariodb, passdb)

    '        'Propiedades del SqlCommand
    '        Dim comando As New SqlCommand
    '        With comando
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlstr
    '            .Connection = CN
    '        End With

    '        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
    '        Dim dataset As New DataSet 'Crear nuevo dataset

    '        da.SelectCommand = comando

    '        'llenar el dataset
    '        da.Fill(dataset, "Tabla")
    '        id_vendedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
    '        cerrardb()
    '        Return id_vendedor
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '        id_vendedor = -1
    '        cerrardb()
    '        Return id_vendedor
    '    End Try
    'End Function

    'Public Function existeproveedor(ByVal n As String, Optional ByVal a As String = "") As Integer
    '    Dim tmp As New proveedor

    '    Dim sqlstr As String
    '    sqlstr = "SELECT id_proveedor FROM proveedores WHERE razon_social LIKE '%" + Trim(n.ToString) + Trim(a.ToString) + "%'"

    '    Try
    '        'Crea y abre una nueva conexión
    '        abrirdb(serversql, basedb, usuariodb, passdb)

    '        'Propiedades del SqlCommand
    '        Dim comando As New SqlCommand
    '        With comando
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlstr
    '            .Connection = CN
    '        End With

    '        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
    '        Dim dataset As New DataSet 'Crear nuevo dataset

    '        da.SelectCommand = comando

    '        'llenar el dataset
    '        da.Fill(dataset, "Tabla")
    '        tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
    '        If tmp.id_proveedor = 0 Then Return -1
    '        cerrardb()
    '        Return tmp.id_proveedor
    '    Catch ex As Exception
    '        tmp.razon_social = "error"
    '        cerrardb()
    '        Return -1
    '    End Try
    'End Function
    ' ************************************ FUNCIONES DE PROVEEDORES ***************************
End Module
