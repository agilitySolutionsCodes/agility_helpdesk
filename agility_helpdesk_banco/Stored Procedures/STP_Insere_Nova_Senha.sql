USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Insere_Nova_Senha]    Script Date: 09/08/2014 17:17:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =======================================================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  15/10/2013   
-- Descrição:  Insere nova senha para usuário com problemas de acesso ao sistema   
-- Número Data        Usuário   Descrição      
-- #001#  
-- =======================================================================================================  
    
ALTER PROCEDURE [dbo].[STP_Insere_Nova_Senha]      
(   
 @P_IdUsuario INT,
 @P_NovaSenha VARCHAR(40)
)      
AS      
BEGIN      
SET NOCOUNT ON    

	Update Usuario 
	Set Senha = @P_NovaSenha
	Where IdUsuario = @P_IdUsuario AND Ativo = 1
	
END      
SET NOCOUNT OFF 



GO


