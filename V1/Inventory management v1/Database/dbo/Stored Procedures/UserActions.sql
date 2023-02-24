CREATE PROCEDURE [dbo].[UserActions]
	@action int, -- gets what action to be peformed
	@username nvarchar(50), -- gets username
	@pass nvarchar(500) = null, -- gets password
	@perms int = null
AS
if @action = 0 -- if action is add

begin
	Insert into dbo.Users ([dbo].[Users].[Username],[dbo].[Users].[Password], Perms) -- insert data
	values (@username, @pass, @perms);
end

else
if @action = 1 -- if action is edit

begin
	update dbo.Users -- update data 
	set [dbo].[Users].[Password] = @pass
	Where [dbo].[Users].[Username] = @username
end

else
if @action = 2 -- if action is delete

begin
	delete from [dbo].[Users] --delete data
	where [dbo].[Users].[Username] = @username
end
return 0




