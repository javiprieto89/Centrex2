--EJECUTAR TODO DE A UNO Y CON PRUDENCIA

SELECT MAX(idPresupuesto)
FROM pedidos
WHERE esPresupuesto = 1

SELECT *
FROM pedidos
WHERE esPresupuesto = 1 AND idPresupuesto IS NOT NULL

UPDATE pedidos
SET idPresupuesto = NULL
WHERE esPresupuesto = 1 AND idPresupuesto IS NOT NULL	

UPDATE pedidos
SET esPresupuesto = 1
WHERE id_comprobante = 3

SELECT *
FROM pedidos
WHERE esPresupuesto = 1

SELECT id_pedido
FROM pedidos
WHERE esPresupuesto = 1

--FORMULA EN EXCEL PARA ACTUALIZAR NUMERO DE PRESUPUESTOS PERDIDOS
--=CONCATENAR("UPDATE pedidos SET idPresupuesto = "; FILA(); " WHERE id_pedido = "; A1)

--DEBERIA DEVOLVER VACIO
SELECT *
FROM pedidos
WHERE esPresupuesto = 1 AND (idPresupuesto IS NULL OR idPresupuesto = 0)


UPDATE transacciones
SET transacciones.numeroComprobante = tabla2agregada.idPresupuesto
FROM transacciones AS t1, (SELECT t2.id_pedido, t2.idPresupuesto 
                          FROM transacciones AS t1, pedidos AS t2
                          WHERE t1.id_pedido = t2.id_pedido) AS tabla2agregada
WHERE t1.id_pedido = tabla2agregada.id_pedido

SELECT *
FROM transacciones
WHERE id_tipoComprobante = 99 AND numeroComprobante IS NULL