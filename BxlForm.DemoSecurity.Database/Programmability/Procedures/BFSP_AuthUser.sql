CREATE PROCEDURE [dbo].[BFSP_AuthUser]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [Id], LastName, FirstName, Email, IsAdmin
	FROM [User] 
	WHERE Email = @Email
	AND Passwd = HASHBYTES('SHA2_512', dbo.BFSF_GetPreSalt() + @Passwd + dbo.BFSF_GetPostSalt());
	RETURN 0;
END
