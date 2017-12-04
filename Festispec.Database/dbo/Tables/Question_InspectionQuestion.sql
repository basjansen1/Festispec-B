CREATE TABLE [dbo].[Question_InspectionQuestion] (
    [Answer]                 NVARCHAR (MAX) NULL,
    [Planning_Inspection_Id] INT            NOT NULL,
    [Planning_Inspector_Id]  INT            NOT NULL,
    [Planning_Date]          DATETIME       NOT NULL,
    [Id]                     INT            NOT NULL,
    CONSTRAINT [PK_Question_InspectionQuestion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InspectionQuestion_inherits_Question] FOREIGN KEY ([Id]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PlanningInspectionQuestion] FOREIGN KEY ([Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date]) REFERENCES [dbo].[Planning] ([Inspection_Id], [Inspector_Id], [Date])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_PlanningInspectionQuestion]
    ON [dbo].[Question_InspectionQuestion]([Planning_Inspection_Id] ASC, [Planning_Inspector_Id] ASC, [Planning_Date] ASC);

