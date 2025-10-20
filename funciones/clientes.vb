'Imports System.Data
Imports System.Data.SqlClient
'Imports System.Data.Entity
Imports System.Linq

Module clientes
    ' ************************************ FUNCIONES DE CLIENTES ***************************
    Public Function info_cliente(ByVal id_cliente As String) As cliente
        Dim tmp As New cliente
        
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim clienteEntity = context.Clientes.Include(Function(c) c.ProvinciaFiscal) _
                    .Include(Function(c) c.ProvinciaEntrega) _
                    .FirstOrDefault(Function(c) c.IdCliente = CInt(id_cliente))
                
                If clienteEntity IsNot Nothing Then
                    tmp.id_cliente = clienteEntity.IdCliente.ToString()
                    tmp.razon_social = clienteEntity.RazonSocial
                    tmp.nombre_fantasia = clienteEntity.NombreFantasia
                    tmp.taxNumber = clienteEntity.TaxNumber
                    tmp.contacto = clienteEntity.Contacto
                    tmp.telefono = clienteEntity.Telefono
                    tmp.celular = clienteEntity.Celular
                    tmp.email = clienteEntity.Email
                    tmp.id_pais_fiscal = clienteEntity.IdPaisFiscal
                    tmp.id_provincia_fiscal = clienteEntity.IdProvinciaFiscal
                    tmp.direccion_fiscal = clienteEntity.DireccionFiscal
                    tmp.localidad_fiscal = clienteEntity.LocalidadFiscal
                    tmp.cp_fiscal = clienteEntity.CpFiscal
                    tmp.id_pais_entrega = clienteEntity.IdPaisEntrega
                    tmp.id_provincia_entrega = clienteEntity.IdProvinciaEntrega
                    tmp.direccion_entrega = clienteEntity.DireccionEntrega
                    tmp.localidad_entrega = clienteEntity.LocalidadEntrega
                    tmp.cp_entrega = clienteEntity.CpEntrega
                    tmp.notas = clienteEntity.Notas
                    tmp.esInscripto = clienteEntity.EsInscripto
                    tmp.activo = clienteEntity.Activo
                    tmp.id_tipoDocumento = clienteEntity.IdTipoDocumento
                    tmp.id_claseFiscal = clienteEntity.IdClaseFiscal
                Else
                    tmp.razon_social = "error"
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.razon_social = "error"
        End Try
        
        Return tmp
    End Function

    Public Function addcliente(ByVal cl As cliente) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim clienteEntity As New ClienteEntity()
                
                With clienteEntity
                    .RazonSocial = cl.razon_social
                    .NombreFantasia = cl.nombre_fantasia
                    .TaxNumber = cl.taxNumber
                    .Contacto = cl.contacto
                    .Telefono = cl.telefono
                    .Celular = cl.celular
                    .Email = cl.email
                    .IdProvinciaFiscal = cl.id_provincia_fiscal
                    .DireccionFiscal = cl.direccion_fiscal
                    .LocalidadFiscal = cl.localidad_fiscal
                    .CpFiscal = cl.cp_fiscal
                    .IdProvinciaEntrega = cl.id_provincia_entrega
                    .DireccionEntrega = cl.direccion_entrega
                    .LocalidadEntrega = cl.localidad_entrega
                    .CpEntrega = cl.cp_entrega
                    .Notas = cl.notas
                    .EsInscripto = cl.esInscripto
                    .Activo = cl.activo
                    .IdTipoDocumento = cl.id_tipoDocumento
                    .IdClaseFiscal = cl.id_claseFiscal
                End With
                
                context.Clientes.Add(clienteEntity)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updatecliente(cl As cliente, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE clientes SET activo = '0' WHERE id_cliente = '" + cl.id_cliente.ToString + "'"
            Else
                With cl
                    sqlstr = "UPDATE clientes SET razon_social = '" + .razon_social + "', nombre_fantasia = '" + .nombre_fantasia + "', taxNumber = '" + .taxNumber + "', contacto = '" + .contacto + "', telefono = '" _
                                                + .telefono + "', celular = '" + .celular + "', email = '" + .email + "', id_provincia_fiscal = '" + .id_provincia_fiscal.ToString + "', direccion_fiscal = '" _
                                                + .direccion_fiscal + "', localidad_fiscal = '" + .localidad_fiscal + "', cp_fiscal = '" + .cp_fiscal + "', id_provincia_entrega = '" + .id_provincia_entrega.ToString + "', direccion_entrega = '" _
                                                + .direccion_entrega + "', localidad_entrega = '" + .localidad_entrega + "', cp_entrega = '" + .cp_entrega + "', notas = '" + .notas + "', esInscripto = '" + .esInscripto.ToString + "', activo = '" _
                                                + .activo.ToString + "', id_tipoDocumento = '" + .id_tipoDocumento.ToString + "', id_claseFiscal = '" + .id_claseFiscal.ToString + "' " _
                                                + "WHERE id_cliente = '" + .id_cliente.ToString + "'"
                End With
            End If

            Comando = New SqlClient.SqlCommand(sqlstr, CN)

            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function borrarcliente(cl As cliente) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM clientes WHERE id_cliente = '" + cl.id_cliente.ToString + "'", CN)
            Comando.Transaction = mytrans
            Comando.ExecuteNonQuery()

            mytrans.Commit()
            cerrardb()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return False
        End Try
    End Function

    Public Function estaClienteDefault(ByVal id_clientePedidoDefault As Integer) As Boolean
        Dim tmp As New cliente
        Dim sqlstr As String

        sqlstr = "SELECT c.id_cliente AS 'id_cliente', c.razon_social AS 'razon_social' " &
                   "FROM clientes AS c " &
                    "WHERE c.activo = '1' AND c.id_cliente = '" + id_clientePedidoDefault.ToString + "' " &
                    "ORDER BY c.razon_social ASC"

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(0).ToString
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    Public Function existecliente(ByVal taxNumber As String) As Integer
        Dim tmp As New cliente

        Dim sqlstr As String
        sqlstr = "SELECT id_cliente FROM clientes WHERE taxNumber = '" + Trim(taxNumber.ToString) + "'"

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_cliente = dataset.Tables("tabla").Rows(0).Item(0).ToString
            If tmp.id_cliente = 0 Then Return -1
            cerrardb()
            Return tmp.id_cliente
        Catch ex As Exception
            tmp.razon_social = "error"
            cerrardb()
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
