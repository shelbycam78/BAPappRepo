CREATE TABLE [dbo].[Venue] (
    [VenueId]       INT              IDENTITY (1, 1) NOT NULL DEFAULT 1,
    [OwnerId]       UNIQUEIDENTIFIER NOT NULL,
    [VenueName]     NVARCHAR (MAX)   NOT NULL,
    [VenueLocation] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_dbo.Venue] PRIMARY KEY CLUSTERED ([VenueId] ASC)
);

