CREATE TABLE [dbo].[UserProfile] (
    [UserId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (100) NULL,
    [NameIdentifier] NVARCHAR(100) NULL, 
    [EMail] NVARCHAR(100) NULL, 
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

