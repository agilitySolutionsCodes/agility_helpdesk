USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Chamados]    Script Date: 04/01/2015 14:29:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descri��o:		Lista Chamados 
-- N�mero			Data	     Usu�rio      Descri��o
-- #001#			29/10/2013	Yule Souza	 Primeira Vers�o
-- ===================================================================================      
CREATE PROCEDURE [dbo].[STP_Lista_Chamados]

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
	WHERE C.Empresa = U.Empresa 
	AND (C.Solicitante = @P_IdUsuario 
	OR C.Atendente = @P_IdUsuario)
	ORDER BY C.Prioridade 
	
END




GO


