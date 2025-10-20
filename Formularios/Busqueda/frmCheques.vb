Public Class frmCheques
    Private cl As New cliente
    Private pr As New proveedor
    Private c As New cobro
    Private cliente As Boolean = False

    Public Sub New(Optional ByVal idCliente As Integer = -1, Optional ByVal idProveedor As Integer = -1, Optional ByVal idCobro As Integer = -1)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If idCliente <> -1 Then
            cl = info_cliente(idCliente)
            cliente = True
        Else
            pr = info_proveedor(idProveedor)
        End If

        If idCobro <> -1 Then
            c = info_cobro(idCobro)
        End If
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub frmCheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String

        sqlstr = "INSERT INTO tmpSelCH (id_cheque) SELECT id_cheque FROM cheques WHERE id_cliente = '" + cl.id_cliente.ToString + "'"
        ejecutarSQL(sqlstr)

        If cliente Then
            lbl_cheques.Text = "Cheques disponibles del cliente: " + cl.razon_social
            'sqlstr = "SELECT ch.id_cheque AS 'ID', b.nombre AS 'Banco emisor', ch.nCheque AS 'Nº cheque', ch.importe AS '$$' " &
            '            "FROM cheques AS ch " &
            '            "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
            '            "WHERE ch.id_cliente = '" + cl.id_cliente.ToString + "'"
            sqlstr = "SELECT tmpch.seleccionado AS 'Seleccionado', ch.id_cheque AS 'ID', b.nombre AS 'Banco emisor', ch.nCheque AS 'Nº cheque', ch.importe AS '$$' " &
                        "FROM tmpSelCH AS tmpch " &
                        "INNER JOIN cheques AS ch ON tmpch.id_cheque = ch.id_cheque " &
                        "INNER JOIN bancos AS b ON ch.id_banco = b.id_banco " &
                        "WHERE ch.id_cliente = '" + cl.id_cliente.ToString + "' "
            Dim nRegs As Integer = 0
            Dim tPaginas As Integer = 0
            Dim txtnPage As New TextBox()
            cargar_datagrid(dg_view, sqlstr, basedb, 0, nRegs, tPaginas, 1, txtnPage, "cheques", "cheques")

            dg_view.ReadOnly = False
            dg_view.Columns("ID").ReadOnly = True
            dg_view.Columns("Banco emisor").ReadOnly = True
            dg_view.Columns("Nº cheque").ReadOnly = True
            dg_view.Columns("$$").ReadOnly = True
            dg_view.Columns("Seleccionado").ReadOnly = False

        Else
            lbl_cheques.Text = "Cheques en cartera"
        End If
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Dim sqlstr As String

        If dg_view.Rows.Count > 0 Then
            For Each fila As DataGridViewRow In dg_view.Rows
                If Not fila Is Nothing Then
                    If fila.Cells("Seleccionado").Value Then
                        sqlstr = "UPDATE tmpSelCH SET seleccionado = '1' WHERE id_cheque = '" + fila.Cells("ID").Value.ToString + "'"
                        ejecutarSQL(sqlstr)
                        'MsgBox("Fila " + fila.Cells("Nº cheque").Value.ToString + "seleccionado")
                    End If
                End If
            Next
        End If
    End Sub
End Class