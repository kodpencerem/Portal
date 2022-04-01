using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDbConfigureUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_IkUygulamaId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "IkUygulamaId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "MevzuatId",
                table: "Dosya");

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Mevzuat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResimId",
                table: "IkUygulama",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "HaberDuyuru",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "HaberDuyuru",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KapakId",
                table: "Etkinlik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mevzuat_DosyaId",
                table: "Mevzuat",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_IkUygulama_ResimId",
                table: "IkUygulama",
                column: "ResimId");

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_VideoId",
                table: "HaberDuyuru",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_KapakId",
                table: "Etkinlik",
                column: "KapakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinlik_Dosya_KapakId",
                table: "Etkinlik",
                column: "KapakId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IkUygulama_Dosya_ResimId",
                table: "IkUygulama",
                column: "ResimId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mevzuat_Dosya_DosyaId",
                table: "Mevzuat",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlik_Dosya_KapakId",
                table: "Etkinlik");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Dosya_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropForeignKey(
                name: "FK_IkUygulama_Dosya_ResimId",
                table: "IkUygulama");

            migrationBuilder.DropForeignKey(
                name: "FK_Mevzuat_Dosya_DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropIndex(
                name: "IX_Mevzuat_DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropIndex(
                name: "IX_IkUygulama_ResimId",
                table: "IkUygulama");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_Etkinlik_KapakId",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropColumn(
                name: "ResimId",
                table: "IkUygulama");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "KapakId",
                table: "Etkinlik");

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Video",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IkUygulamaId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MevzuatId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_IkUygulamaId",
                table: "Dosya",
                column: "IkUygulamaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya",
                column: "MevzuatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId",
                table: "Dosya",
                column: "IkUygulamaId",
                principalTable: "IkUygulama",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
