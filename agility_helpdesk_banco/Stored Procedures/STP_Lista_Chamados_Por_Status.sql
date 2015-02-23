USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Chamados_Por_Status]    Script Date: 02/25/2014 16:20:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Chamados Por Status
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Chamados_Por_Status]

(
	@P_IdUsuario INT,
	@P_StatusChamado CHAR(2)
)

AS
BEGIN

	SET NOCOUNT ON;

SELECT C.Assunto, 
	   E.RazaoSocial, 
	   C.Solicitante,
	   CA.Nome AS NomeCategoria, 
	   CL.Nome AS NomeClassificacao, 
	   C.Descricao, 
	   C.DataAbertura, 
	   U.Nome, 
	   C.Prioridade,
	   C.Atendente

FROM Chamados C
JOIN Usuario U 
ON C.Solicitante = U.IdUsuario OR C.Atendente = U.IdUsuario
JOIN Categoria CA 
ON C.CodCategoria = CA.IdCategoria
JOIN Classificacao CL 
ON C.CodClassificacao = CL.IdClassificacao
JOIN Empresa E
ON C.Empresa = E.IdEmpresa
WHERE C.StatusChamado = @P_StatusChamado
AND (C.Atendente = @P_IdUsuario 
OR C.Solicitante = @P_IdUsuario)
	
END




GO


