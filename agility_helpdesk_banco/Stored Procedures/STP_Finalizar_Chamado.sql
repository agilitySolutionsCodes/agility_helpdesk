USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Finalizar_Chamado]    Script Date: 09/08/2014 17:15:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  15/10/2013      
-- Descri��o:	  Finaliza Chamado Status Finalizado
-- N�MERO		DATA        USU�RIO   DESCRI��O      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Finalizar_Chamado]      

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


