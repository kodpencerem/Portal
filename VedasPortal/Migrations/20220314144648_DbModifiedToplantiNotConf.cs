using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModifiedToplantiNotConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_Dosya_GetDosyaId",
                table: "ToplantiNotu");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiNotu_GetDosyaId",
                table: "ToplantiNotu");

            migrationBuilder.DropColumn(
                name: "GetDosyaId",
                table: "ToplantiNotu");

            migrationBuilder.AddColumn<int>(
                name: "ToplantiMerkeziId",
                table: "ToplantiTakvimi",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ToplantiNotu",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "ToplantiNotu",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Konu",
                table: "ToplantiNotu",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "ToplantiNotu",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "ToplantiNotu",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "ToplantiNotu",
                type: "VarChar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "ToplantiNotu",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Birimler",
                table: "ToplantiNotu",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Baslik",
                table: "ToplantiNotu",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AltBaslik",
                table: "ToplantiNotu",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "ToplantiNotu",
                type: "Bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "ToplantiNotu",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToplantiNotuId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiTakvimi_ToplantiMerkeziId",
                table: "ToplantiTakvimi",
                column: "ToplantiMerkeziId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya",
                column: "ToplantiNotuId",
                principalTable: "ToplantiNotu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiTakvimi_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiTakvimi",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_ToplantiNotu_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu");

            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiTakvimi_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropIndex(
                name: "IX_ToplantiTakvimi_ToplantiMerkeziId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "ToplantiMerkeziId",
                table: "ToplantiTakvimi");

            migrationBuilder.DropColumn(
                name: "ToplantiNotuId",
                table: "Dosya");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ToplantiNotu",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SilenKullanici",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Konu",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "ToplantiNotu",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "KaydedenKullanici",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DuzenleyenKullanici",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DuzenlemeTarihi",
                table: "ToplantiNotu",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Birimler",
                table: "ToplantiNotu",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");

            migrationBuilder.AlterColumn<string>(
                name: "Baslik",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "AltBaslik",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<bool>(
                name: "AktifPasif",
                table: "ToplantiNotu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "ToplantiNotu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AddColumn<int>(
                name: "GetDosyaId",
                table: "ToplantiNotu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToplantiNotu_GetDosyaId",
                table: "ToplantiNotu",
                column: "GetDosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_Dosya_GetDosyaId",
                table: "ToplantiNotu",
                column: "GetDosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiNotu_ToplantiMerkezi_ToplantiMerkeziId",
                table: "ToplantiNotu",
                column: "ToplantiMerkeziId",
                principalTable: "ToplantiMerkezi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
