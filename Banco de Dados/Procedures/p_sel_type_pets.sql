SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jean Moreira
-- Create date: 29/07/2018
-- Description: Este procedimento tem como finalidade consultar os tipos dos animais.
-- =============================================
CREATE PROCEDURE p_sel_type_pets
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [cd_tipo_animal] as Id, [dc_tipo_animal] as Description FROM [dbo].[tipo_animal]

END
GO
