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

SET IDENTITY_INSERT [dbo].[Template] ON
INSERT INTO [dbo].[Template] ([Id], [Name], [Description]) VALUES (1, N'Standaard Festival', N'')
SET IDENTITY_INSERT [dbo].[Template] OFF

SET IDENTITY_INSERT [dbo].[Question] ON
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (1, N'Op een schaal van 1 tot 10 wat was de sfeer bij de eetgelegenheden', N'*1 – Er is niemand, 5 - Het is redelijk druk, 10 – Er is geen doorkomen aan', N'Reeks', null)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (2, N'Geef een indruk van de sfeer impressie bij de eetgelegenheden', null, N'Tekst', null)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (3, N'Maak een foto van opvallende situaties', N'Benoem hier de geüploade foto’s:', N'Beeld', null)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (4, N'Meet de afstand tussen de verschillende food trucks', null, N'Tekst', null)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (5, N'Teken de algemene stroom van mensen op de kaart (bijlage A).', N'Eventuele opmerkingen:', N'Tekst', null)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (6, N'Tel het aantal tafels en zitplaatsen bij de foodtrucks', null, N'Tekst', null)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (7, N'Wat beschrijft het beste de sfeer bij het publiek na de shows bij de main stage?', N'-A: De sfeer is grimmig -B: Het publiek is rustig -C: Het publiek is dronken/aangeschoten -D: Het is chaos', N'Tabel', N'["Act","Sfeer"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (8, N'Geef het aantal mensen in de rij 5 minuten voor het begin van de elke theater show', null, N'Tabel', N'["Show","Aantal mensen in rij"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (9, N'Hoe druk was het bij de WC''s? Maak elk uur een schatting', N'*(Gebruik je inschattingstechniek geleerd op de training dag)', N'Tabel', N'["Tijd","Drukte"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (10, N'Hoe druk is het bij de Main Stage? Maak elk half uur een schatting', null, N'Tabel', N'["Tijd","Drukte"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (11, N'Hoe druk was het bij de foodtrucks? Maak elk uur een schatting', null, N'Tabel', N'["Tijd","Drukte"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (12, N'Losse opmerkingen', N'Plaats hier eventuele opmerkingen:', N'Tekst', null)
SET IDENTITY_INSERT [dbo].[Question] OFF

INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (1, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (2, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (3, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (4, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (5, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (6, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (7, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (8, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (9, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (10, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (11, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Question_Id], [Template_Id]) VALUES (12, 1)