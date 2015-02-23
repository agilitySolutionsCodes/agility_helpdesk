USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Categoria]    Script Date: 09/08/2014 17:12:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  31/10/2013      
-- Descrição:	  Deletar Categoria a partir do código do mesmo

-- Número			Data    Usuário   Descrição      
-- #001#  
-- =========================================================================    

ALTER PROCEDURE [dbo].[STP_Deleta_Categoria]    
(     
 @P_IdCategoria INT
)       
AS      
BEGIN      
SET NOCOUNT ON   

	DELETE FROM Categoria WHERE @P_IdCategoria = IdCategoria
END      
SET NOCOUNT OFF 




GO


