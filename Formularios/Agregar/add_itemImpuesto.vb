Public Class add_itemImpuesto

    Private Sub add_modeloa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub add_modeloa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me

        'Cargo todas los items
        cargar_combo(cmb_items, "SELECT id_item, descript FROM items ORDER BY item ASC", basedb, "descript", "id_item")
        cmb_items.Text = "Seleccione un item"

        'Cargo todos los impuestos
        cargar_combo(cmb_impuestos, "SELECT id_impuesto, nombre FROM impuestos ORDER BY nombre ASC", basedb, "nombre", "id_impuesto")
        cmb_impuestos.Text = "Seleccione un impuesto"
        
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False

            With edita_itemImpuesto
                cmb_items.SelectedValue = .id_item
                cmb_impuestos.SelectedValue = .id_impuesto
                chk_activo.Checked = .activo
            End With
        End If

        If borrado = True Then
            cmb_items.Enabled = False
            cmb_impuestos.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar esta relación?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borraritemImpuesto(edita_itemImpuesto)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado de la relación, ¿desea intectar desactivarla para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateitemImpuesto(edita_itemImpuesto, , True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero la realación no se borró definitivamente." + Chr(13) + _
                                "Esto posiblemente se deba a que el está relación, tiene operaciones realizadas y/o dependencias por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar la relación, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Dispose()
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If cmb_items.Text = "Seleccione un item" Then
            MsgBox("El campo 'Item' es obligatorio y está vacio")
            Exit Sub
        ElseIf cmb_impuestos.Text = "Seleccione un impuesto" Then
            MsgBox("El campo 'Impuestos' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New itemImpuesto
        tmp.id_item = cmb_items.SelectedValue
        tmp.id_impuesto = cmb_impuestos.SelectedValue
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            'tmp.id_item = edita_itemImpuesto.id_item
            'tmp.id_impuesto = edita_impuesto.id_impuesto
            If updateitemImpuesto(edita_itemImpuesto, tmp) = False Then
                MsgBox("Hubo un problema al actualizar la relación, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            additemImpuesto(tmp)
        End If

        If chk_secuencia.Checked = True Then
            cmb_items.Text = "Seleccione un item"
            cmb_items.Text = "Seleccione un impuesto"
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub pic_search_item_Click(sender As Object, e As EventArgs) Handles pic_search_item.DoubleClick
        Dim tmp As String
        tmp = tabla
        tabla = "itemsImpuestosItems"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        'cmb_items.SelectedIndex = cmb_items.FindString(info_item(id).descript)
        cmb_items.SelectedValue = id
        id = 0
    End Sub

    Private Sub pic_search_impuestos_Click(sender As Object, e As EventArgs) Handles pic_search_impuestos.DoubleClick
        Dim tmp As String
        tmp = tabla
        tabla = "itemsImpuestosImpuestos"
        Me.Enabled = False
        search.ShowDialog()
        tabla = tmp

        'Establezco la opción del combo
        'cmb_impuestos.SelectedIndex = cmb_impuestos.FindString(info_impuesto(id).nombre)
        cmb_impuestos.SelectedValue = id
        id = 0
    End Sub

    Private Sub cmb_items_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_items.KeyPress
        'e.KeyChar = ""
    End Sub

    Private Sub cmb_impuestos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_impuestos.KeyPress
        'e.KeyChar = ""
    End Sub
End Class