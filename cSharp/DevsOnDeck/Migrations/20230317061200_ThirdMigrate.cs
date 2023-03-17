using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevsOnDeck.Migrations
{
    public partial class ThirdMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevSkills_Devs_DevId",
                table: "DevSkills");

            migrationBuilder.DropTable(
                name: "Devs");

            migrationBuilder.RenameColumn(
                name: "DevId",
                table: "DevSkills",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DevSkills_DevId",
                table: "DevSkills",
                newName: "IX_DevSkills_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevSkills_Users_UserId",
                table: "DevSkills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevSkills_Users_UserId",
                table: "DevSkills");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DevSkills",
                newName: "DevId");

            migrationBuilder.RenameIndex(
                name: "IX_DevSkills_UserId",
                table: "DevSkills",
                newName: "IX_DevSkills_DevId");

            migrationBuilder.CreateTable(
                name: "Devs",
                columns: table => new
                {
                    DevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devs", x => x.DevId);
                    table.ForeignKey(
                        name: "FK_Devs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Devs_UserId",
                table: "Devs",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DevSkills_Devs_DevId",
                table: "DevSkills",
                column: "DevId",
                principalTable: "Devs",
                principalColumn: "DevId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
