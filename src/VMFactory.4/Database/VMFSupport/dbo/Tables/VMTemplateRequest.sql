CREATE TABLE [dbo].[VMTemplateRequest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserEmailAddress] NVARCHAR(200) NULL, 
    [UserName] NVARCHAR(128) NULL, 
    [RequestDetail] NVARCHAR(MAX) NULL
)
