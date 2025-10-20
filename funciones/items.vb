Imports System.Data.Entity
Imports System.Linq

Module mitem
    ' ************************************ FUNCIONES DE ITEMS ***************************
    Public Function info_item(ByVal id_item As String) As ItemEntity
        Try
            Using context As New CentrexDbContext()
                Return context.Items _
                    .Include(Function(i) i.Marca) _
                    .Include(Function(i) i.Tipo) _
                    .Include(Function(i) i.Proveedor) _
                    .FirstOrDefault(Function(i) i.IdItem = CInt(id_item))
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return Nothing
        End Try
    End Function

    Public Function info_itemDesc(ByVal descript As String) As ItemEntity
        Try
            Using context As New CentrexDbContext()
                Return context.Items _
                    .Include(Function(i) i.Marca) _
                    .Include(Function(i) i.Tipo) _
                    .Include(Function(i) i.Proveedor) _
                    .FirstOrDefault(Function(i) i.Descript = descript)
            End Using
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            Return Nothing
        End Try
    End Function

    Public Function info_itemtmp(ByVal _idItem As String, ByVal _idUsuario As Integer, ByVal _idUnico As String) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim idItemInt As Integer = CInt(_idItem)

                Dim exists = context.TmpPedidoItems _
                    .Any(Function(t) t.IdItem = idItemInt AndAlso
                                     t.IdUsuario = _idUsuario AndAlso
                                     t.IdUnico = _idUnico)

                Return exists
            End Using
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Function additem(it As ItemEntity) As Boolean
        Try
            Using context As New CentrexDbContext()
                context.Items.Add(it)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function addItemIVA(ByVal ii As ItemImpuestoEntity) As Boolean
        Try
            Using context As New CentrexDbContext()
                context.ItemsImpuestos.Add(ii)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function infoItem_lastItem() As ItemEntity
        Try
            Using context As New CentrexDbContext()
                Return context.Items _
                    .Include(Function(i) i.Marca) _
                    .Include(Function(i) i.Tipo) _
                    .Include(Function(i) i.Proveedor) _
                    .OrderByDescending(Function(i) i.IdItem) _
                    .FirstOrDefault()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return Nothing
        End Try
    End Function

    Public Function updateitem(it As ItemEntity, Optional borra As Boolean = False) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim itemEntity = context.Items.FirstOrDefault(Function(i) i.IdItem = it.IdItem)

                If itemEntity IsNot Nothing Then
                    If borra = True Then
                        ' Solo actualizar el campo activo
                        itemEntity.Activo = False
                    Else
                        ' Actualizar todos los campos
                        context.Entry(itemEntity).CurrentValues.SetValues(it)
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

    Public Function borraritem(it As ItemEntity) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim itemEntity = context.Items.FirstOrDefault(Function(i) i.IdItem = it.IdItem)

                If itemEntity IsNot Nothing Then
                    context.Items.Remove(itemEntity)
                    context.SaveChanges()
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Function existeitem(ByVal i As String) As Integer
        Try
            Using context As New CentrexDbContext()
                Dim itemEntity = context.Items _
                    .FirstOrDefault(Function(item) item.Item.Contains(i))

                If itemEntity IsNot Nothing Then
                    Return itemEntity.IdItem
                Else
                    Return -1
                End If
            End Using
        Catch ex As Exception
            Return -1
        End Try
    End Function
    ' ************************************ FUNCIONES DE ITEMS ***************************
End Module
