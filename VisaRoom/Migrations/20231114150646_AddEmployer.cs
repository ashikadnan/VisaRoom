using Microsoft.EntityFrameworkCore.Migrations;

namespace VisaRoom.Migrations
{
    public partial class AddEmployer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateImage",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerPhone = table.Column<int>(type: "int", nullable: false),
                    EmployerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerCompany = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropColumn(
                name: "CandidateImage",
                table: "Candidate");
        }
    }
}
