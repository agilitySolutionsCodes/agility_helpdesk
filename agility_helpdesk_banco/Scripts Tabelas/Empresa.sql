USE [WebHelpDesk]
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 06/10/2014 11:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Empresa](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[CNPJ] [varchar](17) NULL,
	[RazaoSocial] [varchar](100) NULL,
	[NomeFantasia] [varchar](100) NULL,
	[Endereco] [varchar](120) NULL,
	[UF] [char](2) NULL,
	[Cidade] [varchar](70) NULL,
	[Cep] [varchar](10) NULL,
	[Telefone] [varchar](10) NULL,
	[Email] [varchar](100) NULL,
	[Ativo] [bit] NULL,
	[Matriz] [bit] NULL,
	[CodigoMatriz] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD FOREIGN KEY([CodigoMatriz])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO


