USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Empresa]    Script Date: 09/08/2014 17:17:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  10/10/2013      
-- Descrição:	  Incluir / Alterar Empresa   
-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Incluir_Empresa]      

(     
 @P_IdEmpresa INTEGER = NULL,
 @P_CNPJ VARCHAR(16),
 @P_RazaoSocial VARCHAR(100),
 @P_NomeFantasia VARCHAR(100),
 @P_Endereco VARCHAR(120),
 @P_UF CHAR(2),
 @P_Cidade VARCHAR(70),
 @P_Cep CHAR(10),
 @P_Telefone VARCHAR(10),
 @P_Email VARCHAR(100),
 @P_Ativo BIT, 
 @P_Matriz BIT, 
 @P_CodMatriz INT = NULL
)      

AS      
BEGIN      
SET NOCOUNT ON
		If(SELECT COUNT(*) FROM Empresa (NOLOCK) WHERE IdEmpresa = @P_IdEmpresa or CNPJ = @P_CNPJ) = 0 BEGIN
			INSERT INTO Empresa (CNPJ, RazaoSocial, NomeFantasia, Endereco, UF, Cidade, Cep, Telefone, Email, Ativo, Matriz, CodigoMatriz) 
			VALUES(@P_CNPJ, @P_RazaoSocial, @P_NomeFantasia, @P_Endereco, @P_UF, @P_Cidade, @P_Cep, @P_Telefone, @P_Email, @P_Ativo, @P_Matriz, @P_CodMatriz)		
			
		END
END      
SET NOCOUNT OFF 





GO


