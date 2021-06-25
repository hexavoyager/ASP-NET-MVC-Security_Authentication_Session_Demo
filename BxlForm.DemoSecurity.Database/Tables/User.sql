CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY, 
    [LastName] NVARCHAR(75) NOT NULL, 
    [FirstName] NVARCHAR(75) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    [Passwd] BINARY(64) NOT NULL, 
    [IsAdmin] BIT NOT NULL
        CONSTRAINT DF_User_IsAdmin DEFAULT (0), 
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_User_Email] UNIQUE ([Email]) 
)
