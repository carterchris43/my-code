
-- =============================================
-- Author: Chris Carter
-- Create date: 27 Jul 2022
-- Description: Delete a record from the dbo.Contacts table by @Id
-- Code Reviewer: /* removed */

-- MODIFIED BY:
-- MODIFIED DATE:
-- Code Reviewer:
-- Note:
-- =============================================

ALTER   PROC [dbo].[Contacts_Delete_ById]
		
		@Id int

as

/* --- TEST CODE ---

	Declare @Id int = 4

	SELECT * from dbo.Contacts WHERE Id = @Id
	
	EXECUTE dbo.Contacts_Delete_ById @Id

	Select * from dbo.Contacts WHERE Id = @Id

--- END TEST CODE ---
*/

BEGIN

	DELETE FROM [dbo].[Contacts]
		  WHERE Id = @Id


END




