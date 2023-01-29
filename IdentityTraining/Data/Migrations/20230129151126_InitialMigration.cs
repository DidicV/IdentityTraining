using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityTraining.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "036781d8-3785-4141-b52b-8485fedd418c", "53e7c1cd-9abc-4015-9c2f-8468c820e6ed", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c969a26-8283-4de8-9ac5-3badd7bb1a1b", "6ac89118-a69c-4148-8b19-85cfc998155e", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "036781d8-3785-4141-b52b-8485fedd418c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c969a26-8283-4de8-9ac5-3badd7bb1a1b");
        }
    }
}
