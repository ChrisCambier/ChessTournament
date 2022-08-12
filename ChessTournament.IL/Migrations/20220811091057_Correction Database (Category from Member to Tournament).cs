using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessTournament.IL.Migrations
{
    public partial class CorrectionDatabaseCategoryfromMembertoTournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Member");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Tournament",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Tournament");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
