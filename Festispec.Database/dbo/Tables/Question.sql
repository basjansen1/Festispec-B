CREATE TABLE [dbo].[Question] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX) NOT NULL,
    [Description]       NVARCHAR (MAX) NULL,
    [QuestionType_Type] NVARCHAR (64)  NOT NULL,
    [Metadata]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QuestionTypeQuestion] FOREIGN KEY ([QuestionType_Type]) REFERENCES [dbo].[QuestionType] ([Type])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionTypeQuestion]
    ON [dbo].[Question]([QuestionType_Type] ASC);

