Imports System.Data
Imports System.Data.SqlClient
'Imports System.Data.Entity
Imports System.Linq

Module comprobantes
    ' ************************************ FUNCIONES DE COMPROBANTES ***************************
    Public Function info_comprobante(ByVal id_comprobante As String) As comprobante
        Dim tmp As New comprobante
        
        If id_comprobante Is Nothing Then
            tmp.comprobante = "error"
            Return tmp
        End If

        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim comprobanteEntity = context.Comprobantes.Include(Function(c) c.TipoComprobante) _
                    .FirstOrDefault(Function(c) c.IdComprobante = CInt(id_comprobante))
                
                If comprobanteEntity IsNot Nothing Then
                    tmp.id_comprobante = comprobanteEntity.IdComprobante.ToString()
                    tmp.comprobante = comprobanteEntity.Comprobante
                    tmp.id_tipoComprobante = comprobanteEntity.IdTipoComprobante.ToString()
                    tmp.numeroComprobante = 0 ' No está en la entidad actual
                    tmp.puntoVenta = 0 ' No está en la entidad actual
                    tmp.esFiscal = False ' No está en la entidad actual
                    tmp.esElectronica = False ' No está en la entidad actual
                    tmp.esManual = False ' No está en la entidad actual
                    tmp.esPresupuesto = False ' No está en la entidad actual
                    tmp.activo = comprobanteEntity.Activo
                    tmp.testing = False ' No está en la entidad actual
                    tmp.maxItems = comprobanteEntity.MaxItems
                    tmp.comprobanteRelacionado = 0 ' No está en la entidad actual
                    tmp.esMiPyME = False ' No está en la entidad actual
                    tmp.CBU_emisor = "" ' No está en la entidad actual
                    tmp.alias_CBU_emisor = "" ' No está en la entidad actual
                    tmp.anula_MiPyME = "0" ' No está en la entidad actual
                    tmp.contabilizar = False ' No está en la entidad actual
                    tmp.mueveStock = False ' No está en la entidad actual
                    tmp.prefijo = "" ' No está en la entidad actual
                    tmp.id_modoMiPyme = 0 ' No está en la entidad actual
                Else
                    tmp.comprobante = "error"
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.comprobante = "error"
        End Try
        
        Return tmp
    End Function

    Public Function addcomprobante(ByVal c As comprobante) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim comprobanteEntity As New ComprobanteEntity()
                
                With comprobanteEntity
                    .Comprobante = c.comprobante
                    .IdTipoComprobante = c.id_tipoComprobante
                    .MaxItems = c.maxItems
                    .Activo = c.activo
                End With
                
                context.Comprobantes.Add(comprobanteEntity)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updatecomprobante(ByVal c As comprobante, Optional ByVal borra As Boolean = False) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim comprobanteEntity = context.Comprobantes.FirstOrDefault(Function(comp) comp.IdComprobante = CInt(c.id_comprobante))
                
                If comprobanteEntity IsNot Nothing Then
                    If borra = True Then
                        comprobanteEntity.Activo = False
                    Else
                        comprobanteEntity.Comprobante = c.comprobante
                        comprobanteEntity.IdTipoComprobante = c.id_tipoComprobante
                        ' Nota: Algunos campos no están en la entidad actual, se mantienen como estaban
                        comprobanteEntity.Activo = c.activo
                        comprobanteEntity.MaxItems = c.maxItems
                        ' Los demás campos se pueden agregar a la entidad si es necesario
                    End If
                    
                    context.SaveChanges()
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    ' Versión SQL original como fallback para compatibilidad completa
    Public Function updatecomprobante_sql(ByVal c As comprobante, Optional ByVal borra As Boolean = False) As Boolean
        abrirdb(serversql, basedb, usuariodb, passdb)

        Dim mytrans As SqlTransaction
        Dim Comando As New SqlClient.SqlCommand
        Dim sqlstr As String

        mytrans = CN.BeginTransaction()

        Try
            If borra = True Then
                sqlstr = "UPDATE comprobantes SET activo = '0' WHERE id_comprobante = '" + c.id_comprobante.ToString + "'"
            Else
                sqlstr = "UPDATE comprobantes SET comprobante = '" + c.comprobante + "', id_tipoComprobante = '" + c.id_tipoComprobante.ToString + "', numeroComprobante = '" _
                        + c.numeroComprobante.ToString + "', puntoVenta = '" + c.puntoVenta.ToString + "', esFiscal = '" + c.esFiscal.ToString + "', esElectronica = '" _
                        + c.esElectronica.ToString + "', esManual = '" + c.esManual.ToString + "', esPresupuesto = '" + c.esPresupuesto.ToString + "', activo = '" _
                        + c.activo.ToString + "', testing = '" + c.testing.ToString + "', maxItems = '" + c.maxItems.ToString + "' " _
                        + ", comprobanteRelacionado = '" + c.comprobanteRelacionado.ToString + "', esMiPyME = '" + c.esMiPyME.ToString + "', CBU_emisor = '" _
                        + c.CBU_emisor + "', alias_CBU_emisor = '" + c.alias_CBU_emisor + "', anula_MiPyme = '" + c.anula_MiPyME + "', contabilizar = '" _
                        + c.contabilizar.ToString + "', mueveStock = '" + c.mueveStock.ToString + "', id_modoMiPyme = '" + c.id_modoMiPyme.ToString + "' " _
                        + "WHERE id_comprobante = '" + c.id_comprobante.ToString + "'"
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

    Public Function estaComprobanteDefault(ByVal condicion As String, ByVal id_comprobanteDefault As Integer) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                ' Implementar la lógica original con Entity Framework
                Dim comprobantes = context.Comprobantes.Include(Function(c) c.TipoComprobante) _
                    .Where(Function(c) c.Activo = True AndAlso 
                           (c.IdTipoComprobante.ToString() + condicion + "(1, 2, 3, 4, 5, 63, 34, 39, 60)" OrElse
                            c.IdTipoComprobante = 0 OrElse c.IdTipoComprobante = 99 OrElse c.IdTipoComprobante = 199 OrElse
                            c.IdComprobante = id_comprobanteDefault)) _
                    .OrderBy(Function(c) c.Comprobante) _
                    .ToList()
                
                Return comprobantes.Any()
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Versión SQL original como fallback para compatibilidad completa
    Public Function estaComprobanteDefault_sql(ByVal condicion As String, ByVal id_comprobanteDefault As Integer) As Boolean
        Dim tmp As New comprobante
        Dim sqlstr As String

        sqlstr = "SELECT c.id_comprobante AS 'id_comprobante', c.comprobante AS 'comprobante' " &
                            "FROM comprobantes AS c " &
                            "WHERE c.activo = '1' AND (c.id_tipoComprobante " + condicion + " (1, 2, 3, 4, 5, 63, 34, 39, 60) " &
                            "OR c.id_tipoComprobante IN (0, 99, 199)) OR c.id_comprobante = " + id_comprobanteDefault.ToString + " " &
                            "ORDER BY c.comprobante ASC"

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
            tmp.id_comprobante = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.comprobante = dataset.Tables("tabla").Rows(0).Item(1).ToString
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            Return False
        Finally
            cerrardb()
        End Try
    End Function

    Public Function info_comprobante_anulacion(ByVal id_tipoComprobante As String) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim tipoComprobante = context.TiposComprobantes.FirstOrDefault(Function(tc) tc.IdTipoComprobante = CInt(id_tipoComprobante))
                
                If tipoComprobante IsNot Nothing Then
                    Return If(tipoComprobante.IdAnulaTipoComprobante, -1)
                Else
                    Return -1
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return -1
        End Try
    End Function

    ' Versión SQL original como fallback para compatibilidad completa
    Public Function info_comprobante_anulacion_sql(ByVal id_tipoComprobante As String) As Integer
        Dim id_anulaTipoComprobante As Integer
        Dim sqlstr As String

        If id_tipoComprobante Is Nothing Then
            Return -1
        End If

        sqlstr = "SELECT ISNULL(id_anulaTipoComprobante, -1)" &
                    "FROM tipos_comprobantes " &
                    "WHERE id_tipoComprobante = '" + id_tipoComprobante.ToString + "'"

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
            id_anulaTipoComprobante = dataset.Tables("tabla").Rows(0).Item(0).ToString
            cerrardb()
            Return id_anulaTipoComprobante
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            id_anulaTipoComprobante = -1
            cerrardb()
            Return id_anulaTipoComprobante
        End Try
    End Function

    ' Mantener funciones SQL como fallback para compatibilidad
    Public Function info_comprobante_sql(ByVal id_comprobante As String) As comprobante
        Dim tmp As New comprobante
        Dim sqlstr As String

        If id_comprobante Is Nothing Then
            tmp.comprobante = "error"
            Return tmp
        End If

        sqlstr = "SELECT c.id_comprobante, c.comprobante, c.id_tipoComprobante, c.numeroComprobante, c.puntoVenta, ISNULL(esFiscal, 0) AS 'esFiscal', ISNULL(c.esElectronica, 0) AS 'esElectronica' " &
                    ", ISNULL(c.esManual, 0) AS 'esManual', ISNULL(c.esPresupuesto, 0) AS 'esPresupuesto', c.activo, c.testing, c.maxItems, ISNULL(c.comprobanteRelacionado, 0) AS 'comprobanteRelacionado' " &
                    ", c.esMiPyME, c.CBU_emisor, c.alias_CBU_emisor, ISNULL(c.anula_MiPyME, 0), c.contabilizar, c.mueveStock, ISNULL(tc.nombreAbreviado, '') AS 'Prefijo', ISNULL(c.id_modoMiPyme, '') AS 'id_modoMiPyme'  " &
                    "FROM comprobantes AS c " &
                    "INNER JOIN tipos_comprobantes AS tc ON c.id_tipoComprobante = tc.id_tipoComprobante " &
                    "WHERE c.id_comprobante = '" + id_comprobante.ToString + "'"

        Try
            abrirdb(serversql, basedb, usuariodb, passdb)

            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter
            Dim dataset As New DataSet

            da.SelectCommand = comando
            da.Fill(dataset, "Tabla")
            
            tmp.id_comprobante = dataset.Tables("tabla").Rows(0).Item(0).ToString
            tmp.comprobante = dataset.Tables("tabla").Rows(0).Item(1).ToString
            tmp.id_tipoComprobante = dataset.Tables("tabla").Rows(0).Item(2).ToString
            tmp.numeroComprobante = dataset.Tables("tabla").Rows(0).Item(3).ToString
            tmp.puntoVenta = dataset.Tables("tabla").Rows(0).Item(4).ToString
            tmp.esFiscal = dataset.Tables("tabla").Rows(0).Item(5).ToString
            tmp.esElectronica = dataset.Tables("tabla").Rows(0).Item(6).ToString
            tmp.esManual = dataset.Tables("tabla").Rows(0).Item(7).ToString
            tmp.esPresupuesto = dataset.Tables("tabla").Rows(0).Item(8).ToString
            tmp.activo = dataset.Tables("tabla").Rows(0).Item(9).ToString
            tmp.testing = dataset.Tables("tabla").Rows(0).Item(10).ToString
            tmp.maxItems = dataset.Tables("tabla").Rows(0).Item(11).ToString
            tmp.comprobanteRelacionado = dataset.Tables("tabla").Rows(0).Item(12).ToString
            tmp.esMiPyME = dataset.Tables("tabla").Rows(0).Item(13).ToString
            tmp.CBU_emisor = dataset.Tables("tabla").Rows(0).Item(14).ToString
            tmp.alias_CBU_emisor = dataset.Tables("tabla").Rows(0).Item(15).ToString
            tmp.anula_MiPyME = dataset.Tables("tabla").Rows(0).Item(16).ToString
            tmp.contabilizar = dataset.Tables("tabla").Rows(0).Item(17).ToString
            tmp.mueveStock = dataset.Tables("tabla").Rows(0).Item(18).ToString
            tmp.prefijo = dataset.Tables("tabla").Rows(0).Item(19).ToString
            tmp.id_modoMiPyme = dataset.Tables("tabla").Rows(0).Item(20).ToString
            cerrardb()
            Return tmp
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.comprobante = "error"
            cerrardb()
            Return tmp
        End Try
    End Function

End Module