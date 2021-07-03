CREATE PROCEDURE [dbo].[SpInsertNewContact]
	@firstName varchar(255),
	@lastName varchar(255),
	@address varchar(255),
	@city varchar(255),
	@state varchar(255),
	@zip int,
	@phoneNumber bigint,
	@email varchar(255),
	@Name varchar(255),
	@typeOf varchar(255)
AS
	INSERT INTO ContactBook(firstName, lastName, address, city, state, zip, phoneNumber, email, Name, TypeOf)  
	VALUES(@firstName ,@lastName, @address, @city, @state, @zip, @phoneNumber, @email, @Name, @typeOf );
RETURN 0