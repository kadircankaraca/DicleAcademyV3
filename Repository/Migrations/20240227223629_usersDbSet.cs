using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class usersDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b08ab18-facb-496a-8e87-33886e24c8d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2f24705-a21f-4b6d-b843-6b2cc7a28130");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4da99576-6770-4949-9241-0c57bda1d7a1", null, "Admin", "ADMIN" },
                    { "708b598a-fb4b-418f-baf9-811fe7e1621e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da99576-6770-4949-9241-0c57bda1d7a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "708b598a-fb4b-418f-baf9-811fe7e1621e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b08ab18-facb-496a-8e87-33886e24c8d8", null, "User", "USER" },
                    { "a2f24705-a21f-4b6d-b843-6b2cc7a28130", null, "Admin", "ADMIN" }
                });
        }
    }
}
