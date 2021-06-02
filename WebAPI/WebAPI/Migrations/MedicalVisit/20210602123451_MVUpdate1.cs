using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.MedicalVisit
{
    public partial class MVUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Private",
                table: "MedicalVisits",
                newName: "Confirmed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Confirmed",
                table: "MedicalVisits",
                newName: "Private");
        }
    }
}
