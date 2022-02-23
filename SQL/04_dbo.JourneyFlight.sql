IF OBJECT_ID('[dbo].[JourneyFlight]') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[JourneyFlight]
	PRINT '<<DROP TABLE [dbo].[JourneyFlight] SUCCESSFUL!!>>'
END
GO
CREATE TABLE [dbo].[JourneyFlight] (
	[IdJourneyFlight]	[INT]			NOT NULL,
	[IdJorney]			[INT]			NOT NULL,
	[IdFlight]			[INT]				NOT NULL
)
GO
IF OBJECT_ID('[dbo].[JourneyFlight]') IS NOT NULL
BEGIN
	PRINT '<<CREATE TABLE [dbo].[JourneyFlight] SUCCESSFUL!!>>'
END
GO
IF OBJECT_ID('[dbo].[JourneyFlight]') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[JourneyFlight] ADD CONSTRAINT PK_JOURNEYFLIGHT PRIMARY KEY (IdJourneyFlight)
END
GO