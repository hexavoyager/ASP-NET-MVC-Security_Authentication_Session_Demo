CREATE PROCEDURE [dbo].[BFSP_UpdateContact]
	@Id int,
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75),
	@Email NVARCHAR(75),
	@CategoryId INT,
	@UserId INT
AS
BEGIN
	UPDATE [Contact] Set [LastName] = @LastName, [FirstName] = @FirstName, [Email] = @Email, [CategoryId] = @CategoryId WHERE Id = @Id and UserId = @UserId;
	RETURN 0
END
