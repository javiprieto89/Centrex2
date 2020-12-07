Public Class add_cuentaBancaria
    Private Sub add_cuentaBancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        'Cargo todos los bancos
        If cargar_combo(cmb_banco, "SELECT id_banco, nombre FROM bancos ORDER BY nombre ASC", basedb, "nombre", "id_banco") = -1 Then
            MsgBox("No hay ningún banco cargado, por lo cual no podrá cargar ninguna cuenta bancaria", vbExclamation + vbOKOnly, "Centrex")
            closeandupdate(Me)
            Exit Sub
        End If

        'Cargo todas las monedas
        cargar_combo(cmb_moneda, "SELECT id_moneda, moneda FROM sysMoneda ORDER BY id_moneda ASC", basedb, "moneda", "id_moneda")

        If edicion Or borrado Then
            cmb_banco.SelectedValue = edita_cuentaBancaria.id_banco
            txt_cuentaBancaria.Text = edita_cuentaBancaria.nombre
            cmb_moneda.SelectedValue = edita_cuentaBancaria.id_moneda
        Else
            cmb_banco.Text = "Seleccione un banco..."
            cmb_moneda.Text = "Seleccione una moneda..."
        End If

        If borrado Then
            cmb_banco.Enabled = False
            txt_cuentaBancaria.Enabled = False
            cmb_moneda.Enabled = False
            cmd_ok.Enabled = False
            cmd_exit.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta cuenta bancaria?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarcuenta_Bancaria(edita_cuentaBancaria)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la cuenta, ¿desea intectar desactivarla para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatecuentaBancaria(edita_cuentaBancaria, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la cuenta no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que la cuenta, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la cuenta, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_banco.Text = "Seleccione un banco..." Then
            MsgBox("Debe seleccionar un banco.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf cmb_moneda.Text = "Seleccione una moneda..." Then
            MsgBox("Debe seleccionar una moneda", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf txt_cuentaBancaria.Text = "" Then
            MsgBox("El campo 'Descripción' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim cb As New cuenta_bancaria

        cb.id_banco = cmb_banco.SelectedValue
        cb.nombre = txt_cuentaBancaria.Text
        cb.id_moneda = cmb_moneda.SelectedValue
        cb.activo = chk_activo.Checked

        If edicion Then
            cb.id_cuentaBancaria = edita_cuentaBancaria.id_cuentaBancaria
            If Not updatecuentaBancaria(cb) Then
                MsgBox("Hubo un problema al actualizar la cuenta bancaria, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        Else
            addcuentaBancaria(cb)
        End If

        If chk_secuencia.Checked Then
            cmb_banco.SelectedValue = 1
            txt_cuentaBancaria.Text = ""
            cmb_moneda.SelectedValue = 1
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmb_banco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_banco.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_moneda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_moneda.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub psearch_banco_Click(sender As Object, e As EventArgs) Handles psearch_banco.Click
        Dim tmp As String
        tmp = tabla
        tabla = "bancos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        cmb_banco.selectedvalue = id
        'cmb_cat.SelectedIndex = id
        id = 0
    End Sub

    Private Sub add_cuentaBancaria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub
End Class