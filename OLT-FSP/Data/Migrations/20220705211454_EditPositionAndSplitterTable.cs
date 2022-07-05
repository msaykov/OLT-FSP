using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class EditPositionAndSplitterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdfOutPosition",
                table: "Positions");

            migrationBuilder.AddColumn<string>(
                name: "InputPosition",
                table: "Splitters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputPosition",
                table: "Splitters");

            migrationBuilder.AddColumn<string>(
                name: "OdfOutPosition",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
