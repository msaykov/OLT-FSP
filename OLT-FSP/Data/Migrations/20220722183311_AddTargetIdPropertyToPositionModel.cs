using Microsoft.EntityFrameworkCore.Migrations;

namespace OLT_FSP.Data.Migrations
{
    public partial class AddTargetIdPropertyToPositionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Targets_TargetId",
                table: "Positions");

            migrationBuilder.AlterColumn<int>(
                name: "TargetId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Targets_TargetId",
                table: "Positions",
                column: "TargetId",
                principalTable: "Targets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Targets_TargetId",
                table: "Positions");

            migrationBuilder.AlterColumn<int>(
                name: "TargetId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Targets_TargetId",
                table: "Positions",
                column: "TargetId",
                principalTable: "Targets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
