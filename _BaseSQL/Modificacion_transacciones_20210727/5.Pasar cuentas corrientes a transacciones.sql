/*ACTUALIZO LOS CLIENTES DE LOS PEDIDOS*/

UPDATE trn
SET trn.id_cliente = p.id_cliente
FROM transacciones trn
INNER JOIN pedidos AS p ON trn.id_pedido = p.id_pedido

/*ACTUALIZO LOS PROVEEDORES DE LOS COMPROBANTES DE COMPRAS*/

UPDATE trn
SET trn.id_proveedor = cc.id_proveedor
FROM transacciones trn
INNER JOIN comprobantes_compras AS cc ON trn.id_comprobanteCompra = cc.id_comprobanteCompra

/*ACTUALIZO LOS CLIENTES DE LOS COBROS*/

UPDATE trn
SET trn.id_cliente = c.id_cliente
FROM transacciones trn
INNER JOIN cobros AS c ON trn.id_cobro = c.id_cobro

/*ACTUALIZO LOS PROVEEDORES DE LOS PAGOS*/

UPDATE trn
SET trn.id_proveedor = p.id_proveedor
FROM transacciones trn
INNER JOIN pagos AS p ON trn.id_pago = p.id_pago