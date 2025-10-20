Imports Centrex.Afip.Models

Namespace Afip
    ''' <summary>
    ''' Wrapper WSFEv1 usando Web References directas
    ''' Usa la configuración establecida por InicialesFE()
    ''' </summary>
    Public Class WSFEv1
        Private ReadOnly _mode As AfipMode
        Private ReadOnly _auth As AfipAuth
        Private _client As WSFEClient

        ''' <summary>
        ''' Constructor privado - usar CreateWithTa para instanciar
        ''' </summary>
        Private Sub New(auth As AfipAuth, mode As AfipMode)
            _auth = auth
            _mode = mode
            
            ' Crear cliente con la URL correspondiente
            Dim url As String = AfipConfig.GetWsfeUrl(mode)
            _client = New WSFEClient(url, AfipConfig.TimeoutSeconds)
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
                Dim req As New FECompConsultaReq With {
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
                
                ' Convertir el objeto genérico a FECAERequest
                Dim caeRequest As FECAERequest = ConvertToFECAERequest(request)
                
                Dim response = _client.FECAESolicitar(auth, caeRequest)
                
                ' Convertir la respuesta a un formato compatible con el código existente
                Return ConvertFECAEResponse(response)
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
                Dim response = _client.FEParamGetPtosVenta(auth)
                
                Dim resultList As New List(Of PtoVentaInfo)()
                
                If response.ResultGet IsNot Nothing AndAlso response.ResultGet.PtoVenta IsNot Nothing Then
                    For Each pto In response.ResultGet.PtoVenta
                        Dim info As New PtoVentaInfo() With {
                            .Nro = pto.Nro,
                            .EmisionTipo = pto.EmisionTipo,
                            .Bloqueado = pto.Bloqueado,
                            .FchBaja = pto.FchBaja
                        }
                        resultList.Add(info)
                    Next
                Else
                    Console.WriteLine("No se encontraron puntos de venta.")
                End If

                Console.WriteLine($"Total puntos de venta: {resultList.Count}")
                Return resultList

            Catch ex As Exception
                Console.WriteLine("=== ERROR EN FEParamGetPtosVenta ===")
                Console.WriteLine("Error: " & ex.Message)
                Console.WriteLine("Stack Trace: " & ex.StackTrace)
                Throw New ApplicationException("Error en FEParamGetPtosVenta: " & ex.Message, ex)
            End Try
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
        Private Function CreateAuthRequest() As FEAuthRequest
            Return New FEAuthRequest With {
                .Token = _auth.Token,
                .Sign = _auth.Sign,
                .Cuit = _auth.Cuit
            }
        End Function

        ''' <summary>
        ''' Convierte un objeto genérico a FECAERequest
        ''' </summary>
        Private Function ConvertToFECAERequest(obj As Object) As FECAERequest
            Try
                Dim request As New FECAERequest()
                
                ' Obtener FeCabReq
                Dim feCabReq = GetPropertyValue(obj, "FeCabReq")
                If feCabReq IsNot Nothing Then
                    request.FeCabReq = New FECabReq With {
                        .CantReg = CInt(GetPropertyValue(feCabReq, "CantReg")),
                        .PtoVta = CInt(GetPropertyValue(feCabReq, "PtoVta")),
                        .CbteTipo = CInt(GetPropertyValue(feCabReq, "CbteTipo"))
                    }
                End If
                
                ' Obtener FeDetReq array
                Dim feDetReqArray = GetPropertyValue(obj, "FeDetReq")
                If feDetReqArray IsNot Nothing Then
                    Dim detList As New List(Of FEDetReq)()
                    
                    For Each det In CType(feDetReqArray, Array)
                        Dim detReq As New FEDetReq With {
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
                            Dim ivaList As New List(Of FEIva)()
                            For Each iva In CType(ivaArray, Array)
                                ivaList.Add(New FEIva With {
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
        ''' Convierte FECAEResponse al formato esperado por el código existente
        ''' </summary>
        Private Function ConvertFECAEResponse(response As FECAEResponse) As Object
            ' Crear un objeto dinámico compatible
            Dim result = New With {
                .FeCabResp = response.FeCabResp,
                .FeDetResp = ConvertFeDetResp(response.FeDetResp),
                .Errors = ConvertErrors(response.Errors)
            }
            Return result
        End Function

        Private Function ConvertFeDetResp(detArray As FEDetResp()) As Object()
            If detArray Is Nothing Then Return Nothing
            
            Dim list As New List(Of Object)()
            For Each det In detArray
                list.Add(New With {
                    .Concepto = det.Concepto,
                    .DocTipo = det.DocTipo,
                    .DocNro = det.DocNro,
                    .CbteDesde = det.CbteDesde,
                    .CbteHasta = det.CbteHasta,
                    .CbteFch = det.CbteFch,
                    .Resultado = det.Resultado,
                    .CAE = det.CAE,
                    .CAEFchVto = det.CAEFchVto,
                    .Observaciones = ConvertObservaciones(det.Observaciones)
                })
            Next
            Return list.ToArray()
        End Function

        Private Function ConvertObservaciones(obsArray As FEObs()) As Object()
            If obsArray Is Nothing Then Return Nothing
            
            Dim list As New List(Of Object)()
            For Each obs In obsArray
                list.Add(New With {
                    .Code = obs.Code,
                    .Msg = obs.Msg
                })
            Next
            Return list.ToArray()
        End Function

        Private Function ConvertErrors(errArray As FEErr()) As Object()
            If errArray Is Nothing Then Return Nothing
            
            Dim list As New List(Of Object)()
            For Each err In errArray
                list.Add(New With {
                    .Code = err.Code,
                    .Msg = err.Msg
                })
            Next
            Return list.ToArray()
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
