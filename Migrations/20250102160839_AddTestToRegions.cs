using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddTestToRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Regions");
        }
    }
}
