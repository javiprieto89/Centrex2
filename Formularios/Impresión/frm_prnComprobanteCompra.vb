Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frm_prnComprobanteCompra
    'Generales
    Dim ID As Integer

    Dim comando As New SqlCommand

    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub New(ByVal _id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id = _id
    End Sub


    Private Sub frm_prnComprobanteCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim archivoRpt As String
        Dim sqlstr As String
        Dim filename As String

        archivoRpt = "rpt_comprobanteCompra"

        filename = "Comprobante compra " + ID.ToString
        archivoRpt = "Centrex." + archivoRpt + ".rdlc"

        rpt_view.ProcessingMode = ProcessingMode.Local
        rpt_view.LocalReport.DataSources.Clear()


        Dim DS_Empresa As DataSet = New DataSet("DS_Empresa")
        Dim DS_Cabecera As DataSet = New DataSet("DS_ComprobanteCompraCabecera")
        Dim DS_Detalle_Items As DataSet = New DataSet("DS_ComprobanteCompraDetalleItems")
        Dim DS_Detalle_Impuestos As DataSet = New DataSet("DS_ComprobanteCompraDetalleImpuestos")
        Dim DS_Detalle_Conceptos As DataSet = New DataSet("DS_ComprobanteCompraDetalleConceptos")

        Dim DT_Empresa As New DataTable
        Dim DT_Cabecera As New DataTable
        Dim DT_Detalle_Items As New DataTable
        Dim DT_Detalle_Impuestos As New DataTable
        Dim DT_Detalle_Conceptos As New DataTable

        Dim da As New SqlDataAdapter

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            comando.CommandType = CommandType.Text
            comando.Connection = CN

            sqlstr = "EXEC	[dbo].[datos_empresa]"
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Empresa, "Tabla")

            sqlstr = "EXEC	[dbo].[SP_comprobanteCompra_cabecera]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Cabecera, "Tabla")

            sqlstr = "EXEC [dbo].[SP_comprobanteCompra_detalle_items]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Items, "Tabla")

            sqlstr = "EXEC [dbo].[SP_comprobanteCompra_detalle_impuestos]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Impuestos, "Tabla")

            sqlstr = "EXEC [dbo].[SP_comprobanteCompra_detalle_conceptos]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Conceptos, "Tabla")

            DT_Empresa = DS_Empresa.Tables(0)
            DT_Cabecera = DS_Cabecera.Tables(0)
            DT_Detalle_Items = DS_Detalle_Items.Tables(0)
            DT_Detalle_Impuestos = DS_Detalle_Impuestos.Tables(0)
            DT_Detalle_Conceptos = DS_Detalle_Conceptos.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Exit Sub
        Finally
            cerrardb()
        End Try

        With rpt_view
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Empresa", DT_Empresa))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_ComprobanteCompraCabecera", DT_Cabecera))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_ComprobanteCompraDetalleItems", DT_Detalle_Items))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_ComprobanteCompraDetalleImpuestos", DT_Detalle_Impuestos))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_ComprobanteCompraDetalleConceptos", DT_Detalle_Conceptos))
        End With

        With rpt_view
            .PrinterSettings.Copies = 2
            .LocalReport.ReportEmbeddedResource = archivoRpt

            .LocalReport.DisplayName = filename

            .PrinterSettings.PrintRange = PrintRange.SomePages
            .PrinterSettings.FromPage = 1
            .PrinterSettings.ToPage = 1

            .RefreshReport()
        End With
    End Sub
End Class