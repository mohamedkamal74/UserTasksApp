using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTasks.Migrations
{
    public partial class RenameUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_appUsers_AppUserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appUsers",
                table: "appUsers");

            migrationBuilder.RenameTable(
                name: "appUsers",
                newName: "AppUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AppUsers_AppUserId",
                table: "Tasks",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AppUsers_AppUserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "appUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appUsers",
                table: "appUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_appUsers_AppUserId",
                table: "Tasks",
                column: "AppUserId",
                principalTable: "appUsers",
                principalColumn: "Id");
        }
    }
}
