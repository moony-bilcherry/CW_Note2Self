using Microsoft.EntityFrameworkCore.Migrations;

namespace Note2Self.Migrations
{
    public partial class AddedGoalsChangedNamespace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_GoalId",
                table: "Notes",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Goals_GoalId",
                table: "Notes",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Goals_GoalId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Notes_GoalId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
