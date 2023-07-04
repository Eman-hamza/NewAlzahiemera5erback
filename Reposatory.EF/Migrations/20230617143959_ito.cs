using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reposatory.EF.Migrations
{
    /// <inheritdoc />
    public partial class ito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
