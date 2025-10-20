Imports System.Data.Entity
Imports System.Linq
Imports System.Windows.Forms
Imports System.Data.SqlClient

''' <summary>
''' Entity Framework helper module for database operations
''' Replaces the old DatabaseHelper with Entity Framework functionality
''' </summary>
Module EntityFrameworkHelper

    ''' <summary>
    ''' Gets a new DbContext instance
    ''' </summary>
    Public Function GetDbContext() As CentrexDbContext
        Return New CentrexDbContext()
    End Function

    ''' <summary>
    ''' Gets a new DbContext instance with custom connection string
    ''' </summary>
    Public Function GetDbContext(connectionString As String) As CentrexDbContext
        Return New CentrexDbContext(connectionString)
    End Function

    ''' <summary>
    ''' Executes a query and returns a DataTable (for compatibility with existing code)
    ''' </summary>
    Public Function ExecuteQuery(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        ' This method is kept for backward compatibility
        ' In a full EF migration, this would be replaced with LINQ queries
        Dim dt As New DataTable()
        Try
            Using conn As New SqlConnection(GetConnectionString())
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error ejecutando consulta: {ex.Message}", ex)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Executes a scalar query and returns a single value (for compatibility)
    ''' </summary>
    Public Function ExecuteScalar(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Object
        ' This method is kept for backward compatibility
        Try
            Using conn As New SqlConnection(GetConnectionString())
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error ejecutando escalar: {ex.Message}", ex)
        End Try
    End Function

    ''' <summary>
    ''' Executes a non-query command (for compatibility)
    ''' </summary>
    'Public Function ExecuteNonQuery(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Integer
    '    ' This method is kept for backward compatibility
    '    Try
    '        Using conn As New SqlConnection(GetConnectionString())
    '            conn.Open()
    '            Using cmd As New SqlCommand(sql, conn)
    '                If parameters IsNot Nothing Then
    '                    For Each param In parameters
    '                        cmd.Parameters.AddWithValue(param.Key, param.Value)
    '                    Next
    '                End If
    '                Return cmd.ExecuteNonQuery()
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw New Exception($"Error ejecutando comando: {ex.Message}", ex)
    '    End Try
    'End Function

    ''' <summary>
    ''' Loads a ComboBox with Entity Framework data
    ''' </summary>
    Public Sub LoadComboBox(combo As ComboBox, tableName As String, displayField As String, valueField As String, Optional defaultText As String = "Seleccione...")
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim data As Object
                Select Case tableName.ToLower()
                    Case "clientes"
                        data = context.Clientes.Where(Function(c) c.Activo = True).Select(Function(c) New With {.Value = c.IdCliente, .Text = c.RazonSocial})
                    Case "items"
                        data = context.Items.Where(Function(i) i.Activo = True).Select(Function(i) New With {.Value = i.IdItem, .Text = i.Descript})
                    Case "proveedores"
                        data = context.Proveedores.Where(Function(p) p.Activo = True).Select(Function(p) New With {.Value = p.IdProveedor, .Text = p.RazonSocial})
                    Case "marcas"
                        data = context.Marcas.Where(Function(m) m.Activo = True).Select(Function(m) New With {.Value = m.IdMarca, .Text = m.Marca})
                    Case "tipos_items"
                        data = context.TiposItems.Where(Function(t) t.Activo = True).Select(Function(t) New With {.Value = t.IdTipo, .Text = t.Tipo})
                    Case Else
                        ' Fallback to SQL for unknown tables
                        Dim sql As String = $"SELECT {valueField}, {displayField} FROM {tableName} WHERE activo = 1"
                        Dim dt As DataTable = ExecuteQuery(sql)
                        combo.DataSource = dt
                        combo.DisplayMember = displayField
                        combo.ValueMember = valueField
                        combo.Text = defaultText
                        Return
                End Select

                combo.DataSource = data.ToList()
                combo.DisplayMember = "Text"
                combo.ValueMember = "Value"
                combo.Text = defaultText
            End Using
        Catch ex As Exception
            Throw New Exception($"Error cargando ComboBox: {ex.Message}", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Loads a DataGridView with Entity Framework data
    ''' </summary>
    Public Sub LoadDataGrid(grid As DataGridView, tableName As String, Optional filters As String = "")
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim data As Object = Nothing

                Select Case tableName.ToLower()
                    Case "clientes"
                        Dim query = context.Clientes.
                        Include(Function(c) c.ProvinciaFiscal).
                        Include(Function(c) c.ProvinciaEntrega)

                        If Not String.IsNullOrEmpty(filters) Then
                            query = query.Where(Function(c) c.RazonSocial.Contains(filters) OrElse c.NombreFantasia.Contains(filters))
                        End If

                        data = query.ToList()

                    Case "items"
                        Dim query = context.Items.
                        Include(Function(i) i.Marca).
                        Include(Function(i) i.Tipo).
                        Include(Function(i) i.Proveedor)

                        If Not String.IsNullOrEmpty(filters) Then
                            query = query.Where(Function(i) i.Descript.Contains(filters) OrElse i.Item.Contains(filters))
                        End If

                        data = query.ToList()

                    Case "pedidos"
                        Dim query = context.Pedidos.
                        Include(Function(p) p.Cliente).
                        Include(Function(p) p.Comprobante).
                        Include(Function(p) p.TipoComprobante)

                        data = query.ToList()

                    Case "proveedores"
                        Dim query = context.Proveedores
                        If Not String.IsNullOrEmpty(filters) Then
                            query = query.Where(Function(p) p.RazonSocial.Contains(filters) OrElse p.NombreFantasia.Contains(filters))
                        End If
                        data = query.ToList()

                    Case Else
                        ' Fallback a SQL si la tabla no está mapeada en EF
                        Dim sql As String = $"SELECT * FROM {tableName}"
                        If Not String.IsNullOrEmpty(filters) Then
                            sql += $" WHERE {filters}"
                        End If
                        Dim dt As DataTable = ExecuteQuery(sql)
                        grid.DataSource = dt
                        Return
                End Select

                ' Asigna la lista resultante al DataGridView
                grid.DataSource = data
            End Using

        Catch ex As Exception
            Throw New Exception($"Error cargando DataGridView: {ex.Message}", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Checks if a record exists using Entity Framework
    ''' </summary>
    Public Function RecordExists(tableName As String, idField As String, idValue As Object) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Select Case tableName.ToLower()
                    Case "clientes"
                        Return context.Clientes.Any(Function(c) c.IdCliente = CInt(idValue))
                    Case "items"
                        Return context.Items.Any(Function(i) i.IdItem = CInt(idValue))
                    Case "pedidos"
                        Return context.Pedidos.Any(Function(p) p.IdPedido = CInt(idValue))
                    Case "proveedores"
                        Return context.Proveedores.Any(Function(p) p.IdProveedor = CInt(idValue))
                    Case Else
                        ' Fallback to SQL for unknown tables
                        Dim sql As String = $"SELECT COUNT(*) FROM {tableName} WHERE {idField} = @id"
                        Dim parameters As New Dictionary(Of String, Object) From {{"@id", idValue}}
                        Return CInt(ExecuteScalar(sql, parameters)) > 0
                End Select
            End Using
        Catch ex As Exception
            Throw New Exception($"Error verificando existencia del registro: {ex.Message}", ex)
        End Try
    End Function

    ''' <summary>
    ''' Gets connection string from configuration
    ''' </summary>
    Private Function GetConnectionString() As String
        Return $"Server={serversql};Database={basedb};Uid={usuariodb};Password={passdb}"
    End Function

End Module
