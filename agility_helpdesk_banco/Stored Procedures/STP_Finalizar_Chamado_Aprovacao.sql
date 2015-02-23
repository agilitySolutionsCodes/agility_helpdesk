USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Finalizar_Chamado_Aprovacao]    Script Date: 06/10/2014 11:12:13 ******/
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

ALTER PROCEDURE [dbo].[STP_Finalizar_Chamado_Aprovacao]      

(     

 @P_IdChamado INT,
 @P_IdUsuario INT,
 @OK BIT OUTPUT,
 @P_Observacao VARCHAR(255) = NULL

)      

AS      
BEGIN      
SET NOCOUNT ON
		
	BEGIN
	
	IF(SELECT COUNT(*) FROM Chamados WHERE Solicitante = @P_IdUsuario) = 0
	
	BEGIN 
		UPDATE Chamados
		SET 
		Observacao = @P_Observacao, StatusChamado = 'FA'	
		WHERE IdChamado = @P_IdChamado
		SET @OK = 'TRUE'
	END
	
	ELSE
		BEGIN 
			SET @OK = 'FALSE'
		END
	END		
END      
SET NOCOUNT OFF 



GO


