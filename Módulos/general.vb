Imports System.Runtime.InteropServices ' required imports

Module mod_Gen
    Public serversql As String
    Public basedb As String
    Public usuariodb As String
    Public passdb As String
    Public versiondb As String
    Public cs As String ' Conection string
    Public rutaBackup As String
    Public archivoBackup As String
    Public sepDecimal As Char
    Public sepdec As Char
    Public showrpt As Boolean
    Public modificacionesDB As Boolean
    Public itXPage As Integer

    Public edicion As Boolean
    Public edicion_item_registro_stock As Boolean
    Public borrado As Boolean
    Public terminacaso As Boolean
    Public terminarpedido As Boolean
    Public agregaitem As Boolean
    Public cargarapidadecaso As Boolean
    Public busquedaavanzada As Boolean
    'Public cantidaditem As Long
    Public id As Integer
    Public datos_consulta(,) As String
    Public tabla As String
    Public tabla_vieja As String
    Public form As Form
    Public activo As Boolean = True
    Public editaStock As Boolean = False

    Public edita_cliente As New cliente
    Public edita_ccCliente As New ccCliente
    Public edita_ccProveedor As New ccProveedor
    Public edita_marcai As New marca_item
    Public edita_condicion_venta As New condicion_venta
    Public edita_condicion_compra As New condicion_compra
    Public edita_concepto_compra As New concepto_compra
    Public edita_item As New item
    Public edita_comprobante As New comprobante
    Public edita_proveedor As New proveedor
    Public edita_tipoitem As New tipoitem
    Public edita_pedido As New pedido
    Public edita_registro_stock As New registro_stock
    Public edita_item_registro_stock As New registro_stock
    Public edita_consulta As New consultaP
    Public edita_impuesto As New impuesto
    Public edita_itemImpuesto As New itemImpuesto
    Public edita_asocItem As New asocItem
    Public edita_produccion As New produccion
    Public edita_ordenCompra As New ordenCompra
    Public edita_banco As New banco
    Public edita_cuentaBancaria As New cuenta_bancaria
    Public edita_caja As New caja
    Public edita_transferencia As New transferencia
    Public edita_cobroRetencion As New cobroRetencion
    Public edita_cheque As New cheque

    Public busca_cliente As New cliente
    Public busca_marcai As New marca_item
    Public busca_item As New item
    Public busca_proveedor As New proveedor
    Public busca_tipoitem As New tipoitem

    Public secuencia As Boolean = False

    Public intInputBoxCancel As Integer                    ' public variable


    Public Function StrPtr(ByVal obj As Object) As Integer
        Dim Handle As GCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned)
        Dim intReturn As Integer = Handle.AddrOfPinnedObject.ToInt32
        Handle.Free()
        Return intReturn
    End Function
End Module
