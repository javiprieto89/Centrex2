' Entidad transacciones
Public Class TransaccionEntity
    Public Property IdTransaccion As Integer
    Public Property Fecha As Date
    Public Property IdCliente As Integer?
    Public Property IdProveedor As Integer?
    Public Property Importe As Decimal
    Public Property Descripcion As String
    Public Property Activo As Boolean
End Class

