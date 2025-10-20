' Entidad Provincia según db/dbo.provincias.Table.sql
Public Class ProvinciaEntity
    Public Property IdProvincia As Integer
    Public Property IdPais As Integer
    Public Property Provincia As String

    Public Overridable Property Pais As PaisEntity
End Class

