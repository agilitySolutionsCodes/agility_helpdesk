USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Usuarios]    Script Date: 09/08/2014 17:20:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Usuarios Cadastrados Recebe como paramêtro o Id do usuário
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Usuarios]
(
	@P_IdEmpresa INT, 
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
    E.IdEmpresa,
    E.NomeFantasia AS Empresa, 
    U.Imagem, 
    CC.Descricao AS Departamento, 
    U.Ativo
    FROM Usuario U
    JOIN Empresa E 
    ON U.Empresa = E.IdEmpresa
    JOIN CentroCusto CC
    ON U.Departamento = CC.IdCentroCusto
    WHERE U.Empresa = @P_IdEmpresa AND U.IdUsuario <> @P_IdUsuario
	
END








GO


