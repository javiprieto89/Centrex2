Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.Entity
Imports System.Linq

''' <summary>
''' Módulo para manejar operaciones de base de datos específicas del formulario principal
''' Ahora usa Entity Framework en lugar de SQL directo
''' </summary>
Module MainDatabaseOperations
    
    ''' <summary>
    ''' Carga los datos del DataGridView principal usando Entity Framework
    ''' </summary>
    Public Sub LoadMainDataGrid(grid As DataGridView, tableName As String, Optional filters As String = "")
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim data As IQueryable
                
                Select Case tableName.ToLower()
                    Case "clientes"
                        data = context.Clientes.Include(Function(c) c.ProvinciaFiscal).Include(Function(c) c.ProvinciaEntrega)
                        If Not String.IsNullOrEmpty(filters) Then
                            data = data.Where(Function(c) c.RazonSocial.Contains(filters) OrElse c.NombreFantasia.Contains(filters))
                        End If
                        data = data.OrderByDescending(Function(c) c.IdCliente)
                        
                    Case "items"
                        data = context.Items.Include(Function(i) i.Marca).Include(Function(i) i.Tipo).Include(Function(i) i.Proveedor)
                        If Not String.IsNullOrEmpty(filters) Then
                            data = data.Where(Function(i) i.Descript.Contains(filters) OrElse i.Item.Contains(filters))
                        End If
                        data = data.OrderByDescending(Function(i) i.IdItem)
                        
                    Case "pedidos"
                        data = context.Pedidos.Include(Function(p) p.Cliente).Include(Function(p) p.Comprobante).Include(Function(p) p.TipoComprobante)
                        If Not String.IsNullOrEmpty(filters) Then
                            data = data.Where(Function(p) p.Cliente.RazonSocial.Contains(filters))
                        End If
                        data = data.OrderByDescending(Function(p) p.IdPedido)
                        
                    Case "proveedores"
                        data = context.Proveedores
                        If Not String.IsNullOrEmpty(filters) Then
                            data = data.Where(Function(p) p.RazonSocial.Contains(filters) OrElse p.NombreFantasia.Contains(filters))
                        End If
                        data = data.OrderByDescending(Function(p) p.IdProveedor)
                        
                    Case Else
                        ' Fallback to SQL for unknown tables
                        Dim sql As String = $"SELECT * FROM {tableName}"
                        If Not String.IsNullOrEmpty(filters) Then
                            sql += $" WHERE {filters}"
                        End If
                        sql += " ORDER BY id_" & tableName & " DESC"
                        LoadDataGrid(grid, sql)
                        FormHelper.ConfigureDataGrid(grid, False)
                        Return
                End Select
                
                grid.DataSource = data.ToList()
                FormHelper.ConfigureDataGrid(grid, False)
            End Using
            
        Catch ex As Exception
            ShowError($"Error cargando datos de {tableName}: {ex.Message}", "Error de Carga")
        End Try
    End Sub
    
    ''' <summary>
    ''' Obtiene información de un comprobante usando Entity Framework
    ''' </summary>
    Public Function GetComprobanteInfo(comprobanteId As String) As comprobante
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim comprobanteEntity = context.Comprobantes.Include(Function(c) c.TipoComprobante) _
                    .FirstOrDefault(Function(c) c.IdComprobante = CInt(comprobanteId))
                
                If comprobanteEntity IsNot Nothing Then
                    Dim comprobante As New comprobante()
                    comprobante.id_comprobante = comprobanteEntity.IdComprobante.ToString()
                    comprobante.comprobante = comprobanteEntity.Comprobante
                    comprobante.maxItems = comprobanteEntity.MaxItems
                    comprobante.activo = comprobanteEntity.Activo
                    Return comprobante
                End If
                
                Return Nothing
            End Using
        Catch ex As Exception
            Throw New Exception($"Error obteniendo información del comprobante: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene información de un pedido usando Entity Framework
    ''' </summary>
    Public Function GetPedidoInfo(pedidoId As String) As pedido
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim pedidoEntity = context.Pedidos.Include(Function(p) p.Cliente) _
                    .Include(Function(p) p.Comprobante).Include(Function(p) p.TipoComprobante) _
                    .FirstOrDefault(Function(p) p.IdPedido = CInt(pedidoId))
                
                If pedidoEntity IsNot Nothing Then
                    Dim pedido As New pedido()
                    pedido.id_pedido = pedidoEntity.IdPedido.ToString()
                    pedido.fecha = pedidoEntity.Fecha
                    pedido.id_cliente = pedidoEntity.IdCliente.ToString()
                    pedido.total = pedidoEntity.Total
                    pedido.activo = pedidoEntity.Activo
                    Return pedido
                End If
                
                Return Nothing
            End Using
        Catch ex As Exception
            Throw New Exception($"Error obteniendo información del pedido: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene información de un cliente usando Entity Framework
    ''' </summary>
    Public Function GetClienteInfo(clienteId As String) As cliente
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim clienteEntity = context.Clientes.Include(Function(c) c.ProvinciaFiscal) _
                    .Include(Function(c) c.ProvinciaEntrega) _
                    .FirstOrDefault(Function(c) c.IdCliente = CInt(clienteId))
                
                If clienteEntity IsNot Nothing Then
                    Dim cliente As New cliente()
                    cliente.id_cliente = clienteEntity.IdCliente.ToString()
                    cliente.nombre = clienteEntity.RazonSocial
                    cliente.cuit = clienteEntity.TaxNumber
                    cliente.activo = clienteEntity.Activo
                    Return cliente
                End If
                
                Return Nothing
            End Using
        Catch ex As Exception
            Throw New Exception($"Error obteniendo información del cliente: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene información de un item usando Entity Framework
    ''' </summary>
    Public Function GetItemInfo(itemId As String) As item
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim itemEntity = context.Items.Include(Function(i) i.Marca) _
                    .Include(Function(i) i.Tipo).Include(Function(i) i.Proveedor) _
                    .FirstOrDefault(Function(i) i.IdItem = CInt(itemId))
                
                If itemEntity IsNot Nothing Then
                    Dim item As New item()
                    item.id_item = itemEntity.IdItem.ToString()
                    item.descript = itemEntity.Descript
                    item.precio_lista = itemEntity.PrecioLista
                    item.cantidad = itemEntity.Cantidad
                    item.activo = itemEntity.Activo
                    Return item
                End If
                
                Return Nothing
            End Using
        Catch ex As Exception
            Throw New Exception($"Error obteniendo información del item: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Actualiza el estado de un registro usando Entity Framework
    ''' </summary>
    Public Function UpdateRecordStatus(tableName As String, recordId As String, active As Boolean) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim recordIdInt As Integer = CInt(recordId)
                
                Select Case tableName.ToLower()
                    Case "clientes"
                        Dim cliente = context.Clientes.FirstOrDefault(Function(c) c.IdCliente = recordIdInt)
                        If cliente IsNot Nothing Then
                            cliente.Activo = active
                            context.SaveChanges()
                            Return True
                        End If
                        
                    Case "items"
                        Dim item = context.Items.FirstOrDefault(Function(i) i.IdItem = recordIdInt)
                        If item IsNot Nothing Then
                            item.Activo = active
                            context.SaveChanges()
                            Return True
                        End If
                        
                    Case "pedidos"
                        Dim pedido = context.Pedidos.FirstOrDefault(Function(p) p.IdPedido = recordIdInt)
                        If pedido IsNot Nothing Then
                            pedido.Activo = active
                            context.SaveChanges()
                            Return True
                        End If
                        
                    Case "proveedores"
                        Dim proveedor = context.Proveedores.FirstOrDefault(Function(p) p.IdProveedor = recordIdInt)
                        If proveedor IsNot Nothing Then
                            proveedor.Activo = active
                            context.SaveChanges()
                            Return True
                        End If
                        
                    Case Else
                        ' Fallback to SQL for unknown tables
                        Dim sql As String = $"UPDATE {tableName} SET activo = @activo WHERE id_{tableName} = @id"
                        Dim parameters As New Dictionary(Of String, Object) From {
                            {"@activo", active},
                            {"@id", recordId}
                        }
                        Dim rowsAffected As Integer = ExecuteNonQuery(sql, parameters)
                        Return rowsAffected > 0
                End Select
                
                Return False
            End Using
        Catch ex As Exception
            Throw New Exception($"Error actualizando estado del registro: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Elimina un registro (marca como inactivo)
    ''' </summary>
    Public Function DeleteRecord(tableName As String, recordId As String) As Boolean
        Try
            Return UpdateRecordStatus(tableName, recordId, False)
        Catch ex As Exception
            Throw New Exception($"Error eliminando registro: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Restaura un registro (marca como activo)
    ''' </summary>
    Public Function RestoreRecord(tableName As String, recordId As String) As Boolean
        Try
            Return UpdateRecordStatus(tableName, recordId, True)
        Catch ex As Exception
            Throw New Exception($"Error restaurando registro: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene estadísticas del sistema usando Entity Framework
    ''' </summary>
    Public Function GetSystemStats() As Dictionary(Of String, Integer)
        Try
            Dim stats As New Dictionary(Of String, Integer)()
            
            Using context As CentrexDbContext = GetDbContext()
                ' Contar registros activos
                stats.Add("ClientesActivos", context.Clientes.Count(Function(c) c.Activo = True))
                stats.Add("ProveedoresActivos", context.Proveedores.Count(Function(p) p.Activo = True))
                stats.Add("ItemsActivos", context.Items.Count(Function(i) i.Activo = True))
                stats.Add("PedidosActivos", context.Pedidos.Count(Function(p) p.Activo = True))
                
                ' Contar registros totales
                stats.Add("TotalClientes", context.Clientes.Count())
                stats.Add("TotalProveedores", context.Proveedores.Count())
                stats.Add("TotalItems", context.Items.Count())
                stats.Add("TotalPedidos", context.Pedidos.Count())
            End Using
            
            Return stats
        Catch ex As Exception
            Throw New Exception($"Error obteniendo estadísticas del sistema: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el último número de comprobante usando Entity Framework
    ''' </summary>
    Public Function GetLastComprobanteNumber(puntoVenta As Integer, tipoComprobante As Integer) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim lastNumber = context.Pedidos _
                    .Where(Function(p) p.PuntoVenta = puntoVenta AndAlso p.IdTipoComprobante = tipoComprobante) _
                    .Max(Function(p) p.NumeroComprobante)
                
                Return If(lastNumber, 0)
            End Using
        Catch ex As Exception
            Throw New Exception($"Error obteniendo último número de comprobante: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Verifica si hay stock suficiente para un item usando Entity Framework
    ''' </summary>
    Public Function CheckStockAvailability(itemId As String, requiredQuantity As Decimal) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim item = context.Items.FirstOrDefault(Function(i) i.IdItem = CInt(itemId))
                
                If item Is Nothing Then Return False
                
                Return item.Cantidad >= requiredQuantity
            End Using
        Catch ex As Exception
            Throw New Exception($"Error verificando disponibilidad de stock: {ex.Message}", ex)
        End Try
    End Function
    
End Module
