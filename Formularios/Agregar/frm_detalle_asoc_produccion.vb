Public Class frm_detalle_asoc_produccion
    Dim id_item As Integer
    Dim id_produccion As Integer
    Dim dt_cantidades_items_asociados As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _id_item As Integer, Optional ByVal _id_produccion As Integer = -1)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id_item = _id_item
        id_produccion = _id_produccion
    End Sub
    Private Sub frm_detalle_asoc_produccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_produccion <> -1 Then
            dt_cantidades_items_asociados = Traer_Cantidades_Enviadas_Items_Asociados_Default_Produccion(id_item, id_produccion)
            dg_view.ReadOnly = True
            cmd_ok.Enabled = False
        Else
            dt_cantidades_items_asociados = Traer_Cantidades_Enviadas_Items_Asociados_Default_Produccion(id_item)
        End If

        dg_view.DataSource = dt_cantidades_items_asociados
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        For Each row As DataRow In dt_cantidades_items_asociados.Rows
            addItemAsocProducciontmp(row.Item(4), row.Item(5), row.Item(6), row.Item(3))
        Next

        closeandupdate(Me)
    End Sub
End Class