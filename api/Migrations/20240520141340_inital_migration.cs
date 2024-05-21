using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class inital_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<long>(type: "bigint", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<long>(type: "bigint", nullable: false),
                    CartStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Carts_AppUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeacherID = table.Column<long>(type: "bigint", nullable: false),
                    NumberOfEnrollement = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_AppUsers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<long>(type: "bigint", nullable: false),
                    CourseID = table.Column<long>(type: "bigint", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<long>(type: "bigint", nullable: false),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCategories_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<long>(type: "bigint", nullable: false),
                    CourseID = table.Column<long>(type: "bigint", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollments_AppUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseID = table.Column<long>(type: "bigint", nullable: true),
                    CouseID = table.Column<long>(type: "bigint", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CouseID",
                        column: x => x.CouseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingValue = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<long>(type: "bigint", nullable: false),
                    CourseID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_AppUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<long>(type: "bigint", nullable: false),
                    CourseID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wishlists_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lessons_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CourseID",
                table: "CartItems",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_StudentID",
                table: "Carts",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_CategoryID",
                table: "CourseCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_CourseID",
                table: "CourseCategories",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherID",
                table: "Courses",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleID",
                table: "Lessons",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CouseID",
                table: "Modules",
                column: "CouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseID",
                table: "Reviews",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentID",
                table: "Reviews",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_CourseID",
                table: "Wishlists",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
