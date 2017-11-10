CREATE TABLE [dbo].[Note] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Content]     NVARCHAR (MAX) NOT NULL,
    [Customer_Id] INT            NOT NULL,
    CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerNote] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Address_Customer] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_CustomerNote]
    ON [dbo].[Note]([Customer_Id] ASC);

