CREATE PROCEDURE [dbo].[Itemactions]
	@Action int,
	@name nvarchar(50),
	@type nvarchar(50) = null,
	@newname nvarchar(50) = null
AS

if @Action = 0 -- if action is add

begin
	insert into dbo.Items([dbo].[Items].[Name],[dbo].[Items].[Type]) -- add data 
	values (@name, @type)
end
else
if @Action = 1 -- if action is edit 

begin
	if @type = 'none'
		update dbo.Items
		set [dbo].[Items].[Name] = @newname
		where [dbo].[Items].[Name] = @name
	else

	update dbo.Items -- update data 
	set [dbo].[Items].[Name] = @newname, [dbo].[Items].[Type] = @type
	where [dbo].[Items].[Name] = @name
end

else
if @Action = 2 -- if action is delete

begin  -- delete data
	delete from dbo.Items
	where [dbo].[Items].[Name] = @name
end
