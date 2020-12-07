Public Class add_banco
    Private Sub add_banco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todos los paises
        cargar_combo(cmb_pais, "SELECT id_pais, pais FROM paises ORDER BY pais ASC", basedb, "pais", "id_pais")

        If edicion Or borrado Then
            txt_nombre.Text = edita_banco.nombre
            cmb_pais.SelectedValue = edita_banco.id_pais
            txt_bancoN.Text = edita_banco.n_banco
            chk_activo.Checked = edita_banco.activo

            chk_secuencia.Enabled = False
        End If

        If borrado Then
            txt_nombre.Enabled = False
            cmb_pais.Enabled = False
            txt_bancoN.Enabled = False
            chk_activo.Enabled = False

            chk_secuencia.Enabled = False
            cmd_ok.Enabled = False
            cmd_exit.Enabled = False
        End If

    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_nombre.Text = "" Then
            MsgBox("El campo 'Nombre' es obligatorio y está vacio", vbExclamation + vbOKOnly, "Centrext")
            Exit Sub
        End If

        Dim b As New banco

        b.nombre = txt_nombre.Text
        b.id_pais = cmb_pais.SelectedValue
        b.n_banco = Val(txt_bancoN.Text)
        b.activo = chk_activo.Checked

        If edicion Then
            b.id_banco = edita_banco.id_banco
            If Not updatebanco(b) Then
                MsgBox("Hubo un problema al actualizar el banco, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        Else
            addbanco(b)
        End If

        If chk_secuencia.Checked Then
            txt_nombre.Text = ""
            cmb_pais.SelectedValue = 1
            txt_bancoN.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub cmb_pais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_pais.KeyPress
        'e.KeyChar = ""
    End Sub
End Class