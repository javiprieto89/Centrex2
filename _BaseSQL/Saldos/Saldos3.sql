SELECT	p.id_pedido, 
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
    WHERE p.id_cliente = 6
    GROUP BY p.id_pedido