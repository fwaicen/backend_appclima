USE [Clima]
GO

/****** Object:  StoredProcedure [dbo].[spGetHistorico]    Script Date: 6/24/2021 3:44:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetHistorico]
	@Ciudad char(35),
	@Pais char(52)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [id] 
	  ,[PaisNombre]
      ,[CiudadNombre]
      ,[Clima]
      ,[SensacionTermica]
	  ,[Icon]
  FROM [Clima].[dbo].[Historico]
  WHERE TRIM(CiudadNombre) = TRIM(@Ciudad) and TRIM(PaisNombre) = TRIM(@Pais) 
END
GO


