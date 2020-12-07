DECLARE @id_cliente INT = 6;
DECLARE @fecha_inicio DATETIME = '20190825 14:00';
DECLARE @fecha_fin DATETIME = '20191201';
WITH s1 AS
(
	SELECT	p.id_pedido, p.numeroComprobante,
		SUM(
			CASE
				WHEN cmp.id_tipoComprobante IN (1, 6, 11, 51, 2, 7, 12, 52, 200) THEN --Facturas Y notas de débito Y ¿saldos iniciales deudor??
					p.total
                ELSE 
					0
            END
		) AS debe, 
        SUM(
			CASE				
				WHEN cmp.id_tipoComprobante IN (3, 8, 13, 53, 2012) THEN --Notas de crédito Y ¿saldos iniciales acreedores??
					p.total
				ELSE 
					0
				END
		) AS haber
    FROM pedidos AS p
    INNER JOIN comprobantes AS cmp ON p.id_comprobante = cmp.id_comprobante    
    WHERE p.id_cliente = @id_cliente
    GROUP BY p.id_pedido, p.numeroComprobante
),
s2 AS 
(
	SELECT ISNULL(haber, 0) - ISNULL(debe, 0) AS saldo, id_pedido
	FROM s1
),
cte AS 
(
	SELECT	p.id_pedido, p.numeroComprobante,
			SUM(
				CASE
					WHEN cmp.id_tipoComprobante IN (1, 6, 11, 51, 2, 7, 12, 52, 200) THEN --Facturas Y notas de débito Y ¿saldos iniciales deudor??
						p.total
                    ELSE
						0
                END
			) AS DEBE, 
            SUM(
				CASE
					WHEN cmp.id_tipoComprobante IN (3, 8, 13, 53, 2012) THEN --Notas de crédito Y ¿saldos iniciales acreedores??
						p.total
                    ELSE
						0
                END
			) AS HABER
    FROM pedidos AS p
    INNER JOIN comprobantes AS cmp ON p.id_comprobante = cmp.id_comprobante    
    WHERE p.id_cliente = @id_cliente		
	GROUP BY p.id_pedido, p.numeroComprobante
)
SELECT 	
		p.id_pedido,
		p.numeroComprobante,
		cmp.comprobante, 		
		fecha, 
		DEBE, 
		HABER,
		S2.saldo
FROM pedidos AS p
INNER JOIN comprobantes AS cmp ON p.id_comprobante = cmp.id_comprobante
INNER JOIN cte ON cte.id_pedido = p.id_pedido
LEFT JOIN S2 ON CTE.id_pedido = S2.id_pedido;