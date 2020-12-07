ALTER TABLE comprobantes ADD isSystem BIT NOT NULL DEFAULT (0) WITH VALUES
INSERT INTO comprobantes (	comprobante, 
							id_tipoComprobante,
							numeroComprobante,
							puntoVenta,
							esFiscal,
							esElectronica,
							esManual, 
							esPresupuesto,
							activo,
							testing, 
							maxItems,
							comprobanteRelacionado,
							isSystem)
						VALUES ('Salida de mercadería', 0, 0, 0, 0,	0, 0, 0, 1,	0, 25, NULL, 1)