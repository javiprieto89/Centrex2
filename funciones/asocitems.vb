Imports System.Data.SqlClient

Module asocitems
    ' ************************************ FUNCIONES DE ITEMS ASOCIADOS ***************************
    Public Function info_asocItem(ByVal id_item As String, ByVal id_asocItem As String) As asocItem
        Dim tmp As New asocItem
        Try
            Using ctx As New CentrexDbContext()
                Dim ent = ctx.AsocItems.AsNoTracking().FirstOrDefault(Function(a) a.IdItem = CInt(id_item) AndAlso a.IdItemAsociado = CInt(id_asocItem))
                If ent Is Nothing Then
                    tmp.id_item = -1
                    Return tmp
                End If
                tmp.id_item = ent.IdItem
                tmp.id_item_asoc = ent.IdItemAsociado
                tmp.cantidad = ent.Cantidad
                Return tmp
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            tmp.id_item = -1
            Return tmp
        End Try
    End Function

    Public Function addAsocItem(it As asocItem) As Boolean
        Try
            Using ctx As New CentrexDbContext()
                Dim ent As New AsocItemEntity With {
                    .IdItem = it.id_item,
                    .IdItemAsociado = it.id_item_asoc,
                    .Cantidad = it.cantidad
                }
                ctx.AsocItems.Add(ent)
                ctx.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateAsocItem(it As asocItem, Optional borra As Boolean = False) As Boolean
        Try
            Using ctx As New CentrexDbContext()
                Dim ent = ctx.AsocItems.FirstOrDefault(Function(a) a.IdItem = it.id_item AndAlso a.IdItemAsociado = it.id_item_asoc)
                If ent Is Nothing Then Return False
                ent.Cantidad = it.cantidad
                ctx.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function borrarAsocItem(it As asocItem) As Boolean
        Try
            Using ctx As New CentrexDbContext()
                Dim ent = ctx.AsocItems.FirstOrDefault(Function(a) a.IdItem = it.id_item AndAlso a.IdItemAsociado = it.id_item_asoc)
                If ent Is Nothing Then Return False
                ctx.AsocItems.Remove(ent)
                ctx.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Function Tiene_Items_Asociados(ByVal id_item As String) As Boolean
        Try
            Using ctx As New CentrexDbContext()
                Return ctx.AsocItems.AsNoTracking().Any(Function(a) a.IdItem = CInt(id_item))
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Function Traer_Cantidades_Enviadas_Items_Asociados_Default_Produccion(ByVal id_item As String, Optional ByVal id_produccion As Integer = -1) As DataTable
        Dim sqlstr As String

        'sqlstr = "SELECT i.item AS 'Producto', tpi.cantidad AS 'Cantidad', ii.descript AS 'Producto asociado', ai.cantidad * tpi.cantidad  AS 'Cantidad enviada', " &
        '        "tpi.id_tmpProduccionItem AS 'id_tmpProduccionItem', ai.id_item AS 'id_item', ai.id_item_asoc AS 'id_item_asoc' " &
        '        "FROM asocItems AS ai " &
        '        "INNER JOIN tmpproduccion_items AS tpi ON ai.id_item = tpi.id_item " &
        '        "INNER JOIN items AS i ON ai.id_item = i.id_item " &
        '        "INNER JOIN items AS ii ON ai.id_item_asoc = ii.id_item " &
        '        "WHERE ai.id_item = '" + id_item + "'"


        If id_produccion = -1 Then
            sqlstr = "SELECT i.item AS 'Producto', tpi.cantidad AS 'Cantidad', ii.descript AS 'Producto asociado', ai.cantidad * tpi.cantidad  AS 'Cantidad enviada', " &
                    "tpi.id_tmpProduccionItem AS 'id_tmpProduccionItem', ai.id_item AS 'id_item', ai.id_item_asoc AS 'id_item_asoc' " &
                    "FROM asocItems AS ai " &
                    "INNER JOIN tmpproduccion_items AS tpi ON ai.id_item = tpi.id_item " &
                    "INNER JOIN items AS i ON ai.id_item = i.id_item " &
                    "INNER JOIN items AS ii ON ai.id_item_asoc = ii.id_item " &
                    "WHERE ai.id_item = '" + id_item + "'"
        Else
            sqlstr = "SELECT DISTINCT i.item AS 'Producto', pi.cantidad AS 'Cantidad', ii.descript AS 'Producto asociado', pai.cantidad_item_asoc_enviada  AS 'Cantidad enviada', " &
                    "pai.id_item AS 'id_item', pai.id_item_asoc AS 'id_item_asoc' " &
                    "FROM produccion_asocItems AS pai " &
                    "INNER JOIN produccion_items AS pi ON pai.id_item = pi.id_item " &
                    "INNER JOIN items AS i ON pai.id_item = i.id_item " &
                    "INNER JOIN items AS ii ON pai.id_item_asoc = ii.id_item " &
                    "WHERE pai.id_item = '" + id_item + "' AND pai.id_produccion = '" + id_produccion.ToString + "'"
        End If
        Try
            Using ctx As New CentrexDbContext()
                If id_produccion = -1 Then
                    Dim query = From ai In ctx.AsocItems.AsNoTracking()
                                Join tpi In ctx.TmpProduccionItems.AsNoTracking() On ai.IdItem Equals tpi.IdItem
                                Join i In ctx.Items.AsNoTracking() On ai.IdItem Equals i.IdItem
                                Join ii In ctx.Items.AsNoTracking() On ai.IdItemAsociado Equals ii.IdItem
                                Where ai.IdItem = CInt(id_item)
                                Select New With { .Producto = i.Item, .Cantidad = tpi.Cantidad, .Producto_asociado = ii.Descript, .Cantidad_enviada = ai.Cantidad * tpi.Cantidad,
                                                  .id_tmpProduccionItem = tpi.IdTmpProduccionItem, .id_item = ai.IdItem, .id_item_asoc = ai.IdItemAsociado }
                    Return ToDataTable(query)
                Else
                    Dim query2 = (From pai In ctx.ProduccionAsocItems.AsNoTracking()
                                  Join pi In ctx.ProduccionItems.AsNoTracking() On pai.id_item Equals pi.id_item
                                  Join i In ctx.Items.AsNoTracking() On pai.id_item Equals i.IdItem
                                  Join ii In ctx.Items.AsNoTracking() On pai.id_item_asoc Equals ii.IdItem
                                  Where pai.id_item = CInt(id_item) AndAlso pai.id_produccion = id_produccion
                                  Select New With { .Producto = i.Item, .Cantidad = pi.Cantidad, .Producto_asociado = ii.Descript, .Cantidad_enviada = pai.cantidad,
                                                    .id_item = pai.id_item, .id_item_asoc = pai.id_item_asoc }).Distinct()
                    Return ToDataTable(query2)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return Nothing
        End Try
    End Function
End Module
