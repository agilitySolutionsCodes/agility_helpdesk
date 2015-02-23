USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Chamados_Por_Id]    Script Date: 09/08/2014 17:18:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Chamado Por Id
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Chamados_Por_Id]

(
	@P_IdUsuario INT
)

AS
BEGIN

	SET NOCOUNT ON;
 
 	SELECT 
		C.IdChamado AS Codigo,
		C.Assunto AS Assunto,
		U.Nome AS Solicitante,
		C.Prioridade,
		E.NomeFantasia AS Empresa,
		C.Descricao,
		CONVERT(VARCHAR, C.DataAbertura, 103) AS Abertura,
		CT.Nome AS Categoria,
		CL.Nome AS Classificacao,
		C.StatusChamado AS StatusChamado,
		C.Anexo, 
		C.Observacao,
		CONVERT(VARCHAR, C.DataFinalizacao, 103) AS Encerramento
	FROM

	(SELECT ROW_NUMBER() OVER(ORDER BY IdChamado ASC) AS Linha, *	
	FROM Chamados) C
	JOIN Usuario U
	ON C.Solicitante = U.IdUsuario
	JOIN Empresa E
	ON C.Empresa = E.IdEmpresa
	JOIN Categoria CT
	ON C.CodCategoria = CT.IdCategoria 
	JOIN Classificacao CL
	ON C.CodClassificacao = CL.IdClassificacao
	WHERE C.Atendente = @P_IdUsuario
	ORDER BY C.Prioridade 
	
END


GO


