using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.DataAccess.Migrations
{
    public partial class deleteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionStartYear",
                table: "tblAllCars");

            migrationBuilder.DropColumn(
                name: "ProductionStopYear",
                table: "tblAllCars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductionStartYear",
                table: "tblAllCars",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductionStopYear",
                table: "tblAllCars",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
