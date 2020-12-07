Imports System.Data.SqlClient

Module impuestos

    ' ************************************ FUNCIONES DE IMPUESTOS **********************
    Public Function info_impuesto(ByVal id_impuesto) As impuesto
        Dim tmp As New impuesto
        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = "SELECT id_impuesto, nombre, porcentaje, esRetencion, esPercepcion, activo FROM impuestos WHERE id_impuesto = '" + id_impuesto.ToString + "'"
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            tmp.id_impuesto = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.porcentaje = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.esRetencion = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.esPercepcion = dataset.Tables("tabla").Rows(0).Item(4).ToString
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

    Public Function addImpuesto(ByVal i As impuesto) As Integer
        Dim sqlComm As New SqlCommand 'Comando en el resto
        Dim resultado As Integer

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            With sqlComm
                .CommandText = "SP_insertImpuesto"
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .AddWithValue("nombre", i.nombre)
                    .AddWithValue("porcentaje", i.porcentaje)
                    .AddWithValue("esRetencion", i.esRetencion)
                    .AddWithValue("esPercepcion", i.esPercepcion)
                    .AddWithValue("activo", i.activo)
                    .Add(New SqlParameter("@resultado", SqlDbType.Int)).Direction = ParameterDirection.Output
                End With
                .Connection = CN
                .ExecuteNonQuery()
            End With

            resultado = CInt(sqlComm.Parameters("@resultado").Value)
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            cerrardb()
        End Try
    End Function
    'Public Function addImpuesto(ByVal i As impuesto) As Boolean
    '    abrirdb(serversql, basedb, usuariodb, passdb)

    '    Dim sqlstr As String
    '    Dim mytrans As SqlTransaction
    '    Dim Comando As New SqlClient.SqlCommand

    '    mytrans = CN.BeginTransaction()

    '    Try
    '        sqlstr = "INSERT INTO impuestos (nombre, porcentaje, esRetencion, esPercepcion, activo) VALUES ('" + i.nombre + "', '" +
    '                    i.porcentaje.ToString + "', '" + i.esRetencion.ToString + "', '" + i.esPercepcion.ToString + "', '" + i.activo.ToString + "')"
    '        Comando = New SqlClient.SqlCommand(sqlstr, CN)

    '        Comando.Transaction = mytrans
    '        Comando.ExecuteNonQuery()

    '        mytrans.Commit()
    '        cerrardb()
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        cerrardb()
    '        Return False
    '    End Try
    'End Function

    Public Function updateImpuesto(ByVal i As impuesto, Optional borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE impuestos SET activo = '0' WHERE id_impuesto = '" + i.id_impuesto.ToString + "'"
            Else
                sqlstr = "UPDATE impuestos SET nombre = '" + i.nombre + "', porcentaje = '" + i.porcentaje.ToString +
                            "', esRetencion = '" + i.esRetencion.ToString + "', esPercepcion = '" + i.esPercepcion.ToString + "', activo = '" + i.activo.ToString +
                            "' WHERE id_impuesto = '" + i.id_impuesto.ToString + "'"
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

    Public Function borrarImpuesto(ByVal i As impuesto) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM impuestos WHERE id_impuesto = '" + i.id_impuesto.ToString + "'"
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
    ' ************************************ FUNCIONES DE IMPUESTOS **********************
End Module