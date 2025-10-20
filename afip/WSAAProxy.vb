Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Security

Namespace Afip
    ''' <summary>
    ''' Cliente manual para el servicio WSAA (LoginCms)
    ''' Reemplaza las Service References con llamadas HTTP directas
    ''' </summary>
    Public Class WSAAClient
        Private ReadOnly _url As String
        Private ReadOnly _timeout As Integer

        Public Sub New(url As String, Optional timeoutSeconds As Integer = 60)
            _url = url
            _timeout = timeoutSeconds * 1000
        End Sub

        ''' <summary>
        ''' Llama al método loginCms del servicio WSAA
        ''' </summary>
        Public Function loginCms(cmsSigned As String) As String
            Try
                ' Crear el SOAP envelope
                Dim soapEnvelope As String = CreateLoginCmsSoapEnvelope(cmsSigned)

                ' Crear la petición HTTP
                Dim request As HttpWebRequest = CType(WebRequest.Create(_url), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "text/xml; charset=utf-8"
                request.Timeout = _timeout
                request.Headers.Add("SOAPAction", "http://ar.gov.afip.dif.facturaelectronica/loginCms")

                ' Escribir el SOAP en el body
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(soapEnvelope)
                request.ContentLength = bytes.Length

                Using stream As Stream = request.GetRequestStream()
                    stream.Write(bytes, 0, bytes.Length)
                End Using

                ' Obtener respuesta
                Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Using responseStream As Stream = response.GetResponseStream()
                        Using reader As New StreamReader(responseStream)
                            Dim responseText As String = reader.ReadToEnd()
                            Return ExtractLoginCmsResponse(responseText)
                        End Using
                    End Using
                End Using

            Catch ex As WebException
                Dim errorMessage As String = "Error en llamada WSAA: "
                If ex.Response IsNot Nothing Then
                    Using responseStream As Stream = ex.Response.GetResponseStream()
                        Using reader As New StreamReader(responseStream)
                            errorMessage &= reader.ReadToEnd()
                        End Using
                    End Using
                Else
                    errorMessage &= ex.Message
                End If
                Throw New ApplicationException(errorMessage, ex)
            End Try
        End Function

        ''' <summary>
        ''' Crea el SOAP envelope para loginCms
        ''' </summary>
        Private Function CreateLoginCmsSoapEnvelope(cmsSigned As String) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            sb.AppendLine("<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">")
            sb.AppendLine("  <soap:Body>")
            sb.AppendLine("    <loginCms xmlns=""http://ar.gov.afip.dif.facturaelectronica/"">")
            sb.AppendLine($"      <in0>{SecurityElement.Escape(cmsSigned)}</in0>")
            sb.AppendLine("    </loginCms>")
            sb.AppendLine("  </soap:Body>")
            sb.AppendLine("</soap:Envelope>")
            Return sb.ToString()
        End Function

        ''' <summary>
        ''' Extrae la respuesta XML del SOAP envelope
        ''' </summary>
        Private Function ExtractLoginCmsResponse(soapResponse As String) As String
            Try
                Dim doc As New XmlDocument()
                doc.LoadXml(soapResponse)

                ' Buscar el nodo loginCmsReturn
                Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
                nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
                nsmgr.AddNamespace("ns1", "http://ar.gov.afip.dif.facturaelectronica/")

                Dim node As XmlNode = doc.SelectSingleNode("//ns1:loginCmsReturn", nsmgr)
                If node Is Nothing Then
                    ' Intentar sin namespace
                    node = doc.SelectSingleNode("//loginCmsReturn")
                End If

                If node IsNot Nothing Then
                    Return node.InnerText
                Else
                    Throw New ApplicationException("No se encontró loginCmsReturn en la respuesta WSAA")
                End If

            Catch ex As Exception
                Throw New ApplicationException("Error al parsear respuesta WSAA: " & ex.Message, ex)
            End Try
        End Function
    End Class
End Namespace
