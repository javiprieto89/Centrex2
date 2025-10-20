' Entidad Ajuste de Stock según db/dbo.ajustes_stock.Table.sql
Public Class AjusteStockEntity
    Public Property IdAjusteStock As Integer
    Public Property IdItem As Integer
    Public Property Cantidad As Decimal
    Public Property Fecha As Date?
    Public Property Motivo As String
End Class

