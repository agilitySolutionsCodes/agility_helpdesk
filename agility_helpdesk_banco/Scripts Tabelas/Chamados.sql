USE [WebHelpDesk]
GO

/****** Object:  Table [dbo].[Chamados]    Script Date: 06/10/2014 11:21:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Chamados](
	[IdChamado] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [int] NULL,
	[Assunto] [varchar](80) NULL,
	[CodCategoria] [int] NULL,
	[CodClassificacao] [int] NULL,
	[Descricao] [varchar](5000) NULL,
	[DataAbertura] [datetime] NULL,
	[Solicitante] [int] NULL,
	[Anexo] [varchar](60) NULL,
	[StatusChamado] [char](2) NULL,
	[Observacao] [varchar](255) NULL,
	[DataFinalizacao] [datetime] NULL,
	[Prioridade] [char](2) NULL,
	[Atendente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdChamado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Chamados]  WITH CHECK ADD FOREIGN KEY([CodCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO

ALTER TABLE [dbo].[Chamados]  WITH CHECK ADD FOREIGN KEY([CodClassificacao])
REFERENCES [dbo].[Classificacao] ([IdClassificacao])
GO

ALTER TABLE [dbo].[Chamados]  WITH CHECK ADD FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[Chamados]  WITH CHECK ADD FOREIGN KEY([Solicitante])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO


