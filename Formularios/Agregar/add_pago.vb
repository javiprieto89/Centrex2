Public Class add_pago
    Private p As New proveedor
    Private cc As New ccProveedor
    Private selColName As String = "Seleccionado"
    Private total As Double = Nothing
    Private efectivo As Double = Nothing
    Private transferenciaBancaria As Double = Nothing
    Private totalCh As Double = Nothing
    Private chSel() As Integer
    Private noCambiar As Boolean = False
    'Private chSelSearch() As Integer

    Private Sub add_pago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        form = Me

        'Cargo el combo con todos los proveedores
        sqlstr = "SELECT p.id_proveedor AS 'id_proveedor', p.razon_social AS 'razon_social' FROM proveedores AS p WHERE p.activo = '1' ORDER BY p.razon_social ASC"
        cargar_combo(cmb_proveedor, sqlstr, basedb, "razon_social", "id_proveedor")
        cmb_proveedor.Text = "Seleccione un proveedor..."
        cmb_cc.Enabled = False

        resetForm()
        actualizarDataGrid()
        lbl_fecha.Text = Hoy()
        form = Me
    End Sub

    Private Sub add_pago_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmb_proveedor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_proveedor.SelectionChangeCommitted
        Dim sqlstr As String

        '
        'MUESTRA LAS FACTURAS PENDIENTES DE ABONAR POR EL CLIENTE
        'chk_efectivo.Enabled = True
        'chk_transferenciaBancaria.Enabled = True
        'chk_cheque.Enabled = True
        'chklb_facturasPendientes.Enabled = True

        'sqlstr = "SELECT p.id_pedido AS 'id_pedido', CONCAT(c.comprobante, ' - Nº ',  p.numeroComprobante) AS 'numeroComprobante'" &
        '    "FROM pedidos AS p " &
        '    "INNER JOIN comprobantes AS c ON p.id_comprobante = c.id_comprobante " &
        '    "WHERE p.id_cliente = 6 AND c.id_tipoComprobante IN (1, 6, 11, 51) " &
        '    "ORDER BY p.numeroComprobante ASC"

        'cargar_checkListBox(chklb_facturasPendientes, cs, sqlstr, "id_pedido", "numeroComprobante")
        'MUESTRA LAS FACTURAS PENDIENTES DE ABONAR POR EL CLIENTE
        '

        Dim p As String = cmb_proveedor.SelectedValue.ToString

        'Cargo los combos con todas las cuentas corrientes del proveedor
        sqlstr = "SELECT id_cc, nombre FROM cc_proveedores WHERE activo = 1 AND id_proveedor = '" + p + "' ORDER BY nombre ASC"
        cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")
        cmb_cc.Enabled = True

        chk_efectivo.Enabled = True
        chk_transferencia.Enabled = True
        chk_cheque.Enabled = True
        'c = info_cliente(cmb_cliente.SelectedValue)
        cmb_cc_SelectionChangeCommitted(Nothing, Nothing)
        ' actualizarDataGrid(p)
        actualizarDataGrid()
        resetForm()
    End Sub

    Private Sub chk_efectivo_CheckedChanged(sender As Object, e As EventArgs) Handles chk_efectivo.CheckedChanged
        If txt_efectivo.Text <> 0 Then efectivo = Convert.ToDouble(txt_efectivo.Text)

        If chk_efectivo.Checked Then
            total += efectivo
        Else
            total -= efectivo
        End If

        txt_efectivo.Enabled = chk_efectivo.Checked
    End Sub

    Private Sub chk_transferenciaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chk_transferencia.CheckedChanged
        If txt_transferenciaBancaria.Text <> 0 Then transferenciaBancaria = Convert.ToDouble(txt_transferenciaBancaria.Text)

        If chk_transferencia.Checked Then
            total += transferenciaBancaria
        Else
            total -= transferenciaBancaria
        End If

        txt_transferenciaBancaria.Enabled = chk_transferencia.Checked
    End Sub

    Private Sub chk_cheque_CheckedChanged(sender As Object, e As EventArgs) Handles chk_cheque.CheckedChanged
        Dim chk As Boolean
        chk = chk_cheque.Checked

        dg_view.Enabled = chk
        cmd_addCheques.Enabled = chk
        cmd_verCheques.Enabled = chk
        txt_search.Enabled = chk
        lbl_borrarbusqueda.Enabled = chk
    End Sub

    Private Sub cmb_cc_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cc.SelectionChangeCommitted
        cc = info_ccProveedor(cmb_cc.SelectedValue)

        lbl_dineroCuenta.Text = "$ " + cc.saldo.ToString
        If cc.saldo < 0 Then
            lbl_dineroCuenta.ForeColor = Color.Red
        Else
            lbl_dineroCuenta.ForeColor = Color.Green
        End If
    End Sub

    Private Sub cmd_addCheques_Click(sender As Object, e As EventArgs) Handles cmd_addCheques.Click
        Dim addCheque As New add_cheque(-1, cmb_proveedor.SelectedValue)
        addCheque.ShowDialog()
        'actualizarDataGrid(cmb_proveedor.SelectedValue.ToString)
        actualizarDataGrid()
    End Sub

    Private Sub cmd_verCheques_Click(sender As Object, e As EventArgs) Handles cmd_verCheques.Click
        Dim frm As New frmCheques(cmb_proveedor.SelectedValue)
        frm.ShowDialog()
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim pg As New pago
        Dim ccp As New ccProveedor

        If cmb_proveedor.Text = "Seleccione un proveedor..." Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio", vbOKOnly, vbExclamation)
            Exit Sub
            If Not chk_efectivo.Checked And Not chk_transferencia.Checked And Not chk_cheque.Checked Then
                MsgBox("Debe elegir algún medio de pago", vbOKOnly, vbExclamation)
                Exit Sub
            End If
        End If

        ccp = info_ccProveedor(cmb_cc.SelectedValue)

        With pg
            '.fecha_pago = lbl_fecha.Text
            .fecha_pago = dtp_fechaPago.Value.Date.ToString
            .id_proveedor = cmb_proveedor.SelectedValue
            .id_cc = cmb_cc.SelectedValue
            .dineroEnCc = ccp.saldo

            If chk_efectivo.Checked Then
                .efectivo = txt_efectivo.Text
            Else
                .efectivo = 0
            End If

            If chk_transferencia.Checked Then
                .totalTransferencia = txt_transferenciaBancaria.Text
            Else
                .totalTransferencia = 0
            End If

            If chk_cheque.Checked Then
                .totalch = totalCh
            Else
                .totalTransferencia = 0
            End If

            .hayCheque = chk_cheque.Checked

            .total = total
        End With

        pg.id_pago = addpago(pg)
        If pg.id_pago <> -1 Then
            If pg.hayCheque Then
                'Dim count As Integer = -1

                'For Each row As DataGridViewRow In dg_view.Rows
                '    If (Convert.ToBoolean(row.Cells(selColName).Value)) Then count += 1
                'Next
                'Dim cheques(count) As Integer
                'count = 0

                'For Each row As DataGridViewRow In dg_view.Rows
                '    If (Convert.ToBoolean(row.Cells(selColName).Value)) Then
                '        cheques(count) = row.Cells("ID").Value
                '        count += 1
                '    End If
                'Next

                'add_chequeCobrado(cb.id_cobro, cheques)
                'Marco los cheques como entregados
                Dim ch As New cheque
                For Each row As DataGridViewRow In dg_view.Rows
                    If (Convert.ToBoolean(row.Cells(selColName).Value)) Then
                        ch = info_cheque(row.Cells("ID").Value.ToString)
                        ch.id_estadoch = ID_CH_ENTREGADO
                        updatech(ch)
                    End If
                Next

                'Actualizo el saldo del proveedor
                'Dim p As New proveedor

                ccp.saldo += pg.total
                updateCCProveedor(ccp)
                closeandupdate(Me)
            Else
                closeandupdate(Me)
            End If
        Else
            MsgBox("Hubo un problema al agregar el cobro.", vbExclamation)
            closeandupdate(Me)
        End If
    End Sub

    Private Sub txt_efectivo_Leave(sender As Object, e As EventArgs) Handles txt_efectivo.Leave
        total -= efectivo
        efectivo = Convert.ToDouble(txt_efectivo.Text)
        total += efectivo

        lbl_importePago.Text = "$ " + Convert.ToString(total)
    End Sub

    Private Sub txt_transferenciaBancaria_Leave(sender As Object, e As EventArgs) Handles txt_transferenciaBancaria.Leave
        total -= transferenciaBancaria
        transferenciaBancaria = Convert.ToDouble(txt_transferenciaBancaria.Text)
        total += transferenciaBancaria

        lbl_importePago.Text = "$ " + Convert.ToString(total)
    End Sub

    Private Sub pic_proveedorProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchProveedor.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_proveedor)
    End Sub

    Private Sub cmb_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_proveedor.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_cc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cc.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub lbl_borrarbusqueda_DoubleClick(sender As Object, e As EventArgs) Handles lbl_borrarbusqueda.DoubleClick
        txt_search.Text = ""
        'actualizarDataGrid(cmb_proveedor.SelectedValue.ToString)
        actualizarDataGrid()
    End Sub

    'Private Sub actualizarDataGrid(ByVal p As String)
    Private Sub actualizarDataGrid()
        Dim sqlstr As String = ""
        Dim txtsearch As String = ""
        Dim count As Integer = 0

        If txt_search.Text <> "" Then
            txtsearch = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")

            checkCheques()

            sqlstr = "SELECT ch.id_cheque AS 'ID', CASE WHEN ch.id_cliente IS NULL THEN '**** CHEQUE PROPIO ****' ELSE c.razon_social END AS 'Cliente', b.nombre AS 'Banco', ch.nCheque AS 'Nº cheque', ch.importe AS 'Importe', sech.estado AS 'Estado', " &
                 "CASE WHEN ch.id_cuentaBancaria IS NULL THEN 'No' ELSE CONCAT('Si, en:', cbb.nombre, ' - ', cb.nombre) END AS '¿Depositado?', " &
                 "CASE WHEN ch.activo = 1 THEN 'Si' ELSE 'No' END AS '¿Activo?' " &
                 "FROM cheques AS ch " &
                 "LEFT JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                 "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                 "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                 "LEFT JOIN bancos AS cbb ON cb.id_banco = cbb.id_banco " &
                 "INNER JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                 "WHERE ch.activo = 1 AND ch.id_estadoch = 1  " & 'id_estadoch = 1 = En cartera
                 "AND (ch.id_cheque LIKE '%" & txtsearch & "%' " &
                 "OR b.nombre LIKE '%" & txtsearch & "%' " &
                 "OR ch.nCheque LIKE '%" & txtsearch & "%' " &
                 "OR ch.importe LIKE '%" & txtsearch & "%' " &
                 "OR sech.estado LIKE '%" & txtsearch & "%') " &
                 "ORDER BY ch.nCheque ASC"
        Else
            checkCheques()

            sqlstr = "SELECT ch.id_cheque AS 'ID', CASE WHEN ch.id_cliente IS NULL THEN '**** CHEQUE PROPIO ****' ELSE c.razon_social END AS 'Cliente', b.nombre AS 'Banco', ch.nCheque AS 'Nº cheque', ch.importe AS 'Importe', sech.estado AS 'Estado', " &
                 "CASE WHEN ch.id_cuentaBancaria IS NULL THEN 'No' ELSE CONCAT('Si, en:', cbb.nombre, ' - ', cb.nombre) END AS '¿Depositado?', " &
                 "CASE WHEN ch.activo = 1 THEN 'Si' ELSE 'No' END AS '¿Activo?' " &
                 "FROM cheques AS ch " &
                 "LEFT JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                 "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                 "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                 "LEFT JOIN bancos AS cbb ON cb.id_banco = cbb.id_banco " &
                 "INNER JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                 "WHERE ch.activo = 1 AND ch.id_estadoch = 1  " & 'id_estadoch = 1 = En cartera
                 "ORDER BY ch.nCheque ASC"
        End If

        If sqlstr <> "" And sqlstr <> "error" Then
            cargar_datagrid(dg_view, sqlstr, basedb, {0}, True, selColName) 'Carga el datagrid con los nuevos datos
            selCheques()
        End If

        'If chSel IsNot Nothing Then
        '    For Each idCheque As Integer In chSel
        '        totalCh += info_cheque(idCheque.ToString).importe
        '    Next
        'End If

        'total += totalCh
        lbl_importePago.Text = "$ " + Convert.ToString(total)
    End Sub

    Private Sub txt_search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_search.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            ' actualizarDataGrid(cmb_proveedor.SelectedValue.ToString)
            actualizarDataGrid()
        End If
    End Sub

    Private Sub dg_view_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dg_view.CurrentCellDirtyStateChanged
        If dg_view.IsCurrentCellDirty Then
            dg_view.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dg_view_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dg_view.CellValueChanged
        Dim count As Integer = 0

        If noCambiar Then Exit Sub

        total -= totalCh
        totalCh = 0

        checkCheques()

        'For Each idCheque As Integer In chSel
        '    totalCh += info_cheque(idCheque.ToString).importe
        'Next

        'For Each row As DataGridViewRow In dg_view.Rows
        '    If (Convert.ToBoolean(row.Cells(selColName).Value)) Then
        '        totalCh += Convert.ToDouble(row.Cells("Importe").Value)
        '    End If
        'Next

        If chSel IsNot Nothing Then
            For Each a As Integer In chSel
                totalCh += info_cheque(a).importe
            Next
        End If

        total += totalCh
        lbl_totalCh.Text = "$ " + Convert.ToString(totalCh)
        lbl_importePago.Text = "$ " + Convert.ToString(total)
    End Sub

    Private Sub checkCheques()
        'Reviso el datagridview y si el cheque esta seleccionado lo agrego a chSel (Cheques seleccionados)
        'Si el cheque no está seleccionado lo borro de chSel
        'Si el cheque ya está agregado en chSel, no lo vuelve a agregar
        'Si el cheque no está en chSel no hace nada

        For Each row As DataGridViewRow In dg_view.Rows
            If (Convert.ToBoolean(row.Cells(selColName).Value)) Then
                chSel = addValArray(chSel, row.Cells("ID").Value)
            Else
                If chSel IsNot Nothing Then
                    chSel = delValArray(chSel, row.Cells("ID").Value)
                End If
            End If
        Next
    End Sub

    Private Sub selCheques()
        Dim c As Integer = 0
        noCambiar = True

        For Each row As DataGridViewRow In dg_view.Rows
            If searchArray(chSel, row.Cells("ID").Value) Then
                row.Cells(selColName).Value = True
            End If
        Next

        noCambiar = False
    End Sub

    Private Sub resetForm()
        total = 0
        efectivo = 0
        transferenciaBancaria = 0
        totalCh = 0
        chSel = Nothing
        noCambiar = False

        chk_efectivo.Checked = False
        chk_transferencia.Checked = False
        chk_cheque.Checked = False

        txt_efectivo.Text = efectivo
        txt_transferenciaBancaria.Text = transferenciaBancaria
        txt_search.Text = ""
        lbl_totalCh.Text = "$ " + Convert.ToString(totalCh)
        lbl_importePago.Text = "$ " + Convert.ToString(total)
    End Sub

    Private Sub pic_searchCCProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchCCProveedor.Click
        'busqueda
        Dim tmp As String
        Dim tmpProveedor As proveedor

        If cmb_proveedor.Text = "Seleccione un proveedor..." Or cmb_proveedor.SelectedValue = 0 Then Exit Sub

        tmp = tabla
        tmpProveedor = edita_proveedor
        'edita_cliente = info_cliente(cmb_proveedor.SelectedValue)
        edita_proveedor = info_proveedor(cmb_proveedor.SelectedValue)
        tabla = "cc_proveedores"
        Me.Enabled = False

        search.ShowDialog()
        tabla = tmp
        edita_proveedor = tmpProveedor

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_cc)
    End Sub
End Class