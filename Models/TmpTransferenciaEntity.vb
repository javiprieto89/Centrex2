Imports System
Imports System.ComponentModel.DataAnnotations

' Entidad para [dbo].[tmptransferencias]
Public Class TmpTransferenciaEntity
    <Key>
    Public Property id_tmpTransferencia As Integer
    Public Property id_cuentaBancaria As Integer
    Public Property fecha As DateTime
    Public Property total As Decimal
    Public Property notas As String
    Public Property id_usuario As Integer
End Class

