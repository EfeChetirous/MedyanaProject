using Microsoft.EntityFrameworkCore.Migrations;

namespace Medyana.Data.Migrations
{
    public partial class Medyana_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MedClinic",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MedClinic");
        }
    }
}