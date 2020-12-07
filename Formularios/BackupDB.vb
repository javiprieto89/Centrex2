Public Class BackupDB
    Private resultado As Boolean
    Private Sub BackupDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True
        ProgressBar1.Visible = True

        resultado = dbBackup()
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