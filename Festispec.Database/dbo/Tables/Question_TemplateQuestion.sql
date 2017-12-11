﻿CREATE TABLE [dbo].[Question_TemplateQuestion] (
    [Template_Id] INT NOT NULL,
    [Id]          INT NOT NULL,
    CONSTRAINT [PK_Question_TemplateQuestion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TemplateQuestion_inherits_Question] FOREIGN KEY ([Id]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TemplateTemplateQuestion] FOREIGN KEY ([Template_Id]) REFERENCES [dbo].[Template] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_TemplateTemplateQuestion]
    ON [dbo].[Question_TemplateQuestion]([Template_Id] ASC);

