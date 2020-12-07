DECLARE @id_cliente INT = 6;
DECLARE @fecha_inicio DATETIME = '20190825 14:00';
DECLARE @fecha_fin DATETIME = '20191201';

WITH tbl
	 AS (SELECT t.id_pedido,
				t.id_cliente,
				t.numeroComprobante,
				t.puntoVenta,
				cmp.id_tipoComprobante,
				t.fecha,
				(CASE WHEN cmp.id_tipoComprobante IN (1, 2, 6, 7, 11, 12, 51, 52, 200) THEN T.total ELSE 0 END) AS 'debito',
				(CASE WHEN cmp.id_tipoComprobante IN (3, 4, 8, 9, 13, 15, 53, 54, 201) THEN T.total*-1 ELSE 0 END) AS 'credito',
				(CASE WHEN cmp.id_tipoComprobante IN (1, 2, 6, 7, 11, 12, 51, 52, 200) THEN T.total
					  WHEN cmp.id_tipoComprobante IN (3, 4, 8, 9, 13, 15, 53, 54, 201) THEN T.TOTAL * -1 ELSE 0 END) AS 'total',
				t.activo,
				t.cerrado,
				t.esTest,
				t.esPresupuesto,
				t.id_cc
				FROM pedidos As t
				INNER JOIN comprobantes AS cmp ON t.id_comprobante = cmp.id_comprobante
				INNER JOIN tipos_comprobantes AS tc ON cmp.id_tipoComprobante = tc.id_tipoComprobante
				WHERE t.id_cliente = 6 AND t.activo = 0 AND t.cerrado = 1 AND t.esTest = 0 AND t.esPresupuesto = 0
				AND cmp.id_tipoComprobante IN (1, 2, 3, 4, 6, 7, 8, 9, 11 ,12, 13, 15, 51, 52, 53, 54, 200, 201)			
)
	 SELECT	
			tbl.id_pedido AS 'ID',
			tbl.id_cliente AS 'ID Cliente',
			tbl.fecha AS 'Fecha',
			ccc.nombre AS 'Cuenta corriente',
			dbo.CalculoComprobante(tbl.id_tipoComprobante, tbl.puntoVenta, tbl.numeroComprobante),
			tbl.debito AS 'Débito',
			tbl.credito AS 'Crédito',			
			SUM(tbl.TOTAL) OVER (PARTITION BY tbl.id_cc
		  -- la gracia de los acumulados está en el order by, particionado
               --ORDER BY tbl.fecha, tbl.numeroComprobante, tbl.id_pedido, tbl.id_cc ROWS UNBOUNDED PRECEDING ) AS 'Saldo'
			   ORDER BY tbl.numeroComprobante ROWS UNBOUNDED PRECEDING ) AS 'Saldo'
			FROM tbl			
			INNER JOIN cc_clientes AS ccc ON tbl.id_cc = ccc.id_cc
 			WHERE tbl.id_cliente = 6 AND tbl.activo = 0 AND tbl.cerrado = 1 AND tbl.esTest = 0 AND tbl.esPresupuesto = 0
			AND tbl.id_tipoComprobante IN (1, 2, 3, 4, 6, 7, 8, 9, 11, 12, 13, 15, 51, 52, 53, 54, 200, 201)
			ORDER BY tbl.numeroComprobante ASC