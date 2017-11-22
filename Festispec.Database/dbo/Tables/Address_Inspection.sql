CREATE TABLE [dbo].[Address_Inspection] (
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Website]       NVARCHAR (MAX) NULL,
    [Start]         DATETIME       NOT NULL,
    [End]           DATETIME       NOT NULL,
    [Id]            INT            NOT NULL,
    [Status_Status] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Address_Inspection] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Inspection_inherits_Address] FOREIGN KEY ([Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InspectionStatusInspection] FOREIGN KEY ([Status_Status]) REFERENCES [dbo].[InspectionStatus] ([Status])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_InspectionStatusInspection]
    ON [dbo].[Address_Inspection]([Status_Status] ASC);

