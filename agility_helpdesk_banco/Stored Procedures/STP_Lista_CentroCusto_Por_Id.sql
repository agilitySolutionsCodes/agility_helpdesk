USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_CentroCusto_Por_Id]    Script Date: 09/08/2014 17:18:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descri��o:		Lista Centro Custo Por Id
-- N�mero			  Data		 Usu�rio      Descri��o
-- #001#			29/10/2013	Yule Souza	 Primeira Vers�o
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_CentroCusto_Por_Id]

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


