USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Categorias_Por_Id]    Script Date: 04/01/2015 14:29:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Categorias 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
CREATE PROCEDURE [dbo].[STP_Lista_Categorias_Por_Id]

(
	@P_IdCategoria INT
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT DISTINCT
    IdCategoria, Nome, Descricao, Ativo
    FROM Categoria
    WHERE IdCategoria = @P_IdCategoria
	ORDER BY IdCategoria
END



GO


