' Entidad Item según db/dbo.items.Table.sql
Public Class ItemEntity
    Public Property IdItem As Integer
    Public Property Item As String
    Public Property Descript As String
    Public Property Cantidad As Integer
    Public Property Costo As Decimal
    Public Property PrecioLista As Decimal
    Public Property IdTipo As Integer
    Public Property IdMarca As Integer
    Public Property IdProveedor As Integer
    Public Property Factor As Decimal?
    Public Property EsDescuento As Boolean
    Public Property EsMarkup As Boolean
    Public Property Activo As Boolean

    Public Overridable Property Tipo As TipoItemEntity
    Public Overridable Property Marca As MarcaEntity
    Public Overridable Property Proveedor As ProveedorEntity
End Class

