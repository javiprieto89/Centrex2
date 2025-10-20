' Entidad transferencias
Public Class TransferenciaEntity
    Public Property IdTransferencia As Integer
    Public Property IdCobro As Integer?
    Public Property IdPago As Integer?
    Public Property IdCuentaBancaria As Integer
    Public Property Fecha As Date
    Public Property Total As Decimal
    Public Property NComprobante As String
    Public Property Notas As String
End Class

