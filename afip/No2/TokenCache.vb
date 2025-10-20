Imports System.IO

Namespace Afip
    ''' <summary>
    ''' Cache de tickets AFIP: archivo por clave (servicio|modo).
    ''' Sin dependencias JSON (ideal .NET Framework).
    ''' </summary>
    Public NotInheritable Class TokenCache
        Private Shared ReadOnly BaseFolder As String =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "afip_cache")

        Private Shared ReadOnly MemoryCache As New Dictionary(Of String, AfipTicket)

        Private Sub New()
        End Sub

        Private Shared Function BuildKey(serviceName As String, mode As AfipMode) As String
            Return $"{serviceName.ToLower()}|{mode.ToString().ToLower()}"
        End Function

        Private Shared Function BuildFilePath(key As String) As String
            Dim safeName = key.Replace("|", "_")
            Return Path.Combine(BaseFolder, $"{safeName}.ta")
        End Function

        Public Shared Sub Save(serviceName As String, mode As AfipMode, ticket As AfipTicket)
            Try
                Dim key = BuildKey(serviceName, mode)
                MemoryCache(key) = ticket

                If Not Directory.Exists(BaseFolder) Then
                    Directory.CreateDirectory(BaseFolder)
                End If

                Dim path = BuildFilePath(key)
                Dim lines As String() = {
                    ticket.Token,
                    ticket.Sign,
                    ticket.Expiration.ToString("o")
                }
                File.WriteAllLines(path, lines)

            Catch ex As Exception
                Console.WriteLine($"[TokenCache] Error al guardar ticket: {ex.Message}")
            End Try
        End Sub

        Public Shared Function GetTicket(serviceName As String, mode As AfipMode) As AfipTicket
            Try
                Dim key = BuildKey(serviceName, mode)
                If MemoryCache.ContainsKey(key) Then
                    Return MemoryCache(key)
                End If

                Dim path = BuildFilePath(key)
                If Not File.Exists(path) Then Return Nothing

                Dim lines = File.ReadAllLines(path)
                If lines.Length < 3 Then Return Nothing

                Dim t As New AfipTicket With {
                    .Token = lines(0),
                    .Sign = lines(1),
                    .Expiration = DateTime.Parse(lines(2))
                }
                MemoryCache(key) = t
                Return t

            Catch ex As Exception
                Console.WriteLine($"[TokenCache] Error al obtener ticket: {ex.Message}")
                Return Nothing
            End Try
        End Function

        Public Shared Sub ClearAll()
            Try
                MemoryCache.Clear()
                If Directory.Exists(BaseFolder) Then
                    Directory.Delete(BaseFolder, recursive:=True)
                End If
                Console.WriteLine("[TokenCache] Cache limpia.")
            Catch ex As Exception
                Console.WriteLine($"[TokenCache] Error al limpiar cache: {ex.Message}")
            End Try
        End Sub
    End Class
End Namespace
