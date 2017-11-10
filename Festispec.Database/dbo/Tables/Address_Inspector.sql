﻿CREATE TABLE [dbo].[Address_Inspector] (
    [CertificationFrom] DATETIME NOT NULL,
    [CertificationTo]   DATETIME NOT NULL,
    [Id]                INT      NOT NULL,
    CONSTRAINT [PK_Address_Inspector] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Inspector_inherits_Employee] FOREIGN KEY ([Id]) REFERENCES [dbo].[Address_Employee] ([Id]) ON DELETE CASCADE
);

