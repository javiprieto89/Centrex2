Public Class add_comprobantes_compras_impuestos
    Dim id_comprobanteCompra As Integer
    Dim id_impuesto As Integer
    Dim i As New impuesto

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _id_comprobanteCompra As Integer, ByVal _id_impuesto As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id_comprobanteCompra = _id_comprobanteCompra
        id_impuesto = _id_impuesto

    End Sub
    Private Sub add_comprobantes_compras_impuestos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        i = info_impuesto(id_impuesto)
        lbl_impuesto.Text = i.nombre
    End Sub

    Private Sub txt_importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_importe.KeyPress
        If Not esNumero(e) Then
            e.KeyChar = ""
        Else
            e.KeyChar = isDecimalOk(e)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_importe.Text = "" Then
            MsgBox("El campo importe está vació", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If Not add_impuesto_comprobanteCompra(id_comprobanteCompra, i.id_impuesto, txt_importe.Text) Then
            MsgBox("Hubo un error al agregar el impuesto, consulte con el programador.", vbCritical + vbOKOnly, "Centrex")
            Exit Sub
        End If

        closeandupdate(Me)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub
End Class