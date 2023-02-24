CREATE PROCEDURE [dbo].[Batchactions]
	@Action int,
	@number int = null,
	@item int = null,
	@quant int = null,
	@date date = null
AS

if @Action = 0 -- if action is add

begin
	insert into dbo.Batches([dbo].[Batches].[ItemID],[dbo].[Batches].[Quantity],[dbo].[Batches].[ExpiryDate])  -- add data 
	values (@item, @quant, @date)
end
else
if @Action = 1 -- if action is edit 

begin
	update dbo.Batches -- update data 
	set [dbo].[Batches].[ItemID] = @item, [dbo].[Batches].[Quantity] = @quant, [dbo].[Batches].[ExpiryDate] = @date
	where [dbo].[Batches].[BatchID] = @number
end

else
if @Action = 2 -- if action is delete

begin 
	delete from dbo.Batches -- delete data
	where [dbo].[Batches].[BatchID] = @number
end