CREATE TABLE [dbo].[TemplateQuestion] (
    [Template_Id] INT NOT NULL,
    [Question_Id] INT NOT NULL,
    CONSTRAINT [PK_TemplateQuestion] PRIMARY KEY CLUSTERED ([Template_Id] ASC, [Question_Id] ASC),
    CONSTRAINT [FK_QuestionTemplateQuestion] FOREIGN KEY ([Question_Id]) REFERENCES [dbo].[Question] ([Id]),
    CONSTRAINT [FK_TemplateTemplateQuestion] FOREIGN KEY ([Template_Id]) REFERENCES [dbo].[Template] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionTemplateQuestion]
    ON [dbo].[TemplateQuestion]([Question_Id] ASC);

