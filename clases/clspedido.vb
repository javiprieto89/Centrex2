Public Class pedido
    Public id_pedido As Integer
    Public fecha As String
    Public fecha_edicion As String
    Public id_cliente As Integer
    Public markup As Double
    Public subTotal As Double
    Public iva As Double
    Public total As Double
    Public nota1 As String
    Public nota2 As String
    Public esPresupuesto As Boolean = False
    Public activo As Boolean = True
    Public cerrado As Boolean
    Public idPresupuesto As Integer
    Public id_comprobante As Integer
    Public cae As String
    Public fechaVencimiento_cae As String
    Public puntoVenta As Integer
    Public numeroComprobante As Integer
    Public codigoDeBarras As String
    Public esTest As Boolean
    Public tipoComprobante As Integer
    Public id_Cc As Integer
    Public numeroComprobante_anulado As Integer
    Public numeroPedido_anulado As Integer
    Public esDuplicado As Boolean
    Public estado As String
    Public id_usuario As Integer
End Class
