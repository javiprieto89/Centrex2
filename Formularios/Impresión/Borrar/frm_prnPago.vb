Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class frm_prnPago
    'Generales
    Dim archivoRpt As String
    Dim rptID As Integer
    Dim spEmpresa As String
    Dim spCabecera As String
    Dim spDetalle As String

    Dim dsEmpresa As String
    Dim dsCabecera As String
    Dim dsDetalle As String
    'Generales

    'Para cobros
    Dim esCobro As Boolean

    Dim spCheque As String
    Dim spTransferencia As String
    Dim spRetencion As String

    Dim dsCheque As String
    Dim dsTransferencia As String
    Dim dsRetencion As String
    'Para cobros

    Dim comando As New SqlCommand

    Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub New(ByVal _archivoRpt As String, ByVal _spEmpresa As String, ByVal _spCabecera As String, ByVal _spDetalle As String,
                ByVal _dsEmpresa As String, ByVal _dsCabecera As String, ByVal _dsDetalle As String, _id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        archivoRpt = _archivoRpt
        spEmpresa = _spEmpresa
        spCabecera = _spCabecera
        spDetalle = _spDetalle
        dsEmpresa = _dsEmpresa
        dsCabecera = _dsCabecera
        dsDetalle = _dsDetalle
        rptID = _id
    End Sub

    Sub New(ByVal _archivoRpt As String, ByVal _spEmpresa As String, ByVal _spCabecera As String,
                ByVal _spCheque As String, ByVal _spTransferencia As String, ByVal _spRetencion As String, ByVal _dsEmpresa As String,
                ByVal _dsCabecera As String, ByVal _dsCheque As String, ByVal _dsTransferencia As String,
                ByVal _dsRetencion As String, _id As Integer, ByVal _esCobro As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        archivoRpt = _archivoRpt
        spEmpresa = _spEmpresa
        spCabecera = _spCabecera
        spCheque = _spCheque
        spTransferencia = _spTransferencia
        spRetencion = _spRetencion
        dsEmpresa = _dsEmpresa
        dsCabecera = _dsCabecera
        dsCheque = _dsCheque
        dsTransferencia = _dsTransferencia
        dsRetencion = _dsRetencion
        rptID = _id
        esCobro = _esCobro
    End Sub

    Private Sub frm_prnPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim guardarComo As String
        Dim sqlstr As String

        guardarComo = archivoRpt + " " + rptID.ToString
        archivoRpt = "Centrex." + archivoRpt + ".rdlc"

        rpt_view.ProcessingMode = ProcessingMode.Local
        rpt_view.LocalReport.DataSources.Clear()

        If esCobro Then
            Dim DS_Empresa As DataSet = New DataSet(dsEmpresa)
            Dim DS_Cabecera As DataSet = New DataSet(dsCabecera)

            Dim DS_Cheque As DataSet = New DataSet(dsCheque)
            Dim DS_Transferencia As DataSet = New DataSet(dsTransferencia)
            Dim DS_Retencion As DataSet = New DataSet(dsRetencion)

            Dim DT_Empresa As New DataTable
            Dim DT_Cabecera As New DataTable

            Dim DT_Cheque As New DataTable
            Dim DT_Transferencia As New DataTable
            Dim DT_Retencion As New DataTable

            Dim da As New SqlDataAdapter

            Try
                abrirdb(serversql, basedb, usuariodb, passdb)

                comando.CommandType = CommandType.Text
                comando.Connection = CN

                sqlstr = "EXEC	[dbo].[" + spEmpresa + "]"
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Empresa, "Tabla")

                sqlstr = "EXEC	[dbo].[" + spCabecera + "]	@id = " & rptID.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Cabecera, "Tabla")

                sqlstr = "EXEC	[dbo].[" + spCheque + "]	@id = " & rptID.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Cheque, "Tabla")

                sqlstr = "EXEC	[dbo].[" + spTransferencia + "]	@id = " & rptID.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Transferencia, "Tabla")

                sqlstr = "EXEC [dbo].[" + spRetencion + "]	@id = " & rptID.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Retencion, "Tabla")

                DT_Empresa = DS_Empresa.Tables(0)
                DT_Cabecera = DS_Cabecera.Tables(0)

                DT_Cheque = DS_Cheque.Tables(0)
                DT_Transferencia = DS_Transferencia.Tables(0)
                DT_Retencion = DS_Retencion.Tables(0)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                Exit Sub
            Finally
                cerrardb()
            End Try

            With rpt_view
                .LocalReport.DataSources.Add(New ReportDataSource(dsEmpresa, DT_Empresa))
                .LocalReport.DataSources.Add(New ReportDataSource(dsCabecera, DT_Cabecera))

                .LocalReport.DataSources.Add(New ReportDataSource(dsCheque, DT_Cheque))
                .LocalReport.DataSources.Add(New ReportDataSource(dsTransferencia, DT_Transferencia))
                .LocalReport.DataSources.Add(New ReportDataSource(dsRetencion, DT_Retencion))
            End With
        Else
            Dim DS_Empresa As DataSet = New DataSet(dsEmpresa)
            Dim DS_Cabecera As DataSet = New DataSet(dsCabecera)
            Dim DS_Detalle As DataSet = New DataSet(dsDetalle)

            Dim DT_Empresa As New DataTable
            Dim DT_Cabecera As New DataTable
            Dim DT_Detalle As New DataTable

            Dim da As New SqlDataAdapter

            Try
                abrirdb(serversql, basedb, usuariodb, passdb)

                comando.CommandType = CommandType.Text
                comando.Connection = CN

                sqlstr = "EXEC	[dbo].[" + spEmpresa + "]"
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Empresa, "Tabla")

                sqlstr = "EXEC	[dbo].[" + spCabecera + "]	@id = " & rptID.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Cabecera, "Tabla")

                sqlstr = "EXEC [dbo].[" + spDetalle + "]	@id = " & rptID.ToString
                comando.CommandText = sqlstr
                da.SelectCommand = comando
                da.Fill(DS_Detalle, "Tabla")

                DT_Empresa = DS_Empresa.Tables(0)
                DT_Cabecera = DS_Cabecera.Tables(0)
                DT_Detalle = DS_Detalle.Tables(0)

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                Exit Sub
            Finally
                cerrardb()
            End Try

            With rpt_view
                .LocalReport.DataSources.Add(New ReportDataSource(dsEmpresa, DT_Empresa))
                .LocalReport.DataSources.Add(New ReportDataSource(dsCabecera, DT_Cabecera))
                .LocalReport.DataSources.Add(New ReportDataSource(dsDetalle, DT_Detalle))
            End With
        End If

        With rpt_view
            .PrinterSettings.Copies = 2
            .LocalReport.ReportEmbeddedResource = archivoRpt

            .LocalReport.DisplayName = guardarComo

            .PrinterSettings.PrintRange = PrintRange.SomePages
            .PrinterSettings.FromPage = 1
            .PrinterSettings.ToPage = 1

            .RefreshReport()
        End With
    End Sub
End Class