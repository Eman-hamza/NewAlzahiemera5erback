using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reposatory.EF.Migrations
{
    /// <inheritdoc />
    public partial class ioo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHelper",
                table: "patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPatient",
                table: "patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHelper",
                table: "Helpers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPatient",
                table: "Helpers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHelper",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "IsPatient",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "IsHelper",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "IsPatient",
                table: "Helpers");
        }
    }
}
