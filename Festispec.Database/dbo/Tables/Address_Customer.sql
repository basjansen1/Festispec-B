CREATE TABLE [dbo].[Address_Customer] (
    [KVK] NVARCHAR (MAX) NOT NULL,
    [Id]  INT            NOT NULL,
    CONSTRAINT [PK_Address_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_inherits_Contact] FOREIGN KEY ([Id]) REFERENCES [dbo].[Address_Contact] ([Id]) ON DELETE CASCADE
);

