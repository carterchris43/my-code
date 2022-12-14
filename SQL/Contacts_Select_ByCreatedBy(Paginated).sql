
-- =============================================
-- Author: Chris Carter
-- Create date: 27 Jul 2022
-- Description: Select paginated records in dbo.Contacts associated with @CreatedBy user
-- Code Reviewer: /*removed*/

-- MODIFIED BY:
-- MODIFIED DATE:
-- Code Reviewer:
-- Note:
-- =============================================

ALTER   PROC [dbo].[Contacts_Select_ByCreatedBy] --Paginated
		
		@PageIndex int
		,@PageSize int
		,@CreatedBy int
		
AS

	DECLARE @offset int = @PageIndex * @PageSize;

/* --- TEST CODE ---

		Declare @PageIndex int = 0
				,@PageSize int = 5
				,@CreatedBy int = 1

		EXECUTE dbo.[Contacts_Select_ByCreatedBy]
				@PageIndex
				,@PageSize
				,@CreatedBy

		SELECT * FROM dbo.Contacts

		DELETE FROM dbo.Contacts WHERE CreatedBy = 8


*/

BEGIN

	SELECT	[Id]
			,[Name]
			,[AvatarUrl]
			,[Email]
			,[Phone]
			,[Notes]
			,[CreatedBy] 
			,TotalCount = COUNT(1) OVER()

	FROM [dbo].[Contacts] WHERE CreatedBy = @CreatedBy

	ORDER BY [Id]

	OFFSET @offSet Rows
	Fetch Next @PageSize Rows ONLY

END


