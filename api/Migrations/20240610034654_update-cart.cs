using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updatecart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Courses_CourseID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CourseID",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d45bfc94-f670-42d8-8e8f-d43714a72b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4da4a0b-a068-4af2-981a-a8979272d7c4");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Carts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "252add62-fb17-4ff6-ba48-e341bae6cbcb", null, "Admin", "ADMIN" },
                    { "a938695f-841c-41e9-9ae9-a1ed63e6edb3", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "252add62-fb17-4ff6-ba48-e341bae6cbcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a938695f-841c-41e9-9ae9-a1ed63e6edb3");

            migrationBuilder.AddColumn<long>(
                name: "CourseID",
                table: "Carts",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d45bfc94-f670-42d8-8e8f-d43714a72b14", null, "Admin", "ADMIN" },
                    { "e4da4a0b-a068-4af2-981a-a8979272d7c4", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CourseID",
                table: "Carts",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Courses_CourseID",
                table: "Carts",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
