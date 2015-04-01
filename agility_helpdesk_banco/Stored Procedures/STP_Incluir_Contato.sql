USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Contato]    Script Date: 04/01/2015 14:28:06 ******/
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

CREATE PROCEDURE [dbo].[STP_Incluir_Contato]      

(     
 @P_IdClassificacao INTEGER = NULL,
 @P_Nome VARCHAR(80),
 @P_Email VARCHAR(100),
 @P_Assunto VARCHAR(75),
 @P_Mensagem VARCHAR(255),
 @P_DataContato DATETIME
)      

AS      
BEGIN      
SET NOCOUNT ON
			INSERT INTO Contato(Nome, Email, Assunto, Mensagem, DataContato) 
			VALUES(@P_Nome, @P_Email, @P_Assunto, @P_Mensagem, @P_DataContato)		
	
END      
SET NOCOUNT OFF 


GO


