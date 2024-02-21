using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class courseNameDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CourseName",
                table: "BestCourses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e5a1674-0570-49e1-a394-73014774b02e", null, "Admin", "ADMIN" },
                    { "25192209-3061-4ab3-a738-545c4494543d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e5a1674-0570-49e1-a394-73014774b02e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25192209-3061-4ab3-a738-545c4494543d");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "BestCourses",
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
    }
}
