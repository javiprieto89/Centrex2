' Entidad Pedido según db/dbo.pedidos.Table.sql
Public Class PedidoEntity
    Public Property IdPedido As Integer
    Public Property Fecha As Date
    Public Property FechaEdicion As Date
    Public Property IdCliente As Integer
    Public Property Markup As Decimal?
    Public Property Subtotal As Decimal
    Public Property Iva As Decimal?
    Public Property Total As Decimal
    Public Property Nota1 As String
    Public Property Nota2 As String
    Public Property EsPresupuesto As Boolean
    Public Property Activo As Boolean
    Public Property Cerrado As Boolean
    Public Property IdPresupuesto As Integer?
    Public Property IdComprobante As Integer
    Public Property Cae As String
    Public Property FechaVencimientoCae As Date?
    Public Property PuntoVenta As Integer?
    Public Property NumeroComprobante As Integer?
    Public Property CodigoDeBarras As String
    Public Property EsTest As Boolean
    Public Property IdCc As Integer?
    Public Property FcQr As Byte()
    Public Property NumeroComprobanteAnulado As Integer?
    Public Property NumeroPedidoAnulado As Integer?
    Public Property EsDuplicado As Boolean?
    Public Property IdUsuario As Integer?

    Public Overridable Property Cliente As ClienteEntity
    Public Overridable Property Comprobante As ComprobanteEntity
End Class

