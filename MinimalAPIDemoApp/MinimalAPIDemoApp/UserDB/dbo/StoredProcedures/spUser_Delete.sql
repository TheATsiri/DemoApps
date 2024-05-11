CREATE PROCEDURE [dbo].[spUser_Delete]
	@ID int
AS
begin
	delete 
	from dbo.[User]
	where Id=@Id;
end
