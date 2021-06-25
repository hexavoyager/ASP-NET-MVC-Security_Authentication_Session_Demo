CREATE PROCEDURE [dbo].[BFSP_AddContact]
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75),
	@Email NVARCHAR(75),
	@CategoryId INT,
	@UserId int
AS
BEGIN
	INSERT INTO [Contact] ([LastName], [FirstName], [Email], [CategoryId], [UserId]) VALUES (@LastName, @FirstName, @Email, @CategoryId, @UserId);
	RETURN 0
END