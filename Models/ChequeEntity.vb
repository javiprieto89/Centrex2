' Entidad Cheque mapeada según db/dbo.cheques.Table.sql
Public Class ChequeEntity
    Public Property IdCheque As Integer
    Public Property FechaIngreso As Date
    Public Property FechaEmision As Date
    Public Property IdCliente As Integer?
    Public Property IdProveedor As Integer?
    Public Property IdBanco As Integer
    Public Property NCheque As Integer
    Public Property NCheque2 As Integer
    Public Property Importe As Decimal
    Public Property IdEstadoCh As Integer
    Public Property FechaCobro As Date?
    Public Property FechaSalida As Date?
    Public Property FechaDeposito As Date?
    Public Property Recibido As Boolean?
    Public Property Emitido As Boolean?
    Public Property IdCuentaBancaria As Integer?
    Public Property ECheck As Boolean
    Public Property Activo As Boolean

    Public Overridable Property Cliente As ClienteEntity
    Public Overridable Property Proveedor As ProveedorEntity
    Public Overridable Property Banco As BancoEntity
    Public Overridable Property CuentaBancaria As CuentaBancariaEntity
End Class

