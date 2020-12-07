Public Class infoagregarstock
    Private i As New item
    Private id_proveedor As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _id_proveedor As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id_proveedor = _id_proveedor
    End Sub
    Private Sub infoagregarstock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargar_combo(cmb_proveedor, "SELECT id_proveedor, razon_social FROM proveedores ORDER BY razon_social ASC", basedb, "razon_social", "id_proveedor")

        If editaStock Then
            psearch_item.Visible = True
        End If

        If edicion Or edicion_item_registro_stock Then
            i = info_item(edita_item_registro_stock.id_item)
            id = i.id_item

            lbl_item.Text = i.descript
            txt_fecha.Text = DateTime.Parse(edita_item_registro_stock.fecha)
            txt_factura.Text = edita_item_registro_stock.factura
            'cmb_proveedor.SelectedValue = CByte(edita_item_registro_stock.id_proveedor)
            cmb_proveedor.SelectedValue = id_proveedor
            txt_cantidad.Text = edita_item_registro_stock.cantidad
            txt_costo.Text = edita_item_registro_stock.costo
            txt_preciolista.Text = edita_item_registro_stock.precio_lista
            txt_factor.Text = edita_item_registro_stock.factor
            txt_notas.Text = edita_item_registro_stock.nota
            If edicion And Not editaStock Then
                lbl_item.Enabled = False
                txt_fecha.Enabled = False
                txt_factura.Enabled = False
                cmb_proveedor.Enabled = False
                txt_cantidad.Enabled = False
                txt_costo.Enabled = False
                txt_preciolista.Enabled = False
                txt_factor.Enabled = False
                txt_notas.Enabled = False
                cmd_ok.Text = "Aceptar"
            End If
        Else
            i = info_item(id)

            lbl_item.Text = i.descript
            txt_fecha.Text = add_stock.txt_fecha.Text
            txt_factura.Text = add_stock.txt_factura.Text
            'cmb_proveedor.SelectedValue = CByte(add_stock.cmb_proveedor.SelectedValue)
            cmb_proveedor.SelectedValue = id_proveedor

            txt_costo.Text = i.costo.ToString
            txt_preciolista.Text = i.precio_lista.ToString
            txt_factor.Text = i.factor.ToString
            txt_notas.Text = add_stock.txt_notas.Text

            'Si el item se encuentra inactivo, al agregar stock se activa
            If i.activo = False Then
                If txt_notas.Text <> "" Then
                    txt_notas.Text = txt_notas.Text & vbCrLf & "ESTE ITEM SE ENCUENTRA INACTIVO, SI AGREGA STOCK SE ACTIVARÁ"
                Else
                    txt_notas.Text = "ESTE ITEM SE ENCUENTRA INACTIVO, SI AGREGA STOCK SE ACTIVARÁ"
                End If
                i.activo = True
                updateitem(i)
            End If

        End If
        Me.ActiveControl = txt_cantidad
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If edicion Then
            closeandupdate(Me)
            Exit Sub
        End If

        Dim rs As New registro_stock

        If txt_cantidad.Text = "" Then
            MsgBox("El campo 'Cantidad' no puede estar vació", vbExclamation, "Centrex")
            Exit Sub
        ElseIf txt_cantidad.Text = "0" Then
            MsgBox("La cantidad ingresada no puede ser 0", vbExclamation, "Centrex")
            Exit Sub
        ElseIf txt_costo.Text = "" Then
            MsgBox("El campo 'Costo' no puede estar vació", vbExclamation, "Centrex")
            Exit Sub
        ElseIf txt_preciolista.Text = "" Then
            MsgBox("El campo 'Precio lista' no puede estar vació", vbExclamation, "Centrex")
            Exit Sub
        ElseIf txt_factor.Text = "" Then
            MsgBox("El campo 'Factor' no puede estar vació", vbExclamation, "Centrex")
            Exit Sub
        End If

        rs.id_item = id
        rs.fecha = txt_fecha.Text
        rs.factura = txt_factura.Text
        rs.id_proveedor = cmb_proveedor.SelectedValue
        rs.cantidad = txt_cantidad.Text
        rs.costo = txt_costo.Text
        rs.precio_lista = txt_preciolista.Text
        rs.factor = txt_factor.Text
        rs.cantidad_anterior = i.cantidad
        rs.costo_anterior = i.costo
        rs.precio_lista_anterior = i.precio_lista
        rs.factor_anterior = i.factor
        rs.nota = txt_notas.Text
        If edicion_item_registro_stock Then
            rs.id_registro = edita_item_registro_stock.id_registro
            updatestocktmp(rs)
        Else
            addstocktmp(rs)
        End If

        closeandupdate(Me)
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub txt_costo_LostFocus(sender As Object, e As EventArgs) Handles txt_costo.LostFocus
        If Not txt_costo.Text = vbNullString Then
            txt_preciolista.Text = CDbl(txt_costo.Text) * CDbl(txt_factor.Text)
        End If
    End Sub

    Private Sub txt_factor_LostFocus(sender As Object, e As EventArgs) Handles txt_factor.LostFocus
        If Not txt_costo.Text = vbNullString Then
            txt_preciolista.Text = CDbl(txt_costo.Text) * CDbl(txt_factor.Text)
        End If
    End Sub

    Private Sub psearch_item_Click(sender As Object, e As EventArgs) Handles psearch_item.Click
        Dim i As New item
        Dim tablatmp As String

        tablatmp = tabla
        tabla = "items_registros_stock"

        Me.Enabled = False
        search.ShowDialog()
        Me.Enabled = True

        If id = 0 Then Exit Sub
        i = info_item(id)

        lbl_item.Text = i.descript
        tabla = tablatmp
    End Sub
End Class