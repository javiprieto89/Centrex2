Public Class muestra_texto
    Private str As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _str As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        str = _str
    End Sub

    Private Sub muestra_texto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_msg.Text = str
    End Sub

    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        Me.Close()
    End Sub
End Class