using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class wishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a59a46c-0919-4709-a0ce-be7b56b48737");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eebd20bc-4333-4cea-ac01-64cfdd4f5be8");

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Wishlists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0416d732-af7c-4189-8456-8938b2a40135", null, "Admin", "ADMIN" },
                    { "93fc8a46-269f-4c08-8a7f-f94980ff44d5", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_StudentID",
                table: "Wishlists",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Order",
                table: "Lessons",
                column: "Order",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_AspNetUsers_StudentID",
                table: "Wishlists",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_AspNetUsers_StudentID",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_StudentID",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_Order",
                table: "Lessons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0416d732-af7c-4189-8456-8938b2a40135");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93fc8a46-269f-4c08-8a7f-f94980ff44d5");

            migrationBuilder.AlterColumn<long>(
                name: "StudentID",
                table: "Wishlists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a59a46c-0919-4709-a0ce-be7b56b48737", null, "Admin", "ADMIN" },
                    { "eebd20bc-4333-4cea-ac01-64cfdd4f5be8", null, "User", "USER" }
                });
        }
    }
}
