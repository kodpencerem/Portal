using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ModifiedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Video",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Video",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "ToplantiTakvimi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ToplantiTakvimi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "ToplantiOdasi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ToplantiOdasi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ToplantiNotu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "ToplantiMerkezi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ToplantiMerkezi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Rehber",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Rehber",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Oneri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Oneri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Mevzuat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Mevzuat",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Katilimci",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "IkUygulama",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "IkUygulama",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "HaberDuyuru",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Etkinlik",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Egitim",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Egitim",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LokasyonBilgisi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "IstekFaaliyetKonusu",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "FaaliyetGurupAdi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "DuzelticiFaaliyet",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "AnketSecenek",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "AnketSecenek",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SilenKullanici",
                table: "Anket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Anket",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "ToplantiOdasi");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "ToplantiMerkezi");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "ToplantiMerkezi");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Rehber");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Rehber");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Oneri");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Oneri");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Mevzuat");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Mevzuat");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Katilimci");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Katilimci");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "IkUygulama");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "IkUygulama");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Egitim");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Egitim");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "AnketSecenek");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "AnketSecenek");

            migrationBuilder.DropColumn(
                name: "SilenKullanici",
                table: "Anket");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "Anket");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "HaberDuyuru",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LokasyonBilgisi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IstekFaaliyetKonusu",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaaliyetGurupAdi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
