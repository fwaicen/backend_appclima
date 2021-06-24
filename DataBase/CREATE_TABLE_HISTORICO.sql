USE [Clima]
GO

/****** Object:  Table [dbo].[Historico]    Script Date: 6/24/2021 3:42:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Historico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PaisNombre] [char](52) NOT NULL,
	[CiudadNombre] [char](35) NOT NULL,
	[Clima] [decimal](4, 2) NOT NULL,
	[SensacionTermica] [decimal](4, 2) NOT NULL,
	[Icon] [char](3) NULL,
 CONSTRAINT [PK_Historico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


