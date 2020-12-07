DECLARE @id_cliente AS INTEGER

SET @id_cliente = 6

WITH tbl AS 
(
	SELECT 
		ROW_NUMBER() OVER(PARTITION BY p.id_pedido, p.id_cc ORDER BY p.fecha) AS f, 
		p.id_pedido, p.fecha, p.id_cliente, p.id_cc, p.id_comprobante, p.puntoVenta, p.numeroComprobante, p.total,
		CASE
			WHEN cmp.id_tipoComprobante IN (1, 6, 11, 51, 2, 7, 12, 52, 200) THEN --Facturas Y notas de d�bito Y �saldos iniciales deudor??
				p.total
			WHEN cmp.id_tipoComprobante IN (3, 8, 13, 53, 2012) THEN --Notas de cr�dito Y �saldos iniciales acreedores??
				p.total * -1
		END AS 'balance'
	FROM pedidos AS p
	INNER JOIN comprobantes AS cmp ON p.id_comprobante = cmp.id_comprobante
	WHERE p.id_cliente = @id_cliente
)
SELECT
	p.id_pedido AS 'ID',
	p.fecha AS 'Fecha',
	CASE 
		WHEN cmp.id_tipoComprobante = 1 THEN
			CONCAT('FC A ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 2 THEN
			CONCAT('ND A ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 3 THEN
			CONCAT('NC A ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 6 THEN
			CONCAT('FC B ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 7 THEN
			CONCAT('ND B ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 8 THEN
			CONCAT('NC B ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 11 THEN
			CONCAT('FC C ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 12 THEN
			CONCAT('ND C ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 13 THEN
			CONCAT('NC C ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 51 THEN
			CONCAT('FC M ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 52 THEN
			CONCAT('ND M ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 53 THEN
			CONCAT('NC M ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 99 THEN
			CONCAT('PR ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 199 THEN
			CONCAT('RM ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 200 THEN
			CONCAT('SID ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
		WHEN cmp.id_tipoComprobante = 201 THEN
			CONCAT('SIA ', 'N�  ', REPLICATE('0', 4 - LEN(p.puntoVenta)), p.puntoVenta, '-', REPLICATE('0', 8 - LEN(p.numeroComprobante)), p.numeroComprobante)
	END AS 'Comprobante',
	ccc.nombre AS 'Cuenta corriente',
	CASE
		WHEN cmp.id_tipoComprobante IN (1, 6, 11, 51, 2, 7, 12, 52, 200) THEN --Facturas Y notas de d�bito Y �saldos iniciales deudor??
			CONCAT('$ ', p.total)
		ELSE 
			'$ 0'
	END AS 'D�bito',
	CASE
		WHEN cmp.id_tipoComprobante IN (3, 8, 13, 53, 2012) THEN --Notas de cr�dito Y �saldos iniciales acreedores??
			CONCAT('$ ', (p.total * -1))
		ELSE
			'$ 0'
	END AS 'Cr�dito',
	CONCAT('$ ', SUM(p.balance) OVER(PARTITION BY p.id_pedido ORDER BY p.f))AS 'Saldo'
FROM tbl AS p
INNER JOIN clientes AS c ON p.id_cliente = c.id_cliente
INNER JOIN cc_clientes AS ccc ON p.id_cc = ccc.id_cc
INNER JOIN comprobantes AS cmp ON p.id_comprobante = cmp.id_comprobante
WHERE c.id_cliente = @id_cliente
ORDER BY p.fecha ASC


