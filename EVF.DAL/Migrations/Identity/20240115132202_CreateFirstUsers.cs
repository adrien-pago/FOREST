using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreateFirstUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Commercial", "CO" },
                    { "2", null, "AssistantCommercial", "AC" },
                    { "3", null, "Administrateur", "ADM" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "3aafb8cf-5dbf-4171-9e55-0d00b013aa06" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "f224cc8f-e737-44ef-b2ac-33b7f3f0aefd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aafb8cf-5dbf-4171-9e55-0d00b013aa06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f224cc8f-e737-44ef-b2ac-33b7f3f0aefd");
        }
    }
}
