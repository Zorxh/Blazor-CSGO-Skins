using Microsoft.EntityFrameworkCore.Migrations;

namespace CSGOSkinsWeb.Database.Migrations.Migrations
{
    public partial class AddedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cee0fcf-add3-400d-89ac-7cec1cf1a9ed", "0711ae0e-56a5-469a-a639-502533263d53", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e902b58-4eb0-4071-9c50-ebde698cc0d0", "25081b0e-59e0-4cb7-9e03-ccff8323d308", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e902b58-4eb0-4071-9c50-ebde698cc0d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cee0fcf-add3-400d-89ac-7cec1cf1a9ed");
        }
    }
}
