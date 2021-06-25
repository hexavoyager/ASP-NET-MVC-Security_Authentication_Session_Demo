CREATE PROCEDURE [dbo].[BFSP_DeleteContact]
	@Id int,
	@UserId int
AS
BEGIN
	DELETE FROM [Contact] WHERE Id = @Id and UserId = @UserId;
	RETURN 0
END

