Imports System

Namespace Afip
    ' =========================
    ' AUTENTICACIÓN | TICKETS
    ' =========================
    Public Class AfipAuth
        Public Property Token As String
        Public Property Sign As String
        Public Property Cuit As Long
    End Class

    Public Class AfipTicket
        Public Property Token As String
        Public Property Sign As String
        Public Property Expiration As DateTime
        Public Function IsExpired() As Boolean
            Return DateTime.Now >= Expiration
        End Function
    End Class

    ' =========================
    ' ERRORES/OBSERVACIONES
    ' =========================
    Public Class AfipError
        Public Property Code As Integer
        Public Property Msg As String
    End Class

    Public Class AfipObservation
        Public Property Code As Integer
        Public Property Msg As String
    End Class

    ' =========================
    ' RESPUESTAS WSFE GENERALES
    ' =========================
    Public Class FeDetRespItem
        Public Property Concepto As Integer
        Public Property DocTipo As Integer
        Public Property DocNro As Long
        Public Property CbteDesde As Long
        Public Property CbteHasta As Long
        Public Property CbteFch As String
        Public Property Resultado As String
        Public Property CAE As String
        Public Property CAEFchVto As String
        Public Property Observaciones() As AfipObservation()
    End Class

    Public Class FeCabResp
        Public Property Cuit As Long
        Public Property PtoVta As Integer
        Public Property CbteTipo As Integer
        Public Property FchProceso As String
        Public Property CantReg As Integer
        Public Property Resultado As String
        Public Property Reproceso As String
    End Class

    Public Class FECaeResponse
        Public Property FeCabResp As FeCabResp
        Public Property FeDetResp() As FeDetRespItem()
        Public Property Errors() As AfipError()
    End Class

    Public Class FECompConsultarResult
        Public Property CbteDesde As Long
        Public Property CbteHasta As Long
        Public Property CbteTipo As Integer
        Public Property Concepto As Integer
        Public Property DocNro As Long
        Public Property DocTipo As Integer
        Public Property PtoVta As Integer
        Public Property Resultado As String
        Public Property CbteFch As String
        Public Property CAE As String
        Public Property CAEFchVto As String
        Public Property Observaciones() As AfipObservation()
        Public Property Errors() As AfipError()
    End Class
End Namespace
