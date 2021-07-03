CREATE PROCEDURE [dbo].[SpRetrieveContact]
@city varchar(255)
AS
	SELECT firstName, lastName, address, city, state, zip, phoneNumber, email FROM ContactBook WHERE city = @city;
RETURN 0
