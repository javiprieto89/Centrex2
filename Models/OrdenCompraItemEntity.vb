Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[ordenesCompras_items]
Public Class OrdenCompraItemEntity
    <Key>
    Public Property id_ordenCompraItem As Integer
    Public Property id_ordenCompra As Integer
    Public Property id_item As Integer
    Public Property cantidad As Decimal
    Public Property precio As Decimal
    Public Property observaciones As String
End Class

