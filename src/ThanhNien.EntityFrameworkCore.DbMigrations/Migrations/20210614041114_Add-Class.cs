using Microsoft.EntityFrameworkCore.Migrations;

namespace ThanhNien.Migrations
{
    public partial class AddClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "AppUserResults",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentCode",
                table: "AppUserResults",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "AppUserResults");

            migrationBuilder.DropColumn(
                name: "StudentCode",
                table: "AppUserResults");
        }
    }
}
