Public Class config
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
    Dim c As New configInit

    Private Sub tctrl_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tctrl.Selecting
        cargar_combo(cmb_clientes, "SELECT id_cliente AS 'ID', razon_social AS 'Cliente' FROM clientes WHERE activo = '1' ORDER BY razon_social ASC", basedb, "cliente", "id")
    End Sub

    Private Sub config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With c
            .leerConfig()

            txtdb.Text = .nameDB
            txtserver.Text = .serverDB
            txtuser.Text = .userDB
            txtpassword.Text = .passwordDB
            txt_rutaBackup.Text = .backupPath
            txt_nombreBackup.Text = .backupFile
            txt_itPerPage.Text = .itemsPorPagina
        End With

        dtp_fecha_sistema.Value = Fecha_Sistema()
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        With c
            .nameDB = txtdb.Text
            .serverDB = txtserver.Text
            .userDB = txtuser.Text
            .passwordDB = txtpassword.Text
            .backupPath = txt_rutaBackup.Text
            .backupFile = txt_nombreBackup.Text
            .itemsPorPagina = txt_itPerPage.Text
        End With

        c.guardarConfig()
        Me.Dispose()
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Dispose()
    End Sub

    Private Sub cmd_elegirRuta_Click(sender As Object, e As EventArgs) Handles cmd_elegirRuta.Click
        FolderBrowserDialog1.ShowDialog()
        txt_rutaBackup.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub cmd_abrirCarpeta_Click(sender As Object, e As EventArgs) Handles cmd_abrirCarpeta.Click
        If System.IO.Directory.Exists(txt_rutaBackup.Text) Then
            ShellExecute(0, "Open", txt_rutaBackup.Text, "", "", 1) 'Para Abrir Carpetas
        Else
            MsgBox("La ruta ingresada: " & vbCrLf & txt_rutaBackup.Text & "NO existe" & vbCrLf &
                    "Por favor escriba un directorio válido o seleccioneló desde el botón: 'Elegir carpeta'", vbCritical + vbOKOnly, "Computron")
        End If

    End Sub

    Private Sub cmd_cierre_diario_Click(sender As Object, e As EventArgs) Handles cmd_cierre_diario.Click

    End Sub
End Class