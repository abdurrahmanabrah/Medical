using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Migrations
{
    /// <inheritdoc />
    public partial class poblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientProblems_ProblemProblems_ProblemId",
                table: "PatientProblems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProblemProblems",
                table: "ProblemProblems");

            migrationBuilder.RenameTable(
                name: "ProblemProblems",
                newName: "Problems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Problems",
                table: "Problems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientProblems_Problems_ProblemId",
                table: "PatientProblems",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientProblems_Problems_ProblemId",
                table: "PatientProblems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Problems",
                table: "Problems");

            migrationBuilder.RenameTable(
                name: "Problems",
                newName: "ProblemProblems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProblemProblems",
                table: "ProblemProblems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientProblems_ProblemProblems_ProblemId",
                table: "PatientProblems",
                column: "ProblemId",
                principalTable: "ProblemProblems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
