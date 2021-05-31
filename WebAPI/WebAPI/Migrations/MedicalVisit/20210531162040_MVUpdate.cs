using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.MedicalVisit
{
    public partial class MVUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "MedicalVisits",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "MedicalVisits",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
