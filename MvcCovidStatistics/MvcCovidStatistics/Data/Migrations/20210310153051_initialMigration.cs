using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCovidStatistics.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumVaccinated = table.Column<int>(type: "int", nullable: false),
                    NumDeaths = table.Column<int>(type: "int", nullable: false),
                    NumRecovered = table.Column<int>(type: "int", nullable: false),
                    NewCases = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayRecords");
        }
    }
}
