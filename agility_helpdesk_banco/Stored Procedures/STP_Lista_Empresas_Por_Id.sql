USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Lista_Empresas_Por_Id]    Script Date: 09/08/2014 17:19:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ===================================================================================       
-- Autor:			Yule Souza. - Agility Solutions      
-- Data Criacao:	29/10/2013     
-- Descri��o:		Lista Empresas Por Id 
-- N�mero			  Data		 Usu�rio      Descri��o
-- #001#			29/10/2013	Yule Souza	 Primeira Vers�o
-- ===================================================================================      
ALTER PROCEDURE [dbo].[STP_Lista_Empresas_Por_Id]

(
	@P_IdEmpresa INT
)

AS
BEGIN

	SET NOCOUNT ON;

    SELECT DISTINCT
    IdEmpresa, CNPJ, RazaoSocial, NomeFantasia, Endereco, UF, Cidade, Cep, Telefone, Email, Ativo, Matriz
    
	FROM Empresa
    WHERE IdEmpresa = @P_IdEmpresa
END



GO


