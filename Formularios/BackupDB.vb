Public Class BackupDB
    Private resultado As Boolean
    Private Sub BackupDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim anio As String = DateTime.Now.Year
        Dim mes As String = DateTime.Now.Month
        Dim dia As String = DateTime.Now.Day
        Dim hora As String = DateTime.Now.Hour
        Dim minuto As String = DateTime.Now.Minute
        Dim segundo As String = DateTime.Now.Second
        Dim timeStamp As String = anio + mes + dia + "_" + hora + minuto + segundo
        Dim archivoBackup_local As String
        Timer1.Enabled = True
        ProgressBar1.Visible = True


        archivoBackup_local = archivoBackup + "_" + timeStamp + ".bak"
        resultado = dbBackup(rutaBackup, archivoBackup_local)
        'If pc = "BRUNO" Then
        '    resultado = dbBackup(Application.StartupPath + "\SQL\BKP", archivoBackup_local)
        'End If

        Dim directory As New IO.DirectoryInfo(Application.StartupPath + "\SQL\BKP")

        For Each file As IO.FileInfo In directory.GetFiles
            If (Now - file.CreationTime).Days > 10 Then file.Delete()
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            If Not resultado Then
                'MsgBox("Se ha realizado correctamente el backup", vbInformation, "Centrex")
                'Else
                MsgBox("Ha ocurrido un error al realizar un backup de la base de datos" & Chr(13) & "Consulte con el programador", vbInformation, "Centrex")
            End If
            closeandupdate(Me)
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
    End Sub
End Class