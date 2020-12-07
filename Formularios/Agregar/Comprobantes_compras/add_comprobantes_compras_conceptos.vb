Public Class add_comprobantes_compras_conceptos
    Dim id_concepto As Integer
    Dim id_comprobanteCompra As Integer
    Dim c As New concepto_compra
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _id_comprobanteCompra As Integer, ByVal _id_concepto As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id_comprobanteCompra = _id_comprobanteCompra
        id_concepto = _id_concepto
    End Sub
    Private Sub add_comprobantes_compras_conceptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        c = info_concepto_compra(id_concepto)

        lbl_concepto.Text = c.concepto
    End Sub

    Private Sub txt_subtotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_subtotal.KeyPress
        If Not esNumero(e) Then
            e.KeyChar = ""
        Else
            e.KeyChar = isDecimalOk(e)
        End If
    End Sub

    Private Sub txt_iva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_iva.KeyPress
        If Not esNumero(e) Then
            e.KeyChar = ""
        Else
            e.KeyChar = isDecimalOk(e)
        End If
    End Sub

    Private Sub txt_total_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_total.KeyPress
        If Not esNumero(e) Then
            e.KeyChar = ""
        Else
            e.KeyChar = isDecimalOk(e)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_subtotal.Text = "" Then
            MsgBox("El campo subtotal está vacio.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_iva.Text = "" Then
            MsgBox("El cambo I.V.A. está vacio.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_total.Text = "" Then
            MsgBox("El campo total está vacio.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If Not add_concepto_comprobanteCompra(id_comprobanteCompra, c.id_concepto_compra, txt_subtotal.Text, txt_iva.Text, txt_total.Text) Then
            MsgBox("Hubo un problema al cargar el concepto en la base de datos, consulte con el programador.", vbCritical + vbOKOnly, "Centrex")
            closeandupdate(Me)
            Exit Sub
        End If

        closeandupdate(Me)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub
End Class