USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Atender_Chamado]    Script Date: 04/01/2015 14:18:47 ******/
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

ALTER PROCEDURE [dbo].[STP_Atender_Chamado]      

(     
 @P_IdChamado INTEGER,
 @P_IdUsuario INTEGER,
 @Ok BIT OUTPUT
)      

AS           		
BEGIN
	IF(SELECT COUNT(*) FROM Chamados WHERE IdChamado = @P_IdChamado AND Solicitante = @P_IdUsuario) < 1 BEGIN
		
		UPDATE Chamados
		SET 
		Atendente = @P_IdUsuario,
		StatusChamado = 'A'
		
		WHERE IdChamado = @P_IdChamado
		
		SET @Ok = 'TRUE'
			
	END		
	
	ELSE 
		BEGIN 
			SET @Ok = 'FALSE'
		END	
END      
 SET NOCOUNT OFF

GO


