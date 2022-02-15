using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "HaberDuyuru",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_VideoId",
                table: "HaberDuyuru",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "HaberDuyuru");
        }
    }
}
