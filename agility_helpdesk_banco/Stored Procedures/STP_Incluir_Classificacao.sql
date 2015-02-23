USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Classificacao]    Script Date: 09/08/2014 17:16:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  10/10/2013      
-- Descrição:	  Incluir / Alterar Classificacao   
-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Incluir_Classificacao]      

(     
 @P_IdClassificacao INTEGER = NULL,
 @P_IdEmpresa INT,
 @P_Nome VARCHAR(80),
 @P_Descricao VARCHAR(255),
 @P_Ativo BIT
)      

AS      
BEGIN      
SET NOCOUNT ON
		
			INSERT INTO Classificacao(Nome, Descricao, Ativo, Empresa) 
			VALUES(@P_Nome, @P_Descricao, @P_Ativo, @P_IdEmpresa)		

END      
SET NOCOUNT OFF 




GO


