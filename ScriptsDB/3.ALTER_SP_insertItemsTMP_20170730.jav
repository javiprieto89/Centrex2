ALTER PROCEDURE [dbo].[SP_insertItemsTMP]
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
	SET NOCOUNT ON;

	IF @item = 'MANUAL'
		BEGIN
			INSERT tmppedidos_items (descript, cantidad, precio) SELECT @descript, @cantidad, @precio
		END
	ELSE
		BEGIN
			INSERT tmppedidos_items (id_item, cantidad, precio) SELECT @id_item, @cantidad, @precio			
	END
	
	
	SET @resultado = 1
	RETURN
END
