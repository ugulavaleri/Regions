using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddTestToDifficultyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "Difficulties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "Difficulties");
        }
    }
}
