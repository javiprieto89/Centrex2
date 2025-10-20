INSERT INTO transacciones (
	fecha
	, id_comprobanteCompra
	, id_tipoComprobante
	, numeroComprobante
	, puntoVenta
	, total
)
SELECT cc.fecha_comprobante
	, cc.id_comprobanteCompra
	, cc.id_tipoComprobante
	, cc.numeroComprobante
	, cc.puntoVenta
	, cc.total
FROM comprobantes_compras AS cc