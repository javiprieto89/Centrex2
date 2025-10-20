Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[comprobantes_compras_impuestos]
Public Class ComprobanteCompraImpuestoEntity
    <Key>
    Public Property id_comprobanteCompraImpuesto As Integer
    Public Property id_comprobanteCompra As Integer
    Public Property id_impuesto As Integer
    Public Property baseImponible As Decimal
    Public Property alicuota As Decimal
    Public Property importe As Decimal
End Class

