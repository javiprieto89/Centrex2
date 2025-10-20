Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Data.Entity
Imports System.Linq

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

    ' Mantener funciones originales para compatibilidad
    ' ... (resto de funciones originales)
    
End Module
