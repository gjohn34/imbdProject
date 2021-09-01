CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DirectorId] INT NOT NULL,
    [Title] NVARCHAR(50) NOT NULL, 
    [ReleaseYear] INT NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [UpdatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [FK_Movies_ToDirectors] FOREIGN KEY ([DirectorId]) REFERENCES [Directors]([Id])
)
