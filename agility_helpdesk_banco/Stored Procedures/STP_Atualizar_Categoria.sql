USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Atualizar_Categoria]    Script Date: 09/08/2014 17:09:37 ******/
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

ALTER PROCEDURE [dbo].[STP_Atualizar_Categoria]      

(     
 @P_IdCategoria INTEGER,
 @P_Nome VARCHAR(80),
 @P_Descricao VARCHAR(255),
 @P_Ativo BIT
)      

AS      
BEGIN      
SET NOCOUNT ON
		
	BEGIN
	
		UPDATE Categoria
		SET 
		Nome = @P_Nome,
		Descricao = @P_Descricao,
		Ativo = @P_Ativo
		
		WHERE IdCategoria = @P_IdCategoria
		
	END		
END      
SET NOCOUNT OFF 



GO


