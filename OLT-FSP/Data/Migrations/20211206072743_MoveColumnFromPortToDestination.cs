using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class MoveColumnFromPortToDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zone",
                table: "Ports");

            migrationBuilder.RenameColumn(
                name: "portFullName",
                table: "Ports",
                newName: "PortFullName");

            migrationBuilder.AddColumn<string>(
                name: "Zone",
                table: "Destinations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zone",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "PortFullName",
                table: "Ports",
                newName: "portFullName");

            migrationBuilder.AddColumn<string>(
                name: "Zone",
                table: "Ports",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
