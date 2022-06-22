using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programming_CoursesDataContext.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programming_Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INT IDENTITY(1,1)", nullable: false),
                    CourseName = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Duration = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    FutureJob = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programming_Courses", x => x.CourseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programming_Courses");
        }
    }
}
