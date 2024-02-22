using Microsoft.EntityFrameworkCore.Migrations;

namespace VisaRoom.Migrations
{
    public partial class qandex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Candidate_CandidateId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Candidate_CandidateId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_CandidateId",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_CandidateId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Experiences");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Qualifications_QualificationId",
                table: "Candidate",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Qualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_CandidateId",
                table: "Qualifications",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CandidateId",
                table: "Experiences",
                column: "CandidateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Candidate_CandidateId",
                table: "Experiences",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Candidate_CandidateId",
                table: "Qualifications",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
