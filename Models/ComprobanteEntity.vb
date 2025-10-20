' Entidad Comprobante según db/dbo.comprobantes.Table.sql
Public Class ComprobanteEntity
    Public Property IdComprobante As Integer
    Public Property Comprobante As String
    Public Property IdTipoComprobante As Integer
    Public Property NumeroComprobante As Integer
    Public Property PuntoVenta As Integer
    Public Property EsFiscal As Boolean?
    Public Property EsElectronica As Boolean?
    Public Property EsManual As Boolean?
    Public Property EsPresupuesto As Boolean?
    Public Property Activo As Boolean
    Public Property Testing As Boolean
    Public Property MaxItems As Integer?
    Public Property ComprobanteRelacionado As Integer?
    Public Property EsMiPyME As Boolean
    Public Property CBUEmisor As String
    Public Property AliasCBUEmisor As String
    Public Property AnulaMiPyME As String
    Public Property Contabilizar As Boolean
    Public Property MueveStock As Boolean
    Public Property IdModoMiPyme As Integer

    Public Overridable Property TipoComprobante As TipoComprobanteEntity
End Class

