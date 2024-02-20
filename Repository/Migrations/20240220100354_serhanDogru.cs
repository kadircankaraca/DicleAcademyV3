using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class serhanDogru : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cb67158-5bea-4ecc-9aa5-40175b7513b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff548915-cfc2-486b-b8f3-b74c1358ce78");

            migrationBuilder.AddColumn<string>(
                name: "InstructorImage",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d3d187-6a73-4d87-a061-bd27cba2a784", null, "User", "USER" },
                    { "b3d22c67-17a3-46a1-b532-0eb113b32ea6", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06d3d187-6a73-4d87-a061-bd27cba2a784");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3d22c67-17a3-46a1-b532-0eb113b32ea6");

            migrationBuilder.DropColumn(
                name: "InstructorImage",
                table: "Instructors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cb67158-5bea-4ecc-9aa5-40175b7513b7", null, "Admin", "ADMIN" },
                    { "ff548915-cfc2-486b-b8f3-b74c1358ce78", null, "User", "USER" }
                });
        }
    }
}
