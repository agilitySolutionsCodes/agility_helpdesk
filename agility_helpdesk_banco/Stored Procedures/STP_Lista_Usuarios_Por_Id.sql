USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Usuarios_Por_Id]    Script Date: 04/01/2015 14:31:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Usuários Por Id 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
CREATE PROCEDURE [dbo].[STP_Lista_Usuarios_Por_Id]

(
	@P_IdUsuario INT
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT DISTINCT
    U.IdUsuario, 
    U.Nome, 
    U.Email, 
    U.Cargo, 
    U.Telefone, 
    U.Ramal, 
    E.IdEmpresa AS Empresa, 
    U.Ativo, 
    U.Administrador, 
    U.Imagem, 
    U.Departamento,
    U.Perfil
    
	FROM Usuario U
	JOIN Empresa E
	ON U.Empresa = E.IdEmpresa
	
    WHERE IdUsuario = @P_IdUsuario
END





GO


