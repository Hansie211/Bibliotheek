CREATE PROCEDURE CreateMember 
    @MemberFirstName varchar(255), @MemberAffix varchar(255), @MemberLastName varchar(255), @MemberBirthDate date, @MemberEmailAddress varchar(255), @MemberTelephone varchar(255), @MemberStreet varchar(255), 
    @MemberNumber int, @MemberNumberSuffix varchar(255), @MemberZipCode char(6), @MemberPlace varchar(255), @MemberAddressNote varchar(1023), @MemberID int OUTPUT
AS
INSERT INTO Members ( FirstName, Affix, LastName, BirthDate, EmailAddress, Telephone, Street, Number, NumberSuffix, ZipCode, Place, AddressNote )
VALUES ( @MemberFirstName, @MemberAffix, @MemberLastName, @MemberBirthDate, @MemberEmailAddress, @MemberTelephone, @MemberStreet, @MemberNumber, @MemberNumberSuffix, @MemberZipCode, @MemberPlace, @MemberAddressNote )
SET @MemberID = SCOPE_IDENTITY()
RETURN  @MemberID
GO


CREATE PROCEDURE UpdateMember 
    @MemberID int, @MemberFirstName varchar(255), @MemberAffix varchar(255), @MemberLastName varchar(255), @MemberBirthDate date, @MemberEmailAddress varchar(255), @MemberTelephone varchar(255), @MemberStreet varchar(255), 
    @MemberNumber int, @MemberNumberSuffix varchar(255), @MemberZipCode char(6), @MemberPlace varchar(255), @MemberAddressNote varchar(1023)
AS
UPDATE Members SET 
    FirstName = @MemberFirstName, Affix = @MemberAffix, LastName = @MemberLastName, BirthDate = @MemberBirthDate, EmailAddress = @MemberEmailAddress, 
    Telephone = @MemberTelephone, Street = @MemberStreet, Number = @MemberNumber, NumberSuffix = @MemberNumberSuffix, ZipCode = @MemberZipCode, Place = @MemberPlace, 
    AddressNote = @MemberAddressNote
WHERE ID = @MemberID
GO

CREATE PROCEDURE GetMember
    @MemberID int, @MemberFirstName varchar(255) OUTPUT, @MemberAffix varchar(255) OUTPUT, @MemberLastName varchar(255) OUTPUT, @MemberBirthDate date OUTPUT, 
    @MemberEmailAddress varchar(255) OUTPUT, @MemberTelephone varchar(255) OUTPUT, @MemberStreet varchar(255) OUTPUT, @MemberNumber int OUTPUT, 
    @MemberNumberSuffix varchar(255) OUTPUT, @MemberZipCode char(6) OUTPUT, @MemberPlace varchar(255) OUTPUT, @MemberAddressNote varchar(1023) OUTPUT,
    @MembershipID int OUTPUT, @MembershipStartDate date OUTPUT, @MembershipEndDate date OUTPUT
AS
SELECT TOP 1 @MemberFirstName = Member.FirstName, @MemberAffix = Member.Affix, @MemberLastName = Member.LastName, @MemberBirthDate = Member.BirthDate, 
    @MemberEmailAddress = Member.EmailAddress, @MemberTelephone = Member.Telephone, @MemberStreet = Member.Street, @MemberNumber = Member.Number, 
    @MemberNumberSuffix = Member.NumberSuffix, @MemberZipCode = Member.ZipCode, @MemberPlace = Member.Place, @MemberAddressNote = Member.AddressNote,
    @MembershipID = Membership.ID, @MembershipStartDate = Membership.StartDate, @MembershipEndDate = Membership.EndDate
FROM Members as Member
LEFT JOIN Memberships as Membership ON Membership.MemberID = Member.ID
WHERE
(@MemberID = Member.ID)
GO

CREATE PROCEDURE DeleteMember
    @MemberID int
AS
DELETE 
FROM Members 
WHERE
@MemberID = ID
GO