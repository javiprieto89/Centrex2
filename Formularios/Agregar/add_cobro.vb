Public Class add_cobro
    Private c As New cliente
    Private cc As New ccCliente
    Private selColName As String = "Seleccionado"
    Private total As Double = Nothing
    Private efectivo As Double = Nothing
    Private transferenciaBancaria As Double = Nothing
    Private totalRetenciones As Double = Nothing
    Private totalCh As Double = Nothing
    Private chSel() As Integer
    Private noCambiar As Boolean = False

    'Private chSelSearch() As Integer

    Private Sub add_cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        form = Me

        'Borro datos anteriores
        borrartbl("tmpcobros_retenciones")
        borrartbl("tmptransferencias")
        borrartbl("tmpSelCH")

        'Cargo el combo con todos los clientes
        sqlstr = "SELECT c.id_cliente AS 'id_cliente', c.razon_social AS 'razon_social' FROM clientes AS c WHERE c.activo = '1' ORDER BY c.razon_social ASC"
        cargar_combo(cmb_cliente, sqlstr, basedb, "razon_social", "id_cliente")
        cmb_cliente.Text = "Seleccione un cliente"
        cmb_cc.Enabled = False

        resetForm()

        lbl_fechaCarga.Text = Hoy()
        form = Me
    End Sub

    Private Sub add_cobro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmb_cliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cliente.SelectionChangeCommitted
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

        Dim c As String = cmb_cliente.SelectedValue.ToString

        'Cargo los combos con todas las cuentas corrientes del cliente
        sqlstr = "SELECT id_cc, nombre FROM cc_clientes WHERE activo = 1 AND id_cliente = '" + c + "' ORDER BY nombre ASC"
        cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")
        cmb_cc.Text = "Seleccione una cuenta corriente..."
        cmb_cc.Enabled = True
        Me.ActiveControl = Me.cmb_cc

        chk_cobro_no_oficial.Enabled = True
        chk_efectivo.Enabled = True
        chk_transferencia.Enabled = True
        chk_cheque.Enabled = True
        'txt_aplicaFc.Enabled = True
        txt_notas.Enabled = True
        chk_retenciones.Enabled = True
        dg_view_nFC_importes.Enabled = True
        'c = info_cliente(cmb_cliente.SelectedValue)
        'cmb_cc_SelectionChangeCommitted(Nothing, Nothing)
        actualizarDataGrid(c)
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
        txt_searchCH.Enabled = chk
        lbl_borrarbusquedaCH.Enabled = chk
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

    Private Sub chk_retenciones_CheckedChanged(sender As Object, e As EventArgs) Handles chk_retenciones.CheckedChanged
        Dim chk As Boolean
        chk = chk_retenciones.Checked

        If chk Then
            total += totalRetenciones
            lbl_totalRetencion.Text = precio(totalRetenciones.ToString)
            lbl_importePago.Text = precio(total.ToString)
        Else
            total -= totalRetenciones
            lbl_totalRetencion.Text = precio("0")
            lbl_importePago.Text = precio(total)
        End If

        txt_searchRetencion.Enabled = chk
        dg_viewRetencion.Enabled = chk
        cmd_addRetencion.Enabled = chk
    End Sub

    Private Sub cmb_cc_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cc.SelectionChangeCommitted
        'If cc.saldo > 0 Then total -= cc.saldo
        cc = info_ccCliente(cmb_cc.SelectedValue)

        'If cc.saldo > 0 Then total += cc.saldo
        lbl_saldo.Text = "$ " + cc.saldo.ToString
        lbl_importePago.Text = precio(total.ToString)
        If cc.saldo < 0 Then
            lbl_saldo.ForeColor = Color.Red
        Else
            lbl_saldo.ForeColor = Color.Green
        End If
    End Sub

    Private Sub cmd_addCheques_Click(sender As Object, e As EventArgs) Handles cmd_addCheques.Click
        Dim addCheque As New add_cheque(cmb_cliente.SelectedValue, -1)
        addCheque.ShowDialog()
        actualizarDataGrid(cmb_cliente.SelectedValue.ToString)
    End Sub

    Private Sub cmd_verCheques_Click(sender As Object, e As EventArgs) Handles cmd_verCheques.Click
        Dim frm As New frmCheques(cmb_cliente.SelectedValue)
        frm.ShowDialog()
    End Sub

    Private Sub txt_efectivo_Leave(sender As Object, e As EventArgs) Handles txt_efectivo.Leave
        total -= efectivo
        efectivo = Convert.ToDouble(txt_efectivo.Text)
        total += efectivo

        lbl_importePago.Text = precio(total)
    End Sub

    'Private Sub txt_totalRetenciones_Leave(sender As Object, e As EventArgs)
    '    total -= totalRetenciones
    '    totalRetenciones = Convert.ToDouble(txt_totalRetenciones.Text)
    '    total += totalRetenciones

    '    lbl_importePago.Text = precio(total)
    'End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim cb As New cobro
        Dim sqlstr As String
        Dim sumaFC As Double = 0

        If cmb_cliente.Text = "Seleccione un cliente" Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
            If Not chk_efectivo.Checked And Not chk_transferencia.Checked And Not chk_cheque.Checked Then
                MsgBox("Debe elegir algún medio de pago", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            End If
        End If

        'If dg_view_nFC_importes.Rows.Count = 0 Then
        '    MsgBox("Debe indicar a que facturas está aplicando el pago y sus importes", vbCritical + vbOKOnly, "Centrex")
        '    Exit Sub
        'End If


        'For Each row As DataGridViewRow In dg_view_nFC_importes.Rows
        '    If Not row Is Nothing Then
        '        sumaFC += row.Cells("Importe").Value
        '    End If
        'Next

        'If sumaFC <> total Then
        '    MsgBox("El monto ingresado no coincide con los que ingreso en las facturas a cobrar", vbCritical + vbOKOnly, "Centrex")
        '    Exit Sub
        'End If

        sqlstr = "Una vez dado de alta un cobro, no puede modificarse, debera anularlo y cargarlo nuevamente en caso de error." & vbCr &
                "Verifique que los datos sean correctos." & vbCr
        'If txt_aplicaFc.Text = "" Then sqlstr += "ATENCIÓN: No ha completado el campo de facturas a las que aplica este cobro." & vbCr
        sqlstr += "¿Está seguro de que desea continuar?"

        If MsgBox(sqlstr, vbYesNo + vbQuestion, "Centrex") = vbNo Then
            Exit Sub
        End If

        With cb
            If chk_cobro_no_oficial.Checked Then
                .id_cobro_oficial = -1
                .id_cobro_no_oficial = Ultimo_cobro_no_oficial()
            Else
                .id_cobro_oficial = Ultimo_cobro_oficial()
                .id_cobro_no_oficial = -1
            End If

            .fecha_carga = lbl_fechaCarga.Text
            .fecha_cobro = dtp_fechaCobro.Value.Date
            .id_cliente = cmb_cliente.SelectedValue
            .id_cc = cmb_cc.SelectedValue

            If chk_efectivo.Checked Then
                .efectivo = txt_efectivo.Text
            Else
                .efectivo = 0
            End If

            If chk_cheque.Checked Then
                .hayCheque = True
                .totalCh = sumaCheques()
            Else
                .hayCheque = False
                .totalCh = 0
            End If

            If chk_transferencia.Checked Then
                .hayTransferencia = True
                .totalTransferencia = sumaTransferencias()
            Else
                .hayTransferencia = False
                .totalTransferencia = 0
            End If

            If chk_retenciones.Checked Then
                '.txtRetencion = txt_Retenciones.Text
                .hayRetencion = True
                .totalRetencion = totalRetenciones
            Else
                .hayRetencion = False
                .totalRetencion = 0
            End If

            '.aplicaFc = txt_aplicaFc.Text

            .total = total
            'If txt_notas.Text = "" Then txt_notas.Text = " "
            .notas = txt_notas.Text
            .firmante = txt_firmante.Text
        End With

        cb.id_cobro = addcobro(cb)
        cb = info_cobro(cb.id_cobro)
        If cb.id_cobro Then
            If cb.hayCheque Then
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
                        'ch = info_cheque(cheques(count).ToString)
                        'ch.id_estadoch = ID_CH_ENTREGADO
                        'updatech(ch)
                        count += 1
                    End If
                Next


                add_chequeCobrado(cb.id_cobro, cheques)
            End If

            If cb.hayTransferencia Then
                If Not guardarTransferencias(cb) Then
                    MsgBox("Hubo un problema al agregar el cobro.", vbExclamation + vbOKOnly, "Centrex")
                    closeandupdate(Me)
                End If
            End If

            If cb.hayRetencion Then
                If Not guardarCobroRetencion(cb) Then
                    MsgBox("Hubo un problema al agregar el cobro.", vbExclamation + vbOKOnly, "Centrex")
                    closeandupdate(Me)
                End If
            End If

            If Not guardar_cobros_facturas_importes(cb.id_cobro, dg_view_nFC_importes) Then
                MsgBox("Hubo un problema al agregar el cobro.", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If

            'Hecho a mano
            cc.saldo -= total
            updateCCCliente(cc)

            closeandupdate(Me)
            'Dim frm As New frm_prnReportes("rpt_reciboCobro", "datos_empresa", "produccion_cabecera", "produccion_detalle", "DS_empresa",
            '                               "DSProd_cabecera", "DSProd_detalle", ultimaProd.id_produccion)
            'frm.ShowDialog()
        Else
            MsgBox("Hubo un problema al agregar el cobro.", vbExclamation + vbOKOnly, "Centrex")
            closeandupdate(Me)
        End If
    End Sub

    Private Sub pic_searchCliente_Click(sender As Object, e As EventArgs) Handles pic_searchCliente.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "clientes"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        cmb_cliente.SelectedValue = id
        cmb_cliente_SelectionChangeCommitted(Nothing, Nothing)
        updateform(id.ToString, cmb_cliente)
    End Sub

    Private Sub cmb_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cliente.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_cc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cc.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub lbl_borrarbusquedaCH_DoubleClick(sender As Object, e As EventArgs) Handles lbl_borrarbusquedaCH.DoubleClick
        txt_searchCH.Text = ""
        actualizarDataGrid(cmb_cliente.SelectedValue.ToString)
    End Sub

    Private Sub actualizarDataGrid(ByVal c As String)
        Dim sqlstr As String = ""
        Dim txtsearch As String = ""
        Dim count As Integer = 0

        If txt_searchCH.Text <> "" Then
            txtsearch = Microsoft.VisualBasic.Replace(txt_searchCH.Text, " ", "%")

            checkCheques()

            sqlstr = "SELECT ch.id_cheque AS 'ID', c.razon_social AS 'Cliente', b.nombre AS 'Banco', ch.nCheque AS 'Nº cheque', ch.importe AS 'Importe', sech.estado AS 'Estado', " &
                 "CASE WHEN ch.id_cuentaBancaria IS NULL THEN 'No' ELSE CONCAT('Si, en:', cbb.nombre, ' - ', cb.nombre) END AS '¿Depositado?', " &
                 "CASE WHEN ch.activo = 1 THEN 'Si' ELSE 'No' END AS '¿Activo?' " &
                 "FROM cheques AS ch " &
                 "INNER JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                 "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                 "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                 "LEFT JOIN bancos AS cbb ON cb.id_banco = cbb.id_banco " &
                 "INNER JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                 "WHERE (ch.activo = 1 AND c.id_cliente = " & c & ") " &
                 "AND (ch.id_cheque LIKE '%" & txtsearch & "%' " &
                 "OR b.nombre LIKE '%" & txtsearch & "%' " &
                 "OR ch.nCheque LIKE '%" & txtsearch & "%' " &
                 "OR ch.importe LIKE '%" & txtsearch & "%' " &
                 "OR sech.estado LIKE '%" & txtsearch & "%') " &
                 "ORDER BY ch.nCheque ASC"
        Else
            checkCheques()

            sqlstr = "SELECT ch.id_cheque AS 'ID', c.razon_social AS 'Cliente', b.nombre AS 'Banco', ch.nCheque AS 'Nº cheque', ch.importe AS 'Importe', sech.estado AS 'Estado', " &
                 "CASE WHEN ch.id_cuentaBancaria IS NULL THEN 'No' ELSE CONCAT('Si, en:', cbb.nombre, ' - ', cb.nombre) END AS '¿Depositado?', " &
                 "CASE WHEN ch.activo = 1 THEN 'Si' ELSE 'No' END AS '¿Activo?' " &
                 "FROM cheques AS ch " &
                 "INNER JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                 "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                 "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                 "LEFT JOIN bancos AS cbb ON cb.id_banco = cbb.id_banco " &
                 "INNER JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                 "WHERE ch.activo = 1 AND c.id_cliente = " & c & " " &
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
        lbl_importePago.Text = precio(total)
    End Sub

    Private Sub txt_searchCH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_searchCH.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            actualizarDataGrid(cmb_cliente.SelectedValue.ToString)
        End If
    End Sub

    Private Sub dg_viewCH_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dg_viewCH.CurrentCellDirtyStateChanged
        If dg_viewCH.IsCurrentCellDirty Then
            dg_viewCH.CommitEdit(DataGridViewDataErrorContexts.Commit)
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
        total = 0
        totalRetenciones = 0
        chSel = Nothing
        noCambiar = False

        chk_cobro_no_oficial.Checked = False
        chk_efectivo.Checked = False
        chk_transferencia.Checked = False
        chk_cheque.Checked = False
        chk_retenciones.Checked = False

        txt_efectivo.Text = efectivo
        'txt_transferenciaBancaria.Text = transferenciaBancaria
        'txt_totalRetenciones.Text = totalRetenciones
        lbl_totalRetencion.Text = precio(totalRetenciones)
        lbl_totalTransferencia.Text = precio(transferenciaBancaria)

        txt_searchCH.Text = ""
        'txt_aplicaFc.Text = ""
        'txt_Retenciones.Text = ""
        txt_notas.Text = ""
        lbl_totalCh.Text = precio(totalCh)
        lbl_importePago.Text = precio(total)
        cargarDGTransferencias()
        cargarDGRetenciones()
    End Sub

    Private Sub pic_searchCCCliente_Click(sender As Object, e As EventArgs) Handles pic_searchCCCliente.Click
        'busqueda
        Dim tmp As String
        Dim tmpCliente As cliente

        If cmb_cliente.Text = "Seleccione un cliente" Or cmb_cliente.SelectedValue = 0 Then Exit Sub

        tmp = tabla
        tmpCliente = edita_cliente
        edita_cliente = info_cliente(cmb_cliente.SelectedValue)
        tabla = "cc_clientes"
        Me.Enabled = False

        search.ShowDialog()
        tabla = tmp
        edita_cliente = tmpCliente

        'Establezco la opción del combo, si es 0 elijo el cliente default
        If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_cc)
    End Sub

    Private Sub cmd_addTransferencia_Click(sender As Object, e As EventArgs) Handles cmd_addTransferencia.Click
        'Dim t As New transferencia

        add_transferencia.ShowDialog()

        actualizaTransferencias()
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        If MsgBox("¿Está seguro que desea cancelar el ingreso del cobro?" & vbCr &
                  "Perderá todos los datos cargados", vbQuestion + vbYesNo, "Centrex") = vbYes Then
            closeandupdate(Me)
        End If
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

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        borrado = True
        If tbControl.SelectedTab.Name = "tb_cheques" Then
            'seleccionado = dg_viewCH.CurrentRow.Cells(0).Value
        ElseIf tbControl.SelectedTab.Name = "tb_transferencias" Then
            dg_viewTransferencia_CellMouseDoubleClick(Nothing, Nothing)
        End If
        borrado = False
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        edicion = True
        If tbControl.SelectedTab.Name = "tb_cheques" Then
            'seleccionado = dg_viewCH.CurrentRow.Cells(0).Value
        ElseIf tbControl.SelectedTab.Name = "tb_transferencias" Then
            dg_viewTransferencia_CellMouseDoubleClick(Nothing, Nothing)
        End If
        edicion = False
    End Sub

    Private Sub dg_viewCH_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_viewCH.CellMouseDoubleClick
        Dim seleccionado As String = dg_viewTransferencia.CurrentRow.Cells(0).Value.ToString
        edita_cheque = info_cheque(seleccionado)
        If borrado = False Then edicion = True

        add_cheque.ShowDialog()

        actualizarDataGrid(cmb_cliente.SelectedValue.ToString)
        edicion = False
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

    Private Function sumaTransferencias() As Double
        'Obtengo el total de las transferencias
        Dim suma As Double

        For Each row As DataGridViewRow In dg_viewTransferencia.Rows
            suma += row.Cells("Total").Value
        Next

        Return suma
    End Function

    Private Function sumaRetenciones() As Double
        'Obtengo el total de las retenciones
        Dim suma As Double

        For Each row As DataGridViewRow In dg_viewRetencion.Rows
            suma += row.Cells("Total").Value
        Next

        Return suma
    End Function

    Private Sub cmd_addRetencion_Click(sender As Object, e As EventArgs) Handles cmd_addRetencion.Click
        'Dim t As New transferencia
        add_cobroRetencion.ShowDialog()

        actualizaRetenciones()
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
    Private Sub actualizaTransferencias()
        cargarDGTransferencias()

        total -= transferenciaBancaria
        transferenciaBancaria = sumaTransferencias()
        total += transferenciaBancaria

        lbl_totalTransferencia.Text = precio(transferenciaBancaria)
        lbl_importePago.Text = precio(total)
    End Sub
    Private Sub cargarDGRetenciones()
        Dim sqlstr As String

        sqlstr = "SELECT cb.id_tmpRetencion AS 'ID', i.nombre AS 'Retencion', cb.total AS 'Total', cb.notas AS 'Notas' " +
                    "FROM tmpcobros_retenciones AS cb " +
                    "INNER JOIN impuestos AS i ON cb.id_impuesto = i.id_impuesto "

        'Carga el datagrid con los nuevos datos
        Dim nRegs As Integer = 0
        Dim tPaginas As Integer = 0
        Dim txtnPage As New TextBox()
        cargar_datagrid(dg_viewRetencion, sqlstr, basedb, 0, nRegs, tPaginas, 1, txtnPage, "tmpcobros_retenciones", "tmpcobros_retenciones")
    End Sub
    Private Sub actualizaRetenciones()
        cargarDGRetenciones()

        total -= totalRetenciones
        totalRetenciones = sumaRetenciones()
        total += totalRetenciones

        lbl_totalRetencion.Text = precio(totalRetenciones)
        lbl_importePago.Text = precio(total)
    End Sub

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

    'Private Sub dg_view_nFC_importes_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dg_view_nFC_importes.CellValidating
    '    If e.ColumnIndex = 2 Then
    '        If dg_view_nFC_importes.IsCurrentCellDirty Then
    '            If Not IsNumeric(e.FormattedValue) Then
    '                e.Cancel = True
    '                MsgBox("Solo puede ingresar números en el campo Importe")
    '            End If
    '        End If
    '    End If
    'End Sub
End Class
