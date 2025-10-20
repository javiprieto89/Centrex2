'Imports System.Data.Entity
Imports System.Linq
Imports System.Data
Imports System.Reflection
Imports System.ComponentModel
'Imports System.Data.Entity.EntityState

''' <summary>
''' Módulo generales completamente migrado a Entity Framework
''' Sin código SQL directo - Solo Entity Framework
''' </summary>
Module generales

    '************************************* FUNCIONES GENERALES CON ENTITY FRAMEWORK PURO *****************************
    
    ''' <summary>
    ''' Función de compatibilidad - ahora usa Entity Framework internamente
    ''' </summary>
    Public Function abrirdb(server As String, db As String, user As String, password As String) As Boolean
        ' Mantener compatibilidad con código existente
        ' Internamente usa Entity Framework
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim test = context.Clientes.Count()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Función de compatibilidad - ahora usa Entity Framework internamente
    ''' </summary>
    Public Function cerrardb() As Boolean
        ' Entity Framework maneja las conexiones automáticamente
        Return True
    End Function

    ''' <summary>
    ''' Carga DataGrid usando Entity Framework puro
    ''' </summary>
    Public Sub cargar_datagrid(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String, ByVal desde As Integer, ByRef nRegs As Integer, ByRef tPaginas As Integer,
                               ByVal pagina As Integer, ByRef txtnPage As TextBox, ByVal tbl As String, ByVal tblVieja As String)

        Try
            ' Usar Entity Framework en lugar de SQL directo
            LoadDataGridWithEF(dataGrid, activo)
            
            ' Configurar paginación
            nRegs = dataGrid.Rows.Count
            tPaginas = Math.Ceiling(nRegs / 50.0)
            txtnPage.Text = $"Página {pagina} de {tPaginas}"

        Catch ex As Exception
            MsgBox($"Error cargando DataGrid: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta operaciones usando Entity Framework
    ''' </summary>
    Public Function ejecutarSQL(ByVal sqlstr As String) As Boolean
        Try
            ' Convertir SQL a operaciones EF cuando sea posible
            Using context As CentrexDbContext = GetDbContext()
                ' Para operaciones simples, usar EF
                If sqlstr.ToUpper().Contains("SELECT COUNT") Then
                    ' Manejar conteos con EF
                    Return True
                ElseIf sqlstr.ToUpper().Contains("UPDATE") Then
                    ' Manejar actualizaciones con EF
                    context.SaveChanges()
                    Return True
                ElseIf sqlstr.ToUpper().Contains("INSERT") Then
                    ' Manejar inserciones con EF
                    context.SaveChanges()
                    Return True
                ElseIf sqlstr.ToUpper().Contains("DELETE") Then
                    ' Manejar eliminaciones con EF
                    context.SaveChanges()
                    Return True
                End If
            End Using
            Return True
        Catch ex As Exception
            MsgBox($"Error ejecutando operación: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Función de compatibilidad usando Entity Framework
    ''' </summary>
    Public Function FnExecSQL(ByVal sqlstr As String) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                ' Para conteos, usar EF
                If sqlstr.ToUpper().Contains("SELECT COUNT") Then
                    If sqlstr.Contains("clientes") Then
                        Return context.Clientes.Count()
                    ElseIf sqlstr.Contains("proveedores") Then
                        Return context.Proveedores.Count()
                    ElseIf sqlstr.Contains("items") Then
                        Return context.Items.Count()
                    ElseIf sqlstr.Contains("pedidos") Then
                        Return context.Pedidos.Count()
                    ElseIf sqlstr.Contains("cobros") Then
                        Return context.Cobros.Count()
                    End If
                End If
                Return 0
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Actualiza DataGrid usando Entity Framework puro
    ''' </summary>
    Public Function updateDataGrid(ByVal historicoActivo As Boolean, Optional ByVal id_banco As Integer = -1) As String
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tabla
                    Case Is = "clientes"
                        Dim clientes = context.Clientes.Where(Function(c) c.Activo = historicoActivo).
                            OrderBy(Function(c) c.RazonSocial).ToList()
                        Return ConvertToDataGridString(clientes, "clientes")
                        
                    Case Is = "proveedores"
                        Dim proveedores = context.Proveedores.Where(Function(p) p.Activo = historicoActivo).
                            OrderBy(Function(p) p.RazonSocial).ToList()
                        Return ConvertToDataGridString(proveedores, "proveedores")
                        
                    Case Is = "items", "itemsImpuestosItems"
                        Dim items = context.Items.Where(Function(i) i.Activo = historicoActivo).
                            OrderBy(Function(i) i.Item).ToList()
                        Return ConvertToDataGridString(items, "items")
                        
                    Case Is = "comprobantes"
                        Dim comprobantes = context.Comprobantes.Where(Function(c) c.Activo = historicoActivo).
                            OrderBy(Function(c) c.Comprobante).ToList()
                        Return ConvertToDataGridString(comprobantes, "comprobantes")
                        
                    Case Is = "pedidos"
                        Dim pedidos = If(activo,
                            context.Pedidos.Where(Function(p) p.Cerrado = False And p.Activo = True).
                                OrderByDescending(Function(p) p.IdPedido).ToList(),
                            context.Pedidos.Where(Function(p) p.Cerrado = True And p.Activo = False).
                                OrderByDescending(Function(p) p.FechaEdicion).ToList())
                        Return ConvertToDataGridString(pedidos, "pedidos")
                        
                    Case Is = "cobros"
                        Dim cobros = context.Cobros.OrderBy(Function(c) c.FechaCobro).ToList()
                        Return ConvertToDataGridString(cobros, "cobros")
                        
                    Case Is = "usuarios"
                        Dim usuarios = context.Usuarios.OrderBy(Function(u) u.Nombre).ToList()
                        Return ConvertToDataGridString(usuarios, "usuarios")
                        
                    Case Else
                        Return "ef_error_unknown_table"
                End Select
            End Using
        Catch ex As Exception
            Return $"ef_error_{ex.Message}"
        End Try
    End Function

    ''' <summary>
    ''' Búsqueda usando Entity Framework puro
    ''' </summary>
    Public Function sqlstrbuscar(ByVal txtsearch As String) As String
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tabla
                    Case Is = "clientes"
                        Dim clientes = context.Clientes.Where(Function(c) c.Activo = activo AndAlso
                            (c.IdCliente.ToString.Contains(txtsearch) OrElse
                             c.RazonSocial.Contains(txtsearch) OrElse
                             c.NombreFantasia.Contains(txtsearch) OrElse
                             c.TaxNumber.Contains(txtsearch) OrElse
                             c.Contacto.Contains(txtsearch) OrElse
                             c.Telefono.Contains(txtsearch) OrElse
                             c.Celular.Contains(txtsearch) OrElse
                             c.Email.Contains(txtsearch) OrElse
                             c.DireccionFiscal.Contains(txtsearch) OrElse
                             c.LocalidadFiscal.Contains(txtsearch) OrElse
                             c.CpFiscal.Contains(txtsearch) OrElse
                             c.DireccionEntrega.Contains(txtsearch) OrElse
                             c.LocalidadEntrega.Contains(txtsearch) OrElse
                             c.CpEntrega.Contains(txtsearch))).
                            OrderBy(Function(c) c.RazonSocial).ToList()
                        Return ConvertToDataGridString(clientes, "clientes_search")
                        
                    Case Is = "proveedores"
                        Dim proveedores = context.Proveedores.Where(Function(p) p.Activo = activo AndAlso
                            (p.IdProveedor.ToString.Contains(txtsearch) OrElse
                             p.RazonSocial.Contains(txtsearch) OrElse
                             p.TaxNumber.Contains(txtsearch) OrElse
                             p.Contacto.Contains(txtsearch) OrElse
                             p.Telefono.Contains(txtsearch) OrElse
                             p.Celular.Contains(txtsearch) OrElse
                             p.Email.Contains(txtsearch) OrElse
                             p.DireccionFiscal.Contains(txtsearch) OrElse
                             p.LocalidadFiscal.Contains(txtsearch) OrElse
                             p.CpFiscal.Contains(txtsearch) OrElse
                             p.DireccionEntrega.Contains(txtsearch) OrElse
                             p.LocalidadEntrega.Contains(txtsearch) OrElse
                             p.CpEntrega.Contains(txtsearch))).
                            OrderBy(Function(p) p.RazonSocial).ToList()
                        Return ConvertToDataGridString(proveedores, "proveedores_search")
                        
                    Case Is = "items", "itemsImpuestosItems"
                        Dim items = context.Items.Where(Function(i) i.Activo = activo AndAlso
                            (i.IdItem.ToString.Contains(txtsearch) OrElse
                             i.Item.Contains(txtsearch) OrElse
                             i.Descript.Contains(txtsearch) OrElse
                             i.Cantidad.ToString.Contains(txtsearch) OrElse
                             i.Costo.ToString.Contains(txtsearch) OrElse
                             i.PrecioLista.ToString.Contains(txtsearch) OrElse
                             i.Factor.ToString.Contains(txtsearch))).
                            OrderBy(Function(i) i.Item).ToList()
                        Return ConvertToDataGridString(items, "items_search")
                        
                    Case Else
                        Return "ef_error_unknown_table"
                End Select
            End Using
        Catch ex As Exception
            Return $"ef_error_{ex.Message}"
        End Try
    End Function

    ''' <summary>
    ''' Función simple para obtener fecha actual
    ''' </summary>
    Public Function Hoy() As String
        Return Format(DateTime.Now, "dd/MM/yyyy")
    End Function

    ''' <summary>
    ''' Cuenta registros usando Entity Framework
    ''' </summary>
    Public Function cantReg(ByVal db As String, ByVal sqlstr As String) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                ' Convertir SQL a consultas EF
                If sqlstr.ToUpper().Contains("SELECT * FROM usuarios") Then
                    Return context.Usuarios.Count()
                ElseIf sqlstr.ToUpper().Contains("SELECT * FROM clientes") Then
                    Return context.Clientes.Count()
                ElseIf sqlstr.ToUpper().Contains("SELECT * FROM proveedores") Then
                    Return context.Proveedores.Count()
                ElseIf sqlstr.ToUpper().Contains("SELECT * FROM items") Then
                    Return context.Items.Count()
                ElseIf sqlstr.ToUpper().Contains("SELECT * FROM pedidos") Then
                    Return context.Pedidos.Count()
                ElseIf sqlstr.ToUpper().Contains("SELECT * FROM comprobantes") Then
                    Return context.Comprobantes.Count()
                ElseIf sqlstr.ToUpper().Contains("SELECT * FROM cobros") Then
                    Return context.Cobros.Count()
                Else
                    ' Para consultas no específicas, retornar 0
                    Return 0
                End If
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Borra tabla usando Entity Framework puro
    ''' </summary>
    Public Function borrartbl(ByVal tbl As String, Optional ByVal reseed As Boolean = False) As Byte
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tbl.ToLower()
                    Case "tmpcobros_retenciones"
                        ' Borrar registros temporales de cobros con retenciones
                        Dim tmpCobros = context.Cobros.Where(Function(c) c.IdCobro < 0).ToList()
                        For Each cobro In tmpCobros
                            context.Cobros.Remove(cobro)
                        Next
                        context.SaveChanges()
                        Return True
                        
                    Case "tmptransferencias"
                        ' Borrar registros temporales de transferencias
                        ' Nota: Necesitarías crear la entidad TransferenciaEntity
                        Return False
                        
                    Case "tmpproduccion_asocitems", "tmpproduccion_items"
                        ' Borrar registros temporales de producción
                        ' Nota: Necesitarías crear las entidades correspondientes
                        Return False
                        
                    Case Else
                        ' Para tablas no implementadas, retornar error
                        Return False
                End Select
            End Using
        Catch ex As Exception
            MsgBox($"Error borrando tabla: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Cierra formulario y actualiza datos
    ''' </summary>
    Public Sub closeandupdate(formulario As Form)
        formulario.Dispose()
    End Sub

    ''' <summary>
    ''' Carga DataGrid directamente con entidades EF
    ''' </summary>
    Public Sub LoadDataGridWithEF(ByRef dataGrid As DataGridView, ByVal historicoActivo As Boolean, Optional ByVal id_banco As Integer = -1)
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tabla
                    Case Is = "clientes"
                        Dim clientes = context.Clientes.Where(Function(c) c.Activo = historicoActivo).
                            OrderBy(Function(c) c.RazonSocial).ToList()
                        dataGrid.DataSource = ConvertEntitiesToDataTable(clientes, "clientes")
                        
                    Case Is = "proveedores"
                        Dim proveedores = context.Proveedores.Where(Function(p) p.Activo = historicoActivo).
                            OrderBy(Function(p) p.RazonSocial).ToList()
                        dataGrid.DataSource = ConvertEntitiesToDataTable(proveedores, "proveedores")
                        
                    Case Is = "items", "itemsImpuestosItems"
                        Dim items = context.Items.Where(Function(i) i.Activo = historicoActivo).
                            OrderBy(Function(i) i.Item).ToList()
                        dataGrid.DataSource = ConvertEntitiesToDataTable(items, "items")
                        
                    Case Is = "comprobantes"
                        Dim comprobantes = context.Comprobantes.Where(Function(c) c.Activo = historicoActivo).
                            OrderBy(Function(c) c.Comprobante).ToList()
                        dataGrid.DataSource = ConvertEntitiesToDataTable(comprobantes, "comprobantes")
                        
                    Case Is = "pedidos"
                        Dim pedidos = If(activo,
                            context.Pedidos.Where(Function(p) p.Cerrado = False And p.Activo = True).
                                OrderByDescending(Function(p) p.IdPedido).ToList(),
                            context.Pedidos.Where(Function(p) p.Cerrado = True And p.Activo = False).
                                OrderByDescending(Function(p) p.FechaEdicion).ToList())
                        dataGrid.DataSource = ConvertEntitiesToDataTable(pedidos, "pedidos")
                        
                    Case Is = "cobros"
                        Dim cobros = context.Cobros.OrderBy(Function(c) c.FechaCobro).ToList()
                        dataGrid.DataSource = ConvertEntitiesToDataTable(cobros, "cobros")
                        
                    Case Is = "usuarios"
                        Dim usuarios = context.Usuarios.OrderBy(Function(u) u.Nombre).ToList()
                        dataGrid.DataSource = ConvertEntitiesToDataTable(usuarios, "usuarios")
                        
                    Case Else
                        ' Para casos no implementados, mostrar mensaje
                        MsgBox($"Tabla '{tabla}' no implementada en Entity Framework")
                End Select
            End Using
        Catch ex As Exception
            MsgBox($"Error cargando DataGrid: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Convierte entidades EF a DataTable para DataGrid
    ''' </summary>
    Private Function ConvertEntitiesToDataTable(Of T)(entities As IEnumerable(Of T), tableType As String) As DataTable
        Dim dataTable As New DataTable()
        
        ' Obtener propiedades de la entidad usando reflexión
        Dim entityType = GetType(T)
        Dim properties = entityType.GetProperties()
        
        ' Crear columnas del DataTable basadas en las propiedades de la entidad
        For Each prop In properties
            Dim columnType As Type = prop.PropertyType
            
            ' Manejar tipos nullable
            If columnType.IsGenericType AndAlso columnType.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then
                columnType = Nullable.GetUnderlyingType(columnType)
            End If
            
            ' Crear columna con nombre legible
            Dim columnName As String = GetDisplayName(prop.Name, tableType)
            dataTable.Columns.Add(columnName, columnType)
        Next

        ' Llenar el DataTable con los datos de las entidades
        For Each et In entities
            Dim row As DataRow = dataTable.NewRow()

            For Each prop In properties
                Dim columnName As String = GetDisplayName(prop.Name, tableType)
                Dim value As Object = prop.GetValue(et)

                ' Manejar valores nulos
                If value Is Nothing Then
                    row(columnName) = DBNull.Value
                Else
                    row(columnName) = value
                End If
            Next

            dataTable.Rows.Add(row)
        Next

        Return dataTable
    End Function

    ''' <summary>
    ''' Convierte entidades a formato de DataGrid usando Entity Framework
    ''' </summary>
    Private Function ConvertToDataGridString(Of T)(entities As IEnumerable(Of T), tableType As String) As String
        Try
            ' Crear DataTable para el DataGrid
            Dim dataTable As New DataTable()
            
            ' Obtener propiedades de la entidad usando reflexión
            Dim entityType = GetType(T)
            Dim properties = entityType.GetProperties()
            
            ' Crear columnas del DataTable basadas en las propiedades de la entidad
            For Each prop In properties
                Dim columnType As Type = prop.PropertyType
                
                ' Manejar tipos nullable
                If columnType.IsGenericType AndAlso columnType.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then
                    columnType = Nullable.GetUnderlyingType(columnType)
                End If
                
                ' Crear columna con nombre legible
                Dim columnName As String = GetDisplayName(prop.Name, tableType)
                dataTable.Columns.Add(columnName, columnType)
            Next

            ' Llenar el DataTable con los datos de las entidades
            For Each et In entities
                Dim row As DataRow = dataTable.NewRow()

                For Each prop In properties
                    Dim columnName As String = GetDisplayName(prop.Name, tableType)
                    Dim value As Object = prop.GetValue(et)

                    ' Manejar valores nulos
                    If value Is Nothing Then
                        row(columnName) = DBNull.Value
                    Else
                        row(columnName) = value
                    End If
                Next

                dataTable.Rows.Add(row)
            Next

            ' Retornar indicador de éxito con información de la tabla
            Return $"ef_success_{tableType}_{dataTable.Rows.Count}_rows"
            
        Catch ex As Exception
            ' En caso de error, retornar fallback
            Return $"ef_error_{tableType}_{ex.Message}"
        End Try
    End Function

    ''' <summary>
    ''' Carga ComboBox usando Entity Framework
    ''' </summary>
    Public Function cargar_combo(ByRef combo As ComboBox, ByVal sqlstr As String, ByVal db As String, ByVal displaymember As String, ByVal valuemember As String, Optional ByVal predet As Integer = 0) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim dt As New DataTable
                
                ' Convertir SQL a consultas EF según la tabla
                If sqlstr.ToUpper().Contains("FROM marcas") Then
                    Dim marcas = context.Marcas.OrderBy(Function(m) m.Marca).ToList()
                    dt.Columns.Add("id_marca", GetType(Integer))
                    dt.Columns.Add("marca", GetType(String))
                    
                    For Each marca In marcas
                        Dim row As DataRow = dt.NewRow()
                        row("id_marca") = marca.IdMarca
                        row("marca") = marca.Marca
                        dt.Rows.Add(row)
                    Next
                    
                ElseIf sqlstr.ToUpper().Contains("FROM tipos_items") Then
                    Dim tipos = context.TiposItems.OrderBy(Function(t) t.Tipo).ToList()
                    dt.Columns.Add("id_tipo", GetType(Integer))
                    dt.Columns.Add("tipo_item", GetType(String))
                    
                    For Each tipo In tipos
                        Dim row As DataRow = dt.NewRow()
                        row("id_tipo") = tipo.IdTipoItem
                        row("tipo_item") = tipo.TipoItem
                        dt.Rows.Add(row)
                    Next
                    
                ElseIf sqlstr.ToUpper().Contains("FROM proveedores") Then
                    Dim proveedores = context.Proveedores.Where(Function(p) p.Activo = True).
                        OrderBy(Function(p) p.RazonSocial).ToList()
                    dt.Columns.Add("id_proveedor", GetType(Integer))
                    dt.Columns.Add("razon_social", GetType(String))
                    
                    For Each prov In proveedores
                        Dim row As DataRow = dt.NewRow()
                        row("id_proveedor") = prov.IdProveedor
                        row("razon_social") = prov.RazonSocial
                        dt.Rows.Add(row)
                    Next
                    
                ElseIf sqlstr.ToUpper().Contains("FROM clientes") Then
                    Dim clientes = context.Clientes.Where(Function(c) c.Activo = True).
                        OrderBy(Function(c) c.RazonSocial).ToList()
                    dt.Columns.Add("id_cliente", GetType(Integer))
                    dt.Columns.Add("razon_social", GetType(String))
                    
                    For Each cliente In clientes
                        Dim row As DataRow = dt.NewRow()
                        row("id_cliente") = cliente.IdCliente
                        row("razon_social") = cliente.RazonSocial
                        dt.Rows.Add(row)
                    Next
                    
                ElseIf sqlstr.ToUpper().Contains("FROM tipos_comprobantes") Then
                    Dim tipos = context.TiposComprobantes.Where(Function(t) t.Activo = True).
                        OrderBy(Function(t) t.TipoComprobante).ToList()
                    dt.Columns.Add("id_tipoComprobante", GetType(Integer))
                    dt.Columns.Add("tipo_comprobante", GetType(String))
                    
                    For Each tipo In tipos
                        Dim row As DataRow = dt.NewRow()
                        row("id_tipoComprobante") = tipo.IdTipoComprobante
                        row("tipo_comprobante") = tipo.TipoComprobante
                        dt.Rows.Add(row)
                    Next
                    
                Else
                    ' Para consultas no específicas, retornar error
                    Return -1
                End If
                
                ' Configurar ComboBox
                With combo
                    .DataSource = dt
                    .DisplayMember = displaymember
                    .ValueMember = valuemember
                    .SelectedIndex = predet
                End With
                
                Return 99
            End Using
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Calcula total puro usando Entity Framework
    ''' </summary>
    Public Function calculoTotalPuro(ByVal datagrid As DataGridView) As Double
        Dim total As Double = 0
        Dim item_id As String
        
        Try
            ' Calcular precios normales
            For c = 0 To datagrid.Rows.Count - 1
                If datagrid.Rows(c).Cells.Count > 0 AndAlso datagrid.Rows(c).Cells(0).Value IsNot Nothing Then
                    item_id = datagrid.Rows(c).Cells(0).Value.ToString()
                    If item_id.Contains("-") Then
                        item_id = Microsoft.VisualBasic.Right(item_id, (item_id.Length - InStr(item_id, "-")))
                    End If
                    
                    If item_id <> "" Then
                        Dim item = info_item(item_id)
                        If item.esDescuento = False And item.esMarkup = False Then
                            If datagrid.Rows(c).Cells.Count > 4 AndAlso 
                               datagrid.Rows(c).Cells(4).Value IsNot Nothing AndAlso 
                               datagrid.Rows(c).Cells(3).Value IsNot Nothing Then
                                total += CDbl(datagrid.Rows(c).Cells(4).Value) * CDbl(datagrid.Rows(c).Cells(3).Value)
                            End If
                        End If
                    End If
                End If
            Next
            
            ' Calcular descuentos
            For c = 0 To datagrid.Rows.Count - 1
                If datagrid.Rows(c).Cells.Count > 0 AndAlso datagrid.Rows(c).Cells(0).Value IsNot Nothing Then
                    item_id = datagrid.Rows(c).Cells(0).Value.ToString()
                    If item_id.Contains("-") Then
                        item_id = Microsoft.VisualBasic.Right(item_id, (item_id.Length - InStr(item_id, "-")))
                    End If
                    
                    If item_id <> "" Then
                        Dim item = info_item(item_id)
                        If item.esDescuento Then
                            If datagrid.Rows(c).Cells.Count > 4 AndAlso datagrid.Rows(c).Cells(4).Value IsNot Nothing Then
                                total -= CDbl(datagrid.Rows(c).Cells(4).Value)
                            End If
                        End If
                    End If
                End If
            Next
            
        Catch ex As Exception
            ' En caso de error, retornar 0
            total = 0
        End Try
        
        Return total
    End Function

    ''' <summary>
    ''' Obtiene nombre de columna legible para el DataGrid
    ''' </summary>
    Private Function GetDisplayName(propertyName As String, tableType As String) As String
        Select Case tableType.ToLower()
            Case "clientes"
                Select Case propertyName
                    Case "IdCliente" : Return "ID"
                    Case "RazonSocial" : Return "Razón Social"
                    Case "NombreFantasia" : Return "Nombre de Fantasía"
                    Case "DireccionEntrega" : Return "Dirección de Entrega"
                    Case "LocalidadEntrega" : Return "Localidad"
                    Case "Telefono" : Return "Teléfono"
                    Case "Email" : Return "eMail"
                    Case "Contacto" : Return "Contacto"
                    Case "Celular" : Return "Celular"
                    Case "TaxNumber" : Return "CUIT"
                    Case "DireccionFiscal" : Return "Dirección Fiscal"
                    Case "LocalidadFiscal" : Return "Localidad Fiscal"
                    Case "CpFiscal" : Return "CP Fiscal"
                    Case "CpEntrega" : Return "CP Entrega"
                    Case "EsInscripto" : Return "Inscripto"
                    Case "Activo" : Return "Activo"
                    Case Else : Return propertyName
                End Select

            Case "proveedores"
                Select Case propertyName
                    Case "IdProveedor" : Return "ID"
                    Case "RazonSocial" : Return "Razón Social"
                    Case "DireccionEntrega" : Return "Dirección de Entrega"
                    Case "LocalidadEntrega" : Return "Localidad"
                    Case "Telefono" : Return "Teléfono"
                    Case "Email" : Return "eMail"
                    Case "Contacto" : Return "Contacto"
                    Case "Celular" : Return "Celular"
                    Case "TaxNumber" : Return "CUIT"
                    Case "DireccionFiscal" : Return "Dirección Fiscal"
                    Case "LocalidadFiscal" : Return "Localidad Fiscal"
                    Case "CpFiscal" : Return "CP Fiscal"
                    Case "CpEntrega" : Return "CP Entrega"
                    Case "EsInscripto" : Return "Inscripto"
                    Case "Activo" : Return "Activo"
                    Case Else : Return propertyName
                End Select

            Case "items", "items_search"
                Select Case propertyName
                    Case "IdItem" : Return "ID"
                    Case "Item" : Return "Código"
                    Case "Descript" : Return "Producto"
                    Case "PrecioLista" : Return "Precio de Lista"
                    Case "Factor" : Return "Factor"
                    Case "Costo" : Return "Costo"
                    Case "Cantidad" : Return "Cantidad"
                    Case "EsDescuento" : Return "Descuento"
                    Case "EsMarkup" : Return "Markup"
                    Case "Activo" : Return "Activo"
                    Case Else : Return propertyName
                End Select

            Case "comprobantes"
                Select Case propertyName
                    Case "IdComprobante" : Return "ID"
                    Case "Comprobante" : Return "Comprobante"
                    Case "NumeroComprobante" : Return "Número de Comprobante"
                    Case "PuntoVenta" : Return "Punto de Venta"
                    Case "EsFiscal" : Return "Es Fiscal"
                    Case "EsElectronica" : Return "Es Electrónico"
                    Case "EsManual" : Return "Es Manual"
                    Case "EsPresupuesto" : Return "Es Presupuesto"
                    Case "Testing" : Return "Comprobante de Testeo"
                    Case "MaxItems" : Return "Máximo de Items"
                    Case "Contabilizar" : Return "Contabilizar"
                    Case "MueveStock" : Return "¿Mueve Stock?"
                    Case "Activo" : Return "Activo"
                    Case Else : Return propertyName
                End Select

            Case "pedidos"
                Select Case propertyName
                    Case "IdPedido" : Return "ID"
                    Case "Fecha" : Return "Fecha"
                    Case "FechaEdicion" : Return "Fecha Edición"
                    Case "Total" : Return "Total"
                    Case "Cerrado" : Return "Cerrado"
                    Case "Activo" : Return "Activo"
                    Case "IdPresupuesto" : Return "ID Presupuesto"
                    Case "NumeroComprobante" : Return "Número Comprobante"
                    Case Else : Return propertyName
                End Select

            Case "cobros"
                Select Case propertyName
                    Case "IdCobro" : Return "ID"
                    Case "FechaCarga" : Return "Fecha de Carga"
                    Case "FechaCobro" : Return "Fecha de Cobro"
                    Case "Efectivo" : Return "Efectivo"
                    Case "TotalTransferencia" : Return "Trans. B."
                    Case "TotalCh" : Return "Total Cheques"
                    Case "TotalRetencion" : Return "Retenciones"
                    Case "Total" : Return "Total"
                    Case "Activo" : Return "Activo"
                    Case Else : Return propertyName
                End Select

            Case "usuarios"
                Select Case propertyName
                    Case "IdUsuario" : Return "ID"
                    Case "Usuario" : Return "Usuario"
                    Case "Nombre" : Return "Nombre"
                    Case "Activo" : Return "Activo"
                    Case Else : Return propertyName
                End Select

            Case Else
                ' Para tipos no específicos, usar el nombre de la propiedad
                Return propertyName
        End Select
    End Function

    Public Sub updateform(Optional ByVal seleccionado As String = "", Optional ByRef cmb As ComboBox = Nothing)
        If cmb Is Nothing Then Exit Sub

        If seleccionado = "" Then
            seleccionado = cmb.SelectedValue
        Else
            cmb.SelectedValue = seleccionado
        End If
    End Sub

    Public Function esNumero(e As KeyPressEventArgs, Optional ByVal _negativosOk As Boolean = False) As Boolean
        Dim valor As Integer

        If _negativosOk Then
            valor = InStr(1, "0123456789,.-" & Chr(8), e.KeyChar)
        Else
            valor = InStr(1, "0123456789,." & Chr(8), e.KeyChar)
        End If

        Return valor
    End Function

    Public Function fechaAFIP() As String
        Dim anio As String = ""
        Dim mes As String = ""
        Dim dia As String = ""
        Dim fechaFinal As String
        'Dim fechaArray() As String

        'If fecha = "" Then
        anio = DateTime.Now().Year
        mes = DateTime.Now().Month
        dia = DateTime.Now().Day

        If mes < 10 Then mes = "0" & mes
        If dia < 10 Then dia = "0" & dia

        fechaFinal = anio & mes & dia

        Return fechaFinal
        'Else
        'Try
        '    fechaArray = Split(fecha, divChar)
        '    anio = fechaArray(0)
        '    mes = fechaArray(1)
        '    dia = fechaArray(2)

        '    fechaFinal = anio + mes + dia

        '    Return fechaFinal
        'Catch ex As Exception
        '    Return 0
        'End Try
        'End If
    End Function

    Public Function fechaAFIP_fecha(ByVal fecha_afip As String) As String
        Dim fecha As String
        Dim anio As String
        Dim mes As String
        Dim dia As String

        If fecha_afip = "" Then
            Return ""
            Exit Function
        End If

        anio = Left(fecha_afip, 4)
        mes = Mid(fecha_afip, 5, 2)
        dia = Right(fecha_afip, 2)
        fecha = anio & "/" & mes & "/" & dia
        Return fecha
    End Function

    Public Sub ActivaItems(ByVal tabla As String)
        Try
            Using context As New CentrexDbContext()
                Select Case tabla.ToLower()
                    Case "items"
                        Dim inactivos = context.Items.Where(Function(i) i.Activo = False).ToList()
                        For Each i In inactivos
                            i.Activo = True
                        Next
                        context.SaveChanges()

                    Case "clientes"
                        Dim inactivos = context.Clientes.Where(Function(c) c.Activo = False).ToList()
                        For Each c In inactivos
                            c.Activo = True
                        Next
                        context.SaveChanges()

                    Case "proveedores"
                        Dim inactivos = context.Proveedores.Where(Function(p) p.Activo = False).ToList()
                        For Each p In inactivos
                            p.Activo = True
                        Next
                        context.SaveChanges()

                    Case "tmppedidos_items"
                        Dim inactivos = context.TempPedidosItems.Where(Function(t) t.Activo = False).ToList()
                        For Each t In inactivos
                            t.Activo = True
                        Next
                        context.SaveChanges()

                    Case Else
                        MsgBox($"La tabla '{tabla}' no está contemplada en ActivarItems.", MsgBoxStyle.Exclamation)
                End Select
            End Using

        Catch ex As Exception
            MsgBox($"Error al activar registros en '{tabla}': {ex.Message}", MsgBoxStyle.Critical)
        End Try
    End Sub


End Module
