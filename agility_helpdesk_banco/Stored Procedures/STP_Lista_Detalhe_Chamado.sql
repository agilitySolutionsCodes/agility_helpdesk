USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Detalhe_Chamado]    Script Date: 09/08/2014 17:19:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Chamados 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Detalhe_Chamado]

(
	@P_IdChamado INT
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
	   C.IdChamado AS IdChamado,
	   C.Empresa, 
	   C.Assunto, 
	   CT.IdCategoria,
	   CT.Nome AS NomeCategoria, 
	   CL.IdClassificacao,
	   CL.Nome AS NomeClassificacao, 
	   C.Descricao AS Descricao, 
	   CONVERT(VARCHAR, C.DataAbertura, 103) AS DataAbertura, 
	   U.Nome AS NomeSolicitante, 
	   C.Anexo, 
	   C.StatusChamado, 
	   C.Solicitante,
	   C.Atendente,
	   C.Observacao, 
	   CONVERT(VARCHAR, C.DataFinalizacao, 103) AS DataFinalizacao,
	   C.Prioridade AS Prioridade
	   
	FROM Chamados C
	JOIN Categoria CT
	ON C.CodCategoria = CT.IdCategoria
	INNER JOIN Classificacao CL
	ON C.CodClassificacao = CL.IdClassificacao
	INNER JOIN Usuario U
	ON C.Solicitante = U.IdUsuario
    WHERE C.IdChamado = @P_IdChamado
	
END






GO


