Public Class add_transferencia
    Private formViejo As Form
    Private esCobro As Boolean
    Private esPago As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _esCobro As Boolean, ByVal _esPago As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        esCobro = _esCobro
        esPago = _esPago
    End Sub

    Private Sub add_transferencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cb As New cuenta_bancaria
        Dim b As New banco

        cargar_combo(cmb_banco, "SELECT id_banco, nombre FROM bancos ORDER BY nombre ASC", basedb, "nombre", "id_banco")

        If Not edicion And Not borrado Then
            cmb_banco.SelectedItem = Nothing
            cmb_banco.Text = "Seleccione un banco..."
            cmb_cuentaBancaria.Text = "Seleccione un banco..."
            cmb_cuentaBancaria.Enabled = False
        Else
            dtp_fecha.Value = DateTime.Parse(edita_transferencia.fecha)
            cb = info_cuentaBancaria(edita_transferencia.id_cuentaBancaria)
            b = info_banco(cb.id_banco)
            cmb_banco.SelectedValue = b.id_banco

            cargar_combo(cmb_cuentaBancaria, "SELECT id_cuentaBancaria, nombre FROM cuentas_bancarias WHERE id_banco = '" & b.id_banco.ToString & "' ORDER BY nombre ASC", basedb, "nombre", "id_cuentaBancaria")
            cmb_cuentaBancaria.SelectedValue = edita_transferencia.id_cuentaBancaria

            txt_importe.Text = edita_transferencia.total
            txt_nComprobante.Text = edita_transferencia.nComprobante
            txt_notas.Text = edita_transferencia.notas
        End If

        If borrado Then
            dtp_fecha.Enabled = False
            cmb_banco.Enabled = False
            cmb_cuentaBancaria.Enabled = False
            txt_importe.Enabled = False
            txt_nComprobante.Enabled = False
            txt_notas.Enabled = False
            cmd_ok.Enabled = False
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta transferencia?", vbYesNo + vbQuestion, "Centrex") = MsgBoxResult.Yes Then
                If borrarTmptransferencia(edita_transferencia.id_transferencia) = False Then
                    MsgBox("No se ha podido borrar la transferencia.")
                End If
            End If
            closeandupdate(Me)
        End If

        formViejo = form
        form = Me
    End Sub

    Private Sub txt_importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_importe.KeyPress
        e.Handled = valida(e.KeyChar, 5)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim t As New transferencia

        If cmb_cuentaBancaria.Text = "Seleccione una cuenta bancaria..." Or cmb_cuentaBancaria.Text = "Seleccione un banco..." Then
            MsgBox("Debe seleccionar una cuenta bancaria", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_importe.Text = "" Then
            MsgBox("Debe ingresar un importe", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_nComprobante.Text = "" Then
            MsgBox("Debe ingresar un número de comprobante", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        With t
            .fecha = dtp_fecha.Value.Date
            .id_cuentaBancaria = cmb_cuentaBancaria.SelectedValue
            .total = txt_importe.Text
            .nComprobante = txt_nComprobante.Text
            .notas = txt_notas.Text
        End With

        If edicion Then
            t.id_transferencia = edita_transferencia.id_transferencia
            If Not updateTmptransferencia(t) Then
                MsgBox("Ocurrió un error al actualizar la transferencia.", vbExclamation + vbOKOnly, "Centrex")
            End If
        Else
            t.id_transferencia = addTmpTransferencia(t)
            If t.id_transferencia = False Then
                MsgBox("Ocurrió un error al agregar la transferencia", vbExclamation + vbOKOnly, "Centrex")
            End If
        End If

        closeandupdate(Me)
    End Sub

    Private Sub cmb_banco_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_banco.SelectionChangeCommitted
        Dim seleccionado As Integer

        seleccionado = cmb_banco.SelectedValue

        cargar_combo(cmb_cuentaBancaria, "SELECT id_cuentaBancaria, nombre FROM cuentas_bancarias WHERE id_banco = '" & seleccionado.ToString & "' ORDER BY nombre ASC", basedb, "nombre", "id_cuentaBancaria")
                cmb_cuentaBancaria.SelectedItem = Nothing
        cmb_cuentaBancaria.Text = "Seleccione una cuenta bancaria..."
        cmb_cuentaBancaria.Enabled = True
    End Sub

    Private Sub psearch_banco_Click(sender As Object, e As EventArgs) Handles psearch_banco.Click
        Dim tmp As String
        tmp = tabla
        tabla = "bancos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_banco.SelectedValue = id
        'cmb_banco.Text = info_banco(id).nombre
        'cmb_cat.SelectedIndex = id
        id = 0
        cmb_banco_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub psearch_cuentaBancaria_Click(sender As Object, e As EventArgs) Handles psearch_cuentaBancaria.Click
        Dim tmp As String

        If cmb_banco.Text = "Seleccione un banco..." Then
            Exit Sub
        End If

        tmp = tabla
        tabla = "cuentas_bancarias"
        Me.Enabled = False
        Dim frm As New search(cmb_banco.SelectedValue)
        frm.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_cuentaBancaria.SelectedValue = id
        'cmb_cat.SelectedIndex = id
        id = 0
    End Sub

    Private Sub add_transferencia_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        form = formViejo
        closeandupdate(Me)
    End Sub

    Private Sub cmb_banco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_banco.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_cuentaBancaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cuentaBancaria.KeyPress
        'e.KeyChar = ""
    End Sub
End Class