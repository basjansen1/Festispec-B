CREATE TABLE [dbo].[Planning] (
    [Inspection_Id] INT      NOT NULL,
    [Inspector_Id]  INT      NOT NULL,
    [Date]          DATETIME NOT NULL,
    [TimeFrom]      TIME (7) NOT NULL,
    [TimeTo]        TIME (7) NOT NULL,
    [Hours]         TIME (7) NULL,
    CONSTRAINT [PK_Planning] PRIMARY KEY CLUSTERED ([Inspection_Id] ASC, [Inspector_Id] ASC, [Date] ASC),
    CONSTRAINT [FK_InspectionPlanning] FOREIGN KEY ([Inspection_Id]) REFERENCES [dbo].[Address_Inspection] ([Id]),
    CONSTRAINT [FK_InspectorPlanning] FOREIGN KEY ([Inspector_Id]) REFERENCES [dbo].[Address_Inspector] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_InspectorPlanning]
    ON [dbo].[Planning]([Inspector_Id] ASC);

