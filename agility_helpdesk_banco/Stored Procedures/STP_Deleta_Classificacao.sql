USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Classificacao]    Script Date: 09/08/2014 17:14:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  31/10/2013      
-- Descri��o:	  Deletar Classifica��o a partir do c�digo do mesmo

-- N�mero			Data    Usu�rio   Descri��o      
-- #001#  
-- =========================================================================    

ALTER PROCEDURE [dbo].[STP_Deleta_Classificacao]    
(     
 @P_IdClassificacao INT
)       
AS      
BEGIN      
SET NOCOUNT ON   

	DELETE FROM Classificacao WHERE @P_IdClassificacao = IdClassificacao
END      
SET NOCOUNT OFF 




GO


