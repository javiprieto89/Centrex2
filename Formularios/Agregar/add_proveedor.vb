Public Class add_proveedor
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If busquedaavanzada Then
            With edita_proveedor
                .razon_social = Trim(txt_razonSocial.Text)
                .id_claseFiscal = cmb_claseFiscal.SelectedValue
                .id_tipoDocumento = cmb_tipoDocumento.SelectedValue
                .contacto = Trim(txt_contacto.Text)
                .vendedor = Trim(txt_vendedor.Text)
                .taxNumber = txt_taxNumber.Text
                .telefono = txt_telefono.Text
                .celular = txt_celular.Text
                .email = txt_email.Text
                .id_pais_fiscal = cmb_paisFiscal.SelectedValue
                .id_provincia_fiscal = cmb_provinciaFiscal.SelectedValue
                .direccion_fiscal = txt_direccionFiscal.Text
                .localidad_fiscal = txt_localidadFiscal.Text
                .cp_fiscal = txt_cpFiscal.Text
                .id_pais_entrega = cmb_paisEntrega.SelectedValue
                .id_provincia_entrega = cmb_provinciaEntrega.SelectedValue
                .direccion_entrega = txt_direccionEntrega.Text
                .localidad_entrega = txt_localidadEntrega.Text
                .cp_entrega = txt_cpEntrega.Text
                .esInscripto = chk_esInscripto.Checked
                .activo = chk_activo.Checked
            End With
            closeandupdate(Me)
            Exit Sub
        End If

        If txt_razonSocial.Text = "" Then
            MsgBox("El campo 'Razon social' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_claseFiscal.Text = "Seleccione una clase fiscal..." Then
            MsgBox("Debe seleccionar una clase fiscal", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf (InStr(LCase(cmb_claseFiscal.Text), "indefinido") = 0 Or InStr(LCase(cmb_tipoDocumento.Text), "indefinido") = 0 Or InStr(LCase(cmb_claseFiscal.Text), "c.u.i.t.") > 0) And txt_taxNumber.Text = "" Then
            MsgBox("Debe especificar un documento o seleccionar una clase fiscal y un tipo de documento indefinido.", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        Dim p As New proveedor

        With p
            .razon_social = Trim(txt_razonSocial.Text)
            .id_claseFiscal = cmb_claseFiscal.SelectedValue
            .id_tipoDocumento = cmb_tipoDocumento.SelectedValue
            .contacto = Trim(txt_contacto.Text)
            .vendedor = Trim(txt_vendedor.Text)
            .taxNumber = txt_taxNumber.Text
            .telefono = txt_telefono.Text
            .celular = txt_celular.Text
            .email = txt_email.Text
            .id_pais_fiscal = cmb_paisFiscal.SelectedValue
            .id_provincia_fiscal = cmb_provinciaFiscal.SelectedValue
            .direccion_fiscal = txt_direccionFiscal.Text
            .localidad_fiscal = txt_localidadFiscal.Text
            .cp_fiscal = txt_cpFiscal.Text
            .id_pais_entrega = cmb_paisEntrega.SelectedValue
            .id_provincia_entrega = cmb_provinciaEntrega.SelectedValue
            If txt_direccionEntrega.Text = "" Then .direccion_entrega = txt_direccionFiscal.Text Else .direccion_entrega = txt_direccionEntrega.Text
            If txt_localidadEntrega.Text = "" Then .localidad_entrega = txt_localidadFiscal.Text Else .localidad_entrega = txt_localidadEntrega.Text
            If txt_cpEntrega.Text = "" Then .cp_entrega = txt_cpFiscal.Text Else .cp_entrega = txt_cpEntrega.Text
            .esInscripto = chk_esInscripto.Checked
            .activo = chk_activo.Checked
            .notas = txt_notas.Text
        End With

        If edicion = True Then
            p.id_proveedor = edita_proveedor.id_proveedor
            If updateProveedor(p) = False Then
                MsgBox("Hubo un problema al actualizar el proveedor, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addproveedor(p)
        End If

        If chk_secuencia.Checked = True Then
            txt_razonSocial.Text = ""
            cmb_claseFiscal.Text = "Seleccione una clase fiscal..."
            cmb_tipoDocumento.SelectedValue = id_tipoDocumento_default
            txt_taxNumber.Text = ""
            txt_contacto.Text = ""
            txt_vendedor.Text = ""
            txt_telefono.Text = ""
            txt_celular.Text = ""
            txt_email.Text = ""
            cmb_paisFiscal.SelectedValue = id_pais_default
            cmb_provinciaFiscal.SelectedValue = id_provincia_default
            txt_direccionFiscal.Text = ""
            txt_localidadFiscal.Text = ""
            txt_cpFiscal.Text = ""
            cmb_paisEntrega.SelectedValue = id_pais_default
            cmb_provinciaEntrega.SelectedValue = id_provincia_default
            txt_direccionEntrega.Text = ""
            txt_localidadEntrega.Text = ""
            txt_cpEntrega.Text = ""
            chk_esInscripto.Checked = False
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    'Private Sub txt_taxNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_taxNumber
    '    'e.Handled = valida(e.KeyChar, 2)
    'End Sub

    Private Sub add_proveedor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todos los paises de dirección fiscal
        cargar_combo(cmb_paisFiscal, "SELECT id_pais, pais FROM paises ORDER BY pais ASC", basedb, "pais", "id_pais")

        'Cargo todas las provincias de direccion fiscal
        cargar_combo(cmb_provinciaFiscal, "SELECT id_provincia, provincia FROM provincias WHERE id_pais = '" + cmb_paisFiscal.SelectedValue.ToString + "' ORDER BY provincia ASC", basedb, "provincia", "id_provincia")

        'Cargo todos los paises de dirección de entrega
        cargar_combo(cmb_paisEntrega, "SELECT id_pais, pais FROM paises ORDER BY pais ASC", basedb, "pais", "id_pais")

        'Cargo todas las provincias de direccion de entrega
        cargar_combo(cmb_provinciaEntrega, "SELECT id_provincia, provincia FROM provincias WHERE id_pais = '" + cmb_paisEntrega.SelectedValue.ToString + "' ORDER BY provincia ASC", basedb, "provincia", "id_provincia")

        'Cargo todos las clases fiscales
        cargar_combo(cmb_claseFiscal, "SELECT id_claseFiscal, descript FROM sys_ClasesFiscales ORDER BY descript ASC", basedb, "descript", "id_claseFiscal")
        cmb_claseFiscal.Text = "Seleccione una clase fiscal..."

        'Cargo todos los tipos de documentos
        cargar_combo(cmb_tipoDocumento, "SELECT id_tipoDocumento, documento FROM tipos_documentos WHERE activo = 1 ORDER BY documento ASC", basedb, "documento", "id_tipoDocumento")
        cmb_tipoDocumento.SelectedValue = id_tipoDocumento_default

        Me.ActiveControl = Me.txt_razonSocial

        If busquedaavanzada Then
            Me.Text = "Buscar proveedors"
            cmd_ok.Text = "Buscar"
            chk_secuencia.Visible = False
            chk_activo.Checked = True
            Exit Sub
        End If

        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_razonSocial.Text = edita_proveedor.razon_social
            cmb_claseFiscal.SelectedValue = edita_proveedor.id_claseFiscal
            cmb_tipoDocumento.SelectedValue = edita_proveedor.id_tipoDocumento
            txt_taxNumber.Text = edita_proveedor.taxNumber
            txt_contacto.Text = edita_proveedor.contacto
            txt_vendedor.Text = edita_proveedor.vendedor
            txt_telefono.Text = edita_proveedor.telefono
            txt_celular.Text = edita_proveedor.celular
            txt_email.Text = edita_proveedor.email
            cmb_paisFiscal.SelectedValue = edita_proveedor.id_pais_fiscal
            cmb_provinciaFiscal.SelectedValue = edita_proveedor.id_provincia_fiscal
            txt_direccionFiscal.Text = edita_proveedor.direccion_fiscal
            txt_localidadFiscal.Text = edita_proveedor.localidad_fiscal
            txt_cpFiscal.Text = edita_proveedor.cp_fiscal
            cmb_paisEntrega.SelectedValue = edita_proveedor.id_pais_entrega
            cmb_provinciaEntrega.SelectedValue = edita_proveedor.id_provincia_entrega
            txt_direccionEntrega.Text = edita_proveedor.direccion_entrega
            txt_localidadEntrega.Text = edita_proveedor.localidad_entrega
            txt_cpEntrega.Text = edita_proveedor.cp_entrega
            chk_esInscripto.Checked = edita_proveedor.esInscripto
            chk_activo.Checked = edita_proveedor.activo
            txt_notas.Text = edita_proveedor.notas
        End If

        If borrado = True Then
            txt_razonSocial.Enabled = False
            cmb_claseFiscal.Enabled = False
            cmb_tipoDocumento.Enabled = False
            txt_taxNumber.Enabled = False
            txt_contacto.Enabled = False
            txt_telefono.Enabled = False
            txt_celular.Enabled = False
            txt_email.Enabled = False
            cmb_paisFiscal.Enabled = False
            cmb_provinciaFiscal.Enabled = False
            txt_direccionFiscal.Enabled = False
            txt_localidadFiscal.Enabled = False
            txt_cpFiscal.Enabled = False
            cmb_paisEntrega.Enabled = False
            cmb_provinciaEntrega.Enabled = False
            txt_direccionEntrega.Enabled = False
            txt_localidadEntrega.Enabled = False
            txt_cpEntrega.Enabled = False
            chk_esInscripto.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este proveedor?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarproveedor(edita_proveedor)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del proveedor, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateproveedor(edita_proveedor, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el proveedor no se borró definitivamente." + Chr(13) + _
                                "Esto posiblemente se deba a que el proveedor, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el proveedor, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmb_paisFiscal_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_paisFiscal.SelectionChangeCommitted
        'Cargo todas las provincias de direccion de fiscal
        cargar_combo(cmb_provinciaFiscal, "SELECT id_provincia, provincia FROM provincias WHERE id_pais = '" + cmb_paisFiscal.SelectedValue.ToString + "' ORDER BY provincia ASC", basedb, "provincia", "id_provincia")
    End Sub

    Private Sub cmb_paisEntrega_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_paisEntrega.SelectionChangeCommitted
        'Cargo todas las provincias de direccion de entrega
        cargar_combo(cmb_provinciaEntrega, "SELECT id_provincia, provincia FROM provincias WHERE id_pais = '" + cmb_paisEntrega.SelectedValue.ToString + "' ORDER BY provincia ASC", basedb, "provincia", "id_provincia")
    End Sub

    Private Sub txt_taxNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_taxNumber.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class