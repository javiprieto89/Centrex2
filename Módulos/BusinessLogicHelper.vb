Imports System.Collections.Generic

''' <summary>
''' Módulo helper para lógica de negocio común
''' Centraliza cálculos y reglas de negocio repetitivas
''' </summary>
Module BusinessLogicHelper
    
    ''' <summary>
    ''' Calcula el subtotal de un pedido
    ''' </summary>
    Public Function CalculateSubtotal(items As List(Of item_pedido)) As Decimal
        Dim subtotal As Decimal = 0
        For Each item In items
            subtotal += item.cantidad * item.precio
        Next
        Return subtotal
    End Function
    
    ''' <summary>
    ''' Calcula el IVA sobre un subtotal
    ''' </summary>
    Public Function CalculateIVA(subtotal As Decimal, ivaPercentage As Decimal) As Decimal
        Return subtotal * (ivaPercentage / 100)
    End Function
    
    ''' <summary>
    ''' Calcula el total de un pedido
    ''' </summary>
    Public Function CalculateTotal(subtotal As Decimal, iva As Decimal, Optional descuento As Decimal = 0) As Decimal
        Return subtotal + iva - descuento
    End Function
    
    ''' <summary>
    ''' Calcula el markup sobre un precio de costo
    ''' </summary>
    Public Function CalculateMarkup(costo As Decimal, markupPercentage As Decimal) As Decimal
        Return costo * (1 + markupPercentage / 100)
    End Function
    
    ''' <summary>
    ''' Calcula el descuento sobre un precio
    ''' </summary>
    Public Function CalculateDiscount(precio As Decimal, discountPercentage As Decimal) As Decimal
        Return precio * (discountPercentage / 100)
    End Function
    
    ''' <summary>
    ''' Calcula el precio final con descuento aplicado
    ''' </summary>
    Public Function CalculateFinalPrice(precio As Decimal, discountPercentage As Decimal) As Decimal
        Dim descuento As Decimal = CalculateDiscount(precio, discountPercentage)
        Return precio - descuento
    End Function
    
    ''' <summary>
    ''' Valida si un cliente tiene crédito disponible
    ''' </summary>
    Public Function HasAvailableCredit(clienteId As Integer, monto As Decimal) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim cliente = context.Clientes.FirstOrDefault(Function(c) c.IdCliente = clienteId)
                If cliente Is Nothing Then Return False

                Dim limite As Decimal = If(cliente.LimiteCredito, 0D)
                Dim saldoActual As Decimal = GetClientBalance(clienteId)

                Return (saldoActual + monto) <= limite
            End Using
        Catch
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Obtiene el saldo actual de un cliente
    ''' </summary>
    Public Function GetClientBalance(clienteId As Integer) As Decimal
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim movimientos = context.CcClientes.Where(Function(m) m.IdCliente = clienteId)
                Dim saldo As Decimal = movimientos.Select(Function(m) (m.Debe - m.Haber)).DefaultIfEmpty(0D).Sum()
                Return saldo
            End Using
        Catch
            Return 0
        End Try
    End Function
    
    ''' <summary>
    ''' Valida si hay stock suficiente para un item
    ''' </summary>
    Public Function HasEnoughStock(itemId As Integer, cantidad As Decimal) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim item = context.Items.FirstOrDefault(Function(i) i.IdItem = itemId)
                If item Is Nothing Then Return False
                Return item.StockActual >= cantidad
            End Using
        Catch
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Actualiza el stock de un item
    ''' </summary>
    Public Function UpdateItemStock(itemId As Integer, cantidad As Decimal, tipoMovimiento As String) As Boolean
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim factor As Integer = If(tipoMovimiento = "ENTRADA", 1, -1)
                Dim item = context.Items.FirstOrDefault(Function(i) i.IdItem = itemId)
                If item Is Nothing Then Return False
                item.StockActual = item.StockActual + (cantidad * factor)
                context.SaveChanges()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Genera el próximo número de pedido
    ''' </summary>
    Public Function GetNextPedidoNumber() As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim maxId As Integer = context.Pedidos.Select(Function(p) p.IdPedido).DefaultIfEmpty(0).Max()
                Return maxId + 1
            End Using
        Catch
            Return 1
        End Try
    End Function
    
    ''' <summary>
    ''' Genera el próximo número de comprobante
    ''' </summary>
    Public Function GetNextComprobanteNumber(tipoComprobante As Integer) As Integer
        Try
            Using context As CentrexDbContext = GetDbContext()
                Dim maxNumero As Integer = context.Pedidos.Where(Function(p) p.IdTipoComprobante = tipoComprobante).
                    Select(Function(p) p.NumeroComprobante).DefaultIfEmpty(0).Max()
                Return maxNumero + 1
            End Using
        Catch
            Return 1
        End Try
    End Function
    
    ''' <summary>
    ''' Calcula la edad de un cliente basada en su fecha de nacimiento
    ''' </summary>
    Public Function CalculateAge(fechaNacimiento As Date) As Integer
        Dim today As Date = DateTime.Today
        Dim age As Integer = today.Year - fechaNacimiento.Year
        
        If fechaNacimiento.Date > today.AddYears(-age) Then
            age -= 1
        End If
        
        Return age
    End Function
    
    ''' <summary>
    ''' Valida si una fecha está en el rango de trabajo
    ''' </summary>
    Public Function IsWorkingDate(fecha As Date) As Boolean
        ' Lunes a Viernes, excluyendo feriados
        If fecha.DayOfWeek = DayOfWeek.Saturday OrElse fecha.DayOfWeek = DayOfWeek.Sunday Then
            Return False
        End If
        
        ' Aquí se podrían agregar validaciones de feriados
        Return True
    End Function
    
    ''' <summary>
    ''' Formatea un número de teléfono
    ''' </summary>
    Public Function FormatPhoneNumber(phone As String) As String
        If String.IsNullOrEmpty(phone) Then Return ""
        
        ' Remover caracteres no numéricos
        Dim cleanPhone As String = System.Text.RegularExpressions.Regex.Replace(phone, "[^\d]", "")
        
        ' Formatear según la longitud
        Select Case cleanPhone.Length
            Case 10
                Return $"{cleanPhone.Substring(0, 3)}-{cleanPhone.Substring(3, 3)}-{cleanPhone.Substring(6, 4)}"
            Case 11
                Return $"{cleanPhone.Substring(0, 1)}-{cleanPhone.Substring(1, 3)}-{cleanPhone.Substring(4, 3)}-{cleanPhone.Substring(7, 4)}"
            Case Else
                Return phone ' Devolver original si no coincide con formato esperado
        End Select
    End Function
    
    ''' <summary>
    ''' Valida si un precio está dentro del rango aceptable
    ''' </summary>
    Public Function IsPriceInRange(precio As Decimal, precioMinimo As Decimal, precioMaximo As Decimal) As Boolean
        Return precio >= precioMinimo AndAlso precio <= precioMaximo
    End Function
    
End Module
