using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_StudentID",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0416d732-af7c-4189-8456-8938b2a40135");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93fc8a46-269f-4c08-8a7f-f94980ff44d5");

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                name: "FK_Carts_AspNetUsers_StudentID",
                table: "Carts",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Courses_CourseID",
                table: "Carts",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_StudentID",
                table: "Carts");

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

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0416d732-af7c-4189-8456-8938b2a40135", null, "Admin", "ADMIN" },
                    { "93fc8a46-269f-4c08-8a7f-f94980ff44d5", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_StudentID",
                table: "Carts",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
