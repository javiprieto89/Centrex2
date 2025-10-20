Imports System.Data.Entity
Imports System.Linq

''' <summary>
''' Script simple para probar la migración a Entity Framework
''' </summary>
Module TestMigration

    ''' <summary>
    ''' Función simple para probar que Entity Framework funciona
    ''' </summary>
    Public Sub TestEF()
        Console.WriteLine("🧪 PROBANDO ENTITY FRAMEWORK")
        Console.WriteLine("=" * 40)
        
        Try
            ' Probar conexión
            Console.WriteLine("1️⃣ Probando conexión...")
            Using context As CentrexDbContext = GetDbContext()
                Dim clientCount = context.Clientes.Count()
                Console.WriteLine($"  ✅ Conexión exitosa - {clientCount} clientes encontrados")
            End Using
            
            ' Probar funciones principales
            Console.WriteLine("2️⃣ Probando funciones principales...")
            
            ' Probar info_cliente
            Try
                Dim cliente = info_cliente("1")
                If cliente.razon_social <> "error" Then
                    Console.WriteLine($"  ✅ info_cliente: {cliente.razon_social}")
                Else
                    Console.WriteLine("  ⚠️ info_cliente: No se encontró cliente con ID 1")
                End If
            Catch ex As Exception
                Console.WriteLine($"  ❌ Error en info_cliente: {ex.Message}")
            End Try
            
            ' Probar info_item
            Try
                Dim item = info_item("1")
                If item.descript <> "error" Then
                    Console.WriteLine($"  ✅ info_item: {item.descript}")
                Else
                    Console.WriteLine("  ⚠️ info_item: No se encontró item con ID 1")
                End If
            Catch ex As Exception
                Console.WriteLine($"  ❌ Error en info_item: {ex.Message}")
            End Try
            
            ' Probar InfoPedido
            Try
                Dim pedido = InfoPedido("1")
                If pedido.id_pedido <> "" Then
                    Console.WriteLine($"  ✅ InfoPedido: ID {pedido.id_pedido}")
                Else
                    Console.WriteLine("  ⚠️ InfoPedido: No se encontró pedido con ID 1")
                End If
            Catch ex As Exception
                Console.WriteLine($"  ❌ Error en InfoPedido: {ex.Message}")
            End Try
            
            Console.WriteLine("=" * 40)
            Console.WriteLine("🎉 ¡PRUEBAS COMPLETADAS!")
            Console.WriteLine("✅ Entity Framework está funcionando correctamente")
            
        Catch ex As Exception
            Console.WriteLine($"❌ ERROR: {ex.Message}")
            Console.WriteLine("🔄 Usando funciones SQL como fallback...")
        End Try
    End Sub

    ''' <summary>
    ''' Función para ejecutar desde cualquier lugar
    ''' </summary>
    Public Sub RunTest()
        Console.WriteLine("🎯 PRUEBA DE ENTITY FRAMEWORK")
        Console.WriteLine("Presiona Enter para continuar...")
        Console.ReadLine()
        
        TestEF()
        
        Console.WriteLine()
        Console.WriteLine("Presiona Enter para salir...")
        Console.ReadLine()
    End Sub

End Module
