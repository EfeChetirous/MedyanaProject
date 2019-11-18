using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medyana.Data.Migrations
{
    public partial class medyana_migration_equipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProvideDate = table.Column<DateTime>(nullable: false),
                    CountInfo = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    UsageRate = table.Column<double>(nullable: false),
                    ClinicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedEquipment_MedClinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "MedClinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedEquipment_ClinicId",
                table: "MedEquipment",
                column: "ClinicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedEquipment");
        }
    }
}
