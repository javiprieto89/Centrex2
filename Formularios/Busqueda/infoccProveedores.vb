Public Class infoccProveedores
    Private Sub ccClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String
        'Cargo el combo con todos los clientes
        sqlstr = "SELECT c.id_cliente AS 'id_cliente', c.razon_social AS 'razon_social' FROM clientes AS c WHERE c.activo = '1' ORDER BY c.razon_social ASC"
        cargar_combo(cmb_cliente, sqlstr, basedb, "razon_social", "id_cliente")
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

        If cmb_tipoDocs.Text = "Seleccione un tipo de documento" Then
            MsgBox("Debe elegir que tipos de documentos desea consultar para poder hacer la consulta.", MsgBoxStyle.Exclamation + vbOKOnly, "Dr. Oil")
            Exit Sub
        End If

        If Not chk_abiertos.Checked And Not chk_cerrados.Checked Then
            MsgBox("Debe elegir pedidos abiertos o cerrados para poder hacer la consulta." & Chr(13) & "Por favor seleccione 'Consultar pedidos abiertos', 'Consultar pedidos cerrados' o ambos si quiere.", MsgBoxStyle.Exclamation + vbOKOnly, "Dr. Oil")
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


        'dg_view.DataSource = consultaCcCliente(cmb_cliente.SelectedValue, fechaDesde, fechaHasta, chk_abiertos.Checked, chk_cerrados.Checked, cmb_tipoDocs.SelectedIndex)

        'txt_total.Text = consultaTotalCcCliente(cmb_cliente.SelectedValue, fechaDesde, fechaHasta, chk_abiertos.Checked, chk_cerrados.Checked, cmb_tipoDocs.SelectedIndex)
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
End Class