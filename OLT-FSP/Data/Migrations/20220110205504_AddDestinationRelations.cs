using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class AddDestinationRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Destinations_DestinationId",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_DestinationId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "PathId",
                table: "Destinations");

            migrationBuilder.AlterColumn<int>(
                name: "PortId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paths_DestinationId",
                table: "Paths",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Destinations_DestinationId",
                table: "Paths",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Destinations_DestinationId",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_DestinationId",
                table: "Paths");

            migrationBuilder.AlterColumn<int>(
                name: "PortId",
                table: "Destinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PathId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paths_DestinationId",
                table: "Paths",
                column: "DestinationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Destinations_DestinationId",
                table: "Paths",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
