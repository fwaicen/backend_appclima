USE [Clima]
GO

/****** Object:  Table [dbo].[Ciudad]    Script Date: 6/24/2021 3:42:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ciudad](
	[CiudadID] [int] NOT NULL,
	[CiudadNombre] [char](35) NOT NULL,
	[PaisCodigo] [char](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CiudadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ciudad] ADD  DEFAULT ('') FOR [CiudadNombre]
GO

ALTER TABLE [dbo].[Ciudad] ADD  DEFAULT ('') FOR [PaisCodigo]
GO

ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Pais] FOREIGN KEY([PaisCodigo])
REFERENCES [dbo].[Pais] ([PaisCodigo])
GO

ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Pais]
GO


