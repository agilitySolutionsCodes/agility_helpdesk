USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Aceita_Termos_Uso]    Script Date: 09/08/2014 17:08:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =======================================================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  26/09/2013   
-- Descri��o:  Atualiza Campo Ativo Tabela Usu�rios para setar que usu�rio aceitou os termos de uso   
-- N�mero Data        Usu�rio   Descri��o      
-- #001#  
-- =======================================================================================================  
    
ALTER PROCEDURE [dbo].[STP_Aceita_Termos_Uso]      
(   
 @P_IdUsuario INT,
 @P_Ativo BIT,
 @P_NovaSenha VARCHAR(40)
)      
AS      
BEGIN      
SET NOCOUNT ON    

	Update Usuario 
	Set Ativo = @P_Ativo, Senha = @P_NovaSenha
	Where IdUsuario = @P_IdUsuario
	
END      
SET NOCOUNT OFF 



GO


