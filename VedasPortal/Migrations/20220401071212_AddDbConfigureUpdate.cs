using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class AddDbConfigureUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_IkUygulama_IKUygulamaId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Dosya_ResimId",
                table: "Katilimci");

            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_Etkinlik_No",
                table: "Etkinlik");

            migrationBuilder.RenameColumn(
                name: "IKUygulamaId",
                table: "Dosya",
                newName: "IkUygulamaId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_IKUygulamaId",
                table: "Dosya",
                newName: "IX_Dosya_IkUygulamaId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Mevzuat",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Mevzuat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Mevzuat",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Mevzuat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kategori",
                table: "Mevzuat",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Mevzuat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Mevzuat",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Birimler",
                table: "Mevzuat",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Mevzuat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Mevzuat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "TelefonNo",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Katilimci",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Katilimci",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KatilisNedeni",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<bool>(
                name: "KatilisDurumu",
                table: "Katilimci",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Katilimci",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Katilimci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "IkUygulama",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "IkUygulama",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "IkUygulama",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "IkUygulama",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kategori",
                table: "IkUygulama",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "IkUygulama",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "IkUygulama",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Birimler",
                table: "IkUygulama",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "IkUygulama",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "IkUygulama",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<bool>(
                name: "SliderdaGoster",
                table: "HaberDuyuru",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "HaberDuyuru",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "HaberDuyuru",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "Int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "HaberDuyuru",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kategori",
                table: "HaberDuyuru",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "HaberDuyuru",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AnasayfadaGoster",
                table: "HaberDuyuru",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "AltBaslik",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "HaberDuyuru",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<bool>(
                name: "SliderdaGoster",
                table: "Etkinlik",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Etkinlik",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "Int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Etkinlik",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kategori",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<int>(
                name: "KKategori",
                table: "Etkinlik",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Etkinlik",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BitisTarihi",
                table: "Etkinlik",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "Etkinlik",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<bool>(
                name: "AnasayfadaGoster",
                table: "Etkinlik",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "Etkinlik",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "DuzelticiFaaliyet",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LokasyonBilgisi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "KonuEtiketi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "DuzelticiFaaliyet",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kategori",
                table: "DuzelticiFaaliyet",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "IstekFaaliyetKonusu",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "FaaliyetGurupAdi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "DuzelticiFaaliyet",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BildirimTarihi",
                table: "DuzelticiFaaliyet",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "DuzelticiFaaliyet",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Yolu",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Uzanti",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kategori",
                table: "Dosya",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Boyutu",
                table: "Dosya",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "Dosya",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId",
                principalTable: "ToplantiNotu",
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
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video",
                column: "DosyaId",
                principalTable: "Dosya",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
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
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Dosya_ResimId",
                table: "Katilimci");

            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video");

            migrationBuilder.RenameColumn(
                name: "IkUygulamaId",
                table: "Dosya",
                newName: "IKUygulamaId");

            migrationBuilder.RenameIndex(
                name: "IX_Dosya_IkUygulamaId",
                table: "Dosya",
                newName: "IX_Dosya_IKUygulamaId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Mevzuat",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Mevzuat",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Mevzuat",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Mevzuat",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Kategori",
                table: "Mevzuat",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Mevzuat",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Mevzuat",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Birimler",
                table: "Mevzuat",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Mevzuat",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Mevzuat",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TelefonNo",
                table: "Katilimci",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Katilimci",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Katilimci",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Katilimci",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Katilimci",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KatilisNedeni",
                table: "Katilimci",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KatilisDurumu",
                table: "Katilimci",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "Katilimci",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Katilimci",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Katilimci",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Katilimci",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "IkUygulama",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "IkUygulama",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "IkUygulama",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "IkUygulama",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Kategori",
                table: "IkUygulama",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "IkUygulama",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "IkUygulama",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Birimler",
                table: "IkUygulama",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "IkUygulama",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "IkUygulama",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SliderdaGoster",
                table: "HaberDuyuru",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "HaberDuyuru",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "HaberDuyuru",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "HaberDuyuru",
                type: "Int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "HaberDuyuru",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "HaberDuyuru",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Kategori",
                table: "HaberDuyuru",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "HaberDuyuru",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "HaberDuyuru",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AnasayfadaGoster",
                table: "HaberDuyuru",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "AltBaslik",
                table: "HaberDuyuru",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "HaberDuyuru",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "HaberDuyuru",
                type: "VarChar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "HaberDuyuru",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SliderdaGoster",
                table: "Etkinlik",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Etkinlik",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Etkinlik",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "Etkinlik",
                type: "Int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Etkinlik",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Etkinlik",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Kategori",
                table: "Etkinlik",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "KKategori",
                table: "Etkinlik",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Etkinlik",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Etkinlik",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BitisTarihi",
                table: "Etkinlik",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "Etkinlik",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "AnasayfadaGoster",
                table: "Etkinlik",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "Etkinlik",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Etkinlik",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Etkinlik",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "DuzelticiFaaliyet",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LokasyonBilgisi",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KonuEtiketi",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "DuzelticiFaaliyet",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Kategori",
                table: "DuzelticiFaaliyet",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IstekFaaliyetKonusu",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FaaliyetGurupAdi",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "DuzelticiFaaliyet",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BildirimTarihi",
                table: "DuzelticiFaaliyet",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "DuzelticiFaaliyet",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Yolu",
                table: "Dosya",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uzanti",
                table: "Dosya",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "Dosya",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "Dosya",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "Dosya",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "Dosya",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Kategori",
                table: "Dosya",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "Dosya",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "Dosya",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Boyutu",
                table: "Dosya",
                type: "VarChar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "Dosya",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Dosya",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru",
                column: "No");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_No",
                table: "Etkinlik",
                column: "No");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_IkUygulama_IKUygulamaId",
                table: "Dosya",
                column: "IKUygulamaId",
                principalTable: "IkUygulama",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId",
                principalTable: "ToplantiNotu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Katilimci_Dosya_ResimId",
                table: "Katilimci",
                column: "ResimId",
                principalTable: "Dosya",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Dosya_DosyaId",
                table: "Video",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
                principalColumn: "Id");
        }
    }
}
