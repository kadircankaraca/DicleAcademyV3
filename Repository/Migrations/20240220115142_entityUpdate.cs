using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class entityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06d3d187-6a73-4d87-a061-bd27cba2a784");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3d22c67-17a3-46a1-b532-0eb113b32ea6");

            migrationBuilder.AddColumn<string>(
                name: "SkillImage",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21ccbe4c-5d10-449c-b322-94bf31c49e9e", null, "User", "USER" },
                    { "a22054b1-67ac-4283-8968-33ecc34ccb80", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21ccbe4c-5d10-449c-b322-94bf31c49e9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a22054b1-67ac-4283-8968-33ecc34ccb80");

            migrationBuilder.DropColumn(
                name: "SkillImage",
                table: "Skills");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d3d187-6a73-4d87-a061-bd27cba2a784", null, "User", "USER" },
                    { "b3d22c67-17a3-46a1-b532-0eb113b32ea6", null, "Admin", "ADMIN" }
                });
        }
    }
}
