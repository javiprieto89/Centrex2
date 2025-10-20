Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

''' <summary>
''' Entity Framework model for Produccion table
''' </summary>
<Table("producciones")>
Public Class ProduccionEntity
    <Key>
    <Column("id_produccion")>
    Public Property IdProduccion As Integer

    <Column("id_proveedor")>
    Public Property IdProveedor As Integer?

    <Column("fecha_carga")>
    Public Property FechaCarga As DateTime?

    <Column("fecha_envio")>
    Public Property FechaEnvio As DateTime?

    <Column("fecha_recepcion")>
    Public Property FechaRecepcion As DateTime?

    <Column("enviado")>
    Public Property Enviado As Boolean?

    <Column("recibido")>
    Public Property Recibido As Boolean?

    <Column("notas")>
    <StringLength(1000)>
    Public Property Notas As String

    <Column("activo")>
    Public Property Activo As Boolean?

    <Column("id_usuario")>
    Public Property IdUsuario As Integer?

    ' Navigation properties
    Public Overridable Property Proveedor As ProveedorEntity
    Public Overridable Property Usuario As UsuarioEntity
End Class
