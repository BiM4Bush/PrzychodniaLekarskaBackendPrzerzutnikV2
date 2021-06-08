using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.Doctor
{
    public partial class UpdateDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Doctors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Doctors",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
