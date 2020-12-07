Public Class add_ccProveedor
    Private Sub add_ccProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        form = Me
        txt_saldo.Text = "0"
        chk_activo.Checked = True

        'Cargo el combo con todos los proveedores
        sqlstr = "SELECT p.id_proveedor AS 'id_proveedor', p.razon_social AS 'razon_social' FROM proveedores AS p WHERE p.activo = '1' ORDER BY p.razon_social ASC"
        cargar_combo(cmb_proveedor, sqlstr, basedb, "razon_social", "id_proveedor")

        'Cargo el combo con todas las monedas
        sqlstr = "SELECT id_moneda, moneda FROM sysMoneda ORDER BY moneda ASC"
        cargar_combo(cmb_moneda, sqlstr, basedb, "moneda", "id_moneda")

        If edicion Or borrado Then
            cmb_proveedor.SelectedValue = edita_ccProveedor.id_proveedor
            cmb_moneda.SelectedValue = edita_ccProveedor.id_moneda
            txt_nombre.Text = edita_ccProveedor.nombre
            txt_saldo.Text = edita_ccProveedor.saldo
            chk_activo.Checked = edita_ccProveedor.activo
            cmb_proveedor.Enabled = False 'No se puede cambiar el proveedor de una cuenta corriente dada de alta
            cmb_moneda.Enabled = False 'No se puede cambiar la moneda de una cuenta corriente ya dada de alta
            'No se puede cambiar el saldo de una cuenta corriente ya dada de alta
            'Deberá hacerse a traves de un documento de saldo inicial deudor o acreedor.
            txt_saldo.Enabled = False

            chk_secuencia.Enabled = False
        Else
            cmb_proveedor.Text = "Seleccione un Proveedor..."
            cmb_moneda.Text = "Seleccione una moneda..."
        End If

        If borrado Then
            txt_nombre.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Enabled = False
            cmd_exit.Enabled = False

            Me.Show()

            If MsgBox("¿Está seguro que desea borrar esta cuenta corriente?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If borrarccProveedor(edita_ccProveedor) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la cuenta corriente, ¿desea intetar desactivarla para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateCCProveedor(edita_ccProveedor, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la cuenta corriente no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la cuenta corriente, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la cuenta corriente.")
                        End If
                    End If
                Else
                    If info_ccProveedor(edita_ccProveedor.id_cc).nombre <> "error" Then
                        MsgBox("Cada proveedor debe tener por lo menos una cuenta corriente, y este proveedor tiene solo una, por lo cual no puede ser borrada", vbExclamation + vbOKOnly, "Centrex")
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_proveedor.Text = "Seleccione un proveedor..." Then
            MsgBox("El campo 'Proveedor' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_moneda.Text = "Seleccione una moneda..." Then
            MsgBox("El campo 'Moneda' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_nombre.Text = "" Then
            MsgBox("El campo nombre es obligatorio y está vacio.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim tmp As New ccProveedor

        tmp.id_proveedor = cmb_proveedor.SelectedValue
        tmp.id_moneda = cmb_moneda.SelectedValue
        tmp.nombre = txt_nombre.Text
        tmp.saldo = txt_saldo.Text
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_proveedor = edita_ccProveedor.id_proveedor
            tmp.id_cc = edita_ccProveedor.id_cc
            If updateCCProveedor(tmp) = False Then
                MsgBox("Hubo un problema al actualizar la cuenta corriente, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        Else
            addCCProveedor(tmp)
        End If

        If chk_secuencia.Checked Then
            cmb_proveedor.Text = "Seleccione un proveedor..."
            cmb_moneda.Text = "Seleccione una moneda..."
            txt_nombre.Text = ""
            txt_saldo.Text = "0"
            chk_activo.Checked = True
            Me.ActiveControl = Me.cmb_proveedor
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub pic_searchProveedor_Click(sender As Object, e As EventArgs) Handles pic_searchProveedor.Click
        'busqueda
        Dim tmp As String
        tmp = tabla
        tabla = "proveedores"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo, si es 0 elijo el proveedor default
        If id = 0 Then id = id_proveedor_default
        updateform(id.ToString, cmb_proveedor)
    End Sub
End Class