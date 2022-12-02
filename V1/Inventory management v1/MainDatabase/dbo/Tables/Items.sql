CREATE TABLE [dbo].[Items]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Type] NVARCHAR(50) NULL
)

/*
This creates a table called items with an incrementing PK and 2 other fields
*/
