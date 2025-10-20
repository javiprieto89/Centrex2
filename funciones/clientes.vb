Imports System.Data.Entity
Imports System.Linq

Module clientes
    ' ************************************ FUNCIONES DE CLIENTES ***************************
    Public Function info_cliente(ByVal id_cliente As String) As cliente
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim clienteEntity = context.Clientes _
                    .Include(Function(c) c.ProvinciaFiscal) _
                    .Include(Function(c) c.ProvinciaEntrega) _
                    .FirstOrDefault(Function(c) c.IdCliente = CInt(id_cliente))

                If clienteEntity Is Nothing Then
                    Dim notFound As New cliente
                    notFound.razon_social = "error"
                    Return notFound
                End If

                Return cliente.FromEntity(clienteEntity)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Dim tmp As New cliente
            tmp.razon_social = "error"
            Return tmp
        End Try
    End Function

    Public Function addcliente(ByVal cl As cliente) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim clienteEntity = cl.ToEntity()

                context.Clientes.Add(clienteEntity)
                context.SaveChanges()

                cl.id_cliente = clienteEntity.IdCliente
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updatecliente(cl As cliente, Optional borra As Boolean = False) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim idCliente As Integer = cl.id_cliente
                Dim clienteEntity = context.Clientes _
                    .Include(Function(c) c.ProvinciaFiscal) _
                    .Include(Function(c) c.ProvinciaEntrega) _
                    .FirstOrDefault(Function(c) c.IdCliente = idCliente)

                If clienteEntity Is Nothing Then
                    Return False
                End If

                If borra Then
                    clienteEntity.Activo = False
                Else
                    cl.ApplyToEntity(clienteEntity)
                End If

                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function borrarcliente(cl As cliente) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim idCliente As Integer = cl.id_cliente
                Dim clienteEntity = context.Clientes.FirstOrDefault(Function(c) c.IdCliente = idCliente)

                If clienteEntity Is Nothing Then
                    Return False
                End If

                context.Clientes.Remove(clienteEntity)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Function estaClienteDefault(ByVal id_clientePedidoDefault As Integer) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Return context.Clientes.Any(Function(c) c.Activo AndAlso c.IdCliente = id_clientePedidoDefault)
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function existecliente(ByVal taxNumber As String) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim trimmedTaxNumber = If(taxNumber, String.Empty).Trim()
                Dim existing = context.Clientes _
                    .Where(Function(c) c.TaxNumber = trimmedTaxNumber) _
                    .Select(Function(c) CType(c.IdCliente, Integer?)) _
                    .FirstOrDefault()

                If existing.HasValue Then
                    Return existing.Value
                End If

                Return -1
            End Using
        Catch ex As Exception
            Return -1
        End Try
    End Function

    'Public Function info_clienteVendedor(ByVal id_cliente As String) As Integer
    '    Dim sqlstr As String
    '    Dim id_vendedor As Integer

    '    sqlstr = "SELECT c.id_vendedor " & _
    '                "FROM clientes AS c " & _
    '                "WHERE c.id_vendedor = '" + id_cliente + "'"

    '    Try
    '        'Crea y abre una nueva conexión
    '        abrirdb(serversql, basedb, usuariodb, passdb)

    '        'Propiedades del SqlCommand
    '        Dim comando As New SqlCommand
    '        With comando
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlstr
    '            .Connection = CN
    '        End With

    '        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
    '        Dim dataset As New DataSet 'Crear nuevo dataset

    '        da.SelectCommand = comando

    '        'llenar el dataset
    '        da.Fill(dataset, "Tabla")
    '        id_vendedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
    '        cerrardb()
    '        Return id_vendedor
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '        id_vendedor = -1
    '        cerrardb()
    '        Return id_vendedor
    '    End Try
    'End Function

    'Public Function existecliente(ByVal n As String, Optional ByVal a As String = "") As Integer
    '    Dim tmp As New cliente

    '    Dim sqlstr As String
    '    sqlstr = "SELECT id_cliente FROM clientes WHERE razon_social LIKE '%" + Trim(n.ToString) + Trim(a.ToString) + "%'"

    '    Try
    '        'Crea y abre una nueva conexión
    '        abrirdb(serversql, basedb, usuariodb, passdb)

    '        'Propiedades del SqlCommand
    '        Dim comando As New SqlCommand
    '        With comando
    '            .CommandType = CommandType.Text
    '            .CommandText = sqlstr
    '            .Connection = CN
    '        End With

    '        Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
    '        Dim dataset As New DataSet 'Crear nuevo dataset

    '        da.SelectCommand = comando

    '        'llenar el dataset
    '        da.Fill(dataset, "Tabla")
    '        tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(0).ToString
    '        If tmp.id_cliente = 0 Then Return -1
    '        cerrardb()
    '        Return tmp.id_cliente
    '    Catch ex As Exception
    '        tmp.razon_social = "error"
    '        cerrardb()
    '        Return -1
    '    End Try
    'End Function
    ' ************************************ FUNCIONES DE CLIENTES ***************************
End Module
