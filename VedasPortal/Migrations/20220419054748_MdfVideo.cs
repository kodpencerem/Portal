using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class MdfVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DosyaVideo");

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_VideoId",
                table: "Dosya",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Video_VideoId",
                table: "Dosya",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Video_VideoId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_VideoId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Dosya");

            migrationBuilder.CreateTable(
                name: "DosyaVideo",
                columns: table => new
                {
                    DosyaId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosyaVideo", x => new { x.DosyaId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_DosyaVideo_Dosya_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DosyaVideo_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DosyaVideo_VideoId",
                table: "DosyaVideo",
                column: "VideoId");
        }
    }
}
