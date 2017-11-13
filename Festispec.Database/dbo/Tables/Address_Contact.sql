CREATE TABLE [dbo].[Address_Contact] (
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Email]     NVARCHAR (MAX) NULL,
    [Telephone] NVARCHAR (MAX) NULL,
    [IBAN]      NVARCHAR (MAX) NULL,
    [Id]        INT            NOT NULL,
    CONSTRAINT [PK_Address_Contact] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contact_inherits_Address] FOREIGN KEY ([Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE
);

