USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Deleta_CentroCusto]    Script Date: 04/01/2015 14:21:05 ******/
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

CREATE PROCEDURE [dbo].[STP_Deleta_CentroCusto]    
(     
 @P_IdCentroCusto INT
)       
AS      
BEGIN      
SET NOCOUNT ON   

	DELETE FROM CentroCusto WHERE @P_IdCentroCusto = IdCentroCusto
END      
SET NOCOUNT OFF 


GO


