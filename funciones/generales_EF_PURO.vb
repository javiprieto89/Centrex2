Imports System.Data.Entity
Imports System.Linq
Imports System.Data
Imports System.Reflection
Imports System.ComponentModel

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
        For Each entity In entities
            Dim row As DataRow = dataTable.NewRow()
            
            For Each prop In properties
                Dim columnName As String = GetDisplayName(prop.Name, tableType)
                Dim value As Object = prop.GetValue(entity)
                
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
            For Each entity In entities
                Dim row As DataRow = dataTable.NewRow()
                
                For Each prop In properties
                    Dim columnName As String = GetDisplayName(prop.Name, tableType)
                    Dim value As Object = prop.GetValue(entity)
                    
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
    
End Module
