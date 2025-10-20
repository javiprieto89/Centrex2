Public Class FacturaPrueba

    Public Sub New()
        InitializeComponent()
        f = New Factura
        actualizar()
    End Sub
    Sub actualizar()
        DataGridView1.DataSource = Nothing
        DataGridView2.DataSource = Nothing
        DataGridView1.DataSource = f.Detalles
        DataGridView2.DataSource = f.SubTotalesIva

        totalneto.Text = f.SubTotalPreDescuento.ToString("C")
        descuento.Text = f.Descuento.ToString("C")
        subtotal.Text = f.SubTotalNeto.ToString("C")
        iva21.Text = f.getSubTotalIva(21).ToString("C")
        tootal.Text = f.Total.ToString("C")

    End Sub
    Private f As Factura
    Private Sub Addbtn_Click(sender As Object, e As EventArgs) Handles Addbtn.Click
        Dim codTexto = InputBox("Codigo")
        Dim cod As Long?
        If Not String.IsNullOrWhiteSpace(codTexto) Then
            Dim codValor As Long
            If Not Long.TryParse(codTexto, codValor) Then
                MsgBox("Código inválido.")
                Return
            End If
            cod = codValor
        End If

        Dim cantTexto = InputBox("Cantidad")
        Dim cant As Integer
        If Not Integer.TryParse(cantTexto, cant) Then
            MsgBox("Cantidad inválida.")
            Return
        End If

        Dim desc As String = InputBox("Desc")
        If String.IsNullOrWhiteSpace(desc) Then
            MsgBox("Ingrese una descripción.")
            Return
        End If

        Dim precioTexto = InputBox("Precio")
        Dim precio As Decimal
        If Not Decimal.TryParse(precioTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, precio) Then
            If Not Decimal.TryParse(precioTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, precio) Then
                MsgBox("Precio inválido.")
                Return
            End If
        End If

        Dim alicuotaTexto = InputBox("Alicuota")
        Dim alicuota As Decimal
        If Not Decimal.TryParse(alicuotaTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, alicuota) Then
            If Not Decimal.TryParse(alicuotaTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, alicuota) Then
                MsgBox("Alicuota inválida.")
                Return
            End If
        End If

        Dim netoRespuesta = InputBox("Es Neto? s/n")
        Dim neto As Boolean = netoRespuesta.Trim().Equals("s", System.StringComparison.OrdinalIgnoreCase)

        If neto Then
            f.addDetalle(cod, cant, precio, desc, alicuota)
        Else
            f.addDetallePrecioFinal(cod, cant, precio, desc, alicuota)
        End If
        actualizar()
    End Sub

    Private Sub FacturaPrueba_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private r As Random
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        r = New Random
        For i = 0 To 10

            Dim cod = r.Next(1, 222)
            Dim cant = r.Next(1, 10)
            Dim prec = randDec(15, 200)
            Dim ali = 21
            Dim desc = Guid.NewGuid().ToString().Substring(0, 8)

            f.addDetalle(cod, cant, prec, desc, ali)
        Next
        actualizar()
    End Sub

    Private Function randDec(min As Decimal, max As Decimal) As Decimal
        min *= 100
        max *= 100
        Return r.Next(min, max) / 100

    End Function
End Class
