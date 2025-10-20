Imports System.Data.SqlClient
Module consultasSIAP
    ' ************************************ FUNCIONES DE CONSULTAS DE SIAP **********************
    Public Function info_consultaSIAP(ByVal id_consulta As Integer) As consultaSIAP
        Dim tmp As New consultaSIAP
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            sqlstr = "SELECT c.id_consultaSiap, c.nombre, c.consulta, c.excel, c.txt, c.activo FROM consultas_SIAP AS c WHERE c.id_consultaSiap = '" + id_consulta.ToString + "'"

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
            tmp.id_consulta = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.consulta = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.excel = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.txt = dataset.Tables("tabla").Rows(0).Item(4).ToString
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
    ' ************************************ FUNCIONES DE CONSULTAS DE SIAP **********************
End Module
