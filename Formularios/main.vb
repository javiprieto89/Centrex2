Imports Centrex.clsgenerales
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO

Public Class main
    Private ultimoComprobanteFin As Boolean
    Dim desde As Integer
    Dim pagina As Integer
    Dim nRegs As Integer
    Dim tPaginas As Integer
    Dim orderCol As ColumnClickEventArgs = Nothing

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pc As String

        pc = SystemInformation.ComputerName

        ' ******* Configuraciones inciales *******
        Dim c As New configInit
        c.leerConfig()

        comprobantePresupuesto_default = 3
        id_comprobante_default = 3 '4
        id_tipoDocumento_default = 80
        id_tipoComprobante_default = 1
        id_cliente_pedido_default = 2 '8
        id_pais_default = 1
        id_provincia_default = 1
        id_marca_default = 1
        id_proveedor_default = 1
        cuit_emisor_default = "20100906512"
        id_condicion_compra_default = 1
        archivaringresostock()
        modificacionesDB = 0
        'Carga versión de la base de datos
        versiondb = "1.0.0"
        cs = "Data Source=127.0.0.1;Initial Catalog=dbCentrex;Persist Security Info=True;User ID=sa;Password=Ladeda78"
        If pc <> "JARVIS" And pc <> "SERVTEC-06" And pc <> "CORTANA" And pc <> "SKYNET" Then
            depuracion = False
        Else
            depuracion = True
            chk_test.Visible = True
            Timer1.Enabled = False
        End If

        'If pc = "SKYNET" Then
        '    serversql = "192.168.0.100"
        'End If

        ' ******* Testeos inciales *******
        If abrirdb(serversql, basedb, usuariodb, passdb) = False Then
            MsgBox("Error al abrir la Base de datos.")
            End
        End If
        cerrardb()

        configuracion_regional.cambiarIdioma()
        ' ******* Sentencias SQL específicas que se quieran ejecutar antes de iniciar la aplicación *******
        'ejecutarSQL("SQL")
        Try
            Dim di As DirectoryInfo = New DirectoryInfo("..\..\ScriptsDB")
            Dim fileReader As String
            Dim archivo As String
            Dim nuevoArchivo As String
            For Each fi In di.GetFiles()
                archivo = fi.DirectoryName + "\" + fi.Name
                nuevoArchivo = archivo.Substring(0, archivo.Length - 4) + ".jav"
                If Path.GetExtension(archivo) = ".txt" Then
                    fileReader = My.Computer.FileSystem.ReadAllText(archivo)
                    ejecutarSQL(fileReader)
                    Rename(archivo, nuevoArchivo)
                End If
            Next
        Catch ex As Exception
            MsgBox("Ocurrió un error al ejecutar procesos de actualización de la base de datos" & vbNewLine &
                   "Hablé con el programador" & vbNewLine & "Se recomienda no continuar usando el sistema hasta que esta situación se corrija" & vbNewLine &
                   vbNewLine & "Error: " & ex.Message.ToString, vbCritical + vbOKOnly, "Computron")
        End Try
        ' ******* Sentencias SQL específicas que se quieran ejecutar antes de iniciar la aplicación *******

        If modificacionesDB And Not pc = "JARVIS" Then
            MsgBox("Se deben hacer modificaciones mayores a la base de datos para que se ajuste a la última versión del programa." & Chr(13) _
                           + "Avisele al programador, ya que puede ser que el programa no corra correctamente sin estas modificaciones", vbInformation + vbOKOnly, "Centrex")
        End If

        Control.CheckForIllegalCrossThreadCalls = False
        ' ******* Configuraciones inciales *******
        cerrardb()
        borrartbl("tmpcobros_retenciones")
        borrartbl("tmptransferencias")
        borrartbl("tmppedidos_items")
        borrar_comprobantes_compras_activos()
        'borrartbl("tmpproduccion_asocItems")
        'borrartbl("tmpproduccion_items", True)
        borrarTmpProduccion()
        borrartbl("tmpOC_items")

        If haycambios() Then
            frmCambios.ShowDialog()
        End If

        cmd_add.Enabled = False
        dg_view.Visible = False
        txt_search.Enabled = False
        lbl_borrarbusqueda.Enabled = False
        chk_historicos.Enabled = False

        With My.Application.Info.Version
            tss_version.Text = "Versión: " & .Major & "." & .Minor & "." & .Revision
            tss_dbInfo.Text = "ServerSQL: " & serversql & " - DB: " & basedb & " - Ver.DB: " & versiondb
        End With
        tss_hora.Text = "Hora: " & DateAndTime.TimeOfDay

        'Treev.ExpandAll()
        'Treev.ExpandAll()
        'Expando las ramas principales {0,1,3,4}
        Dim ramas = New Integer() {0, 1, 3, 4}
        With Treev
            .SelectedNode = Treev.Nodes(0)
            .SelectedNode.Expand()
            For Each rama As Integer In ramas
                .SelectedNode = Treev.Nodes(0).Nodes(rama)
                .SelectedNode.Expand()
            Next
        End With
    End Sub

    Private Sub Treev_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Treev.NodeMouseClick
        Dim selectedNode As TreeNode

        If e.Button = Windows.Forms.MouseButtons.Left Then
            selectedNode = Me.Treev.Nodes.Find(e.Node.Name, True)(0)
            'If selectedNode.IsExpanded Then
            '    selectedNode.Collapse()
            'Else
            '    selectedNode.Expand()
            'End If

            If cmd_add.Enabled = False Then
                cmd_add.Enabled = True
                dg_view.Visible = True
                txt_search.Enabled = True
                lbl_borrarbusqueda.Enabled = True
                chk_historicos.Enabled = True
                pic.Visible = False
            End If

            tabla_vieja = tabla
            tabla = e.Node.Name
            txt_search.Text = ""
            chk_historicos.Checked = False

            desde = 0
            pagina = 1

            actualizarDatagrid()

            cmd_first.Enabled = True
            cmd_prev.Enabled = True
            cmd_next.Enabled = True
            cmd_last.Enabled = True
            txt_nPage.Enabled = True
            cmd_go.Enabled = True
        End If
    End Sub

    Private Sub actualizarDatagrid()
        Dim sqlstr As String = ""

        If txt_search.Text <> "" Then
            Dim txtsearch As String = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
            sqlstr = sqlstrbuscar(txtsearch)
        Else
            Select Case tabla
                Case Is = "root"
                    cmd_add.Enabled = False
                    dg_view.Visible = False
                    txt_search.Enabled = False
                    lbl_borrarbusqueda.Enabled = False
                    chk_historicos.Enabled = False
                    pic.Visible = True
                ' Case Is = "archivos"
                'dg_view.Rows.Clear()
                Case Is = "depositarCH"
                    frm_depositarCH.ShowDialog()
                Case Is = "rechazarCH"
                    frm_rechazarCH.ShowDialog()
                Case Is = "ccProveedores"
                    infoccProveedores.ShowDialog()
                Case Is = "ccClientes"
                    infoccClientes.ShowDialog()
                Case Is = "ultimoComprobante"
                    'frm_ultimo_comprobante.ShowDialog()
                    BackgroundWorker1.RunWorkerAsync()
                    Exit Sub
                Case Else
                    sqlstr = updateDataGrid(activo)
            End Select
        End If

        'If sqlstr = "error" Then
        'MsgBox("Ha ocurrido un error, consulte con el programdor", vbOKOnly + vbAbort, "Computron")
        If sqlstr <> "" And sqlstr <> "error" Then
            cargar_datagrid(dg_view, sqlstr, basedb, desde, nRegs, tPaginas, pagina, txt_nPage, tabla, tabla_vieja) 'Carga el datagrid con los nuevos datos
            If tabla = "archivoConsultas" Then
                dg_view.Columns(0).Width = 50
            End If
            'If tabla = "items" Then
            '    'resaltarColumna(dg_view, 4, Color.Red)
            'ElseIf tabla = "registros_stock" Then
            '    'resaltarColumna(dg_view, 7, Color.Red)
            'ElseIf tabla = "pedidos" Then
            '    'resaltarColumna(dg_view, 3, Color.Red)
            'End If
        End If
        'cargar_datagrid(dg_view, "SELECT id_cliente, activo FROM clientes", basedb)

    End Sub

    Private Sub txt_search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_search.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Dim txtsearch As String = Microsoft.VisualBasic.Replace(txt_search.Text, " ", "%")
            Dim sqlstr As String = sqlstrbuscar(txtsearch)

            cargar_datagrid(dg_view, sqlstr, basedb)
            'If tabla = "items" Then resaltarcolumna(dg_view, 4, Color.Red)
        End If
    End Sub

    Private Sub cmd_add_Click(sender As Object, e As EventArgs) Handles cmd_add.Click
        Select Case tabla
            Case Is = "clientes"
                add_cliente.ShowDialog()
            Case Is = "archivoCCClientes"
                add_ccCliente.ShowDialog()
            Case Is = "proveedores"
                add_proveedor.ShowDialog()
            Case Is = "archivoCCProveedores"
                add_ccProveedor.ShowDialog()
            Case Is = "tipos_items"
                add_tipoitem.ShowDialog()
            Case Is = "marcas_items"
                add_marcai.ShowDialog()
            Case Is = "items"
                add_item.ShowDialog()
            Case Is = "asocItems"
                add_asocItem.ShowDialog()
            Case Is = "comprobantes"
                add_comprobante.ShowDialog()
            Case Is = "archivoconsultas"
                add_consulta.ShowDialog()
            Case Is = "caja"
                add_caja.ShowDialog()
            Case Is = "bancos"
                add_banco.ShowDialog()
            Case Is = "cuentas_bancarias"
                add_cuentaBancaria.ShowDialog()
            Case Is = "chRecibidos"
                Dim addCheque As New add_cheque(True, False)
                addCheque.ShowDialog()
                'add_cheque.ShowDialog()
            Case Is = "chEmitidos"
                Dim addCheque As New add_cheque(False, True)
                addCheque.ShowDialog()
                'add_cheque.ShowDialog()
            Case Is = "chCartera"
                add_cheque.ShowDialog()
            Case Is = "impuestos"
                add_impuesto.ShowDialog()
            Case Is = "condiciones_venta"
                add_condicion_venta.ShowDialog()
            Case Is = "condiciones_compra"
                add_condicion_compra.ShowDialog()
            Case Is = "conceptos_compra"
                add_concepto_compra.ShowDialog()
            Case Is = "itemsImpuestos"
                add_itemImpuesto.ShowDialog()
            Case Is = "ordenesCompras"
                add_ordenCompra.ShowDialog()
            Case Is = "comprobantes_compras"
                add_comprobantes_compras.ShowDialog()
            Case Is = "pagos"
                add_pago.ShowDialog()
            Case Is = "ajustes_stock"
                tabla = "ajustes_stock"
                add_ajuste_stock.ShowDialog()
            Case Is = "registros_stock"
                tabla = "items_registros_stock"
                add_stock.ShowDialog()
                tabla = "registros_stock"
            Case Is = "produccion"
                add_produccion.ShowDialog()
            Case Is = "pedidos"
                add_pedido.ShowDialog()
            Case Is = "cobros"
                add_cobro.ShowDialog()
            Case Is = "cpersonalizadas"
                grilla_resultados.ShowDialog()
        End Select
        actualizarDatagrid()
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        dg_view_CellMouseDoubleClick(Nothing, Nothing)
        actualizarDatagrid()
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarToolStripMenuItem.Click
        'borrar el item
        borrado = True
        dg_view_CellMouseDoubleClick(Nothing, Nothing)
        borrado = False
        actualizarDatagrid()
    End Sub

    Private Sub dg_view_MouseDown(sender As Object, e As MouseEventArgs) Handles dg_view.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.dg_view
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With

            '2, 4 y 5 pedidos
            cmsGeneral.Items(2).Visible = False
            cmsGeneral.Items(4).Visible = False
            cmsGeneral.Items(5).Visible = False

            If chk_historicos.Checked Then
                If tabla = "pedidos" Then
                    cmsGeneral.Items(0).Text = "Ver pedido"
                    cmsGeneral.Items(4).Visible = True
                    cmsGeneral.Items(5).Visible = True
                ElseIf tabla = "registros_stock" Then
                    cmsGeneral.Items(0).Text = "Ver ingreso"
                ElseIf tabla = "items" Then
                    cmsGeneral.Items(3).Text = "Activar item"
                    cmsGeneral.Items(3).Visible = True
                    Exit Sub
                Else
                    cmsGeneral.Items(3).Visible = False
                    Exit Sub
                End If
                cmsGeneral.Items(1).Visible = False
            Else
                If tabla = "registros_stock" Then
                    cmsGeneral.Items(0).Text = "Ver ingreso"
                    cmsGeneral.Items(1).Visible = False
                    cmsGeneral.Items(7).Visible = True
                Else
                    cmsGeneral.Items(0).Text = "Editar"
                    cmsGeneral.Items(1).Visible = True
                    If tabla = "items" Then
                        cmsGeneral.Items(3).Text = "Desactivar item"
                        cmsGeneral.Items(3).Visible = True
                    Else
                        cmsGeneral.Items(3).Visible = False
                    End If
                End If
            End If

            If tabla = "pedidos" Then
                cmsGeneral.Items(2).Visible = True
            End If

            If tabla = "pagos" Or tabla = "cobros" Then
                cmsGeneral.Items(1).Text = "Anular"
                cmsGeneral.Items(0).Visible = False
            Else
                cmsGeneral.Items(1).Text = "Borrar"
                cmsGeneral.Items(0).Visible = True
            End If
        End If

        cmsGeneral.Items(0).Visible = False 'No quiere ver la opción de editar en ningún menú
        cmsGeneral.Items(2).Visible = False 'No quiere ver la opción de cerrar pedido
    End Sub

    Private Sub chk_historicos_CheckedChanged(sender As Object, e As EventArgs) Handles chk_historicos.CheckedChanged
        If activo Then
            activo = False
        Else
            activo = True
        End If
        cmd_add.Enabled = activo
        actualizarDatagrid()
    End Sub

    Private Sub TerminarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminarPedidoToolStripMenuItem.Click
        If MsgBox("¿Está seguro de que desea cerrar el pedido?", vbYesNo + vbQuestion, "Centrex") = MsgBoxResult.Yes Then
            Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
            Dim p As New pedido
            'p.id_pedido = seleccionado
            p = info_pedido(seleccionado)
            cerrarPedido(p, p.esPresupuesto, True)
        End If
        actualizarDatagrid()
    End Sub

    Private Sub lbl_borrarbusqueda_DoubleClick(sender As Object, e As EventArgs) Handles lbl_borrarbusqueda.DoubleClick
        txt_search.Text = ""
        actualizarDatagrid()
    End Sub

    Private Sub cmd_pedido_Click(sender As Object, e As EventArgs) Handles cmd_pedido.Click
        add_pedido.ShowDialog()
        'Treev.SelectedNode = Treev.Nodes("root").Nodes("ventas").Nodes("pedidos")
        'tabla = "pedidos"
        actualizarDatagrid()
    End Sub

    Private Sub cmd_addcliente_Click(sender As Object, e As EventArgs) Handles cmd_addcliente.Click
        add_cliente.ShowDialog()
        actualizarDatagrid()
    End Sub

    Private Sub DeshabilitarItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshabilitarItemToolStripMenuItem.Click
        'Desactivar/activar item
        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        Dim i As New item
        i = info_item(seleccionado)

        If chk_historicos.Checked Then
            i.activo = True   'Activo
        Else
            i.activo = False 'Desactivo
        End If

        updateitem(i)
        actualizarDatagrid()
    End Sub

    Private Sub chk_rpt_CheckedChanged(sender As Object, e As EventArgs) Handles chk_rpt.CheckedChanged
        showrpt = chk_rpt.Checked
    End Sub

    Private Sub MostrarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarFacturaToolStripMenuItem.Click
        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        'Dim p As New pedido
        'p = info_pedido(seleccionado)
        'id = p.id_pedido

        'frm_prnCmp.ShowDialog()
        edicion = True
        edita_pedido = info_pedido(seleccionado)
        pedido_a_pedidoTmp(seleccionado)
        add_pedido.ShowDialog()
        edicion = False
    End Sub

    Private Sub DuplicarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicarPedidoToolStripMenuItem.Click
        Dim sqlstr As String = ""
        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        Dim p As New pedido
        p = info_pedido(seleccionado)
        id = p.id_pedido
        duplicarPedido(id)
        Treev.SelectedNode = Treev.Nodes("root").Nodes("ventas").Nodes("pedidos")
        chk_historicos.Checked = False
        actualizarDatagrid()
        edita_pedido = info_pedido()
        pedido_a_pedidoTmp(edita_pedido.id_pedido)
        edicion = True
        add_pedido.ShowDialog()
        edicion = False
    End Sub

    Private Sub dg_view_ColumnDividerDoubleClick(sender As Object, e As DataGridViewColumnDividerDoubleClickEventArgs) Handles dg_view.ColumnDividerDoubleClick
        If e.Button = MouseButtons.Left Then
            dg_view.AutoResizeColumn(e.ColumnIndex, DataGridViewAutoSizeColumnMode.DisplayedCells)
        End If
    End Sub

    Private Sub ActualizaciónMasivaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizaciónMasivaDePreciosToolStripMenuItem.Click
        edita_precios.ShowDialog()
    End Sub

    Private Sub Treev_MouseClick(sender As Object, e As MouseEventArgs) Handles Treev.MouseClick
        cmsPreciosMasivo.Visible = False
        If Treev.SelectedNode.Name = "items" And e.Button = Windows.Forms.MouseButtons.Right Then
            Treev.ContextMenuStrip = Me.cmsPreciosMasivo
        Else
            Treev.ContextMenuStrip = Nothing
        End If
    End Sub

    Private Sub main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dim pc As String
        pc = SystemInformation.ComputerName

        If pc <> "JARVIS" And pc <> "SERVTEC-06" And pc <> "CORTANA" And Not depuracion Then
            'If MsgBox("¿Desea realizar un backup de la base de datos?", vbYesNo + vbQuestion, "Centrex") = MsgBoxResult.Yes Then
            BackupDB.ShowDialog()
            'Else
            '   MsgBox("Recuerde realizar un backup de la base de datos periodicamente", vbExclamation, "Centrex")
            'End If
        End If
        If modificacionesDB And Not SystemInformation.ComputerName = "JARVIS" Then
            MsgBox("Se deben hacer modificaciones mayores a la base de datos para que se ajuste a la última versión del programa." & Chr(13) _
           + "Avisele al programador, ya que puede ser que el programa no corra correctamente sin estas modificaciones", vbInformation + vbOKOnly, "Centrex")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'tss_hora.Text = "Hora: " & Hour() & ":" & Minute() & ":" & Second()
        tss_hora.Text = "Hora: " & DateAndTime.TimeOfDay
        'Timer1.Enabled = False
    End Sub

    Private Sub dg_view_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dg_view.CellMouseDoubleClick
        If borrado = False Then edicion = True

        If dg_view.Rows.Count = 0 Then Exit Sub

        Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        Select Case tabla
            Case "clientes"
                edita_cliente = info_cliente(seleccionado)
                add_cliente.ShowDialog()
            Case "archivoCCClientes"
                edita_ccCliente = info_ccCliente(seleccionado)
                add_ccCliente.ShowDialog()
            Case "archivoCCProveedores"
                edita_ccProveedor = info_ccProveedor(seleccionado)
                add_ccProveedor.ShowDialog()
            Case "proveedores"
                edita_proveedor = info_proveedor(seleccionado)
                add_proveedor.ShowDialog()
            Case "tipos_items"
                edita_tipoitem = info_tipoitem(seleccionado)
                add_tipoitem.ShowDialog()
            Case "marcas_items"
                edita_marcai = info_marcai(seleccionado)
                add_marcai.ShowDialog()
            Case "items"
                edita_item = info_item(seleccionado)
                add_item.ShowDialog()
            Case "asocItems"
                Dim id_item As String
                Dim id_asocItem As String
                Dim separador As Integer
                Dim largo As Integer

                separador = InStr(seleccionado, "-")
                largo = seleccionado.Length

                id_item = Trim(Microsoft.VisualBasic.Left(seleccionado, (separador - 1)))
                id_asocItem = Trim(Microsoft.VisualBasic.Right(seleccionado, (largo - separador)))

                edita_asocItem = info_asocItem(id_item, id_asocItem)
                add_asocItem.ShowDialog()
            Case "comprobantes"
                edita_comprobante = info_comprobante(seleccionado)
                add_comprobante.ShowDialog()
            Case "archivoconsultas"
                edita_consulta = info_consulta(seleccionado)
                add_consulta.ShowDialog()
            Case "caja"
                edita_caja = info_caja(seleccionado)
                add_caja.ShowDialog()
            Case "bancos"
                edita_banco = info_banco(seleccionado)
                add_banco.ShowDialog()
            Case "cuentas_bancarias"
                edita_cuentaBancaria = info_cuentaBancaria(seleccionado)
                add_cuentaBancaria.ShowDialog()
            Case "chRecibidos"
                edita_cheque = info_cheque(seleccionado)
                add_cheque.ShowDialog()
            Case "chEmitidos"
                edita_cheque = info_cheque(seleccionado)
                add_cheque.ShowDialog()
            Case "chCartera"
                edita_cheque = info_cheque(seleccionado)
                add_cheque.ShowDialog()
            Case "impuestos"
                edita_impuesto = info_impuesto(seleccionado)
                add_impuesto.ShowDialog()
            Case "condiciones_venta"
                edita_condicion_venta = info_condicion_venta(seleccionado)
                add_condicion_venta.ShowDialog()
            Case "condiciones_compra"
                edita_condicion_compra = info_condicion_compra(seleccionado)
                add_condicion_compra.ShowDialog()
            Case "conceptos_compra"
                edita_concepto_compra = info_concepto_compra(seleccionado)
                add_concepto_compra.ShowDialog()
            Case "comprobantes_compras"
                MsgBox("Los comprobantes de compras no pueden editarse, si desea corregir algo debera anularlo y cargarlo nuevamente.", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            Case "itemsImpuestos"
                Dim id_item As String
                Dim id_impuesto As String
                Dim separador As Integer
                Dim largo As Integer

                separador = InStr(seleccionado, "-")
                largo = seleccionado.Length

                id_item = Trim(Microsoft.VisualBasic.Left(seleccionado, (separador - 1)))
                id_impuesto = Trim(Microsoft.VisualBasic.Right(seleccionado, (largo - separador)))


                edita_itemImpuesto = info_itemImpuesto(id_item, id_impuesto)
                add_itemImpuesto.ShowDialog()
            Case "pagos"
                MsgBox("Los pagos no pueden editarse, si desea corregir algo debera anularlo y cargarlo nuevamente.", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            Case "registros_stock"
                edita_registro_stock = info_registro_stock(seleccionado)
                add_stock.ShowDialog()
            Case "produccion"
                'borrartbl("tmpproduccion_items", True)
                borrarTmpProduccion()
                edita_produccion = info_produccion(seleccionado)
                produccion_a_produccionTmp(seleccionado)
                add_produccion.ShowDialog()
            Case "pedidos"
                If chk_historicos.Checked Then
                    'Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
                    Dim p As New pedido
                    p = info_pedido(seleccionado)
                    id = p.id_pedido

                    frm_prnCmp.ShowDialog()
                Else
                    edita_pedido = info_pedido(seleccionado)
                    pedido_a_pedidoTmp(seleccionado)
                    add_pedido.ShowDialog()
                End If
            Case "cobros"
                'edita_cobro = info_cobro(seleccionado)
                'add_cobro.ShowDialog()
                MsgBox("Los cobros no pueden editarse, si desea corregir algo debera borrarlo y cargarlo nuevamente.", vbExclamation + vbOKOnly, "Centrex")
                Exit Sub
            Case "ordenesCompras"
                edita_ordenCompra = info_ordenCompra(seleccionado)

                add_ordenCompra.ShowDialog()
        End Select
        If borrado = False Then edicion = False

        If tabla <> "pedidos" Then
            actualizarDatagrid()
        ElseIf tabla = "pedidos" And activo Then
            actualizarDatagrid()
        End If
    End Sub

    Private Sub chk_test_CheckedChanged(sender As Object, e As EventArgs) Handles chk_test.CheckedChanged
        If chk_test.Checked Then
            depuracion = True
            basedb = "dbCentrexTest"
        Else
            depuracion = False
            basedb = "dbCentrex"
        End If
        actualizarDatagrid()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim sqlstr As String
        Me.Cursor = Cursors.WaitCursor

        Treev.Enabled = False
        txt_search.Enabled = False
        dg_view.Enabled = False
        cmd_add.Enabled = False
        cmd_pedido.Enabled = False
        cmd_addcliente.Enabled = False
        pic_search.Enabled = False
        pic.Enabled = False
        chk_historicos.Enabled = False
        chk_rpt.Enabled = False
        chk_test.Enabled = False

        sqlstr = "SELECT c.id_comprobante, c.comprobante, c.id_tipoComprobante, c.puntoVenta , c.testing, c.esElectronica " &
                            "FROM comprobantes AS c " &
                            "WHERE c.activo = '1' AND c.id_tipoComprobante NOT IN (0, 99, 199) AND c.esElectronica = '1' " &
                            "ORDER BY c.testing ASC, c.comprobante ASC"
        '"WHERE c.activo = '1' AND c.id_tipoComprobante NOT IN (0, 99, 199) AND c.esElectronica = '1' AND c.testing = '0' " &
        Dim dtUltimoComprobante As New DataTable
        abrirdb(serversql, basedb, usuariodb, passdb)
        Dim da As New SqlDataAdapter
        da = New SqlDataAdapter(sqlstr, CN)
        da.Fill(dtUltimoComprobante)
        cerrardb()


        Dim comprobante As String
        Dim puntoVenta As Integer
        Dim tipoComprobante As Integer
        Dim ultimoComprobante As Integer
        Dim esTest As Boolean
        Dim dt As New DataTable
        dt.Columns.Add("Comprobante")
        dt.Columns.Add("Punto de venta")
        dt.Columns.Add("Último comprobante")

        For Each row As DataRow In dtUltimoComprobante.Rows
            comprobante = row("comprobante")
            puntoVenta = row("puntoVenta")
            tipoComprobante = row("id_tipoComprobante")
            esTest = row("testing")
            ultimoComprobante = consultaUltimoComprobante(puntoVenta, tipoComprobante, esTest)
            dt.Rows.Add(New Object() {comprobante, puntoVenta, ultimoComprobante})
        Next

        dg_view.DataSource = dt
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ultimoComprobanteFin = True


        Treev.Enabled = True
        txt_search.Enabled = True
        dg_view.Enabled = True
        cmd_add.Enabled = True
        cmd_pedido.Enabled = True
        cmd_addcliente.Enabled = True
        pic_search.Enabled = True
        pic.Enabled = True
        chk_historicos.Enabled = True
        chk_rpt.Enabled = True
        chk_test.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarInformaciónDeAFIPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarInformaciónDeAFIPToolStripMenuItem.Click
        Dim fe As New WSAFIPFE.Factura
        Dim r As Boolean
        'Dim c As New comprobante
        'Dim seleccionado As String = dg_view.CurrentRow.Cells(0).Value.ToString
        'Dim modo As String
        'Dim cuit_emisor As String
        'Dim archivo_certificado As String
        'Dim archivo_licencia As String
        'Dim password_certificado As String
        'Dim resultadoTicket As Boolean

        'edita_pedido = info_pedido(seleccionado)
        'c = info_comprobante(edita_pedido.id_comprobante)

        'modo = WSAFIPFE.Factura.modoFiscal.Test
        'cuit_emisor = cuit_emisor_default
        'archivo_certificado = "Q:\J@V!\Docs\Dropbox\_Development\Centrex 2.0\Certificados\JARVIS20171211.pfx"
        'archivo_licencia = "Q:\J@V!\Docs\Dropbox\_Development\Centrex 2.0\Certificados\WSAFIPFE.lic"
        'password_certificado = "Ladeda78"

        'If fe.iniciar(modo, cuit_emisor, archivo_certificado, archivo_licencia) Then
        '    fe.ArchivoCertificadoPassword = password_certificado

        '    If Not fe.f1TicketEsValido Then
        '        resultadoTicket = fe.f1ObtenerTicketAcceso()
        '        If Not resultadoTicket Then
        '            MsgBox(errorFE(fe, c) & vbCr & vbCr &
        '                           "Error al obtener el ticket de acceso, PROBLEMA DE AFIP")
        '            'Return 0
        '            'Exit Function
        '        End If
        '    Else
        '        resultadoTicket = True
        '    End If

        '    If resultadoTicket Then
        '        'r = fe.F1CompConsultar(edita_pedido.puntoVenta, c.id_tipoComprobante, edita_pedido.numeroComprobante)
        '        r = fe.F1CompConsultar("2", "1", "23")
        '    End If
        'End If

        'r = fe.F1CompConsultar(edita_pedido.puntoVenta, c.id_tipoComprobante, edita_pedido.numeroComprobante)
        r = fe.F1CompConsultar("2", "1", "23")
        MsgBox(r)
    End Sub

    Private Function errorFE(ByVal fe As WSAFIPFE.Factura, ByVal c As comprobante) As String
        Dim errorStr As String
        errorStr = "El número del último comprobante autorizado para: " + c.comprobante + " es: " + fe.F1CompUltimoAutorizado(c.puntoVenta, c.id_tipoComprobante).ToString
        errorStr += vbCr + "resultado global AFIP: " + fe.F1RespuestaResultado
        errorStr += vbCr + "es reproceso? " + fe.F1RespuestaReProceso
        errorStr += vbCr + "registros procesados por AFIP: " + Str(fe.F1RespuestaCantidadReg)
        errorStr += vbCr + "error genérico global:" + fe.f1ErrorMsg1
        Return errorStr
    End Function

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

    Private Sub txt_nPage_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nPage.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmd_go_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_nPage_Click(sender As Object, e As EventArgs) Handles txt_nPage.Click
        txt_nPage.Text = ""
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frm_prnReportes("rpt_reciboCobro", "datos_empresa", "SP_cobro_cabecera", "SP_detalle_cobros_cheques", "SP_detalle_cobros_transferencias",
                                       "sp_detalle_cobros_retenciones", "DataSetFC_empresa", "DS_Cobro_Cabecera", "DS_Detalle_Cobro_Cheques",
                                       "DS_Detalle_Cobro_Transferencias", "DS_Detalle_Cobro_Retenciones", 6, True)
        frm.ShowDialog()
    End Sub
End Class