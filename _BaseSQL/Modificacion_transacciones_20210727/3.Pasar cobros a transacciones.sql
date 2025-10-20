INSERT INTO transacciones (
	fecha
	, id_cobro	
	, numeroComprobante
	, puntoVenta
	, total
)
SELECT c.fecha_cobro
	, c.id_cobro	
	, c.id_cobro
	, '0' -- Punto de venta
	, c.total
FROM cobros AS c 
