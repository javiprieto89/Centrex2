USE [dbCentrex]
GO

/****** Object:  UserDefinedFunction [dbo].[CalculoComprobante]    Script Date: 4/11/2020 12:23:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CalculoComprobante] (@id_tipoComprobante int, @puntoVenta int, @numeroComprobante int)
	RETURNS NVARCHAR(50)
	BEGIN
	RETURN (SELECT CASE 
		WHEN @id_tipoComprobante = 1 THEN
			CONCAT('FC A ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 2 THEN
			CONCAT('ND A ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 3 THEN
			CONCAT('NC A ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 6 THEN
			CONCAT('FC B ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 7 THEN
			CONCAT('ND B ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 8 THEN
			CONCAT('NC B ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 11 THEN
			CONCAT('FC C ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 12 THEN
			CONCAT('ND C ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 13 THEN
			CONCAT('NC C ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 51 THEN
			CONCAT('FC M ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 52 THEN
			CONCAT('ND M ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 53 THEN
			CONCAT('NC M ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 99 THEN
			CONCAT('PR ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 199 THEN
			CONCAT('RM ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 200 THEN
			CONCAT('SID ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
		WHEN @id_tipoComprobante = 201 THEN
			CONCAT('SIA ', 'Nº  ', REPLICATE('0', 4 - LEN(@puntoVenta)), @puntoVenta, '-', REPLICATE('0', 8 - LEN(@numeroComprobante)), @numeroComprobante)
	END AS 'Comprobante')
END
GO


