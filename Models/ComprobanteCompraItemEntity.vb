Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[comprobantes_compras_items]
Public Class ComprobanteCompraItemEntity
    <Key>
    Public Property id_comprobanteCompraItem As Integer
    Public Property id_comprobanteCompra As Integer
    Public Property id_item As Integer
    Public Property cantidad As Decimal
    Public Property precio As Decimal
    Public Property bonificacion As Decimal
    Public Property subtotal As Decimal
    Public Property observaciones As String
End Class

