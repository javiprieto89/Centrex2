Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[comprobantes_compras_conceptos]
Public Class ComprobanteCompraConceptoEntity
    <Key>
    Public Property id_comprobanteCompraConcepto As Integer
    Public Property id_comprobanteCompra As Integer
    Public Property id_concepto_compra As Integer
    Public Property descripcion As String
    Public Property importe As Decimal
End Class

