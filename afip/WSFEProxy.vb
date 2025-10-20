Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Security

Namespace Afip.Proxy
    ''' <summary>
    ''' Cliente manual para el servicio WSFEv1
    ''' Reemplaza las Service References con llamadas HTTP directas
    ''' </summary>
    Public Class WSFEClient
        Private ReadOnly _url As String
        Private ReadOnly _timeout As Integer

        Public Sub New(url As String, Optional timeoutSeconds As Integer = 60)
            _url = url
            _timeout = timeoutSeconds * 1000
        End Sub

        ''' <summary>
        ''' Método FEDummy - Prueba de conectividad
        ''' </summary>
        Public Function FEDummy() As FEDummyResponse
            Dim soapBody As String = "<FEDummy xmlns=""http://ar.gov.afip.dif.FEV1/"" />"
            Dim response As String = CallSoapMethod("FEDummy", soapBody)
            Return ParseFEDummyResponse(response)
        End Function

        ''' <summary>
        ''' Método FECompUltimoAutorizado
        ''' </summary>
        Public Function FECompUltimoAutorizado(auth As FEAuthRequest, ptoVta As Integer, cbteTipo As Integer) As FECompUltimoAutorizadoResponse
            Dim soapBody As String = CreateFECompUltimoAutorizadoBody(auth, ptoVta, cbteTipo)
            Dim response As String = CallSoapMethod("FECompUltimoAutorizado", soapBody)
            Return ParseFECompUltimoAutorizadoResponse(response)
        End Function

        ''' <summary>
        ''' Método FECompConsultar
        ''' </summary>
        Public Function FECompConsultar(auth As FEAuthRequest, req As FECompConsultaReq) As FECompConsultaResponse
            Dim soapBody As String = CreateFECompConsultarBody(auth, req)
            Dim response As String = CallSoapMethod("FECompConsultar", soapBody)
            Return ParseFECompConsultaResponse(response)
        End Function

        ''' <summary>
        ''' Método FECAESolicitar
        ''' </summary>
        Public Function FECAESolicitar(auth As FEAuthRequest, request As FECAERequest) As FECAEResponse
            Dim soapBody As String = CreateFECAESolicitarBody(auth, request)
            Dim response As String = CallSoapMethod("FECAESolicitar", soapBody)
            Return ParseFECAEResponse(response)
        End Function

        ''' <summary>
        ''' Método FEParamGetTiposCbte
        ''' </summary>
        Public Function FEParamGetTiposCbte(auth As FEAuthRequest) As FEParamGetTiposCbteResponse
            Dim soapBody As String = CreateFEParamGetTiposCbteBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetTiposCbte", soapBody)
            Return ParseFEParamGetTiposCbteResponse(response)
        End Function

        ''' <summary>
        ''' Método FEParamGetTiposDoc
        ''' </summary>
        Public Function FEParamGetTiposDoc(auth As FEAuthRequest) As FEParamGetTiposDocResponse
            Dim soapBody As String = CreateFEParamGetTiposDocBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetTiposDoc", soapBody)
            Return ParseFEParamGetTiposDocResponse(response)
        End Function

        ''' <summary>
        ''' Método FEParamGetTiposIva
        ''' </summary>
        Public Function FEParamGetTiposIva(auth As FEAuthRequest) As Object
            Dim soapBody As String = CreateFEParamGetTiposIvaBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetTiposIva", soapBody)
            Return ParseGenericResponse(response, "FEParamGetTiposIvaResponse")
        End Function

        ''' <summary>
        ''' Método FEParamGetTiposMonedas
        ''' </summary>
        Public Function FEParamGetTiposMonedas(auth As FEAuthRequest) As Object
            Dim soapBody As String = CreateFEParamGetTiposMonedasBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetTiposMonedas", soapBody)
            Return ParseGenericResponse(response, "FEParamGetTiposMonedasResponse")
        End Function

        ''' <summary>
        ''' Método FEParamGetTiposConcepto
        ''' </summary>
        Public Function FEParamGetTiposConcepto(auth As FEAuthRequest) As Object
            Dim soapBody As String = CreateFEParamGetTiposConceptoBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetTiposConcepto", soapBody)
            Return ParseGenericResponse(response, "FEParamGetTiposConceptoResponse")
        End Function

        ''' <summary>
        ''' Método FEParamGetPtosVenta
        ''' </summary>
        Public Function FEParamGetPtosVenta(auth As FEAuthRequest) As FEParamGetPtosVentaResponse
            Dim soapBody As String = CreateFEParamGetPtosVentaBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetPtosVenta", soapBody)
            Return ParseFEParamGetPtosVentaResponse(response)
        End Function

        ''' <summary>
        ''' Método FEParamGetCotizacion
        ''' </summary>
        Public Function FEParamGetCotizacion(auth As FEAuthRequest, moneda As String, fecha As String) As Object
            Dim soapBody As String = CreateFEParamGetCotizacionBody(auth, moneda, fecha)
            Dim response As String = CallSoapMethod("FEParamGetCotizacion", soapBody)
            Return ParseGenericResponse(response, "FEParamGetCotizacionResponse")
        End Function

        ''' <summary>
        ''' Método FEParamGetTiposTributos
        ''' </summary>
        Public Function FEParamGetTiposTributos(auth As FEAuthRequest) As Object
            Dim soapBody As String = CreateFEParamGetTiposTributosBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetTiposTributos", soapBody)
            Return ParseGenericResponse(response, "FEParamGetTiposTributosResponse")
        End Function

        ''' <summary>
        ''' Método FEParamGetTiposOpcional
        ''' </summary>
        Public Function FEParamGetTiposOpcional(auth As FEAuthRequest) As Object
            Dim soapBody As String = CreateFEParamGetTiposOpcionalBody(auth)
            Dim response As String = CallSoapMethod("FEParamGetTiposOpcional", soapBody)
            Return ParseGenericResponse(response, "FEParamGetTiposOpcionalResponse")
        End Function

        ' ============================================
        ' MÉTODOS PRIVADOS - LLAMADAS SOAP
        ' ============================================

        Private Function CallSoapMethod(methodName As String, soapBody As String) As String
            Try
                Dim soapEnvelope As String = CreateSoapEnvelope(soapBody)

                Dim request As HttpWebRequest = CType(WebRequest.Create(_url), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "text/xml; charset=utf-8"
                request.Timeout = _timeout
                request.Headers.Add("SOAPAction", $"http://ar.gov.afip.dif.FEV1/{methodName}")

                Dim bytes As Byte() = Encoding.UTF8.GetBytes(soapEnvelope)
                request.ContentLength = bytes.Length

                Using stream As Stream = request.GetRequestStream()
                    stream.Write(bytes, 0, bytes.Length)
                End Using

                Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    Using responseStream As Stream = response.GetResponseStream()
                        Using reader As New StreamReader(responseStream)
                            Return reader.ReadToEnd()
                        End Using
                    End Using
                End Using

            Catch ex As WebException
                Dim errorMessage As String = "Error en llamada WSFE: "
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

        Private Function CreateSoapEnvelope(body As String) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            sb.AppendLine("<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">")
            sb.AppendLine("  <soap:Body>")
            sb.AppendLine(body)
            sb.AppendLine("  </soap:Body>")
            sb.AppendLine("</soap:Envelope>")
            Return sb.ToString()
        End Function

        ' ============================================
        ' MÉTODOS PRIVADOS - CREAR SOAP BODIES
        ' ============================================

        Private Function CreateAuthBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("    <Auth>")
            sb.AppendLine($"      <Token>{SecurityElement.Escape(auth.Token)}</Token>")
            sb.AppendLine($"      <Sign>{SecurityElement.Escape(auth.Sign)}</Sign>")
            sb.AppendLine($"      <Cuit>{auth.Cuit}</Cuit>")
            sb.AppendLine("    </Auth>")
            Return sb.ToString()
        End Function

        Private Function CreateFECompUltimoAutorizadoBody(auth As FEAuthRequest, ptoVta As Integer, cbteTipo As Integer) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FECompUltimoAutorizado xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine($"  <PtoVta>{ptoVta}</PtoVta>")
            sb.AppendLine($"  <CbteTipo>{cbteTipo}</CbteTipo>")
            sb.AppendLine("</FECompUltimoAutorizado>")
            Return sb.ToString()
        End Function

        Private Function CreateFECompConsultarBody(auth As FEAuthRequest, req As FECompConsultaReq) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FECompConsultar xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("  <FeCompConsReq>")
            sb.AppendLine($"    <CbteTipo>{req.CbteTipo}</CbteTipo>")
            sb.AppendLine($"    <CbteNro>{req.CbteNro}</CbteNro>")
            sb.AppendLine($"    <PtoVta>{req.PtoVta}</PtoVta>")
            sb.AppendLine("  </FeCompConsReq>")
            sb.AppendLine("</FECompConsultar>")
            Return sb.ToString()
        End Function

        Private Function CreateFECAESolicitarBody(auth As FEAuthRequest, request As FECAERequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FECAESolicitar xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("  <FeCAEReq>")
            sb.AppendLine("    <FeCabReq>")
            sb.AppendLine($"      <CantReg>{request.FeCabReq.CantReg}</CantReg>")
            sb.AppendLine($"      <PtoVta>{request.FeCabReq.PtoVta}</PtoVta>")
            sb.AppendLine($"      <CbteTipo>{request.FeCabReq.CbteTipo}</CbteTipo>")
            sb.AppendLine("    </FeCabReq>")
            sb.AppendLine("    <FeDetReq>")

            For Each det In request.FeDetReq
                sb.AppendLine("      <FECAEDetRequest>")
                sb.AppendLine($"        <Concepto>{det.Concepto}</Concepto>")
                sb.AppendLine($"        <DocTipo>{det.DocTipo}</DocTipo>")
                sb.AppendLine($"        <DocNro>{det.DocNro}</DocNro>")
                sb.AppendLine($"        <CbteDesde>{det.CbteDesde}</CbteDesde>")
                sb.AppendLine($"        <CbteHasta>{det.CbteHasta}</CbteHasta>")
                sb.AppendLine($"        <CbteFch>{det.CbteFch}</CbteFch>")
                sb.AppendLine($"        <ImpTotal>{det.ImpTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</ImpTotal>")
                sb.AppendLine($"        <ImpTotConc>{det.ImpTotConc.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</ImpTotConc>")
                sb.AppendLine($"        <ImpNeto>{det.ImpNeto.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</ImpNeto>")
                sb.AppendLine($"        <ImpOpEx>{det.ImpOpEx.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</ImpOpEx>")
                sb.AppendLine($"        <ImpTrib>{det.ImpTrib.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</ImpTrib>")
                sb.AppendLine($"        <ImpIVA>{det.ImpIVA.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</ImpIVA>")

                If Not String.IsNullOrEmpty(det.FchServDesde) Then
                    sb.AppendLine($"        <FchServDesde>{det.FchServDesde}</FchServDesde>")
                End If
                If Not String.IsNullOrEmpty(det.FchServHasta) Then
                    sb.AppendLine($"        <FchServHasta>{det.FchServHasta}</FchServHasta>")
                End If
                If Not String.IsNullOrEmpty(det.FchVtoPago) Then
                    sb.AppendLine($"        <FchVtoPago>{det.FchVtoPago}</FchVtoPago>")
                End If

                sb.AppendLine($"        <MonId>{SecurityElement.Escape(det.MonId)}</MonId>")
                sb.AppendLine($"        <MonCotiz>{det.MonCotiz.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture)}</MonCotiz>")

                If det.Iva IsNot Nothing AndAlso det.Iva.Length > 0 Then
                    sb.AppendLine("        <Iva>")
                    For Each iva In det.Iva
                        sb.AppendLine("          <AlicIva>")
                        sb.AppendLine($"            <Id>{iva.Id}</Id>")
                        sb.AppendLine($"            <BaseImp>{iva.BaseImp.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</BaseImp>")
                        sb.AppendLine($"            <Importe>{iva.Importe.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}</Importe>")
                        sb.AppendLine("          </AlicIva>")
                    Next
                    sb.AppendLine("        </Iva>")
                End If

                ' Opcionales (MiPyME)
                If det.Opcionales IsNot Nothing AndAlso det.Opcionales.Length > 0 Then
                    sb.AppendLine("        <Opcionales>")
                    For Each opc In det.Opcionales
                        sb.AppendLine("          <Opcional>")
                        sb.AppendLine($"            <Id>{opc.Id}</Id>")
                        sb.AppendLine($"            <Valor>{SecurityElement.Escape(opc.Valor)}</Valor>")
                        sb.AppendLine("          </Opcional>")
                    Next
                    sb.AppendLine("        </Opcionales>")
                End If

                ' Comprobantes Asociados (NC/ND)
                If det.CbtesAsoc IsNot Nothing AndAlso det.CbtesAsoc.Length > 0 Then
                    sb.AppendLine("        <CbtesAsoc>")
                    For Each asoc In det.CbtesAsoc
                        sb.AppendLine("          <CbteAsoc>")
                        sb.AppendLine($"            <Tipo>{asoc.Tipo}</Tipo>")
                        sb.AppendLine($"            <PtoVta>{asoc.PtoVta}</PtoVta>")
                        sb.AppendLine($"            <Nro>{asoc.Nro}</Nro>")
                        sb.AppendLine($"            <Cuit>{asoc.Cuit}</Cuit>")
                        If Not String.IsNullOrEmpty(asoc.CbteFch) Then
                            sb.AppendLine($"            <CbteFch>{asoc.CbteFch}</CbteFch>")
                        End If
                        sb.AppendLine("          </CbteAsoc>")
                    Next
                    sb.AppendLine("        </CbtesAsoc>")
                End If

                sb.AppendLine("      </FECAEDetRequest>")
            Next

            sb.AppendLine("    </FeDetReq>")
            sb.AppendLine("  </FeCAEReq>")
            sb.AppendLine("</FECAESolicitar>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetTiposCbteBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetTiposCbte xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetTiposCbte>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetTiposDocBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetTiposDoc xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetTiposDoc>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetTiposIvaBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetTiposIva xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetTiposIva>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetTiposMonedasBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetTiposMonedas xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetTiposMonedas>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetTiposConceptoBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetTiposConcepto xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetTiposConcepto>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetPtosVentaBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetPtosVenta xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetPtosVenta>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetCotizacionBody(auth As FEAuthRequest, moneda As String, fecha As String) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetCotizacion xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine($"  <MonId>{SecurityElement.Escape(moneda)}</MonId>")
            sb.AppendLine($"  <FchCotiz>{fecha}</FchCotiz>")
            sb.AppendLine("</FEParamGetCotizacion>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetTiposTributosBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetTiposTributos xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetTiposTributos>")
            Return sb.ToString()
        End Function

        Private Function CreateFEParamGetTiposOpcionalBody(auth As FEAuthRequest) As String
            Dim sb As New StringBuilder()
            sb.AppendLine("<FEParamGetTiposOpcional xmlns=""http://ar.gov.afip.dif.FEV1/"">")
            sb.Append(CreateAuthBody(auth))
            sb.AppendLine("</FEParamGetTiposOpcional>")
            Return sb.ToString()
        End Function

        ' ============================================
        ' MÉTODOS PRIVADOS - PARSE RESPONSES
        ' ============================================

        Private Function ParseFEDummyResponse(soapResponse As String) As FEDummyResponse
            Dim doc As New XmlDocument()
            doc.LoadXml(soapResponse)

            Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
            nsmgr.AddNamespace("ns1", "http://ar.gov.afip.dif.FEV1/")

            Dim response As New FEDummyResponse()
            response.AppServer = GetNodeValue(doc, "//ns1:AppServer", nsmgr)
            response.AuthServer = GetNodeValue(doc, "//ns1:AuthServer", nsmgr)
            response.DbServer = GetNodeValue(doc, "//ns1:DbServer", nsmgr)

            Return response
        End Function

        Private Function ParseFECompUltimoAutorizadoResponse(soapResponse As String) As FECompUltimoAutorizadoResponse
            Dim doc As New XmlDocument()
            doc.LoadXml(soapResponse)

            Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
            nsmgr.AddNamespace("ns1", "http://ar.gov.afip.dif.FEV1/")

            Dim response As New FECompUltimoAutorizadoResponse()
            Dim cbteNroStr = GetNodeValue(doc, "//ns1:CbteNro", nsmgr)
            If Not String.IsNullOrEmpty(cbteNroStr) Then
                response.CbteNro = CInt(cbteNroStr)
            End If

            response.Errors = ParseErrors(doc, nsmgr)

            Return response
        End Function

        Private Function ParseFECompConsultaResponse(soapResponse As String) As FECompConsultaResponse
            Dim doc As New XmlDocument()
            doc.LoadXml(soapResponse)

            Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
            nsmgr.AddNamespace("ns1", "http://ar.gov.afip.dif.FEV1/")

            Dim response As New FECompConsultaResponse()
            Dim resultNode = doc.SelectSingleNode("//ns1:ResultGet", nsmgr)

            If resultNode IsNot Nothing Then
                response.ResultGet = New FECompConsultaResult()
                response.ResultGet.CodAutorizacion = GetChildNodeValue(resultNode, "CodAutorizacion")
                response.ResultGet.DocNro = CLng(GetChildNodeValue(resultNode, "DocNro", "0"))
                response.ResultGet.ImpTotal = CDec(GetChildNodeValue(resultNode, "ImpTotal", "0"))
            End If

            Return response
        End Function

        Private Function ParseFECAEResponse(soapResponse As String) As FECAEResponse
            Dim doc As New XmlDocument()
            doc.LoadXml(soapResponse)

            Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
            nsmgr.AddNamespace("ns1", "http://ar.gov.afip.dif.FEV1/")

            Dim response As New FECAEResponse()

            ' Parse FeCabResp
            Dim cabNode = doc.SelectSingleNode("//ns1:FeCabResp", nsmgr)
            If cabNode IsNot Nothing Then
                response.FeCabResp = New FECabResp()
                response.FeCabResp.Cuit = CLng(GetChildNodeValue(cabNode, "Cuit", "0"))
                response.FeCabResp.PtoVta = CInt(GetChildNodeValue(cabNode, "PtoVta", "0"))
                response.FeCabResp.CbteTipo = CInt(GetChildNodeValue(cabNode, "CbteTipo", "0"))
                response.FeCabResp.FchProceso = GetChildNodeValue(cabNode, "FchProceso")
                response.FeCabResp.CantReg = CInt(GetChildNodeValue(cabNode, "CantReg", "0"))
                response.FeCabResp.Resultado = GetChildNodeValue(cabNode, "Resultado")
                response.FeCabResp.Reproceso = GetChildNodeValue(cabNode, "Reproceso")
            End If

            ' Parse FeDetResp
            Dim detNodes = doc.SelectNodes("//ns1:FECAEDetResponse", nsmgr)
            If detNodes IsNot Nothing AndAlso detNodes.Count > 0 Then
                Dim detList As New List(Of FEDetResp)()
                For Each detNode As XmlNode In detNodes
                    Dim det As New FEDetResp()
                    det.Concepto = CInt(GetChildNodeValue(detNode, "Concepto", "0"))
                    det.DocTipo = CInt(GetChildNodeValue(detNode, "DocTipo", "0"))
                    det.DocNro = CLng(GetChildNodeValue(detNode, "DocNro", "0"))
                    det.CbteDesde = CLng(GetChildNodeValue(detNode, "CbteDesde", "0"))
                    det.CbteHasta = CLng(GetChildNodeValue(detNode, "CbteHasta", "0"))
                    det.CbteFch = GetChildNodeValue(detNode, "CbteFch")
                    det.Resultado = GetChildNodeValue(detNode, "Resultado")
                    det.CAE = GetChildNodeValue(detNode, "CAE")
                    det.CAEFchVto = GetChildNodeValue(detNode, "CAEFchVto")
                    detList.Add(det)
                Next
                response.FeDetResp = detList.ToArray()
            End If

            response.Errors = ParseErrors(doc, nsmgr)

            Return response
        End Function

        Private Function ParseFEParamGetTiposCbteResponse(soapResponse As String) As FEParamGetTiposCbteResponse
            Return New FEParamGetTiposCbteResponse() With {.RawXml = soapResponse}
        End Function

        Private Function ParseFEParamGetTiposDocResponse(soapResponse As String) As FEParamGetTiposDocResponse
            Return New FEParamGetTiposDocResponse() With {.RawXml = soapResponse}
        End Function

        Private Function ParseFEParamGetPtosVentaResponse(soapResponse As String) As FEParamGetPtosVentaResponse
            Try
                Dim doc As New XmlDocument()
                doc.LoadXml(soapResponse)

                ' Crear namespace manager
                Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
                nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
                nsmgr.AddNamespace("ns", "http://ar.gov.afip.dif.FEV1/")

                ' Buscar el nodo de respuesta usando namespaces
                Dim resultNode = doc.SelectSingleNode("//ns:FEParamGetPtosVentaResponse/ns:FEParamGetPtosVentaResult", nsmgr)

                If resultNode Is Nothing Then
                    ' Intentar sin namespace
                    resultNode = doc.SelectSingleNode("//FEParamGetPtosVentaResult")
                End If

                Dim response As New FEParamGetPtosVentaResponse()

                If resultNode IsNot Nothing Then
                    ' Buscar ResultGet
                    Dim resultGetNode = resultNode.SelectSingleNode("ns:ResultGet", nsmgr)
                    If resultGetNode Is Nothing Then
                        resultGetNode = resultNode.SelectSingleNode("ResultGet")
                    End If

                    If resultGetNode IsNot Nothing Then
                        response.ResultGet = New FEPtosVentaResult()

                        ' Buscar todos los PtoVenta
                        Dim ptosVentaNodes = resultGetNode.SelectNodes("ns:PtoVenta", nsmgr)
                        If ptosVentaNodes Is Nothing OrElse ptosVentaNodes.Count = 0 Then
                            ptosVentaNodes = resultGetNode.SelectNodes("PtoVenta")
                        End If

                        If ptosVentaNodes IsNot Nothing AndAlso ptosVentaNodes.Count > 0 Then
                            Dim ptosList As New List(Of FEPtoVenta)()

                            For Each ptoNode As XmlNode In ptosVentaNodes
                                Dim pto As New FEPtoVenta() With {
                                    .Nro = Integer.Parse(GetChildNodeValue(ptoNode, "Nro", "0")),
                                    .EmisionTipo = GetChildNodeValue(ptoNode, "EmisionTipo"),
                                    .Bloqueado = GetChildNodeValue(ptoNode, "Bloqueado", "N"),
                                    .FchBaja = GetChildNodeValue(ptoNode, "FchBaja")
                                }
                                ptosList.Add(pto)
                            Next

                            response.ResultGet.PtoVenta = ptosList.ToArray()
                        End If
                    End If
                End If

                Return response

            Catch ex As Exception
                Console.WriteLine($"Error en ParseFEParamGetPtosVentaResponse: {ex.Message}")
                Throw
            End Try
        End Function

        Private Function ParseGenericResponse(soapResponse As String, responseType As String) As Object
            ' Implementación genérica para respuestas menos críticas
            Dim doc As New XmlDocument()
            doc.LoadXml(soapResponse)
            Return doc
        End Function

        Private Function ParseErrors(doc As XmlDocument, nsmgr As XmlNamespaceManager) As FEErr()
            Dim errorNodes = doc.SelectNodes("//ns1:Err", nsmgr)
            If errorNodes IsNot Nothing AndAlso errorNodes.Count > 0 Then
                Dim errorList As New List(Of FEErr)()
                For Each errNode As XmlNode In errorNodes
                    Dim err As New FEErr()
                    err.Code = CInt(GetChildNodeValue(errNode, "Code", "0"))
                    err.Msg = GetChildNodeValue(errNode, "Msg")
                    errorList.Add(err)
                Next
                Return errorList.ToArray()
            End If
            Return Nothing
        End Function

        Private Function GetNodeValue(doc As XmlDocument, xpath As String, nsmgr As XmlNamespaceManager, Optional defaultValue As String = "") As String
            Dim node = doc.SelectSingleNode(xpath, nsmgr)
            If node IsNot Nothing Then
                Return node.InnerText
            End If
            Return defaultValue
        End Function

        Private Function GetChildNodeValue(parentNode As XmlNode, childName As String, Optional defaultValue As String = "") As String
            ' Buscar el nodo sin usar XPath con prefijos
            For Each child As XmlNode In parentNode.ChildNodes
                If child.LocalName = childName Then
                    Return child.InnerText
                End If
            Next
            Return defaultValue
        End Function

    End Class

    ' ============================================
    ' CLASES DE DATOS PARA WSFE
    ' ============================================

    Public Class FEAuthRequest
        Public Property Token As String
        Public Property Sign As String
        Public Property Cuit As Long
    End Class

    Public Class FECompConsultaReq
        Public Property CbteTipo As Integer
        Public Property CbteNro As Integer
        Public Property PtoVta As Integer
    End Class

    Public Class FECAERequest
        Public Property FeCabReq As FECabReq
        Public Property FeDetReq As FEDetReq()
    End Class

    Public Class FECabReq
        Public Property CantReg As Integer
        Public Property PtoVta As Integer
        Public Property CbteTipo As Integer
    End Class

    Public Class FEDetReq
        Public Property Concepto As Integer
        Public Property DocTipo As Integer
        Public Property DocNro As Long
        Public Property CbteDesde As Long
        Public Property CbteHasta As Long
        Public Property CbteFch As String
        Public Property ImpTotal As Decimal
        Public Property ImpTotConc As Decimal
        Public Property ImpNeto As Decimal
        Public Property ImpOpEx As Decimal
        Public Property ImpTrib As Decimal
        Public Property ImpIVA As Decimal
        Public Property FchServDesde As String
        Public Property FchServHasta As String
        Public Property FchVtoPago As String
        Public Property MonId As String
        Public Property MonCotiz As Decimal
        Public Property Iva As FEIva()
        Public Property Opcionales As FEOpcional()
        Public Property CbtesAsoc As FECbtesAsoc()
    End Class

    Public Class FEIva
        Public Property Id As Integer
        Public Property BaseImp As Decimal
        Public Property Importe As Decimal
    End Class

    ' Respuestas
    Public Class FEDummyResponse
        Public Property AppServer As String
        Public Property AuthServer As String
        Public Property DbServer As String
    End Class

    Public Class FECompUltimoAutorizadoResponse
        Public Property CbteNro As Integer
        Public Property Errors As FEErr()
    End Class

    Public Class FECompConsultaResponse
        Public Property ResultGet As FECompConsultaResult
    End Class

    Public Class FECompConsultaResult
        Public Property CodAutorizacion As String
        Public Property DocNro As Long
        Public Property ImpTotal As Decimal
        Public Property Iva As FEIva()
    End Class

    Public Class FECAEResponse
        Public Property FeCabResp As FECabResp
        Public Property FeDetResp As FEDetResp()
        Public Property Errors As FEErr()
    End Class

    Public Class FECabResp
        Public Property Cuit As Long
        Public Property PtoVta As Integer
        Public Property CbteTipo As Integer
        Public Property FchProceso As String
        Public Property CantReg As Integer
        Public Property Resultado As String
        Public Property Reproceso As String
    End Class

    Public Class FEDetResp
        Public Property Concepto As Integer
        Public Property DocTipo As Integer
        Public Property DocNro As Long
        Public Property CbteDesde As Long
        Public Property CbteHasta As Long
        Public Property CbteFch As String
        Public Property Resultado As String
        Public Property CAE As String
        Public Property CAEFchVto As String
        Public Property Observaciones As FEObs()
    End Class

    Public Class FEObs
        Public Property Code As Integer
        Public Property Msg As String
    End Class

    Public Class FEErr
        Public Property Code As Integer
        Public Property Msg As String
    End Class

    Public Class FEParamGetTiposCbteResponse
        Public Property RawXml As String
    End Class

    Public Class FEParamGetTiposDocResponse
        Public Property RawXml As String
    End Class

    Public Class FEParamGetPtosVentaResponse
        Public Property ResultGet As FEPtosVentaResult
    End Class

    Public Class FEPtosVentaResult
        Public Property PtoVenta As FEPtoVenta()
    End Class

    Public Class FEPtoVenta
        Public Property Nro As Integer
        Public Property EmisionTipo As String
        Public Property Bloqueado As String
        Public Property FchBaja As String
    End Class

    ''' <summary>
    ''' Clase para opcionales MiPyME (CBU, Alias, Modo, etc.)
    ''' </summary>
    Public Class FEOpcional
        Public Property Id As Integer
        Public Property Valor As String
    End Class

    ''' <summary>
    ''' Clase para comprobantes asociados (NC/ND)
    ''' </summary>
    Public Class FECbtesAsoc
        Public Property Tipo As Integer
        Public Property PtoVta As Integer
        Public Property Nro As Long
        Public Property Cuit As Long
        Public Property CbteFch As String
    End Class

End Namespace
