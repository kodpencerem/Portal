using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DosyaHaberDuyuru");

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "HaberDuyuru",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.CreateTable(
                name: "DosyaHaberDuyuru",
                columns: table => new
                {
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    HaberDuyuruId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaHaberDuyuru", x => new { x.DosyaId, x.HaberDuyuruId });
                    table.ForeignKey(
                        name: "FK_DosyaHaberDuyuru_Dosya_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaHaberDuyuru_HaberDuyuru_HaberDuyuruId",
                        column: x => x.HaberDuyuruId,
                        principalTable: "HaberDuyuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DosyaHaberDuyuru_HaberDuyuruId",
                table: "DosyaHaberDuyuru",
                column: "HaberDuyuruId");
        }
    }
}
