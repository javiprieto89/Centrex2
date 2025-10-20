/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id_tipoComprobante]
      ,[comprobante_AFIP]
      ,[id_claseFiscal]
      ,[signoProveedor]
      ,[signoCliente]
      ,[discriminaIVA]
      ,[esRemito]
      ,[nombreAbreviado]
      ,[id_claseComprobante]
      ,[id_anulaTipoComprobante]
  FROM [dbCentrex].[dbo].[tipos_comprobantes]
  WHERE comprobante_AFIP LIKE '%factura%'