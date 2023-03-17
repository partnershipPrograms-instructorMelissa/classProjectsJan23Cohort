using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevsOnDeck.Migrations
{
    public partial class FifthMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrameOrder",
                table: "DevSkills");

            migrationBuilder.DropColumn(
                name: "LangOrder",
                table: "DevSkills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FrameOrder",
                table: "DevSkills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LangOrder",
                table: "DevSkills",
                type: "int",
                nullable: true);
        }
    }
}
