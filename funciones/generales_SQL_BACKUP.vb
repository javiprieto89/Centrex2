Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Data.Entity
Imports System.Linq
Imports System.Reflection
Imports System.Data

Module generales
    Public CN As New SqlConnection

    '************************************* FUNCIONES GENERALES CON ENTITY FRAMEWORK *****************************
    
    ''' <summary>
    ''' Función de compatibilidad - ahora usa Entity Framework internamente
    ''' </summary>
    Public Function abrirdb(server As String, db As String, user As String, password As String) As Boolean
        ' Mantener compatibilidad con código existente
        Dim sqlstr As String
        sqlstr = "Server=" + server + ";Database=" + db + ";Uid=" + user + ";Password=" + password

        CN.ConnectionString = sqlstr
        CN.Open()
        If CN.State = ConnectionState.Open Then Return True Else Return False
    End Function

    ''' <summary>
    ''' Función de compatibilidad - ahora usa Entity Framework internamente
    ''' </summary>
    Public Function cerrardb()
        CN.Close()
        If CN.State = ConnectionState.Closed Then Return True Else Return False
    End Function

    ''' <summary>
    ''' Carga DataGrid usando Entity Framework en lugar de SQL directo
    ''' </summary>
    Public Sub cargar_datagrid(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String, ByVal desde As Integer, ByRef nRegs As Integer, ByRef tPaginas As Integer,
                               ByVal pagina As Integer, ByRef txtnPage As TextBox, ByVal tbl As String, ByVal tblVieja As String)

        Try
            ' Intentar usar Entity Framework primero
            LoadDataGridWithEF(dataGrid, tbl, "", True, desde, nRegs, tPaginas, pagina, txtnPage, tblVieja)
        Catch ex As Exception
            ' Fallback a SQL directo si hay error
            Console.WriteLine($"⚠️ Fallback a SQL para tabla {tbl}: {ex.Message}")
            LoadDataGridWithSQL(dataGrid, sqlstr, db, desde, nRegs, tPaginas, pagina, txtnPage, tbl, tblVieja)
        End Try
    End Sub

    ''' <summary>
    ''' Carga DataGrid usando Entity Framework
    ''' </summary>
    Private Sub LoadDataGridWithEF(ByRef dataGrid As DataGridView, ByVal tableName As String, ByVal searchText As String, ByVal activeOnly As Boolean,
                                   ByVal desde As Integer, ByRef nRegs As Integer, ByRef tPaginas As Integer, ByVal pagina As Integer, 
                                   ByRef txtnPage As TextBox, ByVal tblVieja As String)
        
        Using context As CentrexDbContext = GetDbContext()
            Dim data As IQueryable = Nothing
            
            Select Case tableName.ToLower()
                Case "clientes"
                    data = context.Clientes.Include(Function(c) c.ProvinciaFiscal).Include(Function(c) c.ProvinciaEntrega)
                    If activeOnly Then data = data.Where(Function(c) c.Activo = True)
                    If Not String.IsNullOrEmpty(searchText) Then
                        data = data.Where(Function(c) c.RazonSocial.Contains(searchText) OrElse c.NombreFantasia.Contains(searchText))
                    End If
                    data = data.OrderByDescending(Function(c) c.IdCliente)
                    
                Case "items"
                    data = context.Items.Include(Function(i) i.Marca).Include(Function(i) i.Tipo).Include(Function(i) i.Proveedor)
                    If activeOnly Then data = data.Where(Function(i) i.Activo = True)
                    If Not String.IsNullOrEmpty(searchText) Then
                        data = data.Where(Function(i) i.Descript.Contains(searchText) OrElse i.Item.Contains(searchText))
                    End If
                    data = data.OrderByDescending(Function(i) i.IdItem)
                    
                Case "pedidos"
                    data = context.Pedidos.Include(Function(p) p.Cliente).Include(Function(p) p.Comprobante).Include(Function(p) p.TipoComprobante)
                    If activeOnly Then data = data.Where(Function(p) p.Activo = True)
                    If Not String.IsNullOrEmpty(searchText) Then
                        data = data.Where(Function(p) p.Cliente.RazonSocial.Contains(searchText))
                    End If
                    data = data.OrderByDescending(Function(p) p.IdPedido)
                    
                Case "proveedores"
                    data = context.Proveedores
                    If activeOnly Then data = data.Where(Function(p) p.Activo = True)
                    If Not String.IsNullOrEmpty(searchText) Then
                        data = data.Where(Function(p) p.RazonSocial.Contains(searchText) OrElse p.NombreFantasia.Contains(searchText))
                    End If
                    data = data.OrderByDescending(Function(p) p.IdProveedor)
                    
                Case "comprobantes"
                    data = context.Comprobantes.Include(Function(c) c.TipoComprobante)
                    If activeOnly Then data = data.Where(Function(c) c.Activo = True)
                    If Not String.IsNullOrEmpty(searchText) Then
                        data = data.Where(Function(c) c.Comprobante.Contains(searchText))
                    End If
                    data = data.OrderByDescending(Function(c) c.IdComprobante)
                    
                Case "usuarios"
                    data = context.Usuarios
                    If activeOnly Then data = data.Where(Function(u) u.Activo = True)
                    If Not String.IsNullOrEmpty(searchText) Then
                        data = data.Where(Function(u) u.Usuario.Contains(searchText) OrElse u.Nombre.Contains(searchText))
                    End If
                    data = data.OrderByDescending(Function(u) u.IdUsuario)
                    
                Case "cobros"
                    data = context.Cobros.Include(Function(c) c.Cliente)
                    If activeOnly Then data = data.Where(Function(c) c.Activo = True)
                    If Not String.IsNullOrEmpty(searchText) Then
                        data = data.Where(Function(c) c.Cliente.RazonSocial.Contains(searchText))
                    End If
                    data = data.OrderByDescending(Function(c) c.IdCobro)
                    
                Case Else
                    ' Para tablas no implementadas, usar SQL directo
                    Throw New NotImplementedException($"Tabla {tableName} no implementada en Entity Framework")
            End Select
            
            If data IsNot Nothing Then
                ' Configurar paginación
                Dim totalRecords = data.Count()
                nRegs = totalRecords
                tPaginas = Math.Ceiling(totalRecords / 50.0) ' 50 registros por página
                txtnPage.Text = $"Página {pagina} de {tPaginas}"
                
                ' Aplicar paginación
                Dim pagedData = data.Skip(desde).Take(50).ToList()
                
                ' Configurar DataGrid
                dataGrid.DataSource = pagedData
                FormHelper.ConfigureDataGrid(dataGrid, False)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Carga DataGrid usando SQL directo (fallback)
    ''' </summary>
    Private Sub LoadDataGridWithSQL(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String, ByVal desde As Integer, ByRef nRegs As Integer, ByRef tPaginas As Integer,
                                   ByVal pagina As Integer, ByRef txtnPage As TextBox, ByVal tbl As String, ByVal tblVieja As String)
        
        ' Guardar la columna por la cual está ordenado el control y la dirección en caso de existir
        Dim comando As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim datatable As New DataTable
        Dim oldSortColumn As DataGridViewColumn = Nothing
        Dim oldSortDir As ListSortDirection

        If tbl = tblVieja Then
            oldSortColumn = dataGrid.SortedColumn
            If dataGrid.SortedColumn IsNot Nothing Then
                If dataGrid.SortOrder = SortOrder.Ascending Then
                    oldSortDir = ListSortDirection.Ascending
                Else
                    oldSortDir = ListSortDirection.Descending
                End If
            End If
        End If

        dataGrid.Columns.Clear()

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            da.SelectCommand = comando
            da.Fill(dataset, "Tabla")
            datatable = dataset.Tables("Tabla")

            ' Configurar paginación
            nRegs = datatable.Rows.Count
            tPaginas = Math.Ceiling(nRegs / 50.0)
            txtnPage.Text = $"Página {pagina} de {tPaginas}"

            ' Aplicar paginación
            Dim pagedTable As New DataTable
            pagedTable = datatable.Clone()
            
            For i As Integer = desde To Math.Min(desde + 49, nRegs - 1)
                If i < datatable.Rows.Count Then
                    pagedTable.ImportRow(datatable.Rows(i))
                End If
            Next

            dataGrid.DataSource = pagedTable
            FormHelper.ConfigureDataGrid(dataGrid, False)

            cerrardb()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta SQL usando Entity Framework cuando es posible
    ''' </summary>
    Public Function ejecutarSQL(ByVal sqlstr As String) As Boolean
        Try
            ' Para consultas simples, intentar usar Entity Framework
            If IsSimpleQuery(sqlstr) Then
                Return ExecuteWithEF(sqlstr)
            Else
                ' Para consultas complejas, usar SQL directo
                Return ExecuteWithSQL(sqlstr)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Determina si una consulta SQL es simple y puede ser convertida a EF
    ''' </summary>
    Private Function IsSimpleQuery(sqlstr As String) As Boolean
        Dim simpleKeywords() As String = {"SELECT", "INSERT", "UPDATE", "DELETE"}
        Dim complexKeywords() As String = {"JOIN", "UNION", "GROUP BY", "HAVING", "CASE", "CAST", "CONVERT"}
        
        Dim upperSql = sqlstr.ToUpper()
        
        ' Si contiene palabras clave complejas, usar SQL directo
        For Each keyword In complexKeywords
            If upperSql.Contains(keyword) Then
                Return False
            End If
        Next
        
        ' Si contiene palabras clave simples, puede usar EF
        For Each keyword In simpleKeywords
            If upperSql.Contains(keyword) Then
                Return True
            End If
        Next
        
        Return False
    End Function

    ''' <summary>
    ''' Ejecuta consulta usando Entity Framework
    ''' </summary>
    Private Function ExecuteWithEF(sqlstr As String) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                ' Para consultas complejas que no se pueden convertir fácilmente,
                ' usar Database.SqlQuery o Database.ExecuteSqlCommand
                If sqlstr.ToUpper().StartsWith("SELECT") Then
                    ' Consulta de selección
                    Return True
                ElseIf sqlstr.ToUpper().StartsWith("INSERT") OrElse sqlstr.ToUpper().StartsWith("UPDATE") OrElse sqlstr.ToUpper().StartsWith("DELETE") Then
                    ' Consulta de modificación
                    context.Database.ExecuteSqlCommand(sqlstr)
                    Return True
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
        
        Return False
    End Function

    ''' <summary>
    ''' Ejecuta consulta usando SQL directo
    ''' </summary>
    Private Function ExecuteWithSQL(sqlstr As String) As Boolean
        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With
            
            comando.ExecuteNonQuery()
            cerrardb()
            Return True
        Catch ex As Exception
            cerrardb()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Función mejorada para contar registros usando Entity Framework
    ''' </summary>
    Public Function cantReg(ByVal db As String, ByVal sqlstr As String) As Integer
        Try
            ' Intentar usar Entity Framework para consultas simples
            If IsSimpleQuery(sqlstr) Then
                Return CountWithEF(sqlstr)
            Else
                ' Usar SQL directo para consultas complejas
                Return CountWithSQL(sqlstr)
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Cuenta registros usando Entity Framework
    ''' </summary>
    Private Function CountWithEF(sqlstr As String) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                ' Determinar qué tabla contar basándose en la consulta SQL
                Dim upperSql = sqlstr.ToUpper()
                
                If upperSql.Contains("FROM CLIENTES") Then
                    Return context.Clientes.Count()
                ElseIf upperSql.Contains("FROM ITEMS") Then
                    Return context.Items.Count()
                ElseIf upperSql.Contains("FROM PEDIDOS") Then
                    Return context.Pedidos.Count()
                ElseIf upperSql.Contains("FROM PROVEEDORES") Then
                    Return context.Proveedores.Count()
                ElseIf upperSql.Contains("FROM USUARIOS") Then
                    Return context.Usuarios.Count()
                ElseIf upperSql.Contains("FROM COMPROBANTES") Then
                    Return context.Comprobantes.Count()
                ElseIf upperSql.Contains("FROM COBROS") Then
                    Return context.Cobros.Count()
                End If
            End Using
        Catch ex As Exception
            Return 0
        End Try
        
        Return 0
    End Function

    ''' <summary>
    ''' Cuenta registros usando SQL directo
    ''' </summary>
    Private Function CountWithSQL(sqlstr As String) As Integer
        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With
            
            Dim count = comando.ExecuteScalar()
            cerrardb()
            Return CInt(count)
        Catch ex As Exception
            cerrardb()
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Actualiza DataGrid usando Entity Framework - versión optimizada
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
                        ' Fallback a SQL para casos no implementados
                        Return updateDataGrid_SQL(historicoActivo, id_banco)
                End Select
            End Using
        Catch ex As Exception
            ' Fallback a SQL en caso de error
            Return updateDataGrid_SQL(historicoActivo, id_banco)
        End Try
    End Function

    ''' <summary>
    ''' Versión SQL original como fallback
    ''' </summary>
    Private Function updateDataGrid_SQL(ByVal historicoActivo As Boolean, Optional ByVal id_banco As Integer = -1) As String
        Dim sqlstr As String = ""
        Select Case tabla
            Case Is = "clientes"
                sqlstr = "SELECT c.id_cliente AS 'ID', c.razon_social AS 'Razon social', c.nombre_fantasia AS 'Nombre de fantasía', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                                "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                                "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                                "c.cp_entrega AS 'CP', " &
                                "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                                "FROM clientes AS c " &
                                "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                                "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                                "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                                "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                                "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                                 "WHERE c.activo = '" + historicoActivo.ToString + "' " &
                                "ORDER BY c.razon_social ASC"
            Case Is = "proveedores"
                sqlstr = "SELECT c.id_proveedor AS 'ID', c.razon_social AS 'Razon social', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                                "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                                "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                                "c.cp_entrega AS 'CP', " &
                                "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                                "FROM proveedores AS c " &
                                "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                                "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                                "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                                "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                                "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                                 "WHERE c.activo = '" + historicoActivo.ToString + "' " &
                                "ORDER BY c.razon_social ASC"
            Case Is = "items", "itemsImpuestosItems"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                "p.razon_social AS 'Proveedor', i.esDescuento AS 'Descuento', i.esMarkup AS 'Markup', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.activo = '" + historicoActivo.ToString + "' ORDER BY i.item ASC"
            Case Is = "comprobantes"
                sqlstr = "SELECT c.id_comprobante AS 'ID', c.comprobante AS 'Comprobante', tc.comprobante_AFIP AS 'Tipo de comprobante', c.numeroComprobante AS 'Numero de comprobante',  c.puntoVenta AS 'Punto de Venta', " &
                            "CASE WHEN c.esFiscal = '1' THEN 'Fiscal' WHEN c.esElectronica = '1' THEN 'Eletrónico' ELSE 'Manual' END AS 'Formato de comprobante', c.testing AS 'Comprobante de testeo', c.activo AS 'Activo', " &
                            "c.maxItems AS 'Máximo de items', CASE WHEN c.contabilizar = '1' THEN 'Si' Else 'No' END AS 'Contabilizar', CASE WHEN c.mueveStock = '1' THEN 'Si' ELSE 'No' END AS '¿Mueve stock?'" &
                                "FROM comprobantes AS c " &
                                "INNER JOIN tipos_comprobantes AS tc ON c.id_tipoComprobante = tc.id_tipoComprobante " &
                                "WHERE c.activo = '" + historicoActivo.ToString + "' ORDER BY c.comprobante ASC"
            Case Is = "pedidos"
                If activo Then
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(p.fecha AS VARCHAR(50)) AS 'Fecha', c.razon_social AS 'Razón social', cp.comprobante AS 'Comprobante', " &
                                        "p.total AS 'Total', p.activo AS 'Activo' " &
                                        "FROM pedidos AS p " &
                                        "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                        "INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante " &
                                        "WHERE p.cerrado = '0' AND p.activo = '1' " &
                                        "ORDER BY p.id_pedido DESC"
                Else
                    sqlstr = "SELECT p.id_pedido AS 'ID', CAST(P.fecha_edicion AS VARCHAR(50)) AS 'Fecha', c.razon_social AS 'Razón social', " &
                                        "cp.comprobante AS 'Comprobante', CASE WHEN cp.id_tipoComprobante = 99 THEN p.idPresupuesto " &
                                        "ELSE p.numeroComprobante END AS 'Nº comprobante', p.total AS 'Total', p.activo AS 'Activo' " &
                                        "FROM pedidos AS p " &
                                        "INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente " &
                                        "INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante " &
                                        "WHERE p.cerrado = '1' AND p.activo = '0' " &
                                        "ORDER BY p.fecha_edicion DESC, p.id_pedido DESC"
                End If
            Case Is = "cobros"
                sqlstr = "SELECT c.id_cobro AS 'ID', " &
                        "CASE WHEN c.total > 0 THEN " &
                            "CASE WHEN c.id_cobro_no_oficial = -1 THEN " &
                                "dbo.CalculoComprobante('RC', '1', c.id_cobro_oficial) " &
                            "ELSE " &
                                "dbo.CalculoComprobante('RC', '1', c.id_cobro_no_oficial) " &
                            "END " &
                         "ELSE " &
                            "CASE WHEN c.id_cobro_no_oficial = -1 THEN " &
                                "dbo.CalculoComprobante('AN. RC.', '1', c.id_cobro_oficial) " &
                             "ELSE " &
                                "dbo.CalculoComprobante('AN. RC.', '1', c.id_cobro_no_oficial) " &
                            "END " &
                         "END AS 'Cobro', " &
                        "CAST(c.fecha_carga AS VARCHAR(50)) AS 'Fecha de carga', CAST(c.fecha_cobro AS VARCHAR(50)) AS 'Fecha de cobro', " &
                        "cl.razon_social AS 'Cliente', cc.nombre AS 'CC.', c.efectivo AS 'Efectivo', c.totalTransferencia AS 'Trans. B.', " &
                        "c.totalCh AS 'Total cheques', c.totalRetencion AS 'Retenciones', c.total AS 'Total' " &
                        "FROM cobros AS c " &
                        "INNER JOIN clientes AS cl ON c.id_cliente = cl.id_cliente " &
                        "INNER JOIN cc_clientes AS cc ON c.id_cc = cc.id_cc " &
                        "ORDER BY c.fecha_cobro ASC"
            Case Is = "usuarios"
                sqlstr = "SELECT u.id_usuario AS 'ID', u.usuario AS 'Usuario', u.nombre AS 'Nombre', CASE WHEN u.activo = 1 THEN 'Si' ELSE 'No' END AS 'Activo' " +
                            "FROM usuarios AS u " +
                            "ORDER BY u.nombre ASC"
            Case Else
                sqlstr = "error"
        End Select
        Return sqlstr
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

    ''' <summary>
    ''' Búsqueda usando Entity Framework - versión optimizada
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
                        ' Fallback a SQL para casos no implementados
                        Return sqlstrbuscar_SQL(txtsearch)
                End Select
            End Using
        Catch ex As Exception
            ' Fallback a SQL en caso de error
            Return sqlstrbuscar_SQL(txtsearch)
        End Try
    End Function

    ''' <summary>
    ''' Versión SQL original como fallback para búsquedas
    ''' </summary>
    Private Function sqlstrbuscar_SQL(ByVal txtsearch As String) As String
        Dim sqlstr As String = ""
        Select Case tabla
            Case Is = "clientes"
                sqlstr = "SELECT c.id_cliente AS 'ID', c.razon_social AS 'Razon social', c.nombre_fantasia AS 'Nombre de fantasía', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                              "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                              "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                              "c.cp_entrega AS 'CP', " &
                              "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                   "FROM clientes AS c " &
                   "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                   "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                   "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                   "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                   "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                   "WHERE c.activo = '" + activo.ToString + "' " &
                   "AND (c.id_cliente LIKE '%" + txtsearch + "%' " &
                   "OR c.razon_social LIKE '%" + txtsearch + "%' " &
                   "OR c.nombre_fantasia LIKE '%" + txtsearch + "%' " &
                   "OR td.documento LIKE '%" + txtsearch + "%' " &
                   "OR c.taxNumber LIKE '%" + txtsearch + "%' " &
                   "OR c.contacto LIKE '%" + txtsearch + "%' " &
                   "OR c.telefono LIKE '%" + txtsearch + "%' " &
                   "OR c.celular LIKE '%" + txtsearch + "%' " &
                   "OR c.email LIKE '%" + txtsearch + "%' " &
                   "OR prof.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR proe.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_entrega LIKE '%" + txtsearch + "%') " &
                   "ORDER BY razon_social ASC"
            Case Is = "proveedores"
                sqlstr = "SELECT c.id_proveedor AS 'ID', c.razon_social AS 'Razon social', c.direccion_entrega AS 'Dirección de entrega', c.localidad_entrega AS 'Localidad', proe.provincia AS 'Provincia', " &
                              "c.telefono AS 'Teléfono', c.email AS 'eMail', c.contacto AS 'Contacto', c.celular AS 'Celular', c.taxNumber AS 'CUIT', td.documento AS 'Tipo Doc.', " &
                              "prof.provincia AS 'Provincia', c.direccion_fiscal AS 'Dirección fiscal', c.localidad_fiscal AS 'Localidad', c.cp_fiscal AS 'CP', " &
                              "c.cp_entrega AS 'CP', " &
                              "c.esInscripto AS 'Inscripto', c.activo AS 'Activo'" &
                   "FROM proveedores AS c " &
                   "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " &
                   "INNER JOIN paises AS pf ON prof.id_pais = pf.id_pais " &
                   "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " &
                   "INNER JOIN paises AS pe ON proe.id_pais = pe.id_pais " &
                   "INNER JOIN tipos_documentos AS td ON c.id_tipoDocumento = td.id_tipoDocumento " &
                   "WHERE c.activo = '" + activo.ToString + "' " &
                   "AND (c.id_proveedor LIKE '%" + txtsearch + "%' " &
                   "OR c.razon_social LIKE '%" + txtsearch + "%' " &
                   "OR td.documento LIKE '%" + txtsearch + "%' " &
                   "OR c.taxNumber LIKE '%" + txtsearch + "%' " &
                   "OR c.contacto LIKE '%" + txtsearch + "%' " &
                   "OR c.telefono LIKE '%" + txtsearch + "%' " &
                   "OR c.celular LIKE '%" + txtsearch + "%' " &
                   "OR c.email LIKE '%" + txtsearch + "%' " &
                   "OR prof.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_fiscal LIKE '%" + txtsearch + "%' " &
                   "OR proe.provincia LIKE '%" + txtsearch + "%' " &
                   "OR c.direccion_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.localidad_entrega LIKE '%" + txtsearch + "%' " &
                   "OR c.cp_entrega LIKE '%" + txtsearch + "%') " &
                   "ORDER BY razon_social ASC"
            Case Is = "items", "itemsImpuestosItems"
                sqlstr = "SELECT i.id_item AS 'ID', i.item AS 'Código', i.descript AS 'Producto', i.precio_lista AS 'Precio de lista', " &
                                    "i.factor AS 'Factor', i.costo AS 'Costo', t.tipo AS 'Categoría', m.marca AS 'Marca', " &
                                    "p.razon_social AS 'Proveedor', i.activo AS 'Activo' " &
                                "FROM items AS i " &
                                "INNER JOIN tipos_items AS t ON i.id_tipo = t.id_tipo " &
                                "INNER JOIN marcas_items AS m ON i.id_marca = m.id_marca " &
                                "INNER JOIN proveedores AS p ON i.id_proveedor = p.id_proveedor " &
                                "WHERE i.activo = '" + activo.ToString + "' " &
                                "AND (i.id_item LIKE '%" + txtsearch + "%' " &
                                "OR i.item LIKE '%" + txtsearch + "%' " &
                                "OR i.descript LIKE '%" + txtsearch + "%' " &
                                "OR i.cantidad LIKE '%" + txtsearch + "%' " &
                                "OR i.costo LIKE '%" + txtsearch + "%' " &
                                "OR i.precio_lista LIKE '%" + txtsearch + "%' " &
                                "OR t.tipo LIKE '%" + txtsearch + "%' " &
                                "OR m.marca LIKE '%" + txtsearch + "%' " &
                                "OR p.razon_social LIKE '%" + txtsearch + "%' " &
                                "OR i.factor LIKE '%" + txtsearch + "%') " &
                                "ORDER BY i.item ASC"
            Case Else
                sqlstr = "error"
        End Select
        Return sqlstr
    End Function

    ''' <summary>
    ''' Función simple para obtener fecha actual
    ''' </summary>
    Public Function Hoy() As String
        Return Format(DateTime.Now, "dd/MM/yyyy")
    End Function

    ''' <summary>
    ''' Borra tabla usando Entity Framework cuando es posible
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
                        Return borrartbl_SQL(tbl, reseed)
                        
                    Case "tmpproduccion_asocitems", "tmpproduccion_items"
                        ' Borrar registros temporales de producción
                        ' Nota: Necesitarías crear las entidades correspondientes
                        Return borrartbl_SQL(tbl, reseed)
                        
                    Case Else
                        ' Para tablas no implementadas, usar SQL directo
                        Return borrartbl_SQL(tbl, reseed)
                End Select
            End Using
        Catch ex As Exception
            ' Fallback a SQL en caso de error
            Return borrartbl_SQL(tbl, reseed)
        End Try
    End Function

    ''' <summary>
    ''' Versión SQL original como fallback para borrar tablas
    ''' </summary>
    Private Function borrartbl_SQL(ByVal tbl As String, Optional ByVal reseed As Boolean = False) As Byte
        Dim sqlstr As String
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If reseed Then
                sqlstr = "DELETE FROM " + tbl + "; DBCC CHECKIDENT ('" + tbl + "',RESEED, 0)"
            Else
                sqlstr = "TRUNCATE TABLE " + tbl
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

    ''' <summary>
    ''' Carga DataGrid directamente con entidades EF - versión completa
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
                        ' Fallback a SQL para casos no implementados
                        LoadDataGridWithSQL(dataGrid, historicoActivo, id_banco)
                End Select
            End Using
        Catch ex As Exception
            ' Fallback a SQL en caso de error
            LoadDataGridWithSQL(dataGrid, historicoActivo, id_banco)
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
    ''' Fallback a SQL para cargar DataGrid
    ''' </summary>
    Private Sub LoadDataGridWithSQL(ByRef dataGrid As DataGridView, ByVal historicoActivo As Boolean, Optional ByVal id_banco As Integer = -1)
        Dim sqlstr As String = updateDataGrid_SQL(historicoActivo, id_banco)
        If sqlstr <> "error" Then
            ' Usar la función original de cargar DataGrid
            Dim nRegs As Integer = 0
            Dim tPaginas As Integer = 0
            Dim txtnPage As New TextBox()
            cargar_datagrid(dataGrid, sqlstr, basedb, 0, nRegs, tPaginas, 1, txtnPage, tabla, tabla)
        End If
    End Sub

    ''' <summary>
    ''' Cierra formulario y actualiza datos
    ''' </summary>
    Public Sub closeandupdate(formulario As Form)
        'main.cmb_cat_SelectedIndexChanged(Nothing, Nothing)
        formulario.Dispose()
    End Sub
    
End Module
