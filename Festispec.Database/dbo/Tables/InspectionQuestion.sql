CREATE TABLE [dbo].[InspectionQuestion] (
    [Inspection_Id] INT NOT NULL,
    [Question_Id]   INT NOT NULL,
    CONSTRAINT [PK_InspectionQuestion] PRIMARY KEY CLUSTERED ([Inspection_Id] ASC, [Question_Id] ASC),
    CONSTRAINT [FK_InspectionInspectionQuestion] FOREIGN KEY ([Inspection_Id]) REFERENCES [dbo].[Address_Inspection] ([Id]),
    CONSTRAINT [FK_QuestionInspectionQuestion] FOREIGN KEY ([Question_Id]) REFERENCES [dbo].[Question] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_QuestionInspectionQuestion]
    ON [dbo].[InspectionQuestion]([Question_Id] ASC);

