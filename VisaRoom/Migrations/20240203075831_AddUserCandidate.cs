using Microsoft.EntityFrameworkCore.Migrations;

namespace VisaRoom.Migrations
{
    public partial class AddUserCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateUserId",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CandidateUserId",
                table: "Candidate",
                column: "CandidateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_AspNetUsers_CandidateUserId",
                table: "Candidate",
                column: "CandidateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_AspNetUsers_CandidateUserId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_CandidateUserId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CandidateUserId",
                table: "Candidate");
        }
    }
}
