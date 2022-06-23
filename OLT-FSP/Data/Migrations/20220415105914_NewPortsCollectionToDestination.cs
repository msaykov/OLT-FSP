using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class NewPortsCollectionToDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Ports_PortId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_PortId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "PortId",
                table: "Destinations");

            migrationBuilder.CreateTable(
                name: "DestinationPort",
                columns: table => new
                {
                    PortsId = table.Column<int>(type: "int", nullable: false),
                    TargetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationPort", x => new { x.PortsId, x.TargetsId });
                    table.ForeignKey(
                        name: "FK_DestinationPort_Destinations_TargetsId",
                        column: x => x.TargetsId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationPort_Ports_PortsId",
                        column: x => x.PortsId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationPort_TargetsId",
                table: "DestinationPort",
                column: "TargetsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationPort");

            migrationBuilder.AddColumn<int>(
                name: "PortId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_PortId",
                table: "Destinations",
                column: "PortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Ports_PortId",
                table: "Destinations",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
