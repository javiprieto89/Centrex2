Imports Centrex.clsgenerales

Public Class search
    Dim desde As Integer = 0
    Dim pagina As Integer = 1
    Dim nRegs As Integer
    Dim tPaginas As Integer
    Dim produccion As Boolean = False
    Dim ordenCompra As Boolean = False
    Dim comprobanteCompra As Boolean = False
    Dim id_comprobanteCompra As Integer = -1
    Dim addItem As Boolean = True
    Dim id_banco As Integer = -1

    Public Overridable Property SelectedIndex As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _produccion As Boolean, ByVal _ordenCompra As Boolean, ByVal _addItem As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        produccion = _produccion
        ordenCompra = _ordenCompra
        addItem = _addItem
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _id_banco As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id_banco = _id_banco
    End Sub

    Public Sub New(ByVal _comprobanteCompra As Boolean, ByVal _id_comprobanteCompra As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        comprobanteCompra = _comprobanteCompra
        id_comprobanteCompra = _id_comprobanteCompra
        addItem = False
    End Sub

    Private Sub search_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        form.Enabled = True
        closeandupdate(Me)
    End Sub

    Private Sub search_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        form.Enabled = True
        closeandupdate(Me)
    End Sub

    Private Sub search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String = ""

        Select Case tabla
            Case Is = "items_registros_stock"
                chk_secuencia.Visible = True
                chk_secuencia.Checked = secuencia
                sqlstr = updateDataGrid(1)
            Case Is = "items_recibidos"
                Me.Text = "Seleccione el artículo recibido"
                chk_secuencia.Visible = True
                chk_secuencia.Checked = secuencia
                sqlstr = updateDataGrid(1)
            Case Is = "pedidos"
                sqlstr = updateDataGrid(activo)
            Case Is = "cuentas_bancarias"
                sqlstr = updateDataGrid(1, id_banco)
            Case Else
                If tabla = "items_sinDescuento" Then cmd_addItem.Visible = True
                sqlstr = updateDataGrid(1)
        End Select

        'cargar_datagrid(dg_view, sqlstr, basedb)
        'desde = 0
        'pagina = 1

        cargar_datagrid(dg_view, sqlstr, basedb, desde, nRegs, tPaginas, pagina, txt_nPage, tabla, tabla_vieja) 'Carga el datagrid con los nuevos datos

        If tabla = "items" Then
            chk_secuencia.Visible = True
            'resaltarcolumna(dg_view, 4, Color.Red)
            'ElseIf tabla = "registros_stock" Then
            '    resaltarcolumna(dg_view, 4, Color.Red)
            'ElseIf tabla = "pedidos" Then
            '    resaltarcolumna(dg_view, 3, Color.Red)
            'ElseIf tabla = "casos" Then
            '    resaltarcolumna(dg_view, 9, Color.Red)
        End If
    End Sub

    Private Sub txt_search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_search.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Dim txtsearch As String = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
            Dim sqlstr As String = sqlstrbuscar(txtsearch)

            cargar_datagrid(dg_view, sqlstr, basedb)

            'If tabla = "items" Or tabla = "registros_stock" Then resaltarcolumna(dg_view, 4, Color.Red)
            dg_view.Focus()
        End If
    End Sub

    'Private Sub dg_view_ColumnClick(sender As Object, e As ColumnClickEventArgs)
    '    Me.dg_view.ListViewItemSorter = New ListViewItemComparer(e.Column)
    'End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString

        id = CInt(seleccionado)

        If tabla = "items" Or tabla = "items_sinDescuento" Or tabla = "itemsDescuentos" Then
            Dim i As New item
            edita_item = info_item(seleccionado)

            If edita_item.esDescuento Or edita_item.esMarkup Then
                'Verificar que ya haya items antes
                'addItemPedidotmp(edita_item.id_item, 1, edita_item.factor, True)
                Dim id_item As Integer
                id_item = existe_Descuento_Markup_Tmp(edita_item.id_item)
                addItemPedidotmp(edita_item, 1, edita_item.factor, id_item)
            Else
                If addItem Then
                    Dim agregaItemFrm As New infoagregaitem(produccion, ordenCompra, True)
                    agregaItemFrm.ShowDialog()
                ElseIf comprobanteCompra Then
                    Dim agregaitemfrm As New infoagregaitem(comprobanteCompra, id_comprobanteCompra)
                    agregaitem = True
                    agregaitemfrm.ShowDialog()
                    agregaitem = False
                Else
                    form.Enabled = True
                    closeandupdate(Me)
                    Exit Sub
                End If
            End If

            If chk_secuencia.Checked = True Then
                search_Load(Nothing, Nothing)
                Exit Sub
            End If
        ElseIf tabla = "conceptos_compra" And comprobanteCompra Then
            Dim frm_add_comprobantes_compras_conceptos As New add_comprobantes_compras_conceptos(id_comprobanteCompra, id)
            frm_add_comprobantes_compras_conceptos.ShowDialog()
        ElseIf tabla = "impuestos" And comprobanteCompra Then
            Dim frm_add_comprobantes_compras_impuestos As New add_comprobantes_compras_impuestos(id_comprobanteCompra, id)
            frm_add_comprobantes_compras_impuestos.ShowDialog()
        ElseIf tabla = "asocItem_Item" Then
            edita_item = info_item(seleccionado)
        End If

        secuencia = chk_secuencia.Checked 'Para el ingreso secuencial de stocks de items

        form.Enabled = True
        closeandupdate(Me)
    End Sub

    Private Sub lbl_borrarbusqueda_DoubleClick(sender As Object, e As EventArgs) Handles lbl_borrarbusqueda.DoubleClick
        txt_search.Text = ""
        Dim sqlstr As String = sqlstrbuscar("")

        cargar_datagrid(dg_view, sqlstr, basedb)
        'If tabla = "items" Or tabla = "registros_stock" Then resaltarcolumna(dg_view, 4, Color.Red)
    End Sub

    Private Sub cmd_addItem_Click(sender As Object, e As EventArgs) Handles cmd_addItem.Click
        Dim frm As Form

        frm = form
        add_item.ShowDialog()
        form = frm

        search_Load(Nothing, Nothing)
    End Sub

    Private Sub dg_view_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_view.CellDoubleClick
        cmd_ok_Click(Nothing, Nothing)
    End Sub

    Private Sub dg_view_KeyDown(sender As Object, e As KeyEventArgs) Handles dg_view.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmd_ok_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmd_next_Click(sender As Object, e As EventArgs) Handles cmd_next.Click
        If pagina = Math.Ceiling(nRegs / itXPage) Then Exit Sub
        desde += itXPage
        pagina += 1
        search_Load(Nothing, Nothing)
    End Sub

    Private Sub cmd_prev_Click(sender As Object, e As EventArgs) Handles cmd_prev.Click
        If pagina = 1 Then Exit Sub
        desde -= itXPage
        pagina -= 1
        search_Load(Nothing, Nothing)
    End Sub

    Private Sub cmd_first_Click(sender As Object, e As EventArgs) Handles cmd_first.Click
        desde = 0
        pagina = 1
        search_Load(Nothing, Nothing)
    End Sub

    Private Sub cmd_last_Click(sender As Object, e As EventArgs) Handles cmd_last.Click
        pagina = tPaginas
        desde = nRegs - itXPage
        search_Load(Nothing, Nothing)
    End Sub

    Private Sub cmd_go_Click(sender As Object, e As EventArgs) Handles cmd_go.Click
        pagina = txt_nPage.Text
        If pagina > tPaginas Then pagina = tPaginas
        desde = (pagina - 1) * itXPage
        search_Load(Nothing, Nothing)
    End Sub

    Private Sub txt_nPage_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nPage.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmd_go_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_nPage_Click(sender As Object, e As EventArgs) Handles txt_nPage.Click
        txt_nPage.Text = ""
    End Sub

    Private Sub search_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub detectaTeclas(e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            txt_search.SelectAll()
            txt_search.Select()
        End If
    End Sub

    Private Sub dg_view_KeyUp(sender As Object, e As KeyEventArgs) Handles dg_view.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_first_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_first.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_prev_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_prev.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_next_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_next.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_last_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_last.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub txt_nPage_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_nPage.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_go_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_go.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub cmd_addItem_KeyUp(sender As Object, e As KeyEventArgs) Handles cmd_addItem.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub txt_search_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_search.KeyUp
        detectaTeclas(e)
    End Sub

    Private Sub chk_secuencia_KeyUp(sender As Object, e As KeyEventArgs) Handles chk_secuencia.KeyUp
        detectaTeclas(e)
    End Sub
End Class