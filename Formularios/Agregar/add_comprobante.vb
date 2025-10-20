Public Class add_comprobante

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_comprobante.Text = "" Then
            MsgBox("El campo 'Comprobante' es obligatorio y está vacio", vbOKOnly + vbExclamation, "Centrex")
            Exit Sub
        ElseIf chk_esMipyme.Checked And cmb_comprobanteRelacionado.Text = "Seleccione un comprobante asociado..." Then
            MsgBox("El campo 'Comprobant asociado' es obligatorio al ser un comprobante MiPyME y está vacio", vbOKOnly + vbExclamation, "Centrex")
            Exit Sub
        End If

        Dim c As New comprobante

        With c
            .comprobante = txt_comprobante.Text
            .id_tipoComprobante = cmb_tipoComprobante.SelectedValue
            .numeroComprobante = nup_numero.Value
            .puntoVenta = nup_puntoVenta.Value
            .esFiscal = rb_fiscal.Checked
            .esElectronica = rb_electronico.Checked
            .esManual = rb_manual.Checked
            .esPresupuesto = rb_presupuesto.Checked
            .activo = chk_activo.Checked
            .testing = chk_testing.Checked
            .maxItems = nup_maxItems.Value
            .contabilizar = chk_contabilizar.Checked
            .mueveStock = chk_mueveStock.Checked
            '.comprobanteRelacionado = cmb_comprobanteRelacionado.SelectedValue
            .esMiPyME = chk_esMipyme.Checked
            .CBU_emisor = txt_CBU_emisor.Text
            .alias_CBU_emisor = txt_alias_CBU_emisor.Text
            .id_modoMiPyme = cmb_modoMiPyme.SelectedValue
            .anula_MiPyME = txt_comprobanteAnulacion.Text
        End With

        If edicion = True Then
            c.id_comprobante = edita_comprobante.id_comprobante
            If updatecomprobante(c) = False Then
                MsgBox("Hubo un problema al actualizar el comprobante, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addcomprobante(c)
        End If

        If chk_secuencia.Checked = True Then
            txt_comprobante.Text = ""
            cmb_tipoComprobante.SelectedValue = id_tipoComprobante_default
            nup_numero.Value = 1
            nup_puntoVenta.Value = 1
            rb_electronico.Checked = True
            chk_activo.Checked = True
            chk_testing.Checked = False
            nup_maxItems.Value = 20
            'chk_esMipyme.Checked = False
            'cmb_modoMiPyme.SelectedValue = 1
            cmb_comprobanteRelacionado.Text = "Seleccione un comprobante asociado..."
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_comprobante_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_comprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todos los tipos de documentos
        cargar_combo(cmb_tipoComprobante, "SELECT id_tipoComprobante, comprobante_AFIP FROM tipos_comprobantes ORDER BY comprobante_AFIP ASC", basedb, "comprobante_AFIP", "id_tipoComprobante")
        cmb_tipoComprobante.SelectedValue = id_tipoComprobante_default

        'Cargo todos los comprobantes asociados
        ' cargar_combo(cmb_comprobanteRelacionado, "SELECT id_comprobante, comprobante FROM comprobantes ORDER BY comprobante ASC", basedb, "comprobante", "id_comprobante")
        'cmb_comprobanteRelacionado.Text = "Seleccione un comprobante asociado..."
        'cmb_comprobanteRelacionado.Enabled = False
        'cmb_comprobanteAsociado.SelectedValue = id_tipoComprobante_default

        'Cargo todos los modos de MiPyme
        cargar_combo(cmb_modoMiPyme, "SELECT id_modoMiPyme, modo FROM sys_modoMiPyme ORDER BY id_modoMiPyme ASC", basedb, "modo", "id_modoMiPyme")
        cmb_modoMiPyme.SelectedValue = 1 '1=No es MiPyme

        rb_electronico.Checked = True
        chk_activo.Checked = True

        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            With edita_comprobante
                txt_comprobante.Text = .comprobante
                cmb_tipoComprobante.SelectedValue = .id_tipoComprobante
                cmb_tipoComprobante.Enabled = False
                nup_numero.Value = .numeroComprobante
                nup_puntoVenta.Value = .puntoVenta
                rb_fiscal.Checked = .esFiscal
                rb_electronico.Checked = .esElectronica
                rb_manual.Checked = .esManual
                rb_presupuesto.Checked = .esPresupuesto
                chk_activo.Checked = .activo
                chk_testing.Checked = .testing
                nup_maxItems.Value = .maxItems
                chk_contabilizar.Checked = .contabilizar
                chk_mueveStock.Checked = .mueveStock
                chk_esMipyme.Checked = .esMiPyME
                'cmb_comprobanteRelacionado.SelectedValue = .comprobanteRelacionado
                txt_CBU_emisor.Text = .CBU_emisor
                txt_alias_CBU_emisor.Text = .alias_CBU_emisor
                cmb_modoMiPyme.SelectedValue = .id_modoMiPyme
                txt_comprobanteAnulacion.Text = .anula_MiPyME
            End With
        End If

        If borrado = True Then
            txt_comprobante.Enabled = False
            cmb_tipoComprobante.Enabled = False
            nup_numero.Enabled = False
            nup_puntoVenta.Enabled = False
            rb_fiscal.Enabled = False
            rb_electronico.Enabled = False
            rb_manual.Enabled = False
            rb_presupuesto.Enabled = False
            chk_activo.Enabled = False
            chk_testing.Enabled = False
            chk_secuencia.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            chk_contabilizar.Enabled = False
            chk_mueveStock.Enabled = False
            chk_esMipyme.Enabled = False
            'cmb_comprobanteRelacionado.Enabled = False
            txt_CBU_emisor.Enabled = False
            txt_alias_CBU_emisor.Enabled = False
            txt_comprobanteAnulacion.Enabled = False
            cmb_modoMiPyme.Enabled = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este comprobante?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarcomprobante(edita_comprobante)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del comprobante, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updatecomprobante(edita_comprobante, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el comprobante no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el comprobante, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el comprobante, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmb_tipoComprobante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_tipoComprobante.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub chk_esMipyme_CheckedChanged(sender As Object, e As EventArgs) Handles chk_esMipyme.CheckedChanged
        Dim chk As Boolean = chk_esMipyme.Checked

        'cmb_comprobanteRelacionado.Enabled = chk
        txt_CBU_emisor.Enabled = chk
        txt_alias_CBU_emisor.Enabled = chk
        txt_comprobanteAnulacion.Enabled = chk
        cmb_modoMiPyme.Enabled = chk
    End Sub
End Class