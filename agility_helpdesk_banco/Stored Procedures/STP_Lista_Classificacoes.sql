USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Classificacoes]    Script Date: 09/08/2014 17:18:56 ******/
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
ALTER PROCEDURE [dbo].[STP_Lista_Classificacoes]
(
	@P_IdUsuario INT 
)
AS
BEGIN

	SET NOCOUNT ON;

        SELECT DISTINCT
		CL.IdClassificacao, CL.Nome, CL.Descricao, CL.Descricao, CL.Ativo
		FROM Classificacao CL
		JOIN Empresa E
		ON CL.Empresa = E.IdEmpresa 
		JOIN Usuario U 
		ON U.IdUsuario = @P_IdUsuario 
		WHERE E.IdEmpresa = U.Empresa
		ORDER BY CL.IdClassificacao
	
END







GO


