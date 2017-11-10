CREATE TABLE [dbo].[Address] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Street]       NVARCHAR (MAX) NOT NULL,
    [HouseNumber]  NVARCHAR (MAX) NOT NULL,
    [PostalCode]   NVARCHAR (6)   NOT NULL,
    [City]         NVARCHAR (MAX) NOT NULL,
    [Country]      NVARCHAR (MAX) NOT NULL,
    [Municipality] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);

