USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Valida_CNPJ]    Script Date: 09/08/2014 17:20:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  26/09/2013      
-- Descrição:  Valida se CNPJ ja existe 
-- Número Data        Usuário   Descrição      
-- #001#  
-- =========================================================================  
    
ALTER PROCEDURE [dbo].[STP_Valida_CNPJ]      

(   
 @P_CNPJ VARCHAR(16),
 @Ok BIT OUTPUT
)      
AS      
BEGIN      
SET NOCOUNT ON    

	DECLARE @CNPJ VARCHAR(16)
	IF(SELECT COUNT(*) FROM Empresa WHERE CNPJ = @P_CNPJ) = 0 BEGIN
	    
		SELECT  
			   @CNPJ = E.CNPJ
			   			   
		FROM Empresa E (NOLOCK) 
		WHERE E.CNPJ = @P_CNPJ 
		GROUP BY
		E.CNPJ
		 				
		IF @CNPJ = @P_CNPJ BEGIN
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


