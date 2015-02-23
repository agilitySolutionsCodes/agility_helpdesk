USE [WebHelpDesk]
GO

/****** Object:  Table [dbo].[CentroCusto]    Script Date: 06/10/2014 11:21:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CentroCusto](
	[IdCentroCusto] [int] IDENTITY(1,1) NOT NULL,
	[Classe] [char](2) NULL,
	[Ativo] [bit] NULL,
	[Descricao] [varchar](80) NULL,
	[Empresa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCentroCusto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CentroCusto]  WITH CHECK ADD  CONSTRAINT [FK_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[CentroCusto] CHECK CONSTRAINT [FK_Empresa]
GO


