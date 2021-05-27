using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.Patient
{
    public partial class UpdatePatientProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "birthdayDate",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "telNumber",
                table: "Patients",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthdayDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "telNumber",
                table: "Patients");
        }
    }
}
