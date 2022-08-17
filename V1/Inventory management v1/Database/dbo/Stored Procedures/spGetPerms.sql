CREATE PROCEDURE [dbo].[spGetPerms]
	@ID int
AS
	begin
		select Perms
		from dbo.Users
		where UserID = @ID
	end
RETURN 0
