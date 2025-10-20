Imports Centrex.Afip.Models

Namespace Afip
    ''' <summary>
    ''' Wrapper WSFEv1 (Service References: WSFEHomo / WSFEProd)
    ''' Usa la configuración establecida por InicialesFE()
    ''' 
    ''' Service References requeridos en el proyecto:
    ''' - WSFEHomo: https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL
    ''' - WSFEProd: https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL
    ''' </summary>
    Public Class WSFEv1
        Private ReadOnly _mode As AfipMode
        Private ReadOnly _auth As AfipAuth
        Private _clienteHomo As WSFEHomo.ServiceSoapClient
        Private _clienteProd As WSFEProd.ServiceSoapClient

        ''' <summary>
        ''' Constructor privado - usar CreateWithTa para instanciar
        ''' </summary>
        Private Sub New(auth As AfipAuth, mode As AfipMode)
            _auth = auth
            _mode = mode
            If _mode = AfipMode.HOMO Then
                _clienteHomo = New WSFEHomo.ServiceSoapClient()
            Else
                _clienteProd = New WSFEProd.ServiceSoapClient()
            End If
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
                If _mode = AfipMode.HOMO Then
                    Dim r = _clienteHomo.FEDummy()
                    Return $"AppServer: {r.AppServer}, AuthServer: {r.AuthServer}, DbServer: {r.DbServer}"
                Else
                    Dim r = _clienteProd.FEDummy()
                    Return $"AppServer: {r.AppServer}, AuthServer: {r.AuthServer}, DbServer: {r.DbServer}"
                End If
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
                If _mode = AfipMode.HOMO Then
                    Dim r = _clienteHomo.FECompUltimoAutorizado(auth, ptoVta, cbteTipo)
                    If r.Errors IsNot Nothing AndAlso r.Errors.Length > 0 Then
                        Throw New ApplicationException(r.Errors(0).Msg)
                    End If
                    Return r.CbteNro
                Else
                    Dim r = _clienteProd.FECompUltimoAutorizado(auth, ptoVta, cbteTipo)
                    If r.Errors IsNot Nothing AndAlso r.Errors.Length > 0 Then
                        Throw New ApplicationException(r.Errors(0).Msg)
                    End If
                    Return r.CbteNro
                End If
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
                If _mode = AfipMode.HOMO Then
                    Dim req As New WSFEHomo.FECompConsultaReq With {
                        .CbteNro = cbteNro,
                        .CbteTipo = cbteTipo,
                        .PtoVta = ptoVta
                    }
                    Dim r = _clienteHomo.FECompConsultar(auth, req)
                    Return r.ResultGet
                Else
                    Dim req As New WSFEProd.FECompConsultaReq With {
                        .CbteNro = cbteNro,
                        .CbteTipo = cbteTipo,
                        .PtoVta = ptoVta
                    }

                    Dim r = _clienteProd.FECompConsultar(auth, req)
                    Return r.ResultGet
                End If
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FECAESolicitar(auth, CType(request, WSFEHomo.FECAERequest))
                Else
                    Return _clienteProd.FECAESolicitar(auth, CType(request, WSFEProd.FECAERequest))
                End If
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FEParamGetTiposCbte(auth)
                Else
                    Return _clienteProd.FEParamGetTiposCbte(auth)
                End If
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FEParamGetTiposDoc(auth)
                Else
                    Return _clienteProd.FEParamGetTiposDoc(auth)
                End If
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FEParamGetTiposIva(auth)
                Else
                    Return _clienteProd.FEParamGetTiposIva(auth)
                End If
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FEParamGetTiposMonedas(auth)
                Else
                    Return _clienteProd.FEParamGetTiposMonedas(auth)
                End If
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposMonedas: " & ex.Message, ex)
            End Try
        End Function

        ' Métodos auxiliares para leer propiedades dinámicas de objetos SOAP
        Private Function HasProperty(obj As Object, propName As String) As Boolean
            Return obj IsNot Nothing AndAlso obj.GetType().GetProperty(propName) IsNot Nothing
        End Function

        Private Function GetPropertyValue(obj As Object, propName As String) As Object
            Dim p = obj.GetType().GetProperty(propName)
            If p IsNot Nothing Then Return p.GetValue(obj)
            Return Nothing
        End Function

        Private Function SafeGetString(obj As Object, propName As String) As String
            Try
                Dim p = obj.GetType().GetProperty(propName)
                If p IsNot Nothing Then
                    Dim v = p.GetValue(obj)
                    If v IsNot Nothing Then Return v.ToString()
                End If
            Catch
            End Try
            Return ""
        End Function

        Private Function SafeGetInt(obj As Object, propName As String) As Integer
            Try
                Dim s = SafeGetString(obj, propName)
                Dim n As Integer
                If Integer.TryParse(s, n) Then Return n
            Catch
            End Try
            Return 0
        End Function

        ''' <summary>
        ''' Obtiene puntos de venta habilitados
        ''' </summary>
        Public Function FEParamGetPtosVenta() As List(Of PtoVentaInfo)
            Try
                Console.WriteLine("=== CONSULTANDO PUNTOS DE VENTA HABILITADOS ===")
                Dim authXML As Object
                If _mode = AfipMode.HOMO Then
                    authXML = New WSFEHomo.FEAuthRequest()
                    authXML.Token = _auth.Token
                    authXML.Sign = _auth.Sign
                    authXML.Cuit = CLng(_auth.Cuit)
                    'Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(WSFEHomo.FEAuthRequest))
                Else
                    authXML = New WSFEProd.FEAuthRequest()
                    authXML.Token = _auth.Token
                    authXML.Sign = _auth.Sign
                    authXML.Cuit = CLng(_auth.Cuit)
                    'Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(WSFEProd.FEAuthRequest))
                End If
                Dim response As Object

                ' Llamar al WSFE según el modo
                If _mode = AfipMode.HOMO Then
                    response = _clienteHomo.FEParamGetPtosVenta(authXML)
                Else
                    response = _clienteProd.FEParamGetPtosVenta(authXML)
                End If

                ' Intentar acceder a la estructura real del resultado
                Dim resultList As New List(Of PtoVentaInfo)()

                ' Dependiendo de cómo el proxy genere las clases,
                ' el resultado suele tener la forma:
                ' response.FEParamGetPtosVentaResult.ResultGet.PtoVenta
                ' pero algunos proxies simplifican a response.ResultGet.PtoVenta
                Dim resultGet = Nothing

                If HasProperty(response, "FEParamGetPtosVentaResult") Then
                    resultGet = GetPropertyValue(response.FEParamGetPtosVentaResult, "ResultGet")
                ElseIf HasProperty(response, "ResultGet") Then
                    resultGet = response.ResultGet
                Else
                    Console.WriteLine("No se encontró ResultGet en la respuesta.")
                End If

                If resultGet IsNot Nothing AndAlso HasProperty(resultGet, "PtoVenta") Then
                    Dim puntos = resultGet.PtoVenta

                    ' Convertir cada elemento a una estructura manejable
                    For Each pto In puntos
                        Dim info As New PtoVentaInfo() With {
                    .Nro = SafeGetInt(pto, "Nro"),
                    .EmisionTipo = SafeGetString(pto, "EmisionTipo"),
                    .Bloqueado = SafeGetString(pto, "Bloqueado"),
                    .FchBaja = SafeGetString(pto, "FchBaja")
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FEParamGetCotizacion(auth, moneda, fecha)
                Else
                    Return _clienteProd.FEParamGetCotizacion(auth, moneda, fecha)
                End If
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FEParamGetTiposTributos(auth)
                Else
                    Return _clienteProd.FEParamGetTiposTributos(auth)
                End If
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
                If _mode = AfipMode.HOMO Then
                    Return _clienteHomo.FEParamGetTiposOpcional(auth)
                Else
                    Return _clienteProd.FEParamGetTiposOpcional(auth)
                End If
            Catch ex As Exception
                Throw New ApplicationException("Error en FEParamGetTiposOpcional: " & ex.Message, ex)
            End Try
        End Function

        ''' <summary>
        ''' Crea el objeto de autenticación según el modo
        ''' </summary>
        Private Function CreateAuthRequest() As Object
            If _mode = AfipMode.HOMO Then
                Return New WSFEHomo.FEAuthRequest With {
                    .Token = _auth.Token,
                    .Sign = _auth.Sign,
                    .Cuit = _auth.Cuit
                }
            Else
                Return New WSFEProd.FEAuthRequest With {
                    .Token = _auth.Token,
                    .Sign = _auth.Sign,
                    .Cuit = _auth.Cuit
                }
            End If
        End Function

        ''' <summary>
        ''' Libera recursos
        ''' </summary>
        Public Sub Dispose()
            Try
                If _clienteHomo IsNot Nothing Then
                    _clienteHomo.Close()
                    _clienteHomo = Nothing
                End If
                If _clienteProd IsNot Nothing Then
                    _clienteProd.Close()
                    _clienteProd = Nothing
                End If
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
