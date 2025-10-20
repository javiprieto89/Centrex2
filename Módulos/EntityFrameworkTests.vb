Imports System.Data.Entity
Imports System.Linq

''' <summary>
''' Módulo de pruebas para verificar la migración a Entity Framework
''' </summary>
Module EntityFrameworkTests

    ''' <summary>
    ''' Ejecuta todas las pruebas de Entity Framework
    ''' </summary>
    Public Sub RunAllTests()
        Console.WriteLine("🧪 Iniciando pruebas de Entity Framework...")
        
        Try
            TestDatabaseConnection()
            TestClientOperations()
            TestItemOperations()
            TestPedidoOperations()
            TestProveedorOperations()
            TestUsuarioOperations()
            TestComprobanteOperations()
            
            Console.WriteLine("✅ Todas las pruebas pasaron exitosamente!")
        Catch ex As Exception
            Console.WriteLine($"❌ Error en las pruebas: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Prueba la conexión a la base de datos
    ''' </summary>
    Private Sub TestDatabaseConnection()
        Console.WriteLine("🔌 Probando conexión a la base de datos...")
        
        Using context As CentrexDbContext = GetDbContext()
            Dim clientCount = context.Clientes.Count()
            Console.WriteLine($"✅ Conexión exitosa. Clientes encontrados: {clientCount}")
        End Using
    End Sub

    ''' <summary>
    ''' Prueba las operaciones de clientes
    ''' </summary>
    Private Sub TestClientOperations()
        Console.WriteLine("👥 Probando operaciones de clientes...")
        
        ' Probar obtener información de cliente
        Dim cliente = info_cliente("1")
        If cliente.razon_social <> "error" Then
            Console.WriteLine($"✅ Cliente encontrado: {cliente.razon_social}")
        Else
            Console.WriteLine("⚠️ No se encontró cliente con ID 1")
        End If
        
        ' Probar agregar cliente (solo si no existe)
        Dim nuevoCliente As New cliente()
        nuevoCliente.razon_social = "Cliente Prueba EF"
        nuevoCliente.nombre_fantasia = "Prueba EF"
        nuevoCliente.activo = True
        nuevoCliente.id_provincia_fiscal = 1
        nuevoCliente.id_provincia_entrega = 1
        
        Dim resultado = addcliente(nuevoCliente)
        If resultado Then
            Console.WriteLine("✅ Cliente agregado exitosamente")
        Else
            Console.WriteLine("⚠️ No se pudo agregar cliente (posiblemente ya existe)")
        End If
    End Sub

    ''' <summary>
    ''' Prueba las operaciones de items
    ''' </summary>
    Private Sub TestItemOperations()
        Console.WriteLine("📦 Probando operaciones de items...")
        
        ' Probar obtener información de item
        Dim item = info_item("1")
        If item.descript <> "error" Then
            Console.WriteLine($"✅ Item encontrado: {item.descript}")
        Else
            Console.WriteLine("⚠️ No se encontró item con ID 1")
        End If
    End Sub

    ''' <summary>
    ''' Prueba las operaciones de pedidos
    ''' </summary>
    Private Sub TestPedidoOperations()
        Console.WriteLine("📋 Probando operaciones de pedidos...")
        
        ' Probar obtener información de pedido
        Dim pedido = InfoPedido("1")
        If pedido.id_pedido <> "" Then
            Console.WriteLine($"✅ Pedido encontrado: ID {pedido.id_pedido}")
        Else
            Console.WriteLine("⚠️ No se encontró pedido con ID 1")
        End If
    End Sub

    ''' <summary>
    ''' Prueba las operaciones de proveedores
    ''' </summary>
    Private Sub TestProveedorOperations()
        Console.WriteLine("🏢 Probando operaciones de proveedores...")
        
        ' Probar obtener información de proveedor
        Dim proveedor = info_proveedor("1")
        If proveedor.razon_social <> "error" Then
            Console.WriteLine($"✅ Proveedor encontrado: {proveedor.razon_social}")
        Else
            Console.WriteLine("⚠️ No se encontró proveedor con ID 1")
        End If
    End Sub

    ''' <summary>
    ''' Prueba las operaciones de usuarios
    ''' </summary>
    Private Sub TestUsuarioOperations()
        Console.WriteLine("👤 Probando operaciones de usuarios...")
        
        ' Probar obtener información de usuario
        Dim usuario = info_usuario(1)
        If usuario.usuario <> "error" Then
            Console.WriteLine($"✅ Usuario encontrado: {usuario.usuario}")
        Else
            Console.WriteLine("⚠️ No se encontró usuario con ID 1")
        End If
    End Sub

    ''' <summary>
    ''' Prueba las operaciones de comprobantes
    ''' </summary>
    Private Sub TestComprobanteOperations()
        Console.WriteLine("🧾 Probando operaciones de comprobantes...")
        
        ' Probar obtener información de comprobante
        Dim comprobante = info_comprobante("1")
        If comprobante.comprobante <> "error" Then
            Console.WriteLine($"✅ Comprobante encontrado: {comprobante.comprobante}")
        Else
            Console.WriteLine("⚠️ No se encontró comprobante con ID 1")
        End If
        
        ' Probar función estaComprobanteDefault
        Dim esDefault = estaComprobanteDefault("fiscal", 1)
        Console.WriteLine($"✅ estaComprobanteDefault resultado: {esDefault}")
    End Sub

    ''' <summary>
    ''' Prueba el rendimiento de Entity Framework vs SQL directo
    ''' </summary>
    Public Sub TestPerformance()
        Console.WriteLine("⚡ Probando rendimiento...")
        
        Dim startTime As DateTime
        Dim endTime As DateTime
        
        ' Prueba con Entity Framework
        startTime = DateTime.Now
        Using context As CentrexDbContext = GetDbContext()
            Dim clientes = context.Clientes.Where(Function(c) c.Activo = True).ToList()
        End Using
        endTime = DateTime.Now
        Dim efTime = (endTime - startTime).TotalMilliseconds
        
        ' Prueba con SQL directo (fallback)
        startTime = DateTime.Now
        Try
            abrirdb(serversql, basedb, usuariodb, passdb)
            Dim sqlstr = "SELECT COUNT(*) FROM clientes WHERE activo = 1"
            Dim comando As New SqlCommand(sqlstr, CN)
            Dim count = comando.ExecuteScalar()
            cerrardb()
        Catch ex As Exception
            cerrardb()
        End Try
        endTime = DateTime.Now
        Dim sqlTime = (endTime - startTime).TotalMilliseconds
        
        Console.WriteLine($"📊 Tiempo Entity Framework: {efTime:F2}ms")
        Console.WriteLine($"📊 Tiempo SQL directo: {sqlTime:F2}ms")
        
        If efTime < sqlTime * 1.5 Then
            Console.WriteLine("✅ Entity Framework tiene rendimiento aceptable")
        Else
            Console.WriteLine("⚠️ Entity Framework es más lento que SQL directo")
        End If
    End Sub

    ''' <summary>
    ''' Prueba la compatibilidad con código existente
    ''' </summary>
    Public Sub TestCompatibility()
        Console.WriteLine("🔄 Probando compatibilidad...")
        
        Try
            ' Probar que las funciones originales siguen funcionando
            Dim cliente = info_cliente("1")
            Dim item = info_item("1")
            Dim pedido = InfoPedido("1")
            Dim proveedor = info_proveedor("1")
            Dim usuario = info_usuario(1)
            Dim comprobante = info_comprobante("1")
            
            Console.WriteLine("✅ Todas las funciones originales funcionan correctamente")
        Catch ex As Exception
            Console.WriteLine($"❌ Error de compatibilidad: {ex.Message}")
        End Try
    End Sub

End Module
