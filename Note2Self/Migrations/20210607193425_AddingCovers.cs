using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Note2Self.Migrations
{
    public partial class AddingCovers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                table: "Notes",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Notes");
        }
    }
}
