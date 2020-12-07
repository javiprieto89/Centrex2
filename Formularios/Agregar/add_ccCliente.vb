Public Class add_ccCliente
    Private Sub add_ccCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        form = Me
        txt_saldo.Text = "0"
        chk_activo.Checked = True

        'Cargo el combo con todos los clientes
        sqlstr = "SELECT c.id_cliente AS 'id_cliente', c.razon_social AS 'razon_social' FROM clientes AS c WHERE c.activo = '1' ORDER BY c.razon_social ASC"
        cargar_combo(cmb_cliente, sqlstr, basedb, "razon_social", "id_cliente")

        'Cargo el combo con todas las monedas
        sqlstr = "SELECT id_moneda, moneda FROM sysMoneda ORDER BY moneda ASC"
        cargar_combo(cmb_moneda, sqlstr, basedb, "moneda", "id_moneda")

        If edicion Or borrado Then
            cmb_cliente.SelectedValue = edita_ccCliente.id_cliente
            cmb_moneda.SelectedValue = edita_ccCliente.id_moneda
            txt_nombre.Text = edita_ccCliente.nombre
            txt_saldo.Text = edita_ccCliente.saldo
            chk_activo.Checked = edita_ccCliente.activo
            cmb_cliente.Enabled = False 'No se puede cambiar el cliente de una cuenta corriente dada de alta
            cmb_moneda.Enabled = False 'No se puede cambiar la moneda de una cuenta corriente dada de alta
            'No se puede cambiar el saldo de una cuenta corriente ya dada de alta
            'Deberá hacerse a traves de un documento de saldo inicial deudor o acreedor.
            txt_saldo.Enabled = False

            chk_secuencia.Enabled = False
        Else
            cmb_cliente.Text = "Seleccione un cliente..."
            cmb_moneda.Text = "Seleccione una moneda..."
        End If

        If borrado Then
            txt_nombre.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Enabled = False
            cmd_exit.Enabled = False

            Me.Show()

            If MsgBox("¿Está seguro que desea borrar esta cuenta corriente?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If borrarccCliente(edita_ccCliente) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la cuenta corriente, ¿desea intetar desactivarla para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateCCCliente(edita_ccCliente, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la cuenta corriente no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la cuenta corriente, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la cuenta corriente.")
                        End If
                    End If
                Else
                    If info_ccCliente(edita_ccCliente.id_cc).nombre <> "error" Then
                        MsgBox("Cada cliente debe tener por lo menos una cuenta corriente, y este cliente tiene solo una, por lo cual no puede ser borrada", vbExclamation + vbOKOnly, "Centrex")
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_cliente.Text = "Seleccione un cliente..." Then
            MsgBox("El campo 'Cliente' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_moneda.Text = "Seleccione una moneda..." Then
            MsgBox("El campo 'Moneda' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_nombre.Text = "" Then
            MsgBox("El campo nombre es obligatorio y está vacio.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim tmp As New ccCliente

        tmp.id_cliente = cmb_cliente.SelectedValue
        tmp.id_moneda = cmb_moneda.SelectedValue
        tmp.nombre = txt_nombre.Text
        tmp.saldo = txt_saldo.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_cliente = edita_ccCliente.id_cliente
            tmp.id_cc = edita_ccCliente.id_cc
            If updateCCCliente(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la cuenta corriente, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        Else
            addCCCliente(tmp)
        End If

        If chk_secuencia.Checked Then
            txt_nombre.Text = ""
            txt_saldo.Text = "0"
            chk_activo.Checked = True
            Me.ActiveControl = Me.cmb_cliente
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
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
        updateform(id.ToString, cmb_cliente)
    End Sub
End Class