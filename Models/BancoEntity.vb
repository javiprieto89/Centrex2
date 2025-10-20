' Entidad Banco mapeada según db/dbo.bancos.Table.sql
Public Class BancoEntity
    Public Property IdBanco As Integer
    Public Property Nombre As String
    Public Property IdPais As Integer
    Public Property NumeroBanco As Integer?
    Public Property Activo As Boolean

    Public Overridable Property Pais As PaisEntity
End Class

