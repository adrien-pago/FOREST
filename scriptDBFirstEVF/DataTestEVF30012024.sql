USE [EVF_DEV]
GO
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (1, 13, N'60000300', N'L')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (2, 14, N'60000400', N'L')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (3, 14, N'60000350', N'KG')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (4, 15, N'60000350', N'KG')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (5, 17, N'60000312', N'LBS')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (6, 13, N'60000338', N'LBS')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (7, 13, N'60000310', N'LBS')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (8, 26, N'60000300', N'L')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (9, 14, N'60000400', N'L')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (10, 31, N'60000350', N'KG')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (11, 35, N'60000350', N'KG')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (12, 31, N'60000312', N'LBS')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (13, 22, N'60000338', N'LBS')
INSERT [dbo].[Article] ([IdArticle], [IdType], [CodeSAP], [Unite]) VALUES (14, 15, N'60000310', N'LBS')
SET IDENTITY_INSERT [dbo].[Article] OFF
GO
SET IDENTITY_INSERT [dbo].[Societe] ON 

INSERT [dbo].[Societe] ([IdSociete], [NomSociete], [OrgCommerciale], [CodeLangue], [CodeSociete]) VALUES (1, N'SERVALESA', N'1400', N'ES                  ', N'ES02')
INSERT [dbo].[Societe] ([IdSociete], [NomSociete], [OrgCommerciale], [CodeLangue], [CodeSociete]) VALUES (2, N'FERTIPLUS', N'1300', N'FR                  ', N'FR15')
INSERT [dbo].[Societe] ([IdSociete], [NomSociete], [OrgCommerciale], [CodeLangue], [CodeSociete]) VALUES (3, N'DE SANGOSSE', N'1200', N'FR                  ', N'FR00')
INSERT [dbo].[Societe] ([IdSociete], [NomSociete], [OrgCommerciale], [CodeLangue], [CodeSociete]) VALUES (4, N'AGN', N'1100', N'FR                  ', N'FR03')
INSERT [dbo].[Societe] ([IdSociete], [NomSociete], [OrgCommerciale], [CodeLangue], [CodeSociete]) VALUES (19, N'LIPHATECH', N'1000', N'FR                  ', N'FR02')
INSERT [dbo].[Societe] ([IdSociete], [NomSociete], [OrgCommerciale], [CodeLangue], [CodeSociete]) VALUES (20, N'AHP CROPSCIENCE', N'1120', N'ES                  ', N'ES06')
INSERT [dbo].[Societe] ([IdSociete], [NomSociete], [OrgCommerciale], [CodeLangue], [CodeSociete]) VALUES (21, N'BIOLÓGICA NATURE', N'1500', N'ES                  ', N'ES04')
SET IDENTITY_INSERT [dbo].[Societe] OFF
GO
SET IDENTITY_INSERT [dbo].[Division] ON 

INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (2, 1, N'6200')
INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (3, 4, N'1300')
INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (4, 4, N'1301')
INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (5, 20, N'6600')
INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (6, 3, N'1000')
INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (7, 19, N'1200')
INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (8, 21, N'6400')
INSERT [dbo].[Division] ([IdDivision], [IdSociete], [CodeDivision]) VALUES (9, 2, N'6300')
SET IDENTITY_INSERT [dbo].[Division] OFF
GO
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (2, 1)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (3, 1)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (2, 2)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (3, 2)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (2, 3)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (2, 4)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (3, 4)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (2, 5)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (2, 6)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (2, 7)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (3, 7)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (4, 7)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (5, 7)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (4, 8)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (5, 8)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (4, 10)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (6, 10)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (7, 12)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (8, 13)
INSERT [dbo].[ArticleDivision] ([IdDivision], [IdArticle]) VALUES (9, 14)
GO
SET IDENTITY_INSERT [dbo].[LibelleArticle] ON 

INSERT [dbo].[LibelleArticle] ([IdLibelleArticle], [IdArticle], [CodeLangue], [Libelle]) VALUES (2, 1, N'FR', N'NECTAR')
INSERT [dbo].[LibelleArticle] ([IdLibelleArticle], [IdArticle], [CodeLangue], [Libelle]) VALUES (3, 1, N'ES', N'NECTARES')
INSERT [dbo].[LibelleArticle] ([IdLibelleArticle], [IdArticle], [CodeLangue], [Libelle]) VALUES (4, 1, N'EN', N'NECTAREN')
INSERT [dbo].[LibelleArticle] ([IdLibelleArticle], [IdArticle], [CodeLangue], [Libelle]) VALUES (5, 2, N'FR', N'OPTIZ-BID')
INSERT [dbo].[LibelleArticle] ([IdLibelleArticle], [IdArticle], [CodeLangue], [Libelle]) VALUES (6, 3, N'ES', N'OPTIZ-BIDES')
INSERT [dbo].[LibelleArticle] ([IdLibelleArticle], [IdArticle], [CodeLangue], [Libelle]) VALUES (7, 6, N'EN', N'FALGROEN')
INSERT [dbo].[LibelleArticle] ([IdLibelleArticle], [IdArticle], [CodeLangue], [Libelle]) VALUES (8, 3, N'ES', N'OPTIZ-BIDES')
SET IDENTITY_INSERT [dbo].[LibelleArticle] OFF
GO
SET IDENTITY_INSERT [dbo].[Personnel] ON 

INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (2, N'ROSALIE', N'600', 1, 1, N'rosa@outlook.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (3, N'DUPONT', N'700', 1, 2, N'dupont@gmail.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (4, N'MONICA', N'500', 1, 3, N'moni@gmail.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (5, N'GOMEZ', N'300', 2, 1, N'gomez10@yahoo.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (6, N'TATIANA', N'900', 2, 1, N'tati@gmail.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (7, N'JEAN', N'450', 2, 2, N'jean@gmail.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (8, N'BORIS', N'650', 2, 3, N'boriss@yahoo.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (9, N'SERGE', N'400', 1, 4, N'serge400@societe.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (10, N'ARIA', N'550', 2, 4, N'arii@yahoo.com')
INSERT [dbo].[Personnel] ([IdPersonnel], [Nom], [CodeSAP], [IdRole], [IdSociete], [Email]) VALUES (12, N'DIR', N'200', 1, 4, N'dire@gmail.com')
SET IDENTITY_INSERT [dbo].[Personnel] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([IdClient], [CodeSAP], [Libelle], [ISOPays], [Region]) VALUES (1, N'2361', N'CERTIS BELCHIM', N'FR                  ', N'Auvergne Rhone Alpes')
INSERT [dbo].[Client] ([IdClient], [CodeSAP], [Libelle], [ISOPays], [Region]) VALUES (2, N'1341', N'LUSOSEM', N'PT                  ', N'Lisbonne')
INSERT [dbo].[Client] ([IdClient], [CodeSAP], [Libelle], [ISOPays], [Region]) VALUES (3, N'1340', N'SOUFFLET', N'FR                  ', N'Normandie')
INSERT [dbo].[Client] ([IdClient], [CodeSAP], [Libelle], [ISOPays], [Region]) VALUES (4, N'1350', N'BASF A/S', N'AU                  ', N'Tasmanie')
INSERT [dbo].[Client] ([IdClient], [CodeSAP], [Libelle], [ISOPays], [Region]) VALUES (5, N'1348', N'SYNGENTA', N'SU                  ', N'Berne')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Prevision] ON 

INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (1, 1, 1, N'10', N'2023', CAST(N'2023-04-09' AS Date), CAST(N'2023-09-10' AS Date), N'20', 2)
INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (2, 1, 2, N'09', N'2023', CAST(N'2023-05-05' AS Date), CAST(N'2023-09-20' AS Date), N'800', 2)
INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (3, 1, 3, N'10', N'2023', CAST(N'2023-04-09' AS Date), CAST(N'2023-09-10' AS Date), N'400', 2)
INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (4, 1, 4, N'05', N'2023', CAST(N'2023-04-09' AS Date), CAST(N'2023-09-15' AS Date), N'900', 3)
INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (5, 2, 5, N'02', N'2023', CAST(N'2023-04-09' AS Date), CAST(N'2023-09-10' AS Date), N'100', 3)
INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (6, 2, 5, N'06', N'2023', CAST(N'2023-04-09' AS Date), CAST(N'2023-10-10' AS Date), N'250', 3)
INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (7, 4, 4, N'11', N'2023', CAST(N'2023-04-10' AS Date), CAST(N'2023-09-01' AS Date), N'300', 4)
INSERT [dbo].[Prevision] ([IdPrevision], [IdClient], [IdArticle], [Mois], [Annee], [DateCreation], [DateModification], [Volume], [IdCommercial]) VALUES (8, 5, 4, N'04', N'2023', CAST(N'2023-04-09' AS Date), CAST(N'2023-10-07' AS Date), N'220', 12)
SET IDENTITY_INSERT [dbo].[Prevision] OFF
GO
SET IDENTITY_INSERT [dbo].[VentePortefeuille] ON 

INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (1, 1, 2, 1, N'10', N'2023', 1, N'500')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (2, 1, 2, 1, N'07', N'2023', 1, N'200')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (3, 1, 2, 3, N'09', N'2023', 0, N'20')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (4, 1, 2, 4, N'01', N'2023', 1, N'550')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (5, 1, 2, 5, N'10', N'2023', 0, N'210')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (6, 2, 3, 5, N'02', N'2023', 1, N'450')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (7, 3, 3, 2, N'11', N'2023', 1, N'10')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (8, 4, 4, 2, N'05', N'2023', 1, N'100')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (9, 5, 3, 2, N'06', N'2023', 0, N'800')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (10, 4, 4, 2, N'05', N'2023', 1, N'100')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (11, 5, 2, 1, N'02', N'2023', 0, N'4400')
INSERT [dbo].[VentePortefeuille] ([IdVentePort], [IdClient], [IdCommercial], [IdArticle], [Mois], [Annee], [TypeVentePort], [Volume]) VALUES (12, 4, 3, 1, N'05', N'2023', 1, N'300')
SET IDENTITY_INSERT [dbo].[VentePortefeuille] OFF
GO
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (1, 1, 2, 5)
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (1, 2, 2, 6)
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (2, 5, 3, 7)
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (3, 2, 4, 8)
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (3, 4, 4, 8)
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (4, 1, 9, 10)
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (4, 3, 9, 10)
INSERT [dbo].[SocieteClient] ([IdSociete], [IdClient], [IdCommercial], [IdAssistantCommercial]) VALUES (4, 5, 12, 10)
GO
SET IDENTITY_INSERT [dbo].[TypeArticle] ON 

INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (13, N'EN        ', N'Additive')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (14, N'EN        ', N'Slug bait')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (15, N'EN        ', N'Fungicide')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (17, N'ES        ', N'Adyuvante')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (19, N'ES        ', N'Inoculador')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (22, N'FR        ', N'Anti-rongeurs')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (24, N'FR        ', N'Herbicides')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (26, N'FR        ', N'Adjuvants')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (27, N'FR        ', N'Anti-limaces')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (29, N'FR        ', N'Fongicides')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (31, N'FR        ', N'Inoculants')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (35, N'EN        ', N'Herbicide')
INSERT [dbo].[TypeArticle] ([IdType], [CodeLangue], [Libelle]) VALUES (37, N'ES        ', N'Antibabosas')
SET IDENTITY_INSERT [dbo].[TypeArticle] OFF
GO
