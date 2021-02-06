using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModernITCourse.DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SUBJ_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SUBJ_NAME = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    HOUR = table.Column<int>(type: "INTEGER", nullable: false),
                    SEMESTER = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SUBJ_ID);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UNIV_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UNIV_NAME = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CITY = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RATING = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UNIV_ID);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SURNAME = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CITY = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UNIV_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lecturers_Universities_UNIV_ID",
                        column: x => x.UNIV_ID,
                        principalTable: "Universities",
                        principalColumn: "UNIV_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    STIPEND = table.Column<int>(type: "INTEGER", nullable: false),
                    KURS = table.Column<int>(type: "INTEGER", nullable: false),
                    BIRTHDAY = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SURNAME = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CITY = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UNIV_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Universities_UNIV_ID",
                        column: x => x.UNIV_ID,
                        principalTable: "Universities",
                        principalColumn: "UNIV_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectLecturers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SUBJ_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    LECTURER_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectLecturers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubjectLecturers_Lecturers_LECTURER_ID",
                        column: x => x.LECTURER_ID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectLecturers_Subjects_SUBJ_ID",
                        column: x => x.SUBJ_ID,
                        principalTable: "Subjects",
                        principalColumn: "SUBJ_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamMarks",
                columns: table => new
                {
                    EXAM_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MARK = table.Column<int>(type: "INTEGER", nullable: false),
                    EXAM_DATE = table.Column<DateTime>(type: "TEXT", nullable: false),
                    STUDENT_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    SUBJ_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamMarks", x => x.EXAM_ID);
                    table.ForeignKey(
                        name: "FK_ExamMarks_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamMarks_Subjects_SUBJ_ID",
                        column: x => x.SUBJ_ID,
                        principalTable: "Subjects",
                        principalColumn: "SUBJ_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamMarks_STUDENT_ID",
                table: "ExamMarks",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMarks_SUBJ_ID",
                table: "ExamMarks",
                column: "SUBJ_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_UNIV_ID",
                table: "Lecturers",
                column: "UNIV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UNIV_ID",
                table: "Students",
                column: "UNIV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectLecturers_LECTURER_ID",
                table: "SubjectLecturers",
                column: "LECTURER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectLecturers_SUBJ_ID",
                table: "SubjectLecturers",
                column: "SUBJ_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamMarks");

            migrationBuilder.DropTable(
                name: "SubjectLecturers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
