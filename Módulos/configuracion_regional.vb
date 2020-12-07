Imports System.Globalization

Friend Class configuracion_regional
    <STAThread()> _
    Shared Sub cambiarIdioma()

        Dim forceDotCulture As CultureInfo
        forceDotCulture = Application.CurrentCulture.Clone()
        forceDotCulture.NumberFormat.NumberDecimalSeparator = "."
        forceDotCulture.NumberFormat.NumberGroupSeparator = ","

        Application.CurrentCulture = forceDotCulture
    End Sub
End Class
