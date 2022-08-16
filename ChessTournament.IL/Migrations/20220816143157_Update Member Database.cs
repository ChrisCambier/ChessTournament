using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessTournament.IL.Migrations
{
    public partial class UpdateMemberDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Salt",
                table: "Member",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Member");
        }
    }
}
