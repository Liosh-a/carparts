using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.DataAccess.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductionStartYear",
                table: "tblProducts",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductionStopYear",
                table: "tblProducts",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionStartYear",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "ProductionStopYear",
                table: "tblProducts");
        }
    }
}
