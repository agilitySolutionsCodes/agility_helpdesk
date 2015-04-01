USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Categorias]    Script Date: 04/01/2015 14:28:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descri��o:		Lista Categorias 
-- N�mero			  Data		 Usu�rio      Descri��o
-- #001#			29/10/2013	Yule Souza	 Primeira Vers�o
-- ===================================================================================      
CREATE PROCEDURE [dbo].[STP_Lista_Categorias]
(
	@P_IdUsuario INT 
)
AS
BEGIN

	SET NOCOUNT ON;

    SELECT DISTINCT
    CA.IdCategoria, CA.Nome, CA.Descricao, CA.Descricao, CA.Ativo
    FROM Categoria CA
	JOIN Empresa E
	ON CA.Empresa = E.IdEmpresa 
	JOIN Usuario U 
	ON U.IdUsuario = @P_IdUsuario 
	WHERE E.IdEmpresa = U.Empresa
	ORDER BY CA.IdCategoria
	
END









GO


