CREATE OR ALTER PROCEDURE CreateAuthor
@AuthorFirstName varchar(255), @AuthorAffix varchar(255), @AuthorLastName varchar(255), @AuthorID int OUTPUT
AS
INSERT INTO Authors ( FirstName, Affix, LastName )
VALUES ( @AuthorFirstName, @AuthorAffix, @AuthorLastName)
SET @AuthorID = SCOPE_IDENTITY()
RETURN  @AuthorID
GO

CREATE OR ALTER PROCEDURE GetAuthor
@AuthorID int, @AuthorFirstName varchar(255) OUTPUT, @AuthorAffix varchar(255) OUTPUT, @AuthorLastName varchar(255) OUTPUT
AS
SELECT TOP 1
@AuthorFirstName = Authors.FirstName, @AuthorAffix = Authors.Affix, @AuthorLastName = Authors.LastName
FROM Authors
WHERE
(@AuthorID = Authors.ID)
GO

CREATE OR ALTER PROCEDURE GetAllAuthor
@AuthorID int OUTPUT, @AuthorFirstName varchar(255) OUTPUT, @AuthorAffix varchar(255) OUTPUT, @AuthorLastName varchar(255) OUTPUT
AS
SELECT
@AuthorID = Authors.ID, @AuthorFirstName = Authors.FirstName, @AuthorAffix = Authors.Affix, @AuthorLastName = Authors.LastName
FROM Authors
GO

CREATE OR ALTER PROCEDURE UpdateAuthor
@AuthorFirstName varchar(255), @AuthorAffix varchar(255), @AuthorLastName varchar(255), @AuthorID int
AS
UPDATE Authors SET
FirstName = @AuthorFirstName, Affix = @AuthorAffix, LastName = @AuthorLastName
WHERE ID = @AuthorID
GO

CREATE OR ALTER PROCEDURE DeleteAuthor
@AuthorID int
AS
DELETE
FROM Authors
WHERE
@AuthorID = ID
GO


CREATE OR ALTER PROCEDURE CreateBook
@BookEditionID int, @BookState varchar(255), @BookAddedAt date, @BookInInventory bit, @BookID int OUTPUT
AS
INSERT INTO Books ( EditionID, State, AddedAt, InInventory )
VALUES ( @BookEditionID, @BookState, @BookAddedAt, @BookInInventory)
SET @BookID = SCOPE_IDENTITY()
RETURN  @BookID
GO

CREATE OR ALTER PROCEDURE GetBook
@BookID int, @BookEditionID int OUTPUT, @BookState varchar(255) OUTPUT, @BookAddedAt date OUTPUT, @BookInInventory bit OUTPUT
AS
SELECT TOP 1
@BookEditionID = Books.EditionID, @BookState = Books.State, @BookAddedAt = Books.AddedAt, @BookInInventory = Books.InInventory
FROM Books
WHERE
(@BookID = Books.ID)
GO

CREATE OR ALTER PROCEDURE GetAllBook
@BookID int OUTPUT, @BookEditionID int OUTPUT, @BookState varchar(255) OUTPUT, @BookAddedAt date OUTPUT, @BookInInventory bit OUTPUT
AS
SELECT
@BookID = Books.ID, @BookEditionID = Books.EditionID, @BookState = Books.State, @BookAddedAt = Books.AddedAt, @BookInInventory = Books.InInventory
FROM Books
GO

CREATE OR ALTER PROCEDURE UpdateBook
@BookEditionID int, @BookState varchar(255), @BookAddedAt date, @BookInInventory bit, @BookID int
AS
UPDATE Books SET
EditionID = @BookEditionID, State = @BookState, AddedAt = @BookAddedAt, InInventory = @BookInInventory
WHERE ID = @BookID
GO

CREATE OR ALTER PROCEDURE DeleteBook
@BookID int
AS
DELETE
FROM Books
WHERE
@BookID = ID
GO


CREATE OR ALTER PROCEDURE CreateEdition
@EditionLanguageID int, @EditionTitle varchar(255), @EditionISBN varchar(255), @EditionPublishDate date, @EditionID int OUTPUT
AS
INSERT INTO Editions ( LanguageID, Title, ISBN, PublishDate )
VALUES ( @EditionLanguageID, @EditionTitle, @EditionISBN, @EditionPublishDate)
SET @EditionID = SCOPE_IDENTITY()
RETURN  @EditionID
GO

CREATE OR ALTER PROCEDURE GetEdition
@EditionID int, @EditionLanguageID int OUTPUT, @EditionTitle varchar(255) OUTPUT, @EditionISBN varchar(255) OUTPUT, @EditionPublishDate date OUTPUT
AS
SELECT TOP 1
@EditionLanguageID = Editions.LanguageID, @EditionTitle = Editions.Title, @EditionISBN = Editions.ISBN, @EditionPublishDate = Editions.PublishDate
FROM Editions
WHERE
(@EditionID = Editions.ID)
GO

CREATE OR ALTER PROCEDURE GetAllEdition
@EditionID int OUTPUT, @EditionLanguageID int OUTPUT, @EditionTitle varchar(255) OUTPUT, @EditionISBN varchar(255) OUTPUT, @EditionPublishDate date OUTPUT
AS
SELECT
@EditionID = Editions.ID, @EditionLanguageID = Editions.LanguageID, @EditionTitle = Editions.Title, @EditionISBN = Editions.ISBN, @EditionPublishDate = Editions.PublishDate
FROM Editions
GO

CREATE OR ALTER PROCEDURE UpdateEdition
@EditionLanguageID int, @EditionTitle varchar(255), @EditionISBN varchar(255), @EditionPublishDate date, @EditionID int
AS
UPDATE Editions SET
LanguageID = @EditionLanguageID, Title = @EditionTitle, ISBN = @EditionISBN, PublishDate = @EditionPublishDate
WHERE ID = @EditionID
GO

CREATE OR ALTER PROCEDURE DeleteEdition
@EditionID int
AS
DELETE
FROM Editions
WHERE
@EditionID = ID
GO


CREATE OR ALTER PROCEDURE CreateEmployee
@EmployeeLibraryID int, @EmployeeFirstName varchar(255), @EmployeeAffix varchar(255), @EmployeeLastName varchar(255), @EmployeeStreet varchar(255), @EmployeeNumber int, @EmployeeNumberSuffix varchar(255), @EmployeeZipCode char, @EmployeePlace varchar(255), @EmployeeAddressNote varchar(255), @EmployeePasswordHash varchar(255), @EmployeePasswordSalt varchar(48), @EmployeeID int OUTPUT
AS
INSERT INTO Employees ( LibraryID, FirstName, Affix, LastName, Street, Number, NumberSuffix, ZipCode, Place, AddressNote, PasswordHash, PasswordSalt )
VALUES ( @EmployeeLibraryID, @EmployeeFirstName, @EmployeeAffix, @EmployeeLastName, @EmployeeStreet, @EmployeeNumber, @EmployeeNumberSuffix, @EmployeeZipCode, @EmployeePlace, @EmployeeAddressNote, @EmployeePasswordHash, @EmployeePasswordSalt)
SET @EmployeeID = SCOPE_IDENTITY()
RETURN  @EmployeeID
GO

CREATE OR ALTER PROCEDURE GetEmployee
@EmployeeID int, @EmployeeLibraryID int OUTPUT, @EmployeeFirstName varchar(255) OUTPUT, @EmployeeAffix varchar(255) OUTPUT, @EmployeeLastName varchar(255) OUTPUT, @EmployeeStreet varchar(255) OUTPUT, @EmployeeNumber int OUTPUT, @EmployeeNumberSuffix varchar(255) OUTPUT, @EmployeeZipCode char OUTPUT, @EmployeePlace varchar(255) OUTPUT, @EmployeeAddressNote varchar(255) OUTPUT, @EmployeePasswordHash varchar(255) OUTPUT, @EmployeePasswordSalt varchar(48) OUTPUT
AS
SELECT TOP 1
@EmployeeLibraryID = Employees.LibraryID, @EmployeeFirstName = Employees.FirstName, @EmployeeAffix = Employees.Affix, @EmployeeLastName = Employees.LastName, @EmployeeStreet = Employees.Street, @EmployeeNumber = Employees.Number, @EmployeeNumberSuffix = Employees.NumberSuffix, @EmployeeZipCode = Employees.ZipCode, @EmployeePlace = Employees.Place, @EmployeeAddressNote = Employees.AddressNote, @EmployeePasswordHash = Employees.PasswordHash, @EmployeePasswordSalt = Employees.PasswordSalt
FROM Employees
WHERE
(@EmployeeID = Employees.ID)
GO

CREATE OR ALTER PROCEDURE GetAllEmployee
@EmployeeID int OUTPUT, @EmployeeLibraryID int OUTPUT, @EmployeeFirstName varchar(255) OUTPUT, @EmployeeAffix varchar(255) OUTPUT, @EmployeeLastName varchar(255) OUTPUT, @EmployeeStreet varchar(255) OUTPUT, @EmployeeNumber int OUTPUT, @EmployeeNumberSuffix varchar(255) OUTPUT, @EmployeeZipCode char OUTPUT, @EmployeePlace varchar(255) OUTPUT, @EmployeeAddressNote varchar(255) OUTPUT, @EmployeePasswordHash varchar(255) OUTPUT, @EmployeePasswordSalt varchar(48) OUTPUT
AS
SELECT
@EmployeeID = Employees.ID, @EmployeeLibraryID = Employees.LibraryID, @EmployeeFirstName = Employees.FirstName, @EmployeeAffix = Employees.Affix, @EmployeeLastName = Employees.LastName, @EmployeeStreet = Employees.Street, @EmployeeNumber = Employees.Number, @EmployeeNumberSuffix = Employees.NumberSuffix, @EmployeeZipCode = Employees.ZipCode, @EmployeePlace = Employees.Place, @EmployeeAddressNote = Employees.AddressNote, @EmployeePasswordHash = Employees.PasswordHash, @EmployeePasswordSalt = Employees.PasswordSalt
FROM Employees
GO

CREATE OR ALTER PROCEDURE UpdateEmployee
@EmployeeLibraryID int, @EmployeeFirstName varchar(255), @EmployeeAffix varchar(255), @EmployeeLastName varchar(255), @EmployeeStreet varchar(255), @EmployeeNumber int, @EmployeeNumberSuffix varchar(255), @EmployeeZipCode char, @EmployeePlace varchar(255), @EmployeeAddressNote varchar(255), @EmployeePasswordHash varchar(255), @EmployeePasswordSalt varchar(48), @EmployeeID int
AS
UPDATE Employees SET
LibraryID = @EmployeeLibraryID, FirstName = @EmployeeFirstName, Affix = @EmployeeAffix, LastName = @EmployeeLastName, Street = @EmployeeStreet, Number = @EmployeeNumber, NumberSuffix = @EmployeeNumberSuffix, ZipCode = @EmployeeZipCode, Place = @EmployeePlace, AddressNote = @EmployeeAddressNote, PasswordHash = @EmployeePasswordHash, PasswordSalt = @EmployeePasswordSalt
WHERE ID = @EmployeeID
GO

CREATE OR ALTER PROCEDURE DeleteEmployee
@EmployeeID int
AS
DELETE
FROM Employees
WHERE
@EmployeeID = ID
GO


CREATE OR ALTER PROCEDURE CreateFine
@FineBookID int, @FineMemberID int, @FinePrice decimal, @FineID int OUTPUT
AS
INSERT INTO Fines ( BookID, MemberID, Price )
VALUES ( @FineBookID, @FineMemberID, @FinePrice)
SET @FineID = SCOPE_IDENTITY()
RETURN  @FineID
GO

CREATE OR ALTER PROCEDURE GetFine
@FineID int, @FineBookID int OUTPUT, @FineMemberID int OUTPUT, @FinePrice decimal OUTPUT
AS
SELECT TOP 1
@FineBookID = Fines.BookID, @FineMemberID = Fines.MemberID, @FinePrice = Fines.Price
FROM Fines
WHERE
(@FineID = Fines.ID)
GO

CREATE OR ALTER PROCEDURE GetAllFine
@FineID int OUTPUT, @FineBookID int OUTPUT, @FineMemberID int OUTPUT, @FinePrice decimal OUTPUT
AS
SELECT
@FineID = Fines.ID, @FineBookID = Fines.BookID, @FineMemberID = Fines.MemberID, @FinePrice = Fines.Price
FROM Fines
GO

CREATE OR ALTER PROCEDURE UpdateFine
@FineBookID int, @FineMemberID int, @FinePrice decimal, @FineID int
AS
UPDATE Fines SET
BookID = @FineBookID, MemberID = @FineMemberID, Price = @FinePrice
WHERE ID = @FineID
GO

CREATE OR ALTER PROCEDURE DeleteFine
@FineID int
AS
DELETE
FROM Fines
WHERE
@FineID = ID
GO


CREATE OR ALTER PROCEDURE CreateGenre
@GenreName varchar(255), @GenreID int OUTPUT
AS
INSERT INTO Genres ( Name )
VALUES ( @GenreName)
SET @GenreID = SCOPE_IDENTITY()
RETURN  @GenreID
GO

CREATE OR ALTER PROCEDURE GetGenre
@GenreID int, @GenreName varchar(255) OUTPUT
AS
SELECT TOP 1
@GenreName = Genres.Name
FROM Genres
WHERE
(@GenreID = Genres.ID)
GO

CREATE OR ALTER PROCEDURE GetAllGenre
@GenreID int OUTPUT, @GenreName varchar(255) OUTPUT
AS
SELECT
@GenreID = Genres.ID, @GenreName = Genres.Name
FROM Genres
GO

CREATE OR ALTER PROCEDURE UpdateGenre
@GenreName varchar(255), @GenreID int
AS
UPDATE Genres SET
Name = @GenreName
WHERE ID = @GenreID
GO

CREATE OR ALTER PROCEDURE DeleteGenre
@GenreID int
AS
DELETE
FROM Genres
WHERE
@GenreID = ID
GO


CREATE OR ALTER PROCEDURE CreateLanguage
@LanguageName varchar(255), @LanguageID int OUTPUT
AS
INSERT INTO Languages ( Name )
VALUES ( @LanguageName)
SET @LanguageID = SCOPE_IDENTITY()
RETURN  @LanguageID
GO

CREATE OR ALTER PROCEDURE GetLanguage
@LanguageID int, @LanguageName varchar(255) OUTPUT
AS
SELECT TOP 1
@LanguageName = Languages.Name
FROM Languages
WHERE
(@LanguageID = Languages.ID)
GO

CREATE OR ALTER PROCEDURE GetAllLanguage
@LanguageID int OUTPUT, @LanguageName varchar(255) OUTPUT
AS
SELECT
@LanguageID = Languages.ID, @LanguageName = Languages.Name
FROM Languages
GO

CREATE OR ALTER PROCEDURE UpdateLanguage
@LanguageName varchar(255), @LanguageID int
AS
UPDATE Languages SET
Name = @LanguageName
WHERE ID = @LanguageID
GO

CREATE OR ALTER PROCEDURE DeleteLanguage
@LanguageID int
AS
DELETE
FROM Languages
WHERE
@LanguageID = ID
GO


CREATE OR ALTER PROCEDURE CreateLibrary
@LibraryEmailAddress varchar(255), @LibraryTelephone varchar(255), @LibraryStreet varchar(255), @LibraryNumber int, @LibraryNumberSuffix varchar(255), @LibraryZipCode char, @LibraryPlace varchar(255), @LibraryAddressNote varchar(255), @LibraryID int OUTPUT
AS
INSERT INTO Libraries ( EmailAddress, Telephone, Street, Number, NumberSuffix, ZipCode, Place, AddressNote )
VALUES ( @LibraryEmailAddress, @LibraryTelephone, @LibraryStreet, @LibraryNumber, @LibraryNumberSuffix, @LibraryZipCode, @LibraryPlace, @LibraryAddressNote)
SET @LibraryID = SCOPE_IDENTITY()
RETURN  @LibraryID
GO

CREATE OR ALTER PROCEDURE GetLibrary
@LibraryID int, @LibraryEmailAddress varchar(255) OUTPUT, @LibraryTelephone varchar(255) OUTPUT, @LibraryStreet varchar(255) OUTPUT, @LibraryNumber int OUTPUT, @LibraryNumberSuffix varchar(255) OUTPUT, @LibraryZipCode char OUTPUT, @LibraryPlace varchar(255) OUTPUT, @LibraryAddressNote varchar(255) OUTPUT
AS
SELECT TOP 1
@LibraryEmailAddress = Libraries.EmailAddress, @LibraryTelephone = Libraries.Telephone, @LibraryStreet = Libraries.Street, @LibraryNumber = Libraries.Number, @LibraryNumberSuffix = Libraries.NumberSuffix, @LibraryZipCode = Libraries.ZipCode, @LibraryPlace = Libraries.Place, @LibraryAddressNote = Libraries.AddressNote
FROM Libraries
WHERE
(@LibraryID = Libraries.ID)
GO

CREATE OR ALTER PROCEDURE GetAllLibrary
@LibraryID int OUTPUT, @LibraryEmailAddress varchar(255) OUTPUT, @LibraryTelephone varchar(255) OUTPUT, @LibraryStreet varchar(255) OUTPUT, @LibraryNumber int OUTPUT, @LibraryNumberSuffix varchar(255) OUTPUT, @LibraryZipCode char OUTPUT, @LibraryPlace varchar(255) OUTPUT, @LibraryAddressNote varchar(255) OUTPUT
AS
SELECT
@LibraryID = Libraries.ID, @LibraryEmailAddress = Libraries.EmailAddress, @LibraryTelephone = Libraries.Telephone, @LibraryStreet = Libraries.Street, @LibraryNumber = Libraries.Number, @LibraryNumberSuffix = Libraries.NumberSuffix, @LibraryZipCode = Libraries.ZipCode, @LibraryPlace = Libraries.Place, @LibraryAddressNote = Libraries.AddressNote
FROM Libraries
GO

CREATE OR ALTER PROCEDURE UpdateLibrary
@LibraryEmailAddress varchar(255), @LibraryTelephone varchar(255), @LibraryStreet varchar(255), @LibraryNumber int, @LibraryNumberSuffix varchar(255), @LibraryZipCode char, @LibraryPlace varchar(255), @LibraryAddressNote varchar(255), @LibraryID int
AS
UPDATE Libraries SET
EmailAddress = @LibraryEmailAddress, Telephone = @LibraryTelephone, Street = @LibraryStreet, Number = @LibraryNumber, NumberSuffix = @LibraryNumberSuffix, ZipCode = @LibraryZipCode, Place = @LibraryPlace, AddressNote = @LibraryAddressNote
WHERE ID = @LibraryID
GO

CREATE OR ALTER PROCEDURE DeleteLibrary
@LibraryID int
AS
DELETE
FROM Libraries
WHERE
@LibraryID = ID
GO


CREATE OR ALTER PROCEDURE CreateMember
@MemberFirstName varchar(255), @MemberAffix varchar(255), @MemberLastName varchar(255), @MemberBirthDate date, @MemberEmailAddress varchar(255), @MemberTelephone varchar(255), @MemberStreet varchar(255), @MemberNumber int, @MemberNumberSuffix varchar(255), @MemberZipCode char, @MemberPlace varchar(255), @MemberAddressNote varchar(1023), @MemberID int OUTPUT
AS
INSERT INTO Members ( FirstName, Affix, LastName, BirthDate, EmailAddress, Telephone, Street, Number, NumberSuffix, ZipCode, Place, AddressNote )
VALUES ( @MemberFirstName, @MemberAffix, @MemberLastName, @MemberBirthDate, @MemberEmailAddress, @MemberTelephone, @MemberStreet, @MemberNumber, @MemberNumberSuffix, @MemberZipCode, @MemberPlace, @MemberAddressNote)
SET @MemberID = SCOPE_IDENTITY()
RETURN  @MemberID
GO

CREATE OR ALTER PROCEDURE GetMember
@MemberID int, @MemberFirstName varchar(255) OUTPUT, @MemberAffix varchar(255) OUTPUT, @MemberLastName varchar(255) OUTPUT, @MemberBirthDate date OUTPUT, @MemberEmailAddress varchar(255) OUTPUT, @MemberTelephone varchar(255) OUTPUT, @MemberStreet varchar(255) OUTPUT, @MemberNumber int OUTPUT, @MemberNumberSuffix varchar(255) OUTPUT, @MemberZipCode char OUTPUT, @MemberPlace varchar(255) OUTPUT, @MemberAddressNote varchar(1023) OUTPUT
AS
SELECT TOP 1
@MemberFirstName = Members.FirstName, @MemberAffix = Members.Affix, @MemberLastName = Members.LastName, @MemberBirthDate = Members.BirthDate, @MemberEmailAddress = Members.EmailAddress, @MemberTelephone = Members.Telephone, @MemberStreet = Members.Street, @MemberNumber = Members.Number, @MemberNumberSuffix = Members.NumberSuffix, @MemberZipCode = Members.ZipCode, @MemberPlace = Members.Place, @MemberAddressNote = Members.AddressNote
FROM Members
WHERE
(@MemberID = Members.ID)
GO

CREATE OR ALTER PROCEDURE GetAllMember
@MemberID int OUTPUT, @MemberFirstName varchar(255) OUTPUT, @MemberAffix varchar(255) OUTPUT, @MemberLastName varchar(255) OUTPUT, @MemberBirthDate date OUTPUT, @MemberEmailAddress varchar(255) OUTPUT, @MemberTelephone varchar(255) OUTPUT, @MemberStreet varchar(255) OUTPUT, @MemberNumber int OUTPUT, @MemberNumberSuffix varchar(255) OUTPUT, @MemberZipCode char OUTPUT, @MemberPlace varchar(255) OUTPUT, @MemberAddressNote varchar(1023) OUTPUT
AS
SELECT
@MemberID = Members.ID, @MemberFirstName = Members.FirstName, @MemberAffix = Members.Affix, @MemberLastName = Members.LastName, @MemberBirthDate = Members.BirthDate, @MemberEmailAddress = Members.EmailAddress, @MemberTelephone = Members.Telephone, @MemberStreet = Members.Street, @MemberNumber = Members.Number, @MemberNumberSuffix = Members.NumberSuffix, @MemberZipCode = Members.ZipCode, @MemberPlace = Members.Place, @MemberAddressNote = Members.AddressNote
FROM Members
GO

CREATE OR ALTER PROCEDURE UpdateMember
@MemberFirstName varchar(255), @MemberAffix varchar(255), @MemberLastName varchar(255), @MemberBirthDate date, @MemberEmailAddress varchar(255), @MemberTelephone varchar(255), @MemberStreet varchar(255), @MemberNumber int, @MemberNumberSuffix varchar(255), @MemberZipCode char, @MemberPlace varchar(255), @MemberAddressNote varchar(1023), @MemberID int
AS
UPDATE Members SET
FirstName = @MemberFirstName, Affix = @MemberAffix, LastName = @MemberLastName, BirthDate = @MemberBirthDate, EmailAddress = @MemberEmailAddress, Telephone = @MemberTelephone, Street = @MemberStreet, Number = @MemberNumber, NumberSuffix = @MemberNumberSuffix, ZipCode = @MemberZipCode, Place = @MemberPlace, AddressNote = @MemberAddressNote
WHERE ID = @MemberID
GO

CREATE OR ALTER PROCEDURE DeleteMember
@MemberID int
AS
DELETE
FROM Members
WHERE
@MemberID = ID
GO


CREATE OR ALTER PROCEDURE CreateMembership
@MembershipMemberID int, @MembershipStartDate date, @MembershipEndDate date, @MembershipID int OUTPUT
AS
INSERT INTO Memberships ( MemberID, StartDate, EndDate )
VALUES ( @MembershipMemberID, @MembershipStartDate, @MembershipEndDate)
SET @MembershipID = SCOPE_IDENTITY()
RETURN  @MembershipID
GO

CREATE OR ALTER PROCEDURE GetMembership
@MembershipID int, @MembershipMemberID int OUTPUT, @MembershipStartDate date OUTPUT, @MembershipEndDate date OUTPUT
AS
SELECT TOP 1
@MembershipMemberID = Memberships.MemberID, @MembershipStartDate = Memberships.StartDate, @MembershipEndDate = Memberships.EndDate
FROM Memberships
WHERE
(@MembershipID = Memberships.ID)
GO

CREATE OR ALTER PROCEDURE GetAllMembership
@MembershipID int OUTPUT, @MembershipMemberID int OUTPUT, @MembershipStartDate date OUTPUT, @MembershipEndDate date OUTPUT
AS
SELECT
@MembershipID = Memberships.ID, @MembershipMemberID = Memberships.MemberID, @MembershipStartDate = Memberships.StartDate, @MembershipEndDate = Memberships.EndDate
FROM Memberships
GO

CREATE OR ALTER PROCEDURE UpdateMembership
@MembershipMemberID int, @MembershipStartDate date, @MembershipEndDate date, @MembershipID int
AS
UPDATE Memberships SET
MemberID = @MembershipMemberID, StartDate = @MembershipStartDate, EndDate = @MembershipEndDate
WHERE ID = @MembershipID
GO

CREATE OR ALTER PROCEDURE DeleteMembership
@MembershipID int
AS
DELETE
FROM Memberships
WHERE
@MembershipID = ID
GO


CREATE OR ALTER PROCEDURE CreatePublisher
@PublisherName varchar(255), @PublisherLocation varchar(255), @PublisherID int OUTPUT
AS
INSERT INTO Publishers ( Name, Location )
VALUES ( @PublisherName, @PublisherLocation)
SET @PublisherID = SCOPE_IDENTITY()
RETURN  @PublisherID
GO

CREATE OR ALTER PROCEDURE GetPublisher
@PublisherID int, @PublisherName varchar(255) OUTPUT, @PublisherLocation varchar(255) OUTPUT
AS
SELECT TOP 1
@PublisherName = Publishers.Name, @PublisherLocation = Publishers.Location
FROM Publishers
WHERE
(@PublisherID = Publishers.ID)
GO

CREATE OR ALTER PROCEDURE GetAllPublisher
@PublisherID int OUTPUT, @PublisherName varchar(255) OUTPUT, @PublisherLocation varchar(255) OUTPUT
AS
SELECT
@PublisherID = Publishers.ID, @PublisherName = Publishers.Name, @PublisherLocation = Publishers.Location
FROM Publishers
GO

CREATE OR ALTER PROCEDURE UpdatePublisher
@PublisherName varchar(255), @PublisherLocation varchar(255), @PublisherID int
AS
UPDATE Publishers SET
Name = @PublisherName, Location = @PublisherLocation
WHERE ID = @PublisherID
GO

CREATE OR ALTER PROCEDURE DeletePublisher
@PublisherID int
AS
DELETE
FROM Publishers
WHERE
@PublisherID = ID
GO


CREATE OR ALTER PROCEDURE CreateReservation
@ReservationBookID int, @ReservationLibraryID int, @ReservationMemberID int, @ReservationStartDate date, @ReservationReturnDate date, @ReservationID int OUTPUT
AS
INSERT INTO Reservations ( BookID, LibraryID, MemberID, StartDate, ReturnDate )
VALUES ( @ReservationBookID, @ReservationLibraryID, @ReservationMemberID, @ReservationStartDate, @ReservationReturnDate)
SET @ReservationID = SCOPE_IDENTITY()
RETURN  @ReservationID
GO

CREATE OR ALTER PROCEDURE GetReservation
@ReservationID int, @ReservationBookID int OUTPUT, @ReservationLibraryID int OUTPUT, @ReservationMemberID int OUTPUT, @ReservationStartDate date OUTPUT, @ReservationReturnDate date OUTPUT
AS
SELECT TOP 1
@ReservationBookID = Reservations.BookID, @ReservationLibraryID = Reservations.LibraryID, @ReservationMemberID = Reservations.MemberID, @ReservationStartDate = Reservations.StartDate, @ReservationReturnDate = Reservations.ReturnDate
FROM Reservations
WHERE
(@ReservationID = Reservations.ID)
GO

CREATE OR ALTER PROCEDURE GetAllReservation
@ReservationID int OUTPUT, @ReservationBookID int OUTPUT, @ReservationLibraryID int OUTPUT, @ReservationMemberID int OUTPUT, @ReservationStartDate date OUTPUT, @ReservationReturnDate date OUTPUT
AS
SELECT
@ReservationID = Reservations.ID, @ReservationBookID = Reservations.BookID, @ReservationLibraryID = Reservations.LibraryID, @ReservationMemberID = Reservations.MemberID, @ReservationStartDate = Reservations.StartDate, @ReservationReturnDate = Reservations.ReturnDate
FROM Reservations
GO

CREATE OR ALTER PROCEDURE UpdateReservation
@ReservationBookID int, @ReservationLibraryID int, @ReservationMemberID int, @ReservationStartDate date, @ReservationReturnDate date, @ReservationID int
AS
UPDATE Reservations SET
BookID = @ReservationBookID, LibraryID = @ReservationLibraryID, MemberID = @ReservationMemberID, StartDate = @ReservationStartDate, ReturnDate = @ReservationReturnDate
WHERE ID = @ReservationID
GO

CREATE OR ALTER PROCEDURE DeleteReservation
@ReservationID int
AS
DELETE
FROM Reservations
WHERE
@ReservationID = ID
GO


