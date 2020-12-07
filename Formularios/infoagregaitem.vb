Public Class infoagregaitem

    Dim seleccionado As String
    Dim produccion As Boolean = False
    Dim ordenCompra As Boolean = False
    Dim comprobanteCompra As Boolean = False
    Dim id_comprobanteCompra As Integer = -1
    Dim actualiza As Boolean = True
    Public cant As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _produccion As Boolean, ByVal _ordenCompra As Boolean, ByVal _actualiza As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        produccion = _produccion
        ordenCompra = _ordenCompra
        actualiza = _actualiza
    End Sub

    Public Sub New(ByVal _comprobanteCompra As Boolean, ByVal _id_comprobanteCompra As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        comprobanteCompra = _comprobanteCompra
        id_comprobanteCompra = _id_comprobanteCompra
        'actualiza = _actualiza
    End Sub

    Private Sub infoagregaitem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'closeandupdate(Me)
    End Sub

    Private Sub infoagregaitem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbl_item.Text = edita_item.item
        lbl_desc.Text = edita_item.descript
        lbl_stock.Text = edita_item.cantidad

        If produccion Then txt_precio.Enabled = False

        If agregaitem = True Then
            txt_cantidad.Text = 1
            txt_precio.Text = edita_item.precio_lista
        Else
            If produccion Then
                txt_cantidad.Text = askCantidadCargadaProduccion(edita_item.id_item,, edita_item.id_item_temporal)
            ElseIf ordenCompra Then
                txt_cantidad.Text = askCantidadCargadaOC(edita_item.id_item,, edita_item.id_item_temporal)
                txt_precio.Text = askPrecioCargadoOC(edita_item.id_item,, edita_item.id_item_temporal)
            ElseIf comprobanteCompra Then

            Else
                txt_cantidad.Text = askCantidadCargada(edita_item.id_item,, edita_item.id_item_temporal)
                txt_precio.Text = askPrecioCargado(edita_item.id_item,, edita_item.id_item_temporal)
            End If
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If CInt(txt_cantidad.Text) = -1 Then
            closeandupdate(Me)
            Exit Sub
        End If

        If txt_cantidad.Text = 0 Then
            MsgBox("La cantidad ingresada no puede ser 0, ingrese nuevamente", vbExclamation, "Centrex")
            Exit Sub
        End If

        If Not actualiza Then
            cant = txt_cantidad.Text
            Me.Dispose()
            Exit Sub
        End If

        If Not produccion And Not ordenCompra And Not comprobanteCompra Then
            If edita_item.cantidad - txt_cantidad.Text < 0 Then
                MsgBox("No hay " + txt_cantidad.Text + " " + edita_item.item.ToString + " hay solo " + edita_item.cantidad.ToString + ".", vbExclamation)
                'MsgBox("No hay " + txt_cantidad.Text + " " + edita_item.item.ToString + " hay solo " + edita_item.cantidad.ToString + ", ingrese una nueva cantidad o cancele", vbExclamation)
                'Exit Sub
            End If
        End If

        If produccion Then
            'Es un pedido de produccion
            If Not agregaitem Then
                addItemProducciontmp(edita_item, txt_cantidad.Text, edita_item.id_item_temporal)
            Else
                addItemProducciontmp(edita_item, txt_cantidad.Text)
            End If
        ElseIf ordenCompra Then
            'Es una orden de compra
            If Not agregaitem Then
                addItemOCtmp(edita_item, txt_cantidad.Text, txt_precio.Text, edita_item.id_item_temporal)
            Else
                addItemOCtmp(edita_item, txt_cantidad.Text, txt_precio.Text)
            End If
        ElseIf comprobanteCompra Then
            'Es un comprobante de compra
            add_item_comprobanteCompra(id_comprobanteCompra, edita_item.id_item, txt_cantidad.Text, txt_precio.Text)
        Else
            'Pedido normal
            If Not agregaitem Then
                addItemPedidotmp(edita_item, txt_cantidad.Text, txt_precio.Text, edita_item.id_item_temporal)
            Else
                addItemPedidotmp(edita_item, txt_cantidad.Text, txt_precio.Text)
            End If
        End If

        Me.Dispose()
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Dispose()
    End Sub

    Private Sub txt_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If esNumero(e) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class