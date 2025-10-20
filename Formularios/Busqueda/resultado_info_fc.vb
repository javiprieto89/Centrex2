Public Class resultado_info_fc

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _cae As String, ByVal _subtotal As String, ByVal _impuestos As String, ByVal _total As String, ByVal _cuit As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim c As New cliente

        c = info_cliente(existecliente(_cuit))


        txt_cae.Text = _cae
        txt_subtotal.Text = "$ " + _subtotal
        txt_impuestos.Text = "$ " + _impuestos
        txt_total.Text = "$ " + _total
        txt_CUIT.Text = _cuit
        txt_cliente.Text = c.razon_social
    End Sub

    Private Sub resultado_info_fc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class