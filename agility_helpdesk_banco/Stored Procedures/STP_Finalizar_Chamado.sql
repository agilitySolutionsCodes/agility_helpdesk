USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Finalizar_Chamado]    Script Date: 04/01/2015 14:23:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  15/10/2013      
-- Descrição:	  Finaliza Chamado Status Finalizado
-- NÚMERO		DATA        USUÁRIO   DESCRIÇÃO      
-- #001#  
-- =========================================================================      

CREATE PROCEDURE [dbo].[STP_Finalizar_Chamado]      

(     
 @P_IdChamado INT,
 @P_IdUsuario INT,
 @P_Comentario VARCHAR(255),
 @OK BIT OUTPUT
)      

AS      
BEGIN      
SET NOCOUNT ON
		
	BEGIN
	
	IF(SELECT COUNT(*) FROM Chamados WHERE Solicitante = @P_IdUsuario) <> 0
	
	BEGIN 
		UPDATE Chamados
		SET 
		StatusChamado = 'F', Observacao = @P_Comentario
		WHERE IdChamado = @P_IdChamado
		SET @OK = 'TRUE'
	END
	
	ELSE
		BEGIN 
			SET @OK = 'FALSE'
		END
	END		
END      
SET NOCOUNT OFF 







GO


