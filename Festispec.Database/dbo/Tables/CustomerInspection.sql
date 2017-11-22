CREATE TABLE [dbo].[CustomerInspection] (
    [Customers_Id]   INT NOT NULL,
    [Inspections_Id] INT NOT NULL,
    CONSTRAINT [PK_CustomerInspection] PRIMARY KEY CLUSTERED ([Customers_Id] ASC, [Inspections_Id] ASC),
    CONSTRAINT [FK_CustomerInspection_Customer] FOREIGN KEY ([Customers_Id]) REFERENCES [dbo].[Address_Customer] ([Id]),
    CONSTRAINT [FK_CustomerInspection_Inspection] FOREIGN KEY ([Inspections_Id]) REFERENCES [dbo].[Address_Inspection] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_CustomerInspection_Inspection]
    ON [dbo].[CustomerInspection]([Inspections_Id] ASC);

