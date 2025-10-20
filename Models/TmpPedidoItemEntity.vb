' Entidad temporal: tmppedidos_items
Imports System

Public Class TmpPedidoItemEntity
    Public Property IdTmpPedidoItem As Integer
    Public Property IdPedidoItem As Integer?
    Public Property IdPedido As Integer?
    Public Property IdItem As Integer?
    Public Property Cantidad As Decimal
    Public Property Precio As Decimal
    Public Property Activo As Boolean
    Public Property Descript As String
    Public Property IdUsuario As Integer
    Public Property IdUnico As Guid

    Public Overridable Property ItemEntity As ItemEntity
    Public Overridable Property PedidoItem As PedidoItemEntity
End Class

