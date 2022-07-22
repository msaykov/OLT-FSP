using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class AddBoolPropertyToPositionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInputPosition",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInputPosition",
                table: "Positions");
        }
    }
}
