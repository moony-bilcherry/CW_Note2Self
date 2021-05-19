using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Note2Self.Migrations
{
    public partial class AddedMoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MoodId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    MoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.MoodId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_MoodId",
                table: "Notes",
                column: "MoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Moods_MoodId",
                table: "Notes",
                column: "MoodId",
                principalTable: "Moods",
                principalColumn: "MoodId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Moods_MoodId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Moods");

            migrationBuilder.DropIndex(
                name: "IX_Notes_MoodId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "MoodId",
                table: "Notes");
        }
    }
}
