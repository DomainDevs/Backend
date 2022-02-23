IF OBJECT_ID('[dbo].[Flight]') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Flight]
	PRINT '<<DROP TABLE [dbo].[Flight] SUCCESSFUL!!>>'
END
GO
CREATE TABLE [dbo].[Flight] (
	[IdFlight]		[INT]				NOT NULL,
	[Origin]		[nvarchar](3)		NOT NULL,
	[Destination]	[nvarchar](3)		NOT NULL,
	[Price]			[DECIMAL](19,4)		DEFAULT 0,
	[DateProc]		[DATETIME]			NULL,
)
GO
IF OBJECT_ID('[dbo].[Flight]') IS NOT NULL
BEGIN
	PRINT '<<CREATE TABLE [dbo].[Flight] SUCCESSFUL!!>>'
END
GO
IF OBJECT_ID('[dbo].[Flight]') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[Flight] ADD CONSTRAINT PK_FLIGHT PRIMARY KEY (IdFlight)
END
GO