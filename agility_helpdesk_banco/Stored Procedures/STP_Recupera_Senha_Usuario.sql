USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Recupera_Senha_Usuario]    Script Date: 04/01/2015 14:31:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================================================    
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  26/09/2013      
-- Descrição:  Valida E-mail fornecido pelo usuário para recuperação de senha
-- Número Data        Usuário   Descrição      
-- #001#  
-- =============================================================================  
    
CREATE PROCEDURE [dbo].[STP_Recupera_Senha_Usuario]      
(   
 @P_Email VARCHAR(100),
 @Ok BIT OUTPUT,
 @CodUsuario INTEGER OUTPUT,
 @NomeUsuario VARCHAR(80) OUTPUT,
 @ImagemUsuario VARCHAR(100) OUTPUT, 
 @Ativo BIT OUTPUT,
 @PerfilUsuario BIT OUTPUT,
 @EmailExistente VARCHAR(100) OUTPUT  
)      
AS      
BEGIN      
SET NOCOUNT ON    

	SET @CodUsuario = 0
	SET @NomeUsuario = ''
	SET @Ativo = 0
	
	IF(SELECT COUNT(*) FROM Usuario WHERE Email = @P_Email) > 0 BEGIN
	    
		SELECT  
			   @EmailExistente = U.Email, 
			   @CodUsuario = U.IdUsuario, 
			   @NomeUsuario = U.Nome, 
			   @ImagemUsuario = U.Imagem, 
			   @Ativo = U.Ativo,
			   @PerfilUsuario = U.Administrador			   
			   
		FROM Usuario U (NOLOCK) 
		WHERE U.Email = @P_Email AND U.Ativo = 1
		
		GROUP BY
		U.Email,
		U.IdUsuario,
		U.Nome,
		U.Imagem,
		U.Ativo,
		U.Administrador	
		 				
		IF @EmailExistente = @P_Email BEGIN
			SET @Ok = 'TRUE'
		END
		ELSE BEGIN
			SET @Ok = 'FALSE'
		END
	END
	ELSE
	BEGIN
		SET @Ok = 'FALSE'
	END
END      
SET NOCOUNT OFF 



GO


