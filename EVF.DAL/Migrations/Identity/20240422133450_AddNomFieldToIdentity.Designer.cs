﻿// <auto-generated />
using System;
using EVF.DAL.DataConnection.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EVF.DAL.Migrations.Identity
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20240422133450_AddNomFieldToIdentity")]
    partial class AddNomFieldToIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArticleDivision", b =>
                {
                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdDivision")
                        .HasColumnType("int");

                    b.HasKey("IdArticle", "IdDivision");

                    b.HasIndex("IdDivision");

                    b.ToTable("ArticleDivision");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Article", b =>
                {
                    b.Property<int>("IdArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticle"));

                    b.Property<string>("CodeSap")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CodeSAP");

                    b.Property<int?>("IdType")
                        .HasColumnType("int");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdArticle");

                    b.HasIndex("IdType");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("CodeSap")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("CodeSAP");

                    b.Property<string>("Isopays")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("ISOPays");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Region")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdClient");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Division", b =>
                {
                    b.Property<int>("IdDivision")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDivision"));

                    b.Property<string>("CodeDivision")
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)");

                    b.Property<int?>("IdSociete")
                        .HasColumnType("int");

                    b.HasKey("IdDivision");

                    b.HasIndex("IdSociete");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.LibelleArticle", b =>
                {
                    b.Property<int>("IdLibelleArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibelleArticle"));

                    b.Property<string>("CodeLangue")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("IdArticle")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdLibelleArticle");

                    b.HasIndex("IdArticle");

                    b.ToTable("LibelleArticle");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Personnel", b =>
                {
                    b.Property<int>("IdPersonnel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonnel"));

                    b.Property<string>("CodeSap")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CodeSAP");

                    b.Property<string>("Email")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<int?>("IdSociete")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPersonnel");

                    b.HasIndex("IdSociete");

                    b.ToTable("Personnel");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Prevision", b =>
                {
                    b.Property<int>("IdPrevision")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrevision"));

                    b.Property<int?>("Annee")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreation")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateModification")
                        .HasColumnType("date");

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCommercial")
                        .HasColumnType("int");

                    b.Property<int?>("Mois")
                        .HasColumnType("int");

                    b.Property<string>("Volume")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdPrevision");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdCommercial");

                    b.ToTable("Prevision");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Societe", b =>
                {
                    b.Property<int>("IdSociete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSociete"));

                    b.Property<string>("CodeLangue")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CodeSociete")
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("NomSociete")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OrgCommerciale")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdSociete");

                    b.ToTable("Societe");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.SocieteClient", b =>
                {
                    b.Property<int>("IdSociete")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCommercial")
                        .HasColumnType("int");

                    b.Property<int>("IdAssistantCommercial")
                        .HasColumnType("int");

                    b.HasKey("IdSociete", "IdClient", "IdCommercial", "IdAssistantCommercial");

                    b.HasIndex("IdAssistantCommercial");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdCommercial");

                    b.ToTable("SocieteClient");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.TypeArticle", b =>
                {
                    b.Property<int>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdType"));

                    b.Property<string>("CodeLangue")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Libelle")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdType");

                    b.ToTable("TypeArticle");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.VentePortefeuille", b =>
                {
                    b.Property<int>("IdVentePort")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVentePort"));

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCommercial")
                        .HasColumnType("int");

                    b.Property<int>("Mois")
                        .HasColumnType("int");

                    b.Property<bool>("TypeVentePort")
                        .HasColumnType("bit");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdVentePort");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdCommercial");

                    b.ToTable("VentePortefeuille");
                });

            modelBuilder.Entity("EVF.DAL.Entity.Identity.Parametrage", b =>
                {
                    b.Property<int>("IdParametrage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdParametrage"));

                    b.Property<string>("IdAspUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LangueBD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdParametrage");

                    b.HasIndex("IdAspUser")
                        .IsUnique();

                    b.ToTable("Parametrage");
                });

            modelBuilder.Entity("EVF.DAL.Entity.Identity.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("IdPersonnel")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdPersonnel");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3dc56bb9-30f1-4e1b-9d63-3728fe333d0a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bf7268f6-42ee-4021-b18f-ccc2041c1cb0",
                            Email = "moni@gmail.com",
                            EmailConfirmed = false,
                            IdPersonnel = 4,
                            LockoutEnabled = false,
                            NormalizedEmail = "MONI@GMAIL.COM",
                            NormalizedUserName = "MONICA00",
                            PasswordHash = "AQAAAAIAAYagAAAAECfBPOIdWPEsgPoHUlqTy0+8fYJxQNueQ5TKMq0aFdjLGiqd1zff+xrqY8wxYu8sVA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "42d136c4-4123-4a9e-b858-1bd86640a111",
                            TwoFactorEnabled = false,
                            UserName = "MONICA00"
                        },
                        new
                        {
                            Id = "f3eb09d7-d639-4a58-abaa-8932d703bd56",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6acc7c12-367d-4788-bc67-16536a8afc94",
                            Email = "arii@yahoo.com",
                            EmailConfirmed = false,
                            IdPersonnel = 10,
                            LockoutEnabled = false,
                            NormalizedEmail = "ARII@YAHOO.COM",
                            NormalizedUserName = "ARIA01",
                            PasswordHash = "AQAAAAIAAYagAAAAEENtue9nj7OaFLz3Dgb2l1jgYS3s1+VqPuJDJrX0FoVu1rCue+6dVOni26eWwY/R1A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "375ad0b5-7a1b-4f35-9daf-2d70fa420421",
                            TwoFactorEnabled = false,
                            UserName = "ARIA01"
                        },
                        new
                        {
                            Id = "88588f56-5a9a-486c-83e6-f3c9f475aa9d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5896fcb3-21b5-4294-b382-f8c2d5f81831",
                            Email = "BesnardFab@gmail.com",
                            EmailConfirmed = false,
                            IdPersonnel = 33,
                            LockoutEnabled = false,
                            NormalizedEmail = "BESNARDFAB@GMAIL.COM",
                            NormalizedUserName = "BESNARDFAB",
                            PasswordHash = "AQAAAAIAAYagAAAAEOeHajEX76s38Djl1NKp/TNa5jWni0inMuC5i3zEH349ltoD7SFIweb5pjk4d3nZgg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d44ff27d-2c3c-4373-8dbe-5b01370a3292",
                            TwoFactorEnabled = false,
                            UserName = "BESNARDFAB"
                        },
                        new
                        {
                            Id = "0afcc4d7-0442-4a26-ba82-369b887c3a8a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "999d1606-1a70-4728-82a5-2aa0013f4472",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "EAVF$2",
                            PasswordHash = "AQAAAAIAAYagAAAAENpy6bas5qT5+ky89as9u3bhbvQJ4sv5aBtj1WgzDkAhx6rwhd1pFuCpQGEsH2rRKQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5a36a1b5-5e00-4dd3-9ee6-1889a4128c8c",
                            TwoFactorEnabled = false,
                            UserName = "EAVF$2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Commercial",
                            NormalizedName = "CO"
                        },
                        new
                        {
                            Id = "2",
                            Name = "AssistantCommercial",
                            NormalizedName = "AC"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Administrateur",
                            NormalizedName = "ADM"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "3dc56bb9-30f1-4e1b-9d63-3728fe333d0a",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "f3eb09d7-d639-4a58-abaa-8932d703bd56",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "88588f56-5a9a-486c-83e6-f3c9f475aa9d",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "0afcc4d7-0442-4a26-ba82-369b887c3a8a",
                            RoleId = "3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ArticleDivision", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Article", null)
                        .WithMany()
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Division", null)
                        .WithMany()
                        .HasForeignKey("IdDivision")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Article", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.TypeArticle", "IdTypeNavigation")
                        .WithMany("Articles")
                        .HasForeignKey("IdType");

                    b.Navigation("IdTypeNavigation");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Division", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Societe", "IdSocieteNavigation")
                        .WithMany("Divisions")
                        .HasForeignKey("IdSociete");

                    b.Navigation("IdSocieteNavigation");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.LibelleArticle", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Article", "IdArticleNavigation")
                        .WithMany("LibelleArticles")
                        .HasForeignKey("IdArticle");

                    b.Navigation("IdArticleNavigation");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Personnel", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Societe", "IdSocieteNavigation")
                        .WithMany("Personnel")
                        .HasForeignKey("IdSociete");

                    b.Navigation("IdSocieteNavigation");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Prevision", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Article", "IdArticleNavigation")
                        .WithMany("Previsions")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Client", "IdClientNavigation")
                        .WithMany("Previsions")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Personnel", "IdCommercialNavigation")
                        .WithMany("Previsions")
                        .HasForeignKey("IdCommercial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdArticleNavigation");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdCommercialNavigation");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.SocieteClient", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Personnel", "IdAssistantCommercialNavigation")
                        .WithMany("SocieteClientIdAssistantCommercialNavigations")
                        .HasForeignKey("IdAssistantCommercial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Client", "IdClientNavigation")
                        .WithMany("SocieteClients")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Personnel", "IdCommercialNavigation")
                        .WithMany("SocieteClientIdCommercialNavigations")
                        .HasForeignKey("IdCommercial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Societe", "IdSocieteNavigation")
                        .WithMany("SocieteClients")
                        .HasForeignKey("IdSociete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAssistantCommercialNavigation");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdCommercialNavigation");

                    b.Navigation("IdSocieteNavigation");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.VentePortefeuille", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Article", "IdArticleNavigation")
                        .WithMany("VentePortefeuilles")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Client", "IdClientNavigation")
                        .WithMany("VentePortefeuilles")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.EVF.Personnel", "IdCommercialNavigation")
                        .WithMany("VentePortefeuilles")
                        .HasForeignKey("IdCommercial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdArticleNavigation");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdCommercialNavigation");
                });

            modelBuilder.Entity("EVF.DAL.Entity.Identity.Parametrage", b =>
                {
                    b.HasOne("EVF.DAL.Entity.Identity.UserInfo", "UserInfoNav")
                        .WithOne("ParametrageNav")
                        .HasForeignKey("EVF.DAL.Entity.Identity.Parametrage", "IdAspUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfoNav");
                });

            modelBuilder.Entity("EVF.DAL.Entity.Identity.UserInfo", b =>
                {
                    b.HasOne("EVF.DAL.Entity.EVF.Personnel", "PersonnelNav")
                        .WithMany()
                        .HasForeignKey("IdPersonnel");

                    b.Navigation("PersonnelNav");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EVF.DAL.Entity.Identity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EVF.DAL.Entity.Identity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVF.DAL.Entity.Identity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EVF.DAL.Entity.Identity.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Article", b =>
                {
                    b.Navigation("LibelleArticles");

                    b.Navigation("Previsions");

                    b.Navigation("VentePortefeuilles");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Client", b =>
                {
                    b.Navigation("Previsions");

                    b.Navigation("SocieteClients");

                    b.Navigation("VentePortefeuilles");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Personnel", b =>
                {
                    b.Navigation("Previsions");

                    b.Navigation("SocieteClientIdAssistantCommercialNavigations");

                    b.Navigation("SocieteClientIdCommercialNavigations");

                    b.Navigation("VentePortefeuilles");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.Societe", b =>
                {
                    b.Navigation("Divisions");

                    b.Navigation("Personnel");

                    b.Navigation("SocieteClients");
                });

            modelBuilder.Entity("EVF.DAL.Entity.EVF.TypeArticle", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("EVF.DAL.Entity.Identity.UserInfo", b =>
                {
                    b.Navigation("ParametrageNav")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
