using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class CourseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e5a1674-0570-49e1-a394-73014774b02e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25192209-3061-4ab3-a738-545c4494543d");

            migrationBuilder.DropColumn(
                name: "InstructorsName",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c48361d-7fcc-48c4-8b2b-c92eab661225", null, "User", "USER" },
                    { "d69fb399-07d3-4bfa-acbd-16e73c9c8098", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c48361d-7fcc-48c4-8b2b-c92eab661225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d69fb399-07d3-4bfa-acbd-16e73c9c8098");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "InstructorsName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e5a1674-0570-49e1-a394-73014774b02e", null, "Admin", "ADMIN" },
                    { "25192209-3061-4ab3-a738-545c4494543d", null, "User", "USER" }
                });
        }
    }
}
