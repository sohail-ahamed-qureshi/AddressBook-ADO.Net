﻿CREATE PROCEDURE [dbo].[SpEditContact]
@name varchar(255),
@firstName varchar(255),
	@lastName varchar(255),
	@address varchar(255),
	@city varchar(255),
	@state varchar(255),
	@zip int,
	@phoneNumber bigint,
	@email varchar(255)
AS
	UPDATE ContactBook set firstName = @firstName, lastName =@lastName , address = @address, city =@city , state = @state, zip =@zip , phoneNumber = @phoneNumber, email = @email  
	Where firstName = @name;
RETURN 0
