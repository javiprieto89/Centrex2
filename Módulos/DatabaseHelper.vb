Imports System.Data.SqlClient
Imports System.Data

''' <summary>
''' Clase para información de comandos SQL
''' </summary>
Public Class CommandInfo
    Public Property Sql As String
    Public Property Parameters As Dictionary(Of String, Object)
    
    Public Sub New(sql As String, parameters As Dictionary(Of String, Object))
        Me.Sql = sql
        Me.Parameters = parameters
    End Sub
End Class

''' <summary>
''' Módulo helper para operaciones comunes de base de datos
''' Reduce código duplicado y centraliza la lógica de acceso a datos
''' </summary>
Module DatabaseHelper
    
    ''' <summary>
    ''' Ejecuta una consulta SQL y devuelve un DataTable
    ''' </summary>
    Public Function ExecuteQuery(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
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
    ''' Ejecuta una consulta SQL y devuelve un DataTable (sobrecarga con List de SqlParameter)
    ''' </summary>
    Public Function ExecuteQuery(sql As String, parameters As List(Of SqlParameter)) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As New SqlConnection(GetConnectionString())
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.Add(param)
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
    ''' Ejecuta una consulta SQL que devuelve un solo valor
    ''' </summary>
    Public Function ExecuteScalar(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Object
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
    ''' Ejecuta una consulta SQL que devuelve un solo valor (sobrecarga con List de SqlParameter)
    ''' </summary>
    Public Function ExecuteScalar(sql As String, parameters As List(Of SqlParameter)) As Object
        Try
            Using conn As New SqlConnection(GetConnectionString())
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.Add(param)
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
    ''' Ejecuta una consulta SQL que no devuelve datos (INSERT, UPDATE, DELETE)
    ''' </summary>
    Public Function ExecuteNonQuery(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Integer
        Try
            Using conn As New SqlConnection(GetConnectionString())
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error ejecutando comando: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Ejecuta una consulta SQL que no devuelve datos (sobrecarga con List de SqlParameter)
    ''' </summary>
    Public Function ExecuteNonQuery(sql As String, parameters As List(Of SqlParameter)) As Integer
        Try
            Using conn As New SqlConnection(GetConnectionString())
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.Add(param)
                        Next
                    End If
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error ejecutando comando: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Ejecuta múltiples comandos en una transacción
    ''' </summary>
    Public Function ExecuteTransaction(commands As List(Of CommandInfo)) As Boolean
        Try
            Using conn As New SqlConnection(GetConnectionString())
                conn.Open()
                Using transaction As SqlTransaction = conn.BeginTransaction()
                    Try
                        For Each cmdInfo In commands
                            Using cmd As New SqlCommand(cmdInfo.Sql, conn, transaction)
                                If cmdInfo.Parameters IsNot Nothing Then
                                    For Each param In cmdInfo.Parameters
                                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                                    Next
                                End If
                                cmd.ExecuteNonQuery()
                            End Using
                        Next
                        transaction.Commit()
                        Return True
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error ejecutando transacción: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el siguiente ID de una tabla (para campos IDENTITY)
    ''' </summary>
    Public Function GetNextId(tableName As String) As Integer
        Dim sql As String = $"SELECT ISNULL(MAX(id_{tableName}), 0) + 1 FROM {tableName}"
        Return CInt(ExecuteScalar(sql))
    End Function
    
    ''' <summary>
    ''' Verifica si existe un registro con el ID especificado
    ''' </summary>
    Public Function RecordExists(tableName As String, idField As String, idValue As Object) As Boolean
        Dim sql As String = $"SELECT COUNT(*) FROM {tableName} WHERE {idField} = @id"
        Dim parameters As New Dictionary(Of String, Object) From {{"@id", idValue}}
        Return CInt(ExecuteScalar(sql, parameters)) > 0
    End Function
    
    ''' <summary>
    ''' Construye la cadena de conexión usando las variables globales
    ''' </summary>
    Private Function GetConnectionString() As String
        Return $"Server={serversql};Database={basedb};Uid={usuariodb};Password={passdb}"
    End Function
    
    ''' <summary>
    ''' Carga un ComboBox con datos de una consulta SQL
    ''' </summary>
    Public Sub LoadComboBox(combo As ComboBox, sql As String, displayField As String, valueField As String, Optional defaultText As String = "Seleccione...")
        Try
            Dim dt As DataTable = ExecuteQuery(sql)
            combo.DataSource = dt
            combo.DisplayMember = displayField
            combo.ValueMember = valueField
            combo.Text = defaultText
        Catch ex As Exception
            Throw New Exception($"Error cargando ComboBox: {ex.Message}", ex)
        End Try
    End Sub
    
    ''' <summary>
    ''' Carga un DataGridView con datos de una consulta SQL
    ''' </summary>
    Public Sub LoadDataGrid(grid As DataGridView, sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing)
        Try
            Dim dt As DataTable = ExecuteQuery(sql, parameters)
            grid.DataSource = dt
        Catch ex As Exception
            Throw New Exception($"Error cargando DataGridView: {ex.Message}", ex)
        End Try
    End Sub
    
    Public Function GetConnection() As SqlConnection
        Try
            ' Esta función debería retornar una conexión a la base de datos
            ' Por ahora retornamos Nothing para evitar errores de compilación
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
