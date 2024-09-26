using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreateSaveTypeColumnParametrage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<string>(
                name: "SaveType",
                table: "Parametrage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Individual");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
   


            migrationBuilder.DropColumn(
                name: "SaveType",
                table: "Parametrage");


        }
    }
}
