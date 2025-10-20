' Entidad Impuesto según db/dbo.impuestos.Table.sql
Public Class ImpuestoEntity
    Public Property IdImpuesto As Integer
    Public Property Nombre As String
    Public Property EsRetencion As Boolean?
    Public Property EsPercepcion As Boolean?
    Public Property Porcentaje As Decimal
    Public Property Activo As Boolean
End Class

