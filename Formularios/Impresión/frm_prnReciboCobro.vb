Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frm_prnReciboCobro
    'Generales
    Dim id As Integer

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


    Private Sub frm_prnReciboCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim archivoRpt As String
        Dim sqlstr As String
        Dim c As New cobro
        Dim fileName As String = ""

        c = info_cobro(id)

        If c.id_cobro_no_oficial = -1 Then
            archivoRpt = "rpt_reciboCobro"
        Else
            archivoRpt = "rpt_reciboCobro_noOficial"
        End If


        fileName = "RC " + id.ToString
        archivoRpt = "Centrex." + archivoRpt + ".rdlc"

        rpt_view.ProcessingMode = ProcessingMode.Local
        rpt_view.LocalReport.DataSources.Clear()


        Dim DataSetFC_empresa As DataSet = New DataSet("DataSetFC_empresa")
        Dim DS_Cobro_Cabecera As DataSet = New DataSet("DS_Cobro_Cabecera")
        Dim DS_Detalle_Cobro_Cheques As DataSet = New DataSet("DS_Detalle_Cobro_Cheques")
        Dim DS_Detalle_Cobro_Transferencias As DataSet = New DataSet("DS_Detalle_Cobro_Transferencias")
        Dim DS_Detalle_Cobro_Retenciones As DataSet = New DataSet("DS_Detalle_Cobro_Retenciones")
        Dim DS_Detalle_Cobro_FC_Importes As DataSet = New DataSet("DS_Detalle_Cobro_FC_Importes")

        Dim DT_empresa As New DataTable
        Dim DT_Cobro_Cabecera As New DataTable
        Dim DT_Detalle_Cobro_Cheques As New DataTable
        Dim DT_Detalle_Cobro_Transferencias As New DataTable
        Dim DT_Detalle_Cobro_Retenciones As New DataTable
        Dim DT_Detalle_Cobro_FC_Importes As New DataTable

        Dim da As New SqlDataAdapter

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            comando.CommandType = CommandType.Text
            comando.Connection = CN

            sqlstr = "EXEC	[dbo].[datos_empresa]"
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DataSetFC_empresa, "Tabla")

            sqlstr = "EXEC	[dbo].[SP_cobro_cabecera]	@id = " & id.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Cobro_Cabecera, "Tabla")

            sqlstr = "EXEC [dbo].[SP_detalle_cobros_cheques]	@id = " & id.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Cobro_Cheques, "Tabla")

            sqlstr = "EXEC [dbo].[SP_detalle_cobros_transferencias]	@id = " & id.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Cobro_Transferencias, "Tabla")

            sqlstr = "EXEC [dbo].[SP_detalle_cobros_retenciones]	@id = " & id.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Cobro_Retenciones, "Tabla")

            sqlstr = "EXEC [dbo].[SP_detalle_cobros_fc_importes]	@id = " & id.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Cobro_FC_Importes, "Tabla")

            DT_empresa = DataSetFC_empresa.Tables(0)
            DT_Cobro_Cabecera = DS_Cobro_Cabecera.Tables(0)
            DT_Detalle_Cobro_Cheques = DS_Detalle_Cobro_Cheques.Tables(0)
            DT_Detalle_Cobro_Transferencias = DS_Detalle_Cobro_Transferencias.Tables(0)
            DT_Detalle_Cobro_Retenciones = DS_Detalle_Cobro_Retenciones.Tables(0)
            DT_Detalle_Cobro_FC_Importes = DS_Detalle_Cobro_FC_Importes.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Exit Sub
        Finally
            cerrardb()
        End Try

        With rpt_view
            .LocalReport.DataSources.Add(New ReportDataSource("DataSetFC_empresa", DT_empresa))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Cobro_Cabecera", DT_Cobro_Cabecera))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Detalle_Cobro_Cheques", DT_Detalle_Cobro_Cheques))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Detalle_Cobro_Transferencias", DT_Detalle_Cobro_Transferencias))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Detalle_Cobro_Retenciones", DT_Detalle_Cobro_Retenciones))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Detalle_Cobro_FC_Importes", DT_Detalle_Cobro_FC_Importes))
        End With

        With rpt_view
            .PrinterSettings.Copies = 2
            .LocalReport.ReportEmbeddedResource = archivoRpt

            .LocalReport.DisplayName = fileName

            .PrinterSettings.PrintRange = PrintRange.SomePages
            .PrinterSettings.FromPage = 1
            .PrinterSettings.ToPage = 1

            .RefreshReport()
        End With
    End Sub
End Class