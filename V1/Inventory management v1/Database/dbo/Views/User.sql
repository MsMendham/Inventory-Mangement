CREATE VIEW [dbo].[User]
	AS 
	select [u].[UserID], [u].[Username], [u].[Password], [u].[Perms]
	from dbo.Users u
