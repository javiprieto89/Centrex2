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

        'sqlstr = "SELECT id_cc, nombre FROM cc_proveedores WHERE activo = 1 AND id_proveedor = '" + p + "' ORDER BY nombre ASC"
        'cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")
        'cmb_cc.Enabled = True

        'Cargo los combos con todas las cuentas corrientes del proveedor
        sqlstr = "SELECT id_cc, nombre FROM cc_proveedores WHERE activo = 1 AND id_proveedor = '" + p + "' ORDER BY nombre ASC"
        cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")
        cmb_cc.Enabled = True

        chk_efectivo.Enabled = True
        chk_transferencia.Enabled = True
        chk_cheque.Enabled = True
        dg_view_nFC_importes.Enabled = True
        txt_notas.Enabled = True
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
        lbl_importePago.Text = total
    End Sub

    'Private Sub chk_transferenciaBancaria_CheckedChanged(sender As Object, e As EventArgs)
    '    If txt_transferenciaBancaria.Text <> 0 Then transferenciaBancaria = Convert.ToDouble(txt_transferenciaBancaria.Text)

    '    If chk_transferencia.Checked Then
    '        total += transferenciaBancaria
    '    Else
    '        total -= transferenciaBancaria
    '    End If

    '    txt_transferenciaBancaria.Enabled = chk_transferencia.Checked
    'End Sub

    Private Sub chk_cheque_CheckedChanged(sender As Object, e As EventArgs) Handles chk_cheque.CheckedChanged
        Dim chk As Boolean
        chk = chk_cheque.Checked

        If chk Then
            total += totalCh
            lbl_totalCh.Text = precio(totalCh.ToString)
            lbl_importePago.Text = precio(total.ToString)
        Else
            total -= totalCh
            lbl_totalCh.Text = precio("0")
            lbl_importePago.Text = precio(total.ToString)
        End If

        dg_viewCH.Enabled = chk
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
            MsgBox("El campo 'Proveedor' es obligatorio y está vacio", vbOKOnly, vbExclamation)
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

            'If chk_transferencia.Checked Then
            '    .totalTransferencia = txt_transferenciaBancaria.Text
            'Else
            '    .totalTransferencia = 0
            'End If

            If chk_transferencia.Checked Then
                .hayTransferencia = True
                .totalTransferencia = sumaTransferencias()
            Else
                .hayTransferencia = False
                .totalTransferencia = 0
            End If

            If chk_cheque.Checked Then
                .hayCheque = True
                .totalch = sumaCheques()
            Else
                .hayCheque = False
                .totalch = 0
            End If

            '.hayCheque = chk_cheque.Checked
            '.aplicaFc = txt_aplicaFc.Text
            .notas = txt_notas.Text

            .total = .total + sumaCheques() + sumaTransferencias()
        End With

        pg.id_pago = addpago(pg)
        If pg.id_pago <> -1 Then
            If pg.hayCheque Then
                Dim count As Integer = -1

                For Each row As DataGridViewRow In dg_viewCH.Rows
                    If (Convert.ToBoolean(row.Cells(selColName).Value)) Then count += 1
                Next
                Dim cheques(count) As Integer
                count = 0

                Dim ch As New cheque
                For Each row As DataGridViewRow In dg_viewCH.Rows
                    If (Convert.ToBoolean(row.Cells(selColName).Value)) Then
                        cheques(count) = row.Cells("ID").Value
                        'Actualizo el estado del cheque
                        ch = info_cheque(cheques(count).ToString)
                        ch.id_estadoch = ID_CH_ENTREGADO
                        updatech(ch)
                        count += 1
                    End If
                Next

                add_chequePagado(pg.id_pago, cheques)
            End If

            If pg.hayTransferencia Then
                If Not guardarTransferencias(pg) Then
                    MsgBox("Hubo un problema al agregar el cobro.", vbExclamation + vbOKOnly, "Centrex")
                    closeandupdate(Me)
                End If
            End If

            If Not guardar_pagos_facturas_importes(pg.id_pago, dg_view_nFC_importes) Then
                MsgBox("Hubo un problema al agregar el pago.", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If

            'Actualizo el saldo del proveedor
            'Dim p As New proveedor

            ccp.saldo -= pg.total
            updateCCProveedor(ccp)

            'Dim frm As New frm_prnReportes("rpt_ordenDePago", "datos_empresa", "SP_pago_cabecera", "SP_detalle_pagos_cheques", "SP_detalle_pagos_transferencias", "DS_Datos_Empresa",
            '                                "DS_Pago_Cabecera", "DS_Detalle_Pagos_Cheques", "DS_Detalle_Pagos_Transferencias", pg.id_pago, True)
            'frm.ShowDialog()
            Dim rptOrdenDePago As New frm_prnOrdenDePago(pg.id_pago)
            rptOrdenDePago.ShowDialog()
            closeandupdate(Me)
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

    'Private Sub txt_transferenciaBancaria_Leave(sender As Object, e As EventArgs)
    '    total -= transferenciaBancaria
    '    transferenciaBancaria = Convert.ToDouble(txt_transferenciaBancaria.Text)
    '    total += transferenciaBancaria

    '    lbl_importePago.Text = "$ " + Convert.ToString(total)
    'End Sub

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

            'MUESTRA LOS CHEQUES EN CARTERA DISPONIBLES PARA USAR PARA PAGAR A UN PROVEEDOR

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
            Dim nRegs As Integer = 0
            Dim tPaginas As Integer = 0
            Dim txtnPage As New TextBox()
            cargar_datagrid(dg_viewCH, sqlstr, basedb, 0, nRegs, tPaginas, 1, txtnPage, "cheques", "cheques")
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

    Private Sub txt_search_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            ' actualizarDataGrid(cmb_proveedor.SelectedValue.ToString)
            actualizarDataGrid()
        End If
    End Sub

    Private Sub dg_view_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If dg_viewCH.IsCurrentCellDirty Then
            dg_viewCH.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dg_view_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
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

        For Each row As DataGridViewRow In dg_viewCH.Rows
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

        For Each row As DataGridViewRow In dg_viewCH.Rows
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
        'txt_transferenciaBancaria.Text = transferenciaBancaria
        lbl_totalTransferencia.Text = precio(transferenciaBancaria)
        txt_search.Text = ""
        lbl_totalCh.Text = "$ " + Convert.ToString(totalCh)
        lbl_importePago.Text = "$ " + Convert.ToString(total)
        cargarDGTransferencias()
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

    Private Sub chk_transferencia_CheckedChanged(sender As Object, e As EventArgs) Handles chk_transferencia.CheckedChanged
        Dim chk As Boolean
        chk = chk_transferencia.Checked

        If chk Then
            total += transferenciaBancaria
            lbl_totalTransferencia.Text = precio(transferenciaBancaria.ToString)
            lbl_importePago.Text = precio(total.ToString)
        Else
            total -= transferenciaBancaria
            lbl_totalTransferencia.Text = precio("0")
            lbl_importePago.Text = precio(total.ToString)
        End If

        txt_searchTransferencia.Enabled = chk
        dg_viewTransferencia.Enabled = chk
        cmd_addTransferencia.Enabled = chk
    End Sub
    Private Sub cargarDGTransferencias()
        Dim sqlstr As String

        sqlstr = "SELECT t.id_tmpTransferencia AS 'ID', b.nombre AS 'Banco', cb.nombre AS 'Cuenta Bancaria', CAST(t.fecha AS VARCHAR(50)) AS 'Fecha', " +
                    "t.total AS 'Total', t.notas AS 'Notas' " +
                    "FROM tmptransferencias AS t " +
                    "INNER JOIN cuentas_bancarias AS cb ON t.id_cuentaBancaria = cb.id_cuentaBancaria " +
                    "INNER JOIN bancos AS b ON cb.id_banco = b.id_banco"

        'Carga el datagrid con los nuevos datos
        Dim nRegs As Integer = 0
        Dim tPaginas As Integer = 0
        Dim txtnPage As New TextBox()
        cargar_datagrid(dg_viewTransferencia, sqlstr, basedb, 0, nRegs, tPaginas, 1, txtnPage, "tmptransferencias", "tmptransferencias")
    End Sub
    Private Function sumaTransferencias() As Double
        'Obtengo el total de las transferencias
        Dim suma As Double

        For Each row As DataGridViewRow In dg_viewTransferencia.Rows
            suma += row.Cells("Total").Value
        Next

        Return suma
    End Function

    Private Sub actualizaTransferencias()
        cargarDGTransferencias()

        total -= transferenciaBancaria
        transferenciaBancaria = sumaTransferencias()
        total += transferenciaBancaria

        lbl_totalTransferencia.Text = precio(transferenciaBancaria)
        lbl_importePago.Text = precio(total)
    End Sub

    Private Sub dg_viewTransferencia_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_viewTransferencia.CellMouseDoubleClick
        Dim seleccionado As String = dg_viewTransferencia.CurrentRow.Cells(0).Value.ToString
        edita_transferencia = InfoTmpTransferencia(seleccionado)

        If edita_transferencia.id_transferencia = -1 Then
            MsgBox("Ocurrió un problema al editar la transferencia.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If borrado = False Then edicion = True

        add_transferencia.ShowDialog()

        actualizaTransferencias()

        edicion = False
    End Sub

    Private Sub cmd_addTransferencia_Click(sender As Object, e As EventArgs) Handles cmd_addTransferencia.Click
        'Dim t As New transferencia

        add_transferencia.ShowDialog()

        actualizaTransferencias()
    End Sub

    Private Function sumaCheques() As Double
        'Obtengo el total de los cheques
        Dim suma As Double

        For Each row As DataGridViewRow In dg_viewCH.Rows
            If (Convert.ToBoolean(row.Cells(selColName).Value)) Then
                suma += row.Cells("Importe").Value
            End If
        Next

        Return suma
    End Function

    Private Sub dg_view_nFC_importes_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dg_view_nFC_importes.EditingControlShowing
        If dg_view_nFC_importes.CurrentCell.ColumnIndex = 2 Then 'Numeric column with decimal point
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf dg_view_nFC_importes_textbox_keyPress
        End If
    End Sub

    Private Sub dg_view_nFC_importes_textbox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        'Allows Numeric values, one decimal point and BackSpace key
        Dim numbers As Windows.Forms.TextBox = sender
        If InStr("1234567890.", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Or (e.KeyChar = "." And InStr(numbers.Text, ".") > 0) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If
    End Sub

    Private Sub dg_viewCH_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dg_viewCH.CellValueChanged
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
        lbl_totalCh.Text = precio(totalCh)
        lbl_importePago.Text = precio(total)
    End Sub

    Private Sub dg_viewCH_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_viewCH.CellMouseDoubleClick
        Dim seleccionado As String = dg_viewTransferencia.CurrentRow.Cells(0).Value.ToString
        edita_cheque = info_cheque(seleccionado)
        If borrado = False Then edicion = True

        add_cheque.ShowDialog()

        actualizarDataGrid()
        edicion = False
    End Sub


    Private Sub dg_viewCH_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dg_viewCH.CurrentCellDirtyStateChanged
        If dg_viewCH.IsCurrentCellDirty Then
            dg_viewCH.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

End Class