CREATE TABLE [dbo].[Event] (
    [EventId]    INT              IDENTITY (1, 1) NOT NULL DEFAULT 1,
    [OwnerId]    UNIQUEIDENTIFIER NOT NULL,
    [EventDate]  DATETIME         NOT NULL,
    [EventTitle] NVARCHAR (MAX)   NULL,
    [IsPaid]     BIT              NOT NULL,
    [VenueId] INT NOT NULL, 
    CONSTRAINT [PK_dbo.Event] PRIMARY KEY CLUSTERED ([EventId] ASC)
);

