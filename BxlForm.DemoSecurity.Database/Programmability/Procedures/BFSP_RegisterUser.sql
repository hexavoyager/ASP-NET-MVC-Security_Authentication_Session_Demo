CREATE PROCEDURE [dbo].[BFSP_RegisterUser]
	@LastName NVARCHAR(75),
	@FirstName NVARCHAR(75),
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	INSERT INTO [User] (LastName, FirstName, Email, Passwd) VALUES 
	(@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.BFSF_GetPreSalt() + @Passwd + dbo.BFSF_GetPostSalt()));

	if(SCOPE_IDENTITY() = 1)
		Update [User] Set IsAdmin = 1 WHERE Id = 1;

	RETURN 0;
END
