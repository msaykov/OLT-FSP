using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class EditedPathTargetAndPortModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Destinations_DestinationId",
                table: "Paths");

            migrationBuilder.DropTable(
                name: "DestinationPort");

            migrationBuilder.DropIndex(
                name: "IX_Paths_DestinationId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ports");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "OdfInPosition",
                table: "Paths");

            migrationBuilder.AddColumn<int>(
                name: "PortId",
                table: "Splitters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SplitterId",
                table: "Ports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OdfInfo",
                table: "Paths",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TargetId",
                table: "Paths",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PortTarget",
                columns: table => new
                {
                    PortsId = table.Column<int>(type: "int", nullable: false),
                    TargetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortTarget", x => new { x.PortsId, x.TargetsId });
                    table.ForeignKey(
                        name: "FK_PortTarget_Destinations_TargetsId",
                        column: x => x.TargetsId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortTarget_Ports_PortsId",
                        column: x => x.PortsId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paths_TargetId",
                table: "Paths",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_PortTarget_TargetsId",
                table: "PortTarget",
                column: "TargetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Destinations_TargetId",
                table: "Paths",
                column: "TargetId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Destinations_TargetId",
                table: "Paths");

            migrationBuilder.DropTable(
                name: "PortTarget");

            migrationBuilder.DropIndex(
                name: "IX_Paths_TargetId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "PortId",
                table: "Splitters");

            migrationBuilder.DropColumn(
                name: "SplitterId",
                table: "Ports");

            migrationBuilder.DropColumn(
                name: "OdfInfo",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Paths");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Paths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OdfInPosition",
                table: "Paths",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_Paths_DestinationId",
                table: "Paths",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationPort_TargetsId",
                table: "DestinationPort",
                column: "TargetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Destinations_DestinationId",
                table: "Paths",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
