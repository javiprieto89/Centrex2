Imports Centrex.Afip.Models
Imports Centrex.Afip.Proxy
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

Namespace Afip
    ''' <summary>
    ''' Wrapper WSFEv1 usando Web References directas
    ''' Usa la configuración establecida por InicialesFE()
    ''' </summary>
    Public Class WSFEv1
        Private ReadOnly _mode As AfipMode
        Private ReadOnly _auth As AfipAuth
        Private _client As Proxy.WSFEClient

        ''' <summary>
        ''' Constructor privado - usar CreateWithTa para instanciar
        ''' </summary>
        Private Sub New(auth As AfipAuth, mode As AfipMode)
            _auth = auth
            _mode = mode

            ' Crear cliente con la URL correspondiente
            Dim url As String = AfipConfig.GetWsfeUrl(mode)
            _client = New Proxy.WSFEClient(url, AfipConfig.TimeoutSeconds)
        End Sub

        ''' <summary>
        ''' Crea una instancia de WSFEv1 con ticket de acceso
        ''' NOTA: Requiere que InicialesFE() haya sido llamado previamente
        ''' </summary>
        Public Shared Function CreateWithTa(mode As AfipMode) As WSFEv1
            Try
                ' Validar que la configuración esté inicializada
                Dim valid = AfipConfig.ValidateConfig(mode)
                If Not valid.isValid Then
                    Throw New InvalidOperationException($"Configuración no válida: {valid.errorMessage}. Debe llamar a InicialesFE() primero.")
                End If

                Console.WriteLine($"[WSFEv1] Creando instancia en modo {mode}")
                Console.WriteLine($"[WSFEv1] URL WSFE: {AfipConfig.GetWsfeUrl(mode)}")

                ' Obtener ticket de acceso
                Dim isTest = (mode = AfipMode.HOMO)
                Dim ta = WSAA.GetValidToken("wsfe", mode)

                ' Crear auth con el CUIT del emisor configurado en InicialesFE
                Dim auth = New AfipAuth With {
                    .Token = ta.Token,
                    .Sign = ta.Sign,
                    .Cuit = AfipConfig.GetCuitEmisor()
                }

                Console.WriteLine($"[WSFEv1] Token obtenido. CUIT: {auth.Cuit}")

                Return New WSFEv1(auth, mode)
            Catch ex As Exception
                Console.WriteLine("=== ERROR AL CREAR WSFEv1 ===")
                Console.WriteLine("Error: " & ex.Message)
                Console.WriteLine("Stack Trace: " & ex.StackTrace)

                ' Mostrar error detallado
                MostrarErrorDetallado("Error AFIP - WSFEv1", "Error al crear instancia WSFEv1",
                    "Error: " & ex.Message & vbCrLf & vbCrLf & "Stack Trace: " & ex.StackTrace)

                Throw New ApplicationException("Error al crear WSFEv1: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Prueba de conectividad con AFIP
        ''' </summary>
        Public Function FEDummy() As String
            Try
                Dim r = _client.FEDummy()
                Return $"AppServer: {r.AppServer}, AuthServer: {r.AuthServer}, DbServer: {r.DbServer}"
            Catch ex As Exception
                Throw New ApplicationException("Error en FEDummy: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Consulta el último comprobante autorizado
        ''' </summary>
        Public Function FECompUltimoAutorizado(ptoVta As Integer, cbteTipo As Integer) As Integer
            Try
                Dim auth = CreateAuthRequest()
                Dim r = _client.FECompUltimoAutorizado(auth, ptoVta, cbteTipo)

                If r.Errors IsNot Nothing AndAlso r.Errors.Length > 0 Then
                    Throw New ApplicationException(r.Errors(0).Msg)
                End If

                Return r.CbteNro
            Catch ex As Exception
                Throw New ApplicationException("Error en FECompUltimoAutorizado: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Consulta un comprobante específico
        ''' </summary>
        Public Function FECompConsultar(ptoVta As Integer, cbteTipo As Integer, cbteNro As Integer) As Object
            Try
                Dim auth = CreateAuthRequest()
                Dim req As New Proxy.FECompConsultaReq With {
                    .CbteNro = cbteNro,
                    .CbteTipo = cbteTipo,
                    .PtoVta = ptoVta
                }

                Dim r = _client.FECompConsultar(auth, req)
                Return r.ResultGet
            Catch ex As Exception
                Throw New ApplicationException("Error en FECompConsultar: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Solicita CAE para un comprobante
        ''' </summary>
        Public Function FECAESolicitar(request As Object) As Object
            Try
                Dim auth = CreateAuthRequest()

                ' Convertir el objeto genérico a FECAERequest del proxy
                Dim caeRequest As Proxy.FECAERequest = ConvertToFECAERequest(request)

                Dim response = _client.FECAESolicitar(auth, caeRequest)

                ' Convertir la respuesta a un formato compatible con el código existente
                Return ConvertFECAEResponseToObject(response)
            Catch ex As Exception
                Throw New ApplicationException("Error en FECAESolicitar: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene tipos de comprobantes
        ''' </summary>
        Public Function FEParamGetTiposCbte() As Object
            Try
                Dim auth = CreateAuthRequest()
                Return _client.FEParamGetTiposCbte(auth)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposCbte: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene tipos de documentos
        ''' </summary>
        Public Function FEParamGetTiposDoc() As Object
            Try
                Dim auth = CreateAuthRequest()
                Return _client.FEParamGetTiposDoc(auth)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposDoc: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene tipos de IVA
        ''' </summary>
        Public Function FEParamGetTiposIva() As Object
            Try
                Dim auth = CreateAuthRequest()
                Return _client.FEParamGetTiposIva(auth)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposIva: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene tipos de monedas
        ''' </summary>
        Public Function FEParamGetTiposMonedas() As Object
            Try
                Dim auth = CreateAuthRequest()
                Return _client.FEParamGetTiposMonedas(auth)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposMonedas: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene tipos de conceptos
        ''' </summary>
        Public Function FEParamGetTiposConcepto() As Object
            Try
                Dim auth = CreateAuthRequest()
                Return _client.FEParamGetTiposConcepto(auth)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposConcepto: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene puntos de venta habilitados
        ''' </summary>
        Public Function FEParamGetPtosVenta() As List(Of PtoVentaInfo)
            Try
                Console.WriteLine("=== CONSULTANDO PUNTOS DE VENTA HABILITADOS ===")
                Dim auth = CreateAuthRequest()

                Console.WriteLine("Auth creado: " & If(auth IsNot Nothing, "OK", "NULL"))

                ' Llamar al servicio
                Dim response = _client.FEParamGetPtosVenta(auth)

                Console.WriteLine("Response recibido: " & If(response IsNot Nothing, "OK", "NULL"))

                Dim resultList As New List(Of PtoVentaInfo)()

                ' Verificar cada nivel de la respuesta
                If response IsNot Nothing Then
                    Console.WriteLine("Response no es null")

                    If response.ResultGet IsNot Nothing Then
                        Console.WriteLine("ResultGet no es null")

                        If response.ResultGet.PtoVenta IsNot Nothing Then
                            Console.WriteLine($"PtoVenta array existe con {response.ResultGet.PtoVenta.Length} elementos")

                            For Each pto In response.ResultGet.PtoVenta
                                Console.WriteLine($"Procesando PtoVenta Nro: {pto.Nro}")

                                Dim info As New PtoVentaInfo() With {
                            .Nro = pto.Nro,
                            .EmisionTipo = If(pto.EmisionTipo, ""),
                            .Bloqueado = If(pto.Bloqueado, "N"),
                            .FchBaja = If(pto.FchBaja, "")
                        }
                                resultList.Add(info)

                                Console.WriteLine($"  - Tipo Emisión: {info.EmisionTipo}")
                                Console.WriteLine($"  - Bloqueado: {info.Bloqueado}")
                            Next
                        Else
                            Console.WriteLine("PtoVenta es NULL")
                        End If
                    Else
                        Console.WriteLine("ResultGet es NULL")
                    End If

                Else
                    Console.WriteLine("Response completo es NULL")
                End If

                Console.WriteLine($"Total puntos de venta encontrados: {resultList.Count}")
                Return resultList

            Catch ex As Exception
                Console.WriteLine("=== ERROR EN FEParamGetPtosVenta ===")
                Console.WriteLine("Error: " & ex.Message)
                If ex.InnerException IsNot Nothing Then
                    Console.WriteLine("Inner Exception: " & ex.InnerException.Message)
                End If
                Console.WriteLine("Stack Trace: " & ex.StackTrace)
                Throw New ApplicationException("Error en FEParamGetPtosVenta: " & ex.Message, ex)
            End Try
        End Function

        Private Function ParsePtosVentaXml(xmlString As String) As List(Of PtoVentaInfo)
            Dim resultList As New List(Of PtoVentaInfo)()

            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.LoadXml(xmlString)

                ' Crear namespace manager
                Dim nsmgr As New XmlNamespaceManager(xmlDoc.NameTable)
                nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
                nsmgr.AddNamespace("afip", "http://ar.gov.afip.dif.FEV1/")

                ' Buscar los nodos de puntos de venta
                Dim nodes = xmlDoc.SelectNodes("//afip:PtoVenta", nsmgr)

                For Each node As XmlNode In nodes
                    Dim info As New PtoVentaInfo() With {
                .Nro = Integer.Parse(node.SelectSingleNode("afip:Nro", nsmgr).InnerText),
                .EmisionTipo = node.SelectSingleNode("afip:EmisionTipo", nsmgr)?.InnerText,
                .Bloqueado = node.SelectSingleNode("afip:Bloqueado", nsmgr)?.InnerText,
                .FchBaja = node.SelectSingleNode("afip:FchBaja", nsmgr)?.InnerText
            }
                    resultList.Add(info)
                Next

            Catch ex As Exception
                Console.WriteLine($"Error parseando XML: {ex.Message}")
            End Try

            Return resultList
        End Function

        ''' <summary>
        ''' Obtiene cotización de moneda
        ''' </summary>
        Public Function FEParamGetCotizacion(moneda As String, Optional fecha As String = Nothing) As Object
            Try
                Dim auth = CreateAuthRequest()
                If String.IsNullOrEmpty(fecha) Then fecha = DateTime.Now.ToString("yyyyMMdd")
                Return _client.FEParamGetCotizacion(auth, moneda, fecha)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetCotizacion: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene tipos de tributos
        ''' </summary>
        Public Function FEParamGetTiposTributos() As Object
            Try
                Dim auth = CreateAuthRequest()
                Return _client.FEParamGetTiposTributos(auth)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposTributos: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene tipos opcionales
        ''' </summary>
        Public Function FEParamGetTiposOpcional() As Object
            Try
                Dim auth = CreateAuthRequest()
                Return _client.FEParamGetTiposOpcional(auth)
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposOpcional: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Crea el objeto de autenticación
        ''' </summary>
        Private Function CreateAuthRequest() As Proxy.FEAuthRequest
            Return New Proxy.FEAuthRequest With {
                .Token = _auth.Token,
                .Sign = _auth.Sign,
                .Cuit = _auth.Cuit
            }
        End Function

        ''' <summary>
        ''' Convierte un objeto genérico a FECAERequest
        ''' </summary>
        Private Function ConvertToFECAERequest(obj As Object) As Proxy.FECAERequest
            Try
                Dim request As New Proxy.FECAERequest()

                ' Obtener FeCabReq
                Dim feCabReq = GetPropertyValue(obj, "FeCabReq")
                If feCabReq IsNot Nothing Then
                    request.FeCabReq = New Proxy.FECabReq With {
                        .CantReg = CInt(GetPropertyValue(feCabReq, "CantReg")),
                        .PtoVta = CInt(GetPropertyValue(feCabReq, "PtoVta")),
                        .CbteTipo = CInt(GetPropertyValue(feCabReq, "CbteTipo"))
                    }
                End If

                ' Obtener FeDetReq array
                Dim feDetReqArray = GetPropertyValue(obj, "FeDetReq")
                If feDetReqArray IsNot Nothing Then
                    Dim detList As New List(Of Proxy.FEDetReq)()

                    For Each det In CType(feDetReqArray, Array)
                        Dim detReq As New Proxy.FEDetReq With {
                            .Concepto = CInt(GetPropertyValue(det, "Concepto")),
                            .DocTipo = CInt(GetPropertyValue(det, "DocTipo")),
                            .DocNro = CLng(GetPropertyValue(det, "DocNro")),
                            .CbteDesde = CLng(GetPropertyValue(det, "CbteDesde")),
                            .CbteHasta = CLng(GetPropertyValue(det, "CbteHasta")),
                            .CbteFch = CStr(GetPropertyValue(det, "CbteFch")),
                            .ImpTotal = CDec(GetPropertyValue(det, "ImpTotal")),
                            .ImpTotConc = CDec(GetPropertyValue(det, "ImpTotConc")),
                            .ImpNeto = CDec(GetPropertyValue(det, "ImpNeto")),
                            .ImpOpEx = CDec(GetPropertyValue(det, "ImpOpEx")),
                            .ImpTrib = CDec(GetPropertyValue(det, "ImpTrib")),
                            .ImpIVA = CDec(GetPropertyValue(det, "ImpIVA")),
                            .FchServDesde = CStrSafe(GetPropertyValue(det, "FchServDesde")),
                            .FchServHasta = CStrSafe(GetPropertyValue(det, "FchServHasta")),
                            .FchVtoPago = CStrSafe(GetPropertyValue(det, "FchVtoPago")),
                            .MonId = CStr(GetPropertyValue(det, "MonId")),
                            .MonCotiz = CDec(GetPropertyValue(det, "MonCotiz"))
                        }

                        ' Obtener array de IVA
                        Dim ivaArray = GetPropertyValue(det, "Iva")
                        If ivaArray IsNot Nothing Then
                            Dim ivaList As New List(Of Proxy.FEIva)()
                            For Each iva In CType(ivaArray, Array)
                                ivaList.Add(New Proxy.FEIva With {
                                    .Id = CInt(GetPropertyValue(iva, "Id")),
                                    .BaseImp = CDec(GetPropertyValue(iva, "BaseImp")),
                                    .Importe = CDec(GetPropertyValue(iva, "Importe"))
                                })
                            Next
                            detReq.Iva = ivaList.ToArray()
                        End If

                        detList.Add(detReq)
                    Next

                    request.FeDetReq = detList.ToArray()
                End If

                Return request
            Catch ex As Exception
                Throw New ApplicationException("Error al convertir FECAERequest: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Convierte FECAEResponse del proxy al formato esperado por el código existente
        ''' </summary>
        Private Function ConvertFECAEResponseToObject(response As Proxy.FECAEResponse) As Object
            ' Crear un objeto dinámico compatible usando objetos anónimos
            Dim cabResp = New With {
                .Cuit = response.FeCabResp.Cuit,
                .PtoVta = response.FeCabResp.PtoVta,
                .CbteTipo = response.FeCabResp.CbteTipo,
                .FchProceso = response.FeCabResp.FchProceso,
                .CantReg = response.FeCabResp.CantReg,
                .Resultado = response.FeCabResp.Resultado,
                .Reproceso = response.FeCabResp.Reproceso
            }

            Dim detRespList As New List(Of Object)()
            If response.FeDetResp IsNot Nothing Then
                For Each det In response.FeDetResp
                    Dim obsList As New List(Of Object)()
                    If det.Observaciones IsNot Nothing Then
                        For Each obs In det.Observaciones
                            obsList.Add(New With {
                                .Code = obs.Code,
                                .Msg = obs.Msg
                            })
                        Next
                    End If

                    detRespList.Add(New With {
                        .Concepto = det.Concepto,
                        .DocTipo = det.DocTipo,
                        .DocNro = det.DocNro,
                        .CbteDesde = det.CbteDesde,
                        .CbteHasta = det.CbteHasta,
                        .CbteFch = det.CbteFch,
                        .Resultado = det.Resultado,
                        .CAE = det.CAE,
                        .CAEFchVto = det.CAEFchVto,
                        .Observaciones = obsList.ToArray()
                    })
                Next
            End If

            Dim errList As New List(Of Object)()
            If response.Errors IsNot Nothing Then
                For Each errorItem In response.Errors
                    errList.Add(New With {
                        .Code = errorItem.Code,
                        .Msg = errorItem.Msg
                    })
                Next
            End If

            Dim result = New With {
                .FeCabResp = cabResp,
                .FeDetResp = detRespList.ToArray(),
                .Errors = errList.ToArray()
            }

            Return result
        End Function

        ''' <summary>
        ''' Obtiene el valor de una propiedad de un objeto dinámicamente
        ''' </summary>
        Private Function GetPropertyValue(obj As Object, propertyName As String) As Object
            If obj Is Nothing Then Return Nothing

            Dim propInfo = obj.GetType().GetProperty(propertyName)
            If propInfo IsNot Nothing Then
                Return propInfo.GetValue(obj, Nothing)
            End If
            Return Nothing
        End Function

        Private Function CStrSafe(obj As Object) As String
            If obj Is Nothing Then Return ""
            Return CStr(obj)
        End Function

        ''' <summary>
        ''' Verifica si un objeto tiene una propiedad
        ''' </summary>
        Private Function HasProperty(obj As Object, propertyName As String) As Boolean
            If obj Is Nothing Then Return False
            Return obj.GetType().GetProperty(propertyName) IsNot Nothing
        End Function

        Private Function SafeGetInt(obj As Object, propertyName As String) As Integer
            Try
                Dim val = GetPropertyValue(obj, propertyName)
                If val Is Nothing Then Return 0
                Return CInt(val)
            Catch
                Return 0
            End Try
        End Function

        Private Function SafeGetString(obj As Object, propertyName As String) As String
            Try
                Dim val = GetPropertyValue(obj, propertyName)
                If val Is Nothing Then Return ""
                Return CStr(val)
            Catch
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' Libera recursos
        ''' </summary>
        Public Sub Dispose()
            Try
                _client = Nothing
            Catch
            End Try
        End Sub

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
