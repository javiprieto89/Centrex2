Imports System.Windows.Forms

''' <summary>
''' Módulo para manejar las operaciones del menú principal
''' </summary>
Module MenuHandler
    
    ''' <summary>
    ''' Maneja la creación de nuevos registros
    ''' </summary>
    Public Sub HandleNewRecord(recordType As String)
        Try
            Select Case recordType.ToLower()
                Case "clientes"
                    Dim frm As New add_cliente()
                    frm.ShowDialog()
                Case "archivoccclientes"
                    Dim frm As New add_ccCliente()
                    frm.ShowDialog()
                Case "proveedores"
                    Dim frm As New add_proveedor()
                    frm.ShowDialog()
                Case "archivoccproveedores"
                    Dim frm As New add_ccProveedor()
                    frm.ShowDialog()
                Case "tipos_items"
                    Dim frm As New add_tipoitem()
                    frm.ShowDialog()
                Case "marcas_items"
                    Dim frm As New add_marcai()
                    frm.ShowDialog()
                Case "items"
                    Dim frm As New add_item()
                    frm.ShowDialog()
                Case "asocitems"
                    Dim frm As New add_asocItem()
                    frm.ShowDialog()
                Case "comprobantes"
                    Dim frm As New add_comprobante()
                    frm.ShowDialog()
                Case "archivoconsultas"
                    Dim frm As New add_consulta()
                    frm.ShowDialog()
                Case "caja"
                    Dim frm As New add_caja()
                    frm.ShowDialog()
                Case "bancos"
                    Dim frm As New add_banco()
                    frm.ShowDialog()
                Case "cuentas_bancarias"
                    Dim frm As New add_cuentaBancaria()
                    frm.ShowDialog()
                Case "chrecibidos"
                    Dim addCheque As New add_cheque(True, False)
                    addCheque.ShowDialog()
                Case "chemitidos"
                    Dim addCheque As New add_cheque(False, True)
                    addCheque.ShowDialog()
                Case "chcartera"
                    Dim frm As New add_cheque()
                    frm.ShowDialog()
                Case "impuestos"
                    Dim frm As New add_impuesto()
                    frm.ShowDialog()
                Case "condiciones_venta"
                    Dim frm As New add_condicion_venta()
                    frm.ShowDialog()
                Case "condiciones_compra"
                    Dim frm As New add_condicion_compra()
                    frm.ShowDialog()
                Case "conceptos_compra"
                    Dim frm As New add_concepto_compra()
                    frm.ShowDialog()
                Case "itemsimpuestos"
                    Dim frm As New add_itemImpuesto()
                    frm.ShowDialog()
                Case "ordenescompras"
                    Dim frm As New add_ordenCompra()
                    frm.ShowDialog()
                Case "comprobantes_compras"
                    Dim frm As New add_comprobantes_compras()
                    frm.ShowDialog()
                Case "pagos"
                    Dim frm As New add_pago()
                    frm.ShowDialog()
                Case "ajustes_stock"
                    tabla = "ajustes_stock"
                    Dim frm As New add_ajuste_stock()
                    frm.ShowDialog()
                Case "registros_stock"
                    tabla = "items_registros_stock"
                    Dim frm As New add_stock()
                    frm.ShowDialog()
                    tabla = "registros_stock"
                Case "produccion"
                    Dim frm As New add_produccion()
                    frm.ShowDialog()
                Case "pedidos"
                    Dim frm As New add_pedido()
                    frm.ShowDialog()
                Case "cobros"
                    Dim frm As New add_cobro()
                    frm.ShowDialog()
                Case "cpersonalizadas"
                    Dim frm As New grilla_resultados()
                    frm.ShowDialog()
                Case "perfiles"
                    Dim frm As New add_perfil()
                    frm.ShowDialog()
                Case "permisos"
                    Dim frm As New add_permiso()
                    frm.ShowDialog()
                Case "usuarios"
                    Dim frm As New add_usuario()
                    frm.ShowDialog()
                Case "permisos_a_perfiles", "perfiles_a_usuarios"
                    ' No hacer nada para estos casos
                Case Else
                    ShowWarning($"Tipo de registro '{recordType}' no reconocido", "Error")
            End Select
        Catch ex As Exception
            ShowError($"Error abriendo formulario de {recordType}: {ex.Message}", "Error")
        End Try
    End Sub
    
    ''' <summary>
    ''' Maneja la búsqueda de registros
    ''' </summary>
    Public Sub HandleSearch(searchType As String)
        Try
            Select Case searchType.ToLower()
                Case "clientes"
                    tabla = "clientes"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "proveedores"
                    tabla = "proveedores"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "items"
                    tabla = "items"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "pedidos"
                    tabla = "pedidos"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "comprobantes"
                    tabla = "comprobantes"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "usuarios"
                    tabla = "usuarios"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "perfiles"
                    tabla = "perfiles"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "permisos"
                    tabla = "permisos"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "cajas"
                    tabla = "cajas"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "bancos"
                    tabla = "bancos"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "impuestos"
                    tabla = "impuestos"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "marcas"
                    tabla = "marcasItems"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "tipositems"
                    tabla = "tiposItems"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "condicionesventas"
                    tabla = "condicionesVentas"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "condicionescompras"
                    tabla = "condicionesCompras"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "conceptoscompras"
                    tabla = "conceptosCompras"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "cuentasbancarias"
                    tabla = "cuentasBancarias"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "transferencias"
                    tabla = "transferencias"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "ajustesstock"
                    tabla = "ajustesStock"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "asocitems"
                    tabla = "asocItems"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "ccclientes"
                    tabla = "ccClientes"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "ccproveedores"
                    tabla = "ccProveedores"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "cheques"
                    tabla = "cheques"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "cobros"
                    tabla = "cobros"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "cobrosretenciones"
                    tabla = "cobrosRetenciones"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "comprobantescompras"
                    tabla = "comprobantesCompras"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "ordenescompras"
                    tabla = "ordenesCompras"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "pagos"
                    tabla = "pagos"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "producciones"
                    tabla = "producciones"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case "stocks"
                    tabla = "registrosStock"
                    Dim frm As New search()
                    frm.ShowDialog()
                Case Else
                    ShowWarning($"Tipo de búsqueda '{searchType}' no reconocido", "Error")
            End Select
        Catch ex As Exception
            ShowError($"Error abriendo búsqueda de {searchType}: {ex.Message}", "Error")
        End Try
    End Sub
    
    ''' <summary>
    ''' Maneja las consultas especiales
    ''' </summary>
    Public Sub HandleSpecialQueries(queryType As String)
        Try
            Select Case queryType.ToLower()
                Case "ultimocomprobante"
                    Dim frm As New frm_ultimo_comprobante()
                    frm.ShowDialog()
                Case "infoccclientes"
                    Dim frm As New infoccClientes()
                    frm.ShowDialog()
                Case "infoccproveedores"
                    Dim frm As New infoccProveedores()
                    frm.ShowDialog()
                Case "infofc"
                    Dim frm As New info_fc()
                    frm.ShowDialog()
                Case "cheques"
                    Dim frm As New frmCheques()
                    frm.ShowDialog()
                Case "pruebasafip"
                    Dim frm As New frm_pruebas_afip()
                    frm.ShowDialog()
                Case Else
                    ShowWarning($"Tipo de consulta '{queryType}' no reconocido", "Error")
            End Select
        Catch ex As Exception
            ShowError($"Error abriendo consulta {queryType}: {ex.Message}", "Error")
        End Try
    End Sub
    
    ''' <summary>
    ''' Maneja los reportes
    ''' </summary>
    Public Sub HandleReports(reportType As String)
        Try
            Select Case reportType.ToLower()
                Case "comprobante"
                    Dim frm As New frm_prnCmp()
                    frm.ShowDialog()
                Case "comprobantecompra"
                    Dim frm As New frm_prnComprobanteCompra()
                    frm.ShowDialog()
                Case "recibocobro"
                    Dim frm As New frm_prnReciboCobro()
                    frm.ShowDialog()
                Case "ordendepago"
                    Dim frm As New frm_prnOrdenDePago()
                    frm.ShowDialog()
                Case "reportes"
                    Dim frm As New frm_prnReportes()
                    frm.ShowDialog()
                Case Else
                    ShowWarning($"Tipo de reporte '{reportType}' no reconocido", "Error")
            End Select
        Catch ex As Exception
            ShowError($"Error abriendo reporte {reportType}: {ex.Message}", "Error")
        End Try
    End Sub
    
    ''' <summary>
    ''' Maneja las operaciones de configuración
    ''' </summary>
    Public Sub HandleConfiguration(configType As String)
        Try
            Select Case configType.ToLower()
                Case "configuracion"
                    Dim frm As New config()
                    frm.ShowDialog()
                Case "backup"
                    Dim frm As New BackupDB()
                    frm.ShowDialog()
                Case "acercade"
                    Dim frm As New frmacercade()
                    frm.ShowDialog()
                Case "exportasiap"
                    Dim frm As New frm_exportaSiap()
                    frm.ShowDialog()
                Case Else
                    ShowWarning($"Tipo de configuración '{configType}' no reconocido", "Error")
            End Select
        Catch ex As Exception
            ShowError($"Error abriendo configuración {configType}: {ex.Message}", "Error")
        End Try
    End Sub
    
End Module
