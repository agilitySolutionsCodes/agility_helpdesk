USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Chamado]    Script Date: 04/01/2015 14:27:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  10/10/2013      
-- Descrição:	  Incluir / Alterar Chamados   
-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

CREATE PROCEDURE [dbo].[STP_Incluir_Chamado]      

(     
 @P_IdChamado INTEGER = NULL,
 @P_Empresa	  INTEGER,
 @P_Assunto	  VARCHAR(80),
 @P_CodCategoria INTEGER,
 @P_CodClassificacao INTEGER,
 @P_Descricao VARCHAR(255), 
 @P_DataAbertura DATETIME,
 @P_Solicitante INTEGER,
 @P_Anexo VARCHAR(60) = NULL,
 @P_StatusChamado CHAR(2),
 @P_Observacao VARCHAR(255) = NULL,
 @P_DataFinalizacao	DATETIME = NULL,
 @P_Prioridade CHAR(2),
 @P_Atendente INT,
 @CodChamado INTEGER OUTPUT
)      

AS      
BEGIN      
SET NOCOUNT ON
		If(SELECT COUNT(*) FROM Chamados (NOLOCK) WHERE IdChamado = @P_IdChamado) = 0 BEGIN
		
			DECLARE	@CodEmpresa INT = (SELECT Empresa FROM Usuario WHERE IdUsuario = @P_Solicitante)
			SET @P_Empresa = @CodEmpresa
			
			INSERT INTO Chamados(Empresa, Assunto, CodCategoria, CodClassificacao, Descricao, DataAbertura, Solicitante, Anexo, 
								 StatusChamado, Observacao, DataFinalizacao, Prioridade, Atendente) 
								 
			VALUES(@P_Empresa, @P_Assunto, @P_CodCategoria, @P_CodClassificacao, @P_Descricao, @P_DataAbertura, @P_Solicitante, @P_Anexo, 
				   @P_StatusChamado, @P_Observacao, @P_DataFinalizacao, @P_Prioridade, @P_Atendente)		
		END
	ELSE
	BEGIN
	
		UPDATE Chamados
		SET 
		Empresa = @P_Empresa,
		Assunto = @P_Assunto,
		CodCategoria = @P_CodCategoria,
		CodClassificacao = @P_CodClassificacao,
		Descricao = @P_Descricao,
		DataAbertura = @P_DataAbertura,
		Solicitante = @P_Solicitante,
		Anexo = @P_Anexo,
		StatusChamado = @P_StatusChamado,
		Observacao = @P_Observacao,
		DataFinalizacao = @P_DataFinalizacao,
		Prioridade = @P_Prioridade
		
		WHERE IdChamado = @P_IdChamado
	END			
	
			SELECT @CodChamado = (SELECT TOP 1 IdChamado FROM Chamados ORDER BY IdChamado DESC)
			
END      
SET NOCOUNT OFF 






GO


