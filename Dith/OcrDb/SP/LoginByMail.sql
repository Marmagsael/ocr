CREATE PROCEDURE [dbo].[LoginByMail]
	@email		NVarchar(60), 
	@password	varbinary(150) 
AS
begin 
	select * from dbo.Users where Email = @email and Password = hashbytes('sha2_512',@password); 
end 
