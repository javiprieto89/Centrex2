Namespace Afip
    Public Enum AfipMode
        HOMO
        PROD
    End Enum

    ''' <summary>
    ''' Configuración centralizada de AFIP
    ''' Ahora depende completamente de InicialesFE de factura_electronica.vb
    ''' </summary>
    Public NotInheritable Class AfipConfig
        Private Sub New()
        End Sub

        ' ============================================
        ' CONFIGURACIÓN DINÁMICA (Establecida por InicialesFE)
        ' ============================================
        Public Shared Property DynamicCertPath As String = Nothing
        Public Shared Property DynamicCertPassword As String = Nothing
        Public Shared Property DynamicCuitEmisor As Long? = Nothing

        ' ============================================
        ' MODO OPERACIÓN
        ' ============================================
        Private Shared _mode As AfipMode = AfipMode.HOMO
        Public Shared Property Mode As AfipMode
            Get
                Return _mode
            End Get
            Set(value As AfipMode)
                _mode = value
            End Set
        End Property

        ' ============================================
        ' SERVICE REFERENCES
        ' ============================================
        ' Los service references ya están agregados al proyecto:
        ' - WSAAHomo: https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl
        ' - WSAAProd: https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl
        ' - WSFEHomo: https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL
        ' - WSFEProd: https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL
        ' No es necesario configurar URLs manualmente

        ' ============================================
        ' CERTIFICADO (desde InicialesFE)
        ' ============================================
        Public Shared Function GetCertPath(mode As AfipMode) As String
            If String.IsNullOrWhiteSpace(DynamicCertPath) Then
                Throw New InvalidOperationException("Debe llamar a InicialesFE() antes de usar los servicios AFIP")
            End If
            Return DynamicCertPath
        End Function

        Public Shared Function GetCertPassword(mode As AfipMode) As String
            If String.IsNullOrWhiteSpace(DynamicCertPassword) Then
                Throw New InvalidOperationException("Debe llamar a InicialesFE() antes de usar los servicios AFIP")
            End If
            Return DynamicCertPassword
        End Function

        Public Shared ReadOnly Property CertPath As String
            Get
                Return GetCertPath(Mode)
            End Get
        End Property

        Public Shared ReadOnly Property CertPassword As String
            Get
                Return GetCertPassword(Mode)
            End Get
        End Property

        ' ============================================
        ' CUIT EMISOR (desde InicialesFE)
        ' ============================================
        Public Shared Function GetCuitEmisor() As Long
            If Not DynamicCuitEmisor.HasValue OrElse DynamicCuitEmisor.Value <= 0 Then
                Throw New InvalidOperationException("Debe llamar a InicialesFE() antes de usar los servicios AFIP")
            End If
            Return DynamicCuitEmisor.Value
        End Function

        ' ============================================
        ' TIMEOUT
        ' ============================================
        Public Shared ReadOnly Property TimeoutSeconds As Integer
            Get
                Return 60
            End Get
        End Property

        ' ============================================
        ' UTILIDAD
        ' ============================================
        Public Shared Sub ClearDynamicConfig()
            DynamicCertPath = Nothing
            DynamicCertPassword = Nothing
            DynamicCuitEmisor = Nothing
        End Sub

        Public Shared Function IsConfigured() As Boolean
            Return Not String.IsNullOrWhiteSpace(DynamicCertPath) AndAlso
                   Not String.IsNullOrWhiteSpace(DynamicCertPassword) AndAlso
                   DynamicCuitEmisor.HasValue AndAlso
                   DynamicCuitEmisor.Value > 0
        End Function

        Public Shared Function GetConfigSummary(mode As AfipMode) As String
            Try
                Dim summary As New System.Text.StringBuilder()
                summary.AppendLine("=== CONFIGURACIÓN AFIP ===")
                summary.AppendLine($"Modo: {mode}")
                summary.AppendLine($"Service References: WSAAHomo, WSAAProd, WSFEHomo, WSFEProd (ya configurados en el proyecto)")

                If IsConfigured() Then
                    summary.AppendLine($"Certificado: {DynamicCertPath}")
                    summary.AppendLine($"Certificado existe: {System.IO.File.Exists(DynamicCertPath)}")
                    summary.AppendLine($"CUIT Emisor: {DynamicCuitEmisor.Value}")
                    summary.AppendLine($"Password configurado: Sí")
                    summary.AppendLine("✓ Configuración establecida por InicialesFE()")
                Else
                    summary.AppendLine("⚠️ NO CONFIGURADO - Debe llamar a InicialesFE() primero")
                End If
                Return summary.ToString()
            Catch ex As Exception
                Return "Error al obtener configuración: " & ex.Message
            End Try
        End Function

        Public Shared Function ValidateConfig(mode As AfipMode) As (isValid As Boolean, errorMessage As String)
            Try
                If Not IsConfigured() Then
                    Return (False, "No se ha llamado a InicialesFE(). Configure certificado, password y CUIT primero.")
                End If
                If Not System.IO.File.Exists(DynamicCertPath) Then
                    Return (False, $"El certificado no existe en: {DynamicCertPath}")
                End If
                If DynamicCuitEmisor.Value <= 0 Then
                    Return (False, "El CUIT emisor es inválido")
                End If
                Return (True, "Configuración válida")
            Catch ex As Exception
                Return (False, $"Error al validar configuración: {ex.Message}")
            End Try
        End Function
    End Class
End Namespace
