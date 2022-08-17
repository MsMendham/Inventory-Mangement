CREATE PROCEDURE [dbo].[getUsername]
	@ID int
AS
	begin
		select Username
		from dbo.Users
		where UserID = @ID
	end
RETURN 0
