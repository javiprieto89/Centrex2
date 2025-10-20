Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

''' <summary>
''' Entity Framework model for UsuarioPerfil table
''' </summary>
<Table("usuarios_perfiles")>
Public Class UsuarioPerfilEntity
    <Key>
    <Column("id_usuario_perfil")>
    Public Property IdUsuarioPerfil As Integer

    <Column("id_usuario")>
    Public Property IdUsuario As Integer?

    <Column("id_perfil")>
    Public Property IdPerfil As Integer?

    ' Navigation properties
    Public Overridable Property Usuario As UsuarioEntity
    Public Overridable Property Perfil As PerfilEntity
End Class
