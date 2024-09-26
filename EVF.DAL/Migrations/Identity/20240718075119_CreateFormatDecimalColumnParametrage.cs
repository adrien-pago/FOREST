using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class CreateFormatDecimalColumnParametrage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
   


            migrationBuilder.AddColumn<string>(
                name: "DecimalFormat",
                table: "Parametrage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "en-US");


         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "DecimalFormat",
                table: "Parametrage");


        }
    }
}
