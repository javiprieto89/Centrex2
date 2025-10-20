Namespace Afip
    ''' <summary>
    ''' Wrapper WSFEv1 (Service References: WSFEHomo / WSFEProd)
    ''' </summary>
    Public Class WSFEv1
        Private ReadOnly _mode As AfipMode
        Private ReadOnly _auth As AfipAuth
        Private _clienteHomo As WSFEHomo.ServiceSoapClient
        Private _clienteProd As WSFEProd.ServiceSoapClient

        Public Sub New(auth As AfipAuth, Optional mode As AfipMode = AfipMode.HOMO)
            _auth = auth
            _mode = mode
            If _mode = AfipMode.HOMO Then
                _clienteHomo = New WSFEHomo.ServiceSoapClient()
            Else
                _clienteProd = New WSFEProd.ServiceSoapClient()
            End If
        End Sub

        Public Shared Function CreateWithTa(Optional mode As AfipMode = AfipMode.HOMO) As WSFEv1
            Try
                Dim ta = WSAA.GetValidToken("wsfe", (mode = AfipMode.HOMO))
                Dim auth = New AfipAuth With {
                    .Token = ta.Token,
                    .Sign = ta.Sign,
                    .Cuit = AfipConfig.GetCuitEmisor()
                }
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

        Public Function FECompUltimoAutorizado(ptoVta As Integer, cbteTipo As Integer) As Integer
            Try
                Dim auth = CreateAuthRequest()
                If _mode = AfipMode.HOMO Then
                    Dim r = _clienteHomo.FECompUltimoAutorizado(auth, ptoVta, cbteTipo)
                    If r.Errors IsNot Nothing AndAlso r.Errors.Length > 0 Then Throw New ApplicationException(r.Errors(0).Msg)
                    Return r.CbteNro
                Else
                    Dim r = _clienteProd.FECompUltimoAutorizado(auth, ptoVta, cbteTipo)
                    If r.Errors IsNot Nothing AndAlso r.Errors.Length > 0 Then Throw New ApplicationException(r.Errors(0).Msg)
                    Return r.CbteNro
                End If
            Catch ex As Exception
                Throw New ApplicationException("Error en FECompUltimoAutorizado: " & ex.Message, ex)
            End Try
        End Function

        Public Function FECompConsultar(ptoVta As Integer, cbteTipo As Integer, cbteNro As Integer) As Object
            Try
                Dim auth = CreateAuthRequest()
                If _mode = AfipMode.HOMO Then
                    Dim req As New WSFEHomo.FECompConsultaReq With {.CbteNro = cbteNro, .CbteTipo = cbteTipo, .PtoVta = ptoVta}
                    Dim r = _clienteHomo.FECompConsultar(auth, req)
                    Return r.ResultGet
                Else
                    Dim req As New WSFEProd.FECompConsultaReq With {.CbteNro = cbteNro, .CbteTipo = cbteTipo, .PtoVta = ptoVta}
                    Dim r = _clienteProd.FECompConsultar(auth, req)
                    Return r.ResultGet
                End If
            Catch ex As Exception
                Throw New ApplicationException("Error en FECompConsultar: " & ex.Message, ex)
            End Try
        End Function

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

        Public Function FEParamGetPtosVenta() As Object
            Try
                Console.WriteLine("=== CONSULTANDO PUNTOS DE VENTA HABILITADOS ===")
                Dim auth = CreateAuthRequest()
                Dim resultado As Object
                
                If _mode = AfipMode.HOMO Then
                    resultado = _clienteHomo.FEParamGetPtosVenta(auth)
                Else
                    resultado = _clienteProd.FEParamGetPtosVenta(auth)
                End If
                
                Console.WriteLine("=== RESPUESTA FEParamGetPtosVenta ===")
                Console.WriteLine("Tipo de resultado: " & resultado.GetType().Name)
                Console.WriteLine("Resultado: " & resultado.ToString())
                
                ' Intentar mostrar información detallada si es posible
                Try
                    Dim resultadoStr As String = resultado.ToString()
                    Console.WriteLine("Resultado como string: " & resultadoStr)
                Catch
                    Console.WriteLine("No se pudo convertir resultado a string")
                End Try
                
                Return resultado
            Catch ex As Exception
                Console.WriteLine("=== ERROR EN FEParamGetPtosVenta ===")
                Console.WriteLine("Error: " & ex.Message)
                Console.WriteLine("Stack Trace: " & ex.StackTrace)
                Throw New ApplicationException("Error en FEParamGetPtosVenta: " & ex.Message, ex)
            End Try
        End Function

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

        Public Sub Dispose()
            Try
                If _clienteHomo IsNot Nothing Then _clienteHomo.Close() : _clienteHomo = Nothing
                If _clienteProd IsNot Nothing Then _clienteProd.Close() : _clienteProd = Nothing
            Catch
            End Try
        End Sub
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
