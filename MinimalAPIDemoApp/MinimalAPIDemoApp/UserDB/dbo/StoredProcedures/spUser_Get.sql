CREATE PROCEDURE [dbo].[spUser_Get]
	@ID int
AS
begin
	select Id, FirstName,LastName
	from dbo.[User]
	where Id=@Id;
end
