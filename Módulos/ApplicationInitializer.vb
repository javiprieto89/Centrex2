Imports System.IO
Imports System.Net
Imports System.Windows.Forms

''' <summary>
''' Módulo para manejar la inicialización de la aplicación
''' </summary>
Module ApplicationInitializer
    
    ''' <summary>
    ''' Configura los protocolos de seguridad TLS
    ''' </summary>
    Public Sub ConfigureSecurityProtocols()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
    End Sub
    
    ''' <summary>
    ''' Configura el entorno gráfico de la aplicación
    ''' </summary>
    Public Sub ConfigureVisualStyles()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
    End Sub
    
    ''' <summary>
    ''' Obtiene el nombre de la computadora
    ''' </summary>
    Public Function GetComputerName() As String
        Return SystemInformation.ComputerName.ToUpper
    End Function
    
    ''' <summary>
    ''' Configura las variables por defecto del sistema
    ''' </summary>
    Public Sub SetDefaultValues()
        comprobantePresupuesto_default = 3
        id_comprobante_default = 3
        id_tipoDocumento_default = 80
        id_tipoComprobante_default = 1
        id_cliente_pedido_default = 2
        id_pais_default = 1
        id_provincia_default = 1
        id_marca_default = 1
        id_proveedor_default = 1
        cuit_emisor_default = "20233695255"
        id_condicion_compra_default = 1
        STR_COMPROBANTES_CONTABLES = "1, 6, 11, 51, 201, 206, 211, 1006, 2, 7, 12, 52, 202, 207, 212, 1007, 1002, 1003, 1004, 1005, 1010, 1015, 3, 8, 13, 53, 203, 208, 213, 1008, 4, 1009"
        versiondb = "1.0.0"
    End Sub
    
    ''' <summary>
    ''' Configura el modo de depuración según la computadora
    ''' </summary>
    Public Sub ConfigureDebugMode(computerName As String)
        If computerName <> "JARVIS" And computerName <> "SERVTEC-06" And computerName <> "CORTANA" And computerName <> "SKYNET" Then
            depuracion = False
        Else
            depuracion = True
            If computerName = "SKYNET" Then
                ' Configuración específica para SKYNET
            ElseIf computerName = "SILVIA" Then
                serversql = "192.168.1.100"
            End If
        End If
        
        ' Forzar depuración si el debugger está conectado
        If Debugger.IsAttached Then
            depuracion = True
        End If
    End Sub
    
    ''' <summary>
    ''' Valida la conexión a la base de datos
    ''' </summary>
    Public Function ValidateDatabaseConnection() As Boolean
        Try
            If Not abrirdb(serversql, basedb, usuariodb, passdb) Then
                ShowError("Error al abrir la Base de datos.", "Error de Conexión")
                Return False
            End If
            cerrardb()
            Return True
        Catch ex As Exception
            ShowError($"Error validando conexión a base de datos: {ex.Message}", "Error de Conexión")
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Ejecuta scripts de base de datos si es necesario
    ''' </summary>
    Public Sub ExecuteDatabaseScripts(computerName As String)
        Try
            If computerName <> "JARVIS" Or depuracion = False Then
                Dim scriptsPath As String = "..\..\ScriptsDB"
                If Directory.Exists(scriptsPath) Then
                    Dim di As DirectoryInfo = New DirectoryInfo(scriptsPath)
                    Dim files As FileInfo() = di.GetFiles("*.sql")
                    
                    For Each file As FileInfo In files
                        Try
                            Dim scriptContent As String = System.IO.File.ReadAllText(file.FullName)
                            If Not String.IsNullOrEmpty(scriptContent.Trim()) Then
                                ExecuteNonQuery(scriptContent)
                            End If
                        Catch ex As Exception
                            Console.WriteLine($"Error ejecutando script {file.Name}: {ex.Message}")
                        End Try
                    Next
                End If
            End If
        Catch ex As Exception
            Console.WriteLine($"Error ejecutando scripts de base de datos: {ex.Message}")
        End Try
    End Sub
    
    ''' <summary>
    ''' Verifica si hay modificaciones pendientes en la base de datos
    ''' </summary>
    Public Sub CheckDatabaseModifications(computerName As String)
        If modificacionesDB And Not computerName = "JARVIS" Then
            ShowWarning("Se deben hacer modificaciones mayores a la base de datos para que se ajuste a la última versión del programa." & vbCrLf &
                       "Avisele al programador, ya que puede ser que el programa no corra correctamente sin estas modificaciones", 
                       "Modificaciones de Base de Datos")
        End If
    End Sub
    
    ''' <summary>
    ''' Inicializa completamente la aplicación
    ''' </summary>
    Public Function InitializeApplication() As Boolean
        Try
            ' Configurar seguridad
            ConfigureSecurityProtocols()
            
            ' Configurar entorno gráfico
            ConfigureVisualStyles()
            
            ' Obtener nombre de computadora
            pc = GetComputerName()
            
            ' Configurar valores por defecto
            SetDefaultValues()
            
            ' Configurar modo de depuración
            ConfigureDebugMode(pc)
            
            ' Validar conexión a base de datos
            If Not ValidateDatabaseConnection() Then
                Return False
            End If
            
            ' Cambiar idioma
            configuracion_regional.cambiarIdioma()
            
            ' Ejecutar scripts de base de datos
            ExecuteDatabaseScripts(pc)
            
            ' Verificar modificaciones pendientes
            CheckDatabaseModifications(pc)
            
            Return True
            
        Catch ex As Exception
            ShowError($"Error inicializando aplicación: {ex.Message}", "Error de Inicialización")
            Return False
        End Try
    End Function
    
    Public Function ReadAllText(ByVal filePath As String) As String
        Try
            Return System.IO.File.ReadAllText(filePath)
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Module
