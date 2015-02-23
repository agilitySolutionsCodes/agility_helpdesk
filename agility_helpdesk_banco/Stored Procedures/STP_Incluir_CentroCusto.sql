USE [WebHelpDesk]
GO

/****** Object:  StoredProcedure [dbo].[STP_Incluir_CentroCusto]    Script Date: 09/08/2014 17:15:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =========================================================================      
-- Autor:		  Yule Souza - Agility Solutions      
-- Data Criacao:  10/10/2013      
-- Descrição:	  Incluir / Alterar Centro de Custo   
-- NÚMERO		  Data        Usuário     Descrição      
-- #001#  
-- =========================================================================      

ALTER PROCEDURE [dbo].[STP_Incluir_CentroCusto]      

(     
 @P_IdCentroCusto INTEGER = NULL,
 @P_Descricao VARCHAR(80),
 @P_Classe CHAR(2),
 @P_Ativo BIT,
 @P_IdEmpresa INTEGER
)      

AS      
BEGIN      
SET NOCOUNT ON
			INSERT INTO CentroCusto(Descricao, Classe, Ativo, Empresa) 
			VALUES(@P_Descricao, @P_Classe, @P_Ativo, @P_IdEmpresa)		
END      
SET NOCOUNT OFF 



GO


