USE [EVF_DEV]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 11/09/2024 09:38:30 ******/
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
/****** Object:  Table [dbo].[ArticleDivision]    Script Date: 11/09/2024 09:38:30 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IdPersonnel] [int] NULL,
	[Nom] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[CodeSAP] [nvarchar](10) NOT NULL,
	[Libelle] [nvarchar](200) NOT NULL,
	[ISOPays] [nchar](2) NOT NULL,
	[Region] [nvarchar](3) NULL,
 CONSTRAINT [PK_Client_IdClient] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 11/09/2024 09:38:30 ******/
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
/****** Object:  Table [dbo].[LibelleArticle]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibelleArticle](
	[IdLibelleArticle] [int] IDENTITY(1,1) NOT NULL,
	[IdArticle] [int] NULL,
	[CodeLangue] [nvarchar](20) NOT NULL,
	[Libelle] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK__LibelleA__9A3B6C9DC842A3E8] PRIMARY KEY CLUSTERED 
(
	[IdLibelleArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametrage]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametrage](
	[IdParametrage] [int] IDENTITY(1,1) NOT NULL,
	[IdAspUser] [nvarchar](450) NOT NULL,
	[LangueBD] [nvarchar](max) NOT NULL,
	[VuMAJ] [bit] NOT NULL,
	[FormatDate] [nvarchar](max) NOT NULL,
	[DecimalFormat] [nvarchar](max) NOT NULL,
	[SaveType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Parametrage] PRIMARY KEY CLUSTERED 
(
	[IdParametrage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatchNote]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatchNote](
	[Titre] [nvarchar](50) NULL,
	[Explication] [nvarchar](max) NULL,
	[Date] [date] NULL,
	[IdPatchNote] [int] IDENTITY(1,1) NOT NULL,
	[VersionMajeur] [nvarchar](8) NULL,
	[NumeroCorrectif] [nvarchar](8) NULL,
 CONSTRAINT [PK_PatchNote] PRIMARY KEY CLUSTERED 
(
	[IdPatchNote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[IdPersonnel] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](100) NOT NULL,
	[CodeSAP] [nvarchar](15) NOT NULL,
	[IdRole] [int] NOT NULL,
	[IdSociete] [int] NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK__Personne__B4CE51973BF1F8E2] PRIMARY KEY CLUSTERED 
(
	[IdPersonnel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prevision]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prevision](
	[IdPrevision] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdArticle] [int] NOT NULL,
	[Mois] [int] NULL,
	[Annee] [int] NULL,
	[DateCreation] [date] NULL,
	[DateModification] [date] NULL,
	[Volume] [int] NOT NULL,
	[IdCommercial] [int] NOT NULL,
 CONSTRAINT [PK__Previsio__6FC6E35A7F49B452] PRIMARY KEY CLUSTERED 
(
	[IdPrevision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Societe]    Script Date: 11/09/2024 09:38:30 ******/
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
/****** Object:  Table [dbo].[SocieteClient]    Script Date: 11/09/2024 09:38:30 ******/
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
	[IdClient] ASC,
	[IdCommercial] ASC,
	[IdAssistantCommercial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarifArticle]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarifArticle](
	[IdTarifArticle] [int] IDENTITY(1,1) NOT NULL,
	[IdCommercial] [int] NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdArticle] [int] NOT NULL,
	[TarifA] [decimal](10, 4) NOT NULL,
 CONSTRAINT [PK__TarifArt__3822E55E139AEB8B] PRIMARY KEY CLUSTERED 
(
	[IdTarifArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeArticle]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeArticle](
	[IdType] [int] IDENTITY(1,1) NOT NULL,
	[CodeLangue] [nchar](10) NULL,
	[Libelle] [nvarchar](60) NULL,
 CONSTRAINT [PK_TypeArticle] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentePortefeuille]    Script Date: 11/09/2024 09:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentePortefeuille](
	[IdVentePort] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdCommercial] [int] NOT NULL,
	[IdArticle] [int] NOT NULL,
	[Mois] [int] NOT NULL,
	[Annee] [int] NOT NULL,
	[TypeVentePort] [bit] NOT NULL,
	[Volume] [int] NOT NULL,
 CONSTRAINT [PK_Vente_Portefeuille] PRIMARY KEY CLUSTERED 
(
	[IdVentePort] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Parametrage] ADD  DEFAULT (CONVERT([bit],(0))) FOR [VuMAJ]
GO
ALTER TABLE [dbo].[Parametrage] ADD  DEFAULT (N'yyyy/MM/dd') FOR [FormatDate]
GO
ALTER TABLE [dbo].[Parametrage] ADD  DEFAULT (N'en-US') FOR [DecimalFormat]
GO
ALTER TABLE [dbo].[Parametrage] ADD  DEFAULT (N'Individual') FOR [SaveType]
GO
ALTER TABLE [dbo].[Prevision] ADD  CONSTRAINT [DF_Prevision_Volume]  DEFAULT ((0)) FOR [Volume]
GO
ALTER TABLE [dbo].[VentePortefeuille] ADD  CONSTRAINT [DF_VentePortefeuille_Volume]  DEFAULT ((0)) FOR [Volume]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK__Article__IdType__1F2E9E6D] FOREIGN KEY([IdType])
REFERENCES [dbo].[TypeArticle] ([IdType])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK__Article__IdType__1F2E9E6D]
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
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Personnel_IdPersonnel] FOREIGN KEY([IdPersonnel])
REFERENCES [dbo].[Personnel] ([IdPersonnel])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Personnel_IdPersonnel]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
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
ALTER TABLE [dbo].[Parametrage]  WITH CHECK ADD  CONSTRAINT [FK_Parametrage_AspNetUsers_IdAspUser] FOREIGN KEY([IdAspUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parametrage] CHECK CONSTRAINT [FK_Parametrage_AspNetUsers_IdAspUser]
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
ALTER TABLE [dbo].[TarifArticle]  WITH CHECK ADD  CONSTRAINT [FK_Article_TA] FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
GO
ALTER TABLE [dbo].[TarifArticle] CHECK CONSTRAINT [FK_Article_TA]
GO
ALTER TABLE [dbo].[TarifArticle]  WITH CHECK ADD  CONSTRAINT [FK_Client_TA] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[TarifArticle] CHECK CONSTRAINT [FK_Client_TA]
GO
ALTER TABLE [dbo].[TarifArticle]  WITH CHECK ADD  CONSTRAINT [FK_Personnel_TA] FOREIGN KEY([IdCommercial])
REFERENCES [dbo].[Personnel] ([IdPersonnel])
GO
ALTER TABLE [dbo].[TarifArticle] CHECK CONSTRAINT [FK_Personnel_TA]
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
