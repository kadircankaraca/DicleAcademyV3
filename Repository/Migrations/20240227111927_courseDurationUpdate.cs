using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class courseDurationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c48361d-7fcc-48c4-8b2b-c92eab661225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d69fb399-07d3-4bfa-acbd-16e73c9c8098");

            migrationBuilder.AlterColumn<double>(
                name: "CourseDuration",
                table: "CoursesDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b08ab18-facb-496a-8e87-33886e24c8d8", null, "User", "USER" },
                    { "a2f24705-a21f-4b6d-b843-6b2cc7a28130", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b08ab18-facb-496a-8e87-33886e24c8d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2f24705-a21f-4b6d-b843-6b2cc7a28130");

            migrationBuilder.AlterColumn<int>(
                name: "CourseDuration",
                table: "CoursesDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c48361d-7fcc-48c4-8b2b-c92eab661225", null, "User", "USER" },
                    { "d69fb399-07d3-4bfa-acbd-16e73c9c8098", null, "Admin", "ADMIN" }
                });
        }
    }
}
