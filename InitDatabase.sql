CREATE TABLE [Members] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [FirstName] varchar(255),
  [Affix] varchar(255),
  [LastName] varchar(255),
  [BirthDate] date,
  [EmailAddress] varchar(255),
  [Telephone] varchar(255),
  [Street] varchar(255),
  [Number] int,
  [NumberSuffix] varchar(255),
  [ZipCode] char(6),
  [Place] varchar(255),
  [AddressNote] varchar(1023)
)
GO

CREATE TABLE [Memberships] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [MemberID] int,
  [StartDate] date,
  [EndDate] date
)
GO

CREATE TABLE [Editions] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [LanguageID] int,
  [Title] varchar(255),
  [ISBN] varchar(255),
  [PublishDate] date
)
GO

CREATE TABLE [Authors] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [FirstName] varchar(255),
  [Affix] varchar(255),
  [LastName] varchar(255)
)
GO

CREATE TABLE [Publishers] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255),
  [Location] varchar(255)
)
GO

CREATE TABLE [Genres] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255)
)
GO

CREATE TABLE [EditionAuthors] (
  [EditionD] int,
  [AuthorID] int
)
GO

CREATE TABLE [EditionGenres] (
  [EditionID] int,
  [GenreID] int
)
GO

CREATE TABLE [EditionPublishers] (
  [EditionID] int,
  [PublisherID] int
)
GO

CREATE TABLE [Books] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [EditionID] int,
  [State] varchar(255),
  [DateAdded] date,
  [InInventory] bit
)
GO

CREATE TABLE [Languages] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255)
)
GO

CREATE TABLE [Libraries] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [EmailAddress] varchar(255),
  [Telephone] varchar(255),
  [Street] varchar(255),
  [Number] int,
  [NumberSuffix] varchar(255),
  [ZipCode] char(6),
  [Place] varchar(255),
  [AddressNote] varchar(1023)
)
GO

CREATE TABLE [LibraryBooks] (
  [BookID] int,
  [LibraryID] int
)
GO

CREATE TABLE [Employees] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [LibraryID] int,
  [FirstName] varchar(255),
  [Affix] varchar(255),
  [LastName] varchar(255),
  [BirthDate] date,
  [Street] varchar(255),
  [Number] int,
  [NumberSuffix] varchar(255),
  [ZipCode] char(6),
  [Place] varchar(255),
  [AddressNote] varchar(1023),
  [PasswordHash] varchar(255),
  [PasswordSalt] varchar(48)
)
GO

CREATE TABLE [Fines] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [BookID] int,
  [MemberID] int,
  [Price] decimal
)
GO

CREATE TABLE [Reservations] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [BookID] int,
  [MemberID] int,
  [LibraryID] int,
  [StartDate] date,
  [ReturnDate] date
)
GO


ALTER TABLE [Memberships] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([ID])
GO

ALTER TABLE [Editions] ADD FOREIGN KEY ([LanguageID]) REFERENCES [Languages] ([ID])
GO

ALTER TABLE [EditionAuthors] ADD FOREIGN KEY ([EditionD]) REFERENCES [Editions] ([ID])
GO

ALTER TABLE [EditionAuthors] ADD FOREIGN KEY ([AuthorID]) REFERENCES [Authors] ([ID])
GO

ALTER TABLE [EditionGenres] ADD FOREIGN KEY ([EditionID]) REFERENCES [Editions] ([ID])
GO

ALTER TABLE [EditionGenres] ADD FOREIGN KEY ([GenreID]) REFERENCES [Genres] ([ID])
GO

ALTER TABLE [EditionPublishers] ADD FOREIGN KEY ([EditionID]) REFERENCES [Editions] ([ID])
GO

ALTER TABLE [EditionPublishers] ADD FOREIGN KEY ([PublisherID]) REFERENCES [Publishers] ([ID])
GO

ALTER TABLE [Books] ADD FOREIGN KEY ([EditionID]) REFERENCES [Editions] ([ID])
GO

ALTER TABLE [LibraryBooks] ADD FOREIGN KEY ([BookID]) REFERENCES [Books] ([ID])
GO

ALTER TABLE [LibraryBooks] ADD FOREIGN KEY ([LibraryID]) REFERENCES [Libraries] ([ID])
GO

ALTER TABLE [Employees] ADD FOREIGN KEY ([LibraryID]) REFERENCES [Libraries] ([ID])
GO

ALTER TABLE [Fines] ADD FOREIGN KEY ([BookID]) REFERENCES [Books] ([ID])
GO

ALTER TABLE [Fines] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([ID])
GO

ALTER TABLE [Reservations] ADD FOREIGN KEY ([BookID]) REFERENCES [Books] ([ID])
GO

ALTER TABLE [Reservations] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([ID])
GO

ALTER TABLE [Reservations] ADD FOREIGN KEY ([LibraryID]) REFERENCES [Libraries] ([ID])
GO