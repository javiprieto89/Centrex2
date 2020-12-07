Public Class add_itemManual
    'Private esEdicion As Boolean
    Public Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(i As item)
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txt_item.Text = i.descript
        txt_cantidad.Text = i.cantidad
        txt_precio.Text = i.precio_lista
        'esEdicion = True
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Dispose()
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim cant As Decimal
        Dim precio As Decimal

        Try
            cant = txt_cantidad.Text
            precio = txt_precio.Text
        Catch ex As Exception
        End Try


        If txt_item.Text = "" Then
            MsgBox("Debe ingresar un item antes de poder continuar", vbCritical + vbOKOnly, "ComputronSystems")
            Exit Sub
        ElseIf txt_cantidad.Text = "" Then
            MsgBox("Debe ingresar la cantidad antes de poder continuar", vbCritical + vbOKOnly, "ComputronSystems")
            Exit Sub
        ElseIf Math.Truncate(cant) <> cant Then
            MsgBox("La cantidad no puede ser decimal", vbCritical + vbOKOnly, "ComputronSystems")
            Exit Sub
        ElseIf txt_precio.Text = "" Then
            MsgBox("Debe ingresar el precio antes de poder continuar", vbCritical + vbOKOnly, "ComputronSystems")
            Exit Sub
        End If

        Dim i As New item

        With i
            .cantidad = txt_cantidad.Text
            .descript = txt_item.Text
            .precio_lista = txt_precio.Text
            .item = "MANUAL"
        End With

        addItemPedidotmp(i, i.cantidad, i.precio_lista, edita_item.id_item_temporal)

        Me.Dispose()
    End Sub

    Private Sub txt_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If Not esNumero(e) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_precio.KeyPress
        If Not esNumero(e) And (e.KeyChar <> "." And e.KeyChar <> ",") Then
            e.KeyChar = ""
        End If

        If Asc(e.KeyChar) = 8 Then Exit Sub
        e.KeyChar = isDecimalOk(e)
    End Sub
End Class