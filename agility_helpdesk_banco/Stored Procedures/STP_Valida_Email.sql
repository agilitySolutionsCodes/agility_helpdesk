USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Valida_Email]    Script Date: 04/01/2015 14:32:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  26/09/2013      
-- Descrição:  Valida se e-mail já existe na base
-- Número Data        Usuário   Descrição      
-- #001#  
-- =========================================================================  
    
CREATE PROCEDURE [dbo].[STP_Valida_Email]      

(   
 @P_EMAIL VARCHAR(100),
 @Ok BIT OUTPUT
)      
AS      
BEGIN      
SET NOCOUNT ON    

	DECLARE @EMAIL VARCHAR(100)
	IF(SELECT COUNT(*) FROM Usuario WHERE Email = @P_EMAIL) = 0 BEGIN
	    
		SELECT  
			   @EMAIL = U.Email
			   			   
		FROM Usuario U (NOLOCK) 
		WHERE U.Email = @P_EMAIL 
		GROUP BY
		U.Email
		IF @EMAIL = @P_EMAIL BEGIN
			SET @Ok = 'FALSE'
		END
		ELSE BEGIN
			SET @Ok = 'TRUE'
		END
	END
	ELSE
	BEGIN
		SET @Ok = 'FALSE'
	END
END      
SET NOCOUNT OFF 


GO


