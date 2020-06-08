CREATE PROCEDURE CreateMember 
    @FirstName varchar(255), @Affix varchar(255), @LastName varchar(255), @BirthDate date, @EmailAddress varchar(255), @Telephone varchar(255), @Street varchar(255), 
    @Number int, @NumberSuffix varchar(255), @ZipCode char(6), @Place varchar(255), @AddressNote varchar(1023), @ID int OUTPUT
AS
INSERT INTO Members ( FirstName, Affix, LastName, BirthDate, EmailAddress, Telephone, Street, Number, NumberSuffix, ZipCode, Place, AddressNote )
VALUES ( @FirstName, @Affix, @LastName, @BirthDate, @EmailAddress, @Telephone, @Street, @Number, @NumberSuffix, @ZipCode, @Place, @AddressNote )
SET @ID = SCOPE_IDENTITY()
RETURN  @ID
GO