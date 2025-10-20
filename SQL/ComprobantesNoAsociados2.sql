SELECT p.id_pedido AS 'ID', CAST(P.fecha_edicion AS VARCHAR(50)) AS 'Fecha', c.razon_social AS 'Razón social',  
	cp.comprobante AS 'Comprobante', CASE WHEN cp.id_tipoComprobante = 99 THEN p.idPresupuesto  
	ELSE p.numeroComprobante END AS 'Nº comprobante', p.total AS 'Total', p.activo AS 'Activo'  
FROM pedidos AS p  
INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente  
INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante  
INNER JOIN tipos_comprobantes AS tc ON cp.id_tipoComprobante = tc.id_tipoComprobante 
WHERE tc.id_tipoComprobante IN (1, 2, 6, 7, 11, 12, 51, 52, 201, 202, 206, 207, 211, 212)  
	AND p.cae <> ''  
	AND p.numeroComprobante_anulado <> pp.id_pedido
	AND p.id_cliente =  14
ORDER BY p.fecha_edicion DESC, p.id_pedido DESC


SELECT id_pedido, numeroComprobante_anulado
				FROM pedidos 
				WHERE numeroComprobante_anulado IS NOT NULL
				AND numeroComprobante_anulado <> 0
				AND id_cliente = 14