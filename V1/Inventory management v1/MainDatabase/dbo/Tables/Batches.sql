CREATE TABLE [dbo].[Batches]
(
	[BatchID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemID] INT NOT NULL, 
    [ExpiryDate] DATE NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_Batches_Items] FOREIGN KEY ([ItemID]) REFERENCES [Items]([ItemId])
)
/*
This creates a table with 4 fields, with the id that incremenst and a foriegn key connecting batches and items
*/