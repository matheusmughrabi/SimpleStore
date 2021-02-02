using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleStore.DataAccess.Migrations
{
    public partial class Renames_RoleTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PermissionTitle",
                table: "Roles",
                newName: "RoleTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleTitle",
                table: "Roles",
                newName: "PermissionTitle");
        }
    }
}
