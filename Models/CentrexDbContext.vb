Imports System.Data.Entity

' Contexto principal de Entity Framework
' Usa la cadena de conexión definida en App.config (name=CentrexConnection)
Public Class CentrexDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=CentrexConnection")
    End Sub

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    ' DbSets principales detectados por las consultas SQL y uso en código
    Public Property Clientes As DbSet(Of ClienteEntity)
    Public Property Proveedores As DbSet(Of ProveedorEntity)
    Public Property Usuarios As DbSet(Of UsuarioEntity)
    Public Property Perfiles As DbSet(Of PerfilEntity)
    Public Property Items As DbSet(Of ItemEntity)
    Public Property Marcas As DbSet(Of MarcaEntity)
    Public Property TiposItems As DbSet(Of TipoItemEntity)
    Public Property Pedidos As DbSet(Of PedidoEntity)
    Public Property Comprobantes As DbSet(Of ComprobanteEntity)
    Public Property TiposComprobantes As DbSet(Of TipoComprobanteEntity)
    Public Property CcClientes As DbSet(Of CcClienteEntity)
    Public Property CcProveedores As DbSet(Of CcProveedorEntity)
    Public Property Provincias As DbSet(Of ProvinciaEntity)
    Public Property Paises As DbSet(Of PaisEntity)
    Public Property Bancos As DbSet(Of BancoEntity)
    Public Property CuentasBancarias As DbSet(Of CuentaBancariaEntity)
    Public Property Cheques As DbSet(Of ChequeEntity)
    Public Property PedidosItems As DbSet(Of PedidoItemEntity)
    Public Property Cobros As DbSet(Of CobroEntity)
    Public Property CobrosCheques As DbSet(Of CobroChequeEntity)
    Public Property CobrosNFacturasImportes As DbSet(Of CobroNFacturaImporteEntity)
    Public Property CobrosRetenciones As DbSet(Of CobroRetencionEntity)
    Public Property Pagos As DbSet(Of PagoEntity)
    Public Property Impuestos As DbSet(Of ImpuestoEntity)
    Public Property SysEstadosCheques As DbSet(Of EstadoChequeEntity)
    Public Property TmpTransferencias As DbSet(Of TmpTransferenciaEntity)
    Public Property TmpCobrosRetenciones As DbSet(Of TmpCobroRetencionEntity)
    Public Property ListasPrecios As DbSet(Of ListaPrecioEntity)
    Public Property Precios As DbSet(Of PrecioEntity)
    Public Property AsocItems As DbSet(Of AsocItemEntity)
    Public Property Localidades As DbSet(Of LocalidadEntity)
    Public Property RegistrosStock As DbSet(Of RegistroStockEntity)
    Public Property AjustesStock As DbSet(Of AjusteStockEntity)
    Public Property Producciones As DbSet(Of ProduccionEntity)
    Public Property ProduccionItems As DbSet(Of ProduccionItemEntity)
    Public Property ProduccionAsocItems As DbSet(Of ProduccionAsocItemEntity)
    Public Property OrdenesCompras As DbSet(Of OrdenCompraEntity)
    Public Property OrdenesComprasItems As DbSet(Of OrdenCompraItemEntity)
    Public Property ComprobantesCompras As DbSet(Of ComprobanteCompraEntity)
    Public Property ComprobantesComprasItems As DbSet(Of ComprobanteCompraItemEntity)
    Public Property ComprobantesComprasImpuestos As DbSet(Of ComprobanteCompraImpuestoEntity)
    Public Property ComprobantesComprasConceptos As DbSet(Of ComprobanteCompraConceptoEntity)
    Public Property TiposDocumentos As DbSet(Of TipoDocumentoEntity)
    Public Property ClasesFiscales As DbSet(Of ClaseFiscalEntity)
    Public Property ModosMiPyme As DbSet(Of ModoMiPymeEntity)
    Public Property Permisos As DbSet(Of PermisoEntity)
    Public Property UsuariosPerfiles As DbSet(Of UsuarioPerfilEntity)
    Public Property PerfilesPermisos As DbSet(Of PerfilPermisoEntity)
    Public Property TmpProduccionItems As DbSet(Of TmpProduccionItemEntity)
    Public Property TmpProduccionAsocItems As DbSet(Of TmpProduccionAsocItemEntity)
    Public Property TmpOrdenCompraItems As DbSet(Of TmpOrdenCompraItemEntity)
    Public Property TmpPedidoItems As DbSet(Of TmpPedidoItemEntity)
    Public Property TmpRegistroStock As DbSet(Of TmpRegistroStockEntity)
    Public Property TmpSelCh As DbSet(Of TmpSelChEntity)
    Public Property Pagos As DbSet(Of PagoEntity)
    Public Property PagosCheques As DbSet(Of PagoChequeEntity)
    Public Property PagosNFacturasImportes As DbSet(Of PagoNFacturaImporteEntity)
    Public Property Transferencias As DbSet(Of TransferenciaEntity)
    Public Property Retenciones As DbSet(Of RetencionEntity)
    Public Property CcClientesNombres As DbSet(Of CuentaCorrienteClienteNombreEntity)
    Public Property CcProveedoresNombres As DbSet(Of CuentaCorrienteProveedorNombreEntity)
    Public Property CuentasBancariasMovimientos As DbSet(Of CuentaBancariaMovimientoEntity)
    Public Property TiposCuentasBancarias As DbSet(Of BancoCuentaTipoEntity)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

        ' Convenciones y mapeos básicos
        ' Clientes
        modelBuilder.Entity(Of ClienteEntity)().ToTable("clientes").HasKey(Function(c) c.IdCliente)
        modelBuilder.Entity(Of ClienteEntity)().Property(Function(c) c.IdCliente).HasColumnName("id_cliente")
        modelBuilder.Entity(Of ClienteEntity)().Property(Function(c) c.RazonSocial).HasColumnName("razon_social")
        modelBuilder.Entity(Of ClienteEntity)().Property(Function(c) c.NombreFantasia).HasColumnName("nombre_fantasia")
        modelBuilder.Entity(Of ClienteEntity)().Property(Function(c) c.LimiteCredito).HasColumnName("limite_credito")
        modelBuilder.Entity(Of ClienteEntity)().Property(Function(c) c.Activo).HasColumnName("activo")
        modelBuilder.Entity(Of ClienteEntity)().Property(Function(c) c.IdProvinciaFiscal).HasColumnName("id_provinciaFiscal")
        modelBuilder.Entity(Of ClienteEntity)().Property(Function(c) c.IdProvinciaEntrega).HasColumnName("id_provinciaEntrega")

        ' Items
        modelBuilder.Entity(Of ItemEntity)().ToTable("items").HasKey(Function(i) i.IdItem)
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.Item).HasColumnName("item")
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.Descript).HasColumnName("descript")
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.StockActual).HasColumnName("stock_actual")
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.Activo).HasColumnName("activo")
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.IdMarca).HasColumnName("id_marca")
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.IdTipo).HasColumnName("id_tipo")
        modelBuilder.Entity(Of ItemEntity)().Property(Function(i) i.IdProveedor).HasColumnName("id_proveedor")

        ' Pedidos
        modelBuilder.Entity(Of PedidoEntity)().ToTable("pedidos").HasKey(Function(p) p.IdPedido)
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.IdPedido).HasColumnName("id_pedido")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.IdCliente).HasColumnName("id_cliente")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.IdComprobante).HasColumnName("id_comprobante")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.IdTipoComprobante).HasColumnName("id_tipoComprobante")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.NumeroComprobante).HasColumnName("numeroComprobante")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.PuntoVenta).HasColumnName("puntoVenta")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.SubTotal).HasColumnName("subTotal")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.Iva).HasColumnName("iva")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.Total).HasColumnName("total")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.Cae).HasColumnName("cae")
        ' Campos de QR: soporta dos nombres de columna posibles
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.FcQr).HasColumnName("fc_qr")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.CodigoQR).HasColumnName("codigoQR")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.Activo).HasColumnName("activo")
        modelBuilder.Entity(Of PedidoEntity)().Property(Function(p) p.Cerrado).HasColumnName("cerrado")

        ' Relaciones básicas (si las llaves foráneas existen)
        modelBuilder.Entity(Of PedidoEntity)() _
            .HasRequired(Function(p) p.Cliente) _
            .WithMany() _
            .HasForeignKey(Function(p) p.IdCliente)

        modelBuilder.Entity(Of PedidoEntity)() _
            .HasRequired(Function(p) p.Comprobante) _
            .WithMany() _
            .HasForeignKey(Function(p) p.IdComprobante)

        modelBuilder.Entity(Of PedidoEntity)() _
            .HasRequired(Function(p) p.TipoComprobante) _
            .WithMany() _
            .HasForeignKey(Function(p) p.IdTipoComprobante)

        ' Comprobantes
        modelBuilder.Entity(Of ComprobanteEntity)().ToTable("comprobantes").HasKey(Function(c) c.IdComprobante)
        modelBuilder.Entity(Of ComprobanteEntity)().Property(Function(c) c.IdComprobante).HasColumnName("id_comprobante")
        modelBuilder.Entity(Of ComprobanteEntity)().Property(Function(c) c.Comprobante).HasColumnName("comprobante")
        modelBuilder.Entity(Of ComprobanteEntity)().Property(Function(c) c.PuntoVenta).HasColumnName("puntoVenta")
        modelBuilder.Entity(Of ComprobanteEntity)().Property(Function(c) c.IdTipoComprobante).HasColumnName("id_tipoComprobante")
        modelBuilder.Entity(Of ComprobanteEntity)().Property(Function(c) c.EsPresupuesto).HasColumnName("esPresupuesto")
        modelBuilder.Entity(Of ComprobanteEntity)().Property(Function(c) c.EsManual).HasColumnName("esManual")

        ' Tipos de comprobantes
        modelBuilder.Entity(Of TipoComprobanteEntity)().ToTable("tipos_comprobantes").HasKey(Function(tc) tc.IdTipoComprobante)
        modelBuilder.Entity(Of TipoComprobanteEntity)().Property(Function(tc) tc.IdTipoComprobante).HasColumnName("id_tipoComprobante")
        modelBuilder.Entity(Of TipoComprobanteEntity)().Property(Function(tc) tc.Tipo).HasColumnName("tipo")

        ' Cuentas corrientes de clientes
        modelBuilder.Entity(Of CcClienteEntity)().ToTable("cc_clientes").HasKey(Function(cc) cc.IdCc)
        modelBuilder.Entity(Of CcClienteEntity)().Property(Function(cc) cc.IdCc).HasColumnName("id_cc")
        modelBuilder.Entity(Of CcClienteEntity)().Property(Function(cc) cc.IdCliente).HasColumnName("id_cliente")
        modelBuilder.Entity(Of CcClienteEntity)().Property(Function(cc) cc.Debe).HasColumnName("debe")
        modelBuilder.Entity(Of CcClienteEntity)().Property(Function(cc) cc.Haber).HasColumnName("haber")

        ' Cuentas corrientes de proveedores
        modelBuilder.Entity(Of CcProveedorEntity)().ToTable("cc_proveedores").HasKey(Function(cc) cc.IdCc)
        modelBuilder.Entity(Of CcProveedorEntity)().Property(Function(cc) cc.IdCc).HasColumnName("id_cc")
        modelBuilder.Entity(Of CcProveedorEntity)().Property(Function(cc) cc.IdProveedor).HasColumnName("id_proveedor")
        modelBuilder.Entity(Of CcProveedorEntity)().Property(Function(cc) cc.Debe).HasColumnName("debe")
        modelBuilder.Entity(Of CcProveedorEntity)().Property(Function(cc) cc.Haber).HasColumnName("haber")

        ' Proveedores
        modelBuilder.Entity(Of ProveedorEntity)().ToTable("proveedores").HasKey(Function(p) p.IdProveedor)
        modelBuilder.Entity(Of ProveedorEntity)().Property(Function(p) p.IdProveedor).HasColumnName("id_proveedor")
        modelBuilder.Entity(Of ProveedorEntity)().Property(Function(p) p.RazonSocial).HasColumnName("razon_social")
        modelBuilder.Entity(Of ProveedorEntity)().Property(Function(p) p.Activo).HasColumnName("activo")

        ' Usuarios
        modelBuilder.Entity(Of UsuarioEntity)().ToTable("usuarios").HasKey(Function(u) u.IdUsuario)
        modelBuilder.Entity(Of UsuarioEntity)().Property(Function(u) u.IdUsuario).HasColumnName("id_usuario")
        modelBuilder.Entity(Of UsuarioEntity)().Property(Function(u) u.Usuario).HasColumnName("usuario")
        modelBuilder.Entity(Of UsuarioEntity)().Property(Function(u) u.Nombre).HasColumnName("nombre")

        ' Perfiles
        modelBuilder.Entity(Of PerfilEntity)().ToTable("perfiles").HasKey(Function(p) p.IdPerfil)
        modelBuilder.Entity(Of PerfilEntity)().Property(Function(p) p.IdPerfil).HasColumnName("id_perfil")
        modelBuilder.Entity(Of PerfilEntity)().Property(Function(p) p.Nombre).HasColumnName("nombre")

        ' Marcas
        modelBuilder.Entity(Of MarcaEntity)().ToTable("marcas").HasKey(Function(m) m.IdMarca)
        modelBuilder.Entity(Of MarcaEntity)().Property(Function(m) m.IdMarca).HasColumnName("id_marca")
        modelBuilder.Entity(Of MarcaEntity)().Property(Function(m) m.Marca).HasColumnName("marca")

        ' Tipos de items
        modelBuilder.Entity(Of TipoItemEntity)().ToTable("tipos_items").HasKey(Function(t) t.IdTipo)
        modelBuilder.Entity(Of TipoItemEntity)().Property(Function(t) t.IdTipo).HasColumnName("id_tipo")
        modelBuilder.Entity(Of TipoItemEntity)().Property(Function(t) t.Tipo).HasColumnName("tipo")

        ' Provincias y Países
        modelBuilder.Entity(Of ProvinciaEntity)().ToTable("provincias").HasKey(Function(p) p.IdProvincia)
        modelBuilder.Entity(Of ProvinciaEntity)().Property(Function(p) p.IdProvincia).HasColumnName("id_provincia")
        modelBuilder.Entity(Of ProvinciaEntity)().Property(Function(p) p.Provincia).HasColumnName("provincia")
        modelBuilder.Entity(Of ProvinciaEntity)().Property(Function(p) p.IdPais).HasColumnName("id_pais")

        modelBuilder.Entity(Of PaisEntity)().ToTable("paises").HasKey(Function(p) p.IdPais)
        modelBuilder.Entity(Of PaisEntity)().Property(Function(p) p.IdPais).HasColumnName("id_pais")
        modelBuilder.Entity(Of PaisEntity)().Property(Function(p) p.Pais).HasColumnName("pais")

        ' Bancos y Cuentas Bancarias
        modelBuilder.Entity(Of BancoEntity)().ToTable("bancos").HasKey(Function(b) b.IdBanco)
        modelBuilder.Entity(Of BancoEntity)().Property(Function(b) b.IdBanco).HasColumnName("id_banco")
        modelBuilder.Entity(Of BancoEntity)().Property(Function(b) b.Nombre).HasColumnName("nombre")
        modelBuilder.Entity(Of BancoEntity)().Property(Function(b) b.IdPais).HasColumnName("id_pais")
        modelBuilder.Entity(Of BancoEntity)().Property(Function(b) b.NumeroBanco).HasColumnName("n_banco")
        modelBuilder.Entity(Of BancoEntity)().Property(Function(b) b.Activo).HasColumnName("activo")

        modelBuilder.Entity(Of CuentaBancariaEntity)().ToTable("cuentas_bancarias").HasKey(Function(cb) cb.IdCuentaBancaria)
        modelBuilder.Entity(Of CuentaBancariaEntity)().Property(Function(cb) cb.IdCuentaBancaria).HasColumnName("id_cuentaBancaria")
        modelBuilder.Entity(Of CuentaBancariaEntity)().Property(Function(cb) cb.Nombre).HasColumnName("nombre")
        modelBuilder.Entity(Of CuentaBancariaEntity)().Property(Function(cb) cb.IdBanco).HasColumnName("id_banco")

        ' Cheques
        modelBuilder.Entity(Of ChequeEntity)().ToTable("cheques").HasKey(Function(ch) ch.IdCheque)
        modelBuilder.Entity(Of ChequeEntity)().Property(Function(ch) ch.IdCheque).HasColumnName("id_cheque")
        modelBuilder.Entity(Of ChequeEntity)().Property(Function(ch) ch.IdCliente).HasColumnName("id_cliente")
        modelBuilder.Entity(Of ChequeEntity)().Property(Function(ch) ch.IdBanco).HasColumnName("id_banco")
        modelBuilder.Entity(Of ChequeEntity)().Property(Function(ch) ch.NCheque).HasColumnName("nCheque")
        modelBuilder.Entity(Of ChequeEntity)().Property(Function(ch) ch.Importe).HasColumnName("importe")
        modelBuilder.Entity(Of ChequeEntity)().Property(Function(ch) ch.IdEstadoCh).HasColumnName("id_estadoch")

        modelBuilder.Entity(Of EstadoChequeEntity)().ToTable("sysestados_cheques").HasKey(Function(e) e.IdEstadoCh)
        modelBuilder.Entity(Of EstadoChequeEntity)().Property(Function(e) e.IdEstadoCh).HasColumnName("id_estadoch")
        modelBuilder.Entity(Of EstadoChequeEntity)().Property(Function(e) e.Estado).HasColumnName("estado")

        ' Pedidos items
        modelBuilder.Entity(Of PedidoItemEntity)().ToTable("pedidos_items").HasKey(Function(pi) pi.IdPedidoItem)
        modelBuilder.Entity(Of PedidoItemEntity)().Property(Function(pi) pi.IdPedidoItem).HasColumnName("id_pedido_item")
        modelBuilder.Entity(Of PedidoItemEntity)().Property(Function(pi) pi.IdPedido).HasColumnName("id_pedido")
        modelBuilder.Entity(Of PedidoItemEntity)().Property(Function(pi) pi.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of PedidoItemEntity)().Property(Function(pi) pi.Cantidad).HasColumnName("cantidad")
        modelBuilder.Entity(Of PedidoItemEntity)().Property(Function(pi) pi.Precio).HasColumnName("precio")

        ' Cobros / Pagos / Impuestos
        modelBuilder.Entity(Of CobroEntity)().ToTable("cobros").HasKey(Function(c) c.IdCobro)
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.IdCobro).HasColumnName("id_cobro")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.IdCobroOficial).HasColumnName("id_cobro_oficial")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.IdCobroNoOficial).HasColumnName("id_cobro_no_oficial")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.FechaCarga).HasColumnName("fecha_carga")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.FechaCobro).HasColumnName("fecha_cobro")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.IdCliente).HasColumnName("id_cliente")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.IdCc).HasColumnName("id_cc")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.DineroEnCc).HasColumnName("dineroEnCc")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.Efectivo).HasColumnName("efectivo")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.TotalTransferencia).HasColumnName("totalTransferencia")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.TotalCh).HasColumnName("totalCh")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.TotalRetencion).HasColumnName("totalRetencion")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.Total).HasColumnName("total")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.HayCheque).HasColumnName("hayCheque")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.HayTransferencia).HasColumnName("hayTransferencia")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.HayRetencion).HasColumnName("hayRetencion")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.Activo).HasColumnName("activo")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.IdAnulaCobro).HasColumnName("id_anulaCobro")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.Notas).HasColumnName("notas")
        modelBuilder.Entity(Of CobroEntity)().Property(Function(c) c.Firmante).HasColumnName("firmante")

        modelBuilder.Entity(Of CobroChequeEntity)().ToTable("cobros_cheques").HasKey(Function(x) New With {x.IdCobro, x.IdCheque})
        modelBuilder.Entity(Of CobroChequeEntity)().Property(Function(x) x.IdCobro).HasColumnName("id_cobro")
        modelBuilder.Entity(Of CobroChequeEntity)().Property(Function(x) x.IdCheque).HasColumnName("id_cheque")

        modelBuilder.Entity(Of CobroNFacturaImporteEntity)().ToTable("cobros_Nfacturas_importes").HasKey(Function(x) New With {x.IdCobro, x.NFactura})
        modelBuilder.Entity(Of CobroNFacturaImporteEntity)().Property(Function(x) x.IdCobro).HasColumnName("id_cobro")
        modelBuilder.Entity(Of CobroNFacturaImporteEntity)().Property(Function(x) x.Fecha).HasColumnName("fecha")
        modelBuilder.Entity(Of CobroNFacturaImporteEntity)().Property(Function(x) x.NFactura).HasColumnName("nfactura")
        modelBuilder.Entity(Of CobroNFacturaImporteEntity)().Property(Function(x) x.Importe).HasColumnName("importe")

        modelBuilder.Entity(Of CobroRetencionEntity)().ToTable("cobros_retenciones").HasKey(Function(x) x.IdRetencion)
        modelBuilder.Entity(Of CobroRetencionEntity)().Property(Function(x) x.IdRetencion).HasColumnName("id_retencion")
        modelBuilder.Entity(Of CobroRetencionEntity)().Property(Function(x) x.IdCobro).HasColumnName("id_cobro")
        modelBuilder.Entity(Of CobroRetencionEntity)().Property(Function(x) x.IdImpuesto).HasColumnName("id_impuesto")
        modelBuilder.Entity(Of CobroRetencionEntity)().Property(Function(x) x.Total).HasColumnName("total")
        modelBuilder.Entity(Of CobroRetencionEntity)().Property(Function(x) x.Notas).HasColumnName("notas")

        modelBuilder.Entity(Of PagoEntity)().ToTable("pagos").HasKey(Function(p) p.IdPago)
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.IdPago).HasColumnName("id_pago")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.IdProveedor).HasColumnName("id_proveedor")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.Total).HasColumnName("total")

        modelBuilder.Entity(Of ImpuestoEntity)().ToTable("impuestos").HasKey(Function(i) i.IdImpuesto)
        modelBuilder.Entity(Of ImpuestoEntity)().Property(Function(i) i.IdImpuesto).HasColumnName("id_impuesto")
        modelBuilder.Entity(Of ImpuestoEntity)().Property(Function(i) i.Nombre).HasColumnName("nombre")

        ' Temporales
        modelBuilder.Entity(Of TmpTransferenciaEntity)().ToTable("tmptransferencias").HasKey(Function(t) t.IdTmpTransferencia)
        modelBuilder.Entity(Of TmpTransferenciaEntity)().Property(Function(t) t.IdTmpTransferencia).HasColumnName("id_tmpTransferencia")
        modelBuilder.Entity(Of TmpTransferenciaEntity)().Property(Function(t) t.IdCuentaBancaria).HasColumnName("id_cuentaBancaria")
        modelBuilder.Entity(Of TmpTransferenciaEntity)().Property(Function(t) t.Fecha).HasColumnName("fecha")

        modelBuilder.Entity(Of TmpCobroRetencionEntity)().ToTable("tmpcobros_retenciones").HasKey(Function(t) t.IdTmpRetencion)
        modelBuilder.Entity(Of TmpCobroRetencionEntity)().Property(Function(t) t.IdTmpRetencion).HasColumnName("id_tmpRetencion")
        modelBuilder.Entity(Of TmpCobroRetencionEntity)().Property(Function(t) t.IdImpuesto).HasColumnName("id_impuesto")
        modelBuilder.Entity(Of TmpCobroRetencionEntity)().Property(Function(t) t.Total).HasColumnName("total")
        modelBuilder.Entity(Of TmpCobroRetencionEntity)().Property(Function(t) t.Notas).HasColumnName("notas")

        ' Catálogo precios y asociaciones
        modelBuilder.Entity(Of ListaPrecioEntity)().ToTable("listas_precios").HasKey(Function(l) l.IdListaPrecio)
        modelBuilder.Entity(Of ListaPrecioEntity)().Property(Function(l) l.IdListaPrecio).HasColumnName("id_listaPrecio")
        modelBuilder.Entity(Of ListaPrecioEntity)().Property(Function(l) l.Nombre).HasColumnName("nombre")

        modelBuilder.Entity(Of PrecioEntity)().ToTable("precios").HasKey(Function(p) p.IdPrecio)
        modelBuilder.Entity(Of PrecioEntity)().Property(Function(p) p.IdPrecio).HasColumnName("id_precio")
        modelBuilder.Entity(Of PrecioEntity)().Property(Function(p) p.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of PrecioEntity)().Property(Function(p) p.IdListaPrecio).HasColumnName("id_listaPrecio")
        modelBuilder.Entity(Of PrecioEntity)().Property(Function(p) p.Precio).HasColumnName("precio")

        modelBuilder.Entity(Of AsocItemEntity)().ToTable("asoc_items").HasKey(Function(a) a.IdAsocItem)
        modelBuilder.Entity(Of AsocItemEntity)().Property(Function(a) a.IdAsocItem).HasColumnName("id_asocItem")
        modelBuilder.Entity(Of AsocItemEntity)().Property(Function(a) a.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of AsocItemEntity)().Property(Function(a) a.IdItemAsociado).HasColumnName("id_item_asociado")

        ' Localidades
        modelBuilder.Entity(Of LocalidadEntity)().ToTable("localidades").HasKey(Function(l) l.IdLocalidad)
        modelBuilder.Entity(Of LocalidadEntity)().Property(Function(l) l.IdLocalidad).HasColumnName("id_localidad")
        modelBuilder.Entity(Of LocalidadEntity)().Property(Function(l) l.Localidad).HasColumnName("localidad")
        modelBuilder.Entity(Of LocalidadEntity)().Property(Function(l) l.IdProvincia).HasColumnName("id_provincia")

        ' Stock / Producción
        modelBuilder.Entity(Of RegistroStockEntity)().ToTable("registros_stock").HasKey(Function(r) r.IdRegistroStock)
        modelBuilder.Entity(Of RegistroStockEntity)().Property(Function(r) r.IdRegistroStock).HasColumnName("id_registro_stock")
        modelBuilder.Entity(Of RegistroStockEntity)().Property(Function(r) r.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of RegistroStockEntity)().Property(Function(r) r.IdProveedor).HasColumnName("id_proveedor")
        modelBuilder.Entity(Of RegistroStockEntity)().Property(Function(r) r.Cantidad).HasColumnName("cantidad")

        modelBuilder.Entity(Of AjusteStockEntity)().ToTable("ajustes_stock").HasKey(Function(a) a.IdAjusteStock)
        modelBuilder.Entity(Of AjusteStockEntity)().Property(Function(a) a.IdAjusteStock).HasColumnName("id_ajuste_stock")
        modelBuilder.Entity(Of AjusteStockEntity)().Property(Function(a) a.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of AjusteStockEntity)().Property(Function(a) a.Cantidad).HasColumnName("cantidad")

        modelBuilder.Entity(Of ProduccionEntity)().ToTable("produccion").HasKey(Function(p) p.IdProduccion)
        modelBuilder.Entity(Of ProduccionEntity)().Property(Function(p) p.IdProduccion).HasColumnName("id_produccion")
        modelBuilder.Entity(Of ProduccionEntity)().Property(Function(p) p.IdProveedor).HasColumnName("id_proveedor")
        modelBuilder.Entity(Of ProduccionEntity)().Property(Function(p) p.IdUsuario).HasColumnName("id_usuario")

        ' Producción relacionados
        modelBuilder.Entity(Of ProduccionItemEntity)().ToTable("produccion_items").HasKey(Function(p) p.id_produccionItem)
        modelBuilder.Entity(Of ProduccionAsocItemEntity)().ToTable("produccion_asocItems").HasKey(Function(p) p.id_produccionAsocItem)

        ' Compras: Ordenes y Comprobantes
        modelBuilder.Entity(Of OrdenCompraEntity)().ToTable("ordenes_compras").HasKey(Function(o) o.id_ordenCompra)
        modelBuilder.Entity(Of OrdenCompraItemEntity)().ToTable("ordenesCompras_items").HasKey(Function(i) i.id_ordenCompraItem)
        modelBuilder.Entity(Of ComprobanteCompraEntity)().ToTable("comprobantes_compras").HasKey(Function(c) c.id_comprobanteCompra)
        modelBuilder.Entity(Of ComprobanteCompraItemEntity)().ToTable("comprobantes_compras_items").HasKey(Function(ci) ci.id_comprobanteCompraItem)
        modelBuilder.Entity(Of ComprobanteCompraImpuestoEntity)().ToTable("comprobantes_compras_impuestos").HasKey(Function(x) x.id_comprobanteCompraImpuesto)
        modelBuilder.Entity(Of ComprobanteCompraConceptoEntity)().ToTable("comprobantes_compras_conceptos").HasKey(Function(x) x.id_comprobanteCompraConcepto)

        ' Configuración / AFIP
        modelBuilder.Entity(Of TipoDocumentoEntity)().ToTable("tipos_documentos").HasKey(Function(t) t.IdTipoDocumento)
        modelBuilder.Entity(Of TipoDocumentoEntity)().Property(Function(t) t.IdTipoDocumento).HasColumnName("id_tipoDocumento")
        modelBuilder.Entity(Of TipoDocumentoEntity)().Property(Function(t) t.Documento).HasColumnName("documento")

        modelBuilder.Entity(Of ClaseFiscalEntity)().ToTable("sys_ClasesFiscales").HasKey(Function(c) c.IdClaseFiscal)
        modelBuilder.Entity(Of ClaseFiscalEntity)().Property(Function(c) c.IdClaseFiscal).HasColumnName("id_claseFiscal")
        modelBuilder.Entity(Of ClaseFiscalEntity)().Property(Function(c) c.Descript).HasColumnName("descript")

        modelBuilder.Entity(Of ModoMiPymeEntity)().ToTable("modos_mipyme").HasKey(Function(m) m.IdModoMiPyme)
        modelBuilder.Entity(Of ModoMiPymeEntity)().Property(Function(m) m.IdModoMiPyme).HasColumnName("id_modoMiPyme")
        modelBuilder.Entity(Of ModoMiPymeEntity)().Property(Function(m) m.Abreviatura).HasColumnName("abreviatura")

        ' Seguridad / permisos
        modelBuilder.Entity(Of PermisoEntity)().ToTable("permisos").HasKey(Function(p) p.IdPermiso)
        modelBuilder.Entity(Of PermisoEntity)().Property(Function(p) p.IdPermiso).HasColumnName("id_permiso")
        modelBuilder.Entity(Of PermisoEntity)().Property(Function(p) p.Nombre).HasColumnName("nombre")

        modelBuilder.Entity(Of UsuarioPerfilEntity)().ToTable("usuarios_perfiles").HasKey(Function(up) up.IdUsuarioPerfil)
        modelBuilder.Entity(Of UsuarioPerfilEntity)().Property(Function(up) up.IdUsuarioPerfil).HasColumnName("id_usuario_perfil")
        modelBuilder.Entity(Of UsuarioPerfilEntity)().Property(Function(up) up.IdUsuario).HasColumnName("id_usuario")
        modelBuilder.Entity(Of UsuarioPerfilEntity)().Property(Function(up) up.IdPerfil).HasColumnName("id_perfil")

        modelBuilder.Entity(Of PerfilPermisoEntity)().ToTable("perfiles_permisos").HasKey(Function(pp) pp.IdPerfilPermiso)
        modelBuilder.Entity(Of PerfilPermisoEntity)().Property(Function(pp) pp.IdPerfilPermiso).HasColumnName("id_perfil_permiso")
        modelBuilder.Entity(Of PerfilPermisoEntity)().Property(Function(pp) pp.IdPerfil).HasColumnName("id_perfil")
        modelBuilder.Entity(Of PerfilPermisoEntity)().Property(Function(pp) pp.IdPermiso).HasColumnName("id_permiso")

        ' Temporales
        modelBuilder.Entity(Of TmpProduccionItemEntity)().ToTable("tmpproduccion_items").HasKey(Function(t) t.IdTmpProduccionItem)
        modelBuilder.Entity(Of TmpProduccionItemEntity)().Property(Function(t) t.IdTmpProduccionItem).HasColumnName("id_tmpProduccionItem")
        modelBuilder.Entity(Of TmpProduccionItemEntity)().Property(Function(t) t.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of TmpProduccionItemEntity)().Property(Function(t) t.Cantidad).HasColumnName("cantidad")
        modelBuilder.Entity(Of TmpProduccionItemEntity)().Property(Function(t) t.IdUsuario).HasColumnName("id_usuario")

        modelBuilder.Entity(Of TmpProduccionAsocItemEntity)().ToTable("tmpproduccion_asocItems").HasKey(Function(t) t.IdTmpProduccionAsocItem)
        modelBuilder.Entity(Of TmpProduccionAsocItemEntity)().Property(Function(t) t.IdTmpProduccionAsocItem).HasColumnName("id_tmpProduccionAsocItem")
        modelBuilder.Entity(Of TmpProduccionAsocItemEntity)().Property(Function(t) t.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of TmpProduccionAsocItemEntity)().Property(Function(t) t.IdItemAsoc).HasColumnName("id_item_asoc")
        modelBuilder.Entity(Of TmpProduccionAsocItemEntity)().Property(Function(t) t.Cantidad).HasColumnName("cantidad")

        modelBuilder.Entity(Of TmpOrdenCompraItemEntity)().ToTable("tmpOC_items").HasKey(Function(t) t.IdTmpOcItem)
        modelBuilder.Entity(Of TmpOrdenCompraItemEntity)().Property(Function(t) t.IdTmpOcItem).HasColumnName("id_tmpOCItem")
        modelBuilder.Entity(Of TmpOrdenCompraItemEntity)().Property(Function(t) t.IdOrdenCompra).HasColumnName("id_ordenCompra")
        modelBuilder.Entity(Of TmpOrdenCompraItemEntity)().Property(Function(t) t.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of TmpOrdenCompraItemEntity)().Property(Function(t) t.Cantidad).HasColumnName("cantidad")
        modelBuilder.Entity(Of TmpOrdenCompraItemEntity)().Property(Function(t) t.Precio).HasColumnName("precio")

        modelBuilder.Entity(Of TmpPedidoItemEntity)().ToTable("tmppedidos_items").HasKey(Function(t) t.IdTmpPedidoItem)
        modelBuilder.Entity(Of TmpPedidoItemEntity)().Property(Function(t) t.IdTmpPedidoItem).HasColumnName("id_tmppedidos_items")
        modelBuilder.Entity(Of TmpPedidoItemEntity)().Property(Function(t) t.IdPedido).HasColumnName("id_pedido")
        modelBuilder.Entity(Of TmpPedidoItemEntity)().Property(Function(t) t.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of TmpPedidoItemEntity)().Property(Function(t) t.Cantidad).HasColumnName("cantidad")
        modelBuilder.Entity(Of TmpPedidoItemEntity)().Property(Function(t) t.Precio).HasColumnName("precio")

        modelBuilder.Entity(Of TmpRegistroStockEntity)().ToTable("tmpregistros_stock").HasKey(Function(t) t.IdTmpRegistroStock)
        modelBuilder.Entity(Of TmpRegistroStockEntity)().Property(Function(t) t.IdTmpRegistroStock).HasColumnName("id_tmpRegistroStock")
        modelBuilder.Entity(Of TmpRegistroStockEntity)().Property(Function(t) t.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of TmpRegistroStockEntity)().Property(Function(t) t.IdProveedor).HasColumnName("id_proveedor")
        modelBuilder.Entity(Of TmpRegistroStockEntity)().Property(Function(t) t.Cantidad).HasColumnName("cantidad")

        modelBuilder.Entity(Of TmpSelChEntity)().ToTable("tmpSelCH").HasKey(Function(t) t.IdTmpSelCh)
        modelBuilder.Entity(Of TmpSelChEntity)().Property(Function(t) t.IdTmpSelCh).HasColumnName("id_tmpSelCH")
        modelBuilder.Entity(Of TmpSelChEntity)().Property(Function(t) t.IdCheque).HasColumnName("id_cheque")
        modelBuilder.Entity(Of TmpSelChEntity)().Property(Function(t) t.Seleccionado).HasColumnName("seleccionado")

        ' Pagos y transferencias
        modelBuilder.Entity(Of PagoEntity)().ToTable("pagos").HasKey(Function(p) p.IdPago)
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.IdPago).HasColumnName("id_pago")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.FechaCarga).HasColumnName("fecha_carga")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.FechaPago).HasColumnName("fecha_pago")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.IdProveedor).HasColumnName("id_proveedor")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.IdCc).HasColumnName("id_cc")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.DineroEnCc).HasColumnName("dineroEnCc")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.Efectivo).HasColumnName("efectivo")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.TotalTransferencia).HasColumnName("totalTransferencia")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.TotalCh).HasColumnName("totalCh")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.Total).HasColumnName("total")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.HayCheque).HasColumnName("hayCheque")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.HayTransferencia).HasColumnName("hayTransferencia")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.Activo).HasColumnName("activo")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.IdAnulaPago).HasColumnName("id_anulaPago")
        modelBuilder.Entity(Of PagoEntity)().Property(Function(p) p.Notas).HasColumnName("notas")

        modelBuilder.Entity(Of PagoChequeEntity)().ToTable("pagos_cheques").HasKey(Function(x) New With {x.IdPago, x.IdCheque})
        modelBuilder.Entity(Of PagoChequeEntity)().Property(Function(x) x.IdPago).HasColumnName("id_pago")
        modelBuilder.Entity(Of PagoChequeEntity)().Property(Function(x) x.IdCheque).HasColumnName("id_cheque")

        modelBuilder.Entity(Of PagoNFacturaImporteEntity)().ToTable("pagos_nFacturas_importes").HasKey(Function(x) New With {x.IdPago, x.NFactura})
        modelBuilder.Entity(Of PagoNFacturaImporteEntity)().Property(Function(x) x.IdPago).HasColumnName("id_pago")
        modelBuilder.Entity(Of PagoNFacturaImporteEntity)().Property(Function(x) x.Fecha).HasColumnName("fecha")
        modelBuilder.Entity(Of PagoNFacturaImporteEntity)().Property(Function(x) x.NFactura).HasColumnName("nfactura")
        modelBuilder.Entity(Of PagoNFacturaImporteEntity)().Property(Function(x) x.Importe).HasColumnName("importe")

        modelBuilder.Entity(Of TransferenciaEntity)().ToTable("transferencias").HasKey(Function(t) t.IdTransferencia)
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.IdTransferencia).HasColumnName("id_transferencia")
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.IdCobro).HasColumnName("id_cobro")
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.IdPago).HasColumnName("id_pago")
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.IdCuentaBancaria).HasColumnName("id_cuentaBancaria")
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.Fecha).HasColumnName("fecha")
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.Total).HasColumnName("total")
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.NComprobante).HasColumnName("nComprobante")
        modelBuilder.Entity(Of TransferenciaEntity)().Property(Function(t) t.Notas).HasColumnName("notas")

        ' Retenciones
        modelBuilder.Entity(Of RetencionEntity)().ToTable("retenciones").HasKey(Function(r) r.IdRetencion)
        modelBuilder.Entity(Of RetencionEntity)().Property(Function(r) r.IdRetencion).HasColumnName("id_retencion")
        modelBuilder.Entity(Of RetencionEntity)().Property(Function(r) r.Nombre).HasColumnName("nombre")
        modelBuilder.Entity(Of RetencionEntity)().Property(Function(r) r.Porcentaje).HasColumnName("porcentaje")

        ' CC auxiliares (si existen tablas auxiliares de nombres)
        modelBuilder.Entity(Of CuentaCorrienteClienteNombreEntity)().ToTable("cc_clientes_nombres").HasKey(Function(x) x.IdCc)
        modelBuilder.Entity(Of CuentaCorrienteClienteNombreEntity)().Property(Function(x) x.IdCc).HasColumnName("id_cc")
        modelBuilder.Entity(Of CuentaCorrienteClienteNombreEntity)().Property(Function(x) x.Nombre).HasColumnName("nombre")

        modelBuilder.Entity(Of CuentaCorrienteProveedorNombreEntity)().ToTable("cc_proveedores_nombres").HasKey(Function(x) x.IdCc)
        modelBuilder.Entity(Of CuentaCorrienteProveedorNombreEntity)().Property(Function(x) x.IdCc).HasColumnName("id_cc")
        modelBuilder.Entity(Of CuentaCorrienteProveedorNombreEntity)().Property(Function(x) x.Nombre).HasColumnName("nombre")

        ' Movimientos en cuentas bancarias
        modelBuilder.Entity(Of CuentaBancariaMovimientoEntity)().ToTable("cuentas_bancarias_movimientos").HasKey(Function(m) m.IdMovimiento)
        modelBuilder.Entity(Of CuentaBancariaMovimientoEntity)().Property(Function(m) m.IdMovimiento).HasColumnName("id_movimiento")
        modelBuilder.Entity(Of CuentaBancariaMovimientoEntity)().Property(Function(m) m.IdCuentaBancaria).HasColumnName("id_cuentaBancaria")
        modelBuilder.Entity(Of CuentaBancariaMovimientoEntity)().Property(Function(m) m.Fecha).HasColumnName("fecha")
        modelBuilder.Entity(Of CuentaBancariaMovimientoEntity)().Property(Function(m) m.Importe).HasColumnName("importe")
        modelBuilder.Entity(Of CuentaBancariaMovimientoEntity)().Property(Function(m) m.Concepto).HasColumnName("concepto")

        ' Tipos de cuenta bancaria
        modelBuilder.Entity(Of BancoCuentaTipoEntity)().ToTable("tipos_cuentas_bancarias").HasKey(Function(t) t.IdTipoCuenta)
        modelBuilder.Entity(Of BancoCuentaTipoEntity)().Property(Function(t) t.IdTipoCuenta).HasColumnName("id_tipoCuenta")
        modelBuilder.Entity(Of BancoCuentaTipoEntity)().Property(Function(t) t.Nombre).HasColumnName("nombre")

    End Sub
End Class
        ' items_impuestos (relación N a M con clave compuesta)
        modelBuilder.Entity(Of ItemImpuestoEntity)().ToTable("items_impuestos").HasKey(Function(x) New With {x.IdItem, x.IdImpuesto})
        modelBuilder.Entity(Of ItemImpuestoEntity)().Property(Function(x) x.IdItem).HasColumnName("id_item")
        modelBuilder.Entity(Of ItemImpuestoEntity)().Property(Function(x) x.IdImpuesto).HasColumnName("id_impuesto")
        modelBuilder.Entity(Of ItemImpuestoEntity)().Property(Function(x) x.Activo).HasColumnName("activo")

        modelBuilder.Entity(Of ItemImpuestoEntity)() _
            .HasRequired(Function(x) x.Item) _
            .WithMany(Function(i) i.ItemImpuestos) _
            .HasForeignKey(Function(x) x.IdItem)

        modelBuilder.Entity(Of ItemImpuestoEntity)() _
            .HasRequired(Function(x) x.Impuesto) _
            .WithMany() _
            .HasForeignKey(Function(x) x.IdImpuesto)
