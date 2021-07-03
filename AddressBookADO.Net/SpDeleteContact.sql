CREATE PROCEDURE [dbo].[SpDeleteContact]
@name varchar(255)
AS
	DELETE FROM ContactBook  
	Where firstName = @name;
RETURN 0