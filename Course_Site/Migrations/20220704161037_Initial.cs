using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Site.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "FacultyStudent",
                columns: table => new
                {
                    FacultiesFacultyId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyStudent", x => new { x.FacultiesFacultyId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_FacultyStudent_Courses_FacultiesFacultyId",
                        column: x => x.FacultiesFacultyId,
                        principalTable: "Courses",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "FacultyId", "Title" },
                values: new object[] { 1, "C# 10 and .NET 6" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "FacultyId", "Title" },
                values: new object[] { 2, "Web Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "FacultyId", "Title" },
                values: new object[] { 3, "Python for Beginners" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName" },
                values: new object[] { 1, "Alice", "Jones" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName" },
                values: new object[] { 2, "Bob", "Smith" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName" },
                values: new object[] { 3, "Cecilia", "Ramirez" });

            migrationBuilder.InsertData(
                table: "FacultyStudent",
                columns: new[] { "FacultiesFacultyId", "StudentsStudentId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "FacultyStudent",
                columns: new[] { "FacultiesFacultyId", "StudentsStudentId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "FacultyStudent",
                columns: new[] { "FacultiesFacultyId", "StudentsStudentId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "FacultyStudent",
                columns: new[] { "FacultiesFacultyId", "StudentsStudentId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "FacultyStudent",
                columns: new[] { "FacultiesFacultyId", "StudentsStudentId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyStudent_StudentsStudentId",
                table: "FacultyStudent",
                column: "StudentsStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyStudent");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
