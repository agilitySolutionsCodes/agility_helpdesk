USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_Empresa]    Script Date: 04/01/2015 14:22:31 ******/
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

CREATE PROCEDURE [dbo].[STP_Deleta_Empresa]    
(     
 @P_IdEmpresa INT
)       
AS      
BEGIN      
SET NOCOUNT ON   

	DELETE FROM Empresa WHERE @P_IdEmpresa = IdEmpresa
END      
SET NOCOUNT OFF 



GO


