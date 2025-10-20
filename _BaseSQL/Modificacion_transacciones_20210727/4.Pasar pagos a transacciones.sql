INSERT INTO transacciones (
	fecha
	, id_pago
	, id_tipoComprobante
	, numeroComprobante
	, puntoVenta
	, total
)
SELECT p.fecha_pago
	, p.id_pago
	, p.id_tipoComprobante
	, p.id_pago
	, '0' -- Punto de venta
	, p.total
FROM pagos AS p 
