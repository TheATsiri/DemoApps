if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName,LastName)
	values ('Antonios','Tsiriplis'),
	('Sue','Storm'),
	('Jonh','Smith'),
	('Mary','Jones')
end
