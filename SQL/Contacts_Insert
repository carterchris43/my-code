CREATE OR ALTER proc [dbo].[Contacts_Insert]

			@Name nvarchar(200) = null
			,@AvatarUrl varchar(255) = null
			,@Email nvarchar(255)
			,@Phone nvarchar(20) = null
			,@Notes nvarchar(500) = null
			,@CreatedBy int
			,@Id int OUTPUT


as

/* --- TEST CODE ---

			DECLARE @Id int = 0

			DECLARE @Name nvarchar(200) = null
					,@AvatarUrl varchar(255) = null
					,@Email nvarchar(255) = 'test@test.com'
					,@Phone nvarchar(20) = null
					,@Notes nvarchar(500) = null
					,@CreatedBy int = 1

			EXECUTE dbo.[Contacts_Insert]
					@Name
					,@AvatarUrl
					,@Email
					,@Phone
					,@Notes
					,@CreatedBy
					,@Id OUTPUT

			SELECT * FROM dbo.Contacts WHERE Id = @Id

*/

BEGIN

			INSERT INTO [dbo].[Contacts]
				([Name]
				,[AvatarUrl]
				,[Email]
				,[Phone]
				,[Notes]
				,[CreatedBy])

			VALUES
				(@Name
				,@AvatarUrl
				,@Email
				,@Phone
				,@Notes
				,@CreatedBy)

			SET @Id = SCOPE_IDENTITY()

END
