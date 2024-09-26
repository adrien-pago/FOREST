using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class RecreateAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdPersonnel", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "075428ed-8c0d-4abf-8284-ff3a5ecc0924", 0, "0e222177-ed2d-4cbb-8afa-bafd0ca53d4c", null, false, null, false, null, null, null, "EAVF$2", "AQAAAAIAAYagAAAAEAsB5j+SOWTqlOed2/hkC8goVfXnrn9+uRjKFr/xZUh/sLp9OW+4qmig25AHfxvqWw==", null, false, "7502f24b-6ced-4cfe-b65e-3e22ff777835", false, "EAVF$2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "075428ed-8c0d-4abf-8284-ff3a5ecc0924" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdPersonnel", "LockoutEnabled", "LockoutEnd", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0afcc4d7-0442-4a26-ba82-369b887c3a8a", 0, "999d1606-1a70-4728-82a5-2aa0013f4472", null, false, null, false, null, null, null, "EAVF$2", "AQAAAAIAAYagAAAAENpy6bas5qT5+ky89as9u3bhbvQJ4sv5aBtj1WgzDkAhx6rwhd1pFuCpQGEsH2rRKQ==", null, false, "5a36a1b5-5e00-4dd3-9ee6-1889a4128c8c", false, "EAVF$2" },

                });

        }
    }
}
