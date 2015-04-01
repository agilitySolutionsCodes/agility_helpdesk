USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Atualizar_Empresa]    Script Date: 04/01/2015 14:19:52 ******/
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

CREATE PROCEDURE [dbo].[STP_Atualizar_Empresa]      

(     
 @P_IdEmpresa INTEGER,
 @P_CNPJ VARCHAR(16),
 @P_RazaoSocial VARCHAR(100),
 @P_NomeFantasia VARCHAR(100),
 @P_Endereco VARCHAR(120),
 @P_UF CHAR(2),
 @P_Cidade VARCHAR(70),
 @P_Cep CHAR(10),
 --@P_Telefone VARCHAR(10),
 @P_Email VARCHAR(100),
 @P_Ativo BIT,
 @P_Matriz BIT

)      

AS      
BEGIN      
SET NOCOUNT ON
		
	BEGIN
	
		UPDATE Empresa
		SET 
		CNPJ = @P_CNPJ,
		RazaoSocial = @P_RazaoSocial,
		NomeFantasia = @P_NomeFantasia,
		Endereco = @P_Endereco,
		UF = @P_UF,
		Cidade = @P_Cidade,
		Cep = @P_Cep,
		--Telefone = @P_Telefone,
		Email = @P_Email,
		Ativo = @P_Ativo,
		Matriz = @P_Matriz
		
		WHERE IdEmpresa = @P_IdEmpresa AND CNPJ = @P_CNPJ
		
	END		
END      
SET NOCOUNT OFF 



GO


