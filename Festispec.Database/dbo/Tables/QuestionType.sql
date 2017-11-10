CREATE TABLE [dbo].[QuestionType] (
    [Type]     NVARCHAR (64)  NOT NULL,
    [Metadata] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_QuestionType] PRIMARY KEY CLUSTERED ([Type] ASC)
);

