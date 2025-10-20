Imports System.Data.SqlClient
Imports System.Data.Entity
Imports System.Linq
Module usuarios

    ' ************************************ FUNCIONES DE USUARIOS **********************
    Public Function info_usuario(ByVal id_usuario As Integer) As usuario
        Dim tmp As New usuario
        
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim usuarioEntity = context.Usuarios.FirstOrDefault(Function(u) u.IdUsuario = id_usuario)
                
                If usuarioEntity IsNot Nothing Then
                    tmp.id_usuario = usuarioEntity.IdUsuario.ToString()
                    tmp.usuario = usuarioEntity.Usuario
                    tmp.password = usuarioEntity.Password
                    tmp.nombre = usuarioEntity.Nombre
                    tmp.activo = usuarioEntity.Activo
                Else
                    tmp.usuario = "error"
                End If
            End Using
        Catch ex As Exception
            tmp.usuario = "error"
        End Try
        
        Return tmp
    End Function

    Public Function info_usuario(ByVal usuario As String, ByVal exacto As Boolean) As usuario
        Dim tmp As New usuario
        Dim sqlstr As String

        Try
            'Crea y abre una nueva conexión
            DatabaseHelper.GetConnection()

            If exacto Then
                sqlstr = "SELECT id_usuario, usuario, password, nombre, activo FROM usuarios " &
                                "WHERE usuario = '" + usuario + "'"
            Else
                sqlstr = "SELECT id_usuario, usuario, password, nombre, activo FROM usuarios " &
                                "WHERE usuario LIKE '%" + usuario + "%'"
            End If


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
            tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.usuario = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.password = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.usuario = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

    Public Function addUsuario(ByVal u As usuario) As Boolean
        DatabaseHelper.GetConnection()

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO usuarios (usuario, password, nombre, activo) " &
                    "VALUES ('" + u.usuario + "', '" + u.password + "', '" + u.nombre.ToString + "', '" + u.activo.ToString + "')"

            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function updateUsuario(ByVal u As usuario, Optional ByVal borra As Boolean = False) As Boolean
        DatabaseHelper.GetConnection()

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE usuarios SET activo = '0' WHERE id_usuario = '" + u.id_usuario.ToString + "'"
            Else
                sqlstr = "UPDATE usuarios SET usuario = '" + u.usuario + "', password = '" + u.password.ToString + "', " +
                            "nombre = '" + u.nombre + "', activo = '" + u.activo.ToString +
                            "' WHERE id_usuario = '" + u.id_usuario.ToString + "'"
            End If
            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function borrarUsuario(ByVal u As usuario) As Boolean
        DatabaseHelper.GetConnection()

        Dim sqlstr As String = ""
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "DELETE FROM usuarios WHERE id_usuario = '" + u.id_usuario.ToString + "'"
            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function add_usuario_perfil(ByVal up As usuario_perfil) As Boolean
        DatabaseHelper.GetConnection()

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO usuarios_perfiles (id_usuario, id_perfil) VALUES ('" + up.id_usuario.ToString + "', '" + up.id_perfil.ToString + "')"

            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function add_permiso_perfil(ByVal pp As perfil_permiso) As Boolean
        DatabaseHelper.GetConnection()

        Dim sqlstr As String
        Dim mytrans As SqlTransaction
        Dim Comando As New SqlCommand

        mytrans = CN.BeginTransaction()

        Try
            sqlstr = "INSERT INTO permisos_perfiles (id_permiso, id_perfil) VALUES ('" + pp.id_permiso.ToString + "', '" + pp.id_perfil.ToString + "')"

            Comando = New SqlCommand(sqlstr, CN) With {.Transaction = mytrans}
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

    Public Function info_login(ByVal usuario As String, ByVal password As String) As usuario
        Dim tmp As New usuario
        Dim sqlstr As String
        Dim e As New Encriptar

        Try
            'Crea y abre una nueva conexión
            DatabaseHelper.GetConnection()

            sqlstr = "SELECT id_usuario, usuario, password, nombre, activo FROM usuarios " &
                                "WHERE usuario = '" + usuario + "' AND password = '" + e.Encriptar(password) + "'"

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
            tmp.id_usuario = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.usuario = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.password = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.nombre = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(4).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            tmp.usuario = "error"
            cerrardb()
            Return tmp
        End Try
    End Function
    ' ************************************ FUNCIONES DE USUARIOS **********************
End Module

