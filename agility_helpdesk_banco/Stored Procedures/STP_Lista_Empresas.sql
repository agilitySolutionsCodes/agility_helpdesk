USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Empresas]    Script Date: 09/08/2014 17:19:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descrição:		Lista Empresas Cadastradas 
-- Número			  Data		 Usuário      Descrição
-- #001#			29/10/2013	Yule Souza	 Primeira Versão
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Empresas]

(
	@P_IdUsuario INT
)

AS
BEGIN

	SET NOCOUNT ON;
	
    SELECT DISTINCT
    E.IdEmpresa, 
    E.CNPJ, 
    E.RazaoSocial, 
    E.NomeFantasia, 
    Endereco, 
    E.UF, 
    E.Cidade, 
    E.Cep, 
    E.Telefone, 
    E.Email, 
    E.Ativo
    
    FROM Empresa E
    JOIN Usuario U
    ON E.IdEmpresa = U.Empresa
    WHERE U.IdUsuario = @P_IdUsuario
	
END


GO


