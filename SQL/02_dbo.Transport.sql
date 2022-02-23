IF OBJECT_ID('[dbo].[Transport]') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Transport]
	PRINT '<<DROP TABLE [dbo].[Transport] SUCCESSFUL!!>>'
END
GO
CREATE TABLE [dbo].[Transport] (
	[IdTransport]		INT				NOT NULL,
	[FlightCarrier]		[nvarchar](3)	NOT NULL,
	[FlightNumber]		[nvarchar](3)	NOT NULL,
	[IdFlight]			[INT]			NOT NULL
)
GO
IF OBJECT_ID('[dbo].[Transport]') IS NOT NULL
BEGIN
	PRINT '<<CREATE TABLE [dbo].[Transport] SUCCESSFUL!!>>'
END
GO
IF OBJECT_ID('[dbo].[Transport]') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[Transport] ADD CONSTRAINT PK_TRANSPORT PRIMARY KEY (IdTransport)
END
GO
