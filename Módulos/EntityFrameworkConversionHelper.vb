'Imports System.Data.Entity
Imports System.Linq
Imports System.Data.SqlClient
'Imports EntityState = System.Data.Entity.EntityState

''' <summary>
''' Helper module para automatizar la conversión de módulos de funciones a Entity Framework
''' </summary>
Module EntityFrameworkConversionHelper

    ''' <summary>
    ''' Convierte una consulta SQL simple a Entity Framework
    ''' </summary>
    Public Function ConvertSimpleQuery(tableName As String, whereClause As String, Optional orderBy As String = "") As IQueryable
        Using context As CentrexDbContext = GetDbContext()
            Dim query As IQueryable = Nothing
            
            Select Case tableName.ToLower()
                Case "clientes"
                    query = context.Clientes.Include(Function(c) c.ProvinciaFiscal).Include(Function(c) c.ProvinciaEntrega)
                Case "items"
                    query = context.Items.Include(Function(i) i.Marca).Include(Function(i) i.Tipo).Include(Function(i) i.Proveedor)
                Case "pedidos"
                    query = context.Pedidos.Include(Function(p) p.Cliente).Include(Function(p) p.Comprobante).Include(Function(p) p.TipoComprobante)
                Case "proveedores"
                    query = context.Proveedores
                Case "usuarios"
                    query = context.Usuarios
                Case "comprobantes"
                    query = context.Comprobantes.Include(Function(c) c.TipoComprobante)
                Case "marcas"
                    query = context.Marcas
                Case "tipos_items"
                    query = context.TiposItems
                Case "tipos_comprobantes"
                    query = context.TiposComprobantes
                Case "provincias"
                    query = context.Provincias
                Case "perfiles"
                    query = context.Perfiles
                Case "registros_stock"
                    query = context.RegistrosStock.Include(Function(r) r.Item).Include(Function(r) r.Proveedor)
                Case "producciones"
                    query = context.Producciones.Include(Function(p) p.Proveedor).Include(Function(p) p.Usuario)
                Case Else
                    Return Nothing
            End Select
            
            ' Aplicar filtros si existen
            If Not String.IsNullOrEmpty(whereClause) Then
                ' Aquí se podrían agregar filtros dinámicos basados en whereClause
                ' Por simplicidad, se mantiene la consulta base
            End If
            
            ' Aplicar ordenamiento si existe
            If Not String.IsNullOrEmpty(orderBy) Then
                ' Aquí se podría agregar ordenamiento dinámico
            End If
            
            Return query
        End Using
    End Function

    ''' <summary>
    ''' Obtiene un registro por ID usando Entity Framework
    ''' </summary>
    Public Function GetRecordById(tableName As String, id As Integer) As Object
        Using context As CentrexDbContext = GetDbContext()
            Select Case tableName.ToLower()
                Case "clientes"
                    Return context.Clientes.Include(Function(c) c.ProvinciaFiscal).Include(Function(c) c.ProvinciaEntrega) _
                        .FirstOrDefault(Function(c) c.IdCliente = id)
                Case "items"
                    Return context.Items.Include(Function(i) i.Marca).Include(Function(i) i.Tipo).Include(Function(i) i.Proveedor) _
                        .FirstOrDefault(Function(i) i.IdItem = id)
                Case "pedidos"
                    Return context.Pedidos.Include(Function(p) p.Cliente).Include(Function(p) p.Comprobante).Include(Function(p) p.TipoComprobante) _
                        .FirstOrDefault(Function(p) p.IdPedido = id)
                Case "proveedores"
                    Return context.Proveedores.FirstOrDefault(Function(p) p.IdProveedor = id)
                Case "usuarios"
                    Return context.Usuarios.FirstOrDefault(Function(u) u.IdUsuario = id)
                Case "comprobantes"
                    Return context.Comprobantes.Include(Function(c) c.TipoComprobante) _
                        .FirstOrDefault(Function(c) c.IdComprobante = id)
                Case "marcas"
                    Return context.Marcas.FirstOrDefault(Function(m) m.IdMarca = id)
                Case "tipos_items"
                    Return context.TiposItems.FirstOrDefault(Function(t) t.IdTipo = id)
                Case "tipos_comprobantes"
                    Return context.TiposComprobantes.FirstOrDefault(Function(tc) tc.IdTipoComprobante = id)
                Case "provincias"
                    Return context.Provincias.FirstOrDefault(Function(p) p.IdProvincia = id)
                Case "perfiles"
                    Return context.Perfiles.FirstOrDefault(Function(p) p.IdPerfil = id)
                Case Else
                    Return Nothing
            End Select
        End Using
    End Function

    ''' <summary>
    ''' Agrega un nuevo registro usando Entity Framework
    ''' </summary>
    Public Function AddRecord(tableName As String, entity As Object) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tableName.ToLower()
                    Case "clientes"
                        context.Clientes.Add(DirectCast(entity, ClienteEntity))
                    Case "items"
                        context.Items.Add(DirectCast(entity, ItemEntity))
                    Case "pedidos"
                        context.Pedidos.Add(DirectCast(entity, PedidoEntity))
                    Case "proveedores"
                        context.Proveedores.Add(DirectCast(entity, ProveedorEntity))
                    Case "usuarios"
                        context.Usuarios.Add(DirectCast(entity, UsuarioEntity))
                    Case "comprobantes"
                        context.Comprobantes.Add(DirectCast(entity, ComprobanteEntity))
                    Case "marcas"
                        context.Marcas.Add(DirectCast(entity, MarcaEntity))
                    Case "tipos_items"
                        context.TiposItems.Add(DirectCast(entity, TipoItemEntity))
                    Case "tipos_comprobantes"
                        context.TiposComprobantes.Add(DirectCast(entity, TipoComprobanteEntity))
                    Case "provincias"
                        context.Provincias.Add(DirectCast(entity, ProvinciaEntity))
                    Case "perfiles"
                        context.Perfiles.Add(DirectCast(entity, PerfilEntity))
                    Case Else
                        Return False
                End Select
                
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Actualiza un registro usando Entity Framework
    ''' </summary>
    Public Function UpdateRecord(tableName As String, entity As Object) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tableName.ToLower()
                    Case "clientes"
                        context.Entry(DirectCast(entity, ClienteEntity)).State = EntityState.Modified
                    Case "items"
                        context.Entry(DirectCast(entity, ItemEntity)).State = EntityState.Modified
                    Case "pedidos"
                        context.Entry(DirectCast(entity, PedidoEntity)).State = EntityState.Modified
                    Case "proveedores"
                        context.Entry(DirectCast(entity, ProveedorEntity)).State = EntityState.Modified
                    Case "usuarios"
                        context.Entry(DirectCast(entity, UsuarioEntity)).State = EntityState.Modified
                    Case "comprobantes"
                        context.Entry(DirectCast(entity, ComprobanteEntity)).State = EntityState.Modified
                    Case "marcas"
                        context.Entry(DirectCast(entity, MarcaEntity)).State = EntityState.Modified
                    Case "tipos_items"
                        context.Entry(DirectCast(entity, TipoItemEntity)).State = EntityState.Modified
                    Case "tipos_comprobantes"
                        context.Entry(DirectCast(entity, TipoComprobanteEntity)).State = EntityState.Modified
                    Case "provincias"
                        context.Entry(DirectCast(entity, ProvinciaEntity)).State = EntityState.Modified
                    Case "perfiles"
                        context.Entry(DirectCast(entity, PerfilEntity)).State = EntityState.Modified
                    Case Else
                        Return False
                End Select
                
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Elimina un registro usando Entity Framework (marca como inactivo)
    ''' </summary>
    Public Function DeleteRecord(tableName As String, id As Integer) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tableName.ToLower()
                    Case "clientes"
                        Dim entity = context.Clientes.FirstOrDefault(Function(c) c.IdCliente = id)
                        If entity IsNot Nothing Then
                            entity.Activo = False
                            context.SaveChanges()
                        End If
                    Case "items"
                        Dim entity = context.Items.FirstOrDefault(Function(i) i.IdItem = id)
                        If entity IsNot Nothing Then
                            entity.Activo = False
                            context.SaveChanges()
                        End If
                    Case "pedidos"
                        Dim entity = context.Pedidos.FirstOrDefault(Function(p) p.IdPedido = id)
                        If entity IsNot Nothing Then
                            entity.Activo = False
                            context.SaveChanges()
                        End If
                    Case "proveedores"
                        Dim entity = context.Proveedores.FirstOrDefault(Function(p) p.IdProveedor = id)
                        If entity IsNot Nothing Then
                            entity.Activo = False
                            context.SaveChanges()
                        End If
                    Case "usuarios"
                        Dim entity = context.Usuarios.FirstOrDefault(Function(u) u.IdUsuario = id)
                        If entity IsNot Nothing Then
                            entity.Activo = False
                            context.SaveChanges()
                        End If
                    Case Else
                        Return False
                End Select
                
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
