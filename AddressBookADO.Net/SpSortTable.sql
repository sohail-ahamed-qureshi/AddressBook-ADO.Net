CREATE PROCEDURE [dbo].[SpSortTable]
@city varchar(255)
AS
	SELECT firstName, lastName, address, city, state, zip, phoneNumber, email FROM ContactBook WHERE city = @city ORDER BY firstName ASC;
RETURN 0
