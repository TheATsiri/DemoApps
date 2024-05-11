CREATE PROCEDURE [dbo].[spUSer_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	insert into dbo.[User] (FirstName,LastName)
	values (@FirstName,@LastName);

end
