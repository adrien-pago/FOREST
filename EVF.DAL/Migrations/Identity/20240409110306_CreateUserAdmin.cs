using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreateUserAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "52cb545b-0d32-48e6-a658-581d6063a3be" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "8bdb6ec9-bc56-4b0b-ae94-760bddcb52eb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "b3a98629-23dc-448d-b0f3-a6630a0b7b95" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52cb545b-0d32-48e6-a658-581d6063a3be");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bdb6ec9-bc56-4b0b-ae94-760bddcb52eb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3a98629-23dc-448d-b0f3-a6630a0b7b95");

 

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdPersonnel", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29c41957-b154-41e1-9350-629687cd371f", 0, "42823373-703b-4d5c-bf25-c3678b1507c4", "moni@gmail.com", false, 4, false, null, "MONI@GMAIL.COM", "MONICA00", "AQAAAAIAAYagAAAAENxMyFBcc7VPmNXmcaxMhVIXRzsSF1BQvFSPRmv6adoU8qg8IY0O7Qd9FxZ0MmpS/g==", null, false, "ea06d09d-73ab-4862-a5ee-89fed636f886", false, "MONICA00" },
                    { "4a20aa89-cac2-4749-b014-81437a92bf20", 0, "e807e050-51ea-4881-a676-6b3b5877b133", "arii@yahoo.com", false, 10, false, null, "ARII@YAHOO.COM", "ARIA01", "AQAAAAIAAYagAAAAEOAs5O3lE888AiAYjeKNgK5JNJQYdYf5Xp8heXgVRzamlm9rNvb2/vXLQ4/XKNAnYg==", null, false, "e4df51f3-e84f-4024-96ff-84edb648ccb2", false, "ARIA01" },
                    { "96a43a58-5170-4c36-9b08-e1ff36f37ede", 0, "c894e338-e2a6-4336-8e97-306dd6b68a81", null, false, null, false, null, null, "EAVF$2", "AQAAAAIAAYagAAAAEDp0KyRE1wBO/SmqdKRxzGRkZ5Zh7CBX9hD++BEZSTBGOhM8gBiwMZ35unmsDmiWDQ==", null, false, "6206cd67-4677-46a5-93d7-7752aebfbd5d", false, "EAVF$2" },
                    { "d8d863a2-8de8-4b0c-a861-377a13b9982a", 0, "6a458fe0-79b2-4fa3-a1b9-27364b7c23fa", "BesnardFab@gmail.com", false, 33, false, null, "BESNARDFAB@GMAIL.COM", "BESNARDFAB", "AQAAAAIAAYagAAAAEHF7+PtP1QRb6u5dmiu8W+pG7P71guDY81a0j2Whs8UJCzS3tSq4eB861hH+s0M9yA==", null, false, "8a4bd331-4ace-4526-b47b-f7aeb2f87a03", false, "BESNARDFAB" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "29c41957-b154-41e1-9350-629687cd371f" },
                    { "2", "4a20aa89-cac2-4749-b014-81437a92bf20" },
                    { "3", "96a43a58-5170-4c36-9b08-e1ff36f37ede" },
                    { "1", "d8d863a2-8de8-4b0c-a861-377a13b9982a" }
                });

        

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "29c41957-b154-41e1-9350-629687cd371f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "4a20aa89-cac2-4749-b014-81437a92bf20" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "96a43a58-5170-4c36-9b08-e1ff36f37ede" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "d8d863a2-8de8-4b0c-a861-377a13b9982a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29c41957-b154-41e1-9350-629687cd371f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a20aa89-cac2-4749-b014-81437a92bf20");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96a43a58-5170-4c36-9b08-e1ff36f37ede");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d863a2-8de8-4b0c-a861-377a13b9982a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdPersonnel", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "52cb545b-0d32-48e6-a658-581d6063a3be", 0, "f413934f-6305-44d4-bc21-a2953177c58b", "moni@gmail.com", false, 4, false, null, "MONI@GMAIL.COM", "MONICA00", "AQAAAAIAAYagAAAAEFD29r1htdzNxxI4PeACzY61hkw102eWwJbrBGLdLlnxd7L3nru5wyo45ZVm2gz6pA==", null, false, "3dd24e85-6895-491c-af73-407bc3698d9c", false, "MONICA00" },
                    { "8bdb6ec9-bc56-4b0b-ae94-760bddcb52eb", 0, "4cbe2124-135c-4401-81df-0e0d5ee1ca76", "arii@yahoo.com", false, 10, false, null, "ARII@YAHOO.COM", "ARIA01", "AQAAAAIAAYagAAAAEOYZP2SQPyGR2wg3Hf/nuUZVYmiKaDDbcK9nm7Zd6bYdFmhqydm9eOGmnnjNjbwpuQ==", null, false, "13a76623-4c56-4c2f-92a0-232ef73e772f", false, "ARIA01" },
                    { "b3a98629-23dc-448d-b0f3-a6630a0b7b95", 0, "c3238399-6df2-4d04-9e68-ffd26c5e1e96", "BesnardFab@gmail.com", false, 33, false, null, "BESNARDFAB@GMAIL.COM", "BESNARDFAB", "AQAAAAIAAYagAAAAED1MjbTsfPJ6gQVJgVHM0KqpRnyAFHVlBdzjsCgCW6oLMW+jKl1RMprCXdTCapk+2g==", null, false, "64f3e43f-9f9b-4ceb-8207-578667817706", false, "BESNARDFAB" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "52cb545b-0d32-48e6-a658-581d6063a3be" },
                    { "2", "8bdb6ec9-bc56-4b0b-ae94-760bddcb52eb" },
                    { "1", "b3a98629-23dc-448d-b0f3-a6630a0b7b95" }
                });
        }
    }
}
