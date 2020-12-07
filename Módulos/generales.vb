Module Module1
    Public serversql As String = "(local)\sqlexpress"
    'Public basedb As String = "DROil"
    'Public basedb As String = "DROilTest"
    Public basedb As String
    Public usuariodb As String = "sa"
    Public passdb As String = "Ladeda78"
    Public sepdec As Char

    Public edicion As Boolean
    Public borrado As Boolean
    Public terminacaso As Boolean
    Public terminarpedido As Boolean
    Public agregaitem As Boolean
    'Public cantidaditem As Long
    Public id As Integer
    Public datos_consulta(,) As String
    Public tabla As String
    Public form As Form
    Public activo As Boolean = True

    Public edita_cliente As New cliente
    Public edita_marcaa As New marca_auto
    Public edita_marcai As New marca_item
    Public edita_auto As New auto
    Public edita_item As New item
    Public edita_proveedor As New proveedor
    Public edita_tipoitem As New tipoitem
    Public edita_modeloa As New modelo_auto
    Public edita_caso As New caso
    Public edita_rosca As New rosca
    Public edita_pedido As New pedido

    Public busca_cliente As New cliente
    Public busca_marcaa As New marca_auto
    Public busca_marcai As New marca_item
    Public busca_auto As New auto
    Public busca_item As New item
    Public busca_proveedor As New proveedor
    Public busca_tipoitem As New tipoitem
    Public busca_modeloa As New modelo_auto
    Public busca_caso As New caso
    Public busca_rosca As New rosca



End Module
