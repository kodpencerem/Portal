using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class VideoTableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Video_VideoId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Egitim_EgitimId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Etkinlik_EtkinlikId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Video_VideoId",
                table: "Yorum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videolar");

            migrationBuilder.RenameIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Videolar",
                newName: "IX_Videolar_HaberDuyuruId");

            migrationBuilder.RenameIndex(
                name: "IX_Video_EtkinlikId",
                table: "Videolar",
                newName: "IX_Videolar_EtkinlikId");

            migrationBuilder.RenameIndex(
                name: "IX_Video_EgitimId",
                table: "Videolar",
                newName: "IX_Videolar_EgitimId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videolar",
                table: "Videolar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Videolar_VideoId",
                table: "Dosya",
                column: "VideoId",
                principalTable: "Videolar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videolar_Egitim_EgitimId",
                table: "Videolar",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videolar_Etkinlik_EtkinlikId",
                table: "Videolar",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videolar_HaberDuyuru_HaberDuyuruId",
                table: "Videolar",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Videolar_VideoId",
                table: "Yorum",
                column: "VideoId",
                principalTable: "Videolar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Videolar_VideoId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Videolar_Egitim_EgitimId",
                table: "Videolar");

            migrationBuilder.DropForeignKey(
                name: "FK_Videolar_Etkinlik_EtkinlikId",
                table: "Videolar");

            migrationBuilder.DropForeignKey(
                name: "FK_Videolar_HaberDuyuru_HaberDuyuruId",
                table: "Videolar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Videolar_VideoId",
                table: "Yorum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videolar",
                table: "Videolar");

            migrationBuilder.RenameTable(
                name: "Videolar",
                newName: "Video");

            migrationBuilder.RenameIndex(
                name: "IX_Videolar_HaberDuyuruId",
                table: "Video",
                newName: "IX_Video_HaberDuyuruId");

            migrationBuilder.RenameIndex(
                name: "IX_Videolar_EtkinlikId",
                table: "Video",
                newName: "IX_Video_EtkinlikId");

            migrationBuilder.RenameIndex(
                name: "IX_Videolar_EgitimId",
                table: "Video",
                newName: "IX_Video_EgitimId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Video_VideoId",
                table: "Dosya",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Egitim_EgitimId",
                table: "Video",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Etkinlik_EtkinlikId",
                table: "Video",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Video_VideoId",
                table: "Yorum",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
