Public Class frm_depositarCH
    Dim desde_cartera As Integer
    Dim pagina_cartera As Integer
    Dim nRegs_cartera As Integer
    Dim tPaginas_cartera As Integer
    Dim orderCol_cartera As ColumnClickEventArgs = Nothing
    'Dim fecha_desde_cartera As Date
    'Dim fecha_hasta_cartera As Date

    Dim desde_depositado As Integer
    Dim pagina_depositado As Integer
    Dim nRegs_depositado As Integer
    Dim tPaginas_depositado As Integer
    Dim orderCol_depositado As ColumnClickEventArgs = Nothing

    '*******************************
    '* id_estadoch   *   Estado    *
    '*******************************
    '*  1           *   En cartera *
    '*  2           *   Entregado  *
    '*  3           *   Cobrado    *
    '*  4           *   Rechazado  *
    '*******************************

    Private Sub frm_depositarCH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fecha_desde_cartera = Today()
        'fecha_hasta_cartera = Date.MaxValue

        cargar_combo(cmb_banco, "SELECT id_banco, nombre FROM bancos WHERE activo = '1' ORDER BY nombre ASC", basedb, "nombre", "id_banco")

        cmb_banco.Text = "Seleccione un banco..."
        cmb_cuentaBancaria.Text = "Seleccione una cuenta bancaria..."
        chk_desdeSiempre_cartera.Checked = True
        dtp_desde_cartera.Value = dtp_desde_cartera.MinDate
        chk_hastaSiempre_cartera.Checked = True
        dtp_hasta_cartera.Value = Today.Date

        cmb_cuentaBancaria.Enabled = False
        'cmd_depositar.Enabled = False
        'cmd_acreditar.Enabled = False
        'cmd_anular.Enabled = False


        actualizarDatagrid_cartera()

    End Sub

    Private Sub actualizarDatagrid_cartera()
        Dim sqlstr As String
        Dim fecha_desde As Date
        Dim fecha_hasta As Date

        If chk_desdeSiempre_cartera.Checked Then
            fecha_desde = dtp_desde_cartera.Value
        Else
            fecha_desde = Date.MinValue
        End If

        If chk_hastaSiempre_cartera.Checked Then
            fecha_hasta = dtp_hasta_cartera.Value
        Else
            fecha_hasta = Date.MaxValue
        End If


        sqlstr = "SELECT ch.id_cheque AS 'ID', CAST(ch.fecha_ingreso AS VARCHAR(50)) AS 'F. Ingreso', CAST(ch.fecha_emision AS VARCHAR(50)) AS 'F. Emisión', " &
                    "c.razon_social AS 'Recibido de', p.razon_social AS 'Entregado a', b.nombre AS 'Banco emisor', " &
                    "cb.nombre AS 'Depositado en', ch.nCheque AS 'Nº cheque', ch.nCheque2 AS '2do nºd/cheque', ch.importe AS 'Monto', sech.estado AS 'Estado', " &
                    "CAST(ch.fecha_cobro AS VARCHAR(50)) AS 'Fecha de cobro', " &
                    "CAST(ch.fecha_salida AS VARCHAR(50)) AS 'Fecha de salida', CAST(ch.fecha_deposito AS VARCHAR(50)) AS 'Fecha de deposito' " &
                    "FROM cheques AS ch " &
                    "LEFT JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                    "LEFT JOIN proveedores AS p ON ch.id_proveedor = p.id_proveedor " &
                    "LEFT JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                    "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                    "LEFT JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                    "WHERE ch.activo = '1' " &
                    "AND ch.id_estadoch = '1' " &
                    "AND ch.fecha_cobro BETWEEN '" + fecha_desde.ToString("yyyy/MM/dd") + "' AND '" + fecha_hasta.ToString("yyyy/MM/dd") + "' "
        If txt_nCH_cartera.Text <> "" Then sqlstr += "AND ch.nCheque = '" + txt_nCH_cartera.Text + "' "
        If txt_importeCH_cartera.Text <> "" Then sqlstr += "AND ch.importe = '" + txt_importeCH_cartera.Text + "' "
        sqlstr += "AND ch.id_estadoch = '" + ID_CH_CARTERA.ToString + "' " &
                    "ORDER BY ch.id_cheque ASC"

        desde_cartera = 0
        pagina_cartera = 1


        cargar_datagrid(dg_view_chCartera, sqlstr, basedb, desde_cartera, nRegs_cartera, tPaginas_cartera, pagina_cartera, txt_nPage_cartera, "cheques", "cheques")
        dg_view_chCartera.ClearSelection()
    End Sub

    Private Sub actualizarDatagrid_cartera(ByVal sqlstr As String, ByVal fecha_desde As Date, ByVal fecha_hasta As Date)
        desde_cartera = 0
        pagina_cartera = 1


        cargar_datagrid(dg_view_chCartera, sqlstr, basedb, desde_cartera, nRegs_cartera, tPaginas_cartera, pagina_cartera, txt_nPage_cartera, "cheques", "cheques")
    End Sub

    Private Sub cmd_next_Click_cartera(sender As Object, e As EventArgs) Handles cmd_next_cartera.Click
        If pagina_cartera = Math.Ceiling(nRegs_cartera / itXPage) Then Exit Sub
        desde_cartera += itXPage
        pagina_cartera += 1
        actualizarDatagrid_cartera()
    End Sub

    Private Sub cmd_prev_Click_cartera(sender As Object, e As EventArgs) Handles cmd_prev_cartera.Click
        If pagina_cartera = 1 Then Exit Sub
        desde_cartera -= itXPage
        pagina_cartera -= 1
        actualizarDatagrid_cartera()
    End Sub

    Private Sub cmd_first_Click_cartera(sender As Object, e As EventArgs) Handles cmd_first_cartera.Click
        desde_cartera = 0
        pagina_cartera = 1
        actualizarDatagrid_cartera()
    End Sub

    Private Sub cmd_last_Click_cartera(sender As Object, e As EventArgs) Handles cmd_last_cartera.Click
        pagina_cartera = tPaginas_cartera
        desde_cartera = nRegs_cartera - itXPage
        actualizarDatagrid_cartera()
    End Sub

    Private Sub cmd_go_Click_cartera(sender As Object, e As EventArgs) Handles cmd_go_cartera.Click
        pagina_cartera = txt_nPage_cartera.Text
        If pagina_cartera > tPaginas_cartera Then pagina_cartera = tPaginas_cartera
        desde_cartera = (pagina_cartera - 1) * itXPage
        actualizarDatagrid_cartera()
    End Sub

    Private Sub txt_nPage_KeyDown_cartera(sender As Object, e As KeyEventArgs) Handles txt_nPage_cartera.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmd_go_Click_cartera(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_nPage_Click_cartera(sender As Object, e As EventArgs) Handles txt_nPage_cartera.Click
        txt_nPage_cartera.Text = ""
    End Sub

    Private Sub actualizarDatagrid_depositado()
        Dim sqlstr As String
        Dim fecha_desde As Date
        Dim fecha_hasta As Date

        If chk_desdeSiempre_depositado.Checked Then
            fecha_desde = dtp_desde_depositado.Value
        Else
            fecha_desde = Date.MinValue
        End If

        If chk_hastaSiempre_depositado.Checked Then
            fecha_hasta = dtp_hasta_depositado.Value
        Else
            fecha_hasta = Date.MaxValue
        End If

        sqlstr = "SELECT ch.id_cheque AS 'ID', CAST(ch.fecha_ingreso AS VARCHAR(50)) AS 'F. Ingreso', CAST(ch.fecha_emision AS VARCHAR(50)) AS 'F. Emisión', " &
                    "c.razon_social AS 'Recibido de', p.razon_social AS 'Entregado a', b.nombre AS 'Banco emisor', " &
                    "cb.nombre AS 'Depositado en', ch.nCheque AS 'Nº cheque', ch.nCheque2 AS '2do nºd/cheque', ch.importe AS 'Monto', sech.estado AS 'Estado', " &
                    "CAST(ch.fecha_cobro AS VARCHAR(50)) AS 'Fecha de cobro', " &
                    "CAST(ch.fecha_salida AS VARCHAR(50)) AS 'Fecha de salida', CAST(ch.fecha_deposito AS VARCHAR(50)) AS 'Fecha de deposito' " &
                    "FROM cheques AS ch " &
                    "LEFT JOIN clientes AS c ON ch.id_cliente = c.id_cliente " &
                    "LEFT JOIN proveedores AS p ON ch.id_proveedor = p.id_proveedor " &
                    "LEFT JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                    "LEFT JOIN cuentas_bancarias AS cb ON ch.id_cuentaBancaria = cb.id_cuentaBancaria " &
                    "LEFT JOIN sysestados_cheques AS sech ON ch.id_estadoch = sech.id_estadoch " &
                    "WHERE ch.activo = '1' "
        If cmb_cuentaBancaria.Text <> "Seleccione una cuenta bancaria..." Then sqlstr += " AND ch.id_cuentaBancaria = '" & cmb_cuentaBancaria.SelectedValue.ToString & "'"
        sqlstr += "AND ch.fecha_cobro BETWEEN '" + fecha_desde.ToString("yyyy/MM/dd") + "' AND '" + fecha_hasta.ToString("yyyy/MM/dd") + "' "
        If txt_nCH_depositado.Text <> "" Then sqlstr += "AND ch.nCheque = '" + txt_nCH_depositado.Text + "' "
        If txt_importeCH_depositado.Text <> "" Then sqlstr += "AND ch.importe = '" + txt_importeCH_depositado.Text + "' "
        sqlstr += "AND ch.id_estadoch = '" + ID_CH_DEPOSITADO.ToString + "' " &
                    "ORDER BY ch.id_cheque ASC"

        desde_cartera = 0
        pagina_cartera = 1

        cargar_datagrid(dg_view_chDepositados, sqlstr, basedb, desde_depositado, nRegs_depositado, tPaginas_depositado, pagina_depositado, txt_nPage_depositado)
    End Sub

    Private Sub cmd_next_Click_depositado(sender As Object, e As EventArgs) Handles cmd_next_depositado.Click
        If pagina_depositado = Math.Ceiling(nRegs_depositado / itXPage) Then Exit Sub
        desde_depositado += itXPage
        pagina_depositado += 1
        actualizarDatagrid_depositado()
    End Sub

    Private Sub cmd_prev_Click_depositado(sender As Object, e As EventArgs) Handles cmd_prev_depositado.Click
        If pagina_depositado = 1 Then Exit Sub
        desde_depositado -= itXPage
        pagina_depositado -= 1
        actualizarDatagrid_depositado()
    End Sub

    Private Sub cmd_first_Click_depositado(sender As Object, e As EventArgs) Handles cmd_first_depositado.Click
        desde_depositado = 0
        pagina_depositado = 1
        actualizarDatagrid_depositado()
    End Sub

    Private Sub cmd_last_Click_depositado(sender As Object, e As EventArgs) Handles cmd_last_depositado.Click
        pagina_depositado = tPaginas_depositado
        desde_depositado = nRegs_depositado - itXPage
        actualizarDatagrid_depositado()
    End Sub

    Private Sub cmd_go_Click_depositado(sender As Object, e As EventArgs) Handles cmd_go_depositado.Click
        pagina_depositado = txt_nPage_depositado.Text
        If pagina_depositado > tPaginas_depositado Then pagina_depositado = tPaginas_depositado
        desde_depositado = (pagina_depositado - 1) * itXPage
        actualizarDatagrid_depositado()
    End Sub

    Private Sub txt_nPage_KeyDown_depositado(sender As Object, e As KeyEventArgs) Handles txt_nPage_depositado.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmd_go_Click_depositado(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_nPage_Click_depositado(sender As Object, e As EventArgs) Handles txt_nPage_depositado.Click
        txt_nPage_depositado.Text = ""
    End Sub

    Private Sub txt_nCH_cartera_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nCH_cartera.KeyDown
        If e.KeyData = Keys.Enter Then
            actualizarDatagrid_cartera()
        End If
    End Sub

    Private Sub txt_importeCH_cartera_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_importeCH_cartera.KeyDown
        If e.KeyData = Keys.Enter Then
            actualizarDatagrid_cartera()
        End If
    End Sub

    Private Sub cmd_depositar_Click(sender As Object, e As EventArgs) Handles cmd_depositar.Click
        Dim c As Integer
        Dim sel As Integer = 0
        Dim hay_error As Boolean = False
        Dim ch As New cheque

        For c = 0 To dg_view_chCartera.Rows.Count - 1
            If dg_view_chCartera.Rows(c).Selected Then
                sel += 1
            End If
        Next

        If dg_view_chCartera.Rows.Count - 1 = 0 Then
            MsgBox("No hay cheques que pueda depositar", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf sel = 0 Then
            MsgBox("No ha seleccionado ningún cheque para depositar", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_banco.Text = "Seleccione un banco..." Then
            MsgBox("No hay seleccionado un banco en el cual depositar el/los cheque(s)", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_cuentaBancaria.Text = "Seleccione una cuenta bancaria..." Then
            MsgBox("No hay seleccionada una cuenta bancaria en la cual depositar el/los cheque(s)", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If MsgBox("¿Confirma depositar el/los cheque(s) seleccionados en la cuenta: " & cmb_cuentaBancaria.Text &
                  " perteneciente al banco: " & cmb_banco.Text & "?", vbYesNo + vbQuestion, "Centrex") = vbNo Then
            Exit Sub
        End If

        For c = 0 To dg_view_chCartera.Rows.Count - 1
            If dg_view_chCartera.Rows(c).Selected Then
                ch.id_cheque = dg_view_chCartera.Rows(c).Cells(0).Value.ToString
                ch.fecha_deposito = Hoy()
                ch.id_cuentaBancaria = cmb_cuentaBancaria.SelectedValue()
                ch.nCheque = dg_view_chCartera.Rows(c).Cells(7).Value.ToString
                If Not Depositar_cheque(ch) Then
                    MsgBox("Hubo un problema al depositar el cheque con número: " & ch.nCheque.ToString &
                           "en la cuenta bancaria: " & cmb_cuentaBancaria.Text &
                           "perteneciente al banco: " & cmb_banco.Text, vbCritical + vbOKOnly, "Centrex")
                    hay_error = True
                    'Exit Sub
                End If
            End If
        Next


        If Not hay_error Then
            MsgBox("Se han depositado correctamente los cheques.", vbInformation + vbOKOnly, "Centrex")
        Else
            MsgBox("Verifique, no todos los cheques se depositaron correctamente, puede ser que no puedan ser depositados.", vbInformation + vbOKOnly, "Centrex")
        End If

        actualizarDatagrid_cartera()
        actualizarDatagrid_depositado()
    End Sub

    Private Sub cmb_banco_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_banco.SelectionChangeCommitted
        cargar_combo(cmb_cuentaBancaria, "SELECT cb.id_cuentaBancaria, CONCAT(b.nombre, ' - ', cb.nombre) AS nombre " &
                     "FROM cuentas_bancarias AS cb " &
                     "INNER JOIN bancos AS b  ON cb.id_banco = b.id_banco " &
                     "WHERE cb.activo = '1' AND cb.id_banco = '" + cmb_banco.SelectedValue.ToString + "' " &
                     "ORDER BY b.nombre, cb.nombre ASC", basedb, "nombre", "id_cuentaBancaria")

        cmb_cuentaBancaria.Text = "Seleccione una cuenta bancaria..."
        cmb_cuentaBancaria.Enabled = True

        actualizarDatagrid_depositado()
    End Sub

    Private Sub chk_desdeSiempre_cartera_CheckedChanged(sender As Object, e As EventArgs) 
        dtp_desde_cartera.Enabled = chk_desdeSiempre_cartera.Checked
        actualizarDatagrid_cartera()
    End Sub

    Private Sub chk_hastaSiempre_cartera_CheckedChanged(sender As Object, e As EventArgs) 
        dtp_hasta_cartera.Enabled = chk_hastaSiempre_cartera.Checked
        actualizarDatagrid_cartera()
    End Sub

    Private Sub chk_desdeSiempre_depositado_CheckedChanged(sender As Object, e As EventArgs) Handles chk_desdeSiempre_depositado.CheckedChanged
        dtp_desde_depositado.Enabled = chk_desdeSiempre_depositado.Checked
    End Sub

    Private Sub chk_hastaSiempre_depositado_CheckedChanged(sender As Object, e As EventArgs) Handles chk_hastaSiempre_depositado.CheckedChanged
        dtp_hasta_depositado.Enabled = chk_hastaSiempre_depositado.Checked
    End Sub
    Private Sub txt_nCH_depositado_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nCH_depositado.KeyDown
        If e.KeyData = Keys.Enter Then
            actualizarDatagrid_depositado()
        End If
    End Sub

    Private Sub txt_importeCH_depositado_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_importeCH_depositado.KeyDown
        If e.KeyData = Keys.Enter Then
            actualizarDatagrid_depositado()
        End If
    End Sub

    Private Sub frm_depositarCH_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmb_cuentaBancaria_Leave(sender As Object, e As EventArgs) Handles cmb_cuentaBancaria.Leave
        actualizarDatagrid_depositado()
    End Sub

    Private Sub chk_desdeSiempre_depositado_Leave(sender As Object, e As EventArgs) Handles chk_desdeSiempre_depositado.Leave
        actualizarDatagrid_depositado()
    End Sub

    Private Sub dtp_desde_depositado_Leave(sender As Object, e As EventArgs) Handles dtp_desde_depositado.Leave
        actualizarDatagrid_depositado()
    End Sub

    Private Sub chk_hastaSiempre_depositado_Leave(sender As Object, e As EventArgs) Handles chk_hastaSiempre_depositado.Leave
        actualizarDatagrid_depositado()
    End Sub

    Private Sub dtp_hasta_depositado_Leave(sender As Object, e As EventArgs) Handles dtp_hasta_depositado.Leave
        actualizarDatagrid_depositado()
    End Sub

    Private Sub txt_nCH_depositado_Leave(sender As Object, e As EventArgs) Handles txt_nCH_depositado.Leave
        actualizarDatagrid_depositado()
    End Sub

    Private Sub txt_importeCH_depositado_Leave(sender As Object, e As EventArgs) Handles txt_importeCH_depositado.Leave
        actualizarDatagrid_depositado()
    End Sub

    Private Sub dtp_desde_cartera_Leave(sender As Object, e As EventArgs) 
        actualizarDatagrid_cartera()
    End Sub

    Private Sub dtp_hasta_cartera_Leave(sender As Object, e As EventArgs) 
        actualizarDatagrid_cartera()
    End Sub

    Private Sub txt_nCH_cartera_Leave(sender As Object, e As EventArgs) Handles txt_nCH_cartera.Leave
        actualizarDatagrid_cartera()
    End Sub

    Private Sub txt_importeCH_cartera_Leave(sender As Object, e As EventArgs) Handles txt_importeCH_cartera.Leave
        actualizarDatagrid_cartera()
    End Sub

    Private Sub cmb_cuentaBancaria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_cuentaBancaria.SelectionChangeCommitted
        actualizarDatagrid_depositado()
    End Sub

    Private Sub cmd_anularDeposito_Click(sender As Object, e As EventArgs) Handles cmd_anularDeposito.Click
        Dim c As Integer
        Dim sel As Integer = 0
        Dim hay_error As Boolean = False
        Dim ch As New cheque

        For c = 0 To dg_view_chDepositados.Rows.Count - 1
            If dg_view_chDepositados.Rows(c).Selected Then
                sel += 1
            End If
        Next

        If dg_view_chDepositados.Rows.Count - 1 = 0 Then
            MsgBox("No hay cheques que pueda anular el deposito.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf sel = 0 Then
            MsgBox("No ha seleccionado ningún cheque para anular el deposito.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If MsgBox("¿Confirma anular el deposito de el/los cheque(s) seleccionados?", vbYesNo + vbQuestion, "Centrex") = vbNo Then
            Exit Sub
        End If

        For c = 0 To dg_view_chDepositados.Rows.Count - 1
            If dg_view_chDepositados.Rows(c).Selected Then
                ch.id_cheque = dg_view_chDepositados.Rows(c).Cells(0).Value.ToString
                ch.nCheque = dg_view_chDepositados.Rows(c).Cells(7).Value.ToString
                If Not Anular_Deposito_Cheque(ch.id_cheque) Then
                    MsgBox("Hubo un problema al depositar el cheque con número: " & ch.nCheque.ToString &
                           "en la cuenta bancaria: " & cmb_cuentaBancaria.Text &
                           "perteneciente al banco: " & cmb_banco.Text, vbCritical + vbOKOnly, "Centrex")
                    hay_error = True
                    'Exit Sub
                End If
            End If
        Next


        If Not hay_error Then
            MsgBox("Se ha(n) anulado el/los deposito(s) correctamente.", vbInformation + vbOKOnly, "Centrex")
        Else
            MsgBox("Verifique, no se pudo anular el deposito de todos los cheques, posiblemente el deposito no pueda ser anulado.", vbInformation + vbOKOnly, "Centrex")
        End If

        actualizarDatagrid_cartera()
        actualizarDatagrid_depositado()
    End Sub

    Private Sub cmd_filtrarCH_cartera_Click(sender As Object, e As EventArgs) Handles cmd_filtrarCH_cartera.Click

    End Sub
End Class