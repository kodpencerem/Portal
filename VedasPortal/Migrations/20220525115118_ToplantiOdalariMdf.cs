using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class ToplantiOdalariMdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi");
                     
            migrationBuilder.AlterColumn<int>(
                name: "ToplantiMerkeziId",
                table: "ToplantiOdasi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "ToplantiOdasi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "ToplantiOdasi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "ToplantiOdasi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi");

            migrationBuilder.AlterColumn<int>(
                name: "ToplantiMerkeziId",
                table: "ToplantiOdasi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "ToplantiOdasi",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "ToplantiOdasi",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "ToplantiOdasi",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "ToplantiId",
                table: "Merkez",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merkez_ToplantiId",
                table: "Merkez",
                column: "ToplantiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merkez_Toplanti_ToplantiId",
                table: "Merkez",
                column: "ToplantiId",
                principalTable: "Toplanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToplantiOdasi_Merkez_ToplantiMerkeziId",
                table: "ToplantiOdasi",
                column: "ToplantiMerkeziId",
                principalTable: "Merkez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
