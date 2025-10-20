Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Pkcs
Imports System.Text
Imports System.Xml

Namespace Afip
    ''' <summary>
    ''' Autenticación WSAA (LoginCms). Firma CMS PKCS#7 válida + TokenCache.
    ''' </summary>
    Public Class WSAA

        ''' <summary>
        ''' Devuelve un TA válido (cache o renovado).
        ''' </summary>
        Public Shared Function GetValidToken(serviceName As String, isTest As Boolean) As AfipTicket
            Try
                Dim mode = If(isTest, AfipMode.HOMO, AfipMode.PROD)

                Dim ta = TokenCache.GetTicket(serviceName, mode)
                If ta IsNot Nothing AndAlso Not ta.IsExpired() Then
                    Return ta
                End If

                ta = LoginCms(serviceName, mode)
                TokenCache.Save(serviceName, mode, ta)
                Return ta

            Catch ex As Exception
                Throw New ApplicationException("Error al obtener token AFIP: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Genera LTR, firma CMS y llama al WSAA correspondiente.
        ''' </summary>
        Private Shared Function LoginCms(serviceName As String, mode As AfipMode) As AfipTicket
            Try
                Dim valid = AfipConfig.ValidateConfig(mode)
                If Not valid.isValid Then
                    Throw New InvalidOperationException(valid.errorMessage)
                End If

                Dim xmlRequest = BuildLoginTicketRequest(serviceName)

                Dim cert As New X509Certificate2(
                    AfipConfig.CertPath,
                    AfipConfig.CertPassword,
                    X509KeyStorageFlags.MachineKeySet Or X509KeyStorageFlags.PersistKeySet
                )

                Dim cmsSigned As String = SignCms(xmlRequest, cert)

                Dim xmlResponse As String
                If mode = AfipMode.HOMO Then
                    Dim client As New WSAAHomo.LoginCMSClient()
                    xmlResponse = client.loginCms(cmsSigned)
                Else
                    Dim client As New WSAAProd.LoginCMSClient()
                    xmlResponse = client.loginCms(cmsSigned)
                End If

                Return ParseLoginTicketResponse(xmlResponse)

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

        Private Shared Function BuildLoginTicketRequest(serviceName As String) As String
            ' ✅ ADAPTADO DEL CÓDIGO QUE FUNCIONA
            Dim now As Date = DateTime.Now.AddMinutes(-10)  ' Como en el prototipo que funciona
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

        Private Shared Function SignCms(xmlData As String, cert As X509Certificate2) As String
            Try
                Console.WriteLine("=== FIRMANDO CMS CON CERTIFICADO ===")
                Console.WriteLine("Certificado Subject: " & cert.Subject)
                Console.WriteLine("Certificado Issuer: " & cert.Issuer)
                Console.WriteLine("Certificado Válido: " & cert.Verify())

                ' ✅ ADAPTADO DEL CÓDIGO QUE FUNCIONA
                Dim msgBytes As Byte() = Encoding.UTF8.GetBytes(xmlData)
                Dim infoContenido As New ContentInfo(msgBytes)
                Dim cmsFirmado As New SignedCms(infoContenido)  ' Sin parámetro False
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

        Private Shared Function ParseLoginTicketResponse(xmlResponse As String) As AfipTicket
            Try
                Dim doc As New XmlDocument()
                doc.LoadXml(xmlResponse)

                Dim token As String = doc.SelectSingleNode("//token")?.InnerText
                Dim sign As String = doc.SelectSingleNode("//sign")?.InnerText
                Dim expirationStr As String = doc.SelectSingleNode("//expirationTime")?.InnerText
                Dim expiration As DateTime = DateTime.Parse(expirationStr)

                Return New AfipTicket With {
                    .Token = token,
                    .Sign = sign,
                    .Expiration = expiration
                }

            Catch ex As Exception
                Throw New ApplicationException("Error al interpretar respuesta WSAA: " & ex.Message, ex)
            End Try
        End Function

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
                
                ' Fallback a MessageBox expandido si hay error
                Dim mensajeCompleto As String = mensaje & vbCrLf & vbCrLf & "=== DETALLES TÉCNICOS ===" & vbCrLf & detalles
                MessageBox.Show(mensajeCompleto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace
