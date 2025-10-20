Public Class infoccProveedores
    Dim desde As Integer
    Dim pagina As Integer
    Dim nRegs As Integer
    Dim tPaginas As Integer
    Dim fechaDesde As Date
    Dim fechaHasta As Date
    Dim orderCol As ColumnClickEventArgs = Nothing

    Private Sub ccProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        form = Me

        'Cargo el combo con todos los proveedores
        sqlstr = "SELECT c.id_proveedor AS 'id_proveedor', c.razon_social AS 'razon_social' FROM proveedores AS c WHERE c.activo = '1' ORDER BY c.razon_social ASC"
        cargar_combo(cmb_proveedor, sqlstr, basedb, "razon_social", "id_proveedor")
        cmb_proveedor.Text = "Seleccione un proveedor..."

        pExportXLS.Enabled = False
    End Sub

    Private Sub ccProveedores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub cmd_consultar_Click(sender As Object, e As EventArgs) Handles cmd_consultar.Click
        'Dim saldo As saldoCaja
        Dim saldo As String
        Dim total As String

        If cmb_proveedor.Text = "Seleccione un proveedor..." Then
            MsgBox("El campo 'Proveedor' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_cc.Text = "Seleccione una cuenta corriente..." Then
            MsgBox("Debe elegir una cuenta corriente del proveedor seleccionado para poder realizar la consulta.", MsgBoxStyle.Exclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

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

        desde = 0
        pagina = 1

        actualizarDatagrid()

        cmd_first.Enabled = True
        cmd_prev.Enabled = True
        cmd_next.Enabled = True
        cmd_last.Enabled = True
        txt_nPage.Enabled = True
        cmd_go.Enabled = True
        pExportXLS.Enabled = True

        cmd_last_Click(Nothing, Nothing) 'Bush quiere que aparezca en la última página

        total = consultaTotalCcProveedor(cmb_proveedor.SelectedValue, fechaDesde, fechaHasta)

        lbl_total.Text = "$ " + total

        saldo = info_ccProveedor(cmb_cc.SelectedValue).saldo.ToString
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
        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        'If borrado = False Then edicion = True

        'If dg_view.Rows.Count = 0 Then Exit Sub


        'edita_pedido = InfoPedido(seleccionado)
        'PedidoAPedidoTmp(seleccionado)
        'add_pedido.ShowDialog()

        'If borrado = False Then edicion = False
        Dim p As New pedido
        p = InfoPedido(seleccionado)
        id = p.id_pedido

        frm_prnCmp.ShowDialog()
    End Sub

    Private Sub cmb_proveedor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_proveedor.SelectionChangeCommitted
        Dim sqlstr As String

        'Cargo el combo con todas las cuentas corrientes del proveedor seleccionado
        sqlstr = "SELECT cc.id_cc AS 'id_cc', cc.nombre AS 'nombre' FROM cc_proveedores AS cc WHERE cc.id_proveedor = '" + cmb_proveedor.SelectedValue.ToString + "' AND cc.activo = '1' ORDER BY cc.nombre ASC"
        cargar_combo(cmb_cc, sqlstr, basedb, "nombre", "id_cc")
        cmb_cc.Text = "Seleccione una cuenta corriente..."

        cmb_cc.Enabled = True
        Me.ActiveControl = Me.cmb_cc

        If cmb_cc.Items.Count = 1 Then
            cmb_cc.SelectedIndex = 0
            cmb_cc.Text = info_ccProveedor(cmb_cc.SelectedValue).nombre
        End If
    End Sub

    Private Sub psearch_proveedor_Click(sender As Object, e As EventArgs) Handles psearch_proveedor.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el proveedor default
        'If id = 0 Then id = id_proveedor_pedido_default
        updateform(id.ToString, cmb_proveedor)
        cmb_proveedor_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub psearch_cc_Click(sender As Object, e As EventArgs) Handles psearch_cc.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "archivoCCProveedores"
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

    Private Sub pExportXLS_Click(sender As Object, e As EventArgs) Handles pExportXLS.Click
        Dim rutaArchivo As String

        With SaveFileDialog1
            .AddExtension = True
            .CheckFileExists = False
            .CheckPathExists = True
            .Filter = "Excel Worksheets 2007 (*.xlsx)|*.xlsx"
            .DefaultExt = "xls"
            .InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            .FileName = cmb_proveedor.Text + " - " + cmb_cc.Text
            .ShowDialog()
            rutaArchivo = .FileName
            If rutaArchivo = "" Then
                MsgBox("Exportación cancelada.", vbInformation + vbOKOnly, "Centrex")
                Exit Sub
            End If
        End With

        consultaCcCliente(dgView_paraExportar, cmb_proveedor.SelectedValue, cmb_cc.SelectedValue, fechaDesde, fechaHasta, desde, nRegs, tPaginas, pagina, txt_nPage, 1)

        exportarExcel(dgView_paraExportar, rutaArchivo)
        MsgBox("Archivo exportado a: " + SaveFileDialog1.FileName, vbInformation + vbOKOnly, "Centrex")
    End Sub
    Private Sub actualizarDatagrid()
        consultaCcProveedor(dg_view, cmb_proveedor.SelectedValue, cmb_cc.SelectedValue, fechaDesde, fechaHasta, desde, nRegs, tPaginas, pagina, txt_nPage, 0)
    End Sub

    Private Sub cmd_next_Click(sender As Object, e As EventArgs) Handles cmd_next.Click
        If pagina = Math.Ceiling(nRegs / itXPage) Then Exit Sub
        desde += itXPage
        pagina += 1
        actualizarDatagrid()
    End Sub

    Private Sub cmd_prev_Click(sender As Object, e As EventArgs) Handles cmd_prev.Click
        If pagina = 1 Then Exit Sub
        desde -= itXPage
        pagina -= 1
        actualizarDatagrid()
    End Sub

    Private Sub cmd_first_Click(sender As Object, e As EventArgs) Handles cmd_first.Click
        desde = 0
        pagina = 1
        actualizarDatagrid()
    End Sub

    Private Sub cmd_last_Click(sender As Object, e As EventArgs) Handles cmd_last.Click
        pagina = tPaginas
        desde = nRegs - itXPage
        actualizarDatagrid()
    End Sub

    Private Sub cmd_go_Click(sender As Object, e As EventArgs) Handles cmd_go.Click
        pagina = txt_nPage.Text
        If pagina > tPaginas Then pagina = tPaginas
        desde = (pagina - 1) * itXPage
        actualizarDatagrid()
    End Sub
End Class