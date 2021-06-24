using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThanhNien.Migrations
{
    public partial class AddDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AppUserResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDepartments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserResults_DepartmentId",
                table: "AppUserResults",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserResults_AppDepartments_DepartmentId",
                table: "AppUserResults",
                column: "DepartmentId",
                principalTable: "AppDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserResults_AppDepartments_DepartmentId",
                table: "AppUserResults");

            migrationBuilder.DropTable(
                name: "AppDepartments");

            migrationBuilder.DropIndex(
                name: "IX_AppUserResults_DepartmentId",
                table: "AppUserResults");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AppUserResults");
        }
    }
}
