CREATE TABLE [dbo].[Address_Employee] (
    [Username]     NVARCHAR (MAX) NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [Id]           INT            NOT NULL,
    [Role_Role]    NVARCHAR (64)  NOT NULL,
    [Employees_Id] INT            NOT NULL,
    CONSTRAINT [PK_Address_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_inherits_Contact] FOREIGN KEY ([Id]) REFERENCES [dbo].[Address_Contact] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeEmployee] FOREIGN KEY ([Employees_Id]) REFERENCES [dbo].[Address_Employee] ([Id]),
    CONSTRAINT [FK_EmployeeRoleEmployee] FOREIGN KEY ([Role_Role]) REFERENCES [dbo].[EmployeeRole] ([Role])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeRoleEmployee]
    ON [dbo].[Address_Employee]([Role_Role] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EmployeeEmployee]
    ON [dbo].[Address_Employee]([Employees_Id] ASC);

