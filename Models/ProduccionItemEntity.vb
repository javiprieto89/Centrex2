Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[produccion_items]
Public Class ProduccionItemEntity
    <Key>
    Public Property id_produccionItem As Integer
    Public Property id_produccion As Integer
    Public Property id_item As Integer
    Public Property cantidad As Decimal
    Public Property tipo As String
    Public Property observaciones As String
End Class

