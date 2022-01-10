using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class AddPathAndSplitterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ports_Destinations_DestinationId",
                table: "Ports");

            migrationBuilder.DropIndex(
                name: "IX_Ports_DestinationId",
                table: "Ports");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Ports");

            migrationBuilder.AddColumn<int>(
                name: "PathId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PortId",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Splitters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutputsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Splitters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdfInPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdfOutPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SplitterId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paths_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paths_Splitters_SplitterId",
                        column: x => x.SplitterId,
                        principalTable: "Splitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_PortId",
                table: "Destinations",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_DestinationId",
                table: "Paths",
                column: "DestinationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paths_SplitterId",
                table: "Paths",
                column: "SplitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Ports_PortId",
                table: "Destinations",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Ports_PortId",
                table: "Destinations");

            migrationBuilder.DropTable(
                name: "Paths");

            migrationBuilder.DropTable(
                name: "Splitters");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_PortId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "PathId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "PortId",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Ports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ports_DestinationId",
                table: "Ports",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ports_Destinations_DestinationId",
                table: "Ports",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
