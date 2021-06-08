using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.Patient
{
    public partial class PPUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
