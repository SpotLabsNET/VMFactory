CREATE TABLE [dbo].[VMRequest] (
    [Id]                       BIGINT         IDENTITY (1, 1) NOT NULL,
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
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VMRequest_RequestStatus] FOREIGN KEY ([RequestStatus]) REFERENCES [dbo].[RequestStatus] ([Id]),
    CONSTRAINT [FK_VMRequest_VMTemplate] FOREIGN KEY ([TemplateId]) REFERENCES [dbo].[VMTemplate] ([Id])
);



GO
CREATE TRIGGER [dbo].[VMRequest_Update_Trigger]
	ON [dbo].[VMRequest]
	FOR UPDATE
	AS
	BEGIN
		INSERT
		INTO
			[dbo].[VMRequestHistory]
		SELECT
			*
		FROM 
			deleted
	END