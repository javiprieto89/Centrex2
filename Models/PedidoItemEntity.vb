' Entidad Item de Pedido según db/dbo.pedidos_items.Table.sql
Public Class PedidoItemEntity
    Public Property IdPedidoItem As Integer
    Public Property IdPedido As Integer?
    Public Property IdItem As Integer?
    Public Property Cantidad As Integer
    Public Property Precio As Decimal
    Public Property Activo As Boolean
    Public Property Descript As String

    Public Overridable Property Pedido As PedidoEntity
    Public Overridable Property Item As ItemEntity
End Class

