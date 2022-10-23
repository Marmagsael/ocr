CREATE PROCEDURE [dbo].[spUsers_GetById]
	@id int 
AS
begin 
	select * from dbo.Users where Id = @id; 
end 
