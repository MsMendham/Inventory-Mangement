CREATE TABLE [dbo].[Users]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(1000) NOT NULL, 
    [Perms] INT NOT NULL
)
/*
creates a table with a primary key UserID that is an identity so will increment, 
a username and password fields and a perms field.
*/
