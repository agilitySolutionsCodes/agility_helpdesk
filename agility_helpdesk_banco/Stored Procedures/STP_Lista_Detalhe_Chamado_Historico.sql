USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Detalhe_Chamado_Historico]    Script Date: 06/02/2015 13:40:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Chamados 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
CREATE PROCEDURE [dbo].[STP_Lista_Detalhe_Chamado_Historico]

(
	@P_IdChamado INT
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
	   HA.IdHistorico,
	   U.Nome,
	   HA.Comentario,
	   HA.DataComentario
	   
	FROM Chamados C
	JOIN HistoricoAtendimento HA
	ON C.IdChamado = HA.Chamado
	JOIN Usuario U 
	ON HA.Usuario = U.IdUsuario
	WHERE HA.Chamado = @P_IdChamado
	
END


GO


