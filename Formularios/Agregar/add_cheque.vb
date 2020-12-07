Public Class add_cheque
    Dim id_Cliente As Integer = -1
    Dim id_Proveedor As Integer = -1
    Dim chRecibido As Boolean = True
    Dim chEmitido As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal idCliente As Integer, ByVal _idProveedor As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        id_Cliente = idCliente
        id_Proveedor = _idProveedor
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByVal _chRecibido As Boolean, ByVal _chEmitido As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        chRecibido = _chRecibido
        chEmitido = _chEmitido
    End Sub


    Private Sub Add_cheque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        cargar_combo(cmb_cliente, "SELECT id_cliente, razon_social FROM clientes WHERE activo = '1' ORDER BY razon_social ASC", basedb, "razon_social", "id_cliente")
        cargar_combo(cmb_proveedor, "SELECT id_proveedor, razon_social FROM proveedores WHERE activo = '1' ORDER BY razon_social ASC", basedb, "razon_social", "id_proveedor")
        cargar_combo(cmb_banco, "SELECT id_banco, nombre FROM bancos WHERE activo = '1' ORDER BY nombre ASC", basedb, "nombre", "id_banco")
        cargar_combo(cmb_estadoch, "SELECT id_estadoch, estado FROM sysestados_cheques ORDER BY estado ASC", basedb, "estado", "id_estadoch")
        cargar_combo(cmb_banco, "SELECT id_banco, nombre FROM bancos WHERE activo = '1' ORDER BY tipo ASC", basedb, "nombre", "id_banco")
        cargar_combo(cmb_cuentaBancaria, "SELECT cb.id_cuentaBancaria, CONCAT(b.nombre, ' - ', cb.nombre) AS nombre " &
                     "FROM cuentas_bancarias AS cb " &
                     "INNER JOIN bancos AS b  ON cb.id_banco = b.id_banco " &
                     "WHERE cb.activo = '1' " &
                     "ORDER BY tipo ASC", basedb, "nombre", "id_cuentaBancaria")

        cmb_cliente.Text = "Seleccione un cliente..."
        cmb_proveedor.Text = "Seleccione un proveedor..."

        'If chRecibido Then
        '    rb_recibido.Checked = True
        '    rb_emitido.Enabled = False
        '    'chk_depositado.Checked = False
        '    cmb_proveedor.Enabled = False
        'Else
        '    rb_emitido.Checked = True
        '    rb_recibido.Enabled = False
        '    cmb_cliente.Enabled = False
        'End If
        'rb_recibido.Checked = True


        chk_depositado.Checked = False
        cmb_banco.Text = "Seleccione un banco..."
        cmb_estadoch.Text = "Seleccione un estado..."
        cmb_estadoch.SelectedValue = 1 '1 = Cheque en cartera
        cmb_cuentaBancaria.Text = "Seleccione una cuenta bancaria..."

        If id_Cliente <> -1 Then
            cmb_cliente.SelectedValue = id_Cliente
            cmb_cliente.Enabled = False
            Exit Sub
        End If

        If id_Proveedor <> -1 Then
            cmb_proveedor.SelectedValue = id_Proveedor
            cmb_proveedor.Enabled = False
        End If

        If edicion Or borrado Then
            dtp_fIngreso.Value = DateTime.Parse(edita_cheque.fecha_ingreso)
            dtp_fEmision.Value = DateTime.Parse(edita_cheque.fecha_emision)
            If edita_cheque.id_cliente <> Nothing Then
                'Es un cheque recibido de un cliente
                rb_recibido.Checked = True
                rb_emitido.Checked = False
                cmb_cliente.SelectedValue = edita_cheque.id_cliente
                cmb_cliente.Text = info_cliente(edita_cheque.id_cliente).razon_social
            ElseIf edita_cheque.id_proveedor <> Nothing Then
                'Es un cheque emitido a un proveedor
                rb_recibido.Checked = False
                rb_emitido.Checked = True
                cmb_proveedor.SelectedValue = edita_cheque.id_proveedor
                cmb_proveedor.Text = info_proveedor(edita_cheque.id_proveedor).razon_social
            End If

            'Campos comunes a todos los cheques
            cmb_banco.SelectedValue = edita_cheque.id_banco
            txt_nCheque.Text = edita_cheque.nCheque
            txt_nCheque2.Text = edita_cheque.nCheque2
            txt_importe.Text = edita_cheque.importe
            cmb_estadoch.SelectedValue = edita_cheque.id_estadoch
            chk_eCheck.Checked = edita_cheque.eCheck

            If edita_cheque.fecha_cobro <> Nothing Then
                chk_fCobro.Checked = True
                dtp_fCobro.Value = DateTime.Parse(edita_cheque.fecha_cobro)
            End If

            If edita_cheque.fecha_salida <> Nothing Then
                chk_fSalida.Checked = True
                dtp_fSalida.Value = DateTime.Parse(edita_cheque.fecha_salida)
            End If

            If edita_cheque.fecha_deposito <> Nothing Then
                chk_fDeposito.Checked = True
                dtp_fDeposito.Value = DateTime.Parse(edita_cheque.fecha_deposito)
            End If


            If edita_cheque.id_cuentaBancaria <> Nothing Then
                chk_depositado.Checked = True
                cmb_cuentaBancaria.SelectedValue = edita_cheque.id_cuentaBancaria
            End If

            chk_secuencia.Checked = False
            chk_secuencia.Enabled = False
        Else
            If chRecibido Then
                txt_nCheque2.Text = (Ultimo_N2_Cheque() + 1).ToString
            Else
                txt_nCheque2.Text = "0"
            End If
        End If

        If borrado Then
            dtp_fEmision.Enabled = False
            rb_recibido.Enabled = False
            cmb_cliente.Enabled = False
            pic_searchCliente.Enabled = False
            rb_emitido.Enabled = False
            cmb_proveedor.Enabled = False
            pic_searchProveedor.Enabled = False
            cmb_banco.Enabled = False
            pic_searchBanco.Enabled = False
            txt_nCheque.Enabled = False
            txt_nCheque2.Enabled = False
            txt_importe.Enabled = False
            chk_eCheck.Enabled = False
            cmb_estadoch.Enabled = False
            chk_fCobro.Enabled = False
            dtp_fCobro.Enabled = False
            chk_fSalida.Enabled = False
            dtp_fSalida.Enabled = False
            chk_depositado.Enabled = False
            dtp_fDeposito.Enabled = False
            chk_depositado.Enabled = False
            cmb_cuentaBancaria.Enabled = False
            cmd_ok.Visible = False
            cmd_ok.Enabled = False
            cmd_exit.Visible = False
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este cheque?", vbYesNo + vbQuestion, "Centrex") = MsgBoxResult.Yes Then
                If (borrarch(edita_cheque)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del cheque, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatech(edita_cheque, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el cheque no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el cheque, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation + vbOKOnly, "Centrex")
                        Else
                            MsgBox("No se ha podido borrar el item, consulte con el programador", vbExclamation + vbOKOnly, "Centrex")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    'Private Sub Ch_fCobro_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fCobro.CheckedChanged
    '    dtp_fCobro.Enabled = chk_fCobro.Checked
    'End Sub

    Private Sub Ch_fSalida_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fSalida.CheckedChanged
        dtp_fSalida.Enabled = chk_fSalida.Checked
    End Sub

    Private Sub Ch_fDeposito_CheckedChanged(sender As Object, e As EventArgs) Handles chk_fDeposito.CheckedChanged
        dtp_fDeposito.Enabled = chk_fDeposito.Checked
    End Sub

    Private Sub rb_recibido_CheckedChanged(sender As Object, e As EventArgs) Handles rb_recibido.CheckedChanged
        If id_Proveedor <> -1 Then
            cmb_cliente.Enabled = rb_recibido.Checked
            Exit Sub
        End If
        cmb_cliente.Enabled = rb_recibido.Checked
        cmb_proveedor.Enabled = rb_emitido.Checked
    End Sub

    Private Sub rb_emitido_CheckedChanged(sender As Object, e As EventArgs) Handles rb_emitido.CheckedChanged
        If id_Proveedor <> -1 Then
            cmb_cliente.Enabled = rb_recibido.Checked
            Exit Sub
        End If
        cmb_cliente.Enabled = rb_recibido.Checked
        cmb_proveedor.Enabled = rb_emitido.Checked
    End Sub

    Private Sub chk_depositado_CheckedChanged(sender As Object, e As EventArgs) Handles chk_depositado.CheckedChanged
        cmb_cuentaBancaria.Enabled = chk_depositado.Checked
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim ch As New cheque

        If rb_recibido.Checked And cmb_cliente.Text = "Seleccione un cliente" Then
            MsgBox("Debe seleccionar un cliente", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf rb_emitido.Checked And cmb_proveedor.Text = "Seleccione un proveedor" Then
            MsgBox("Debe seleccionar un proveedor", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_banco.Text = "Seleccione un banco" Then
            MsgBox("Debe seleccionar un banco", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_nCheque.Text = "" Then
            MsgBox("Debe ingresar un número de cheque", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_importe.Text = "" Then
            MsgBox("Debe ingresar un importe", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_estadoch.Text = "Seleccione un estado" Then
            MsgBox("Debe seleccionar el estado del cheque", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf chk_depositado.Checked And cmb_cuentaBancaria.Text = "Seleccione una cuenta bancaria" Then
            MsgBox("Debe seleccionar la cuenta bancaria en la que se deposito el cheque", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        With ch
            .fecha_emision = dtp_fEmision.Value.Date
            If rb_recibido.Checked Then
                .id_cliente = cmb_cliente.SelectedValue
                .id_proveedor = Nothing
                .recibido = True
                .emitido = False
            ElseIf rb_emitido.Checked Then
                .id_proveedor = cmb_proveedor.SelectedValue
                .id_cliente = Nothing
                .emitido = True
                .recibido = False
            End If
            .id_banco = cmb_banco.SelectedValue
            .nCheque = txt_nCheque.Text
            .nCheque2 = txt_nCheque2.Text
            .importe = txt_importe.Text
            .eCheck = chk_eCheck.Checked
            .id_estadoch = cmb_estadoch.SelectedValue
            'If chk_fCobro.Checked Then
            .fecha_cobro = dtp_fCobro.Value.Date
            'Else
            '    .fecha_cobro = Nothing
            'End If
            If chk_fSalida.Checked Then
                .fecha_salida = dtp_fSalida.Value.Date
            Else
                '  .fecha_salida = Nothing
            End If
            If chk_fDeposito.Checked Then
                .fecha_deposito = dtp_fDeposito.Value.Date
            Else
                ' .fecha_deposito = Nothing
            End If
            If chk_depositado.Checked Then
                .id_cuentaBancaria = cmb_cuentaBancaria.SelectedValue
            Else .id_cuentaBancaria = Nothing
            End If
        End With

        If Existe_N_Cheque(ch.nCheque) Then
            MsgBox("Ya existe el cheque con el número: " & ch.nCheque & ".", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If edicion Then
            ch.id_cheque = edita_cheque.id_cheque
            If updatech(ch) = False Then
                MsgBox("Hubo un problema al actualizar el cheque, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        Else
            If addch(ch) = False Then
                MsgBox("Hubo un problema al ingresar el cheque, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        End If

        If chk_secuencia.Checked Then
            dtp_fEmision.Value = Hoy()
            txt_nCheque.Text = ""
            txt_nCheque2.Text = ""
            txt_importe.Text = ""
            chk_eCheck.Checked = False
            dtp_fCobro.Value = Hoy()
            dtp_fSalida.Value = Hoy()
            dtp_fDeposito.Value = Hoy()
            chk_fCobro.Checked = False
            chk_fSalida.Checked = False
            chk_fDeposito.Checked = False
            chk_depositado.Checked = False
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmb_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cliente.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_proveedor.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_banco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_banco.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_estadoch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_estadoch.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_cuentaBancaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_cuentaBancaria.KeyPress
        'e.KeyChar = ""
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
        'If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_cliente)
    End Sub

    Private Sub pic_searchProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchProveedor.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        'If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_proveedor)
    End Sub

    Private Sub pic_searchBanco_Click(sender As Object, e As EventArgs) Handles pic_searchBanco.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "bancos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el cliente default
        'If id = 0 Then id = id_cliente_pedido_default
        updateform(id.ToString, cmb_banco)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub txt_importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_importe.KeyPress
        If Not esNumero(e) Then
            e.KeyChar = ""
        Else
            e.KeyChar = isDecimalOk(e)
        End If
    End Sub

    Private Sub txt_nCheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nCheque.KeyPress
        'If esNumero(e) = 0 Then
        '    e.KeyChar = ""
        'End If
        esNumero(e)
    End Sub
End Class