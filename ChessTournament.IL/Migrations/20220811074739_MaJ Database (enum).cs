using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessTournament.IL.Migrations
{
    public partial class MaJDatabaseenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statut",
                table: "Tournament",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "ELOMin",
                table: "Tournament",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ELOMax",
                table: "Tournament",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tournament",
                newName: "Statut");

            migrationBuilder.AlterColumn<int>(
                name: "ELOMin",
                table: "Tournament",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ELOMax",
                table: "Tournament",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
