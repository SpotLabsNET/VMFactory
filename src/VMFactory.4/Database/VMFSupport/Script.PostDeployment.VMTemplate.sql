/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
			   SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

UPDATE
	[dbo].[VMTemplate]
SET
	[UniqueName] = 'Ranger base VM',
	[DisplayName] = 'Ranger base VM',
	[CreatedOn] = '2013-01-01',
	[LastModified] = '2013-01-01'
WHERE
	[Id] = 1

IF @@ROWCOUNT <> 1
BEGIN

	SET IDENTITY_INSERT [dbo].[VMTemplate] ON

	INSERT
	INTO
		[dbo].[VMTemplate]
		([Id], [UniqueName], [DisplayName], [CreatedOn], [LastModified])
	VALUES
		(1, 'Ranger base VM', 'Ranger base VM', '2013-01-01', '2013-01-01')

	SET IDENTITY_INSERT [dbo].[VMTemplate] OFF

END


UPDATE
	[dbo].[VMTemplate]
SET
	[UniqueName] = 'Ranger base VM (2)',
	[DisplayName] = 'Ranger base VM (2)',
	[CreatedOn] = '2013-01-01',
	[LastModified] = '2013-01-01'
WHERE
	[Id] = 2

IF @@ROWCOUNT <> 1
BEGIN

	SET IDENTITY_INSERT [dbo].[VMTemplate] ON

	INSERT
	INTO
		[dbo].[VMTemplate]
		([Id], [UniqueName], [DisplayName], [CreatedOn], [LastModified])
	VALUES
		(2, 'Ranger base VM (2)', 'Ranger base VM (2)', '2013-01-01', '2013-01-01')

	SET IDENTITY_INSERT [dbo].[VMTemplate] OFF

END