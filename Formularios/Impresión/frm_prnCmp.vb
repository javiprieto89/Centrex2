Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frm_prnCmp
    Dim esPresupuesto As Boolean = False
    Dim imprimeRemito As Boolean = True
    Dim p As New pedido
    Dim c As New comprobante
    Dim comando As New SqlCommand

    Dim id_tipoComprobante As Integer
    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub New(ByVal Presupuesto As Boolean, ByVal Remito As Boolean)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.esPresupuesto = Presupuesto
        Me.imprimeRemito = Remito
    End Sub

    Private Sub frm_reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds_FC_Empresa As DataSet = New DataSet("DataSetFC_empresa")
        Dim ds_FC_Cabecera As DataSet = New DataSet("DataSetFC_cabecera")
        Dim ds_FC_Detalle As DataSet = New DataSet("DataSetFC_detalle")
        Dim ds_Presupuesto_Cabecera As DataSet = New DataSet("DataSetPresupuesto_cabecera")


        Dim dt_empresa As New DataTable
        Dim dt_FC_cabecera As New DataTable
        Dim dt_FC_detalle As New DataTable
        Dim dt_Presupuesto_cabecera As New DataTable
        Dim fileName As String = ""

        Dim da As New SqlDataAdapter


        Dim sqlstr As String

        p = info_pedido(id)
        c = info_comprobante(p.id_comprobante)

        id_tipoComprobante = c.id_tipoComprobante

        Me.ReportViewer1.ProcessingMode = ProcessingMode.Local
        Me.ReportViewer1.LocalReport.DataSources.Clear()

        Select Case id_tipoComprobante
            Case Is = 99 'PRESUPUESTO
                'If esPresupuesto Then
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_presupuesto.rdlc"
                'Else
                '    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_presupuestoFull.rdlc"
                'End If
                fileName = "PS "
            Case Is = 1 'FACTURA A
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_facturaA.rdlc"
                fileName = "FC A "
            Case Is = 6 'FACTURA B
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_facturaB.rdlc"
                fileName = "FC B "
            Case Is = 3 'NOTA DE CREDITO A
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_notaDeCreditoA.rdlc"
                fileName = "NC A "
            Case Is = 8 'NOTA DE CREDITO B
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_notaDeCreditoB.rdlc"
                fileName = "NC B "
            Case Is = 2 'NOTA DE DEBITO A
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_notaDeDebitoA.rdlc"
                fileName = "ND A "
            Case Is = 7 'NOTA DE DEBITO B
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_notaDeDebitoB.rdlc"
                fileName = "ND B "
            Case Is = 199 'REMITO
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_saleOrderRM.rdlc"
                fileName = "RM "
        End Select

        If id_tipoComprobante = 99 Or id_tipoComprobante = 0 Then
            fileName += p.idPresupuesto.ToString
        Else
            fileName += p.numeroComprobante.ToString
        End If

        Me.ReportViewer1.LocalReport.DisplayName = fileName

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            comando.CommandType = CommandType.Text
            comando.Connection = CN

            If id_tipoComprobante = 199 Then 'REMITO
                cargar_ds_Remitos()
                ReportViewer1.PrinterSettings.Copies = 3
            ElseIf c.id_tipoComprobante = 99 Then 'PRESUPUESTO
                sqlstr = "EXEC [dbo].[presupuesto_cabecera]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_Presupuesto_Cabecera, "Tabla")

                dt_Presupuesto_cabecera = ds_Presupuesto_Cabecera.Tables(0)

                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetPresupuesto_cabecera", dt_Presupuesto_cabecera))
                ReportViewer1.PrinterSettings.Copies = 2
            End If

            If id_tipoComprobante <> 199 Then 'TODO MENOS REMITOS
                sqlstr = "EXEC	[dbo].[datos_empresa]"
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_FC_Empresa, "Tabla")


                sqlstr = "EXEC	[dbo].[factura_cabecera]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_FC_Cabecera, "Tabla")


                sqlstr = "EXEC [dbo].[factura_detalle]	@idfc = " & id.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(ds_FC_Detalle, "Tabla")

                dt_empresa = ds_FC_Empresa.Tables(0)
                dt_FC_cabecera = ds_FC_Cabecera.Tables(0)
                dt_FC_detalle = ds_FC_Detalle.Tables(0)

                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetFC_empresa", dt_empresa))
                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetFC_cabecera", dt_FC_cabecera))
                Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetFC_detalle", dt_FC_detalle))
                If id_tipoComprobante = 99 Then ReportViewer1.PrinterSettings.Copies = 2 Else ReportViewer1.PrinterSettings.Copies = 3
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            cerrardb()
        End Try


        ReportViewer1.PrinterSettings.PrintRange = PrintRange.SomePages
        ReportViewer1.PrinterSettings.FromPage = 1
        ReportViewer1.PrinterSettings.ToPage = 1

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub frm_reportes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If id_tipoComprobante = 199 Or id_tipoComprobante = 99 Then Exit Sub 'Si es un remito no pregunta si se quieren emitir los remitos

        If imprimeRemito Then
            e.Cancel = True
            imprimirRemitos()
            'Else
            'If MsgBox("¿Desea imprimir los remitos?", vbYesNo + MsgBoxStyle.DefaultButton1, "Centrex") = MsgBoxResult.Yes Then
            '   e.Cancel = True
            '  imprimirRemitos()
            'End If
        End If
    End Sub

    Private Sub imprimirRemitos()
        Dim p As New pedido
        Dim c As New comprobante

        p = info_pedido(id)
        c = info_comprobante(p.id_comprobante)

        id_tipoComprobante = 199
        cargar_ds_Remitos()
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Centrex.rpt_saleOrderRM.rdlc"

        Me.ReportViewer1.LocalReport.DisplayName = "RM " + p.numeroComprobante.ToString
        ReportViewer1.PrinterSettings.Copies = 3
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub cargar_ds_Remitos()
        Dim ds_RM_Cabecera As DataSet = New DataSet("DataSetRM_cabecera")
        Dim ds_RM_Detalle As DataSet = New DataSet("DataSetRM_detalle")

        Dim dt_RM_cabecera As New DataTable
        Dim dt_RM_detalle As New DataTable

        Dim sqlstr As String

        Dim da As New SqlDataAdapter

        sqlstr = "EXEC	[dbo].[remito_cabecera]	@idfc = " & id.ToString
        comando.CommandText = sqlstr
        da.SelectCommand = comando
        da.Fill(ds_RM_Cabecera, "Tabla")

        sqlstr = "EXEC [dbo].[remito_detalle]	@idfc = " & id.ToString
        comando.CommandText = sqlstr
        da.SelectCommand = comando
        da.Fill(ds_RM_Detalle, "Tabla")

        dt_RM_cabecera = ds_RM_Cabecera.Tables(0)
        dt_RM_detalle = ds_RM_Detalle.Tables(0)

        Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetRM_cabecera", dt_RM_cabecera))
        Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetRM_detalle", dt_RM_detalle))
    End Sub
End Class