CREATE PROCEDURE [dbo].[SpGetSizeByType]
AS
	SELECT Count(typeOf) from ContactBook;
RETURN 0
