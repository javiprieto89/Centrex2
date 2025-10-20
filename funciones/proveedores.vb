Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Data.Entity
Imports System.Linq

Module proveedores
    ' ************************************ FUNCIONES DE PROVEEDORES ***************************
    Public Function info_proveedor(ByVal id_proveedor As String) As proveedor
        Dim tmp As New proveedor
        
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim proveedorEntity = context.Proveedores.Include(Function(p) p.ProvinciaFiscal) _
                    .Include(Function(p) p.ProvinciaEntrega) _
                    .FirstOrDefault(Function(p) p.IdProveedor = CInt(id_proveedor))
                
                If proveedorEntity IsNot Nothing Then
                    tmp.id_proveedor = proveedorEntity.IdProveedor.ToString()
                    tmp.razon_social = proveedorEntity.RazonSocial
                    tmp.taxNumber = proveedorEntity.TaxNumber
                    tmp.contacto = proveedorEntity.Contacto
                    tmp.telefono = proveedorEntity.Telefono
                    tmp.celular = proveedorEntity.Celular
                    tmp.email = proveedorEntity.Email
                    tmp.id_pais_fiscal = proveedorEntity.IdPaisFiscal
                    tmp.id_provincia_fiscal = proveedorEntity.IdProvinciaFiscal
                    tmp.direccion_fiscal = proveedorEntity.DireccionFiscal
                    tmp.localidad_fiscal = proveedorEntity.LocalidadFiscal
                    tmp.cp_fiscal = proveedorEntity.CpFiscal
                    tmp.id_pais_entrega = proveedorEntity.IdPaisEntrega
                    tmp.id_provincia_entrega = proveedorEntity.IdProvinciaEntrega
                    tmp.direccion_entrega = proveedorEntity.DireccionEntrega
                    tmp.localidad_entrega = proveedorEntity.LocalidadEntrega
                    tmp.cp_entrega = proveedorEntity.CpEntrega
                    tmp.notas = proveedorEntity.Notas
                    tmp.esInscripto = proveedorEntity.EsInscripto
                    tmp.vendedor = proveedorEntity.Vendedor
                    tmp.activo = proveedorEntity.Activo
                    tmp.id_tipoDocumento = proveedorEntity.IdTipoDocumento
                    tmp.id_claseFiscal = proveedorEntity.IdClaseFiscal
                Else
                    tmp.razon_social = "error"
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.razon_social = "error"
        End Try
        
        Return tmp
    End Function

    Public Function addproveedor(ByVal pr As proveedor) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim proveedorEntity As New ProveedorEntity()
                
                With proveedorEntity
                    .RazonSocial = pr.razon_social
                    .TaxNumber = pr.taxNumber
                    .Contacto = pr.contacto
                    .Telefono = pr.telefono
                    .Celular = pr.celular
                    .Email = pr.email
                    .IdProvinciaFiscal = pr.id_provincia_fiscal
                    .DireccionFiscal = pr.direccion_fiscal
                    .LocalidadFiscal = pr.localidad_fiscal
                    .CpFiscal = pr.cp_fiscal
                    .IdProvinciaEntrega = pr.id_provincia_entrega
                    .DireccionEntrega = pr.direccion_entrega
                    .LocalidadEntrega = pr.localidad_entrega
                    .CpEntrega = pr.cp_entrega
                    .Notas = pr.notas
                    .EsInscripto = pr.esInscripto
                    .Vendedor = pr.vendedor
                    .Activo = pr.activo
                    .IdTipoDocumento = pr.id_tipoDocumento
                    .IdClaseFiscal = pr.id_claseFiscal
                End With
                
                context.Proveedores.Add(proveedorEntity)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
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
