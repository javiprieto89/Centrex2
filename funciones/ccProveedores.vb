Imports System.Data.SqlClient

Module ccProveedores

    ' ************************************ FUNCIONES DE CUENTAS CORRIENTES DE PROVEEDORES **********************
    Public Function info_ccProveedor(ByVal id_cc As Integer) As ccProveedor
        Dim tmp As New ccProveedor
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT * FROM cc_proveedores WHERE id_cc = '" + id_cc.ToString + "'"

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
            tmp.id_cc = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.id_proveedor = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_moneda = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.saldo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(5).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.nombre = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addCCProveedor(ByVal cc As ccProveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO cc_proveedores (id_proveedor, id_moneda, nombre, saldo, activo) VALUES ('" + cc.id_proveedor.ToString + "', '" + cc.id_moneda.ToString + "', '" + cc.nombre + "', '" + cc.saldo.ToString + "', '" + cc.activo.ToString + "')"
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

    Public Function updateCCProveedor(ByVal cc As ccProveedor, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE cc_proveedores SET activo = '0' WHERE id_cc = '" + cc.id_cc.ToString + "'"
            Else
                sqlstr = "UPDATE cc_proveedores SET id_proveedor = '" + cc.id_proveedor.ToString + "', id_moneda = '" + cc.id_moneda.ToString + "', nombre = '" + cc.nombre + "', saldo = '" + cc.saldo.ToString + "', activo = '" + cc.activo.ToString +
                                               "' WHERE id_cc = '" + cc.id_cc.ToString + "'"
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

    Public Function borrarccProveedor(ByVal cc As ccProveedor) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM cc_proveedores WHERE id_cc = '" + cc.id_cc.ToString + "'"
            Comando = New SqlClient.SqlCommand(sqlstr, CN)
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


    ' ************************************ FUNCIONES DE CUENTAS CORRIENTES DE PROVEEDORES **********************
End Module
