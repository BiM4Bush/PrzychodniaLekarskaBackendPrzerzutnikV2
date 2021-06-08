using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.Patient
{
    public partial class UpdatePP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Patients");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Patients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Patients",
                nullable: true);
        }
    }
}
