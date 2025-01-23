using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Migrations
{
    /// <inheritdoc />
    public partial class gfh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProblemProblems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemProblems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientProblems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ProblemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProblems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProblems_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProblems_ProblemProblems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "ProblemProblems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false),
                    InstituteId = table.Column<int>(type: "int", nullable: false),
                    BMDCNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultationId = table.Column<int>(type: "int", nullable: false),
                    SpecialInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_SpecialInterests_SpecialInterestId",
                        column: x => x.SpecialInterestId,
                        principalTable: "SpecialInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ConsultationId",
                table: "Doctors",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DegreeId",
                table: "Doctors",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_InstituteId",
                table: "Doctors",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialInterestId",
                table: "Doctors",
                column: "SpecialInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProblems_PatientId",
                table: "PatientProblems",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProblems_ProblemId",
                table: "PatientProblems",
                column: "ProblemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "PatientProblems");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropTable(
                name: "SpecialInterests");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ProblemProblems");
        }
    }
}
