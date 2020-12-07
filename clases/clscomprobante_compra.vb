Public Class comprobante_compra
    Public id_comprobanteCompra As Integer
    Public fecha_carga As String
    Public fecha_comprobante As String
    Public id_sysComprobanteCompra As Integer
    Public id_proveedor As Integer
    Public id_cc As Integer
    Public id_moneda As Integer
    Public puntoVenta As String
    Public numeroComprobante As String
    Public id_condicion_compra As Integer
    Public subtotal As Double
    Public impuestos As Double
    Public conceptos As Double
    Public total As Double
    Public tasaCambio As Double
    Public nota As String
    Public cae As String
    Public activo As Boolean
End Class

Public Class comprobante_compra_items
    Public id_comprobanteCompraItem As Integer
    Public id_comprobanteCompra As Integer
    Public id_item As Integer
    Public cantidad As Integer
    Public precio As Double
End Class

Public Class comprobante_compra_impuestos
    Public id_comprobanteCompraImpuesto As Integer
    Public id_comprobanteCompra As Integer
    Public id_impuesto As Integer
    Public importe As Double
End Class

Public Class comprobante_compra_conceptos
    Public id_comprobanteCompraConcepto As Integer
    Public id_comprobanteCompra As Integer
    Public id_concepto_compra As Integer
    Public subtotal As Double
    Public iva As Double
    Public total As Double
End Class
