Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[produccion_asocItems] (si existe en DB principal)
Public Class ProduccionAsocItemEntity
    <Key>
    Public Property id_produccionAsocItem As Integer
    Public Property id_produccionItem As Integer?
    Public Property id_produccion As Integer?
    Public Property id_item As Integer
    Public Property id_item_asoc As Integer
    Public Property cantidad As Decimal
    Public Property observaciones As String
End Class

