CREATE TABLE [dbo].[VMRequestHistory] (
    [Id]                       BIGINT         NOT NULL,
    [DisplayName]              NVARCHAR (128) NULL,
    [MachineName]              VARCHAR (20)   NULL,
    [MDTConfigurationSettings] XML            NULL,
    [TargetConfiguration]      XML            NULL,
    [RequestStatus]            INT            NULL,
    [LastUpdated]              DATETIME       NULL,
    [ProcessLog]               NVARCHAR (MAX) NULL,
    [CreatedOn]                DATETIME       NULL,
    [CreatedBy]                NCHAR (256)    NULL,
    [TemplateId]               INT            NULL,
    CONSTRAINT [FK_VMRequestHistory_RequestStatus] FOREIGN KEY ([RequestStatus]) REFERENCES [dbo].[RequestStatus] ([Id]),
    CONSTRAINT [FK_VMRequestHistory_VMTemplate] FOREIGN KEY ([TemplateId]) REFERENCES [dbo].[VMTemplate] ([Id])
);

