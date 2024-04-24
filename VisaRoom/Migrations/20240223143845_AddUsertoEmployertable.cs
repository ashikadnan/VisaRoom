using Microsoft.EntityFrameworkCore.Migrations;

namespace VisaRoom.Migrations
{
    public partial class AddUsertoEmployertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Employer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employer_UserId",
                table: "Employer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_AspNetUsers_UserId",
                table: "Employer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employer_AspNetUsers_UserId",
                table: "Employer");

            migrationBuilder.DropIndex(
                name: "IX_Employer_UserId",
                table: "Employer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employer");
        }
    }
}
