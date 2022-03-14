using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DbModified140322 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Etkinlik_Dosya_KapakId",
                table: "Etkinlik");

            migrationBuilder.DropForeignKey(
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_Etkinlik_KapakId",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "HaberDuyuru");

            migrationBuilder.DropColumn(
                name: "KapakId",
                table: "Etkinlik");

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikId",
                table: "Video",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HaberDuyuruId",
                table: "Video",
                type: "int",
                nullable: true);

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
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "HaberDuyuru",
                type: "VarChar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EtkinlikId",
                table: "Dosya",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_EtkinlikId",
                table: "Video",
                column: "EtkinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Video",
                column: "HaberDuyuruId");

            migrationBuilder.CreateIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru",
                column: "No");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_EtkinlikId",
                table: "Dosya",
                column: "EtkinlikId");

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
                principalColumn: "Id");

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
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_Etkinlik_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Etkinlik_EtkinlikId",
                table: "Video");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_HaberDuyuru_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_EtkinlikId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_HaberDuyuru_No",
                table: "HaberDuyuru");

            migrationBuilder.DropIndex(
                name: "IX_Dosya_EtkinlikId",
                table: "Dosya");

            migrationBuilder.DropColumn(
                name: "EtkinlikId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "HaberDuyuruId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "EtkinlikId",
                table: "Dosya");

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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "HaberDuyuru",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar");

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
                name: "IX_HaberDuyuru_VideoId",
                table: "HaberDuyuru",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_KapakId",
                table: "Etkinlik",
                column: "KapakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosya_HaberDuyuru_HaberDuyuruId",
                table: "Dosya",
                column: "HaberDuyuruId",
                principalTable: "HaberDuyuru",
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
                name: "FK_HaberDuyuru_Video_VideoId",
                table: "HaberDuyuru",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
