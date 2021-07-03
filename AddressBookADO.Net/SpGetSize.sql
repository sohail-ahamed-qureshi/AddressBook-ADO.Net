CREATE PROCEDURE [dbo].[SpGetSize]
AS
	SELECT Count(city), Count(state) FROM ContactBook;
RETURN 0
