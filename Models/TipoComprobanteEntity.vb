' Entidad Tipo de Comprobante según db/dbo.tipos_comprobantes.Table.sql
Public Class TipoComprobanteEntity
    Public Property IdTipoComprobante As Integer
    Public Property ComprobanteAFIP As String
    Public Property IdClaseFiscal As String
    Public Property SignoProveedor As String
    Public Property SignoCliente As String
    Public Property DiscriminaIVA As Boolean?
    Public Property EsRemito As Boolean?
    Public Property NombreAbreviado As String
    Public Property IdClaseComprobante As Integer
    Public Property IdAnulaTipoComprobante As Integer?
    Public Property Contabilizar As Boolean
End Class

