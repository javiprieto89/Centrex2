SELECT pp.id_pedido AS 'ID', CAST(pp.fecha_edicion AS VARCHAR(50)) AS 'Fecha', pp.razon_social AS 'Razón social',  
 pp.comprobante AS 'Comprobante', pp.id_numeroComprobante AS 'Nº comprobante', pp.total AS 'Total', pp.activo AS 'Activo'  
FROM pedidos AS p 
INNER JOIN (
SELECT p.id_pedido, CAST(P.fecha_edicion AS VARCHAR(50)) AS 'fecha_edicion', c.razon_social AS 'razon_social',  
 cp.comprobante, CASE WHEN cp.id_tipoComprobante = 99 THEN p.idPresupuesto  
   ELSE p.numeroComprobante END AS 'id_numeroComprobante', p.total, p.activo  
                               FROM pedidos AS p  
                                        INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente  
                                        INNER JOIN comprobantes AS cp ON p.id_comprobante = cp.id_comprobante  
                                        INNER JOIN tipos_comprobantes AS tc ON cp.id_tipoComprobante = tc.id_tipoComprobante 
                 WHERE tc.id_tipoComprobante IN (1, 2, 6, 7, 11, 12, 51, 52, 201, 202, 206, 207, 211, 212)  
                                    AND cae <> ''                                  
                                    AND p.id_cliente =  14) AS pp ON p.id_pedido = pp.id_pedido 
									WHERE p.numeroComprobante_anulado = p.numeroComprobante
									ORDER BY p.fecha_edicion DESC, p.id_pedido DESC


									