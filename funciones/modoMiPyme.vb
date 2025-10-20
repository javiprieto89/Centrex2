Imports System.Data.SqlClient

Module modosMiPyme
    Public Function info_modoMiPyme(ByVal id_modoMiPyme As Integer) As modoMiPyme
        Dim tmp As New modoMiPyme
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand

            sqlstr = "SELECT id_modoMiPyme, modo, abreviatura FROM sys_modoMiPyme WHERE id_modoMiPyme = '" + id_modoMiPyme.ToString + "' "

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
            tmp.id_modoMiPyme = dataset.Tables("tabla").Rows(0).Item(0)
            tmp.modo = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.abreviatura = dataset.Tables("tabla").Rows(0).Item(2).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            cerrardb()
            Return tmp
        End Try
    End Function
End Module
