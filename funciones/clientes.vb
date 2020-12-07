Imports System.Data
Imports System.Data.SqlClient

Module clientes
    ' ************************************ FUNCIONES DE CLIENTES ***************************
    Public Function info_cliente(ByVal id_cliente As String) As cliente
        Dim tmp As New cliente
        Dim sqlstr As String

        sqlstr = "SELECT c.id_cliente, c.razon_social, c.nombre_fantasia, c.taxNumber, c.contacto, c.telefono, c.celular, c.email, prof.id_pais AS 'id_pais_fiscal', " & _
                    "c.id_provincia_fiscal, c.direccion_fiscal, c.localidad_fiscal, c.cp_fiscal, " & _
                    "proe.id_pais AS 'id_pais_entrega', c.id_provincia_entrega, c.direccion_entrega, c.localidad_entrega, c.cp_entrega, c.notas, c.esInscripto, c.activo, c.id_tipoDocumento " & _
                    "FROM clientes AS c " & _
                    "INNER JOIN provincias AS prof ON c.id_provincia_fiscal = prof.id_provincia " & _
                    "INNER JOIN provincias AS proe ON c.id_provincia_entrega = proe.id_provincia " & _
                    "WHERE c.id_cliente = '" + id_cliente + "'"

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
            tmp.razon_social = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.nombre_fantasia = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.taxNumber = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.contacto = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.telefono = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.celular = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.email = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.id_pais_fiscal = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.id_provincia_fiscal = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.direccion_fiscal = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.localidad_fiscal = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.cp_fiscal = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.id_pais_entrega = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.id_provincia_entrega = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.direccion_entrega = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.localidad_entrega = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.cp_entrega = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.esInscripto = dataset.Tables("tabla").Rows(0).Item(19).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(20).ToString
            tmp.id_tipoDocumento = dataset.Tables("tabla").Rows(0).Item(21).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.razon_social = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addcliente(ByVal cl As cliente) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            With cl
                sqlstr = "INSERT INTO clientes (razon_social, nombre_fantasia, taxNumber, contacto, telefono, celular, email, id_provincia_fiscal, direccion_fiscal, localidad_fiscal, cp_fiscal, " & _
                        "id_provincia_entrega, direccion_entrega, localidad_entrega, cp_entrega, notas, esInscripto, activo, id_tipoDocumento) " & _
                        "VALUES ('" + .razon_social + "', '" + .nombre_fantasia + "', '" + .taxNumber + "', '" + .contacto + "', '" + .telefono + "', '" + .celular + "', '" + .email + "', '" + .id_provincia_fiscal.ToString + _
                        "', '" + .direccion_fiscal + "', '" + .localidad_fiscal + "', '" + cl.cp_fiscal + "', '" + .id_provincia_entrega.ToString + "', '" + .direccion_entrega + "', '" + .localidad_entrega + _
                        "', '" + .cp_entrega + "', '" + .notas + "', '" + .esInscripto.ToString + "', '" + .activo.ToString + "', '" + .id_tipoDocumento.ToString + "')"
            End With
            

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
                                                + .activo.ToString + "', id_tipoDocumento = '" + .id_tipoDocumento.ToString + "' " _
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
