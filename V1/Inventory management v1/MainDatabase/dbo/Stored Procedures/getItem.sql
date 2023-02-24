CREATE PROCEDURE [dbo].[getItem]
	@param1 nvarchar(50)
AS
begin
	select [ItemId]
	from dbo.Items
	where [dbo].[Items].[Name] = @param1;
end