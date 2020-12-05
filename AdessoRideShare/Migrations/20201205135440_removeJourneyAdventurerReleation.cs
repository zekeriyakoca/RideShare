using Microsoft.EntityFrameworkCore.Migrations;

namespace AdessoRideShare.Migrations
{
    public partial class removeJourneyAdventurerReleation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventurerJourney");

            migrationBuilder.AddColumn<int>(
                name: "AdventurerId",
                table: "Journeys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_AdventurerId",
                table: "Journeys",
                column: "AdventurerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Adventurers_AdventurerId",
                table: "Journeys",
                column: "AdventurerId",
                principalTable: "Adventurers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Adventurers_AdventurerId",
                table: "Journeys");

            migrationBuilder.DropIndex(
                name: "IX_Journeys_AdventurerId",
                table: "Journeys");

            migrationBuilder.DropColumn(
                name: "AdventurerId",
                table: "Journeys");

            migrationBuilder.CreateTable(
                name: "AdventurerJourney",
                columns: table => new
                {
                    AdventurersId = table.Column<int>(type: "int", nullable: false),
                    JourneysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventurerJourney", x => new { x.AdventurersId, x.JourneysId });
                    table.ForeignKey(
                        name: "FK_AdventurerJourney_Adventurers_AdventurersId",
                        column: x => x.AdventurersId,
                        principalTable: "Adventurers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdventurerJourney_Journeys_JourneysId",
                        column: x => x.JourneysId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventurerJourney_JourneysId",
                table: "AdventurerJourney",
                column: "JourneysId");
        }
    }
}
