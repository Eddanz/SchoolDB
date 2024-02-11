using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDB_Labb3.Migrations
{
    /// <inheritdoc />
    public partial class AddedSalarycolumntoEmployeetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Security_Number = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Security_Number = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Class = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FK_EmployeeID = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Employee",
                        column: x => x.FK_EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Grade = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    FK_CourseID = table.Column<short>(type: "smallint", nullable: false),
                    FK_StudentID = table.Column<short>(type: "smallint", nullable: false),
                    FK_EmployeeID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Grade_Course",
                        column: x => x.FK_CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_Grade_Employee",
                        column: x => x.FK_EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Grade_Student",
                        column: x => x.FK_StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_FK_EmployeeID",
                table: "Course",
                column: "FK_EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_FK_CourseID",
                table: "Grade",
                column: "FK_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_FK_EmployeeID",
                table: "Grade",
                column: "FK_EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_FK_StudentID",
                table: "Grade",
                column: "FK_StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
