DECLARE @id_proveedor INTEGER;
DECLARE @fecha_inicio DATE;
DECLARE @fecha_fin DATE;  
DECLARE @id_cc AS INTEGER;

SET @id_proveedor = '1039';
SET @fecha_inicio = '01/01/1753';   
SET @fecha_fin =  '12/31/9998';
SET @id_cc = '15';

WITH tbl AS (
	SELECT t.id_transaccion, t.id_proveedor, t.numeroComprobante, t.puntoVenta, t.id_tipoComprobante, t.fecha, 
	(CASE WHEN t.id_tipoComprobante IN (1, 6, 11, 51, 201, 206, 211, 1006, 2, 7, 12, 52, 202, 207, 212, 1007, 1002, 1003, 1004, 1005, 1010) THEN T.total ELSE 0 END) AS 'debito',  
	(CASE WHEN t.id_tipoComprobante IN (3, 8, 13, 53, 203, 208, 213, 1008, 4, 9, 15, 54, 1009) THEN T.total * -1 ELSE 0 END) AS 'credito',
	(CASE WHEN t.id_tipoComprobante IN (1, 6, 11, 51, 201, 206, 211, 1006, 2, 7, 12, 52, 202, 207, 212, 1007, 1002, 1003, 1004, 1005, 1010) THEN T.total WHEN t.id_tipoComprobante IN (3, 8, 13, 53, 203, 208, 213, 1008, 4, 9, 15, 54, 1009) THEN T.TOTAL * -1 ELSE 0 END) AS 'total'
	, t.id_cc
	FROM transacciones As t   
	--INNER JOIN comprobantes AS cmp ON t.id_comprobante = cmp.id_comprobante   
	--INNER JOIN tipos_comprobantes AS tc ON cmp.id_tipoComprobante = tc.id_tipoComprobante
	WHERE t.id_proveedor = @id_proveedor AND t.id_cc = @id_cc AND t.fecha BETWEEN @fecha_inicio AND @fecha_fin-- AND t.activo = 0 AND t.cerrado = 1 
	--AND t.esTest = 0 AND t.esPresupuesto = 0   
	--AND cmp.id_tipoComprobante IN (1, 2, 3, 4, 6, 7, 8, 9, 11 ,12, 13, 15, 51, 52, 53, 54, 200, 201)   
) 
SELECT tbl.id_transaccion AS 'ID', tbl.fecha AS 'Fecha', dbo.CalculoComprobante(tbl.id_tipoComprobante, tbl.puntoVenta, tbl.numeroComprobante) AS 'Comprobante', 
		 CONCAT('$ ', tbl.debito) AS 'Débito', CONCAT('$ ', tbl.credito) AS 'Crédito',  
		 SUM(tbl.TOTAL) OVER (PARTITION BY tbl.id_cc  ORDER BY tbl.numeroComprobante ROWS UNBOUNDED PRECEDING ) AS 'Saldo'  
FROM tbl INNER JOIN cc_clientes AS ccc ON tbl.id_cc = ccc.id_cc   
WHERE tbl.id_proveedor = @id_proveedor AND tbl.id_cc = @id_cc AND tbl.fecha BETWEEN @fecha_inicio AND @fecha_fin 
--AND tbl.activo = 0 AND tbl.cerrado = 1 AND tbl.esTest = 0 AND tbl.esPresupuesto = 0  
--AND tbl.id_tipoComprobante IN (1, 2, 3, 4, 6, 7, 8, 9, 11, 12, 13, 15, 51, 52, 53, 54, 200, 201)  
ORDER BY tbl.numeroComprobante ASC
