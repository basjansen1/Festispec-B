﻿INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'Geaccepteerd')
INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'Afgewezen')
INSERT INTO [dbo].[InspectionStatus] ([Status]) VALUES (N'In afwachting')

INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Manager')
INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Medewerker')
INSERT INTO [dbo].[EmployeeRole] ([Role]) VALUES (N'Inspecteur')

INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Tekst')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Getal')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Reeks')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Beeld')
INSERT INTO [dbo].[QuestionType] ([Type]) VALUES (N'Tabel')

SET IDENTITY_INSERT [dbo].[Address] ON
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (1, N'Andriëtte Peereboom', N'1', N'4283GP', N'Giessen', N'Nederland', N'Woudrichem', N'POINT (5.02955 51.79262)', 5.02955, 51.79262)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (2, N'Oude Engelenseweg', N'50A', N'5223KD', N'''s-Hertogenbosch', N'Nederland', N'''s-Hertogenbosch', N'POINT (5.29146 51.69765)', 5.29146, 51.69765)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (3, N'Grote Kerkplein', N'15', N'8011PK', N'Zwolle', N'Nederland', N'Zwolle', N'POINT (6.09292 52.51136)', 6.09292, 52.51136)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (4, N'Tooropstraat', N'87', N'6521NK', N'Nijmegen', N'Nederland', N'Nijmegen', N'POINT (5.88024 51.83678)', 5.88024, 51.83678)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (5, N'Chopinstraat', N'53', N'5481LP', N'Schijndel', N'Nederland', N'Meierijstad', N'POINT (5.44317 51.61173)', 5.44317, 51.61173)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (6, N'Bobbenagelseweg', N'4', N'5492VL', N'Sint-Oedenrode', N'Nederland', N'Meierijstad', N'POINT (5.42526 51.56369)', 5.42526, 51.56369)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (7, N'Kamelenspoor', N'244', N'3605EN', N'Maarssen', N'Nederland', N'Stichtse Vechth', N'POINT (5.02406 52.13776)', 5.02406, 52.13776)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (8, N'de Geer', N'1223', N'6605HV', N'Wijchen', N'Nederland', N'Wijchen', N'POINT (5.72855 51.79688)', 5.72855, 51.79688)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (9, N'Bosschebaan', N'58', N'5384VZ', N'Heesch', N'Nederland', N'Bernheze', N'POINT (5.50657 51.73251)', 5.50657, 51.73251)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (10, N'Onderwijsboulevard', N'215', N'5223DE', N'''s-Hertogenbosch', N'Nederland', N'''s-Hertogenbosch', N'POINT (5.28709 51.68864)', 5.28709, 51.68864)
INSERT INTO [dbo].[Address] ([Id], [Street], [HouseNumber], [PostalCode], [City], [Country], [Municipality], [Location], [Long], [Lat]) VALUES (11, N'Tramkade', N'24', N'5211VB', N'''s-Hertogenbosch', N'Nederland', N'''s-Hertogenbosch', N'POINT (5.2991 51.69656)', 5.2991, 51.69656)
SET IDENTITY_INSERT [dbo].[Address] OFF

INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Sven', N'Slijkoord', N'svenslijkoord@festispec.nl', NULL, NULL, 1)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Thomas', N'van der Slot', N'thomasvanderslot@festispec.nl', NULL, NULL, 2)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Bas', N'Janssen', N'bas.janssen@festispec.nl', NULL, NULL, 3)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Martijn', N'Knook', N'martijn.knook@festispec.nl', NULL, NULL, 4)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Sietse', N'Manders', N'sietse.manders@festispec.nl', NULL, NULL, 5)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Teun', N'Martens', N'teun.martens@festispec.nl', NULL, NULL, 6)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Arjun', N'Autar', N'arjun.autar@festispec.nl', NULL, NULL, 7)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Ylja', N'van Son', N'ylja.son@festispec.nl', NULL, NULL, 8)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Alex', N'Mehlbaum', N'alex.mehlbaum@festispec.nl', NULL, NULL, 9)
INSERT INTO [dbo].[Address_Contact] ([FirstName], [LastName], [Email], [Telephone], [IBAN], [Id]) VALUES (N'Stijn', N'Smulders', N'stijn.smulders@avans.nl', NULL, NULL, 10)

INSERT INTO [dbo].[Address_Customer] ([KVK], [Name], [Id]) VALUES (N'1234567890', N'van Aken', 10)

INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Sven', N'Li6QGvnnHBuYDd/BD+32HA==', N'Manager', NULL, N'2016-01-01 00:00:00', NULL, 1)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Thomas', N'kMRZo+VqYe+MPK410WWJLu30EMApgVUtiqLyc0SJCFs=', N'Manager', NULL, N'2017-01-01 00:00:00', NULL, 2)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Bas', N'QvGyLNNo4QUNmgVRVjlWTQ==', N'Medewerker', 1, N'2017-01-01 00:00:00', NULL, 3)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Martijn', N'/0EbtASlGb79GZeUEsUQPqpSEJjmM86yfHoHq9RykcQ=', N'Inspecteur', 2, N'2017-01-01 00:00:00', NULL, 4)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Sietse', N'QlSHFYRo3dsrrHBqX/tHQnh6XiTqphONmdwUkZIET4k=', N'Medewerker', 1, N'2017-01-01 00:00:00', NULL, 5)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Teun', N'tW52BNZXx1xY+nUDBNwGcw==', N'Medewerker', 2, N'2017-01-01 00:00:00', NULL, 6)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Arjun', N'D7PfSmahWH4Y9NoROsLC/ZQEWFL8Co0EDelmEmQ7rg0=', N'Medewerker', 1, N'2017-01-01 00:00:00', NULL, 7)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Ylja', N'7UngL3aamo7amLAvLU+dSA==', N'Medewerker', 2, N'2017-01-01 00:00:00', NULL, 8)
INSERT INTO [dbo].[Address_Employee] ([Username], [Password], [Role_Role], [Manager_Id], [HiredFrom], [HiredTo], [Id]) VALUES (N'Alex', N'CCQ8wetJxrAclKi81seEVA==', N'Medewerker', 1, N'2017-01-01 00:00:00', NULL, 9)

INSERT INTO [dbo].[Address_Inspection] ([Name], [Website], [Start], [End], [Status_Status], [Customer_Id], [Id], [Instructions]) VALUES (N'Inspectie bij van Aken', N'http://werkwarenhuis.nl/food/', N'2018-01-11 00:00:00', N'2018-01-11 00:00:00', N'Geaccepteerd', 10, 11, N'Vandaag gaan jullie een inspectie uitvoeren op de Tramkade omtrent de kwaliteit van het festival terrein met als focus de ruimte voor het plaatsen van foodtrucks. Naast deze informatie wil de Tramkade ook meer inzicht in de drukte op verschillende onderdelen in het festival. Om de drukte en optredens te simuleren hanger er op het festivalterrein pamfletten met afbeeldingen en informatie over festivals.

Zorg voor een duidelijke en volledige omschrijving van wat je ziet en gebruik de juiste technieken om drukte in te schatten op verschillende locaties.

Hieronder is een kaart van de tramkade en bijbehorende panden. De antwoorden op alle vragen vind je binnen het terrein (rode lijn). Je hoeft dus niet van het terrein af om een vraag te beantwoorden.')

INSERT INTO [dbo].[Address_Inspector] ([CertificationFrom], [CertificationTo], [Id]) VALUES (N'2017-01-01 00:00:00', N'2020-01-01 00:00:00', 4)
--INSERT INTO [dbo].[Address_Inspector] ([CertificationFrom], [CertificationTo], [Id]) VALUES (N'2017-01-01 00:00:00', N'2020-01-01 00:00:00', ??)

SET IDENTITY_INSERT [dbo].[Template] ON
INSERT INTO [dbo].[Template] ([Id], [Name], [Description]) VALUES (1, N'van Aken Template', N'Dit template wordt gebruikt bij van Aken')
SET IDENTITY_INSERT [dbo].[Template] OFF

SET IDENTITY_INSERT [dbo].[Question] ON
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (1, N'Op een schaal van 1 tot 10 hoe geschikt is de tramkade voor het geven van Festivals?', N'*1 - Niet geschikt, 5 - Het kan maar niet praktisch, 10 - Perfecte plek voor een festival', N'Reeks', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (2, N'Geef een indruk van de sfeer impressie bij de mengfabriek. Is de omgeving gezellig aangekleed?', NULL, N'Tekst', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (3, N'Maak een foto van de mooiste graffiti op de voersilo''s. ', NULL, N'Beeld', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (4, N'Meet de afstand tussen de mengfabriek en het werkwarenhuis.', N'Er loopt een steeg tussen de deze 2 panden. Maak om de 5 meter een schatting wat de breedte is van de steeg.', N'Tabel', N'["Afstand in steeg","Breedte van steeg"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (5, N'Geef aan wat het smalte stuk is van de steeg, waar zit deze en hoe breed is de steeg op dit stuk.', N'Maak een foto van het smalste stuk.', N'Beeld', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (6, N'Tel het aantal tafels bij de mengfabriek.', NULL, N'Getal', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (7, N'Tel het aantal zitplaatsen bij de mengfabriek.', NULL, N'Getal', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (8, N'Maak een indicatie wat voor festivals het beste gegeven kunnen worden op dit terrein.', N'A: foodtruck, B: cultureel, C: muziek, D: groot meerdaags, E: anders namelijk', N'Tekst', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (9, N'Weet jij welke band er bij elke act aan het optreden is?', N'De kaaihallen zijn dicht, maar normaliter een mooie plek voor een main stage. Er hangen 4 foto''s aan de deur. 6 opties: Guus meeuwis, metallica, de toppers, adele, lil kleine, lady gaga', N'Tabel', N'["Act","Sfeer"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (10, N'Hoe druk is het bij de Main stage?', N'Maak bij elke act een schatting. 4 foto''s en dan een schatting.', N'Beeld', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (11, N'Hoe druk was het in het van Aken Restaurant?', N'Maak elk kwartier een schatting', N'Tabel', N'["Tijd","Drukte"]')
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (12, N'Op een schaal van 1 tot 10, hoe leuk vond je het om op deze manier de applicatie te testen?', N'*1 - Meh, *5 - Wel grappig, *10 - Een stuk leuker dan in een klaslokaal', N'Reeks', NULL)
INSERT INTO [dbo].[Question] ([Id], [Name], [Description], [QuestionType_Type], [Metadata]) VALUES (13, N'Losse opmerking', NULL, N'Tekst', NULL)
SET IDENTITY_INSERT [dbo].[Question] OFF

INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 1)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 2)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 3)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 4)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 5)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 6)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 7)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 8)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 9)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 10)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 11)
INSERT INTO [dbo].[TemplateQuestion] ([Template_Id], [Question_Id]) VALUES (1, 12)

INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 1)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 2)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 3)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 4)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 5)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 6)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 7)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 8)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 9)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 10)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 11)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 12)
INSERT INTO [dbo].[InspectionQuestion] ([Inspection_Id], [Question_Id]) VALUES (11, 13)

INSERT INTO [dbo].[Planning] ([Inspection_Id], [Inspector_Id], [Date], [TimeFrom], [TimeTo], [Hours]) VALUES (11, 4, N'2018-01-11 00:00:00', N'12:15:00', N'16:25:00', NULL)
--INSERT INTO [dbo].[Planning] ([Inspection_Id], [Inspector_Id], [Date], [TimeFrom], [TimeTo], [Hours]) VALUES (11, ??, N'2018-01-11 00:00:00', N'12:15:00', N'16:25:00', NULL)
INSERT INTO [DBO].[Regulation] ([Id], [Description], [Municipality], [Name]) VALUES (1, N'Er mag niet gerookt worden in het openbaar', N's-Hertogenbosch', N'Roken')
INSERT INTO [DBO].[Regulation] ([Id], [Description], [Municipality], [Name]) VALUES (2, N'Er geen hard muziek afgespeeld worden na 11 uur in de avond', N's-Hertogenbosch', 'Muziek')
INSERT INTO [DBO].[Regulation] ([Id], [Description], [Municipality], [Name]) VALUES (3, N'Er mag geen afval rondzwerven', N's-Hertogenbosch', N'Afval')