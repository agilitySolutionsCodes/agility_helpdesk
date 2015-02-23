USE [WebHelpDesk]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 06/10/2014 11:22:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NULL,
	[Email] [varchar](100) NULL,
	[Senha] [varchar](40) NULL,
	[Cargo] [varchar](70) NULL,
	[Telefone] [varchar](12) NULL,
	[Ramal] [char](5) NULL,
	[Empresa] [int] NULL,
	[Ativo] [bit] NULL,
	[Administrador] [bit] NULL,
	[Imagem] [varchar](50) NULL,
	[Departamento] [int] NULL,
	[Perfil] [char](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Departamento] FOREIGN KEY([Departamento])
REFERENCES [dbo].[CentroCusto] ([IdCentroCusto])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Departamento]
GO


