CREATE PROCEDURE [dbo].[SpGetContact]
@firstName varchar(255)
AS
	SELECT firstName, lastName, address, city, state, zip, phoneNumber, email FROM ContactBook WHERE firstName = @firstName;
RETURN 0
