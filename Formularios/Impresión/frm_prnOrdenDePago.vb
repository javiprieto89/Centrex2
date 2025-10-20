Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frm_prnOrdenDePago
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
        ID = _id
    End Sub


    Private Sub frm_prnReciboPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim archivoRpt As String
        Dim sqlstr As String
        Dim filename As String

        archivoRpt = "rpt_ordenDePago"

        filename = "OP " + ID.ToString
        archivoRpt = "Centrex." + archivoRpt + ".rdlc"

        rpt_view.ProcessingMode = ProcessingMode.Local
        rpt_view.LocalReport.DataSources.Clear()


        Dim DataSetFC_empresa As DataSet = New DataSet("DS_Datos_Empresa")
        Dim DS_Pago_Cabecera As DataSet = New DataSet("DS_Pago_Cabecera")
        Dim DS_Detalle_Pago_Cheques As DataSet = New DataSet("DS_Detalle_Pago_Cheques")
        Dim DS_Detalle_Pago_Transferencias As DataSet = New DataSet("DS_Detalle_Pago_Transferencias")
        Dim DS_Detalle_Pago_FC_Importes As DataSet = New DataSet("DS_Detalle_Pago_FC_Importes")

        Dim DT_empresa As New DataTable
        Dim DT_Pago_Cabecera As New DataTable
        Dim DT_Detalle_Pago_Cheques As New DataTable
        Dim DT_Detalle_Pago_Transferencias As New DataTable
        Dim DT_Detalle_Pago_FC_Importes As New DataTable

        Dim da As New SqlDataAdapter

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            comando.CommandType = CommandType.Text
            comando.Connection = CN

            sqlstr = "EXEC	[dbo].[datos_empresa]"
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DataSetFC_empresa, "Tabla")

            sqlstr = "EXEC	[dbo].[SP_pago_cabecera]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Pago_Cabecera, "Tabla")

            sqlstr = "EXEC [dbo].[SP_detalle_pagos_cheques]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Pago_Cheques, "Tabla")

            sqlstr = "EXEC [dbo].[SP_detalle_pagos_transferencias]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Pago_Transferencias, "Tabla")

            sqlstr = "EXEC [dbo].[SP_detalle_pagos_fc_importes]	@id = " & ID.ToString
            comando.CommandText = sqlstr
            da.SelectCommand = comando
            da.Fill(DS_Detalle_Pago_FC_Importes, "Tabla")

            DT_empresa = DataSetFC_empresa.Tables(0)
            DT_Pago_Cabecera = DS_Pago_Cabecera.Tables(0)
            DT_Detalle_Pago_Cheques = DS_Detalle_Pago_Cheques.Tables(0)
            DT_Detalle_Pago_Transferencias = DS_Detalle_Pago_Transferencias.Tables(0)
            DT_Detalle_Pago_FC_Importes = DS_Detalle_Pago_FC_Importes.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Exit Sub
        Finally
            cerrardb()
        End Try

        With rpt_view
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Datos_Empresa", DT_empresa))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Pago_Cabecera", DT_Pago_Cabecera))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Detalle_Pago_Cheques", DT_Detalle_Pago_Cheques))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Detalle_Pago_Transferencias", DT_Detalle_Pago_Transferencias))
            .LocalReport.DataSources.Add(New ReportDataSource("DS_Detalle_Pago_FC_Importes", DT_Detalle_Pago_FC_Importes))
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