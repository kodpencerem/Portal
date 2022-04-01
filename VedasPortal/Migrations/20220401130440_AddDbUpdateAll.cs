using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDbUpdateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuzelticiFaaliyet_Dosya_ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropForeignKey(
                name: "FK_Egitim_Dosya_KapakId",
                table: "Egitim");

            migrationBuilder.DropForeignKey(
                name: "FK_Egitim_Video_VideoId",
                table: "Egitim");

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
                name: "FK_Katilimci_Dosya_ResimId",
                table: "Katilimci");

            migrationBuilder.DropForeignKey(
                name: "FK_Mevzuat_Dosya_DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropForeignKey(
                name: "FK_Oneri_Dosya_DosyaId",
                table: "Oneri");

            migrationBuilder.DropForeignKey(
                name: "FK_Rehber_Dosya_ProfilResmiId",
                table: "Rehber");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Rehber_ProfilResmiId",
                table: "Rehber");

            migrationBuilder.DropIndex(
                name: "IX_Oneri_DosyaId",
                table: "Oneri");

            migrationBuilder.DropIndex(
                name: "IX_Mevzuat_DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropIndex(
                name: "IX_Katilimci_ResimId",
                table: "Katilimci");

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

            migrationBuilder.DropIndex(
                name: "IX_Egitim_KapakId",
                table: "Egitim");

            migrationBuilder.DropIndex(
                name: "IX_Egitim_VideoId",
                table: "Egitim");

            migrationBuilder.DropIndex(
                name: "IX_DuzelticiFaaliyet_ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropColumn(
                name: "ProfilResmiId",
                table: "Rehber");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Oneri");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropColumn(
                name: "ResimId",
                table: "Katilimci");

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

            migrationBuilder.DropColumn(
                name: "KapakId",
                table: "Egitim");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Egitim");

            migrationBuilder.DropColumn(
                name: "ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.AlterColumn<int>(
                name: "DosyaId",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EgitimId",
                table: "Video",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DuzelticiFaaliyetId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EgitimId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IkUygulamaId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KatilimciId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MevzuatId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OneriId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RehberId",
                table: "Dosya",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Video_EgitimId",
                table: "Video",
                column: "EgitimId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_EgitimId",
                table: "Dosya",
                column: "EgitimId");

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
                name: "IX_Dosya_KatilimciId",
                table: "Dosya",
                column: "KatilimciId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya",
                column: "MevzuatId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya",
                column: "OneriId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_RehberId",
                table: "Dosya",
                column: "RehberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_IkUygulama_IkUygulamaId",
                table: "Dosya",
                column: "IkUygulamaId",
                principalTable: "IkUygulama",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Katilimci_KatilimciId",
                table: "Dosya",
                column: "KatilimciId",
                principalTable: "Katilimci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya",
                column: "OneriId",
                principalTable: "Oneri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Rehber_RehberId",
                table: "Dosya",
                column: "RehberId",
                principalTable: "Rehber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Egitim_EgitimId",
                table: "Video",
                column: "EgitimId",
                principalTable: "Egitim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Egitim_EgitimId",
                table: "Dosya");

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
                name: "FK_Dosya_Katilimci_KatilimciId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Rehber_RehberId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Egitim_EgitimId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_EgitimId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_EgitimId",
                table: "Dosya");

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
                name: "IX_Dosya_KatilimciId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_RehberId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "EgitimId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "EgitimId",
                table: "Dosya");

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
                name: "KatilimciId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "MevzuatId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "OneriId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "RehberId",
                table: "Dosya");

            migrationBuilder.AlterColumn<int>(
                name: "DosyaId",
                table: "Video",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProfilResmiId",
                table: "Rehber",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Oneri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Mevzuat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResimId",
                table: "Katilimci",
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

            migrationBuilder.AddColumn<int>(
                name: "KapakId",
                table: "Egitim",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Egitim",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResimId",
                table: "DuzelticiFaaliyet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rehber_ProfilResmiId",
                table: "Rehber",
                column: "ProfilResmiId");

            migrationBuilder.CreateIndex(
                name: "IX_Oneri_DosyaId",
                table: "Oneri",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mevzuat_DosyaId",
                table: "Mevzuat",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Katilimci_ResimId",
                table: "Katilimci",
                column: "ResimId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_KapakId",
                table: "Egitim",
                column: "KapakId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_VideoId",
                table: "Egitim",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_DuzelticiFaaliyet_ResimId",
                table: "DuzelticiFaaliyet",
                column: "ResimId");

            migrationBuilder.AddForeignKey(
                name: "FK_DuzelticiFaaliyet_Dosya_ResimId",
                table: "DuzelticiFaaliyet",
                column: "ResimId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Egitim_Dosya_KapakId",
                table: "Egitim",
                column: "KapakId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Egitim_Video_VideoId",
                table: "Egitim",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Katilimci_Dosya_ResimId",
                table: "Katilimci",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Oneri_Dosya_DosyaId",
                table: "Oneri",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rehber_Dosya_ProfilResmiId",
                table: "Rehber",
                column: "ProfilResmiId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
