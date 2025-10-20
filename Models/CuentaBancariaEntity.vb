' Entidad Cuenta Bancaria mapeada según db/dbo.cuentas_bancarias.Table.sql
Public Class CuentaBancariaEntity
    Public Property IdCuentaBancaria As Integer
    Public Property IdBanco As Integer
    Public Property Nombre As String
    Public Property IdMoneda As Integer
    Public Property Saldo As Decimal?
    Public Property Activo As Boolean

    Public Overridable Property Banco As BancoEntity
End Class

