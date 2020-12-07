ALTER PROCEDURE [dbo].[SP_updateItemsTMP]
	-- Add the parameters for the stored procedure here
	@id_tmpPedidoItem AS INTEGER, 
	@id_item AS INTEGER,
	@cantidad AS INTEGER,
	@precio AS DECIMAL(18,2), 
	@descript AS NVARCHAR(100),
	@item AS NVARCHAR(50),
	@resultado AS INTEGER OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @item = 'MANUAL' 
		BEGIN
			UPDATE tmppedidos_items SET descript = @descript, cantidad = @cantidad, precio = @precio, activo = 1 WHERE id_tmpPedidoItem = @id_tmpPedidoItem
		END
	ELSE
		BEGIN
			UPDATE tmppedidos_items SET id_item = @id_item, cantidad = @cantidad, precio = @precio, activo = 1 WHERE id_tmpPedidoItem = @id_tmpPedidoItem			
	END

	
	SET @resultado = 1
	RETURN
END
