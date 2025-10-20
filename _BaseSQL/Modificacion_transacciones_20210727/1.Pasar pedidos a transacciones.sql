SELECT * FROM transacciones

INSERT INTO transacciones (
	fecha
	, id_pedido
	, id_tipoComprobante
	, numeroComprobante
	, puntoVenta
	, total
	, id_cc
	, id_cliente
)
SELECT p.fecha
		, p.id_pedido
		, c.id_tipoComprobante
		, CASE WHEN p.esPresupuesto =  1 THEN p.idPresupuesto ELSE p.numeroComprobante END AS numeroComprobante
		, p.puntoVenta 
		, p.total
		, p.id_cc
		, p.id_cliente
FROM pedidos AS p
INNER JOIN comprobantes AS c ON p.id_comprobante = c.id_comprobante AND c.contabilizar = 1

SELECT * FROM transacciones