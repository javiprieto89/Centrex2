' Entidad Cliente mapeada según db/dbo.clientes.Table.sql
Public Class ClienteEntity
    Public Property IdCliente As Integer
    Public Property TaxNumber As String
    Public Property RazonSocial As String
    Public Property NombreFantasia As String
    Public Property Contacto As String
    Public Property Telefono As String
    Public Property Celular As String
    Public Property Email As String
    Public Property IdProvinciaFiscal As Integer?
    Public Property DireccionFiscal As String
    Public Property LocalidadFiscal As String
    Public Property CpFiscal As String
    Public Property IdProvinciaEntrega As Integer?
    Public Property DireccionEntrega As String
    Public Property LocalidadEntrega As String
    Public Property CpEntrega As String
    Public Property Notas As String
    Public Property EsInscripto As Boolean
    Public Property Activo As Boolean
    Public Property IdTipoDocumento As Integer
    Public Property IdClaseFiscal As Integer?

    Public Overridable Property ProvinciaFiscal As ProvinciaEntity
    Public Overridable Property ProvinciaEntrega As ProvinciaEntity
End Class

