Imports System.Data.Entity
Imports System.Linq

''' <summary>
''' Repositorio de operaciones para la tabla "pedidos" usando Entity Framework 6
''' </summary>
Public Class Pedidos

    ''' <summary>
    ''' Obtiene la información de un pedido (último o por ID)
    ''' </summary>
    Public Shared Function InfoPedido(Optional id_pedido As Integer? = Nothing) As PedidoEntity
        Using context As New CentrexDbContext()
            Dim query = context.Pedidos _
                .Include(Function(p) p.Cliente) _
                .Include(Function(p) p.Comprobante) _
                .Include(Function(p) p.TipoComprobante) _
                .Include(Function(p) p.Usuario) _
                .Include(Function(p) p.PedidoItems)

            If id_pedido.HasValue Then
                Return query.FirstOrDefault(Function(p) p.IdPedido = id_pedido.Value)
            Else
                Return query.OrderByDescending(Function(p) p.IdPedido).FirstOrDefault()
            End If
        End Using
    End Function

    ''' <summary>
    ''' Agrega un nuevo pedido
    ''' </summary>
    Public Function AddPedido(p As PedidoEntity) As Boolean
        Try
            Using context As New CentrexDbContext()
                context.Pedidos.Add(p)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al agregar pedido: {ex.Message}")
            Return False
        End Try
    End Function

    Public Shared Function GuardarPedido(idUsuario As Integer, idUnico As String, idPedido As Integer) As Boolean
        Try
            Using context As New CentrexDbContext()
                ' Incluir los ítems del pedido definitivo y los temporales
                Dim pedido = context.Pedidos.
                Include(Function(p) p.PedidoItems).
                FirstOrDefault(Function(p) p.IdPedido = idPedido)

                If pedido Is Nothing Then
                    MsgBox("Pedido no encontrado.")
                    Return False
                End If

                ' Obtener ítems temporales activos del usuario
                Dim itemsTemporales = context.TempPedidosItems.
                Where(Function(t) t.Activo = True AndAlso
                                   t.IdUsuario = idUsuario AndAlso
                                   t.IdUnico = idUnico).
                ToList()

                ' --- 1️⃣ Actualizar ítems existentes ---
                For Each tmp In itemsTemporales
                    Dim existente = pedido.PedidoItems.FirstOrDefault(Function(pi) pi.IdItem = tmp.IdItem)
                    If existente IsNot Nothing Then
                        existente.Cantidad = tmp.Cantidad
                        existente.Descript = tmp.Descript
                        existente.Precio = tmp.Precio
                    End If
                Next

                ' --- 2️⃣ Insertar nuevos ítems ---
                For Each tmp In itemsTemporales
                    Dim existe = pedido.PedidoItems.Any(Function(pi) pi.IdItem = tmp.IdItem)
                    If Not existe Then
                        Dim nuevo = New PedidoItemEntity With {
                        .IdPedido = pedido.IdPedido,
                        .IdItem = tmp.IdItem,
                        .Cantidad = tmp.Cantidad,
                        .Precio = tmp.Precio,
                        .Descript = tmp.Descript
                    }
                        context.PedidoItems.Add(nuevo)
                    End If
                Next

                ' --- 3️⃣ Eliminar ítems inactivos ---
                Dim itemsInactivos = context.TempPedidosItems.
                Where(Function(t) t.Activo = False AndAlso
                                   t.IdUsuario = idUsuario AndAlso
                                   t.IdUnico = idUnico).
                Select(Function(t) t.IdItem).ToList()

                If itemsInactivos.Any() Then
                    Dim aEliminar = pedido.PedidoItems.
                    Where(Function(pi) itemsInactivos.Contains(pi.IdItem)).ToList()

                    If aEliminar.Any() Then
                        context.PedidoItems.RemoveRange(aEliminar)
                    End If
                End If

                ' Guardar todos los cambios en una sola transacción
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al guardar pedido: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Actualiza un pedido existente
    ''' </summary>
    Public Shared Function UpdatePedido(p As PedidoEntity) As Boolean
        Try
            Using context As New CentrexDbContext()
                context.Entry(p).State = EntityState.Modified
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al actualizar pedido: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Marca un pedido como inactivo (eliminación lógica)
    ''' </summary>
    Public Function BorrarPedido(id_pedido As Integer) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim pedido = context.Pedidos.FirstOrDefault(Function(p) p.IdPedido = id_pedido)
                If pedido Is Nothing Then Return False
                pedido.Activo = False
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al eliminar pedido: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el último pedido cargado por un usuario
    ''' </summary>
    Public Shared Function Info_Ultimo_Pedido_Por_Usuario(idUsuario As Integer) As PedidoEntity
        Using context As New CentrexDbContext()
            Return context.Pedidos _
                .Include(Function(p) p.Cliente) _
                .Include(Function(p) p.Comprobante) _
                .Include(Function(p) p.TipoComprobante) _
                .Where(Function(p) p.IdUsuario = idUsuario) _
                .OrderByDescending(Function(p) p.IdPedido) _
                .FirstOrDefault()
        End Using
    End Function

    ''' <summary>
    ''' Cierra un pedido (lo marca como cerrado e inactivo)
    ''' </summary>
    Public Function CerrarPedido(idPedido As Integer) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim pedido = context.Pedidos.FirstOrDefault(Function(p) p.IdPedido = idPedido)
                If pedido Is Nothing Then Return False
                pedido.Cerrado = True
                pedido.Activo = False
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al cerrar pedido: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todos los ítems asociados a un pedido
    ''' </summary>
    Public Function GetItemsPedido(idPedido As Integer) As List(Of PedidoItemEntity)
        Using context As New CentrexDbContext()
            Return context.PedidoItems _
                .Include(Function(i) i.Item) _
                .Where(Function(i) i.IdPedido = idPedido) _
                .ToList()
        End Using
    End Function

    ''' <summary>
    ''' Agrega un ítem a un pedido existente
    ''' </summary>
    Public Function AddItemPedido(idPedido As Integer, nuevoItem As PedidoItemEntity) As Boolean
        Try
            Using context As New CentrexDbContext()
                nuevoItem.IdPedido = idPedido
                context.PedidoItems.Add(nuevoItem)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al agregar item: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Elimina un ítem de pedido
    ''' </summary>
    Public Function DeleteItemPedido(idPedidoItem As Integer) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim item = context.PedidoItems.FirstOrDefault(Function(i) i.IdPedidoItem = idPedidoItem)
                If item Is Nothing Then Return False
                context.PedidoItems.Remove(item)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al eliminar item: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Duplica un pedido y sus ítems para el usuario actual
    ''' </summary>
    Public Function DuplicarPedido(idPedido As Integer, idUsuarioActual As Integer) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim original = context.Pedidos _
                    .Include(Function(p) p.PedidoItems) _
                    .FirstOrDefault(Function(p) p.IdPedido = idPedido)
                If original Is Nothing Then Return False

                Dim nuevo = New PedidoEntity() With {
                    .Fecha = DateTime.Now.ToString("dd/MM/yyyy"),
                    .FechaEdicion = DateTime.Now.ToString("dd/MM/yyyy"),
                    .IdCliente = original.IdCliente,
                    .Markup = original.Markup,
                    .SubTotal = original.SubTotal,
                    .Iva = original.Iva,
                    .Total = original.Total,
                    .Nota1 = original.Nota1,
                    .Nota2 = original.Nota2,
                    .EsPresupuesto = original.EsPresupuesto,
                    .Activo = True,
                    .Cerrado = False,
                    .IdComprobante = original.IdComprobante,
                    .EsTest = original.EsTest,
                    .IdCc = original.IdCc,
                    .EsDuplicado = True,
                    .IdUsuario = idUsuarioActual
                }

                nuevo.PedidoItems = original.PedidoItems.Select(Function(i) New PedidoItemEntity With {
                    .IdItem = i.IdItem,
                    .Cantidad = i.Cantidad,
                    .Precio = i.Precio,
                    .Descript = i.Descript
                }).ToList()

                context.Pedidos.Add(nuevo)
                context.SaveChanges()
                Return True
            End Using
        Catch ex As Exception
            MsgBox($"Error al duplicar pedido: {ex.Message}")
            Return False
        End Try
    End Function

    Public Function AddItemPedidoTmp(ByVal i As ItemEntity,
                                 ByVal cantidad As Double,
                                 ByVal precio As Decimal,
                                 ByVal _idUsuario As Integer,
                                 ByVal _idUnico As String,
                                 ByVal _idPedido As Integer,
                                 Optional ByVal id_tmpPedidoItem As Integer = -1) As Boolean
        Try
            Using context As New CentrexDbContext()
                Dim precioFinal As Decimal = precio

                ' Si es descuento, calcular precio negativo
                If i.EsDescuento.HasValue AndAlso i.EsDescuento.Value Then
                    Dim frm As add_pedido = TryCast(Application.OpenForms("add_pedido"), add_pedido)
                    If frm IsNot Nothing AndAlso Not String.IsNullOrEmpty(frm.txt_subTotal.Text) Then
                        Dim subtotal As Decimal = CDec(frm.txt_subTotal.Text)
                        precioFinal = Math.Round(subtotal * precio, 2) * -1D
                    End If
                End If

                ' Buscar si existe el registro temporal
                Dim tmpItem As TmpPedidoItemEntity = Nothing
                If id_tmpPedidoItem > 0 Then
                    tmpItem = context.TempPedidosItems.FirstOrDefault(
                    Function(t) t.IdTmpPedidoItem = id_tmpPedidoItem AndAlso
                                t.IdUsuario = _idUsuario AndAlso
                                t.IdUnico = _idUnico AndAlso
                                t.IdPedido = _idPedido)
                End If

                ' Si existe, actualizar
                If tmpItem IsNot Nothing Then
                    tmpItem.IdPedido = _idPedido
                    tmpItem.IdItem = i.IdItem
                    tmpItem.Cantidad = cantidad
                    tmpItem.Precio = precioFinal
                    tmpItem.Descript = i.Descript
                    tmpItem.Activo = True

                Else
                    ' Si no existe, crear nuevo
                    tmpItem = New TmpPedidoItemEntity With {
                    .IdPedido = _idPedido,
                    .IdItem = i.IdItem,
                    .Cantidad = cantidad,
                    .Precio = precioFinal,
                    .Descript = i.Descript,
                    .IdUsuario = _idUsuario,
                    .IdUnico = _idUnico,
                    .Activo = True
                }
                    context.TempPedidosItems.Add(tmpItem)
                End If

                ' Guardar cambios
                context.SaveChanges()
                Return True
            End Using

        Catch ex As Exception
            MsgBox($"Error al agregar ítem temporal: {ex.Message}", MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Public Shared Function ExisteDescuentoMarkupTmp(ByVal id_item As Integer) As Integer
        Try
            Using context As New CentrexDbContext()
                ' Buscar el primer registro temporal que tenga ese id_item
                Dim tmpItem = context.TempPedidosItems.
                Where(Function(t) t.IdItem = id_item).
                Select(Function(t) t.IdTmpPedidoItem).
                FirstOrDefault()

                ' Si no se encuentra nada, FirstOrDefault devuelve 0
                If tmpItem = 0 Then
                    Return -1
                End If

                Return tmpItem
            End Using

        Catch ex As Exception
            ' En caso de error, devolver -1 (comportamiento original)
            Return -1
        End Try
    End Function


    Public Shared Function IdItemMarkupPedido(ByVal id_pedido As Integer) As Integer
        Try
            Using context As New CentrexDbContext()
                Dim id_item As Integer = context.PedidoItems _
                .Include(Function(pi) pi.Item) _
                .Where(Function(pi) pi.IdPedido = id_pedido AndAlso pi.Item.EsMarkup = True) _
                .Select(Function(pi) pi.Item.IdItem) _
                .FirstOrDefault()

                If id_item = 0 Then Return -1
                Return id_item
            End Using

        Catch ex As Exception
            MsgBox($"Error obteniendo markup del pedido: {ex.Message}", MsgBoxStyle.Critical)
            Return -1
        End Try
    End Function

    Public Shared Sub BorrarItemCargado(Optional ByVal id_tmpPedidoItem_seleccionado As Integer = -1,
                              Optional ByVal esMarkup As Boolean = False)
        Try
            Using context As New CentrexDbContext()
                Dim itemsAfectados As IQueryable(Of TmpPedidoItemEntity)

                If id_tmpPedidoItem_seleccionado = -1 Then
                    ' Borrar (eliminar físicamente) los inactivos
                    itemsAfectados = context.TempPedidosItems.Where(Function(t) t.Activo = False)
                    context.TempPedidosItems.RemoveRange(itemsAfectados)

                ElseIf esMarkup Then
                    ' Marcar como inactivo todos los ítems con ese id_item (markup)
                    itemsAfectados = context.TempPedidosItems.Where(Function(t) t.IdItem = id_tmpPedidoItem_seleccionado)
                    For Each item In itemsAfectados
                        item.Activo = False
                    Next

                Else
                    ' Marcar como inactivo el ítem seleccionado
                    Dim item = context.TempPedidosItems.FirstOrDefault(Function(t) t.IdTmpPedidoItem = id_tmpPedidoItem_seleccionado)
                    If item IsNot Nothing Then
                        item.Activo = False
                    End If
                End If

                context.SaveChanges()
            End Using

        Catch ex As Exception
            MsgBox($"Error al borrar ítem cargado: {ex.Message}", MsgBoxStyle.Critical)
        End Try
    End Sub


    Public Shared Function PedidoAPedidoTmp(ByVal id_pedido As Integer,
                                 ByVal _idUsuario As Integer,
                                 ByVal _idUnico As String) As Boolean
        Try
            Using context As New CentrexDbContext()
                ' Obtener los ítems del pedido original
                Dim pedidoItems = context.PedidoItems.
                Where(Function(p) p.IdPedido = id_pedido).
                ToList()

                ' Crear una lista temporal de ítems para insertar
                Dim tmpItems As New List(Of TmpPedidoItemEntity)

                For Each item In pedidoItems
                    Dim tmp As New TmpPedidoItemEntity With {
                    .IdPedidoItem = item.IdPedidoItem,
                    .IdPedido = item.IdPedido,
                    .IdItem = item.IdItem,
                    .Cantidad = item.Cantidad,
                    .Precio = item.Precio,
                    .Activo = item.Activo,
                    .Descript = item.Descript,
                    .IdUsuario = _idUsuario,
                    .IdUnico = _idUnico
                }
                    tmpItems.Add(tmp)
                Next

                ' Insertar en la tabla temporal
                context.TempPedidosItems.AddRange(tmpItems)
                context.SaveChanges()

                Return True
            End Using

        Catch ex As Exception
            MsgBox($"Error al copiar ítems del pedido: {ex.Message}", MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Public Function UpdatePrecios(
      ByVal datagrid As DataGridView,
      ByVal chk_esPresupuesto As CheckBox,
      ByVal txt_subTotal As TextBox,
      ByVal txt_impuestos As TextBox,
      ByVal txt_total As TextBox,
      ByVal txt_totalOriginal As TextBox,
      ByVal txt_markup As TextBox,
      ByVal txt_totalDescuentos As TextBox,
      ByVal comprobanteSeleccionado As ComprobanteEntity,
      ByVal _idUsuario As Integer,
      ByVal _idUnico As String) As Boolean

        Try
            Using context As New CentrexDbContext()
                ' === 1. Traer ítems temporales con datos de item ===
                Dim tmpItems = context.TempPedidosItems.
                    Include(Function(t) t.ItemEntity).
                    Where(Function(t) t.IdUsuario = _idUsuario AndAlso t.IdUnico = _idUnico).
                    OrderBy(Function(t) t.IdTmpPedidoItem).
                    ToList()

                Dim subtotal As Double = 0
                Dim descuento As Double = 0
                Dim totalImpuestos As Double = 0

                ' === 2. Calcular subtotal ===
                For Each t In tmpItems
                    If t.Activo AndAlso (t.ItemEntity Is Nothing OrElse (Not t.ItemEntity.EsDescuento AndAlso Not t.ItemEntity.EsMarkup)) Then
                        subtotal += t.Cantidad * t.Precio
                    End If
                Next

                txt_totalOriginal.Text = subtotal

                ' === 3. Aplicar descuentos ===
                For Each t In tmpItems
                    If t.Activo AndAlso t.ItemEntity IsNot Nothing AndAlso t.ItemEntity.EsDescuento Then
                        Dim factor As Double = If(t.ItemEntity.Factor, 1)
                        Dim nuevoPrecio As Double = (subtotal * factor) * -1
                        descuento += nuevoPrecio
                        subtotal += nuevoPrecio
                        t.Precio = nuevoPrecio
                        t.Activo = True
                    End If
                Next
                context.SaveChanges()

                ' === 4. Calcular impuestos ===
                Dim comprobantesB As New List(Of Integer) From {
                    6, 7, 8, 9, 10, 18, 25, 26, 28, 43, 46, 61, 64, 82, 113, 116, 206
                }

                If Not comprobanteSeleccionado.EsPresupuesto Then
                    If Not comprobantesB.Contains(comprobanteSeleccionado.IdTipoComprobante) Then
                        totalImpuestos = 0
                        For Each t In tmpItems
                            If t.Activo AndAlso (t.ItemEntity Is Nothing OrElse (Not t.ItemEntity.EsDescuento AndAlso Not t.ItemEntity.EsMarkup)) Then
                                Dim impuestosItem = CalculaImpuestosItemEF(context, t.IdTmpPedidoItem, t.IdItem, comprobanteSeleccionado, chk_esPresupuesto)
                                Dim totalImpuestoItem As Double = ((impuestosItem * (t.Precio * t.Cantidad)) / 100)
                                totalImpuestos += totalImpuestoItem
                            End If
                        Next
                        totalImpuestos -= ((totalImpuestos * (descuento * -1)) / 100)
                    Else
                        totalImpuestos = subtotal - (subtotal / 1.21)
                    End If
                End If

                ' === 5. Calcular total ===
                Dim total As Double
                If comprobantesB.Contains(comprobanteSeleccionado.IdTipoComprobante) Then
                    total = subtotal
                    subtotal -= totalImpuestos
                Else
                    total = subtotal + totalImpuestos
                End If

                ' === 6. Actualizar controles ===
                If Val(txt_totalOriginal.Text) <> subtotal Then
                    txt_markup.Enabled = False
                Else
                    txt_markup.Enabled = True
                End If

                txt_subTotal.Text = Math.Round(subtotal, 2)
                txt_impuestos.Text = Math.Round(totalImpuestos, 2)
                txt_totalDescuentos.Text = Math.Round(descuento, 2)
                txt_total.Text = Math.Round(total, 2)

                ' === 7. Refrescar DataGrid ===
                Dim lista = tmpItems.
                    Where(Function(t) t.Activo AndAlso (t.ItemEntity Is Nothing OrElse Not t.ItemEntity.EsMarkup)).
                    Select(Function(t) New With {
                        .ID = $"{t.IdTmpPedidoItem}-{t.IdItem}",
                        .IdPedidoItem = t.IdPedidoItem,
                        .Producto = If(t.ItemEntity IsNot Nothing, t.ItemEntity.Descript, t.Descript),
                        .Cantidad = t.Cantidad,
                        .Precio = t.Precio,
                        .Subtotal = Math.Round(t.Cantidad * t.Precio, 2)
                    }).
                    OrderBy(Function(x) x.Producto).
                    ToList()

                datagrid.DataSource = lista
            End Using

            Return True

        Catch ex As Exception
            MsgBox($"Error al actualizar precios: {ex.Message}", MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Private Function CalculaImpuestosItemEF(
    ByVal context As CentrexDbContext,
    ByVal id_tmpPedidoItem As Integer,
    ByVal id_item As Integer,
    ByVal comprobanteSeleccionado As ComprobanteEntity,
    ByVal chk_esPresupuesto As CheckBox) As Double

        Dim totalImpuestos As Double = 0

        Try
            ' Traer el ítem y sus impuestos asociados (ItemImpuestos -> Impuesto)
            Dim itemConImpuestos = context.Items.
            Include(Function(i) i.ItemImpuestos.Select(Function(ii) ii.Impuesto)).
            FirstOrDefault(Function(i) i.IdItem = id_item)

            If itemConImpuestos Is Nothing Then Return 0

            For Each imp In itemConImpuestos.ItemImpuestos
                If imp.Activo AndAlso imp.Impuesto IsNot Nothing Then
                    Dim nombreImp As String = LCase(Trim(imp.Impuesto.Nombre))
                    Dim porcentaje As Double = imp.Impuesto.Porcentaje

                    ' Si es presupuesto, no sumar IVA
                    If chk_esPresupuesto.Checked Then
                        If Not nombreImp.Contains("iva") Then
                            totalImpuestos += porcentaje
                        End If
                    Else
                        ' Suma general según tipo de comprobante
                        totalImpuestos += porcentaje
                    End If
                End If
            Next

            Return totalImpuestos

        Catch ex As Exception
            MsgBox($"Error al calcular impuestos: {ex.Message}", MsgBoxStyle.Critical)
            Return 0
        End Try
    End Function


End Class

' ==========================
' Funciones adicionales (unificadas desde pedidos_refactorizado.vb) en EF puro
' ==========================

Public Module PedidosExtraEF

    ' Obtiene información de pedido (último o por ID) y la mapea a tipo legacy "pedido"
    Public Function InfoPedido(Optional ByVal id_pedido As String = "") As pedido
        Try
            Using ctx As New CentrexDbContext()
                Dim q = ctx.Pedidos _
                    .Include(Function(p) p.Cliente) _
                    .Include(Function(p) p.Comprobante) _
                    .Include(Function(p) p.TipoComprobante)

                Dim ped As PedidoEntity = If(String.IsNullOrEmpty(id_pedido),
                    q.OrderByDescending(Function(p) p.IdPedido).FirstOrDefault(),
                    q.FirstOrDefault(Function(p) p.IdPedido = CInt(id_pedido)))

                If ped Is Nothing Then Return Nothing

                Dim tmp As New pedido()
                tmp.id_pedido = ped.IdPedido.ToString()
                tmp.fecha = ped.Fecha
                tmp.fecha_edicion = ped.FechaEdicion
                tmp.id_cliente = ped.IdCliente.ToString()
                tmp.markup = ped.Markup.ToString()
                tmp.subTotal = ped.SubTotal.ToString()
                tmp.iva = ped.Iva.ToString()
                tmp.total = ped.Total.ToString()
                tmp.nota1 = ped.Nota1
                tmp.nota2 = ped.Nota2
                tmp.esPresupuesto = ped.EsPresupuesto
                tmp.activo = ped.Activo
                tmp.cerrado = ped.Cerrado
                tmp.idPresupuesto = If(ped.IdPresupuesto.HasValue, ped.IdPresupuesto.Value.ToString(), "0")
                tmp.id_comprobante = If(ped.IdComprobante.HasValue, ped.IdComprobante.Value.ToString(), "0")
                tmp.cae = ped.Cae
                tmp.fechaVencimiento_cae = ped.FechaVencimientoCae
                tmp.puntoVenta = If(ped.PuntoVenta.HasValue, ped.PuntoVenta.Value.ToString(), "0")
                tmp.numeroComprobante = If(ped.NumeroComprobante.HasValue, ped.NumeroComprobante.Value.ToString(), "0")
                tmp.codigoDeBarras = If(ped.CodigoDeBarras, 0).ToString()
                tmp.esTest = ped.EsTest
                tmp.id_Cc = If(ped.IdCc.HasValue, ped.IdCc.Value.ToString(), "0")
                tmp.numeroComprobante_anulado = If(ped.NumeroComprobanteAnulado.HasValue, ped.NumeroComprobanteAnulado.Value.ToString(), "0")
                tmp.numeroPedido_anulado = If(ped.NumeroPedidoAnulado.HasValue, ped.NumeroPedidoAnulado.Value.ToString(), "0")
                tmp.esDuplicado = ped.EsDuplicado
                tmp.id_usuario = ped.IdUsuario.ToString()
                Return tmp
            End Using
        Catch ex As Exception
            MsgBox($"Error obteniendo información de pedido (EF): {ex.Message}")
            Return Nothing
        End Try
    End Function

End Module
