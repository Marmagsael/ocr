CREATE PROCEDURE [dbo].[LoginByUserName]
	@userName		NVarchar(60), 
	@password		varbinary(150)
AS
begin 
	select * from dbo.Users where UserName = @userName and Password = hashbytes('sha2_512',@password); 
end 