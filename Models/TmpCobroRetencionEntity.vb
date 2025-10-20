Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[tmpcobros_retenciones]
Public Class TmpCobroRetencionEntity
    <Key>
    Public Property id_tmpRetencion As Integer
    Public Property id_impuesto As Integer
    Public Property total As Decimal
    Public Property notas As String
    Public Property id_usuario As Integer
End Class

