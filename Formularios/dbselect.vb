Public Class dbselect

    Private Sub dbselect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmb_selectdb.SelectedIndex = 0
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        End
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Select Me.cmb_selectdb.SelectedIndex
            Case 0
                basedb = "Centrex"
            Case 1
                basedb = "CentrexTest"
        End Select
        main.ShowDialog()
        Me.Dispose()
    End Sub
End Class