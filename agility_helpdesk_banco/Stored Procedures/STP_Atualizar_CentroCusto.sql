USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Atualizar_CentroCusto]    Script Date: 09/08/2014 17:09:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  15/10/2013      
-- Descrição:	  Alterar Empresa   
-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Atualizar_CentroCusto]      

(     
 @P_IdCentroCusto INTEGER,
 @P_Descricao VARCHAR(255),
 @P_Classe CHAR,
 @P_Ativo BIT
)      

AS      
BEGIN      
SET NOCOUNT ON
		
	BEGIN
	
		UPDATE CentroCusto
		SET 
		Classe = @P_Classe,
		Descricao = @P_Descricao,
		Ativo = @P_Ativo
		
		WHERE IdCentroCusto = @P_IdCentroCusto
		
	END		
END      
SET NOCOUNT OFF 




GO


