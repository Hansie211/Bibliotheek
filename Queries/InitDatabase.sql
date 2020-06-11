CREATE TABLE [Members] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [FirstName] varchar(255) NOT NULL,
  [Affix] varchar(255) NOT NULL,
  [LastName] varchar(255) NOT NULL,
  [BirthDate] date NOT NULL,
  [EmailAddress] varchar(255) NOT NULL,
  [Telephone] varchar(255) NOT NULL,
  [Street] varchar(255) NOT NULL,
  [Number] int NOT NULL,
  [NumberSuffix] varchar(255) NOT NULL,
  [ZipCode] char(6) NOT NULL,
  [Place] varchar(255) NOT NULL,
  [AddressNote] varchar(1023) NOT NULL,
)
GO

CREATE TABLE [Memberships] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [MemberID] int NOT NULL,
  [StartDate] date NOT NULL,
  [EndDate] date NOT NULL,
)
GO

CREATE TABLE [Editions] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [LanguageID] int NOT NULL,
  [Title] varchar(255) NOT NULL,
  [ISBN] varchar(255) NOT NULL,
  [PublishDate] date NOT NULL,
)
GO

CREATE TABLE [Authors] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [FirstName] varchar(255) NOT NULL,
  [Affix] varchar(255) NOT NULL,
  [LastName] varchar(255) NOT NULL,
)
GO

CREATE TABLE [Publishers] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Name] varchar(255) NOT NULL,
  [Location] varchar(255) NOT NULL,
)
GO

CREATE TABLE [Genres] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Name] varchar(255) NOT NULL,
)
GO

CREATE TABLE [EditionAuthors] (
  [EditionD] int NOT NULL,
  [AuthorID] int NOT NULL,
)
GO

CREATE TABLE [EditionGenres] (
  [EditionID] int NOT NULL,
  [GenreID] int NOT NULL,
)
GO

CREATE TABLE [EditionPublishers] (
  [EditionID] int NOT NULL,
  [PublisherID] int NOT NULL,
)
GO

CREATE TABLE [Books] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [EditionID] int NOT NULL,
  [State] varchar(255) NOT NULL,
  [DateAdded] date NOT NULL,
  [InInventory] bit NOT NULL,
)
GO

CREATE TABLE [Languages] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Name] varchar(255) NOT NULL,
)
GO

CREATE TABLE [Libraries] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [EmailAddress] varchar(255) NOT NULL,
  [Telephone] varchar(255) NOT NULL,
  [Street] varchar(255) NOT NULL,
  [Number] int NOT NULL,
  [NumberSuffix] varchar(255) NOT NULL,
  [ZipCode] char(6) NOT NULL,
  [Place] varchar(255) NOT NULL,
  [AddressNote] varchar(1023) NOT NULL,
)
GO

CREATE TABLE [LibraryBooks] (
  [BookID] int NOT NULL,
  [LibraryID] int NOT NULL,
)
GO

CREATE TABLE [Employees] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [LibraryID] int NOT NULL,
  [FirstName] varchar(255) NOT NULL,
  [Affix] varchar(255) NOT NULL,
  [LastName] varchar(255) NOT NULL,
  [BirthDate] date NOT NULL,
  [Street] varchar(255) NOT NULL,
  [Number] int NOT NULL,
  [NumberSuffix] varchar(255) NOT NULL,
  [ZipCode] char(6) NOT NULL,
  [Place] varchar(255) NOT NULL,
  [AddressNote] varchar(1023) NOT NULL,
  [PasswordHash] varchar(255) NOT NULL,
  [PasswordSalt] varchar(48) NOT NULL,
)
GO

CREATE TABLE [Fines] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [BookID] int NOT NULL,
  [MemberID] int NOT NULL,
  [Price] decimal NOT NULL,
)
GO

CREATE TABLE [Reservations] (
  [ID] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [BookID] int NOT NULL,
  [MemberID] int NOT NULL,
  [LibraryID] int NOT NULL,
  [StartDate] date NOT NULL,
  [ReturnDate] date NOT NULL,
)
GO


ALTER TABLE [Memberships] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Editions] ADD FOREIGN KEY ([LanguageID]) REFERENCES [Languages] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [EditionAuthors] ADD FOREIGN KEY ([EditionD]) REFERENCES [Editions] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [EditionAuthors] ADD FOREIGN KEY ([AuthorID]) REFERENCES [Authors] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [EditionGenres] ADD FOREIGN KEY ([EditionID]) REFERENCES [Editions] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [EditionGenres] ADD FOREIGN KEY ([GenreID]) REFERENCES [Genres] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [EditionPublishers] ADD FOREIGN KEY ([EditionID]) REFERENCES [Editions] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [EditionPublishers] ADD FOREIGN KEY ([PublisherID]) REFERENCES [Publishers] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Books] ADD FOREIGN KEY ([EditionID]) REFERENCES [Editions] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [LibraryBooks] ADD FOREIGN KEY ([BookID]) REFERENCES [Books] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [LibraryBooks] ADD FOREIGN KEY ([LibraryID]) REFERENCES [Libraries] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Employees] ADD FOREIGN KEY ([LibraryID]) REFERENCES [Libraries] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Fines] ADD FOREIGN KEY ([BookID]) REFERENCES [Books] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Fines] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Reservations] ADD FOREIGN KEY ([BookID]) REFERENCES [Books] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Reservations] ADD FOREIGN KEY ([MemberID]) REFERENCES [Members] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [Reservations] ADD FOREIGN KEY ([LibraryID]) REFERENCES [Libraries] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO