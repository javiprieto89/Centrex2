Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Pkcs
Imports System.Text
Imports System.Xml

Namespace Afip
    ''' <summary>
    ''' Autenticación WSAA (LoginCms). Firma CMS PKCS#7 válida + TokenCache.
    ''' Depende de la configuración establecida por InicialesFE()
    ''' Usa Web References directas en lugar de Service References
    ''' </summary>
    Public Class WSAA

        ''' <summary>
        ''' Devuelve un TA válido (cache o renovado).
        ''' NOTA: Requiere que InicialesFE() haya sido llamado previamente
        ''' </summary>
        Public Shared Function GetValidToken(serviceName As String, mode As AfipMode) As AfipTicket
            Try
                ' Validar que la configuración esté inicializada
                Dim valid = AfipConfig.ValidateConfig(mode)
                If Not valid.isValid Then
                    Throw New InvalidOperationException($"Configuración no válida: {valid.errorMessage}. Debe llamar a InicialesFE() primero.")
                End If

                ' Intentar obtener token del cache
                Dim ta = TokenCache.GetTicket(serviceName, mode)
                If ta IsNot Nothing AndAlso Not ta.IsExpired() Then
                    Console.WriteLine($"[WSAA] Token en cache válido para {serviceName} ({mode})")
                    Return ta
                End If

                ' Si no hay token válido, obtener uno nuevo
                Console.WriteLine($"[WSAA] Obteniendo nuevo token para {serviceName} ({mode})")
                ta = LoginCms(serviceName, mode)
                TokenCache.Save(serviceName, mode, ta)
                Return ta

            Catch ex As Exception
                Console.WriteLine($"[WSAA] Error al obtener token: {ex.Message}")
                Throw New ApplicationException("Error al obtener token AFIP: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Genera LTR, firma CMS y llama al WSAA correspondiente.
        ''' Usa la configuración establecida por InicialesFE()
        ''' </summary>
        Private Shared Function LoginCms(serviceName As String, mode As AfipMode) As AfipTicket
            Try
                ' Validar configuración
                Dim valid = AfipConfig.ValidateConfig(mode)
                If Not valid.isValid Then
                    Throw New InvalidOperationException(valid.errorMessage)
                End If

                Console.WriteLine("=== INICIANDO LOGIN CMS ===")
                Console.WriteLine($"Servicio: {serviceName}")
                Console.WriteLine($"Modo: {mode}")
                Console.WriteLine($"Certificado: {AfipConfig.CertPath}")
                Console.WriteLine($"URL WSAA: {AfipConfig.GetWsaaUrl(mode)}")

                ' Generar Login Ticket Request
                Dim xmlRequest = BuildLoginTicketRequest(serviceName)

                ' Cargar certificado desde la configuración establecida por InicialesFE
                Dim cert As New X509Certificate2(
                    AfipConfig.CertPath,
                    AfipConfig.CertPassword,
                    X509KeyStorageFlags.MachineKeySet Or X509KeyStorageFlags.PersistKeySet
                )

                Console.WriteLine($"Certificado cargado: {cert.Subject}")

                ' Firmar CMS
                Dim cmsSigned As String = SignCms(xmlRequest, cert)

                ' Llamar al servicio WSAA usando el proxy manual
                Dim url As String = AfipConfig.GetWsaaUrl(mode)
                Dim client As New WSAAClient(url, AfipConfig.TimeoutSeconds)
                Dim xmlResponse As String = client.loginCms(cmsSigned)

                Console.WriteLine("=== RESPUESTA WSAA RECIBIDA ===")

                ' Parsear respuesta
                Dim ticket = ParseLoginTicketResponse(xmlResponse)
                
                Console.WriteLine($"Token obtenido exitosamente. Expira: {ticket.Expiration}")
                
                Return ticket

            Catch ex As Exception
                Console.WriteLine("=== ERROR EN LOGIN CMS ===")
                Console.WriteLine("Error: " & ex.Message)
                Console.WriteLine("Stack Trace: " & ex.StackTrace)
                
                ' Mostrar error detallado
                MostrarErrorDetallado("Error AFIP - LoginCms", "Error al obtener ticket de acceso", 
                    "Error: " & ex.Message & vbCrLf & vbCrLf & "Stack Trace: " & ex.StackTrace)
                
                Throw New ApplicationException("Error en LoginCms: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Construye el XML del Login Ticket Request
        ''' </summary>
        Private Shared Function BuildLoginTicketRequest(serviceName As String) As String
            ' Usar formato que funciona con AFIP
            Dim now As Date = DateTime.Now.AddMinutes(-10)
            Dim exp As Date = DateTime.Now.AddMinutes(+10)
            Dim uniqueId As UInt32 = CUInt((DateTime.Now - New Date(1970, 1, 1)).TotalSeconds)

            Dim sb As New StringBuilder()
            sb.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
            sb.AppendLine("<loginTicketRequest>")
            sb.AppendLine("  <header>")
            sb.AppendFormat("    <uniqueId>{0}</uniqueId>", uniqueId)
            sb.AppendLine()
            sb.AppendFormat("    <generationTime>{0}</generationTime>", now.ToString("s"))
            sb.AppendLine()
            sb.AppendFormat("    <expirationTime>{0}</expirationTime>", exp.ToString("s"))
            sb.AppendLine()
            sb.AppendLine("  </header>")
            sb.AppendFormat("  <service>{0}</service>", serviceName)
            sb.AppendLine()
            sb.AppendLine("</loginTicketRequest>")

            Return sb.ToString()
        End Function

        ''' <summary>
        ''' Firma el XML con el certificado usando CMS/PKCS#7
        ''' </summary>
        Private Shared Function SignCms(xmlData As String, cert As X509Certificate2) As String
            Try
                Console.WriteLine("=== FIRMANDO CMS CON CERTIFICADO ===")
                Console.WriteLine("Certificado Subject: " & cert.Subject)
                Console.WriteLine("Certificado Issuer: " & cert.Issuer)
                Console.WriteLine("Certificado Válido: " & cert.Verify())

                ' Firmar usando PKCS#7
                Dim msgBytes As Byte() = Encoding.UTF8.GetBytes(xmlData)
                Dim infoContenido As New ContentInfo(msgBytes)
                Dim cmsFirmado As New SignedCms(infoContenido)
                Dim cmsFirmante As New CmsSigner(cert)
                cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly

                cmsFirmado.ComputeSignature(cmsFirmante)
                Dim cmsFirmadoBase64 As String = Convert.ToBase64String(cmsFirmado.Encode())

                Console.WriteLine("=== CMS FIRMADO CORRECTAMENTE ===")
                Return cmsFirmadoBase64
            Catch ex As Exception
                Console.WriteLine("=== ERROR AL FIRMAR CMS ===")
                Console.WriteLine("Error: " & ex.Message)
                Console.WriteLine("Stack Trace: " & ex.StackTrace)
                Throw New ApplicationException("Error al firmar CMS: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Parsea la respuesta XML del WSAA
        ''' </summary>
        Private Shared Function ParseLoginTicketResponse(xmlResponse As String) As AfipTicket
            Try
                Dim doc As New XmlDocument()
                doc.LoadXml(xmlResponse)

                Dim token As String = doc.SelectSingleNode("//token")?.InnerText
                Dim sign As String = doc.SelectSingleNode("//sign")?.InnerText
                Dim expirationStr As String = doc.SelectSingleNode("//expirationTime")?.InnerText
                Dim expiration As DateTime = DateTime.Parse(expirationStr)

                If String.IsNullOrWhiteSpace(token) OrElse String.IsNullOrWhiteSpace(sign) Then
                    Throw New Exception("Token o Sign no encontrados en la respuesta WSAA")
                End If

                Return New AfipTicket With {
                    .Token = token,
                    .Sign = sign,
                    .Expiration = expiration
                }

            Catch ex As Exception
                Throw New ApplicationException("Error al interpretar respuesta WSAA: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Muestra un formulario de error detallado
        ''' </summary>
        Private Shared Sub MostrarErrorDetallado(titulo As String, mensaje As String, detalles As String)
            Try
                Console.WriteLine("=== MostrarErrorDetallado ===")
                Console.WriteLine("Título: " & titulo)
                Console.WriteLine("Mensaje: " & mensaje)
                Console.WriteLine("Detalles: " & detalles)
                
                ' Crear formulario de errores detallados
                Dim frmError As New frm_error_detalle()
                frmError.MostrarError(titulo, mensaje, detalles)
                frmError.ShowDialog()
                
                Console.WriteLine("=== Formulario de error mostrado correctamente ===")
            Catch ex As Exception
                Console.WriteLine("=== Error al mostrar formulario de errores ===")
                Console.WriteLine("Error: " & ex.Message)
                Console.WriteLine("Stack Trace: " & ex.StackTrace)
                
                ' Fallback a MessageBox si hay error
                Dim mensajeCompleto As String = mensaje & vbCrLf & vbCrLf & "=== DETALLES TÉCNICOS ===" & vbCrLf & detalles
                MessageBox.Show(mensajeCompleto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace
