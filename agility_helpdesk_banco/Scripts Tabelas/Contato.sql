USE [WebHelpDesk]
GO

/****** Object:  Table [dbo].[Contato]    Script Date: 06/10/2014 11:22:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Contato](
	[IdContato] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NULL,
	[Email] [varchar](100) NULL,
	[Assunto] [varchar](75) NULL,
	[Mensagem] [varchar](255) NULL,
	[DataContato] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdContato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


