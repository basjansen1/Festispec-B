CREATE TABLE [dbo].[Schedule] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [NotAvailableFrom] DATETIME NOT NULL,
    [NotAvailableTo]   DATETIME NOT NULL,
    [Inspector_Id]     INT      NOT NULL,
    CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InspectorSchedule] FOREIGN KEY ([Inspector_Id]) REFERENCES [dbo].[Address_Inspector] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_InspectorSchedule]
    ON [dbo].[Schedule]([Inspector_Id] ASC);

