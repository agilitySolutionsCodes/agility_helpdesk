USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Classificacoes_Por_Id]    Script Date: 09/08/2014 17:19:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descri��o:		Lista Classifica��es 
-- N�mero			  Data		 Usu�rio      Descri��o
-- #001#			29/10/2013	Yule Souza	 Primeira Vers�o
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Classificacoes_Por_Id]

(
	@P_IdClassificacao INT
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT DISTINCT
    IdClassificacao, Nome, Descricao, Ativo
    FROM Classificacao
    WHERE IdClassificacao = @P_IdClassificacao
	
END


GO


