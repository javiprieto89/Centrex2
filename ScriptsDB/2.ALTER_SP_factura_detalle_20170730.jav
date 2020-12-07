ALTER PROCEDURE [dbo].[factura_detalle]
	-- Add the parameters for the stored procedure here
	@idfc INTEGER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CASE WHEN pit.id_item IS NOT NULL THEN i.item END AS 'item_code', 
		CASE WHEN pit.id_item IS NULL THEN pit.descript ELSE i.descript END AS 'item_desc',		
		CASE WHEN (i.esDescuento = '0' AND i.esMarkup = '0') OR pit.id_item IS NULL THEN dbo.milesArgentinos(CONVERT(VARCHAR(50), CAST(pit.cantidad AS INT),1)) END AS 'item_qty', 
		CASE WHEN (i.esDescuento = '0' AND i.esMarkup = '0') OR pit.id_item IS NULL THEN CONCAT('$', dbo.milesArgentinos(CONVERT(VARCHAR(50), CAST(pit.precio AS MONEY),1))) END 'item_price', 
		CONCAT('$', dbo.milesArgentinos(CONVERT(VARCHAR(50), CAST(pit.cantidad * pit.precio AS MONEY),1))) AS 'item_subtotal'		 
	FROM pedidos_items AS pit
	LEFT JOIN items AS i ON pit.id_item = i.id_item
	WHERE pit.id_pedido = @idfc	
	ORDER BY i.esDescuento, i.esMarkup ASC
END
