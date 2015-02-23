USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Usuario]    Script Date: 09/08/2014 17:14:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  31/10/2013      
-- Descri��o:	  Deletar Usu�rio a partir do c�digo do mesmo

-- N�mero			Data    Usu�rio   Descri��o      
-- #001#  
-- =========================================================================    

ALTER PROCEDURE [dbo].[STP_Deleta_Usuario]    
(     
 @P_IdUsuario INT
)       
AS      
BEGIN      
SET NOCOUNT ON   

	DELETE FROM Usuario WHERE @P_IdUsuario = IdUsuario
END      
SET NOCOUNT OFF 




GO


