USE [WebHelpDesk]
GO

/****** Object:  Table [dbo].[Categoria]    Script Date: 06/10/2014 11:21:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NULL,
	[Descricao] [varchar](255) NULL,
	[Ativo] [bit] NULL,
	[Empresa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO


