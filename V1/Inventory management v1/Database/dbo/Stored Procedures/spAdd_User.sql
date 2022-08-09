CREATE PROCEDURE [dbo].[spAdd_User]
	@Uname nvarchar(50),
	@Pword nvarchar(500),
	@perm int
AS
Begin
	insert into Users(Username, Password, Perms)
	values(@Uname, @Pword, @perm);
end
