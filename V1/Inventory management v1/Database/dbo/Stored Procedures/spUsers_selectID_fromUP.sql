CREATE PROCEDURE [dbo].[spUsers_selectID_fromUP]
	@Username nvarchar(50), -- defines the procedure with username and 
	@Password nvarchar(500) -- password parameters
AS
begin
	select UserID -- returns the User Id where the username and password values
	from dbo.Users -- in the database users match the respective parameters
	where Username = @Username and Password = @Password;
end
