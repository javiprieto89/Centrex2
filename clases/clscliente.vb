Public Class cliente
    Public Property id_cliente As Integer
    Public Property taxNumber As String
    Public Property razon_social As String
    Public Property nombre_fantasia As String
    Public Property contacto As String
    Public Property telefono As String
    Public Property celular As String
    Public Property email As String
    Public Property id_pais_fiscal As Integer
    Public Property id_provincia_fiscal As Integer
    Public Property direccion_fiscal As String
    Public Property localidad_fiscal As String
    Public Property cp_fiscal As String
    Public Property id_pais_entrega As Integer
    Public Property id_provincia_entrega As Integer
    Public Property direccion_entrega As String
    Public Property localidad_entrega As String
    Public Property cp_entrega As String
    Public Property notas As String
    Public Property esInscripto As Boolean
    Public Property nombre As String
    Public Property cuit As String
    Public Property limite_credito As Decimal
    Public Property activo As Boolean
    Public Property id_tipoDocumento As Integer
    Public Property id_claseFiscal As Integer

    Public Shared Function FromEntity(entity As ClienteEntity) As cliente
        If entity Is Nothing Then
            Return Nothing
        End If

        Dim result As New cliente With {
            .id_cliente = entity.IdCliente,
            .taxNumber = If(entity.TaxNumber, String.Empty),
            .razon_social = If(entity.RazonSocial, String.Empty),
            .nombre_fantasia = If(entity.NombreFantasia, String.Empty),
            .contacto = If(entity.Contacto, String.Empty),
            .telefono = If(entity.Telefono, String.Empty),
            .celular = If(entity.Celular, String.Empty),
            .email = If(entity.Email, String.Empty),
            .id_provincia_fiscal = entity.IdProvinciaFiscal.GetValueOrDefault(),
            .direccion_fiscal = If(entity.DireccionFiscal, String.Empty),
            .localidad_fiscal = If(entity.LocalidadFiscal, String.Empty),
            .cp_fiscal = If(entity.CpFiscal, String.Empty),
            .id_provincia_entrega = entity.IdProvinciaEntrega.GetValueOrDefault(),
            .direccion_entrega = If(entity.DireccionEntrega, String.Empty),
            .localidad_entrega = If(entity.LocalidadEntrega, String.Empty),
            .cp_entrega = If(entity.CpEntrega, String.Empty),
            .notas = If(entity.Notas, String.Empty),
            .esInscripto = entity.EsInscripto,
            .limite_credito = entity.LimiteCredito.GetValueOrDefault(),
            .activo = entity.Activo,
            .id_tipoDocumento = entity.IdTipoDocumento,
            .id_claseFiscal = entity.IdClaseFiscal.GetValueOrDefault()
        }

        If entity.ProvinciaFiscal IsNot Nothing Then
            result.id_pais_fiscal = entity.ProvinciaFiscal.IdPais
        End If

        If entity.ProvinciaEntrega IsNot Nothing Then
            result.id_pais_entrega = entity.ProvinciaEntrega.IdPais
        End If

        result.nombre = If(String.IsNullOrEmpty(result.nombre_fantasia), result.razon_social, result.nombre_fantasia)
        result.cuit = result.taxNumber

        Return result
    End Function

    Public Function ToEntity(Optional destination As ClienteEntity = Nothing) As ClienteEntity
        Dim entity = If(destination, New ClienteEntity())

        entity.IdCliente = id_cliente
        entity.TaxNumber = taxNumber
        entity.RazonSocial = razon_social
        entity.NombreFantasia = nombre_fantasia
        entity.Contacto = contacto
        entity.Telefono = telefono
        entity.Celular = celular
        entity.Email = email
        entity.IdProvinciaFiscal = NullIfZero(id_provincia_fiscal)
        entity.DireccionFiscal = direccion_fiscal
        entity.LocalidadFiscal = localidad_fiscal
        entity.CpFiscal = cp_fiscal
        entity.IdProvinciaEntrega = NullIfZero(id_provincia_entrega)
        entity.DireccionEntrega = direccion_entrega
        entity.LocalidadEntrega = localidad_entrega
        entity.CpEntrega = cp_entrega
        entity.Notas = notas
        entity.EsInscripto = esInscripto
        entity.LimiteCredito = limite_credito
        entity.Activo = activo
        entity.IdTipoDocumento = id_tipoDocumento
        entity.IdClaseFiscal = NullIfZero(id_claseFiscal)

        Return entity
    End Function

    Public Sub ApplyToEntity(destination As ClienteEntity)
        ToEntity(destination)
    End Sub

    Private Shared Function NullIfZero(value As Integer) As Integer?
        If value = 0 Then
            Return Nothing
        End If

        Return value
    End Function
End Class
