using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class RenameDestinationToTargetAndPathToPositionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Destinations_TargetId",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Splitters_SplitterId",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_PortTarget_Destinations_TargetsId",
                table: "PortTarget");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paths",
                table: "Paths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.RenameTable(
                name: "Paths",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Targets");

            migrationBuilder.RenameIndex(
                name: "IX_Paths_TargetId",
                table: "Positions",
                newName: "IX_Positions_TargetId");

            migrationBuilder.RenameIndex(
                name: "IX_Paths_SplitterId",
                table: "Positions",
                newName: "IX_Positions_SplitterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Targets",
                table: "Targets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortTarget_Targets_TargetsId",
                table: "PortTarget",
                column: "TargetsId",
                principalTable: "Targets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Splitters_SplitterId",
                table: "Positions",
                column: "SplitterId",
                principalTable: "Splitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Targets_TargetId",
                table: "Positions",
                column: "TargetId",
                principalTable: "Targets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortTarget_Targets_TargetsId",
                table: "PortTarget");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Splitters_SplitterId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Targets_TargetId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Targets",
                table: "Targets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Targets",
                newName: "Destinations");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Paths");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_TargetId",
                table: "Paths",
                newName: "IX_Paths_TargetId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_SplitterId",
                table: "Paths",
                newName: "IX_Paths_SplitterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paths",
                table: "Paths",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Destinations_TargetId",
                table: "Paths",
                column: "TargetId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Splitters_SplitterId",
                table: "Paths",
                column: "SplitterId",
                principalTable: "Splitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PortTarget_Destinations_TargetsId",
                table: "PortTarget",
                column: "TargetsId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
