SET IDENTITY_INSERT [dbo].[Address] ON
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (1, N'Onderwijsboulevard', N'215', N'5223DE', N'''s-Hertogenbosch', N'Nederland', N'''s-Hertogenbosch', N'POINT (5.28709 51.68864)', 5.28709, 51.68864)
SET IDENTITY_INSERT [dbo].[Address] OFF

INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Sven', N'Slijkoord', N'sven.slijkoord@festispec.nl', N'06-51712894', N'NL26RABO0367742883', 1)

INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Manager')
INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Medewerker')
INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Inspecteur')

INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Id], [Role_Role], [Manager_Id], [HiredFrom]) VALUES (N'Sven',  N'oP5TegghNxgbFBJUol3UaOOODGyl1NnadCCjGjPv4x0=', 1, N'Manager', null, N'2016-01-01 00:00:00')

INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'Geaccepteerd')
INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'Afgewezen')
INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'In afwachting')

INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Tekst')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Getal')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Reeks')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Beeld')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Tabel')