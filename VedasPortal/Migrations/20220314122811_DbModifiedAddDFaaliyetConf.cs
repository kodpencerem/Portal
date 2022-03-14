using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModifiedAddDFaaliyetConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuzelticiFaaliyet_Dosya_ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropIndex(
                name: "IX_DuzelticiFaaliyet_ResimId",
                table: "DuzelticiFaaliyet");

            migrationBuilder.DropColumn(
                name: "ResimId",
                table: "DuzelticiFaaliyet");

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
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaaliyetGurupAdi",
                table: "DuzelticiFaaliyet",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DuzelticiFaaliyetId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya",
                column: "DuzelticiFaaliyetId",
                principalTable: "DuzelticiFaaliyet",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_DuzelticiFaaliyet_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_DuzelticiFaaliyetId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "DuzelticiFaaliyetId",
                table: "Dosya");

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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "FaaliyetGurupAdi",
                table: "DuzelticiFaaliyet",
                type: "nvarchar(max)",
                nullable: true,
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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AddColumn<int>(
                name: "ResimId",
                table: "DuzelticiFaaliyet",
                type: "int",
                nullable: true);

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
        }
    }
}
