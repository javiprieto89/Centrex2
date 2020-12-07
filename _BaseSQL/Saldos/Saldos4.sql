WITH tbl
	 AS (SELECT t.id_pedido,
				t.numeroComprobante,
				t.puntoVenta,
				cmp.id_tipoComprobante,
				t.id_cliente,
				t.fecha,
				(CASE WHEN cmp.id_tipoComprobante IN (1) THEN T.total ELSE 0 END) AS 'debito',
				(CASE WHEN cmp.id_tipoComprobante IN (3) THEN T.total*-1 ELSE 0 END) AS 'credito',
				(CASE WHEN cmp.id_tipoComprobante IN (1) THEN T.total
					  WHEN cmp.id_tipoComprobante IN (3) THEN T.TOTAL * -1 ELSE 0 END) AS 'total',
				t.activo,
				t.cerrado,
				t.esTest,
				t.esPresupuesto
				FROM pedidos As t
				INNER JOIN comprobantes AS cmp ON t.id_comprobante = cmp.id_comprobante
				INNER JOIN tipos_comprobantes AS tc ON cmp.id_tipoComprobante = tc.id_tipoComprobante
				WHERE t.activo = 0 AND t.cerrado = 1 AND t.esTest = 0 AND t.esPresupuesto = 0
				AND cmp.id_tipoComprobante IN (1,2,3,4,6,7,8,9,11,12,13,15,51,52,53,54,200,201)
-- genero una serie de columnas, que en realidad son la columna total, pero ahora tengo 3.
)
	 SELECT	
			tbl.id_pedido AS 'ID',
			tbl.fecha AS 'Fecha',
			dbo.CalculoComprobante(tbl.id_tipoComprobante, tbl.puntoVenta, tbl.numeroComprobante),
			/*tbl.numeroComprobante,
			tbl.id_tipoComprobante,*/
			tbl.id_cliente,
			tbl.total AS 'Total',
			tbl.debito AS 'Débito',
			tbl.credito AS 'Crédito',
			SUM(tbl.TOTAL) OVER (PARTITION BY numeroComprobante
		  -- la gracia de los acumulados está en el order by, particionado
               ORDER BY fecha, numeroComprobante, id_pedido ROWS UNBOUNDED PRECEDING ) AS 'Saldo'
			FROM tbl			
			WHERE tbl.activo = 0 AND tbl.cerrado = 1 AND tbl.esTest = 0 AND tbl.esPresupuesto = 0
			AND tbl.id_tipoComprobante IN (1,2,3,4,6,7,8,9,11,12,13,15,51,52,53,54,200,201)