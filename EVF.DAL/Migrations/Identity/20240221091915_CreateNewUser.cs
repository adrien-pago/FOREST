using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreateNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

      
        }
    }
}
