using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreateVuMAJColumnParametrage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "VuMAJ",
                table: "Parametrage",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "VuMAJ",
                table: "Parametrage");
        }
    }
}
