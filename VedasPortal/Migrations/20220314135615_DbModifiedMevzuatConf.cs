using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModifiedMevzuatConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mevzuat_Dosya_DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropForeignKey(
                name: "FK_Oneri_Dosya_OneriDosyaId",
                table: "Oneri");

            migrationBuilder.DropIndex(
                name: "IX_Oneri_OneriDosyaId",
                table: "Oneri");

            migrationBuilder.DropIndex(
                name: "IX_Mevzuat_DosyaId",
                table: "Mevzuat");

            migrationBuilder.DropColumn(
                name: "OneriDosyaId",
                table: "Oneri");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Mevzuat");

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

            migrationBuilder.AddColumn<int>(
                name: "MevzuatId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OneriId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya",
                column: "MevzuatId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya",
                column: "OneriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya",
                column: "MevzuatId",
                principalTable: "Mevzuat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya",
                column: "OneriId",
                principalTable: "Oneri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Mevzuat_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Oneri_OneriId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_MevzuatId",
                table: "Dosya");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_OneriId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "MevzuatId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "OneriId",
                table: "Dosya");

            migrationBuilder.AddColumn<int>(
                name: "OneriDosyaId",
                table: "Oneri",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Mevzuat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oneri_OneriDosyaId",
                table: "Oneri",
                column: "OneriDosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mevzuat_DosyaId",
                table: "Mevzuat",
                column: "DosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mevzuat_Dosya_DosyaId",
                table: "Mevzuat",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Oneri_Dosya_OneriDosyaId",
                table: "Oneri",
                column: "OneriDosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
