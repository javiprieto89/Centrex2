Module mconfig
    Public comprobantePresupuesto_default As Integer
    Public id_comprobante_default As Integer
    Public id_tipoDocumento_default As Integer
    Public id_tipoComprobante_default As Integer
    Public id_cliente_pedido_default As Integer
    Public id_pais_default As Integer
    Public id_provincia_default As Integer
    Public id_marca_default As Integer
    Public id_proveedor_default As Integer
    Public id_caja As Integer
    Public cuit_emisor_default As String
    Public depuracion As Boolean
    Public id_condicion_compra_default As Integer

    Public Const ID_CH_CARTERA As Integer = 1
    Public Const ID_CH_ENTREGADO As Integer = 2
    Public Const ID_CH_COBRADO As Integer = 3
    Public Const ID_CH_RECHAZADO As Integer = 4
    Public Const ID_CH_DEPOSITADO As Integer = 5


    Public Const ID_PESO As Integer = 1
    Public Const ID_DOLAR As Integer = 2
End Module
