CREATE TABLE [dbo].[Regulation] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Municipality] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Regulation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

