ALTER TABLE ordenes_compras ADD fecha_comprobante DATE NULL
GO
UPDATE ordenes_compras SET fecha_comprobante = fecha_carga
GO
ALTER TABLE ordenes_compras ALTER COLUMN fecha_comprobante DATE NOT NULL
GO