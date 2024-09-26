using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreateFormatDateColumnParametrage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        


            migrationBuilder.AddColumn<string>(
                name: "FormatDate",
                table: "Parametrage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "FormatDate",
                table: "Parametrage");

        }
    }
}
