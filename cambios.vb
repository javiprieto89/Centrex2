Public Class frmCambios

    Private Sub frmcambios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        archivarcambios()
        main.Visible = True
        Me.Dispose()
    End Sub

    Private Sub frmcambios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_listview(lsv_cambios, "SELECT id_cambio AS 'ID', cambio AS 'Cambio', CAST(fecha AS VARCHAR(50)) AS 'Fecha' FROM cambios WHERE activo = '1'", basedb)
    End Sub

    Private Sub cmdcontinuar_Click(sender As Object, e As EventArgs) Handles cmdcontinuar.Click
        frmcambios_FormClosed(Nothing, Nothing)
    End Sub
End Class