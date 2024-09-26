using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddIdPersonnelColumnInIdentityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "3aafb8cf-5dbf-4171-9e55-0d00b013aa06" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "f224cc8f-e737-44ef-b2ac-33b7f3f0aefd" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aafb8cf-5dbf-4171-9e55-0d00b013aa06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f224cc8f-e737-44ef-b2ac-33b7f3f0aefd");

            migrationBuilder.AddColumn<int>(
                name: "IdPersonnel",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Article",
            //    columns: table => new
            //    {
            //        IdArticle = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdType = table.Column<int>(type: "int", nullable: true),
            //        CodeSAP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Unite = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Article", x => x.IdArticle);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Client",
            //    columns: table => new
            //    {
            //        IdClient = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CodeSAP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Libelle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        ISOPays = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Region = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Client", x => x.IdClient);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Societe",
            //    columns: table => new
            //    {
            //        IdSociete = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NomSociete = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        OrgCommerciale = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        CodeLangue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        CodeSociete = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Societe", x => x.IdSociete);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LibelleArticle",
            //    columns: table => new
            //    {
            //        IdLibelleArticle = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdArticle = table.Column<int>(type: "int", nullable: true),
            //        CodeLangue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        Libelle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LibelleArticle", x => x.IdLibelleArticle);
            //        table.ForeignKey(
            //            name: "FK_LibelleArticle_Article_IdArticle",
            //            column: x => x.IdArticle,
            //            principalTable: "Article",
            //            principalColumn: "IdArticle");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Division",
            //    columns: table => new
            //    {
            //        IdDivision = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdSociete = table.Column<int>(type: "int", nullable: true),
            //        CodeDivision = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Division", x => x.IdDivision);
            //        table.ForeignKey(
            //            name: "FK_Division_Societe_IdSociete",
            //            column: x => x.IdSociete,
            //            principalTable: "Societe",
            //            principalColumn: "IdSociete");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Personnel",
            //    columns: table => new
            //    {
            //        IdPersonnel = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        CodeSAP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        IdRole = table.Column<int>(type: "int", nullable: false),
            //        IdSociete = table.Column<int>(type: "int", nullable: true),
            //        Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Personnel", x => x.IdPersonnel);
            //        table.ForeignKey(
            //            name: "FK_Personnel_Societe_IdSociete",
            //            column: x => x.IdSociete,
            //            principalTable: "Societe",
            //            principalColumn: "IdSociete");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ArticleDivision",
            //    columns: table => new
            //    {
            //        IdArticle = table.Column<int>(type: "int", nullable: false),
            //        IdDivision = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ArticleDivision", x => new { x.IdArticle, x.IdDivision });
            //        table.ForeignKey(
            //            name: "FK_ArticleDivision_Article_IdArticle",
            //            column: x => x.IdArticle,
            //            principalTable: "Article",
            //            principalColumn: "IdArticle",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ArticleDivision_Division_IdDivision",
            //            column: x => x.IdDivision,
            //            principalTable: "Division",
            //            principalColumn: "IdDivision",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Prevision",
            //    columns: table => new
            //    {
            //        IdPrevision = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdClient = table.Column<int>(type: "int", nullable: false),
            //        IdArticle = table.Column<int>(type: "int", nullable: false),
            //        Mois = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
            //        Annee = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
            //        DateCreation = table.Column<DateTime>(type: "date", nullable: true),
            //        DateModification = table.Column<DateTime>(type: "date", nullable: true),
            //        Volume = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
            //        IdCommercial = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Prevision", x => x.IdPrevision);
            //        table.ForeignKey(
            //            name: "FK_Prevision_Article_IdArticle",
            //            column: x => x.IdArticle,
            //            principalTable: "Article",
            //            principalColumn: "IdArticle",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Prevision_Client_IdClient",
            //            column: x => x.IdClient,
            //            principalTable: "Client",
            //            principalColumn: "IdClient",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Prevision_Personnel_IdCommercial",
            //            column: x => x.IdCommercial,
            //            principalTable: "Personnel",
            //            principalColumn: "IdPersonnel",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SocieteClient",
            //    columns: table => new
            //    {
            //        IdSociete = table.Column<int>(type: "int", nullable: false),
            //        IdClient = table.Column<int>(type: "int", nullable: false),
            //        IdCommercial = table.Column<int>(type: "int", nullable: false),
            //        IdAssistantCommercial = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SocieteClient", x => new { x.IdSociete, x.IdClient });
            //        table.ForeignKey(
            //            name: "FK_SocieteClient_Client_IdClient",
            //            column: x => x.IdClient,
            //            principalTable: "Client",
            //            principalColumn: "IdClient",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_SocieteClient_Personnel_IdAssistantCommercial",
            //            column: x => x.IdAssistantCommercial,
            //            principalTable: "Personnel",
            //            principalColumn: "IdPersonnel",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_SocieteClient_Personnel_IdCommercial",
            //            column: x => x.IdCommercial,
            //            principalTable: "Personnel",
            //            principalColumn: "IdPersonnel",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_SocieteClient_Societe_IdSociete",
            //            column: x => x.IdSociete,
            //            principalTable: "Societe",
            //            principalColumn: "IdSociete",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VentePortefeuille",
            //    columns: table => new
            //    {
            //        IdVentePort = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdClient = table.Column<int>(type: "int", nullable: false),
            //        IdCommercial = table.Column<int>(type: "int", nullable: false),
            //        IdArticle = table.Column<int>(type: "int", nullable: false),
            //        Mois = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
            //        Annee = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
            //        TypeVentePort = table.Column<bool>(type: "bit", nullable: false),
            //        Volume = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VentePortefeuille", x => x.IdVentePort);
            //        table.ForeignKey(
            //            name: "FK_VentePortefeuille_Article_IdArticle",
            //            column: x => x.IdArticle,
            //            principalTable: "Article",
            //            principalColumn: "IdArticle",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_VentePortefeuille_Client_IdClient",
            //            column: x => x.IdClient,
            //            principalTable: "Client",
            //            principalColumn: "IdClient",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_VentePortefeuille_Personnel_IdCommercial",
            //            column: x => x.IdCommercial,
            //            principalTable: "Personnel",
            //            principalColumn: "IdPersonnel",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdPersonnel", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21244986-da1d-4d3c-ab31-4e23a57e44f3", 0, "8d069240-da38-4952-9909-b663f7f44d36", "arii@yahoo.com", false, 10, false, null, "ARII@YAHOO.COM", "ARIA01", "AQAAAAIAAYagAAAAEPm7SLK6ujUydOq5xMwNeNjt/+GEGVfsnBLCT7uwMdLOZcNcR4XNHZ9s9CozJMs1sw==", null, false, "0b2a3d84-7171-4cd7-8037-04b445a599bd", false, "ARIA01" },
                    { "e57be925-ce74-47b0-b975-034e7961958b", 0, "fbfeff00-b928-412c-934d-90ccabd1294c", "moni@gmail.com", false, 4, false, null, "MONI@GMAIL.COM", "MONICA00", "AQAAAAIAAYagAAAAEHxRFs/fDcvMOkIYGEyVV+mnKhiim4O9qJfPsQ6GsYS3B2JnTE7+YN5TdRalZJ2taA==", null, false, "d7f83670-df8a-4b46-bbae-69dd34fc4a34", false, "MONICA00" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "21244986-da1d-4d3c-ab31-4e23a57e44f3" },
                    { "1", "e57be925-ce74-47b0-b975-034e7961958b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdPersonnel",
                table: "AspNetUsers",
                column: "IdPersonnel");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArticleDivision_IdDivision",
            //    table: "ArticleDivision",
            //    column: "IdDivision");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Division_IdSociete",
            //    table: "Division",
            //    column: "IdSociete");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LibelleArticle_IdArticle",
            //    table: "LibelleArticle",
            //    column: "IdArticle");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Personnel_IdSociete",
            //    table: "Personnel",
            //    column: "IdSociete");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Prevision_IdArticle",
            //    table: "Prevision",
            //    column: "IdArticle");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Prevision_IdClient",
            //    table: "Prevision",
            //    column: "IdClient");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Prevision_IdCommercial",
            //    table: "Prevision",
            //    column: "IdCommercial");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SocieteClient_IdAssistantCommercial",
            //    table: "SocieteClient",
            //    column: "IdAssistantCommercial");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SocieteClient_IdClient",
            //    table: "SocieteClient",
            //    column: "IdClient");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SocieteClient_IdCommercial",
            //    table: "SocieteClient",
            //    column: "IdCommercial");

            //migrationBuilder.CreateIndex(
            //    name: "IX_VentePortefeuille_IdArticle",
            //    table: "VentePortefeuille",
            //    column: "IdArticle");

            //migrationBuilder.CreateIndex(
            //    name: "IX_VentePortefeuille_IdClient",
            //    table: "VentePortefeuille",
            //    column: "IdClient");

            //migrationBuilder.CreateIndex(
            //    name: "IX_VentePortefeuille_IdCommercial",
            //    table: "VentePortefeuille",
            //    column: "IdCommercial");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Personnel_IdPersonnel",
                table: "AspNetUsers",
                column: "IdPersonnel",
                principalTable: "Personnel",
                principalColumn: "IdPersonnel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Personnel_IdPersonnel",
                table: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "ArticleDivision");

            //migrationBuilder.DropTable(
            //    name: "LibelleArticle");

            //migrationBuilder.DropTable(
            //    name: "Prevision");

            //migrationBuilder.DropTable(
            //    name: "SocieteClient");

            //migrationBuilder.DropTable(
            //    name: "VentePortefeuille");

            //migrationBuilder.DropTable(
            //    name: "Division");

            //migrationBuilder.DropTable(
            //    name: "Article");

            //migrationBuilder.DropTable(
            //    name: "Client");

            //migrationBuilder.DropTable(
            //    name: "Personnel");

            //migrationBuilder.DropTable(
            //    name: "Societe");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdPersonnel",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "21244986-da1d-4d3c-ab31-4e23a57e44f3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e57be925-ce74-47b0-b975-034e7961958b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21244986-da1d-4d3c-ab31-4e23a57e44f3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e57be925-ce74-47b0-b975-034e7961958b");

            migrationBuilder.DropColumn(
                name: "IdPersonnel",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3aafb8cf-5dbf-4171-9e55-0d00b013aa06", 0, "118f1425-f452-4187-bd16-bdd1c51509e7", null, false, false, null, null, "ARIA01", "AQAAAAIAAYagAAAAEHlmMQneIiWu56JzImHn66WBTkQr6ev/j6yFb34ZkJHpTiRhsQ3v2Ga+E4U7LXAIWA==", null, false, "607cec99-be66-4a21-8472-429e621507d3", false, "ARIA01" },
                    { "f224cc8f-e737-44ef-b2ac-33b7f3f0aefd", 0, "fe81cfd4-e8a0-462f-b707-7a7417610145", null, false, false, null, null, "MONICA00", "AQAAAAIAAYagAAAAEKwVbvTuROSt4ZFMn4dg95Z5u8pPtVRcARId73qw1j7aOamBoBsWaZjbCQG+lAFAJw==", null, false, "bba9a7eb-138b-4273-a8c2-17f60934ff75", false, "MONICA00" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "3aafb8cf-5dbf-4171-9e55-0d00b013aa06" },
                    { "1", "f224cc8f-e737-44ef-b2ac-33b7f3f0aefd" }
                });
        }
    }
}
