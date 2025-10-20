' Entidad temporal: tmppedidos_items
Public Class TmpPedidoItemEntity
    Public Property IdTmpPedidoItem As Integer
    Public Property IdPedido As Integer
    Public Property IdItem As Integer
    Public Property Cantidad As Decimal
    Public Property Precio As Decimal
    Public Property Descuento As Decimal?
    Public Property IdUsuario As Integer?
End Class

