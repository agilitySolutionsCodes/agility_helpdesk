USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_CentroCusto_Por_Id]    Script Date: 04/01/2015 14:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Centro Custo Por Id
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
CREATE PROCEDURE [dbo].[STP_Lista_CentroCusto_Por_Id]

(
	@P_IdCentroCusto INT
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
    CC.IdCentroCusto, CC.Classe, CC.Descricao, E.NomeFantasia, CC.Ativo
    FROM CentroCusto CC
    JOIN Empresa E
    ON CC.Empresa = E.IdEmpresa
    WHERE IdCentroCusto = @P_IdCentroCusto
    ORDER BY CC.IdCentroCusto
	
END



GO


