' Entidad Pago según db/dbo.pagos.Table.sql
Public Class PagoEntity
    Public Property IdPago As Integer
    Public Property FechaCarga As Date?
    Public Property FechaPago As Date
    Public Property IdProveedor As Integer
    Public Property IdCc As Integer
    Public Property DineroEnCc As Decimal
    Public Property Efectivo As Decimal
    Public Property TotalTransferencia As Decimal
    Public Property TotalCh As Decimal
    Public Property Total As Decimal
    Public Property HayCheque As Boolean
    Public Property HayTransferencia As Boolean
    Public Property Activo As Boolean
    Public Property IdAnulaPago As Integer?
    Public Property Notas As String
End Class

