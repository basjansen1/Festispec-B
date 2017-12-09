
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2017 15:23:25
-- Generated from EDMX file: C:\Workspace\Avans\Projects\42IN06SOb\Festispec\Festispec.Domain\Festispec.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Festispec];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeRoleEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Employee] DROP CONSTRAINT [FK_EmployeeRoleEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_InspectorSchedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Schedule] DROP CONSTRAINT [FK_InspectorSchedule];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Note] DROP CONSTRAINT [FK_CustomerNote];
GO
IF OBJECT_ID(N'[dbo].[FK_InspectionStatusInspection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Inspection] DROP CONSTRAINT [FK_InspectionStatusInspection];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerInspection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Inspection] DROP CONSTRAINT [FK_CustomerInspection];
GO
IF OBJECT_ID(N'[dbo].[FK_InspectionPlanning]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Planning] DROP CONSTRAINT [FK_InspectionPlanning];
GO
IF OBJECT_ID(N'[dbo].[FK_InspectorPlanning]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Planning] DROP CONSTRAINT [FK_InspectorPlanning];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Employee] DROP CONSTRAINT [FK_EmployeeManager];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionTypeQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_QuestionTypeQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_TemplateTemplateQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_TemplateQuestion] DROP CONSTRAINT [FK_TemplateTemplateQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanningInspectionQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_InspectionQuestion] DROP CONSTRAINT [FK_PlanningInspectionQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_Contact_inherits_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Contact] DROP CONSTRAINT [FK_Contact_inherits_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_inherits_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Employee] DROP CONSTRAINT [FK_Employee_inherits_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_Inspector_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Inspector] DROP CONSTRAINT [FK_Inspector_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Customer_inherits_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Customer] DROP CONSTRAINT [FK_Customer_inherits_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_Inspection_inherits_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address_Inspection] DROP CONSTRAINT [FK_Inspection_inherits_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_TemplateQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_TemplateQuestion] DROP CONSTRAINT [FK_TemplateQuestion_inherits_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_InspectionQuestion_inherits_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_InspectionQuestion] DROP CONSTRAINT [FK_InspectionQuestion_inherits_Question];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[EmployeeRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeRole];
GO
IF OBJECT_ID(N'[dbo].[Schedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schedule];
GO
IF OBJECT_ID(N'[dbo].[Note]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Note];
GO
IF OBJECT_ID(N'[dbo].[InspectionStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InspectionStatus];
GO
IF OBJECT_ID(N'[dbo].[Planning]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Planning];
GO
IF OBJECT_ID(N'[dbo].[Regulation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Regulation];
GO
IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[QuestionType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionType];
GO
IF OBJECT_ID(N'[dbo].[Template]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Template];
GO
IF OBJECT_ID(N'[dbo].[Address_Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address_Contact];
GO
IF OBJECT_ID(N'[dbo].[Address_Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address_Employee];
GO
IF OBJECT_ID(N'[dbo].[Address_Inspector]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address_Inspector];
GO
IF OBJECT_ID(N'[dbo].[Address_Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address_Customer];
GO
IF OBJECT_ID(N'[dbo].[Address_Inspection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address_Inspection];
GO
IF OBJECT_ID(N'[dbo].[Question_TemplateQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_TemplateQuestion];
GO
IF OBJECT_ID(N'[dbo].[Question_InspectionQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_InspectionQuestion];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [HouseNumber] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(6)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Municipality] nvarchar(max)  NOT NULL,
    [Location] geography  NOT NULL,
    [Long] float  NOT NULL,
    [Lat] float  NOT NULL
);
GO

-- Creating table 'EmployeeRole'
CREATE TABLE [dbo].[EmployeeRole] (
    [Role] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'Schedule'
CREATE TABLE [dbo].[Schedule] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NotAvailableFrom] datetime  NOT NULL,
    [NotAvailableTo] datetime  NOT NULL,
    [Inspector_Id] int  NOT NULL
);
GO

-- Creating table 'Note'
CREATE TABLE [dbo].[Note] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'InspectionStatus'
CREATE TABLE [dbo].[InspectionStatus] (
    [Status] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Planning'
CREATE TABLE [dbo].[Planning] (
    [Inspection_Id] int  NOT NULL,
    [Inspector_Id] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [TimeFrom] time  NOT NULL,
    [TimeTo] time  NOT NULL,
    [Hours] time  NULL
);
GO

-- Creating table 'Regulation'
CREATE TABLE [dbo].[Regulation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Municipality] nvarchar(max)  NULL
);
GO

-- Creating table 'Question'
CREATE TABLE [dbo].[Question] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [QuestionType_Type] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'QuestionType'
CREATE TABLE [dbo].[QuestionType] (
    [Type] nvarchar(64)  NOT NULL,
    [Metadata] nvarchar(max)  NULL
);
GO

-- Creating table 'Template'
CREATE TABLE [dbo].[Template] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Address_Contact'
CREATE TABLE [dbo].[Address_Contact] (
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [Telephone] nvarchar(max)  NULL,
    [IBAN] nvarchar(max)  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Address_Employee'
CREATE TABLE [dbo].[Address_Employee] (
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role_Role] nvarchar(64)  NOT NULL,
    [Manager_Id] int  NULL,
    [HiredFrom] datetime  NOT NULL,
    [HiredTo] datetime  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Address_Inspector'
CREATE TABLE [dbo].[Address_Inspector] (
    [CertificationFrom] datetime  NULL,
    [CertificationTo] datetime  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Address_Customer'
CREATE TABLE [dbo].[Address_Customer] (
    [KVK] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Address_Inspection'
CREATE TABLE [dbo].[Address_Inspection] (
    [Name] nvarchar(max)  NOT NULL,
    [Website] nvarchar(max)  NULL,
    [Start] datetime  NOT NULL,
    [End] datetime  NOT NULL,
    [Status_Status] nvarchar(128)  NOT NULL,
    [Customer_Id] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Question_TemplateQuestion'
CREATE TABLE [dbo].[Question_TemplateQuestion] (
    [Template_Id] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Question_InspectionQuestion'
CREATE TABLE [dbo].[Question_InspectionQuestion] (
    [Answer] nvarchar(max)  NULL,
    [Planning_Inspection_Id] int  NOT NULL,
    [Planning_Inspector_Id] int  NOT NULL,
    [Planning_Date] datetime  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Role] in table 'EmployeeRole'
ALTER TABLE [dbo].[EmployeeRole]
ADD CONSTRAINT [PK_EmployeeRole]
    PRIMARY KEY CLUSTERED ([Role] ASC);
GO

-- Creating primary key on [Id] in table 'Schedule'
ALTER TABLE [dbo].[Schedule]
ADD CONSTRAINT [PK_Schedule]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Note'
ALTER TABLE [dbo].[Note]
ADD CONSTRAINT [PK_Note]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Status] in table 'InspectionStatus'
ALTER TABLE [dbo].[InspectionStatus]
ADD CONSTRAINT [PK_InspectionStatus]
    PRIMARY KEY CLUSTERED ([Status] ASC);
GO

-- Creating primary key on [Inspection_Id], [Inspector_Id], [Date] in table 'Planning'
ALTER TABLE [dbo].[Planning]
ADD CONSTRAINT [PK_Planning]
    PRIMARY KEY CLUSTERED ([Inspection_Id], [Inspector_Id], [Date] ASC);
GO

-- Creating primary key on [Id] in table 'Regulation'
ALTER TABLE [dbo].[Regulation]
ADD CONSTRAINT [PK_Regulation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Question'
ALTER TABLE [dbo].[Question]
ADD CONSTRAINT [PK_Question]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Type] in table 'QuestionType'
ALTER TABLE [dbo].[QuestionType]
ADD CONSTRAINT [PK_QuestionType]
    PRIMARY KEY CLUSTERED ([Type] ASC);
GO

-- Creating primary key on [Id] in table 'Template'
ALTER TABLE [dbo].[Template]
ADD CONSTRAINT [PK_Template]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address_Contact'
ALTER TABLE [dbo].[Address_Contact]
ADD CONSTRAINT [PK_Address_Contact]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address_Employee'
ALTER TABLE [dbo].[Address_Employee]
ADD CONSTRAINT [PK_Address_Employee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address_Inspector'
ALTER TABLE [dbo].[Address_Inspector]
ADD CONSTRAINT [PK_Address_Inspector]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address_Customer'
ALTER TABLE [dbo].[Address_Customer]
ADD CONSTRAINT [PK_Address_Customer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address_Inspection'
ALTER TABLE [dbo].[Address_Inspection]
ADD CONSTRAINT [PK_Address_Inspection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Question_TemplateQuestion'
ALTER TABLE [dbo].[Question_TemplateQuestion]
ADD CONSTRAINT [PK_Question_TemplateQuestion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Question_InspectionQuestion'
ALTER TABLE [dbo].[Question_InspectionQuestion]
ADD CONSTRAINT [PK_Question_InspectionQuestion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Role_Role] in table 'Address_Employee'
ALTER TABLE [dbo].[Address_Employee]
ADD CONSTRAINT [FK_EmployeeRoleEmployee]
    FOREIGN KEY ([Role_Role])
    REFERENCES [dbo].[EmployeeRole]
        ([Role])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeRoleEmployee'
CREATE INDEX [IX_FK_EmployeeRoleEmployee]
ON [dbo].[Address_Employee]
    ([Role_Role]);
GO

-- Creating foreign key on [Inspector_Id] in table 'Schedule'
ALTER TABLE [dbo].[Schedule]
ADD CONSTRAINT [FK_InspectorSchedule]
    FOREIGN KEY ([Inspector_Id])
    REFERENCES [dbo].[Address_Inspector]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InspectorSchedule'
CREATE INDEX [IX_FK_InspectorSchedule]
ON [dbo].[Schedule]
    ([Inspector_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'Note'
ALTER TABLE [dbo].[Note]
ADD CONSTRAINT [FK_CustomerNote]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Address_Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerNote'
CREATE INDEX [IX_FK_CustomerNote]
ON [dbo].[Note]
    ([Customer_Id]);
GO

-- Creating foreign key on [Status_Status] in table 'Address_Inspection'
ALTER TABLE [dbo].[Address_Inspection]
ADD CONSTRAINT [FK_InspectionStatusInspection]
    FOREIGN KEY ([Status_Status])
    REFERENCES [dbo].[InspectionStatus]
        ([Status])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InspectionStatusInspection'
CREATE INDEX [IX_FK_InspectionStatusInspection]
ON [dbo].[Address_Inspection]
    ([Status_Status]);
GO

-- Creating foreign key on [Customer_Id] in table 'Address_Inspection'
ALTER TABLE [dbo].[Address_Inspection]
ADD CONSTRAINT [FK_CustomerInspection]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Address_Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerInspection'
CREATE INDEX [IX_FK_CustomerInspection]
ON [dbo].[Address_Inspection]
    ([Customer_Id]);
GO

-- Creating foreign key on [Inspection_Id] in table 'Planning'
ALTER TABLE [dbo].[Planning]
ADD CONSTRAINT [FK_InspectionPlanning]
    FOREIGN KEY ([Inspection_Id])
    REFERENCES [dbo].[Address_Inspection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Inspector_Id] in table 'Planning'
ALTER TABLE [dbo].[Planning]
ADD CONSTRAINT [FK_InspectorPlanning]
    FOREIGN KEY ([Inspector_Id])
    REFERENCES [dbo].[Address_Inspector]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InspectorPlanning'
CREATE INDEX [IX_FK_InspectorPlanning]
ON [dbo].[Planning]
    ([Inspector_Id]);
GO

-- Creating foreign key on [Manager_Id] in table 'Address_Employee'
ALTER TABLE [dbo].[Address_Employee]
ADD CONSTRAINT [FK_EmployeeManager]
    FOREIGN KEY ([Manager_Id])
    REFERENCES [dbo].[Address_Employee]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeManager'
CREATE INDEX [IX_FK_EmployeeManager]
ON [dbo].[Address_Employee]
    ([Manager_Id]);
GO

-- Creating foreign key on [QuestionType_Type] in table 'Question'
ALTER TABLE [dbo].[Question]
ADD CONSTRAINT [FK_QuestionTypeQuestion]
    FOREIGN KEY ([QuestionType_Type])
    REFERENCES [dbo].[QuestionType]
        ([Type])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionTypeQuestion'
CREATE INDEX [IX_FK_QuestionTypeQuestion]
ON [dbo].[Question]
    ([QuestionType_Type]);
GO

-- Creating foreign key on [Template_Id] in table 'Question_TemplateQuestion'
ALTER TABLE [dbo].[Question_TemplateQuestion]
ADD CONSTRAINT [FK_TemplateTemplateQuestion]
    FOREIGN KEY ([Template_Id])
    REFERENCES [dbo].[Template]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TemplateTemplateQuestion'
CREATE INDEX [IX_FK_TemplateTemplateQuestion]
ON [dbo].[Question_TemplateQuestion]
    ([Template_Id]);
GO

-- Creating foreign key on [Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date] in table 'Question_InspectionQuestion'
ALTER TABLE [dbo].[Question_InspectionQuestion]
ADD CONSTRAINT [FK_PlanningInspectionQuestion]
    FOREIGN KEY ([Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date])
    REFERENCES [dbo].[Planning]
        ([Inspection_Id], [Inspector_Id], [Date])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanningInspectionQuestion'
CREATE INDEX [IX_FK_PlanningInspectionQuestion]
ON [dbo].[Question_InspectionQuestion]
    ([Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date]);
GO

-- Creating foreign key on [Id] in table 'Address_Contact'
ALTER TABLE [dbo].[Address_Contact]
ADD CONSTRAINT [FK_Contact_inherits_Address]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Address_Employee'
ALTER TABLE [dbo].[Address_Employee]
ADD CONSTRAINT [FK_Employee_inherits_Contact]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Address_Contact]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Address_Inspector'
ALTER TABLE [dbo].[Address_Inspector]
ADD CONSTRAINT [FK_Inspector_inherits_Employee]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Address_Employee]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Address_Customer'
ALTER TABLE [dbo].[Address_Customer]
ADD CONSTRAINT [FK_Customer_inherits_Contact]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Address_Contact]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Address_Inspection'
ALTER TABLE [dbo].[Address_Inspection]
ADD CONSTRAINT [FK_Inspection_inherits_Address]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Question_TemplateQuestion'
ALTER TABLE [dbo].[Question_TemplateQuestion]
ADD CONSTRAINT [FK_TemplateQuestion_inherits_Question]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Question]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Question_InspectionQuestion'
ALTER TABLE [dbo].[Question_InspectionQuestion]
ADD CONSTRAINT [FK_InspectionQuestion_inherits_Question]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Question]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------