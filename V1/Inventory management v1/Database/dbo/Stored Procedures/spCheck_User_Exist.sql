CREATE PROCEDURE [dbo].[spCheck_User_Exist]
	@Username nvarchar(50) -- defines the procedure with parameter Username
AS
BEGIN
	select 1 -- returns 1 when the username in Users is equal 
	from dbo.Users -- to the parameter username
	where @Username = Username;
end
