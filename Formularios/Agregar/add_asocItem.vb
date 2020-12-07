Public Class add_asocItem
    Dim iAsoc As New asocItem
    Dim item As New item
    Dim asocItem As New item

    Private Sub pic_searchItem_Click(sender As Object, e As EventArgs) Handles pic_searchItem.Click
        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo
        tabla = "asocItem_Item"
        activo = True

        agregaitem = False
        Me.Enabled = False

        search.ShowDialog()
        tabla = tmpTabla
        activo = tmpActivo
        agregaitem = False

        iAsoc.id_item = edita_item.id_item
        txt_item.Text = edita_item.id_item.ToString & " - " & edita_item.item
        txt_descriptItem.Text = edita_item.descript
    End Sub

    Private Sub add_asocItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form = Me
        With iAsoc
            .id_item = -1
            .id_item_asoc = -1
            .cantidad = -99
        End With

        If edicion = True Or borrado = True Then
            'Deshabilito controles comunes 
            txt_item.Enabled = False
            txt_descriptItem.Enabled = False
            pic_searchItem.Enabled = False
            chk_secuencia.Checked = False
            chk_secuencia.Enabled = False

            item = info_item(edita_asocItem.id_item)
            asocItem = info_item(edita_asocItem.id_item_asoc)

            txt_item.Text = item.id_item.ToString & " - " & item.item
            txt_descriptItem.Text = item.descript

            txt_asocItem.Text = asocItem.id_item.ToString & " - " & asocItem.item
            txt_descriptAsocItem.Text = asocItem.descript

            txt_cantidad.Text = edita_asocItem.cantidad.ToString

            iAsoc.id_item = edita_asocItem.id_item
            iAsoc.id_item_asoc = edita_asocItem.id_item_asoc
            iAsoc.cantidad = edita_asocItem.cantidad

            If borrado Then
                txt_asocItem.Enabled = False
                txt_descriptAsocItem.Enabled = False
                txt_cantidad.Enabled = False
                cmd_ok.Enabled = False
                Me.Show()
                If MsgBox("¿Está seguro que desea borrar esta relación?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                    If (borrarAsocItem(edita_asocItem)) = False Then
                        MsgBox("No se ha podido borrar la relación de los artículos, consulte con el programador")
                    End If
                End If
                closeandupdate(Me)
            End If
        End If
    End Sub

    Private Sub pic_searchAsocItem_Click(sender As Object, e As EventArgs) Handles pic_searchAsocItem.Click
        Dim tmpTabla As String
        Dim tmpActivo As Boolean

        tmpTabla = tabla
        tmpActivo = activo
        tabla = "asocItem_Item"
        activo = True

        agregaitem = False
        Me.Enabled = False

        search.ShowDialog()
        tabla = tmpTabla
        activo = tmpActivo
        agregaitem = False

        iAsoc.id_item_asoc = edita_item.id_item
        txt_asocItem.Text = edita_item.id_item.ToString & " - " & edita_item.item
        txt_descriptAsocItem.Text = edita_item.descript
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_cantidad.Text <> "" Then iAsoc.cantidad = txt_cantidad.Text

        If iAsoc.id_item = -1 Then
            MsgBox("Debe ingresar un item al que se le asignaran el resto de los productos", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf iAsoc.id_item_asoc = -1 Then
            MsgBox("Debe ingresar un item asociado al producto maestro", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        ElseIf iAsoc.cantidad = -99 Then
            MsgBox("Debe asignar la cantidad de items que componen al producto maestro", vbExclamation + vbOKOnly, "Centrex")
            Exit Sub
        End If

        If edicion = True Then
            If updateAsocItem(iAsoc) = False Then
                MsgBox("Hubo un problema al actualizar el cliente, consulte con su programdor", vbExclamation)
                closeandupdate(Me)
            End If
        Else
            addAsocItem(iAsoc)
        End If

        If chk_secuencia.Checked = True Then
            iAsoc.id_item_asoc = -1
            iAsoc.cantidad = -99
            txt_item.Enabled = False
            txt_descriptItem.Enabled = False
            pic_searchItem.Enabled = False
            txt_asocItem.Text = ""
            txt_descriptAsocItem.Text = ""
            txt_cantidad.Text = 0
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub txt_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If esNumero(e) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub add_asocItem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub
End Class