ALTER TABLE tmppedidos_items ALTER COLUMN id_item INT NULL
ALTER TABLE tmppedidos_items ADD descript NVARCHAR(100) NULL
ALTER TABLE pedidos_items ALTER COLUMN id_item INT NULL
ALTER TABLE pedidos_items ADD descript NVARCHAR(100)