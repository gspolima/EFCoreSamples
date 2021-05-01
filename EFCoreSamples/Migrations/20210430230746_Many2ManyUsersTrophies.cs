using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSamples.Migrations
{
    public partial class Many2ManyUsersTrophies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trophies",
                columns: table => new
                {
                    TrophyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rarity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophies", x => x.TrophyId);
                });

            migrationBuilder.CreateTable(
                name: "TrophyUser",
                columns: table => new
                {
                    TrophiesTrophyId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyUser", x => new { x.TrophiesTrophyId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TrophyUser_Trophies_TrophiesTrophyId",
                        column: x => x.TrophiesTrophyId,
                        principalTable: "Trophies",
                        principalColumn: "TrophyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrophyUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrophyUser_UsersId",
                table: "TrophyUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrophyUser");

            migrationBuilder.DropTable(
                name: "Trophies");
        }
    }
}
