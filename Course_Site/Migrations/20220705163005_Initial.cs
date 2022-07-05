using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Site.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    StudentFacultiesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
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
                        name: "FK_FacultyStudent_Faculties_FacultiesFacultyId",
                        column: x => x.FacultiesFacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentFaculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFaculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFaculties_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    StudentFacultiesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_StudentFaculties_StudentFacultiesId",
                        column: x => x.StudentFacultiesId,
                        principalTable: "StudentFaculties",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyId", "StudentFacultiesId", "Title" },
                values: new object[] { 1, null, "C# 10 and .NET 6" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyId", "StudentFacultiesId", "Title" },
                values: new object[] { 2, null, "Web Development" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyId", "StudentFacultiesId", "Title" },
                values: new object[] { 3, null, "Python for Beginners" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "StudentFacultiesId" },
                values: new object[] { 1, "Alice", "Jones", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "StudentFacultiesId" },
                values: new object[] { 2, "Bob", "Smith", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "StudentFacultiesId" },
                values: new object[] { 3, "Cecilia", "Ramirez", null });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_StudentFacultiesId",
                table: "Faculties",
                column: "StudentFacultiesId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyStudent_StudentsStudentId",
                table: "FacultyStudent",
                column: "StudentsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFaculties_FacultyId",
                table: "StudentFaculties",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFaculties_StudentId",
                table: "StudentFaculties",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentFacultiesId",
                table: "Students",
                column: "StudentFacultiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_StudentFaculties_StudentFacultiesId",
                table: "Faculties",
                column: "StudentFacultiesId",
                principalTable: "StudentFaculties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyStudent_Students_StudentsStudentId",
                table: "FacultyStudent",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFaculties_Students_StudentId",
                table: "StudentFaculties",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_StudentFaculties_StudentFacultiesId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentFaculties_StudentFacultiesId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "FacultyStudent");

            migrationBuilder.DropTable(
                name: "StudentFaculties");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
