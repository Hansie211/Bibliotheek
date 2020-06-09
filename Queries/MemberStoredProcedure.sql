CREATE PROCEDURE CreateMember 
    @FirstName varchar(255), @Affix varchar(255), @LastName varchar(255), @BirthDate date, @EmailAddress varchar(255), @Telephone varchar(255), @Street varchar(255), 
    @Number int, @NumberSuffix varchar(255), @ZipCode char(6), @Place varchar(255), @AddressNote varchar(1023), @ID int OUTPUT
AS
INSERT INTO Members ( FirstName, Affix, LastName, BirthDate, EmailAddress, Telephone, Street, Number, NumberSuffix, ZipCode, Place, AddressNote )
VALUES ( @FirstName, @Affix, @LastName, @BirthDate, @EmailAddress, @Telephone, @Street, @Number, @NumberSuffix, @ZipCode, @Place, @AddressNote )
SET @ID = SCOPE_IDENTITY()
RETURN  @ID
GO

CREATE PROCEDURE UpdateMember 
    @ID int, @FirstName varchar(255), @Affix varchar(255), @LastName varchar(255), @BirthDate date, @EmailAddress varchar(255), @Telephone varchar(255), @Street varchar(255), 
    @Number int, @NumberSuffix varchar(255), @ZipCode char(6), @Place varchar(255), @AddressNote varchar(1023)
AS
UPDATE Members SET 
    FirstName = @FirstName, Affix = @Affix, LastName = @LastName, BirthDate = @BirthDate, EmailAddress = @EmailAddress, 
    Telephone = @Telephone, Street = @Street, Number = @Number, NumberSuffix = @NumberSuffix, ZipCode = @ZipCode, Place = @Place, 
    AddressNote = @AddressNote
WHERE ID = @ID
GO

CREATE PROCEDURE GetMember
    @ID int, @FirstName varchar(255) OUTPUT, @Affix varchar(255) OUTPUT, @LastName varchar(255) OUTPUT, @BirthDate date OUTPUT, 
    @EmailAddress varchar(255) OUTPUT, @Telephone varchar(255) OUTPUT, @Street varchar(255) OUTPUT, @Number int OUTPUT, 
    @NumberSuffix varchar(255) OUTPUT, @ZipCode char(6) OUTPUT, @Place varchar(255) OUTPUT, @AddressNote varchar(1023) OUTPUT,
    @MembershipID int OUTPUT, @MembershipStartDate date OUTPUT, @MembershipEndDate date OUTPUT
AS
SELECT TOP 1 @FirstName = Member.FirstName, @Affix = Member.Affix, @LastName = Member.LastName, @BirthDate = Member.BirthDate, 
    @EmailAddress = Member.EmailAddress, @Telephone = Member.Telephone, @Street = Member.Street, @Number = Member.Number, 
    @NumberSuffix = Member.NumberSuffix, @ZipCode = Member.ZipCode, @Place = Member.Place, @AddressNote = Member.AddressNote,
    @MembershipID = Membership.ID, @MembershipStartDate = Membership.StartDate, @MembershipEndDate = Membership.EndDate
FROM Members as Member
LEFT JOIN Memberships as Membership ON Membership.MemberID = Member.ID
WHERE
(@ID = Member.ID)
