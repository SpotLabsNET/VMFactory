CREATE TABLE [dbo].[RequestStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(128) NULL, 
    [StepSequence] INT NULL 
)

