USE [EVF_DEV]
GO
/****** Object:  Table [dbo].[PatchNote]    Script Date: 15/07/2024 14:52:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarifArticle]    Script Date: 15/07/2024 14:52:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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
