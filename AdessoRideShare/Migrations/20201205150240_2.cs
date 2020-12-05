using Microsoft.EntityFrameworkCore.Migrations;

namespace AdessoRideShare.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoorditateX",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoorditateY",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoorditateX",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CoorditateY",
                table: "Locations");
        }
    }
}
