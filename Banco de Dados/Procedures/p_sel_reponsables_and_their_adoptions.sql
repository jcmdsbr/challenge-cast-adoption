SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jean Moreira
-- Create date: 29/07/2018
-- Description: Este procedimento tem como finalidade consultar os responsáveis e suas adoções
-- =============================================
CREATE PROCEDURE p_sel_reponsables_and_their_adoptions
	
AS
BEGIN
	SET NOCOUNT ON;

     SELECT
		 (SELECT COUNT([cd_responsavel]) 
				FROM [dbo].[adocao] as [A] WHERE [R].[cd_responsavel] = [A].[cd_responsavel]) as AdoptedPets
			 ,[cd_responsavel] as split
			 ,[cd_responsavel] as Id
			 ,[nm_responsavel] as Name
			 ,0 as splitCpf
			 ,[cpf_responsavel] as Number
			 ,0 as splitEmail
			 ,[email_responsavel] as Address
           
      FROM [dbo].[responsavel] as [R] 

END
GO
