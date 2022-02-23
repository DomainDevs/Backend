IF OBJECT_ID('[dbo].[Jorney]') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Jorney]
	PRINT '<<DROP TABLE [dbo].[Jorney] SUCCESSFUL!!>>'
END
GO
CREATE TABLE [dbo].[Jorney] (
	[IdJorney]		[INT]			NOT NULL,
	[Origin]		[nvarchar](3)	NOT NULL,
	[Destination]	[nvarchar](3)	NOT NULL,
	[Price]			[DECIMAL](19,4)	DEFAULT 0,
	[DateProc]		[DATETIME]		NULL
)
GO
IF OBJECT_ID('[dbo].[Jorney]') IS NOT NULL
BEGIN
	PRINT '<<CREATE TABLE [dbo].[Jorney] SUCCESSFUL!!>>'
END
GO
IF OBJECT_ID('[dbo].[Jorney]') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[Jorney] ADD CONSTRAINT PK_JORNEY PRIMARY KEY (IdJorney)
END
GO