USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Numero_Chamados_Relatorio]    Script Date: 09/08/2014 17:20:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Relatório Teste 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Numero_Chamados_Relatorio]
(
   @P_IdEmpresa INT,
   @P_StatusFiltro CHAR(2) = NULL
)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT COUNT(CA.Nome) AS NumeroOcorrencias, CA.Nome AS CategoriaDoChamado FROM Chamados CH
	JOIN Categoria CA 
	ON CH.CodCategoria = CA.IdCategoria
	WHERE CH.Empresa = @P_IdEmpresa OR CH.StatusChamado = @P_StatusFiltro
	GROUP BY
	CA.Nome,
	CH.StatusChamado
	
END


GO


