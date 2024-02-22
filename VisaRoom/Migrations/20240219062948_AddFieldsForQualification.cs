using Microsoft.EntityFrameworkCore.Migrations;

namespace VisaRoom.Migrations
{
    public partial class AddFieldsForQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BachelorResult",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollegeResult",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeName2",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeName3",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeName4",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationYear2",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationYear3",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationYear4",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstituteName2",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstituteName3",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstituteName4",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterResult",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassingYear2",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassingYear3",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassingYear4",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolResult",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificate2",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificate3",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificate4",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BachelorResult",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "CollegeResult",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DegreeName2",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DegreeName3",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DegreeName4",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DurationYear2",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DurationYear3",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "DurationYear4",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "InstituteName2",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "InstituteName3",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "InstituteName4",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "MasterResult",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "PassingYear2",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "PassingYear3",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "PassingYear4",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "SchoolResult",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Certificate2",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Certificate3",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Certificate4",
                table: "Candidate");
        }
    }
}
