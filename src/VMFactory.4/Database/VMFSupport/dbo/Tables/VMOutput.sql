CREATE TABLE [dbo].[VMOutput]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[VMTemplateId] INT NOT NULL,
	[VMRequestId] BIGINT NOT NULL,
    [FileName] NVARCHAR(128) NULL, 
    [DownloadUrl] NVARCHAR(512) NULL, 
    [Log] NVARCHAR(MAX) NULL,
    [CreatedOn] DATETIME NULL, 
    [LastModified] DATETIME NULL, 
    CONSTRAINT [FK_VMOutput_ToTable] FOREIGN KEY ([VMTemplateId]) REFERENCES [VMTemplate]([Id]), 
    CONSTRAINT [FK_VMOutput_ToTable_1] FOREIGN KEY ([VMRequestId]) REFERENCES [VMRequest]([Id])
)
