USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Categoria]    Script Date: 04/01/2015 14:20:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  31/10/2013      
-- Descri��o:	  Deletar Categoria a partir do c�digo do mesmo

-- N�mero			Data    Usu�rio   Descri��o      
-- #001#  
-- =========================================================================    

CREATE PROCEDURE [dbo].[STP_Deleta_Categoria]    
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


