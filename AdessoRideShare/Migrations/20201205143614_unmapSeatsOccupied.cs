using Microsoft.EntityFrameworkCore.Migrations;

namespace AdessoRideShare.Migrations
{
    public partial class unmapSeatsOccupied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatsAllocated",
                table: "Journeys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatsAllocated",
                table: "Journeys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
