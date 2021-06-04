using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.MedicalVisit
{
    public partial class UpdateMVmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorRecommendation",
                table: "MedicalVisits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorRecommendation",
                table: "MedicalVisits");
        }
    }
}
