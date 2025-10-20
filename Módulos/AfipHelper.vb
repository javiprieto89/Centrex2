Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports Centrex.Afip

''' <summary>
''' Módulo helper para funciones auxiliares de AFIP
''' NOTA: La configuración principal está en InicialesFE de factura_electronica.vb
''' Este módulo solo proporciona funciones auxiliares específicas
''' </summary>
Module AfipHelper

    ''' <summary>
    ''' Obtiene el CUIT emisor desde la configuración de AFIP
    ''' </summary>
    Public Function GetCuitEmisor() As Long
        Try
            ' Obtener desde la configuración establecida por InicialesFE
            Return AfipConfig.GetCuitEmisor()
        Catch ex As Exception
            Console.WriteLine($"[AfipHelper] Error obteniendo CUIT emisor: {ex.Message}")
            Throw New InvalidOperationException("Debe llamar a InicialesFE() antes de usar GetCuitEmisor()", ex)
        End Try
    End Function

    ''' <summary>
    ''' Valida que el certificado AFIP existe y es válido
    ''' </summary>
    Public Function ValidateAfipCertificate(certPath As String, certPassword As String) As Boolean
        Try
            If Not File.Exists(certPath) Then
                Console.WriteLine($"[AfipHelper] Certificado no existe: {certPath}")
                Return False
            End If

            Using cert As New X509Certificate2(certPath, certPassword, X509KeyStorageFlags.PersistKeySet)
                Dim isValid = cert.Verify()
                Console.WriteLine($"[AfipHelper] Certificado válido: {isValid}")
                Return isValid
            End Using
        Catch ex As Exception
            Console.WriteLine($"[AfipHelper] Error validando certificado: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el próximo número de comprobante para un punto de venta y tipo
    ''' Usa la configuración establecida por InicialesFE
    ''' </summary>
    Public Function GetNextComprobanteNumber(puntoVenta As Integer, tipoComprobante As Integer, esTest As Boolean) As Integer
        Try
            ' Llamar a la función del módulo factura_electronica que ya tiene la lógica
            Dim ultimoNumero As Integer = ConsultaUltimoComprobante(puntoVenta, tipoComprobante, esTest)
            Return ultimoNumero + 1
        Catch ex As Exception
            Throw New Exception($"Error obteniendo próximo número de comprobante: {ex.Message}", ex)
        End Try
    End Function

    ''' <summary>
    ''' Clase simple para datos de comprobante (si se necesita)
    ''' </summary>
    Public Class ComprobanteData
        Public Property CantReg As Integer
        Public Property PtoVta As Integer
        Public Property CbteTipo As Integer
        Public Property FchVto As Date
        Public Property ImpTotal As Decimal
        Public Property ImpTotConc As Decimal
        Public Property ImpNeto As Decimal
        Public Property ImpOpEx As Decimal
        Public Property ImpTrib As Decimal
        Public Property ImpIVA As Decimal
        Public Property MonId As String
        Public Property MonCotiz As Decimal
        Public Property DocTipo As Integer
        Public Property DocNro As Long
        Public Property CbteFch As String
    End Class

    ''' <summary>
    ''' Valida los datos de un comprobante antes de enviarlo a AFIP
    ''' </summary>
    Public Function ValidateComprobanteData(comprobante As ComprobanteData) As List(Of String)
        Dim errors As New List(Of String)()

        ' Validar CUIT del cliente
        If comprobante.DocTipo <= 0 OrElse comprobante.DocNro <= 0 Then
            errors.Add("CUIT del cliente es requerido")
        End If

        ' Validar importes
        If comprobante.ImpTotal <= 0 Then
            errors.Add("El importe total debe ser mayor a cero")
        End If

        ' Validar fecha
        If comprobante.FchVto < DateTime.Now Then
            errors.Add("La fecha de vencimiento no puede ser anterior a hoy")
        End If

        ' Validar punto de venta
        If comprobante.PtoVta <= 0 Then
            errors.Add("El punto de venta debe ser mayor a cero")
        End If

        Return errors
    End Function

    ''' <summary>
    ''' Convierte un comprobante del sistema a ComprobanteData de AFIP
    ''' </summary>
    Public Function ConvertToAfipComprobante(pedido As pedido, cliente As cliente) As ComprobanteData

        Dim comprobante As New ComprobanteData()

        ' Datos básicos
        comprobante.CantReg = 1
        comprobante.PtoVta = CInt(pedido.puntoVenta)
        comprobante.CbteTipo = CInt(pedido.tipoComprobante)
        comprobante.FchVto = pedido.fechaVencimiento_cae
        comprobante.ImpTotal = CDec(pedido.total)
        comprobante.ImpTotConc = 0
        comprobante.ImpNeto = CDec(pedido.subTotal)
        comprobante.ImpOpEx = 0
        comprobante.ImpTrib = 0
        comprobante.ImpIVA = CDec(pedido.iva)
        comprobante.MonId = "PES"
        comprobante.MonCotiz = 1

        ' Datos del cliente
        comprobante.DocTipo = 80 ' CUIT
        comprobante.DocNro = CLng(cliente.taxNumber)

        ' Items del comprobante
        comprobante.CbteFch = pedido.fecha.ToString()

        Return comprobante
    End Function

    ''' <summary>
    ''' Guarda el código QR en la base de datos
    ''' </summary>
    Public Function SaveQRToDatabase(pedidoId As Integer, qrCode As String) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim pedido = context.Pedidos.FirstOrDefault(Function(p) p.IdPedido = pedidoId)
                If pedido Is Nothing Then Return False
                ' soporta ambos nombres segun entidad
                Try
                    pedido.CodigoQR = qrCode
                Catch
                    ' fallback a posible campo fc_qr
                    pedido.fc_qr = qrCode
                End Try
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            Throw New Exception($"Error guardando QR en base de datos: {ex.Message}", ex)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene resumen de la configuración actual de AFIP
    ''' </summary>
    Public Function GetConfigSummary(modo As AfipMode) As String
        Try
            If Not AfipConfig.IsConfigured() Then
                Return "⚠️ No hay configuración AFIP inicializada. Debe llamar a InicialesFE() primero."
            End If

            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("=== CONFIGURACIÓN AFIP ===")
            sb.AppendLine($"Modo: {If(modo = AfipMode.HOMO, "HOMOLOGACIÓN", "PRODUCCIÓN")}")
            sb.AppendLine($"WSAA URL: {AfipConfig.GetWsaaUrl(modo)}")
            sb.AppendLine($"WSFE URL: {AfipConfig.GetWsfeUrl(modo)}")
            sb.AppendLine($"Certificado: {AfipConfig.DynamicCertPath}")
            sb.AppendLine($"Certificado existe: {If(String.IsNullOrEmpty(AfipConfig.DynamicCertPath), False, File.Exists(AfipConfig.DynamicCertPath))}")
            sb.AppendLine($"CUIT Emisor: {AfipConfig.DynamicCuitEmisor}")
            sb.AppendLine($"Configurado: {AfipConfig.IsConfigured()}")

            Return sb.ToString()
        Catch ex As Exception
            Return $"Error obteniendo resumen de configuración: {ex.Message}"
        End Try
    End Function

    ''' <summary>
    ''' Verifica si hay una configuración válida de AFIP
    ''' </summary>
    Public Function TieneConfiguracionValida() As Boolean
        Try
            Return AfipConfig.IsConfigured()
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la configuración actual en un objeto simple
    ''' </summary>
    Public Function ObtenerConfiguracionActual() As Object
        Try
            If Not AfipConfig.IsConfigured() Then
                Return Nothing
            End If

            Return New With {
                .Modo = If(AfipConfig.Mode = AfipMode.HOMO, "HOMOLOGACIÓN", "PRODUCCIÓN"),
                .EsTest = (AfipConfig.Mode = AfipMode.HOMO),
                .ArchivoCertificado = AfipConfig.DynamicCertPath,
                .CuitEmisor = AfipConfig.DynamicCuitEmisor.ToString(),
                .AfipMode = AfipConfig.Mode
            }
        Catch ex As Exception
            Console.WriteLine($"[AfipHelper] Error obteniendo configuración: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Valida que la configuración actual sea válida
    ''' </summary>
    Public Function ValidateCurrentConfig() As (isValid As Boolean, errorMessage As String)
        Try
            If Not TieneConfiguracionValida() Then
                Return (False, "No se ha llamado a InicialesFE(). Debe inicializar la configuración primero.")
            End If

            Dim config = ObtenerConfiguracionActual()
            If config Is Nothing Then
                Return (False, "No se pudo obtener la configuración actual")
            End If

            If Not File.Exists(config.ArchivoCertificado) Then
                Return (False, $"El certificado no existe en: {config.ArchivoCertificado}")
            End If

            If String.IsNullOrWhiteSpace(config.CuitEmisor) OrElse config.CuitEmisor = "0" Then
                Return (False, "El CUIT emisor no está configurado")
            End If

            Return (True, "Configuración válida")
        Catch ex As Exception
            Return (False, $"Error al validar configuración: {ex.Message}")
        End Try
    End Function

End Module
