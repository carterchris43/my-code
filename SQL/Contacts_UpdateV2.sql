-- =============================================
-- Author: Chris Carter
-- Create date: 30 Aug 2022
-- Description: V2 to allow update without the CreatedBy parameter coming from logged-in user middle tier
-- Code Reviewer: /*removed*/

-- MODIFIED BY: 
-- MODIFIED DATE: 
-- Code Reviewer: 
-- Note: 
-- =============================================

CREATE OR ALTER	PROC [dbo].[Contacts_UpdateV2]
		
			@Name nvarchar(200) = null
			,@AvatarUrl varchar(255) = null
			,@Email nvarchar(255)
			,@Phone nvarchar(20) = null
			,@Notes nvarchar(500) = null
			,@Id int
		
AS
 
/* --- TEST CODE ---

	DECLARE @Id int = 34
			,@Name nvarchar(200) = '222'
			,@AvatarUrl varchar(255) = null
			,@Email nvarchar(255) = 'fromsoft@test.com'
			,@Phone nvarchar(20) = 123
			,@Notes nvarchar(500) = null
			
			

	EXECUTE dbo.Contacts_UpdateV2
			@Name
			,@AvatarUrl
			,@Email
			,@Phone
			,@Notes
			,@Id

		SELECT * FROM dbo.Contacts WHERE Id = @Id

*/
BEGIN

	DECLARE @CurrentDate datetime2(7) = getutcdate()

	UPDATE dbo.Contacts

	SET	[Name] = @Name
		,[AvatarUrl] = @AvatarUrl
		,[Email] = @Email
		,[Phone] = @Phone
		,[Notes] = @Notes
		,[DateModified] = @CurrentDate

	WHERE [Id] = @Id

END 

