using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVF.DAL.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SetDefaultValueToFormatDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "FormatDate",
                table: "Parametrage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "yyyy/MM/dd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FormatDate",
                table: "Parametrage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "yyyy/MM/dd");
        }
    }
}
