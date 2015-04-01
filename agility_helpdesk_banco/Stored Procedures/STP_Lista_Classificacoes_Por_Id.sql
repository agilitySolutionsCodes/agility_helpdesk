USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Classificacoes_Por_Id]    Script Date: 04/01/2015 14:30:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Classificações 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
CREATE PROCEDURE [dbo].[STP_Lista_Classificacoes_Por_Id]

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


