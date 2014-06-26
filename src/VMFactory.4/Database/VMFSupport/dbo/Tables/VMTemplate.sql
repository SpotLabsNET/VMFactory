CREATE TABLE [dbo].[VMTemplate]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UniqueName] NVARCHAR(50) NOT NULL unique,
	[DisplayName] NVARCHAR(128) NOT NULL, 
    [MdtBaseConfig] XML NULL, 
    [CreatedOn] DATETIME NULL, 
    [LastModified] DATETIME NULL
)
