USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_Categoria]    Script Date: 09/08/2014 17:15:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  10/10/2013      
-- Descri��o:	  Incluir / Alterar Categoria   
-- N�MERO		DATA        USU�RIO   DESCRI��O      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Incluir_Categoria]      

(     
 @P_IdCategoria INTEGER = NULL,
 @P_IdEmpresa INT,
 @P_Nome VARCHAR(80),
 @P_Descricao VARCHAR(255),
 @P_Ativo BIT
)      

AS      
BEGIN      
SET NOCOUNT ON
		
			INSERT INTO Categoria(Nome, Descricao, Ativo, Empresa) 
			VALUES(@P_Nome, @P_Descricao, @P_Ativo, @P_IdEmpresa)		
END      
SET NOCOUNT OFF 




GO


