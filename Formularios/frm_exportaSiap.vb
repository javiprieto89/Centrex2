Public Class frm_exportaSiap
    Private Sub frm_exportaSiap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargo todas las consultas
        cargar_combo(cmb_consultas, "SELECT id_consultaSiap, nombre FROM consultas_SIAP ORDER BY nombre ASC", basedb, "nombre", "id_consultaSiap")
        cmb_consultas.SelectedValue = 0
        cmb_consultas.Text = "Elija una consulta..."

        pExportXLS.Enabled = False
        pExportTXT.Enabled = False
    End Sub

    Private Function checkFilters() As Boolean
        Dim ok As Boolean = True

        If cmb_consultas.SelectedValue = 0 Then
            MsgBox("Debe elegir una consulta para ejecutar", vbExclamation + vbOKOnly, "Centrex")
            ok = False
        End If

        If dtp_desde.Value.Date > dtp_hasta.Value.Date Then
            MsgBox("La fecha 'Desde' no puede ser superior a 'Hasta'", vbExclamation, "Centrex")
            ok = False
        End If

        Return ok
    End Function

    Private Function cabecera(ByVal fecha_desde As Date, ByVal fecha_hasta As Date, Optional ByVal id_comprobante As Integer = -1,
                              Optional ByVal id_item As Integer = -1, Optional ByVal id_cliente As Integer = -1) As String
        Dim cabeceraStr As String

        cabeceraStr = "DECLARE @desde AS DATE " &
                        "DECLARE @hasta AS DATE "

        If chk_desde.Checked Then
            cabeceraStr += " SET @desde = '" + fecha_desde.ToString("yyyy/MM/dd") + "' "
        Else
            cabeceraStr += " SET @desde = NULL "
        End If

        If chk_hasta.Checked Then
            cabeceraStr += " SET @hasta = '" + fecha_hasta.ToString("yyyy/MM/dd") + "' "
        Else
            cabeceraStr += " SET @hasta = NULL "
        End If

        If Not chk_desde.Checked And Not chk_hasta.Checked Then
            cabeceraStr += " SET @desde = NULL SET @hasta = NULL "
        End If

        Return cabeceraStr
    End Function

    Private Sub pExportTXT_Click(sender As Object, e As EventArgs) Handles pExportTXT.Click
        Dim rutaArchivo As String
        Dim c As New consultaSIAP
        Dim cabeceraStr As String
        Dim r As String

        If Not checkFilters() Then Exit Sub

        c = info_consultaSIAP(cmb_consultas.SelectedValue)

        cabeceraStr = cabecera(dtp_desde.Value.Date, dtp_hasta.Value.Date)

        c.consulta = cabeceraStr + c.consulta

        r = ejecutarSQLconResultado(c.consulta)

        With SaveFileDialog1
            .AddExtension = True
            .CheckFileExists = False
            .CheckPathExists = True
            .Filter = "Text Files|*.txt"
            .DefaultExt = "txt"
            .InitialDirectory = "C:\"
            .ShowDialog()
            rutaArchivo = .FileName
            If rutaArchivo = "" Then
                MsgBox("Exportación cancelada.", vbInformation + vbOKOnly, "Centrex")
                Exit Sub
            End If
        End With

        guardarArchivoTexto(rutaArchivo, r)
        MsgBox("Archivo exportado a: " + SaveFileDialog1.FileName, vbInformation + vbOKOnly, "Centrex")
        closeandupdate(Me)
    End Sub

    Private Sub cmb_consultas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmb_consultas.SelectionChangeCommitted
        Dim c As consultaSIAP

        c = info_consultaSIAP(cmb_consultas.SelectedValue)

        If c.excel Then
            pExportXLS.Enabled = True
            pExportTXT.Enabled = False

            pExportXLS.Image = Centrex.My.Resources.Resources.iconoExcel
            pExportTXT.Image = Centrex.My.Resources.Resources.iconotxtByN
        ElseIf c.txt Then
            pExportXLS.Enabled = False
            pExportTXT.Enabled = True

            pExportXLS.Image = Centrex.My.Resources.Resources.iconoExcelByN
            pExportTXT.Image = Centrex.My.Resources.Resources.iconotxt
        End If
    End Sub

    Private Sub pExportXLS_Click(sender As Object, e As EventArgs) Handles pExportXLS.Click
        'MsgBox("Hola")
    End Sub

    Private Sub cmd_cerrar_Click(sender As Object, e As EventArgs) Handles cmd_cerrar.Click
        closeandupdate(Me)
    End Sub

    Private Sub chk_desde_CheckedChanged(sender As Object, e As EventArgs) Handles chk_desde.CheckedChanged
        dtp_desde.Enabled = chk_desde.Checked
    End Sub

    Private Sub chk_hasta_CheckedChanged(sender As Object, e As EventArgs) Handles chk_hasta.CheckedChanged
        dtp_hasta.Enabled = chk_hasta.Checked
    End Sub
End Class