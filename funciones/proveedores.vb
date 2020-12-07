Imports System.Data
Imports System.Data.SqlClient

Module proveedores
    ' ************************************ FUNCIONES DE PROVEEDORES ***************************
    Public Function info_proveedor(ByVal id_proveedor As String) As proveedor
        Dim tmp As New proveedor
        Dim sqlstr As String

        sqlstr = "SELECT p.id_proveedor, p.razon_social, p.taxNumber, p.contacto, p.telefono, p.celular, p.email, prof.id_pais AS 'id_pais_fiscal', p.id_provincia_fiscal, p.direccion_fiscal, p.localidad_fiscal, p.cp_fiscal, " & _
                    "proe.id_pais AS 'id_pais_entrega', p.id_provincia_entrega, p.direccion_entrega, p.localidad_entrega, p.cp_entrega, p.notas, p.esInscripto, p.vendedor, p.activo, p.id_tipoDocumento " & _
                    "FROM proveedores AS p " & _
                    "INNER JOIN provincias AS prof ON p.id_provincia_fiscal = prof.id_provincia " & _
                    "INNER JOIN provincias AS proe ON p.id_provincia_entrega = proe.id_provincia " & _
                    "WHERE p.id_proveedor = '" + id_proveedor + "'"

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
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.razon_social = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.taxNumber = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.contacto = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.telefono = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.celular = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.email = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.id_pais_fiscal = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.id_provincia_fiscal = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.direccion_fiscal = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.localidad_fiscal = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.cp_fiscal = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.id_pais_entrega = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.id_provincia_entrega = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.direccion_entrega = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.localidad_entrega = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.cp_entrega = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.notas = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.esInscripto = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.vendedor = dataset.Tables("tabla").Rows(0).Item(19).ToString
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

    Public Function addproveedor(ByVal pr As proveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO proveedores (razon_social, taxNumber, contacto, telefono, celular, email, id_provincia_fiscal, direccion_fiscal, localidad_fiscal, cp_fiscal, " & _
                        "id_provincia_entrega, direccion_entrega, localidad_entrega, cp_entrega, notas, esInscripto, vendedor, activo, id_tipoDocumento) " & _
                        "VALUES ('" + pr.razon_social + "', '" + pr.taxNumber + "', '" + pr.contacto + "', '" + pr.telefono + "', '" + pr.celular + "', '" + pr.email + "', '" + pr.id_provincia_fiscal.ToString + _
                        "', '" + pr.direccion_fiscal + "', '" + pr.localidad_fiscal + "', '" + pr.cp_fiscal + "', '" + pr.id_provincia_entrega.ToString + "', '" + pr.direccion_entrega + "', '" + pr.localidad_entrega + _
                        "', '" + pr.cp_entrega + "', '" + pr.notas + "', '" + pr.esInscripto.ToString + "', '" + pr.vendedor + "', '" + pr.activo.ToString + "', '" + pr.id_tipoDocumento.ToString + "')"

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

    Public Function updateProveedor(pr As proveedor, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE proveedores SET activo = '0' WHERE id_proveedor = '" + pr.id_proveedor.ToString + "'"
            Else
                sqlstr = "UPDATE proveedores SET razon_social = '" + pr.razon_social + "', taxNumber = '" + pr.taxNumber + "', contacto = '" + pr.contacto + "', telefono = '" _
                                                + pr.telefono + "', celular = '" + pr.celular + "', email = '" + pr.email + "', id_provincia_fiscal = '" _
                                                + pr.id_provincia_fiscal.ToString + "', direccion_fiscal = '" + pr.direccion_fiscal + "', localidad_fiscal = '" _
                                                + pr.localidad_fiscal + "', cp_fiscal = '" + pr.cp_fiscal + "', id_provincia_entrega = '" + pr.id_provincia_entrega.ToString + "', direccion_entrega = '" _
                                                + pr.direccion_entrega + "', localidad_entrega = '" + pr.localidad_entrega + "', cp_entrega = '" + pr.cp_entrega + "', notas = '" _
                                                + pr.notas + "', esInscripto = '" + pr.esInscripto.ToString + "', vendedor = '" + pr.vendedor + "', activo = '" _
                                                + pr.activo.ToString + "', id_tipoDocumento = '" + pr.id_tipoDocumento.ToString + "' " _
                                                + "WHERE id_proveedor = '" + pr.id_proveedor.ToString + "'"
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

    Public Function borrarproveedor(pr As proveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            Comando = New SqlClient.SqlCommand("DELETE FROM proveedores WHERE id_proveedor = '" + pr.id_proveedor.ToString + "'", CN)
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

    'Public Function info_proveedorVendedor(ByVal id_proveedor As String) As Integer
    '    Dim sqlstr As String
    '    Dim id_vendedor As Integer

    '    sqlstr = "SELECT p.id_vendedor " & _
    '                "FROM proveedores AS p " & _
    '                "WHERE p.id_vendedor = '" + id_proveedor + "'"

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

    'Public Function existeproveedor(ByVal n As String, Optional ByVal a As String = "") As Integer
    '    Dim tmp As New proveedor

    '    Dim sqlstr As String
    '    sqlstr = "SELECT id_proveedor FROM proveedores WHERE razon_social LIKE '%" + Trim(n.ToString) + Trim(a.ToString) + "%'"

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
    '        tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(0).ToString
    '        If tmp.id_proveedor = 0 Then Return -1
    '        cerrardb()
    '        Return tmp.id_proveedor
    '    Catch ex As Exception
    '        tmp.razon_social = "error"
    '        cerrardb()
    '        Return -1
    '    End Try
    'End Function
    ' ************************************ FUNCIONES DE PROVEEDORES ***************************
End Module
