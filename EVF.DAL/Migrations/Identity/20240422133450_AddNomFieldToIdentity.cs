using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddNomFieldToIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

        }
    }
}
