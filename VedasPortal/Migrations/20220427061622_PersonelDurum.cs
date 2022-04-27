using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class PersonelDurum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KullaniciRol_KullaniciRolId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_AspNetUsers_KullaniciId1",
                table: "Dosya");

            migrationBuilder.DropTable(
                name: "KullaniciRol");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_KullaniciId1",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KullaniciRolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AyrilisNedeni",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BasladigiGorev",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birimler",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IseBaslangicTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IstenAyrilisTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciDurum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciRolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Resim",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelefonNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TemsilcilikAdi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VefatTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "YakinlikDerecesi",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "Dosya",
                newName: "PersonelDurumId");

            migrationBuilder.CreateTable(
                name: "PersonelDurum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasladigiGorev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemsilcilikAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birimler = table.Column<int>(type: "int", nullable: true),
                    IseBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IstenAyrilisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VefatTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AyrilisNedeni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YakinlikDerecesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifEdilsinMi = table.Column<bool>(type: "bit", nullable: true),
                    PersonelDurumu = table.Column<int>(type: "int", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaydedenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuzenleyenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilenKullanici = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelDurum", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_PersonelDurumId",
                table: "Dosya",
                column: "PersonelDurumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_PersonelDurum_PersonelDurumId",
                table: "Dosya",
                column: "PersonelDurumId",
                principalTable: "PersonelDurum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_PersonelDurum_PersonelDurumId",
                table: "Dosya");

            migrationBuilder.DropTable(
                name: "PersonelDurum");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_PersonelDurumId",
                table: "Dosya");

            migrationBuilder.RenameColumn(
                name: "PersonelDurumId",
                table: "Dosya",
                newName: "KullaniciId");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciId1",
                table: "Dosya",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AyrilisNedeni",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasladigiGorev",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Birimler",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IseBaslangicTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IstenAyrilisTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciDurum",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciRolId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemsilcilikAdi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VefatTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YakinlikDerecesi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KullaniciRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRol", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_KullaniciId1",
                table: "Dosya",
                column: "KullaniciId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KullaniciRolId",
                table: "AspNetUsers",
                column: "KullaniciRolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_KullaniciRol_KullaniciRolId",
                table: "AspNetUsers",
                column: "KullaniciRolId",
                principalTable: "KullaniciRol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_AspNetUsers_KullaniciId1",
                table: "Dosya",
                column: "KullaniciId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
