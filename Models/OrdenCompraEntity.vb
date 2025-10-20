Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[ordenes_compras]
Public Class OrdenCompraEntity
    <Key>
    Public Property id_ordenCompra As Integer
    Public Property id_proveedor As Integer?
    Public Property fecha As DateTime
    Public Property observaciones As String
    Public Property activo As Boolean
End Class

