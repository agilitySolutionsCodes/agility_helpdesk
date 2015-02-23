USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_CentroCusto]    Script Date: 09/08/2014 17:18:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Centro de Custo 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_CentroCusto]

(
	@P_IdUsuario INT 
)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT DISTINCT
    CC.IdCentroCusto, CC.Classe, E.NomeFantasia, CC.Descricao, CC.Ativo
    FROM CentroCusto CC
	JOIN Empresa E
	ON CC.Empresa = E.IdEmpresa 
	JOIN Usuario U 
	ON U.IdUsuario = @P_IdUsuario 
	WHERE E.IdEmpresa = U.Empresa
	ORDER BY CC.IdCentroCusto
	
END



GO


