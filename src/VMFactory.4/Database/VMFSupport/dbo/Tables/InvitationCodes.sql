CREATE TABLE [dbo].[InvitationCodes]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Code] NVARCHAR(50) NOT NULL, 
    [UsedBy] NVARCHAR(50) NULL DEFAULT null, 
    PRIMARY KEY NONCLUSTERED ([Id])
)

GO

CREATE CLUSTERED INDEX [IX_InvitationCodes_Column] ON [dbo].[InvitationCodes] ([Code], [UsedBy], Id)
