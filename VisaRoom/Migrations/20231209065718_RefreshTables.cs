using Microsoft.EntityFrameworkCore.Migrations;

namespace VisaRoom.Migrations
{
    public partial class RefreshTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Experiences_ExperienceId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Qualifications_QualificationId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_ExperienceId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_QualificationId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Candidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Candidate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Candidate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ExperienceId",
                table: "Candidate",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_QualificationId",
                table: "Candidate",
                column: "QualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Experiences_ExperienceId",
                table: "Candidate",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Qualifications_QualificationId",
                table: "Candidate",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
