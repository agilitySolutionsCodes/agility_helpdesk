USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Busca]    Script Date: 04/01/2015 14:20:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  02/10/2012      
-- Descrição:  Busca Posts a partir da palavra chave digitada  
-- NÚMERO DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================  

CREATE PROCEDURE [dbo].[STP_Busca]   
(
	@P_PalavraChave VARCHAR(100)
)

AS

BEGIN 
SET NOCOUNT ON   

	SELECT QFT.IdChamado AS Codigo, 
		   QFT.Prioridade AS Prioridade, 
		   QFT.Assunto AS Assunto , 
		   QFT.Descricao AS Descricao, 
		   QFT.DataAbertura AS Abertura, 
		   U.Nome AS Solicitante, 
		   CL.Nome AS Classificacao,
		   CT.Nome AS Categoria,
		   QFT.StatusChamado, 
		   QFT.Observacao, 
		   QFT.Anexo 
	FROM
	(SELECT KEY_TBL.RANK, 
			FT_TBL.IdChamado, 
			FT_TBL.CodCategoria,
			FT_TBL.CodClassificacao,
			FT_TBL.Prioridade,
			FT_TBL.Assunto, 
			FT_TBL.Descricao,
			FT_TBL.DataAbertura, 
			FT_TBL.Solicitante, 
			FT_TBL.StatusChamado, 
			FT_TBL.Observacao, 
			FT_TBL.Anexo			
			
	FROM Chamados AS FT_TBL	
	JOIN 
	FREETEXTTABLE(Chamados, *, @P_PalavraChave) AS KEY_TBL
	ON FT_TBL.IdChamado = KEY_TBL.[KEY]) AS QFT
	JOIN Usuario U
	ON QFT.Solicitante = U.IdUsuario
	JOIN Chamados CH
	ON CH.IdChamado = QFT.IdChamado
	JOIN Classificacao CL 
	ON CL.IdClassificacao = CH.CodClassificacao
	JOIN Categoria CT
	ON CT.IdCategoria = CH.CodCategoria
	
END



GO


