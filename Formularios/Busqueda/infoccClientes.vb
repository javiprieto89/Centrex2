Public Class infoccClientes
    Private Sub ccClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        form = Me

        'Cargo el combo con todos los clientes
        sqlstr = "SELECT c.id_cliente AS 'id_cliente', c.razon_social AS 'razon_social' FROM clientes AS c WHERE c.activo = '1' ORDER BY c.razon_social ASC"
        cargar_combo(cmb_cliente, sqlstr, basedb, "razon_social", "id_cliente")
        cmb_cliente.Text = "Seleccione un cliente..."
    End Sub

    Private Sub psearch_cliente_Click(sender As Object, e As EventArgs)
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        Me.Enabled = False
        form = Me
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_cliente.SelectedValue = id 'cmb_clientes.FindString(info_cliente(id).nombre)
        id = 0
    End Sub

    Private Sub ccClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmd_consultar_Click(sender As Object, e As EventArgs) Handles cmd_consultar.Click
        'Dim saldo As saldoCaja
        Dim saldo As String
        Dim total As String

        If cmb_cliente.Text = "Seleccione un cliente..." Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_cc.Text = "Seleccione una cuenta corriente..." Then
            MsgBox("Debe elegir una cuenta corriente del cliente seleccionado para poder realizar la consulta.", MsgBoxStyle.Exclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_tipoDocs.Text = "Seleccione un tipo de documento..." Then
            MsgBox("Debe elegir que tipos de documentos desea consultar para poder realizar la consulta.", MsgBoxStyle.Exclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim fechaDesde As Date
        Dim fechaHasta As Date

        If chk_desdeSiempre.Checked Then
            fechaDesde = dtp_desde.MinDate
        Else
            fechaDesde = dtp_desde.Value.Date
        End If

        If chk_hastaSiempre.Checked Then
            fechaHasta = dtp_hasta.MaxDate
        Else
            fechaHasta = dtp_hasta.Value.Date
        End If


        dg_view.DataSource = consultaCcCliente(cmb_cliente.SelectedValue, cmb_cc.SelectedValue, fechaDesde, fechaHasta, cmb_tipoDocs.SelectedIndex)

        total = consultaTotalCcCliente(cmb_cliente.SelectedValue, fechaDesde, fechaHasta, cmb_tipoDocs.SelectedIndex)

        lbl_total.Text = "$ " + total

        saldo = info_ccCliente(cmb_cc.SelectedValue).saldo.ToString
        lbl_saldo.Text = "$ " + saldo

        If InStr(saldo, "-") Then
            lbl_saldo.ForeColor = Color.Red
        Else
            lbl_saldo.ForeColor = Color.Green
        End If

        lbl_saldo.Visible = True
        lbl_total.Visible = True
    End Sub

    Private Sub dg_view_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_view.CellMouseDoubleClick
        If borrado = False Then edicion = True

        If dg_view.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        edita_pedido = info_pedido(seleccionado)
        pedido_a_pedidoTmp(seleccionado)
        add_pedido.ShowDialog()

        If borrado = False Then edicion = False
    End Sub

    Private Sub cmb_cliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cliente.SelectionChangeCommitted
        Dim sqlstr As String

        'Cargo el combo con todas las cuentas corrientes del cliente seleccionado
        sqlstr = "SELECT cc.id_cc AS 'id_cc', cc.nombre AS 'nombre' FROM cc_clientes AS cc WHERE cc.id_cliente = '" + cmb_cliente.SelectedValue.ToString + "' AND cc.activo = '1' ORDER BY cc.nombre ASC"
        cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")
        cmb_cc.Text = "Seleccione una cuenta corriente..."

        cmb_cc.Enabled = True
        Me.ActiveControl = Me.cmb_cc

    End Sub

    Private Sub psearch_cliente_Click_1(sender As Object, e As EventArgs) Handles psearch_cliente.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_cliente)
        cmb_cliente_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub psearch_cc_Click(sender As Object, e As EventArgs) Handles psearch_cc.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "archivoCCClientes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp


        updateform(id.ToString, cmb_cc)
    End Sub

    Private Sub chk_desdeSiempre_CheckedChanged(sender As Object, e As EventArgs) Handles chk_desdeSiempre.CheckedChanged
        dtp_desde.Enabled = Not chk_desdeSiempre.Checked
    End Sub

    Private Sub chk_hastaSiempre_CheckedChanged(sender As Object, e As EventArgs) Handles chk_hastaSiempre.CheckedChanged
        dtp_hasta.Enabled = Not chk_hastaSiempre.Checked
    End Sub
End Class