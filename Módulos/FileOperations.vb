Imports System.IO
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' Módulo para operaciones de archivos y utilidades
''' Refactoriza funciones de generales.vb relacionadas con archivos
''' </summary>
Module FileOperations
    
    ''' <summary>
    ''' Lee un archivo de texto completo
    ''' </summary>
    Public Function ReadTextFile(filePath As String) As String
        Try
            If System.IO.File.Exists(filePath) Then
                Return File.ReadAllText(filePath, Encoding.UTF8)
            Else
                Throw New FileNotFoundException($"El archivo no existe: {filePath}")
            End If
        Catch ex As Exception
            Throw New Exception($"Error leyendo archivo {filePath}: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Escribe texto a un archivo
    ''' </summary>
    Public Function WriteTextFile(filePath As String, content As String) As Boolean
        Try
            ' Crear directorio si no existe
            Dim directory As String = Path.GetDirectoryName(filePath)
            If Not System.IO.Directory.Exists(directory) Then
                System.IO.Directory.CreateDirectory(directory)
            End If
            
            File.WriteAllText(filePath, content, Encoding.UTF8)
            Return True
        Catch ex As Exception
            Throw New Exception($"Error escribiendo archivo {filePath}: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Lee un archivo línea por línea
    ''' </summary>
    Public Function ReadTextFileLines(filePath As String) As String()
        Try
            If System.IO.File.Exists(filePath) Then
                Return File.ReadAllLines(filePath, Encoding.UTF8)
            Else
                Throw New FileNotFoundException($"El archivo no existe: {filePath}")
            End If
        Catch ex As Exception
            Throw New Exception($"Error leyendo líneas del archivo {filePath}: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Escribe líneas a un archivo
    ''' </summary>
    Public Function WriteTextFileLines(filePath As String, lines As String()) As Boolean
        Try
            ' Crear directorio si no existe
            Dim directory As String = Path.GetDirectoryName(filePath)
            If Not System.IO.Directory.Exists(directory) Then
                System.IO.Directory.CreateDirectory(directory)
            End If
            
            File.WriteAllLines(filePath, lines, Encoding.UTF8)
            Return True
        Catch ex As Exception
            Throw New Exception($"Error escribiendo líneas al archivo {filePath}: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Copia un archivo
    ''' </summary>
    Public Function CopyFile(sourcePath As String, destinationPath As String, Optional overwrite As Boolean = True) As Boolean
        Try
            If Not File.Exists(sourcePath) Then
                Throw New FileNotFoundException($"El archivo origen no existe: {sourcePath}")
            End If
            
            ' Crear directorio destino si no existe
            Dim destinationDir As String = Path.GetDirectoryName(destinationPath)
            If Not System.IO.Directory.Exists(destinationDir) Then
                Directory.CreateDirectory(destinationDir)
            End If
            
            File.Copy(sourcePath, destinationPath, overwrite)
            Return True
        Catch ex As Exception
            Throw New Exception($"Error copiando archivo: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Mueve un archivo
    ''' </summary>
    Public Function MoveFile(sourcePath As String, destinationPath As String) As Boolean
        Try
            If Not File.Exists(sourcePath) Then
                Throw New FileNotFoundException($"El archivo origen no existe: {sourcePath}")
            End If
            
            ' Crear directorio destino si no existe
            Dim destinationDir As String = Path.GetDirectoryName(destinationPath)
            If Not System.IO.Directory.Exists(destinationDir) Then
                Directory.CreateDirectory(destinationDir)
            End If
            
            File.Move(sourcePath, destinationPath)
            Return True
        Catch ex As Exception
            Throw New Exception($"Error moviendo archivo: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Elimina un archivo
    ''' </summary>
    Public Function DeleteFile(filePath As String) As Boolean
        Try
            If System.IO.File.Exists(filePath) Then
                File.Delete(filePath)
                Return True
            Else
                Return False ' Archivo no existe
            End If
        Catch ex As Exception
            Throw New Exception($"Error eliminando archivo {filePath}: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Verifica si un archivo existe
    ''' </summary>
    Public Function FileExists(filePath As String) As Boolean
        Try
            Return System.IO.File.Exists(filePath)
        Catch ex As Exception
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el tamaño de un archivo en bytes
    ''' </summary>
    Public Function GetFileSize(filePath As String) As Long
        Try
            If System.IO.File.Exists(filePath) Then
                Dim fileInfo As New FileInfo(filePath)
                Return fileInfo.Length
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene la fecha de última modificación de un archivo
    ''' </summary>
    Public Function GetFileLastWriteTime(filePath As String) As DateTime
        Try
            If System.IO.File.Exists(filePath) Then
                Return File.GetLastWriteTime(filePath)
            Else
                Return DateTime.MinValue
            End If
        Catch ex As Exception
            Return DateTime.MinValue
        End Try
    End Function
    
    ''' <summary>
    ''' Crea un directorio si no existe
    ''' </summary>
    Public Function CreateDirectoryIfNotExists(directoryPath As String) As Boolean
        Try
            If Not Directory.Exists(directoryPath) Then
                Directory.CreateDirectory(directoryPath)
            End If
            Return True
        Catch ex As Exception
            Throw New Exception($"Error creando directorio {directoryPath}: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Elimina un directorio y todo su contenido
    ''' </summary>
    Public Function DeleteDirectory(directoryPath As String, Optional recursive As Boolean = True) As Boolean
        Try
            If System.IO.Directory.Exists(directoryPath) Then
                Directory.Delete(directoryPath, recursive)
                Return True
            Else
                Return False ' Directorio no existe
            End If
        Catch ex As Exception
            Throw New Exception($"Error eliminando directorio {directoryPath}: {ex.Message}", ex)
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene todos los archivos de un directorio
    ''' </summary>
    Public Function GetFilesInDirectory(directoryPath As String, Optional searchPattern As String = "*.*") As String()
        Try
            If System.IO.Directory.Exists(directoryPath) Then
                Return Directory.GetFiles(directoryPath, searchPattern)
            Else
                Return New String() {}
            End If
        Catch ex As Exception
            Return New String() {}
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene todos los subdirectorios de un directorio
    ''' </summary>
    Public Function GetDirectoriesInDirectory(directoryPath As String) As String()
        Try
            If System.IO.Directory.Exists(directoryPath) Then
                Return Directory.GetDirectories(directoryPath)
            Else
                Return New String() {}
            End If
        Catch ex As Exception
            Return New String() {}
        End Try
    End Function
    
    ''' <summary>
    ''' Formatea el tamaño de archivo en formato legible
    ''' </summary>
    Public Function FormatFileSize(bytes As Long) As String
        Try
            Dim sizes As String() = {"B", "KB", "MB", "GB", "TB"}
            Dim order As Integer = 0
            Dim size As Double = bytes
            
            While size >= 1024 And order < sizes.Length - 1
                order += 1
                size = size / 1024
            End While
            
            Return $"{size:0.##} {sizes(order)}"
        Catch ex As Exception
            Return "0 B"
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene la extensión de un archivo
    ''' </summary>
    Public Function GetFileExtension(filePath As String) As String
        Try
            Return Path.GetExtension(filePath)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el nombre del archivo sin la extensión
    ''' </summary>
    Public Function GetFileNameWithoutExtension(filePath As String) As String
        Try
            Return Path.GetFileNameWithoutExtension(filePath)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el nombre del archivo con extensión
    ''' </summary>
    Public Function GetFileName(filePath As String) As String
        Try
            Return Path.GetFileName(filePath)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el directorio padre de un archivo
    ''' </summary>
    Public Function GetDirectoryName(filePath As String) As String
        Try
            Return Path.GetDirectoryName(filePath)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    
    ''' <summary>
    ''' Combina rutas de archivo de forma segura
    ''' </summary>
    Public Function CombinePaths(path1 As String, path2 As String) As String
        Try
            Return Path.Combine(path1, path2)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene la ruta absoluta de un archivo
    ''' </summary>
    Public Function GetFullPath(filePath As String) As String
        Try
            Return Path.GetFullPath(filePath)
        Catch ex As Exception
            Return filePath
        End Try
    End Function
    
    Public Function Exists(ByVal filePath As String) As Boolean
        Try
            Return System.IO.File.Exists(filePath)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CreateDirectory(ByVal directoryPath As String) As Boolean
        Try
            System.IO.Directory.CreateDirectory(directoryPath)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
