using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class RemoveSplitterInputPositionProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputPosition",
                table: "Splitters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InputPosition",
                table: "Splitters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
