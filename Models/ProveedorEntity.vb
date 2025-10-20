' Entidad Proveedor mapeada según db/dbo.proveedores.Table.sql
Public Class ProveedorEntity
    Public Property IdProveedor As Integer
    Public Property TaxNumber As String
    Public Property RazonSocial As String
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
    Public Property Vendedor As String
    Public Property Activo As Boolean
    Public Property IdTipoDocumento As Integer
    Public Property IdClaseFiscal As Integer?
End Class

