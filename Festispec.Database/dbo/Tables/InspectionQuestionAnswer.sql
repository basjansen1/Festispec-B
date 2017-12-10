CREATE TABLE [dbo].[InspectionQuestionAnswer] (
    [Inspection_Id] INT            NOT NULL,
    [Inspector_Id]  INT            NOT NULL,
    [Date]          DATETIME       NOT NULL,
    [Question_Id]   INT            NOT NULL,
    [Answer]        NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_InspectionQuestionAnswer] PRIMARY KEY CLUSTERED ([Inspection_Id] ASC, [Inspector_Id] ASC, [Date] ASC, [Question_Id] ASC),
    CONSTRAINT [FK_InspectionQuestionInspectionQuestionAnswer] FOREIGN KEY ([Inspection_Id], [Question_Id]) REFERENCES [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]),
    CONSTRAINT [FK_PlanningInspectionQuestionAnswer] FOREIGN KEY ([Inspection_Id], [Inspector_Id], [Date]) REFERENCES [dbo].[Planning] ([Inspection_Id], [Inspector_Id], [Date])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_InspectionQuestionInspectionQuestionAnswer]
    ON [dbo].[InspectionQuestionAnswer]([Inspection_Id] ASC, [Question_Id] ASC);

