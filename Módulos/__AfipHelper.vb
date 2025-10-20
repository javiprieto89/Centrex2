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
            Dim ultimoNumero As Integer = ConsultaUltimoComprobante(puntoVenta.ToString(), tipoComprobante.ToString(), esTest)
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
            Dim sql As String = "UPDATE pedidos SET codigoQR = @qrCode WHERE id_pedido = @pedidoId"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@qrCode", qrCode},
                {"@pedidoId", pedidoId}
            }

            ExecuteNonQuery(sql, parameters)
            Return True
        Catch ex As Exception
            Throw New Exception($"Error guardando QR en base de datos: {ex.Message}", ex)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene resumen de la configuración actual
    ''' </summary>
    Public Function GetConfigSummary() As String
        Try
            Dim config = ObtenerConfiguracionActual()
            If config Is Nothing Then
                Return "⚠️ No hay configuración AFIP inicializada. Debe llamar a InicialesFE() primero."
            End If

            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("=== CONFIGURACIÓN AFIP (desde InicialesFE) ===")
            sb.AppendLine($"Modo: {config.Modo}")
            sb.AppendLine($"Es Test: {config.EsTest}")
            sb.AppendLine($"Certificado: {config.ArchivoCertificado}")
            sb.AppendLine($"Certificado existe: {File.Exists(config.ArchivoCertificado)}")
            sb.AppendLine($"CUIT Emisor: {config.CuitEmisor}")
            sb.AppendLine($"AfipMode: {config.AfipMode}")

            Return sb.ToString()
        Catch ex As Exception
            Return $"Error obteniendo resumen de configuración: {ex.Message}"
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

            If Not File.Exists(config.ArchivoCertificado) Then
                Return (False, $"El certificado no existe en: {config.ArchivoCertificado}")
            End If

            If String.IsNullOrWhiteSpace(config.CuitEmisor) Then
                Return (False, "El CUIT emisor no está configurado")
            End If

            Return (True, "Configuración válida")
        Catch ex As Exception
            Return (False, $"Error al validar configuración: {ex.Message}")
        End Try
    End Function

End Module
