USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Classificacao]    Script Date: 04/01/2015 14:22:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  31/10/2013      
-- Descrição:	  Deletar Classificação a partir do código do mesmo

-- Número			Data    Usuário   Descrição      
-- #001#  
-- =========================================================================    

CREATE PROCEDURE [dbo].[STP_Deleta_Classificacao]    
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


