CREATE TABLE [dbo].[Template] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED ([Id] ASC)
);

