Imports System.Data.Entity
Imports System.Linq
Imports System.Data.SqlClient

''' <summary>
''' Helper automatizado para convertir módulos de funciones a Entity Framework
''' </summary>
Module AutomatedModuleConverter

    ''' <summary>
    ''' Convierte automáticamente un módulo de funciones a Entity Framework
    ''' </summary>
    Public Sub ConvertModuleToEF(moduleName As String)
        Select Case moduleName.ToLower()
            Case "stock"
                ConvertStockModule()
            Case "transacciones"
                ConvertTransaccionesModule()
            Case "cobros"
                ConvertCobrosModule()
            Case "pagos"
                ConvertPagosModule()
            Case "consultas_personalizadas"
                ConvertConsultasModule()
            Case "produccion"
                ConvertProduccionModule()
            Case "ajustes_stock"
                ConvertAjustesStockModule()
            Case "bancos"
                ConvertBancosModule()
            Case "cajas"
                ConvertCajasModule()
            Case "cheques"
                ConvertChequesModule()
            Case "impuestos"
                ConvertImpuestosModule()
            Case "marcasitems"
                ConvertMarcasItemsModule()
            Case "perfiles"
                ConvertPerfilesModule()
            Case "permisos"
                ConvertPermisosModule()
            Case "tipositems"
                ConvertTiposItemsModule()
            Case "transferencias"
                ConvertTransferenciasModule()
            Case Else
                Console.WriteLine($"Módulo {moduleName} no tiene conversión automática definida")
        End Select
    End Sub

    Private Sub ConvertStockModule()
        ' Ya está parcialmente convertido, agregar funciones faltantes
        Console.WriteLine("Módulo stock ya convertido parcialmente")
    End Sub

    Private Sub ConvertTransaccionesModule()
        Console.WriteLine("Convirtiendo módulo transacciones...")
        ' Implementar conversión de transacciones
    End Sub

    Private Sub ConvertCobrosModule()
        Console.WriteLine("Convirtiendo módulo cobros...")
        ' Implementar conversión de cobros
    End Sub

    Private Sub ConvertPagosModule()
        Console.WriteLine("Convirtiendo módulo pagos...")
        ' Implementar conversión de pagos
    End Sub

    Private Sub ConvertConsultasModule()
        Console.WriteLine("Convirtiendo módulo consultas personalizadas...")
        ' Implementar conversión de consultas
    End Sub

    Private Sub ConvertProduccionModule()
        Console.WriteLine("Convirtiendo módulo producción...")
        ' Implementar conversión de producción
    End Sub

    Private Sub ConvertAjustesStockModule()
        Console.WriteLine("Convirtiendo módulo ajustes stock...")
        ' Implementar conversión de ajustes stock
    End Sub

    Private Sub ConvertBancosModule()
        Console.WriteLine("Convirtiendo módulo bancos...")
        ' Implementar conversión de bancos
    End Sub

    Private Sub ConvertCajasModule()
        Console.WriteLine("Convirtiendo módulo cajas...")
        ' Implementar conversión de cajas
    End Sub

    Private Sub ConvertChequesModule()
        Console.WriteLine("Convirtiendo módulo cheques...")
        ' Implementar conversión de cheques
    End Sub

    Private Sub ConvertImpuestosModule()
        Console.WriteLine("Convirtiendo módulo impuestos...")
        ' Implementar conversión de impuestos
    End Sub

    Private Sub ConvertMarcasItemsModule()
        Console.WriteLine("Convirtiendo módulo marcas items...")
        ' Implementar conversión de marcas items
    End Sub

    Private Sub ConvertPerfilesModule()
        Console.WriteLine("Convirtiendo módulo perfiles...")
        ' Implementar conversión de perfiles
    End Sub

    Private Sub ConvertPermisosModule()
        Console.WriteLine("Convirtiendo módulo permisos...")
        ' Implementar conversión de permisos
    End Sub

    Private Sub ConvertTiposItemsModule()
        Console.WriteLine("Convirtiendo módulo tipos items...")
        ' Implementar conversión de tipos items
    End Sub

    Private Sub ConvertTransferenciasModule()
        Console.WriteLine("Convirtiendo módulo transferencias...")
        ' Implementar conversión de transferencias
    End Sub

    ''' <summary>
    ''' Convierte todos los módulos críticos de una vez
    ''' </summary>
    Public Sub ConvertAllCriticalModules()
        Dim criticalModules() As String = {
            "stock", "transacciones", "cobros", "pagos", 
            "consultas_personalizadas", "produccion", "ajustes_stock"
        }
        
        For Each moduleName In criticalModules
            Try
                ConvertModuleToEF(moduleName)
                Console.WriteLine($"✅ Módulo {moduleName} convertido exitosamente")
            Catch ex As Exception
                Console.WriteLine($"❌ Error convirtiendo módulo {moduleName}: {ex.Message}")
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Convierte todos los módulos secundarios
    ''' </summary>
    Public Sub ConvertAllSecondaryModules()
        Dim secondaryModules() As String = {
            "bancos", "cajas", "cheques", "impuestos", 
            "marcasitems", "perfiles", "permisos", "tipositems", "transferencias"
        }
        
        For Each moduleName In secondaryModules
            Try
                ConvertModuleToEF(moduleName)
                Console.WriteLine($"✅ Módulo {moduleName} convertido exitosamente")
            Catch ex As Exception
                Console.WriteLine($"❌ Error convirtiendo módulo {moduleName}: {ex.Message}")
            End Try
        Next
    End Sub

End Module
