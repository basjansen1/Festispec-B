SET IDENTITY_INSERT [dbo].[Address] ON
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (1, N'Straatje', N'3', N'4833DF', N'Den bosch', N'Nederland', N'Den Bosch')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (2, N'Oranjelaan', N'5', N'6950GF', N'Schijndel', N'Nederland', N'Meierijstad')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (3, N'Blauweweg', N'4', N'5352GF', N'Walsberg', N'Nederland', N'Veghel')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (4, N'Groenweg', N'22', N'5543FA', N'Walsberg', N'Duitsland', N'Veghel')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (5, N'Bruinweg', N'33', N'5352GF', N'Veghel', N'Belgie', N'Breda')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (6, N'Blauweweg', N'15', N'1234GF', N'Walsberg', N'India', N'Uden')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (7, N'Geleweg', N'56', N'1256GF', N'DingenDoen', N'Nederland', N'Veghel')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (8, N'Achterlaan', N'84', N'5352GF', N'Walsberg', N'Frankrijk', N'Amsterdam')
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality]) VALUES (9, N'Groeneweg', N'42', N'7532GF', N'Walsberg', N'Frankrijk', N'Amsterdam')
SET IDENTITY_INSERT [dbo].[Address] OFF

INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Henk', N'Randers', N'haha@hotmail.com', N'072-5837294', N'NL74RABO0118236819', 1)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Tom', N'Frans', N'hooppdle@hotmail.com', N'072-5837294', N'NL74RABO0118236819', 2)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Henk', N'Randers', N'haha@hotmail.com', N'072-5837294', N'NL74RABO01181356319', 3)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Frans', N'Middel', N'hegf@hotmail.com', N'072-58342454', N'NL74RABO0115676819', 4)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Kam', N'Randers', N'gdeed@hotmail.com', N'072-58341234', N'NL74RABO013455619', 5)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Frans', N'Ham', N'rtyg@hotmail.com', N'072-5676294', N'NL74RABO0118567619', 6)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Rick', N'Mande', N'ujtr@hotmail.com', N'072-5865394', N'NL74RABO0114565819', 7)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Pim', N'Lenss', N'bvng@hotmail.com', N'072-5837544', N'NL74RABO011826769', 8)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Hans', N'Slijkk', N'uityd@hotmail.com', N'072-588764', N'NL74RABO0118276549', 9)

INSERT INTO [dbo].[Address_Customer] ([KVK], [Id]) VALUES (N'KVKNoClue', 1)
INSERT INTO [dbo].[Address_Customer] ([KVK], [Id]) VALUES (N'KVKWattes', 2)
INSERT INTO [dbo].[Address_Customer] ([KVK], [Id]) VALUES (N'KVKGeenIdee', 3)
INSERT INTO [dbo].[Address_Customer] ([KVK], [Id]) VALUES (N'KVKWatMoetHier', 4)

INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Manager')
INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Medewerker')
INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Inspecteur')

INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Id], [Role_Role], [Manager_Id]) VALUES (N'UsernameN', N'123', 1, N'Manager', 1)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Id], [Role_Role], [Manager_Id]) VALUES (N'UsernameLW', N'woord', 2, N'Manager', 2)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Id], [Role_Role], [Manager_Id]) VALUES (N'UsernameNW', N'woord123', 3, N'Medewerker', 1)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Id], [Role_Role], [Manager_Id]) VALUES (N'UsernameUW', N'WOORD', 4, N'Inspecteur', 1)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Id], [Role_Role], [Manager_Id]) VALUES (N'UsernameLWS', N'woord!', 5, N'Inspecteur', 1)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Id], [Role_Role], [Manager_Id]) VALUES (N'UsernameUWS', N'WOORD!', 6, N'Inspecteur', 2)

INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'Accepted')
INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'Declined')
INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'Pending')

INSERT INTO [dbo].[Address_Inspection] ([Name], [Website], [Start], [End], [Id], [Status_Status]) VALUES (N'Paaspop', N'www.wat.nl', N'2017-01-19 03:14:07', N'2017-01-24 03:14:07', 1, N'Pending')
INSERT INTO [dbo].[Address_Inspection] ([Name], [Website], [Start], [End], [Id], [Status_Status]) VALUES (N'Festyland', N'www.festyland.nl', N'2038-01-19 03:14:07', N'2038-01-19 03:14:07', 2, N'Accepted')
INSERT INTO [dbo].[Address_Inspection] ([Name], [Website], [Start], [End], [Id], [Status_Status]) VALUES (N'Mysteryland', N'www.mysteryland.nl', N'2038-01-19 03:14:08', N'2038-01-19 03:14:08', 3, N'Declined')

INSERT INTO [dbo].[Address_Inspector] ([CertificationFrom], [CertificationTo], [Id]) VALUES (N'2009-01-19 03:14:08', N'2024-01-19 03:14:08', 4)
INSERT INTO [dbo].[Address_Inspector] ([CertificationFrom], [CertificationTo], [Id]) VALUES (N'2016-01-19 03:14:08', N'2022-01-19 03:14:08', 5)
INSERT INTO [dbo].[Address_Inspector] ([CertificationFrom], [CertificationTo], [Id]) VALUES (N'2017-01-19 03:14:08', N'2030-01-24 03:14:08', 6)

INSERT INTO [dbo].[CustomerInspection] ([Customers_Id], [Inspections_Id]) VALUES (1, 1)
INSERT INTO [dbo].[CustomerInspection] ([Customers_Id], [Inspections_Id]) VALUES (2, 2)
INSERT INTO [dbo].[CustomerInspection] ([Customers_Id], [Inspections_Id]) VALUES (3, 3)


SET IDENTITY_INSERT [dbo].[Note] ON
INSERT INTO [dbo].[Note] ([Id], [Content], [Customer_Id]) VALUES (1, N'Here for notes', 1)
INSERT INTO [dbo].[Note] ([Id], [Content], [Customer_Id]) VALUES (2, N'Extra notes', 1)
INSERT INTO [dbo].[Note] ([Id], [Content], [Customer_Id]) VALUES (4, N'This one notes', 2)
SET IDENTITY_INSERT [dbo].[Note] OFF


INSERT INTO [dbo].[Planning] ([Inspection_Id], [Inspector_Id], [Date], [TimeFrom], [TimeTo], [Hours]) VALUES (1, 4, N'2016-09-17 00:00:00', N'07:00:00', N'17:00:00', 10)
INSERT INTO [dbo].[Planning] ([Inspection_Id], [Inspector_Id], [Date], [TimeFrom], [TimeTo], [Hours]) VALUES (1, 5, N'2016-09-17 00:00:00', N'09:00:00', N'17:00:00', 8)
INSERT INTO [dbo].[Planning] ([Inspection_Id], [Inspector_Id], [Date], [TimeFrom], [TimeTo], [Hours]) VALUES (2, 6, N'2017-03-24 00:00:00', N'09:00:00', N'17:00:00', 8)

INSERT INTO [dbo].[QuestionType] ([Type], [Metadata]) VALUES (N'Aantal mensen in rij', N'["Show","Aantal mensen in rij"]')
INSERT INTO [dbo].[QuestionType] ([Type], [Metadata]) VALUES (N'Beoordeling', NULL)
INSERT INTO [dbo].[QuestionType] ([Type], [Metadata]) VALUES (N'Drukte', N'["Tijd","Drukte"]')
INSERT INTO [dbo].[QuestionType] ([Type], [Metadata]) VALUES (N'Foto''s', NULL)
INSERT INTO [dbo].[QuestionType] ([Type], [Metadata]) VALUES (N'Sfeer', N'["Act","Sfeer"]')
INSERT INTO [dbo].[QuestionType] ([Type], [Metadata]) VALUES (N'Tekst', NULL)

SET IDENTITY_INSERT [dbo].[Template] ON
INSERT INTO [dbo].[Template] ([Id], [Name], [Description]) VALUES (1, N'Standaard Festival', N'Deze template is bedoeld voor een standaar festival')
INSERT INTO [dbo].[Template] ([Id], [Name], [Description]) VALUES (2, N'Techno Festival', N'Deze template is bedoeld voor een techno festival')
INSERT INTO [dbo].[Template] ([Id], [Name], [Description]) VALUES (3, N'Eet Festival', N'Deze template is bedoeld voor eetfestivals')
SET IDENTITY_INSERT [dbo].[Template] OFF

SET IDENTITY_INSERT [dbo].[Question] ON
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type]) VALUES (1, N'Is alles goed geregeld', N'Is alles goed geregeld', N'Tekst')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type]) VALUES (2, N'Is er genoeg bewaking', N'Is er genoeg bewaking', N'Beoordeling')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type]) VALUES (3, N'Is er genoeg bewaking', N'Is er genoeg bewaking', N'Beoordeling')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type]) VALUES (4, N'Is alles goed geregeld', N'Is alles goed geregeld', N'Tekst')
SET IDENTITY_INSERT [dbo].[Question] OFF

INSERT INTO [dbo].[Question_InspectionQuestion] ([Answer], [Id], [Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date]) VALUES (N'Ja', 1, 1, 4, N'2016-09-17 00:00:00')
INSERT INTO [dbo].[Question_InspectionQuestion] ([Answer], [Id], [Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date]) VALUES (N'Nee', 2, 1, 5, N'2016-09-17 00:00:00')
INSERT INTO [dbo].[Question_InspectionQuestion] ([Answer], [Id], [Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date]) VALUES (N'Ja', 3, 2, 6, N'2017-03-24 00:00:00')
INSERT INTO [dbo].[Question_InspectionQuestion] ([Answer], [Id], [Planning_Inspection_Id], [Planning_Inspector_Id], [Planning_Date]) VALUES (N'Nee', 4, 2, 6, N'2017-03-24 00:00:00')

INSERT INTO [dbo].[Question_TemplateQuestion] ([Id], [Template_Id]) VALUES (1, 1)
INSERT INTO [dbo].[Question_TemplateQuestion] ([Id], [Template_Id]) VALUES (2, 2)
INSERT INTO [dbo].[Question_TemplateQuestion] ([Id], [Template_Id]) VALUES (3, 1)
INSERT INTO [dbo].[Question_TemplateQuestion] ([Id], [Template_Id]) VALUES (4, 2)


SET IDENTITY_INSERT [dbo].[Regulation] ON
INSERT INTO [dbo].[Regulation] ([Id], [Name], [Description], [Municipality]) VALUES (1, N'Bedrijfsnaam', N'Wat beschrijving', N'Meierijstad')
INSERT INTO [dbo].[Regulation] ([Id], [Name], [Description], [Municipality]) VALUES (2, N'Bol', N'Wat bolschrijving', N'Den bosch')
INSERT INTO [dbo].[Regulation] ([Id], [Name], [Description], [Municipality]) VALUES (3, N'Bluehole', N'Wat blueschrijving', N'Amerika')
INSERT INTO [dbo].[Regulation] ([Id], [Name], [Description], [Municipality]) VALUES (4, N'Geentje', N'Wat geenschrijving', N'India')
SET IDENTITY_INSERT [dbo].[Regulation] OFF


SET IDENTITY_INSERT [dbo].[Schedule] ON
INSERT INTO [dbo].[Schedule] ([Id], [NotAvailableFrom], [NotAvailableTo], [Inspector_Id]) VALUES (1, N'2018-05-17 00:00:00', N'2018-06-05 00:00:00', 4)
INSERT INTO [dbo].[Schedule] ([Id], [NotAvailableFrom], [NotAvailableTo], [Inspector_Id]) VALUES (2, N'2018-05-17 00:00:00', N'2018-06-05 00:00:00', 5)
INSERT INTO [dbo].[Schedule] ([Id], [NotAvailableFrom], [NotAvailableTo], [Inspector_Id]) VALUES (3, N'2018-05-17 00:00:00', N'2018-06-05 00:00:00', 6)
INSERT INTO [dbo].[Schedule] ([Id], [NotAvailableFrom], [NotAvailableTo], [Inspector_Id]) VALUES (4, N'2018-04-22 00:00:00', N'2018-05-05 00:00:00', 4)
SET IDENTITY_INSERT [dbo].[Schedule] OFF


