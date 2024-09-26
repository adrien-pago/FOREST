USE [EVF_DEV]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[IdArticle] [int] IDENTITY(1,1) NOT NULL,
	[IdType] [int] NULL,
	[CodeSAP] [nvarchar](20) NOT NULL,
	[Unite] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[IdArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleDivision]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleDivision](
	[IdDivision] [int] NOT NULL,
	[IdArticle] [int] NOT NULL,
 CONSTRAINT [PK_Article_Division] PRIMARY KEY CLUSTERED 
(
	[IdArticle] ASC,
	[IdDivision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[CodeSAP] [nvarchar](20) NOT NULL,
	[Libelle] [nvarchar](20) NOT NULL,
	[ISOPays] [nchar](20) NOT NULL,
	[Region] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Client_IdClient] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[IdDivision] [int] IDENTITY(1,1) NOT NULL,
	[IdSociete] [int] NULL,
	[CodeDivision] [varchar](4) NULL,
 CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED 
(
	[IdDivision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibelleArticle]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibelleArticle](
	[IdLibelleArticle] [int] IDENTITY(1,1) NOT NULL,
	[IdArticle] [int] NULL,
	[CodeLangue] [nvarchar](20) NOT NULL,
	[Libelle] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__LibelleA__9A3B6C9DC842A3E8] PRIMARY KEY CLUSTERED 
(
	[IdLibelleArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[IdPersonnel] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](20) NOT NULL,
	[CodeSAP] [nvarchar](20) NOT NULL,
	[IdRole] [int] NOT NULL,
	[IdSociete] [int] NULL,
	[Email] [varchar](20) NULL,
 CONSTRAINT [PK__Personne__B4CE51973BF1F8E2] PRIMARY KEY CLUSTERED 
(
	[IdPersonnel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prevision]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prevision](
	[IdPrevision] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdArticle] [int] NOT NULL,
	[Mois] [nvarchar](2) NULL,
	[Annee] [nvarchar](4) NULL,
	[DateCreation] [date] NULL,
	[DateModification] [date] NULL,
	[Volume] [nvarchar](10) NULL,
	[IdCommercial] [int] NOT NULL,
 CONSTRAINT [PK__Previsio__6FC6E35A7F49B452] PRIMARY KEY CLUSTERED 
(
	[IdPrevision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Societe]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Societe](
	[IdSociete] [int] IDENTITY(1,1) NOT NULL,
	[NomSociete] [nvarchar](20) NOT NULL,
	[OrgCommerciale] [nvarchar](20) NOT NULL,
	[CodeLangue] [nchar](20) NOT NULL,
	[CodeSociete] [varchar](4) NULL,
 CONSTRAINT [PK_Societe_IdSociete] PRIMARY KEY CLUSTERED 
(
	[IdSociete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocieteClient]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocieteClient](
	[IdSociete] [int] NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdCommercial] [int] NOT NULL,
	[IdAssistantCommercial] [int] NOT NULL,
 CONSTRAINT [PK_Societe_Client] PRIMARY KEY CLUSTERED 
(
	[IdSociete] ASC,
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeArticle]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeArticle](
	[IdType] [int] IDENTITY(1,1) NOT NULL,
	[CodeLangue] [nchar](10) NULL,
	[Libelle] [nvarchar](20) NULL,
 CONSTRAINT [PK_TypeArticle] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentePortefeuille]    Script Date: 30/01/2024 13:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentePortefeuille](
	[IdVentePort] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdCommercial] [int] NOT NULL,
	[IdArticle] [int] NOT NULL,
	[Mois] [nvarchar](2) NOT NULL,
	[Annee] [nvarchar](4) NOT NULL,
	[TypeVentePort] [bit] NOT NULL,
	[Volume] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Vente_Portefeuille] PRIMARY KEY CLUSTERED 
(
	[IdVentePort] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ArticleDivision]  WITH CHECK ADD  CONSTRAINT [FK_Article] FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
GO
ALTER TABLE [dbo].[ArticleDivision] CHECK CONSTRAINT [FK_Article]
GO
ALTER TABLE [dbo].[ArticleDivision]  WITH CHECK ADD  CONSTRAINT [FK_Division] FOREIGN KEY([IdDivision])
REFERENCES [dbo].[Division] ([IdDivision])
GO
ALTER TABLE [dbo].[ArticleDivision] CHECK CONSTRAINT [FK_Division]
GO
ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [FK__Division__IdSoci__44FF419A] FOREIGN KEY([IdSociete])
REFERENCES [dbo].[Societe] ([IdSociete])
GO
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [FK__Division__IdSoci__44FF419A]
GO
ALTER TABLE [dbo].[LibelleArticle]  WITH CHECK ADD  CONSTRAINT [FK_Article_LibelleArticle] FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LibelleArticle] CHECK CONSTRAINT [FK_Article_LibelleArticle]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [FK_Societe_Personnel] FOREIGN KEY([IdSociete])
REFERENCES [dbo].[Societe] ([IdSociete])
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [FK_Societe_Personnel]
GO
ALTER TABLE [dbo].[Prevision]  WITH CHECK ADD  CONSTRAINT [FK_Prevision_IdCommercial] FOREIGN KEY([IdCommercial])
REFERENCES [dbo].[Personnel] ([IdPersonnel])
GO
ALTER TABLE [dbo].[Prevision] CHECK CONSTRAINT [FK_Prevision_IdCommercial]
GO
ALTER TABLE [dbo].[Prevision]  WITH CHECK ADD  CONSTRAINT [FK_PrevisionsArticle] FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
GO
ALTER TABLE [dbo].[Prevision] CHECK CONSTRAINT [FK_PrevisionsArticle]
GO
ALTER TABLE [dbo].[Prevision]  WITH CHECK ADD  CONSTRAINT [FK_PrevisionsClient] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Prevision] CHECK CONSTRAINT [FK_PrevisionsClient]
GO
ALTER TABLE [dbo].[SocieteClient]  WITH CHECK ADD  CONSTRAINT [FK_AssistantCommercial] FOREIGN KEY([IdAssistantCommercial])
REFERENCES [dbo].[Personnel] ([IdPersonnel])
GO
ALTER TABLE [dbo].[SocieteClient] CHECK CONSTRAINT [FK_AssistantCommercial]
GO
ALTER TABLE [dbo].[SocieteClient]  WITH CHECK ADD  CONSTRAINT [FK_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[SocieteClient] CHECK CONSTRAINT [FK_Client]
GO
ALTER TABLE [dbo].[SocieteClient]  WITH CHECK ADD  CONSTRAINT [FK_Commercial] FOREIGN KEY([IdCommercial])
REFERENCES [dbo].[Personnel] ([IdPersonnel])
GO
ALTER TABLE [dbo].[SocieteClient] CHECK CONSTRAINT [FK_Commercial]
GO
ALTER TABLE [dbo].[SocieteClient]  WITH CHECK ADD  CONSTRAINT [FK_Societe] FOREIGN KEY([IdSociete])
REFERENCES [dbo].[Societe] ([IdSociete])
GO
ALTER TABLE [dbo].[SocieteClient] CHECK CONSTRAINT [FK_Societe]
GO
ALTER TABLE [dbo].[VentePortefeuille]  WITH CHECK ADD  CONSTRAINT [FK_Article_Vente_Portefeuille] FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
GO
ALTER TABLE [dbo].[VentePortefeuille] CHECK CONSTRAINT [FK_Article_Vente_Portefeuille]
GO
ALTER TABLE [dbo].[VentePortefeuille]  WITH CHECK ADD  CONSTRAINT [FK_Client_Vente_Portefeuille] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[VentePortefeuille] CHECK CONSTRAINT [FK_Client_Vente_Portefeuille]
GO
ALTER TABLE [dbo].[VentePortefeuille]  WITH CHECK ADD  CONSTRAINT [FK_Commercial_Vente_Portefeuille] FOREIGN KEY([IdCommercial])
REFERENCES [dbo].[Personnel] ([IdPersonnel])
GO
ALTER TABLE [dbo].[VentePortefeuille] CHECK CONSTRAINT [FK_Commercial_Vente_Portefeuille]
GO
