SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jean Moreira
-- Create date: 29/07/2018
-- Description: Este procedimento tem como finalidade consultar os animais que ainda não foram adotados.
-- =============================================
CREATE PROCEDURE p_sel_pets_not_adopted
AS
BEGIN
	SET NOCOUNT ON;

   SELECT

	[cd_animal] as Id, 
	[nm_animal] as Name, 
	[dc_animal] as Description, 
	[animal].[cd_tipo_animal] as TypePetId,
    [T].[cd_tipo_animal] as split, 
	[T].[cd_tipo_animal] as Id, 
	[T].[dc_tipo_animal] as Description 
    
	FROM [dbo].[animal] 

	INNER JOIN [dbo].[tipo_animal] as [T] on [T].[cd_tipo_animal] = [animal].[cd_tipo_animal] 

    WHERE [cd_animal] NOT IN(SELECT cd_animal FROM adocao)

END
GO
