USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Usuario]    Script Date: 09/08/2014 17:17:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  10/10/2013      
-- Descrição:	  Incluir / Alterar usuario   
-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Incluir_Usuario]      

(     
 @P_IdUsuario INTEGER = NULL,
 @P_Nome VARCHAR(80),
 @P_Email VARCHAR(100),
 @P_Senha VARCHAR(40),
 @P_Departamento INT, 
 @P_Cargo VARCHAR(60),
 @P_Telefone VARCHAR(12),
 @P_Ramal CHAR(2),
 @P_Empresa INT,
 @P_Ativo BIT,
 @P_Administrador BIT,
 @P_PerfilUsuario CHAR(2),
 @P_Imagem VARCHAR(50),
 @CodUsuario INTEGER OUTPUT
)      

AS      
BEGIN      
SET NOCOUNT ON
		INSERT INTO Usuario (Nome, Email, Senha, Departamento, Cargo, Telefone, Ramal, Empresa, Ativo, Administrador, Perfil, Imagem) 
		VALUES(@P_Nome, @P_Email, @P_Senha, @P_Departamento, @P_Cargo, @P_Telefone, @P_Ramal, @P_Empresa, @P_Ativo, @P_Administrador, @P_PerfilUsuario, @P_Imagem)		
		
		SELECT @CodUsuario = (SELECT TOP 1 IdUsuario FROM Usuario ORDER BY IdUsuario DESC)
END      
SET NOCOUNT OFF 






GO


