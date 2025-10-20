' Entidad Asociación de Items según db/dbo.asocItems.Table.sql
Public Class AsocItemEntity
    Public Property IdItem As Integer
    Public Property IdItemAsoc As Integer
    Public Property Cantidad As Integer

    Public Overridable Property Item As ItemEntity
    Public Overridable Property ItemAsociado As ItemEntity
End Class

