using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddParametrageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ArticleDivision");

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

            migrationBuilder.CreateTable(
                name: "Parametrage",
                columns: table => new
                {
                    IdParametrage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAspUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LangueBD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametrage", x => x.IdParametrage);
                    table.ForeignKey(
                        name: "FK_Parametrage_AspNetUsers_IdAspUser",
                        column: x => x.IdAspUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdPersonnel", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29e73d51-bdd0-4ec1-9778-474580a5d089", 0, "4422ccfa-fbca-45ed-9f93-f89dba39601d", "arii@yahoo.com", false, 10, false, null, "ARII@YAHOO.COM", "ARIA01", "AQAAAAIAAYagAAAAEESaGP266w681hq+Zp4O76IaFC21oYc28TKzFiAkUWQT3nbmUdcJZgl67AnvlRjTzw==", null, false, "02b3b45f-9de0-4469-8356-e1729c6c50ea", false, "ARIA01" },
                    { "6624642e-3218-4532-91f6-4adc8e495e58", 0, "5a9704ef-5c85-4718-bfa1-3e6ea92254db", "moni@gmail.com", false, 4, false, null, "MONI@GMAIL.COM", "MONICA00", "AQAAAAIAAYagAAAAEOafd2ZRfccaXtR2s3KPLBpn6kWpfRG6xzNBe0AHWStOeLzh6diPVW2oe6HDm44W9g==", null, false, "1fa1f34e-cd7e-4a83-8c3e-bbe0270ff956", false, "MONICA00" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "29e73d51-bdd0-4ec1-9778-474580a5d089" },
                    { "1", "6624642e-3218-4532-91f6-4adc8e495e58" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parametrage_IdAspUser",
                table: "Parametrage",
                column: "IdAspUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametrage");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "29e73d51-bdd0-4ec1-9778-474580a5d089" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "6624642e-3218-4532-91f6-4adc8e495e58" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29e73d51-bdd0-4ec1-9778-474580a5d089");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6624642e-3218-4532-91f6-4adc8e495e58");

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_ArticleDivision_IdDivision",
            //    table: "ArticleDivision",
            //    column: "IdDivision");
        }
    }
}
