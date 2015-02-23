USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Autenticar_Usuario]    Script Date: 09/08/2014 17:11:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:   Yule Souza. - Agility Solutions      
-- Data Criacao:  26/09/2013      
-- Descrição:  Autenticar Usuário  
-- Número Data        Usuário   Descrição      
-- #001#  
-- =========================================================================  
    
ALTER PROCEDURE [dbo].[STP_Autenticar_Usuario]      
(   
 @P_Email VARCHAR(100),
 @P_Senha VARCHAR(40),
 @Ok BIT OUTPUT,
 @CodUsuario INTEGER OUTPUT,
 @NomeUsuario VARCHAR(80) OUTPUT,
 @ImagemUsuario VARCHAR(100) OUTPUT, 
 @Ativo BIT OUTPUT,
 @PerfilUsuario BIT OUTPUT, 
 @PerfilSistema CHAR(2) OUTPUT,
 @EmpresaUsuario INTEGER OUTPUT 
)      
AS      
BEGIN      
SET NOCOUNT ON    

	DECLARE @Senha VARCHAR(30)

	SET @CodUsuario = 0
	SET @NomeUsuario = ''
	SET @Ativo = 0
	
	IF(SELECT COUNT(*) FROM Usuario WHERE Email = @P_Email) > 0 BEGIN
	    
		SELECT  
			   @Senha = U.Senha, 
			   @CodUsuario = U.IdUsuario, 
			   @NomeUsuario = U.Nome, 
			   @ImagemUsuario = U.Imagem, 
			   @Ativo = U.Ativo,
			   @PerfilSistema = U.Perfil,
			   @PerfilUsuario = U.Administrador,	
			   @EmpresaUsuario = U.Empresa
			   
		FROM Usuario U (NOLOCK) 
		WHERE U.Email = @P_Email 
		
		GROUP BY
		U.Senha,
		U.IdUsuario,
		U.Nome,
		U.Imagem,
		U.Ativo,
		U.Perfil,
		U.Administrador,
		U.Empresa	
		 				
		IF @Senha = @P_Senha BEGIN
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


