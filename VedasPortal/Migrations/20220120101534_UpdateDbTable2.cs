using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedasPortal.Migrations
{
    public partial class UpdateDbTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtkinlikDurumlari_DosyaYuklemeleri_DosyaId",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropForeignKey(
                name: "FK_Yayinlar_DosyaYuklemeleri_DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropIndex(
                name: "IX_Yayinlar_DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropIndex(
                name: "IX_EtkinlikDurumlari_DosyaId",
                table: "EtkinlikDurumlari");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "Yayinlar");

            migrationBuilder.DropColumn(
                name: "DosyaId",
                table: "EtkinlikDurumlari");

            migrationBuilder.AddColumn<byte[]>(
                name: "DosyaYolu",
                table: "Yayinlar",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DosyaYolu",
                table: "EtkinlikDurumlari",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosyaYolu",
                table: "Yayinlar");

            migrationBuilder.DropColumn(
                name: "DosyaYolu",
                table: "EtkinlikDurumlari");

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "Yayinlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DosyaId",
                table: "EtkinlikDurumlari",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Yayinlar_DosyaId",
                table: "Yayinlar",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikDurumlari_DosyaId",
                table: "EtkinlikDurumlari",
                column: "DosyaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtkinlikDurumlari_DosyaYuklemeleri_DosyaId",
                table: "EtkinlikDurumlari",
                column: "DosyaId",
                principalTable: "DosyaYuklemeleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yayinlar_DosyaYuklemeleri_DosyaId",
                table: "Yayinlar",
                column: "DosyaId",
                principalTable: "DosyaYuklemeleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
