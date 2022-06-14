using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class DosyaMdfImageFile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Dosya_VidyoId",
                table: "Yorum");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_ImageFile_DosyaId",
                table: "Yorum");

            migrationBuilder.RenameColumn(
                name: "VidyoId",
                table: "Yorum",
                newName: "ImageFileId");

            migrationBuilder.RenameIndex(
                name: "IX_Yorum_VidyoId",
                table: "Yorum",
                newName: "IX_Yorum_ImageFileId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "ImageFile",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "ImageFile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
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
                name: "Adi",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Dosya_DosyaId",
                table: "Yorum",
                column: "DosyaId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_ImageFile_ImageFileId",
                table: "Yorum",
                column: "ImageFileId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Dosya_DosyaId",
                table: "Yorum");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_ImageFile_ImageFileId",
                table: "Yorum");

            migrationBuilder.RenameColumn(
                name: "ImageFileId",
                table: "Yorum",
                newName: "VidyoId");

            migrationBuilder.RenameIndex(
                name: "IX_Yorum_ImageFileId",
                table: "Yorum",
                newName: "IX_Yorum_VidyoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "ImageFile",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "ImageFile",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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
                name: "Adi",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Dosya",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Dosya_VidyoId",
                table: "Yorum",
                column: "VidyoId",
                principalTable: "Dosya",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_ImageFile_DosyaId",
                table: "Yorum",
                column: "DosyaId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
