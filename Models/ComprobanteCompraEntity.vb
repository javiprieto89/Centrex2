Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[comprobantes_compras]
Public Class ComprobanteCompraEntity
    <Key>
    Public Property id_comprobanteCompra As Integer
    Public Property id_proveedor As Integer
    Public Property id_cc As Integer?
    Public Property id_condicion_compra As Integer?
    Public Property id_tipoComprobante As Integer
    Public Property id_moneda As Integer
    Public Property puntoVenta As Integer
    Public Property numero As Integer
    Public Property fecha As DateTime
    Public Property fecha_vencimiento As DateTime?
    Public Property cae As String
    Public Property vencimiento_cae As DateTime?
    Public Property total As Decimal
    Public Property neto As Decimal
    Public Property exento As Decimal
    Public Property tributos As Decimal
    Public Property impuestos As Decimal
    Public Property descuento As Decimal
    Public Property percepciones As Decimal
    Public Property observaciones As String
    Public Property fecha_carga As Date
    Public Property activo As Boolean
End Class

