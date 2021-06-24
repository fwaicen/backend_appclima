USE [Clima]
GO

/****** Object:  StoredProcedure [dbo].[spGetCiudades]    Script Date: 6/24/2021 3:43:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetCiudades]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [CiudadID]
      ,[CiudadNombre]
      ,c.[PaisCodigo]
	  , p.PaisNombre
	FROM [Clima].[dbo].[Ciudad] c
	Inner join Pais p on c.PaisCodigo = p.PaisCodigo
END
GO


