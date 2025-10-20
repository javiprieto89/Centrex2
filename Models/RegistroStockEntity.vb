' Entidad registros_stock
Public Class RegistroStockEntity
    Public Property IdRegistroStock As Integer
    Public Property IdItem As Integer
    Public Property IdProveedor As Integer?
    Public Property Cantidad As Decimal
    Public Property Fecha As Date?
    Public Property Notas As String
End Class

