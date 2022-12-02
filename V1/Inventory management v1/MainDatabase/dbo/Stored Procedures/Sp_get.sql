CREATE PROCEDURE [dbo].[Sp_get]
	@param1 int -- takes a paramter that should be a 1 or a 0
AS
if @param1 = 1 -- if its 1 gets all data from items
begin
	select [ItemId], [Name], [Type]
	from dbo.Items
end
else -- otherwise gets all data from batches
begin
	select [BatchID], [ItemID], [ExpiryDate], [Quantity] 
	from dbo.Batches
end
