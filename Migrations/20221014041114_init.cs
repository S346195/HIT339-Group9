using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace s318344_Assignment1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenderModel",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderModel", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentModel",
                columns: table => new
                {
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentModel", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "LessonTypeModel",
                columns: table => new
                {
                    LessonTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonDuration = table.Column<int>(type: "int", nullable: false),
                    LessonCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTypeModel", x => x.LessonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TutorModel",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorModel", x => x.TutorId);
                });

            migrationBuilder.CreateTable(
                name: "StudentModel",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    GuardianName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PaymentContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModel", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_StudentModel_GenderModel_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderModel",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LetterModel",
                columns: table => new
                {
                    LetterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    BeginningComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountBSB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonTypeId = table.Column<int>(type: "int", nullable: true),
                    LessonDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterModel", x => x.LetterId);
                    table.ForeignKey(
                        name: "FK_LetterModel_LessonTypeModel_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "LessonTypeModel",
                        principalColumn: "LessonTypeId");
                    table.ForeignKey(
                        name: "FK_LetterModel_StudentModel_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentModel",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonModel",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    LessonTypeId = table.Column<int>(type: "int", nullable: true),
                    LessonDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    LetterId = table.Column<int>(type: "int", nullable: true),
                    InstrumentModelInstrumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonModel", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_LessonModel_InstrumentModel_InstrumentModelInstrumentId",
                        column: x => x.InstrumentModelInstrumentId,
                        principalTable: "InstrumentModel",
                        principalColumn: "InstrumentId");
                    table.ForeignKey(
                        name: "FK_LessonModel_LessonTypeModel_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "LessonTypeModel",
                        principalColumn: "LessonTypeId");
                    table.ForeignKey(
                        name: "FK_LessonModel_LetterModel_LetterId",
                        column: x => x.LetterId,
                        principalTable: "LetterModel",
                        principalColumn: "LetterId");
                    table.ForeignKey(
                        name: "FK_LessonModel_StudentModel_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentModel",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonModel_TutorModel_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorModel",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_InstrumentModelInstrumentId",
                table: "LessonModel",
                column: "InstrumentModelInstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_LessonTypeId",
                table: "LessonModel",
                column: "LessonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_LetterId",
                table: "LessonModel",
                column: "LetterId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_StudentId",
                table: "LessonModel",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_TutorId",
                table: "LessonModel",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterModel_LessonTypeId",
                table: "LetterModel",
                column: "LessonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LetterModel_StudentId",
                table: "LetterModel",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_GenderId",
                table: "StudentModel",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonModel");

            migrationBuilder.DropTable(
                name: "InstrumentModel");

            migrationBuilder.DropTable(
                name: "LetterModel");

            migrationBuilder.DropTable(
                name: "TutorModel");

            migrationBuilder.DropTable(
                name: "LessonTypeModel");

            migrationBuilder.DropTable(
                name: "StudentModel");

            migrationBuilder.DropTable(
                name: "GenderModel");
        }
    }
}
