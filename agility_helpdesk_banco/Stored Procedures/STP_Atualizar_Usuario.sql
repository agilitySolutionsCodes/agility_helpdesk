USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Atualizar_Usuario]    Script Date: 04/01/2015 14:20:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  15/10/2013      
-- Descrição:	  Alterar Usuário    
-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

CREATE PROCEDURE [dbo].[STP_Atualizar_Usuario]      

(     
 @P_IdUsuario INTEGER,
 @P_Nome VARCHAR(80) = NULL,
 @P_Email VARCHAR(100) = NULL, 
 @P_Departamento INT = NULL, 
 @P_Cargo VARCHAR(60) = NULL,
 @P_Telefone VARCHAR(12) = NULL,
 @P_Ramal CHAR(2) = NULL,
 @P_Empresa INT = NULL,
 @P_Ativo BIT,
 @P_Administrador BIT = NULL,
 @P_PerfilUsuario CHAR(2) = NULL,
 @P_Imagem VARCHAR(50) = NULL
)      

AS      
BEGIN      
SET NOCOUNT ON
		
	BEGIN
	
		UPDATE Usuario
		SET 
		Nome = @P_Nome,
		Email = @P_Email,
		Departamento = @P_Departamento,
		Cargo = @P_Cargo,
		Telefone = @P_Telefone,
		Ramal = @P_Ramal,
		Empresa = @P_Empresa,
		Ativo = @P_Ativo,
		Administrador = @P_Administrador,
		Perfil = @P_PerfilUsuario,
		Imagem = @P_Imagem
		
		WHERE IdUsuario = @P_IdUsuario
		
	END		
END      
SET NOCOUNT OFF 





GO


