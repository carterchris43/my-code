
-- =============================================
-- Author: Chris Carter
-- Create date: 27 Jul 2022
-- Description: Search by user for a list of the contacts associated with the user who created them.
-- Code Reviewer: /* removed */

-- MODIFIED BY: Author
-- MODIFIED DATE: 29 Jul 2022
-- Code Reviewer: /* removed */
-- Note: Edited parameters to include @CreatedBy & @Query, changed WHERE clause to allow querying against several different columns
-- =============================================

ALTER   PROC [dbo].[Contacts_Search] 
		
		@PageIndex int
		,@PageSize int
		,@CreatedBy int
		,@Query nvarchar(255)
		
		
AS

	DECLARE @offset int = @PageIndex * @PageSize;

/* --- TEST CODE ---

		Declare @PageIndex int = 0
				,@PageSize int = 5
				,@CreatedBy int = 1
				,@Query nvarchar(255) = 'test'

		EXECUTE dbo.[Contacts_Search]
				@PageIndex
				,@PageSize
				,@CreatedBy
				,@Query

		SELECT * FROM dbo.Contacts

*/

BEGIN

	SELECT	[Id]
			,[Name]
			,[AvatarUrl]
			,[Email]
			,[Phone]
			,[Notes]
			,[CreatedBy]
			,[TotalCount] = COUNT(1) OVER()

	FROM [dbo].[Contacts] 
	WHERE (CreatedBy = @CreatedBy) 
			AND ([Name] LIKE '%' + @Query + '%' 
			OR [Email] LIKE '%' + @Query + '%' 
			OR [Phone] LIKE '%' + @Query + '%')

	ORDER BY [Id]

	OFFSET @offSet Rows
	Fetch Next @PageSize Rows ONLY

END


