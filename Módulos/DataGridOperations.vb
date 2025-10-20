Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Text
Imports System.IO

''' <summary>
''' Módulo para operaciones específicas de DataGridView
''' Refactoriza funciones largas de generales.vb
''' </summary>
Module DataGridOperations
    
    ''' <summary>
    ''' Carga un DataGridView con paginación usando DatabaseHelper
    ''' </summary>
    Public Sub LoadDataGridWithPagination(ByRef dataGrid As DataGridView, ByVal sqlstr As String, ByVal db As String, 
                                         ByVal desde As Integer, ByRef nRegs As Integer, ByRef tPaginas As Integer,
                                         ByVal pagina As Integer, ByRef txtnPage As TextBox, ByVal tbl As String, ByVal tblVieja As String)
        Try
            ' Guardar configuración de ordenamiento
            Dim oldSortColumn As DataGridViewColumn = Nothing
            Dim oldSortDir As ListSortDirection = ListSortDirection.Ascending
            
            If tbl = tblVieja Then
                oldSortColumn = dataGrid.SortedColumn
                If dataGrid.SortedColumn IsNot Nothing Then
                    oldSortDir = If(dataGrid.SortOrder = System.Windows.Forms.SortOrder.Ascending, ListSortDirection.Ascending, ListSortDirection.Descending)
                End If
            End If
            
            ' Limpiar columnas
            dataGrid.Columns.Clear()
            
            ' Obtener total de registros
            Dim totalSql As String = $"SELECT COUNT(*) FROM ({sqlstr}) AS CountQuery"
            nRegs = CInt(ExecuteScalar(totalSql))
            tPaginas = Math.Ceiling(nRegs / itXPage)
            txtnPage.Text = $"{pagina} / {tPaginas}"
            
            ' Obtener datos paginados
            Dim paginatedSql As String = $"{sqlstr} OFFSET {desde} ROWS FETCH NEXT {itXPage} ROWS ONLY"
            Dim dt As DataTable = ExecuteQuery(paginatedSql)
            
            ' Configurar DataGridView
            ConfigureDataGridForPagination(dataGrid, dt)
            
            ' Restaurar ordenamiento
            RestoreDataGridSorting(dataGrid, oldSortColumn, oldSortDir)
            
        Catch ex As Exception
            ShowError($"Error cargando DataGridView: {ex.Message}", "Error de Carga")
        End Try
    End Sub
    
    ''' <summary>
    ''' Configura un DataGridView para paginación
    ''' </summary>
    Private Sub ConfigureDataGridForPagination(dataGrid As DataGridView, dataTable As DataTable)
        Try
            dataGrid.DataSource = dataTable
            dataGrid.RowsDefaultCellStyle.BackColor = Color.White
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            
            ' Configurar columnas
            ConfigureDataGridColumns(dataGrid)
            
            ' Configurar tamaño
            AdjustDataGridSize(dataGrid)
            
            ' Configurar modo de redimensionamiento
            ConfigureDataGridAutoSize(dataGrid)
            
        Catch ex As Exception
            Throw New Exception($"Error configurando DataGridView: {ex.Message}", ex)
        End Try
    End Sub
    
    ''' <summary>
    ''' Configura las columnas del DataGridView
    ''' </summary>
    Private Sub ConfigureDataGridColumns(dataGrid As DataGridView)
        Try
            ' Configurar índice de visualización
            Dim i As Integer = 0
            For Each columna As DataGridViewColumn In dataGrid.Columns
                dataGrid.Columns(columna.Name.ToString).DisplayIndex = i
                i += 1
            Next
            
            ' Ocultar columnas según configuración
            If Not dataGrid.Name = "dg_view_resultados" And Not depuracion Then
                dataGrid.Columns(0).Visible = False
            End If
            
            If dataGrid.Name = "dg_viewPedido" Then
                dataGrid.Columns(1).Visible = False
            End If
            
        Catch ex As Exception
            Throw New Exception($"Error configurando columnas: {ex.Message}", ex)
        End Try
    End Sub
    
    ''' <summary>
    ''' Ajusta el tamaño del DataGridView
    ''' </summary>
    Private Sub AdjustDataGridSize(dataGrid As DataGridView)
        Try
            ' Truco para forzar redibujado
            dataGrid.Height = dataGrid.Height + 1
            dataGrid.Height = dataGrid.Height - 1
        Catch ex As Exception
            ' Ignorar errores de tamaño
        End Try
    End Sub
    
    ''' <summary>
    ''' Configura el modo de redimensionamiento automático
    ''' </summary>
    Private Sub ConfigureDataGridAutoSize(dataGrid As DataGridView)
        Try
            If dataGrid.Rows.Count > 0 Then
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            Else
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If
        Catch ex As Exception
            ' Usar modo por defecto si hay error
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None
        End Try
    End Sub
    
    ''' <summary>
    ''' Restaura el ordenamiento del DataGridView
    ''' </summary>
    Private Sub RestoreDataGridSorting(dataGrid As DataGridView, oldSortColumn As DataGridViewColumn, oldSortDir As ListSortDirection)
        Try
            If oldSortColumn IsNot Nothing Then
                Dim sortMode As System.Windows.Forms.SortOrder = If(oldSortDir = ListSortDirection.Ascending, System.Windows.Forms.SortOrder.Ascending, System.Windows.Forms.SortOrder.Descending)
                dataGrid.Sort(oldSortColumn, sortMode)
            End If
        Catch ex As Exception
            ' Ignorar errores de ordenamiento
        End Try
    End Sub
    
    ''' <summary>
    ''' Resalta una columna específica
    ''' </summary>
    Public Sub HighlightColumn(ByRef dataGrid As DataGridView, ByVal columnIndex As Integer, ByVal color As Color, Optional ByVal autoSize As Boolean = False)
        Try
            If columnIndex >= 0 And columnIndex < dataGrid.Columns.Count Then
                dataGrid.Columns(columnIndex).DefaultCellStyle.BackColor = color
                
                If autoSize Then
                    dataGrid.Columns(columnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            End If
        Catch ex As Exception
            ShowError($"Error resaltando columna: {ex.Message}", "Error")
        End Try
    End Sub
    
    ''' <summary>
    ''' Limpia el resaltado de todas las columnas
    ''' </summary>
    Public Sub ClearColumnHighlighting(ByRef dataGrid As DataGridView)
        Try
            For Each column As DataGridViewColumn In dataGrid.Columns
                column.DefaultCellStyle.BackColor = Color.White
            Next
        Catch ex As Exception
            ShowError($"Error limpiando resaltado: {ex.Message}", "Error")
        End Try
    End Sub
    
    ''' <summary>
    ''' Exporta un DataGridView a CSV
    ''' </summary>
    Public Sub ExportDataGridToCSV(dataGrid As DataGridView, fileName As String)
        Try
            Dim csv As New StringBuilder()
            
            ' Agregar encabezados
            For i As Integer = 0 To dataGrid.Columns.Count - 1
                If dataGrid.Columns(i).Visible Then
                    csv.Append(dataGrid.Columns(i).HeaderText)
                    If i < dataGrid.Columns.Count - 1 Then csv.Append(",")
                End If
            Next
            csv.AppendLine()
            
            ' Agregar datos
            For Each row As DataGridViewRow In dataGrid.Rows
                If Not row.IsNewRow Then
                    For i As Integer = 0 To dataGrid.Columns.Count - 1
                        If dataGrid.Columns(i).Visible Then
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                            csv.Append($"""{cellValue}""")
                            If i < dataGrid.Columns.Count - 1 Then csv.Append(",")
                        End If
                    Next
                    csv.AppendLine()
                End If
            Next
            
            ' Guardar archivo
            File.WriteAllText(fileName, csv.ToString(), Encoding.UTF8)
            ShowInfo($"Archivo exportado correctamente: {fileName}", "Exportación Exitosa")
            
        Catch ex As Exception
            ShowError($"Error exportando a CSV: {ex.Message}", "Error de Exportación")
        End Try
    End Sub
    
    ''' <summary>
    ''' Exporta un DataGridView a Excel (formato básico)
    ''' </summary>
    Public Sub ExportDataGridToExcel(dataGrid As DataGridView, fileName As String)
        Try
            Dim csvContent As New StringBuilder()
            
            ' Agregar encabezados
            For i As Integer = 0 To dataGrid.Columns.Count - 1
                If dataGrid.Columns(i).Visible Then
                    csvContent.Append(dataGrid.Columns(i).HeaderText)
                    If i < dataGrid.Columns.Count - 1 Then csvContent.Append(vbTab)
                End If
            Next
            csvContent.AppendLine()
            
            ' Agregar datos
            For Each row As DataGridViewRow In dataGrid.Rows
                If Not row.IsNewRow Then
                    For i As Integer = 0 To dataGrid.Columns.Count - 1
                        If dataGrid.Columns(i).Visible Then
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                            csvContent.Append(cellValue)
                            If i < dataGrid.Columns.Count - 1 Then csvContent.Append(vbTab)
                        End If
                    Next
                    csvContent.AppendLine()
                End If
            Next
            
            ' Guardar como archivo separado por tabulaciones (compatible con Excel)
            File.WriteAllText(fileName, csvContent.ToString(), Encoding.UTF8)
            ShowInfo($"Archivo exportado correctamente: {fileName}", "Exportación Exitosa")
            
        Catch ex As Exception
            ShowError($"Error exportando a Excel: {ex.Message}", "Error de Exportación")
        End Try
    End Sub
    
End Module
