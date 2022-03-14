using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModiedAddEtkinlikReltn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci");

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
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "Etkinlik",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_No",
                table: "Etkinlik",
                column: "No");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci");

            migrationBuilder.DropIndex(
                name: "IX_Etkinlik_No",
                table: "Etkinlik");

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

            migrationBuilder.AlterColumn<string>(
                name: "BitisTarihi",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "BaslangicTarihi",
                table: "Etkinlik",
                type: "nvarchar(max)",
                nullable: true,
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

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Katilimci_Etkinlik_EtkinlikId",
                table: "Katilimci",
                column: "EtkinlikId",
                principalTable: "Etkinlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
