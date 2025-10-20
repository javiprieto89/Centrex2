' Entidad Cobro según db/dbo.cobros.Table.sql
Public Class CobroEntity
    Public Property IdCobro As Integer
    Public Property IdCobroOficial As Integer
    Public Property IdCobroNoOficial As Integer
    Public Property FechaCarga As Date
    Public Property FechaCobro As Date
    Public Property IdCliente As Integer
    Public Property IdCc As Integer
    Public Property DineroEnCc As Decimal
    Public Property Efectivo As Decimal
    Public Property TotalTransferencia As Decimal
    Public Property TotalCh As Decimal
    Public Property TotalRetencion As Decimal
    Public Property Total As Decimal
    Public Property HayCheque As Boolean
    Public Property HayTransferencia As Boolean
    Public Property HayRetencion As Boolean
    Public Property Activo As Boolean
    Public Property IdAnulaCobro As Integer?
    Public Property Notas As String
    Public Property Firmante As String
End Class

